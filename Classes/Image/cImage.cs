using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeImageAPI;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;

namespace HCSAnalyzer
{

    

    public partial class cImage
    {
        
        float[][] Data = null;
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

            this.Data = new float[NumChannels][];
            for(int IdxChannel=0;IdxChannel<NumChannels;IdxChannel++)
                this.Data[IdxChannel] = new float[Width * Height * Depth];
        }

        public cImage(cImage Source)
        {
            this.NumChannels = Source.NumChannels;
            this.Width = Source.Width;
            this.Height = Source.Height;
            this.Depth = Source.Depth;


            this.Data = new float[Source.NumChannels][];
            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                this.Data[IdxChannel] = new float[Source.Width * Source.Height * Source.Depth];
        }


        public Image CurrentMSImage;

        public cImage(string Path)
        {

            this.Name = Path;
            FreeImageAPI.FIMULTIBITMAP LoadedMultiPageImage = FreeImage.OpenMultiBitmap(FREE_IMAGE_FORMAT.FIF_TIFF, Path, false, true, true, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
            FreeImageAPI.FIBITMAP LoadedPage = FreeImage.LockPage(LoadedMultiPageImage,0);
            FreeImageAPI.FIBITMAP LoadedImage = FreeImage.ConvertToStandardType(LoadedPage, true);

            this.Width = (int)FreeImage.GetWidth(LoadedImage);
            this.Height = (int)FreeImage.GetHeight(LoadedImage);
            this.Depth = 1;
            FreeImage.FlipVertical(LoadedImage);

            CurrentMSImage = (Image)FreeImage.GetBitmap(LoadedImage);

            //FormForImageDisplay NewDispl = new FormForImageDisplay();
            //NewDispl.pictureBoxForImage.Image = (Image)FreeImage.GetBitmap(LoadedImage);
            //NewDispl.Show();

            this.NumChannels = 1;
            this.Data = new float[this.NumChannels][];
            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                this.Data[IdxChannel] = new float[this.Width * this.Height * this.Depth];

            if (LoadedImage.IsNull) return;

        }


        #endregion








    }
}
