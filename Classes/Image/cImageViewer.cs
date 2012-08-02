using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using System.Windows.Forms;
using HCSAnalyzer.ObjectForNotations;


namespace HCSAnalyzer
{
    public class cImageViewer : FormForImageDisplay
    {
        public cImage AssociatedImage;
        public Timer timerForDisplay;
      //  private System.ComponentModel.IContainer components;
        public List<cObjectForAnnotation> ListObjectForNotations = new List<cObjectForAnnotation>();


        Graphics ThisGraph;

        public void DrawPic()
        {

            ThisGraph = panelForImage.CreateGraphics();
               ThisGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            ThisGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;         
            ThisGraph.DrawImage(AssociatedImage.CurrentMSImage, new Point(0, 0));

            //   ThisGraph.Clear(Color.White);
            //NewWindow.pictureBoxForImage.Image = (Image)images[(int)NewWindow.numericUpDownIdxImage.Value];
            //Graphics bmG = Graphics.FromImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value]);
            //ThisGraph.DrawImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value], new Point(0, 0));

            //foreach (cObjectForAnnotation TmpObj in ListObjectForNotations)
            //{
            //    if (TmpObj.GetType() == typeof(cString))
            //        ThisGraph.DrawString(((cString)TmpObj).Text, new Font(FontFamily.GenericSansSerif, ((cString)TmpObj).Size), new SolidBrush(((cString)TmpObj).ObjectColor), ((cString)TmpObj).PosX, ((cString)TmpObj).PosY);

            //    if (TmpObj.GetType() == typeof(cDisk))
            //        ThisGraph.FillEllipse(new SolidBrush(((cDisk)TmpObj).ObjectColor), ((cDisk)TmpObj).PosX, ((cDisk)TmpObj).PosY, ((cDisk)TmpObj).Size / 2, ((cDisk)TmpObj).Size / 2);
            //}
            DrawLayers();
        }

        public void DrawLayers()
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

        private void panelForImage_Paint(object sender, PaintEventArgs e)
        {
            DrawPic();
        }

        public void Display()
        {

        
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForImage_Paint);
            //this.timerForDisplay = new Timer();
            //this.timerForDisplay.Tick += new EventHandler(timerForDisplay_Tick);
            //this.timerForDisplay.Interval = (1000) * (1);              // Timer will tick evert second
            //this.timerForDisplay.Enabled = true;                       // Enable the timer
            //this.timerForDisplay.Start();                              // Start the timer


            this.Width = AssociatedImage.Width + 20;
            this.Height = AssociatedImage.Height + 40;
            this.Show();   
            

        }

        public cImageViewer()
        {
        }

        public void SetImage(cImage Image)
        {
            this.AssociatedImage = Image;
            this.Text = Image.Name;
        }


        public void AddNotation(cObjectForAnnotation ObjectForNotation)
        {
            this.ListObjectForNotations.Add(ObjectForNotation);
        }


        //void timerForDisplay_Tick(object sender, EventArgs e)
        //{
        //    this.Text = DateTime.Now.ToString();

        //    //foreach (cObjectForAnnotation TmpObj in ListObjectForNotations)
        //    //{

        //    //    if (TmpObj.GetType() == typeof(cDisk))
        //    //    {
        //    //        //TmpObj.PosX++;
        //    //        //ThisGraph.FillEllipse(new SolidBrush(((cDisk)TmpObj).ObjectColor), ((cDisk)TmpObj).PosX, ((cDisk)TmpObj).PosY, ((cDisk)TmpObj).Size / 2, ((cDisk)TmpObj).Size / 2);
        //    //    }
        //    //}
        
        //    DrawLayers();


        //}

        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.timerForDisplay = new System.Windows.Forms.Timer(this.components);
        //    this.SuspendLayout();
        //    // 
        //    // timerForDisplay
        //    // 
        //    this.timerForDisplay.Enabled = true;
        //    this.timerForDisplay.Tick += new System.EventHandler(this.timerForDisplay_Tick);
        //    // 
        //    // cImageViewer
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.ClientSize = new System.Drawing.Size(604, 366);
        //    this.Name = "cImageViewer";
        //    this.ResumeLayout(false);

        //}


    }

}





namespace HCSAnalyzer.ObjectForNotations
{
    public abstract class cObjectForAnnotation
    {
        public float PosX;
        public float PosY;
        public Color ObjectColor;
        public float Size;
    }

    public class cString : cObjectForAnnotation
    {
        public string Text;

        public cString(string Text, Point Position, Color TextColor, float Size)
        {
            this.ObjectColor = TextColor;
            this.Text = Text;
            this.PosX = Position.X;
            this.PosY = Position.Y;
            this.Size = Size;
        }
    }


    public class cDisk : cObjectForAnnotation
    {
        public cDisk(Point Position, Color DiskColor, float Radius)
        {
            this.ObjectColor = DiskColor;
            this.PosX = Position.X;
            this.PosY = Position.Y;
            this.Size = Radius;
        }
    }

}
