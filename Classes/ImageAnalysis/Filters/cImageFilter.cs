using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeImageAPI;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using ImageAnalysis;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;

namespace ImageAnalysisFiltering
{
    public partial class cImageFilter
    {
        //float[][] Data = null;
        //public int Width    { get; private set;}
    }


    public partial class cImageFilterMedian : cImageFilter
    {
        float Min(float[] input)
        {
            float min = float.MaxValue;
            foreach (float f in input) if (f < min) min = f;
            return min;
        }

        float Max(float[] input)
        {
            float max = float.MinValue;
            foreach (float f in input) if (f > max) max = f;
            return max;
        }


        float[] Rescale(float[] input, float[] output, float minBound, float maxBound)
        {
            float min = Min(input), max = Max(input);
            if (min == max)
            {
                for (int i = 0; i < input.Length; i++) output[i] = minBound;

                //Console.WriteLine("Rescale: input is constant and has been set to " + minBound);
            }
            else
                for (int i = 0; i < input.Length; i++)
                    output[i] = ((maxBound - minBound) * (input[i] - min) / (max - min)) + minBound;

            return output;
        }


        cImage Rescale(cImage input, int inputChannel, cImage output, int outputChannel, float minBound, float maxBound)
        {
            float min = input.Data[inputChannel].Data.Min();
            float max = input.Data[inputChannel].Data.Max();
            if (min == max)
            {
                for (int i = 0; i < input.Height*input.Width; i++) output.Data[outputChannel].Data[i] = minBound;
            }
            else
                for (int i = 0; i < input.Width*input.Height; i++)
                    output.Data[outputChannel].Data[i] = ((maxBound - minBound) * (input.Data[inputChannel].Data[i] - min) / (max - min)) + minBound;


            return output;
        }

    /// <summary> Rescales each band of the given image to [minBound,maxBound] 
    /// </summary>
    /// <param name="input">the input image</param>
    /// <param name="output">the output image</param>
    /// <param name="minBound">the final minimum value</param>
    /// <param name="maxBound">the final maximum value</param>
          //private cImage Rescale(cImage input, cImage output, float minBound, float maxBound)
          //{
          //    for (int band = 0; band < input.NumChannels; band++) Rescale(input.Data[band], output.Data[band], minBound, maxBound);

          //}

 
        public int radius = 3;
        public int HistoSize = 256;
        public bool IsSliceBySliceRescaling = false;
        public cImage input   { get; private set;}
        public cImage output { get; private set; }

        public int inputBand;
        public int outputBand;



        ///<summary>
        ///Median filter by Huang's method (C=O(r))
        ///!!! the image will be discretized according to HistoSize !!!
        ///</summary>
        ///<param name="input">input image</param>
        ///<param name="inputBand">input channel</param>
        ///<param name="output">output image</param>
        ///<param name="outputBand">output channel</param>
        ///<param name="radius">filter radius</param>
        ///<param name="HistoSize">Histogram number of bins</param>
        ///<param name="IsSliceBySliceRescaling">false : 3D rescaling; true : slice by slice rescaling</param>
        public cImageFilterMedian(cImage input, int inputBand, cImage output, int outputBand)
        {
            this.input = input;
            this.inputBand = inputBand;
            this.output = output;
            this.outputBand = outputBand;


        }

        public void Run()
        {
        
        
            // first we have to convert the image with the right number of color
            cImage RescaledInput = new cImage(input.Width,
                                         input.Height,
                                         input.Depth,
                                         1);
            int[] Histo = new int[HistoSize];

            Rescale(input, inputBand, RescaledInput, 0, 0, HistoSize - 1);

            float[] inp = RescaledInput.Data[0].Data;
            float[] outp = output.Data[outputBand].Data;
            int PosX, PosY;

            for (int depth = 0; depth < input.Depth; depth++)
            {
                int i, j, ki, kj;

                int Value = 0;
                int IdxFinal = 0;
                int Threshold = ((2 * radius + 1) * (2 * radius + 1)) / 2;

                #region main loop
                for (j = 0; j < input.Height; j++)
                {
                    for (int Idx = 0; Idx < HistoSize; Idx++)
                        Histo[Idx] = 0;

                    for (kj = -radius; kj <= radius; kj++)
                        for (ki = -radius; ki <= radius; ki++)
                        {
                            PosX = ki;
                            if (PosX < 0) PosX = -PosX - 1;
                            else if (PosX >= input.Width) PosX = 2 * input.Width - PosX - 1;
                            PosY = kj + j;
                            if (PosY < 0) PosY = -PosY - 1;
                            else if (PosY >= input.Height) PosY = 2 * input.Height - PosY - 1;

                            Histo[(int)inp[PosX + PosY * input.Width + depth * input.SliceSize]]++;
                        }

                    Value = 0;
                    IdxFinal = 0;
                    while (Value < Threshold)
                    {
                        Value += Histo[IdxFinal];
                        IdxFinal++;
                    }
                    outp[radius + 1 + j * input.Width + depth * input.SliceSize] = IdxFinal;


                    //for (i = 0; i < input.Width; i++)
                    for (i = 0; i < input.Width/* - (radius + 1)*/; i++)
                    {
                        // remove the first column
                        for (int Idx = -radius; Idx <= radius; Idx++)
                        {
                            PosX = i - radius - 1;
                            if (PosX < 0) PosX = -PosX - 1;
                            else if (PosX >= input.Width) PosX = 2 * input.Width - PosX - 1;

                            PosY = j + Idx;
                            if (PosY < 0) PosY = -PosY - 1;
                            else if (PosY >= input.Height) PosY = 2 * input.Height - PosY - 1;

                            Histo[(int)inp[PosX + PosY * input.Width + depth * input.SliceSize]]--;
                        }
                        // add the new column
                        for (int Idx = -radius; Idx <= radius; Idx++)
                        {
                            PosX = i + radius;
                            if (PosX < 0) PosX = -PosX - 1;
                            if (PosX >= input.Width) PosX = input.Width - (PosX - input.Width + 1);

                            PosY = j + Idx;
                            if (PosY < 0) PosY = -PosY - 1;
                            if (PosY >= input.Height) PosY = 2 * input.Height - PosY - 1;

                            Histo[(int)inp[PosX + PosY * input.Width + depth * input.SliceSize]]++;
                        }
                        Value = 0;
                        IdxFinal = 0;
                        while (Value < Threshold)
                        {
                            Value += Histo[IdxFinal];
                            IdxFinal++;
                        }
                        //return;
                        outp[i + j * input.Width + depth * input.SliceSize] = IdxFinal;

                    }
                }
                #endregion
            }

            return;
        }



    }

    public partial class cImageFilterConvolution : cImageFilter
    {
        
    }

    public partial class cImageFilterGaussianBlur : cImageFilterConvolution
    {

        double StdDev;
        public cImage input { get; private set; }
        public cImage output { get; private set; }

        public int inputBand;
        public int outputBand;


        public cImageFilterGaussianBlur(cImage input, int inputBand, cImage output, int outputBand, double StdDev)
        {
            this.StdDev = StdDev;
            this.input = input;
            this.inputBand = inputBand;
            this.output = output;
            this.outputBand = outputBand;
        }

        public void Run()
        {
            //Matrix<float> Signature1 = new Matrix<float>(this.Count, 2);
            //Matrix<float> Signature2 = new Matrix<float>(CompareTo.Count, 2);

            //for (int Idx = 0; Idx < this.Count; Idx++)
            //{
            //    Signature1[Idx, 0] = (float)this[Idx];
            //    Signature1[Idx, 1] = Idx;

            //    Signature2[Idx, 0] = (float)CompareTo[Idx];
            //    Signature2[Idx, 1] = Idx;
            //}

            //double ResutatEMD;
            //ResutatEMD = CvInvoke.cvCalcEMD2(Signature1.Ptr, Signature2.Ptr, DIST_TYPE.CV_DIST_L1, null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            //Emgu.CV.Structure.MCvPoint2D64f

           // IntPtr SrcImage = CvInvoke.cvCreateImage(


           // Matrix<float> Src = new Matrix<float>(input.Data[inputBand].Data.ToArray());
            
           // Matrix<float> Dst = new Matrix<float>(output.Data[inputBand].Data.ToArray());
          //  CvArray<IPL_DEPTH.IPL_DEPTH_32F> SRC = new 

          //IntPtr Src = CvInvoke.cvCreateImageHeader(new Size(input.Width, input.Height), IPL_DEPTH.IPL_DEPTH_32F, 1);
            //Src =  Marshal.UnsafeAddrOfPinnedArrayElement(input.Data[inputBand].Data, 0);
            //CvInvoke.image
            
            //ipl_image_p->imageData = my_float_image_data;
           // ipl_image_p->imageDataOrigin = ipl_image_p->imageData;

            Image<Gray, float> inputImage = new Image<Gray,float>(input.Width,input.Height);

            //float[,] SrcArray = new float[input.Width, input.Height];
            for (int j = 0; j < input.Height; j++)
                for (int i = 0; i < input.Width; i++)
                {
                    inputImage.Data[j, i, 0] = input.Data[inputBand].Data[i + j * input.Width];      
                }

            Image<Gray, float> smoothedImage = new Image<Gray, float>(inputImage.Width, inputImage.Height);

//            CvInvoke.cvSmooth(inputImage.Ptr, smoothedImage.Ptr, SMOOTH_TYPE.CV_MEDIAN, 5, 0, 0, 0);
            CvInvoke.cvSobel(inputImage.Ptr, smoothedImage.Ptr, 2, 2, 2);


            //CvInvoke.cvSmooth(smoothedImage.Ptr, smoothedImage.Ptr, SMOOTH_TYPE.CV_GAUSSIAN, 3, 0, 0, 0);
            for (int j = 0; j < input.Height; j++)
                for (int i = 0; i < input.Width; i++)
                {
                    output.Data[outputBand].Data[i + j * output.Width] = smoothedImage.Data[j,i,0];
                }



           // float[,] DestArray = new float[output.Width,output.Height];
        //    IntPtr MyintPtrDst = Marshal.UnsafeAddrOfPinnedArrayElement(DestArray, 0);


        //    CvInvoke.cvShowImage("Test", MyintPtr);


            //CvInvoke.cvSmooth(MyintPtrSrc, MyintPtrDst, SMOOTH_TYPE.CV_GAUSSIAN, 0, 0, 3, 0);


            //for (int j = 0; j < input.Height; j++)
            //    for (int i = 0; i < input.Width; i++)
            //    {
            //        output.Data[outputBand].Data[i + j * output.Width] = ;
            //    }



        //  IntPtr Dest = CvInvoke.cvCreateMat(output.Width, output.Height, MAT_DEPTH.CV_32F);



            
            
            //Src.Width = input.Width;



            


            //IntPtr ResImage = CvInvoke.cvCreateImage(new Size(output.Width, output.Height), IPL_DEPTH.IPL_DEPTH_32F, 1);

            //SrcImage =  Marshal.UnsafeAddrOfPinnedArrayElement(input.Data[inputBand].Data, 0);
            //ResImage = Marshal.UnsafeAddrOfPinnedArrayElement(output.Data[outputBand].Data, 0);

            
	// Perform a Gaussian blur
            //IntPtr widthPtr = new IntPtr();

           // IntPtr inputPtr = Marshal.UnsafeAddrOfPinnedArrayElement(input.Data[inputBand].Data, 0);
          //  IntPtr outputPtr = Marshal.UnsafeAddrOfPinnedArrayElement(output.Data[outputBand].Data, 0);


           // CvInvoke.cvSmooth(inputPtr ,outputPtr, SMOOTH_TYPE.CV_GAUSSIAN,0,0,3,3);
	//cvSmooth( img, out, CV_GAUSSIAN, 11, 11 );

	// Show the processed image
            //CvInvoke.cvShowImage("Example3-out", out);



         //   return ResutatEMD;


        }
    
    }
}
