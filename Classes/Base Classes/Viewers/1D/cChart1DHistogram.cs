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
using HCSAnalyzer.Classes.Base_Classes.DataProcessing;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{

    public class cChart1DHistogram : cGraphGeneral
    {
        protected ToolStripMenuItem SpecificContextMenu = null;
        public bool IsLine = false;
        public bool IsBar = false;
        public bool ISPoint = true;
        FormForSingleSlider SliderForMarkerSize = new FormForSingleSlider("Marker Size");
        FormForSingleSlider SliderForMarkerSizeBinSize = new FormForSingleSlider("Bin number");
        FormForSingleSlider SliderForOpacity = new FormForSingleSlider("Marker Opacity");
        public int Opacity = 255;
        public int MarkerSize = 10;
        public int BinNumber = 100;



        public cChart1DHistogram()
        {
            base.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssociatedChart_MouseClick);
            base.IsZoomableX = true;
            base.IsZoomableY = false;
        }




        void Refresh()
        {

            base.CurrentSeries.Clear();

           


            for (int IdxSerie = 0; IdxSerie < input.Count; IdxSerie++)
            {
                Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input[IdxSerie].Name + "_Histogram");

                cHistogramBuilder HB = new cHistogramBuilder();
                HB.SetInputData(new cExtendedTable(input[IdxSerie]));
                HB.BinNumber = this.BinNumber;

                HB.Run();

                cExtendedTable CurrentHistogram = HB.GetOutPut();

                //if (ISPoint)
                //    NewSerie.ChartType = SeriesChartType.Point;
                //if (IsLine)
                //    NewSerie.ChartType = SeriesChartType.Line;
                //if (IsBar)
               // NewSerie.ChartType = SeriesChartType.Column;

                NewSerie.ChartType = SeriesChartType.Column;




                for (int j = 0; j < CurrentHistogram[0].Count; j++)
                {
                    //this.chartForPoints.Series[0].Points[j].MarkerColor = Color.FromArgb(128, GlobalInfo.ListCellularPhenotypes[(int)MachineLearning.Classes[j]].ColourForDisplay);
                    DataPoint DP = new DataPoint();
                    double[] Value = new double[1];
                    Value[0] = CurrentHistogram[1][j];
                    DP.YValues = Value;
                    if (Value[0] == 0) continue;
                    DP.XValue = CurrentHistogram[0][j];
                    DP.Tag = CurrentHistogram[0].Tag;

                    // DP.MarkerSize = this.MarkerSize;
                    // DP.MarkerStyle = MarkerStyle.Circle;

                    if (IsBorder)
                    {
                        DP.MarkerBorderColor = Color.Black;
                        DP.MarkerBorderWidth = 1;
                        DP.BorderColor = Color.Black;
                        DP.BorderWidth = 1;
                    }
                    else
                    {
                        DP.BorderWidth = 0;
                        DP.MarkerBorderWidth = 0;
                    }

                    if (input[IdxSerie].Tag != null)
                    {
                         //if (j >= this.input[0].ListTags.Count) continue;

                        if (input[IdxSerie].Tag.GetType() == typeof(cWellClass))
                         {
                             DP.Color = ((cWellClass)(input[IdxSerie].Tag)).ColourForDisplay;
                             DP.ToolTip = ((cWellClass)(input[IdxSerie].Tag)).Name + "\n";
                         }
                        //DP.Tag = this.input[0].ListTags[j];

                        //if (DP.Tag.GetType() == typeof(cWell))
                        //{
                        //    DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        //    DP.ToolTip = ((cWell)(DP.Tag)).GetShortInfo() + Value[0];
                        //}
                        //if (DP.Tag.GetType() == typeof(cDescriptorsType))
                        //{
                        //    // DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        //    DP.ToolTip = ((cDescriptorsType)(DP.Tag)).GetShortInfo() + Value[0];
                        //    DP.AxisLabel = ((cDescriptorsType)(DP.Tag)).GetName();
                        //    base.CurrentChartArea.AxisX.Interval = 1;

                        //}
                        //if (DP.Tag.GetType() == typeof(cPlate))
                        //{
                        //    // DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        //    DP.ToolTip = ((cPlate)(DP.Tag)).Name + " : " + Value[0];
                        //    DP.AxisLabel = ((cPlate)(DP.Tag)).Name;
                        //    base.CurrentChartArea.AxisX.Interval = 1;

                        //}

                    }
                   
                    DP.ToolTip += DP.XValue.ToString("N2") + " :\n" + DP.YValues[0];
                    
                    NewSerie.Points.Add(DP);
                    //  if (Input[idxCol].ListTags != null)
                    //NewSerie.Points[IdxValue].Tag = Input[idxCol].ListTags[idxRow];
                    // if (this.IsDisplayValues) CurrentSeries.Points[IdxValue].Label = Value.ToString("N2");// string.Format("{0:0.###}", Math.Abs(Value));
                    //this.chartForPoints.Series[0].Points[j].MarkerBorderWidth = BorderSize;
                }
                base.CurrentSeries.Add(NewSerie);
            }
            base.Update();

        
        }



        public void Run()
        {
            this.SliderForMarkerSize.trackBar.Value = this.MarkerSize;
            this.SliderForMarkerSize.numericUpDown.Value = this.MarkerSize;
            this.SliderForOpacity.numericUpDown.Maximum = this.SliderForOpacity.trackBar.Maximum = 255;
            this.SliderForOpacity.trackBar.Value = this.Opacity;
            this.SliderForOpacity.numericUpDown.Value = this.Opacity;

            this.SliderForMarkerSizeBinSize.numericUpDown.Maximum = this.SliderForMarkerSizeBinSize.trackBar.Maximum = 1000;
            this.SliderForMarkerSizeBinSize.trackBar.Value = this.BinNumber;
            this.SliderForMarkerSizeBinSize.numericUpDown.Value = this.BinNumber;

            base.IsYAxis = true;
            base.IsBorder = true;

            this.Refresh();
          
            base.Run();
            base.CurrentTitle.Text = "Histogram(" + base.CurrentTitle.Text + ")";
        }


        public ToolStripMenuItem GetContextMenu()
        {
            SpecificContextMenu = new ToolStripMenuItem("Graph Options");

            ToolStripMenuItem ToolStripMenuItem_ChartLine = new ToolStripMenuItem("Line");
            ToolStripMenuItem_ChartLine.CheckOnClick = true;
            ToolStripMenuItem_ChartLine.Click += new System.EventHandler(this.ToolStripMenuItem_ChartLine);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartLine);

            ToolStripMenuItem ToolStripMenuItem_ChartBar = new ToolStripMenuItem("Column");
            ToolStripMenuItem_ChartBar.CheckOnClick = true;
            ToolStripMenuItem_ChartBar.Click += new System.EventHandler(this.ToolStripMenuItem_ChartBar);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartBar);

            ToolStripMenuItem ToolStripMenuItem_ChartPoint = new ToolStripMenuItem("Point");
            ToolStripMenuItem_ChartPoint.CheckOnClick = true;
            ToolStripMenuItem_ChartPoint.Click += new System.EventHandler(this.ToolStripMenuItem_ChartPoint);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartPoint);

            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_ChartOpacity = new ToolStripMenuItem("Opacity");
            ToolStripMenuItem_ChartOpacity.Click += new System.EventHandler(this.ToolStripMenuItem_ChartOpacity);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartOpacity);

            ToolStripMenuItem ToolStripMenuItem_MarkerSize = new ToolStripMenuItem("Marker Size");
            ToolStripMenuItem_MarkerSize.Click += new System.EventHandler(this.ToolStripMenuItem_MarkerSize);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_MarkerSize);


            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_BinNumber = new ToolStripMenuItem("Bin number");
            ToolStripMenuItem_BinNumber.Click += new System.EventHandler(this.ToolStripMenuItem_BinNumber);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_BinNumber);


            return this.SpecificContextMenu;
        }


        private void ToolStripMenuItem_BinNumber(object sender, EventArgs e)
        {
            if (this.SliderForMarkerSizeBinSize.ShowDialog() != DialogResult.OK) return;
            this.BinNumber = (int)this.SliderForMarkerSizeBinSize.numericUpDown.Value;
            this.Run();
            //base.Run();
        }


        private void ToolStripMenuItem_MarkerSize(object sender, EventArgs e)
        {
            if (this.SliderForMarkerSize.ShowDialog() != DialogResult.OK) return;
            this.MarkerSize = (int)this.SliderForMarkerSize.numericUpDown.Value;

            for (int j = 0; j < this.input.Count; j++)
            {
                foreach (var item in this.Series[j].Points)
                    item.MarkerSize = this.MarkerSize;
            }
        }

        private void ToolStripMenuItem_ChartOpacity(object sender, EventArgs e)
        {
            if (this.SliderForOpacity.ShowDialog() != DialogResult.OK) return;
            this.Opacity = (int)this.SliderForOpacity.numericUpDown.Value;


            for (int j = 0; j < this.input.Count; j++)
                foreach (var item in this.Series[j].Points)
                {
                    Color C = item.Color;
                    item.Color = Color.FromArgb(this.Opacity, C);
                }

        }

        private void ToolStripMenuItem_ChartBar(object sender, EventArgs e)
        {
            IsBar = !IsBar;
            for (int IdxSerie = 0; IdxSerie < base.CurrentSeries.Count; IdxSerie++)
            {
                // Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input[IdxSerie].Name);
                base.CurrentSeries[IdxSerie].ChartType = SeriesChartType.Column;
            }
            base.Update();
        }

        private void ToolStripMenuItem_ChartPoint(object sender, EventArgs e)
        {
            ISPoint = !ISPoint;

            for (int IdxSerie = 0; IdxSerie < base.CurrentSeries.Count; IdxSerie++)
            {
                // Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input[IdxSerie].Name);
                base.CurrentSeries[IdxSerie].ChartType = SeriesChartType.Point;

                foreach (var item in base.CurrentSeries[IdxSerie].Points)
                {
                    item.MarkerStyle = MarkerStyle.Circle;
                }
            }
            base.Update();
        }

        private void ToolStripMenuItem_ChartLine(object sender, EventArgs e)
        {
            IsLine = !IsLine;

            for (int IdxSerie = 0; IdxSerie < base.CurrentSeries.Count; IdxSerie++)
            {
                // Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input[IdxSerie].Name);
                base.CurrentSeries[IdxSerie].ChartType = SeriesChartType.Line;
            }
            base.Update();
        }


        private void AssociatedChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1) return;

            if (e.Button != MouseButtons.Right) return;

            ContextMenuStrip NewMenu = new ContextMenuStrip();
            foreach (var item in base.GetContextMenu(e))
                NewMenu.Items.Add(item);
            NewMenu.Items.Add(this.GetContextMenu());

            #region Selection process
            double MaxX = this.ChartAreas[0].CursorX.SelectionEnd;
            double MinX = this.ChartAreas[0].CursorX.SelectionStart;

            if (MaxX < MinX)
            {
                MinX = this.ChartAreas[0].CursorX.SelectionEnd;
                MaxX = this.ChartAreas[0].CursorX.SelectionStart;
            }

            double MaxY = this.ChartAreas[0].CursorY.SelectionEnd;
            double MinY = this.ChartAreas[0].CursorY.SelectionStart;

            if (MaxY < MinY)
            {
                MinY = this.ChartAreas[0].CursorY.SelectionEnd;
                MaxY = this.ChartAreas[0].CursorY.SelectionStart;
            }

            //cListWell ListWells = new cListWell();
            List<DataPoint> LDP = new List<DataPoint>();

            foreach (DataPoint item in this.Series[0].Points)
            {
                if ((item.XValue >= MinX) && (item.XValue <= MaxX) && (item.YValues[0] >= MinY) && (item.YValues[0] <= MaxY))
                {
                    if ((item.Tag != null) && (item.Tag.GetType() == typeof(cWell)))
                    {
                        // ListWells.Add((cWell)(item.Tag));
                        LDP.Add(item);

                        //((cWell)(item.Tag)).SetClass(5);
                        //item.Color = ((cWell)(item.Tag)).GetClassColor();
                    }
                }
            }

            if (LDP.Count > 0)
            {
                ToolStripMenuItem SpecificContextMenu = new ToolStripMenuItem("List " + LDP.Count + " wells");
                ToolStripMenuItem ToolStripMenuItem_ChangeClass = new ToolStripMenuItem("Classes");
                //ToolStripMenuItem_CopyClassToClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyClassToClipBoard);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChangeClass);

                cWell TmpWell = (cWell)(LDP[0].Tag);

                for (int i = 0; i < TmpWell.Parent.GlobalInfo.ListWellClasses.Count; i++)
                {
                    ToolStripMenuItem ToolStripMenuItem_NewClass = new ToolStripMenuItem(TmpWell.Parent.GlobalInfo.ListWellClasses[i].Name);
                    ToolStripMenuItem_NewClass.Click += new System.EventHandler(this.ToolStripMenuItem_NewClass);
                    ToolStripMenuItem_NewClass.Tag = LDP;
                    ToolStripMenuItem_ChangeClass.DropDownItems.Add(ToolStripMenuItem_NewClass);
                }
                NewMenu.Items.Add(SpecificContextMenu);
            }
            #endregion

            //HitTestResult Res = this.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            //if (Res.Series != null)
            //{
            //    DataPoint PtToTransfer = Res.Series.Points[Res.PointIndex];

            //    if (PtToTransfer.Tag != null)
            //    {
            //        if (PtToTransfer.Tag.GetType() == typeof(cWell))
            //        {
            //            cWell TmpWell = (cWell)(PtToTransfer.Tag);
            //            foreach (var item in TmpWell.GetExtendedContextMenu())
            //                NewMenu.Items.Add(item);
            //        }
            //        if (PtToTransfer.Tag.GetType() == typeof(cDescriptorsType))
            //        {
            //            cDescriptorsType TmpDesc = (cDescriptorsType)(PtToTransfer.Tag);
            //            foreach (var itemDesc in TmpDesc.GetExtendedContextMenu())
            //                NewMenu.Items.Add(itemDesc);
            //        }
            //        if (PtToTransfer.Tag.GetType() == typeof(cPlate))
            //        {
            //            cPlate TmpPlate = (cPlate)(PtToTransfer.Tag);
            //            NewMenu.Items.Add(TmpPlate.GetExtendedContextMenu());
            //        }


            //    }
            //}

            HitTestResult ResForTitle = this.HitTest(e.X, e.Y, ChartElementType.Title);
            if ((ResForTitle != null) && (ResForTitle.ChartElementType == ChartElementType.Title))
            {
                Title TmpTitle = (Title)ResForTitle.Object;

                if ((TmpTitle.Tag != null) && (TmpTitle.Tag.GetType() == typeof(cPlate)))
                {
                    cPlate TmpPlate = (cPlate)(TmpTitle.Tag);
                    if (TmpPlate.GetContextMenu() != null)
                        NewMenu.Items.Add(TmpPlate.GetContextMenu());


                }

            }
            NewMenu.DropShadowEnabled = true;
            NewMenu.Show(Control.MousePosition);
        }


        private void ToolStripMenuItem_NewClass(object sender, EventArgs e)
        {
            //CopyValuestoClipBoard();
            ToolStripMenuItem ParentMenu = (ToolStripMenuItem)(sender);
            int Classe = 0;
            int ResultClasse = -1;

            List<DataPoint> DP = (List<DataPoint>)(ParentMenu.Tag);


            foreach (var Class in ((cWell)(DP[0].Tag)).Parent.GlobalInfo.ListWellClasses)
            {
                if (Class.Name == sender.ToString())
                {
                    ResultClasse = Classe;
                    break;
                }

                Classe++;
            }

            foreach (var item in DP)
            {
                ((cWell)(item.Tag)).SetClass(ResultClasse);
                item.Color = ((cWell)(item.Tag)).GetClassColor();
            }

            ((cWell)(DP[0].Tag)).Parent.GetCurrentDisplayPlate().DisplayDistribution(((cWell)(DP[0].Tag)).Parent.ListDescriptors.CurrentSelectedDescriptorIdx, false);

        }





     
    }

}
