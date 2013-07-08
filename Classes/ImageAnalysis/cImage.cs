using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeImageAPI;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using HCSAnalyzer.Classes;

namespace ImageAnalysis
{
    public partial class cSingleChannelImage
    {
        public float[] Data;

        //public float Min { get; private set;}
        //public float Max { get; private set;}

        public cSingleChannelImage(int ImageSize)
        {
            Data = new float[ImageSize];
            //this.Min = this.Data.Min();
            //this.Max = this.Data.Max(); 
        }
    }
    

    public partial class cImage
    {
        public List<cSingleChannelImage> Data = new List<cSingleChannelImage>();
      //  public float[][] Data {get; private set;}
        public int Width    { get; private set;}
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public int NumChannels { get; private set; }
        public int SliceSize { get; private set; }
        public string Name;
      
        #region Constructors
        private cImage()
        {
            SliceSize = this.Width * this.Height;
        }

        public cImage(int Width, int Height, int Depth, int NumChannels)
        {
            this.NumChannels = NumChannels;
            this.Width = Width;
            this.Height = Height;
            this.Depth = Depth;
            this.SliceSize = this.Height * this.Width;

            this.Data = new List<cSingleChannelImage>();
            for(int IdxChannel=0;IdxChannel<NumChannels;IdxChannel++)
                this.Data.Add(new cSingleChannelImage(Width * Height * Depth));
        }

        public cImage(cImage Source)
        {
            this.NumChannels = Source.NumChannels;
            this.Width = Source.Width;
            this.Height = Source.Height;
            this.Depth = Source.Depth;
            this.SliceSize = this.Height * this.Width;

            this.Data = new List<cSingleChannelImage>();
            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                this.Data[IdxChannel] = new  cSingleChannelImage(Source.Width * Source.Height * Source.Depth);
        }
        //public Image CurrentMSImage;

        public cImage(string Path)
        {

            this.Name = Path;
            FreeImageAPI.FIMULTIBITMAP LoadedMultiPageImage = FreeImage.OpenMultiBitmap(FREE_IMAGE_FORMAT.FIF_TIFF, Path, false, true, true, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
            FreeImageAPI.FIBITMAP LoadedPage = FreeImage.LockPage(LoadedMultiPageImage,0);
            FreeImageAPI.FIBITMAP LoadedImage = FreeImage.ConvertToStandardType(LoadedPage, true);

            this.Width = (int)FreeImage.GetWidth(LoadedImage);
            this.Height = (int)FreeImage.GetHeight(LoadedImage);
            this.SliceSize = this.Width * this.Height;
            this.Depth = 1;
            FreeImage.FlipVertical(LoadedImage);

            //Image CurrentMSImage = (Image)FreeImage.GetBitmap(LoadedImage);
            FreeImageAPI.FIBITMAP Converted24Im = FreeImage.ConvertToGreyscale(LoadedImage);


            IntPtr Pt =  FreeImage.GetBits(LoadedImage);

            int bytes = Width*Height*3;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(Pt, rgbValues, 0,bytes);


            //FormForImageDisplay NewDispl = new FormForImageDisplay();
            //NewDispl.pictureBoxForImage.Image = (Image)FreeImage.GetBitmap(LoadedImage);
            //NewDispl.Show();

            NumChannels = 3;
          //  this.Data = new float[this.NumChannels][];
            this.Data = new List<cSingleChannelImage>();

            int GlobalIdx = 0;

            
                //cSingleChannelImage CI = new cSingleChannelImage(this.Width * this.Height * this.Depth);
                //CI.Data[0] = 10;
                for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                this.Data.Add(new cSingleChannelImage(this.Width * this.Height * this.Depth));
                
                
                for (int IdxY = 0; IdxY < this.Height; IdxY++)
                     for (int IdxX = 0; IdxX < this.Width; IdxX++)
                     {
                         for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                         this.Data[IdxChannel].Data[IdxX + IdxY * this.Width] = rgbValues[GlobalIdx++];
                     }

            //if (LoadedImage.IsNull) return;

        }
        #endregion
    }


    

}
