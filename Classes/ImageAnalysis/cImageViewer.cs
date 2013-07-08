using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using System.Windows.Forms;
using HCSAnalyzer.ObjectForNotations;
using ImageAnalysis;
using HCSAnalyzer.Classes;


namespace HCSAnalyzer
{
    public class cImageViewer : FormForImageDisplay
    {
        public Timer timerForDisplay;
      //  private System.ComponentModel.IContainer components;
        
        public void Display(cGlobalInfo GlobalInfo)
        {
        //    this.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForImage_Paint);
          //  this.Scroll += new ScrollEventHandler(cImageViewer_Scroll);
          //  this.MouseMove += new MouseEventHandler(panelForImage_MouseMove);
            //this.timerForDisplay = new Timer();
            //this.timerForDisplay.Tick += new EventHandler(timerForDisplay_Tick);
            //this.timerForDisplay.Interval = (1000) * (1);              // Timer will tick evert second
            //this.timerForDisplay.Enabled = true;                       // Enable the timer
            //this.timerForDisplay.Start();                              // Start the timer
           // base.panelForImage.Width = AssociatedImage.Width;
           // base.panelForImage.Height = AssociatedImage.Height;
            this.GlobalInfo = GlobalInfo;
            this.Width = AssociatedImage.Width + 40;
            this.Height = AssociatedImage.Height + statusStripForImageViewer.Height + 60;
            this.panelForImage.Width = AssociatedImage.Width;
            this.panelForImage.Height = AssociatedImage.Height;
            this.ViewDimX = AssociatedImage.Width;
            this.ViewDimY = AssociatedImage.Height;
           
            this.Show();   
            

        }
          
        public void SetImage(cImage Image)
        {
           // base.Width = 1000;
            this.AssociatedImage = Image;
            this.Text = Image.Name;

            this.LUTManager = new FormForLUTManager(this);

            for (int IdxLUT = 0; IdxLUT < this.AssociatedImage.NumChannels; IdxLUT++)
            {
                UserControlSingleLUT SingleLUT = new UserControlSingleLUT(this);
                SingleLUT.Location = new Point(0, IdxLUT * SingleLUT.Height);
                this.LUTManager.panelForLUTS.Controls.Add(SingleLUT);
            }

        }

        public void AddNotation(cObjectForAnnotation ObjectForNotation)
        {
            this.ListObjectForNotations.Add(ObjectForNotation);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // panelForImage
            // 
            //this.panelForImage.Size = new System.Drawing.Size(657, 393);
            // 
            // panelForInfo
            // 
            //this.panelForInfo.Size = new System.Drawing.Size(657, 96);
            // 
            // cImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(681, 519);
            this.Name = "cImageViewer";
            this.ResumeLayout(false);

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
