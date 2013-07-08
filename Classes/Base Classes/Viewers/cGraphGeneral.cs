using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Drawing;
using LibPlateAnalysis;
using System.IO;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.General;
using HCSAnalyzer.Classes.Base_Classes.GUI;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    public abstract class cGraphGeneral : Chart
    {
       // protected ToolStripMenuItem SpecificContextMenu = null;
        public cExtendedTable input;
        protected ChartArea CurrentChartArea = new ChartArea("ChartArea");
        protected List<Series> CurrentSeries = new List<Series>();

        public Color BackgroundColor = Color.FromArgb(250, 250, 250);
        public bool IsShadow = false;
        public bool IsBorder = true;

        public bool IsXAxis = false;
        public bool IsYAxis = false;

        public string LabelAxisX = "";
        public string LabelAxisY = "";

        public bool IsZoomableX = false;
        public bool IsZoomableY = false;
        public bool IsSelectable = false;
        public bool IsDisplayValues = false;
        public bool IsLegend = false;

        //FormForSingleSlider SliderForMinX = new FormForSingleSlider("Minimum X");
        FormForXYMinMax WindowForXYMinMax = new FormForXYMinMax();



        protected bool IsAllowDisplayValue = true;
        protected bool IsAllowDisplayTable = true;

        public Title CurrentTitle = new Title();
        //public SeriesChartType CurrentChartType;

        public cGraphGeneral()
        {
            this.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right);
        }


        protected void Run()
        {
            base.ChartAreas.Clear();
          //  CurrentSeries = new List<Series>();

            this.BackColor = this.BackgroundColor;

            CurrentChartArea.BackColor = this.BackgroundColor;
            CurrentTitle.Text = input.Name;
            CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            this.Titles.Clear();
            this.Titles.Add(CurrentTitle);

            // CurrentChartArea.Axes[1].Title = "Sum";
            CurrentChartArea.AxisX.LabelStyle.Format = "N2";
            CurrentChartArea.AxisY.LabelStyle.Format = "N2";

            CurrentChartArea.Axes[0].MajorGrid.Enabled = this.IsYAxis;
            //CurrentChartArea.Axes[0].Enabled = AxisEnabled.True;
            CurrentChartArea.Axes[0].LabelStyle.Enabled = true;
            CurrentChartArea.Axes[0].MajorGrid.LineColor = Color.LightGray;

            if (this.LabelAxisX != "")
                CurrentChartArea.Axes[0].Title = this.LabelAxisX;
            if (this.LabelAxisY != "")
                CurrentChartArea.Axes[1].Title = this.LabelAxisY;

            CurrentChartArea.Axes[1].LabelStyle.Enabled = true;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = this.IsXAxis;
            CurrentChartArea.Axes[1].MajorGrid.LineColor = Color.LightGray;
            //CurrentChartArea.Axes[1].Enabled = AxisEnabled.true;

            this.ChartAreas.Add(CurrentChartArea);
            this.Series.Clear();
            //this.CurrentSeries.Clear();

            foreach (var item in this.CurrentSeries)
            {
                if (this.IsShadow)
                    item.ShadowOffset = 1;
                else
                    item.ShadowOffset = 0;

                //foreach (var Pt in item.Points)
                //    Pt.IsValueShownAsLabel = this.IsDisplayValues;
                this.Series.Add(item);
            }

            if (this.IsDisplayValues)
            {
                foreach (var item in this.Series)
                    foreach (var Pt in item.Points)
                    {
                        Pt.LabelFormat = "N2";
                        Pt.IsValueShownAsLabel = true;
                        Pt.Font = new Font("Arial", 8);
                    }
            }

            //CurrentChartArea.CursorX.IsUserEnabled = this.IsZoomableX;
            CurrentChartArea.CursorX.IsUserSelectionEnabled = this.IsSelectable;
            CurrentChartArea.CursorY.IsUserSelectionEnabled = this.IsSelectable;

            CurrentChartArea.CursorX.SelectionColor = Color.Black;
            CurrentChartArea.CursorY.SelectionColor = Color.Black;

            CurrentChartArea.CursorX.LineColor = Color.Black;
            CurrentChartArea.CursorY.LineColor = Color.Black;
            CurrentChartArea.CursorX.LineWidth = 1;
            CurrentChartArea.CursorY.LineWidth = 1;

            //CurrentChartArea.AxisX.ScaleView.Zoomable = this.IsZoomableX;
            //CurrentChartArea.AxisX.ScrollBar.IsPositionedInside = true;
            if (this.IsZoomableX)
            {
                this.ChartAreas[0].AxisX.ScaleView.Zoomable = this.IsZoomableX;
                CurrentChartArea.CursorX.IsUserSelectionEnabled = this.IsZoomableX;
            }

            if (this.IsZoomableX)
            {
                this.ChartAreas[0].AxisY.ScaleView.Zoomable = this.IsZoomableY;
                CurrentChartArea.CursorY.IsUserSelectionEnabled = this.IsZoomableY;
            }
            if (this.IsSelectable)
            {
                this.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                CurrentChartArea.CursorX.IsUserSelectionEnabled = true;
                this.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
                CurrentChartArea.CursorY.IsUserSelectionEnabled = true;
            }

            CurrentChartArea.AxisX.IsLabelAutoFit = true;

            if (this.IsLegend)
                this.Legends.Add("Legend");

            //  this.Series[0].Sort(PointSortOrder.Ascending, "Y");

            // CurrentChartArea.CursorY.IsUserEnabled = this.IsZoomableY;
            //CurrentChartArea.CursorY.IsUserSelectionEnabled = this.IsZoomableY;
            // CurrentChartArea.AxisY.ScaleView.Zoomable = this.IsZoomableY;
            // CurrentChartArea.AxisY.ScrollBar.IsPositionedInside = true;
        }


        public List<ToolStripMenuItem> GetContextMenu(MouseEventArgs e)
        {
            List<ToolStripMenuItem> ToBeReturned = new List<ToolStripMenuItem>();

            ToolStripMenuItem SpecificContextMenu = new ToolStripMenuItem("General display");

            ToolStripMenuItem ToolStripMenuItem_BackGroundColor = new ToolStripMenuItem("Background Color");
            ToolStripMenuItem_BackGroundColor.Click += new System.EventHandler(this.ToolStripMenuItem_BackGroundColor);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_BackGroundColor);

            ToolStripMenuItem ToolStripMenuItem_IsShadow = new ToolStripMenuItem("Shadow");
            ToolStripMenuItem_IsShadow.CheckOnClick = true;
            ToolStripMenuItem_IsShadow.Checked = this.IsShadow;
            ToolStripMenuItem_IsShadow.Click += new System.EventHandler(this.ToolStripMenuItem_IsShadow);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_IsShadow);

            ToolStripMenuItem ToolStripMenuItem_IsBorder = new ToolStripMenuItem("Border");
            ToolStripMenuItem_IsBorder.CheckOnClick = true;
            ToolStripMenuItem_IsBorder.Checked = this.IsBorder;
            ToolStripMenuItem_IsBorder.Click += new System.EventHandler(this.ToolStripMenuItem_IsBorder);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_IsBorder);

            if (IsAllowDisplayValue)
            {
                ToolStripMenuItem ToolStripMenuItem_IsDisplayValues = new ToolStripMenuItem("Values");
                ToolStripMenuItem_IsDisplayValues.CheckOnClick = true;
                ToolStripMenuItem_IsDisplayValues.Checked = this.IsDisplayValues;
                ToolStripMenuItem_IsDisplayValues.Click += new System.EventHandler(this.ToolStripMenuItem_IsDisplayValues);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_IsDisplayValues);
            }

            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_XAxis = new ToolStripMenuItem("X-Grid");
            ToolStripMenuItem_XAxis.CheckOnClick = true;
            ToolStripMenuItem_XAxis.Checked = this.IsXAxis;
            ToolStripMenuItem_XAxis.Click += new System.EventHandler(this.ToolStripMenuItem_XAxis);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_XAxis);

            ToolStripMenuItem ToolStripMenuItem_YAxis = new ToolStripMenuItem("Y-Grid");
            ToolStripMenuItem_YAxis.CheckOnClick = true;
            ToolStripMenuItem_YAxis.Checked = this.IsYAxis;
            ToolStripMenuItem_YAxis.Click += new System.EventHandler(this.ToolStripMenuItem_YAxis);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_YAxis);

            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_CopyToClipBoard = new ToolStripMenuItem("Copy To Clipboard");
            ToolStripMenuItem_CopyToClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyToClipBoard);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_CopyToClipBoard);

            if (IsAllowDisplayTable)
            {
                ToolStripMenuItem ToolStripMenuItem_DisplayDataTable = new ToolStripMenuItem("Display Data Table");
                ToolStripMenuItem_DisplayDataTable.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayDataTable);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayDataTable);
            }
            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_Axis = new ToolStripMenuItem("Axis Min-Max");
            ToolStripMenuItem_Axis.Click += new System.EventHandler(this.ToolStripMenuItem_Axis);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Axis);
          //  ToolStripMenuItem ToolStripMenuItem_X = new ToolStripMenuItem("X");
            
            //Axis.DropDownItems.Add(ToolStripMenuItem_X);

            

            //ToolStripMenuItem ToolStripMenuItem_X = new ToolStripMenuItem("X");
         //   ToolStripMenuItem_X.Click += new System.EventHandler(this.ToolStripMenuItem_X);
          //  Axis.DropDownItems.Add(ToolStripMenuItem_X);

            ToBeReturned.Add(SpecificContextMenu);

            #region manage context menu on the graph elements
            HitTestResult Res = this.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (Res.Series != null)
            {
                DataPoint PtToTransfer = Res.Series.Points[Res.PointIndex];

                if (PtToTransfer.Tag != null)
                {
                    if (PtToTransfer.Tag.GetType() == typeof(cWell))
                    {
                        cWell TmpWell = (cWell)(PtToTransfer.Tag);
                        foreach (var item in TmpWell.GetExtendedContextMenu())
                            ToBeReturned.Add(item);
                    }
                    if (PtToTransfer.Tag.GetType() == typeof(cSingleBiologicalObject))
                    {
                        cSingleBiologicalObject TmpBiologicalObject = (cSingleBiologicalObject)(PtToTransfer.Tag);
                        foreach (var item in TmpBiologicalObject.GetExtendedContextMenu())
                            ToBeReturned.Add(item);
                    }
                    if (PtToTransfer.Tag.GetType() == typeof(cDescriptorsType))
                    {
                        cDescriptorsType TmpDesc = (cDescriptorsType)(PtToTransfer.Tag);
                        foreach (var itemDesc in TmpDesc.GetExtendedContextMenu())
                            ToBeReturned.Add(itemDesc);
                    }
                    if (PtToTransfer.Tag.GetType() == typeof(cPlate))
                    {
                        cPlate TmpPlate = (cPlate)(PtToTransfer.Tag);
                        ToBeReturned.Add(TmpPlate.GetExtendedContextMenu());
                    }
                    if (PtToTransfer.Tag.GetType() == typeof(cWellClass))
                    {
                        cWellClass TmpClass = (cWellClass)(PtToTransfer.Tag);
                        ToBeReturned.Add(TmpClass.GetExtendedContextMenu());
                    }
                }
            }

            HitTestResult ResForTitle = this.HitTest(e.X, e.Y, ChartElementType.Title);
            if ((ResForTitle != null) && (ResForTitle.Object != null))
            {
                Title TmpTitle = (Title)ResForTitle.Object;

                if ((TmpTitle.Tag != null) && (TmpTitle.Tag.GetType() == typeof(cPlate)))
                {
                    cPlate TmpPlate = (cPlate)(TmpTitle.Tag);
                    if (TmpPlate.GetContextMenu() != null)
                        ToBeReturned.Add(TmpPlate.GetContextMenu());
                }
            }


          //  HitTestResult ResForLegend = this.HitTest(e.X, e.Y, ChartElementType.LegendArea);
          ////  if (ResForTitle.Series != null)
          //  {
          //      MemoryStream ms = new MemoryStream();
          //      this.SaveImage(ms, ChartImageFormat.Bmp);
          //      Bitmap bm = new Bitmap(ms);

          //      Rectangle Rec = new Rectangle((int)this.Legends[0].Position.X,
          //                                    (int)this.Legends[0].Position.Y,
          //                                    (int)this.Legends[0].Position.Width,
          //                                    (int)this.Legends[0].Position.Height);

          //      System.Drawing.Imaging.PixelFormat format = bm.PixelFormat;
          //      Bitmap cloneBitmap = bm.Clone(Rec, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

          //      Clipboard.SetImage(cloneBitmap);

          //  }

            #endregion

            //ToolStripMenuItem ToolStripMenuItem_CopyToClipBoard = new ToolStripMenuItem("Copy To ClipBoard");
            //ToolStripMenuItem_CopyToClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyToClipBoard);
            //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_CopyToClipBoard);

            return ToBeReturned;
        }

        private void ToolStripMenuItem_Axis(object sender, EventArgs e)
        {
            WindowForXYMinMax.numericUpDownXMin.Value = (decimal)this.CurrentChartArea.AxisX.Minimum;
            WindowForXYMinMax.numericUpDownXMax.Value = (decimal)this.CurrentChartArea.AxisX.Maximum;

            WindowForXYMinMax.numericUpDownYMin.Value = (decimal)this.CurrentChartArea.AxisY.Minimum;
            WindowForXYMinMax.numericUpDownYMax.Value = (decimal)this.CurrentChartArea.AxisY.Maximum;


            if (WindowForXYMinMax.ShowDialog() == DialogResult.OK)
            {
                this.CurrentChartArea.AxisX.Minimum = (double)WindowForXYMinMax.numericUpDownXMin.Value;
                this.CurrentChartArea.AxisX.Maximum = (double)WindowForXYMinMax.numericUpDownXMax.Value;

                this.CurrentChartArea.AxisY.Minimum = (double)WindowForXYMinMax.numericUpDownYMin.Value;
                this.CurrentChartArea.AxisY.Maximum = (double)WindowForXYMinMax.numericUpDownYMax.Value;

            }

            //this.SliderForMinX.numericUpDown.Minimum = -1000000000000000;

            //this.SliderForMinX.numericUpDown.Value = (decimal)this.CurrentChartArea.AxisX.Minimum;//this.SliderForMinX.trackBar.Value 
            //if (this.SliderForMinX.ShowDialog() == DialogResult.OK)
            //{
            //    this.CurrentChartArea.AxisX.Minimum = (double)this.SliderForMinX.numericUpDown.Value;
            //}
        }

        private void ToolStripMenuItem_CopyToClipBoard(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            this.SaveImage(ms, ChartImageFormat.Bmp);
            Bitmap bm = new Bitmap(ms);
            Clipboard.SetImage(bm);
        }

        private void ToolStripMenuItem_DisplayDataTable(object sender, EventArgs e)
        {
            cDisplayExtendedTable CDE = new cDisplayExtendedTable();
            CDE.Set_Data(this.input);
            CDE.Run();
        }

        private void ToolStripMenuItem_XAxis(object sender, EventArgs e)
        {
            this.IsXAxis = !this.IsXAxis;
            this.CurrentChartArea.Axes[1].MajorGrid.Enabled = IsXAxis;
        }

        private void ToolStripMenuItem_YAxis(object sender, EventArgs e)
        {
            this.IsYAxis = !this.IsYAxis;
            this.CurrentChartArea.Axes[0].MajorGrid.Enabled = IsYAxis;
        }

        private void ToolStripMenuItem_IsShadow(object sender, EventArgs e)
        {
            this.IsShadow = !this.IsShadow;
            if (IsShadow)
                foreach (var item in this.Series)
                    item.ShadowOffset = 1;
            else
                foreach (var item in this.Series)
                    item.ShadowOffset = 0;
        }

        protected void ToolStripMenuItem_IsDisplayValues(object sender, EventArgs e)
        {
            this.IsDisplayValues = !this.IsDisplayValues;
            foreach (var item in this.Series)
                foreach (var Pt in item.Points)
                {
                    Pt.LabelFormat = "N2";
                    Pt.IsValueShownAsLabel = this.IsDisplayValues;
                }
        }


        private void ToolStripMenuItem_IsBorder(object sender, EventArgs e)
        {
            this.IsBorder = !this.IsBorder;
            if (IsBorder)
                foreach (var item in this.Series)
                    foreach (var Pt in item.Points)
                    {
                        //Pt.MarkerBorderWidth = 1;
                        //Pt.MarkerBorderColor = Color.Black;
                        //Pt.MarkerStyle = MarkerStyle.None;
                        Pt.MarkerBorderWidth = 1;
                        Pt.MarkerBorderColor = Color.Black;
                    }
            else
                foreach (var item in this.Series)
                    foreach (var Pt in item.Points)
                    {
                        Pt.MarkerBorderWidth = 0;
                        Pt.MarkerBorderColor = Color.Black;
                    }

            this.Update();
        }

        private void ToolStripMenuItem_BackGroundColor(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() != DialogResult.OK) return;
            this.BackgroundColor = CD.Color;
            this.CurrentChartArea.BackColor = this.BackgroundColor;
            this.BackColor = this.BackgroundColor;

            this.Update();
        }
    }


}
