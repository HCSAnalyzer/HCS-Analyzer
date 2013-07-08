using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageAnalysis;
using System.IO;
using HCSAnalyzer.ObjectForNotations;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms.FormsForImages
{
    public partial class FormForImageDisplay : Form
    {
        protected FormForLUTManager LUTManager = null;

        protected cImage AssociatedImage;
        int Zoom = 100;
        protected int ViewDimX;
        protected int ViewDimY;
        int StartViewX = 0;
        int StartViewY = 0;

        protected Graphics ThisGraph;
        protected Bitmap BT = null;
        public cGlobalInfo GlobalInfo;

        protected FormForImageDisplay()
        {


            InitializeComponent();
        }

        private void panelForImage_MouseWheel(object sender, MouseEventArgs e)
        {
            Zoom += e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (Zoom < 5) Zoom = 5;
            toolStripStatusLabelForZoom.Text = "Zoom: " + Zoom.ToString() + " %";
            this.StartViewX = this.HorizontalScroll.Value;
            this.StartViewY = this.VerticalScroll.Value;
            DrawPic();
        }

        private void panelForImage_MouseMove(object sender, MouseEventArgs e)
        {
            float ZoomFactor = Zoom / 100.0f;

            int PosX = e.X;
            int PosY = e.Y;

            if ((PosX >= 0) && (PosX < AssociatedImage.Width) && (PosY >= 0) && (PosY < AssociatedImage.Height))
            {


                toolStripStatusLabelForPosition.Text = "(" + (int)(PosX / ZoomFactor) + "," + (int)(PosY / ZoomFactor) + ")";
                float Value = AssociatedImage.Data[0].Data[PosX + PosY * AssociatedImage.Width];
            }
            //else
            //{
            //    toolStripStatusLabelForPosition.Text = "(#,#)";
            //}
        }

        private void displayScaleBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BT == null) return;
            MemoryStream ms = new MemoryStream();
            Clipboard.SetImage(BT);
        }

        //private void toolTip1_Popup(object sender, PopupEventArgs e)
        //{
        //    Point locationOnForm = panelForImage.FindForm().PointToClient(Control.MousePosition);
        //    string TextForToolTip = locationOnForm.X + "x" + locationOnForm.Y;
        //    toolTip1.SetToolTip(panelForImage, TextForToolTip);
        //    // float Value = AssociatedImage.Data[0].Data[PosX + PosY * AssociatedImage.Width];
        //    return;
        //}

        public void DrawPic()
        {
            if (this.LUTManager == null) return;

            ThisGraph = panelForImage.CreateGraphics();

            float ZoomFactor = Zoom / 100.0f;
            int NewWidth = (int)(AssociatedImage.Width * ZoomFactor);
            int NewHeight = (int)(AssociatedImage.Height * ZoomFactor);
            panelForImage.Width = NewWidth;
            panelForImage.Height = NewHeight;

            int PosViewX = (this.Width - NewWidth) / 2;
            int PosViewY = (this.Height - NewHeight) / 2;
            //   panelForImage.Location = new Point(PosViewX,PosViewY);

            BT = new Bitmap(NewWidth, NewHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, NewWidth, NewHeight);
            System.Drawing.Imaging.BitmapData bmpData = BT.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, BT.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            int scanline = Math.Abs(bmpData.Stride);

            // Declare an array to hold the bytes of the bitmap. 
            int bytes = scanline * NewHeight;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            byte CurrentRed;
            byte CurrentGreen;
            byte CurrentBlue;

            int RealX;
            int RealY;

            int NewStartX = (int)(this.StartViewX / ZoomFactor);
            int NewStartY = (int)(this.StartViewY / ZoomFactor);

            List<float> Min = new List<float>();
            List<float> Max = new List<float>();

            for (int IdxChannel = 0; IdxChannel < this.AssociatedImage.NumChannels; IdxChannel++)
            {
                if (this.LUTManager != null)
                {
                    UserControlSingleLUT SingleLUT = (UserControlSingleLUT)this.LUTManager.panelForLUTS.Controls[IdxChannel];
                    Min.Add((float)SingleLUT.numericUpDownMinValue.Value);
                    Max.Add((float)SingleLUT.numericUpDownMaxValue.Value);
                }
            }

            for (int IdxChannel = 0; IdxChannel < this.AssociatedImage.NumChannels; IdxChannel++)
            {
                UserControlSingleLUT SingleLUT = (UserControlSingleLUT)this.LUTManager.panelForLUTS.Controls[IdxChannel];
                if (SingleLUT.checkBoxIsActive.Checked == false) continue;
                for (int FullY = 0; FullY < NewHeight; FullY++)
                {
                    RealY = (int)(FullY / ZoomFactor) + NewStartY;
                    if (RealY >= AssociatedImage.Height) RealY = AssociatedImage.Height - 1;
                    for (int FullX = 0; FullX < NewWidth; FullX++)
                    {
                        RealX = (int)(FullX / ZoomFactor) + NewStartX;
                        if (RealX >= AssociatedImage.Width) RealX = AssociatedImage.Width - 1;

                        float Value = AssociatedImage.Data[IdxChannel].Data[RealX + RealY * AssociatedImage.Width];

                        int ConvertedValue = (int)((((SingleLUT.SelectedLUT[0].Length - 1) * (Value - Min[IdxChannel])) / (Max[IdxChannel] - Min[IdxChannel])));

                        if (ConvertedValue < 0) ConvertedValue = 0;
                        if (ConvertedValue >= SingleLUT.SelectedLUT[0].Length) ConvertedValue = SingleLUT.SelectedLUT[0].Length - 1;

                        CurrentRed = (byte)SingleLUT.SelectedLUT[0][ConvertedValue];
                        CurrentGreen = (byte)SingleLUT.SelectedLUT[1][ConvertedValue];
                        CurrentBlue = (byte)SingleLUT.SelectedLUT[2][ConvertedValue];

           
                        double NewValue = rgbValues[3 * FullX + FullY * scanline] + CurrentBlue;
                        if(NewValue>255) 
                            rgbValues[3 * FullX + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + FullY * scanline] += CurrentBlue;

                        NewValue = rgbValues[3 * FullX + 1 + FullY * scanline] + CurrentGreen;
                        if (NewValue > 255)
                            rgbValues[3 * FullX + 1 + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + 1 + FullY * scanline] += CurrentGreen;

                        NewValue = rgbValues[3 * FullX + 2 + FullY * scanline] + CurrentRed;
                        if(NewValue>255)
                            rgbValues[3 * FullX + 2 + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + 2 + FullY * scanline] += CurrentRed;
                       
                    }
                }
            }


            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            BT.UnlockBits(bmpData);

            // Draw the modified image.
            ThisGraph.DrawImage(BT, this.StartViewX, this.StartViewY);

            //Bitmap BT = new Bitmap(this.Width,this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Image ImageToDraw = (Image)BT;

            //ThisGraph.DrawImage(/*AssociatedImage.CurrentMSImage*/ ImageToDraw, new Point(0, 0));

            //   ThisGraph.Clear(Color.White);
            //NewWindow.pictureBoxForImage.Image = (Image)images[(int)NewWindow.numericUpDownIdxImage.Value];
            //Graphics bmG = Graphics.FromImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value]);
            //ThisGraph.DrawImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value], new Point(0, 0));

            foreach (cObjectForAnnotation TmpObj in ListObjectForNotations)
            {
                if (TmpObj.GetType() == typeof(cString))
                    ThisGraph.DrawString(((cString)TmpObj).Text, new Font(FontFamily.GenericSansSerif, ((cString)TmpObj).Size* ZoomFactor) , new SolidBrush(((cString)TmpObj).ObjectColor), ((cString)TmpObj).PosX, ((cString)TmpObj).PosY);

                if (TmpObj.GetType() == typeof(cDisk))
                    ThisGraph.FillEllipse(new SolidBrush(((cDisk)TmpObj).ObjectColor), ((cDisk)TmpObj).PosX, ((cDisk)TmpObj).PosY, (((cDisk)TmpObj).Size* ZoomFactor) / 2, (((cDisk)TmpObj).Size*ZoomFactor) / 2);
            }
            DrawLayers();
        }

        protected List<cObjectForAnnotation> ListObjectForNotations = new List<cObjectForAnnotation>();

        void DrawLayers()
        {
            // ThisGraph = panelForImage.CreateGraphics();
            foreach (cObjectForAnnotation TmpObj in ListObjectForNotations)
            {
                if (TmpObj.GetType() == typeof(cString))
                    ThisGraph.DrawString(((cString)TmpObj).Text, new Font(FontFamily.GenericSansSerif, ((cString)TmpObj).Size), new SolidBrush(((cString)TmpObj).ObjectColor), ((cString)TmpObj).PosX, ((cString)TmpObj).PosY);

                if (TmpObj.GetType() == typeof(cDisk))
                    ThisGraph.FillEllipse(new SolidBrush(((cDisk)TmpObj).ObjectColor), ((cDisk)TmpObj).PosX, ((cDisk)TmpObj).PosY, ((cDisk)TmpObj).Size / 2, ((cDisk)TmpObj).Size / 2);
            }
        }

        private void FormForImageDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            this.StartViewX = this.HorizontalScroll.Value;
            this.StartViewY = this.VerticalScroll.Value;
            DrawPic();
            //toolStripStatusLabelStartView.Text = "Start View: " + this.HorizontalScroll.Value + ":" + this.VerticalScroll.Value;
        }

        private void FormForImageDisplay_Resize(object sender, EventArgs e)
        {
            ViewDimX = this.Width - 46;
            ViewDimY = this.Height - 68;
            this.StartViewX = this.HorizontalScroll.Value;
            this.StartViewY = this.VerticalScroll.Value;
            DrawPic();
        }

        private void panelForImage_Paint(object sender, PaintEventArgs e)
        {
            DrawPic();
        }

        private void lUTManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LUTManager == null)
            {
                LUTManager.Show();
            }
            else
                this.LUTManager.Visible = true;

        }

        private void FormForImageDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.LUTManager.Close();
            //CurrentFormForImageDisplay
        }


    }
}
