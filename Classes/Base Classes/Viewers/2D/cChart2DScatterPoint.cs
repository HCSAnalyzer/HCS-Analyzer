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

    public class cChart2DScatterPoint : cGraphGeneral
    {
        protected ToolStripMenuItem SpecificContextMenu = null;
        public bool IsLine = false;
        public bool IsBar = false;
        public bool ISPoint = true;
        FormForSingleSlider SliderForMarkerSize = new FormForSingleSlider("Marker Size");
        FormForSingleSlider SliderForOpacity = new FormForSingleSlider("Marker Opacity");
        public int Opacity = 255;
        public int MarkerSize = 10;

        public cChart2DScatterPoint()
        {
            base.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssociatedChart_MouseClick);
        }

        public void Run()
        {
            this.SliderForMarkerSize.trackBar.Value = this.MarkerSize;
            this.SliderForMarkerSize.numericUpDown.Value = this.MarkerSize;
            this.SliderForOpacity.numericUpDown.Maximum = this.SliderForOpacity.trackBar.Maximum = 255;
            this.SliderForOpacity.trackBar.Value = this.Opacity;
            this.SliderForOpacity.numericUpDown.Value = this.Opacity;
            RefreshDisplay();
        }


        public int IdxDesc0 = 0;
        public int IdxDesc1 = 1;
        public int IdxDescForMarkerSize = -1;

        public void RefreshDisplay()
        {
            if (input.Count == 0) return;

            Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input.Name);

            base.LabelAxisX = input[IdxDesc0].Name;
            if (this.input.Count <= IdxDesc1) IdxDesc1 = this.input.Count - 1;
            base.LabelAxisY = input[IdxDesc1].Name;

            NewSerie.ChartType = SeriesChartType.Point;

            double _MinY = double.MaxValue;
            double _MinX = double.MaxValue;
            double _MaxX = double.MinValue;
            double _MaxY = double.MinValue;

            double TmpMinX, TmpMinY, TmpMaxX, TmpMaxY;
            double TMp;

            double MinVolume = 0;
            double MaxVolume = 0;
            if (this.IdxDescForMarkerSize >= 0)
            {
                MinVolume = this.input[this.IdxDescForMarkerSize].Min();
                MaxVolume = this.input[this.IdxDescForMarkerSize].Max();
            }



            for (int j = 0; j < this.input[0].Count; j++)
            {
                DataPoint DP = new DataPoint();

                TMp = this.input[IdxDesc0][j];
                if (TMp < _MinX) _MinX = TMp;
                else if (TMp > _MaxX) _MaxX = TMp;
                DP.XValue = TMp;

                double[] Value = new double[1];
                TMp = this.input[IdxDesc1][j];

                if (TMp < _MinY) _MinY = TMp;
                else if (TMp > _MaxY) _MaxY = TMp;

                Value[0] = TMp;
                DP.YValues = Value;
                if (this.IdxDescForMarkerSize < 0)
                    DP.MarkerSize = this.MarkerSize;
                else
                {
                 //   DP.MarkerSize = this.MarkerSize * 2;
                    int MarkerArea = (int)((50 * (this.input[this.IdxDescForMarkerSize][j] - MinVolume)) / (MaxVolume - MinVolume));
                    DP.MarkerSize = MarkerArea + this.MarkerSize;

                }

                DP.MarkerStyle = MarkerStyle.Circle;

                if (IsBorder)
                {
                    DP.MarkerBorderColor = Color.Black;
                    DP.MarkerBorderWidth = 1;
                }

                if (this.input[0].ListTags != null)
                {
                    if (j >= this.input[0].ListTags.Count) continue;
                    DP.Tag = this.input[0].ListTags[j];

                    if (DP.Tag.GetType() == typeof(cWell))
                    {
                        DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        DP.ToolTip = ((cWell)(DP.Tag)).GetShortInfo() + Value[0];
                    }
                    if (DP.Tag.GetType() == typeof(cSingleBiologicalObject))
                    {
                        DP.Color = ((cSingleBiologicalObject)(DP.Tag)).GetColor();
                        DP.ToolTip = ((cSingleBiologicalObject)(DP.Tag)).GetAssociatedPhenotype().Name + "\nValue: (" + DP.XValue.ToString("N2") + ":" + DP.YValues[0].ToString("N2") + ")";
                    }
                    if (DP.Tag.GetType() == typeof(cDescriptorsType))
                    {
                        // DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        DP.ToolTip = ((cDescriptorsType)(DP.Tag)).GetShortInfo() + Value[0];
                        DP.AxisLabel = ((cDescriptorsType)(DP.Tag)).GetName();
                        base.CurrentChartArea.AxisX.Interval = 1;
                    }
                    if (DP.Tag.GetType() == typeof(cPlate))
                    {
                        // DP.Color = ((cWell)(DP.Tag)).GetClassColor();
                        DP.ToolTip = ((cPlate)(DP.Tag)).Name + " : " + Value[0];
                        DP.AxisLabel = ((cPlate)(DP.Tag)).Name;
                        base.CurrentChartArea.AxisX.Interval = 1;
                    }
                }
                NewSerie.Points.Add(DP);
            }

            base.CurrentSeries.Clear();
            base.CurrentSeries.Add(NewSerie);
            base.Run();
            base.ChartAreas[0].AxisX.Minimum = _MinX;
            base.ChartAreas[0].AxisY.Minimum = _MinY;

            base.ChartAreas[0].AxisX.Maximum = _MaxX;
            base.ChartAreas[0].AxisY.Maximum = _MaxY;
            
            base.CurrentTitle.Text = input.Name + " - " + base.LabelAxisX + " vs. " + base.LabelAxisY + " (" + this.input[0].Count + " points)";

        }

        #region Context Menu
        public ToolStripMenuItem GetContextMenu()
        {
            SpecificContextMenu = new ToolStripMenuItem("Graph Options");

            //ToolStripMenuItem ToolStripMenuItem_ChartLine = new ToolStripMenuItem("Line");
            //ToolStripMenuItem_ChartLine.CheckOnClick = true;
            //ToolStripMenuItem_ChartLine.Click += new System.EventHandler(this.ToolStripMenuItem_ChartLine);
            //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartLine);

            //ToolStripMenuItem ToolStripMenuItem_ChartBar = new ToolStripMenuItem("Bar");
            //ToolStripMenuItem_ChartBar.CheckOnClick = true;
            //ToolStripMenuItem_ChartBar.Click += new System.EventHandler(this.ToolStripMenuItem_ChartBar);
            //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartBar);

            //ToolStripMenuItem ToolStripMenuItem_ChartPoint = new ToolStripMenuItem("Point");
            //ToolStripMenuItem_ChartPoint.CheckOnClick = true;
            //ToolStripMenuItem_ChartPoint.Click += new System.EventHandler(this.ToolStripMenuItem_ChartPoint);
            //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartPoint);

            // SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_ChartOpacity = new ToolStripMenuItem("Opacity");
            ToolStripMenuItem_ChartOpacity.Click += new System.EventHandler(this.ToolStripMenuItem_ChartOpacity);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChartOpacity);

            ToolStripMenuItem ToolStripMenuItem_MarkerSize = new ToolStripMenuItem("Marker Size");
            ToolStripMenuItem_MarkerSize.Click += new System.EventHandler(this.ToolStripMenuItem_MarkerSize);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_MarkerSize);

            SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem ToolStripMenuItem_XAxis = new ToolStripMenuItem("X-Axis");
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_XAxis);

            int IdxDesc = 0;
            foreach (var item in this.input)
            {
                ToolStripMenuItem ToolStripMenuItem_DescX = new ToolStripMenuItem(item.Name);
                ToolStripMenuItem_DescX.Tag = IdxDesc++;
                ToolStripMenuItem_DescX.Click += new System.EventHandler(this.ToolStripMenuItem_DescX);
                ToolStripMenuItem_XAxis.DropDownItems.Add(ToolStripMenuItem_DescX);

            }

            ToolStripMenuItem ToolStripMenuItem_YAxis = new ToolStripMenuItem("Y-Axis");
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_YAxis);

            IdxDesc = 0;
            foreach (var item in this.input)
            {
                ToolStripMenuItem ToolStripMenuItem_DescY = new ToolStripMenuItem(item.Name);
                ToolStripMenuItem_DescY.Tag = IdxDesc++;
                ToolStripMenuItem_DescY.Click += new System.EventHandler(this.ToolStripMenuItem_DescY);
                ToolStripMenuItem_YAxis.DropDownItems.Add(ToolStripMenuItem_DescY);

            }


            ToolStripMenuItem ToolStripMenuItem_MarkerSizeType = new ToolStripMenuItem("Marker Size Type");
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_MarkerSizeType);

            IdxDesc = -1;

            ToolStripMenuItem ToolStripMenuItem_DescMarkerSize = new ToolStripMenuItem("Constant");
            ToolStripMenuItem_DescMarkerSize.Tag = IdxDesc++;
            ToolStripMenuItem_DescMarkerSize.Click += new System.EventHandler(this.ToolStripMenuItem_DescMarkerSize);
            ToolStripMenuItem_MarkerSizeType.DropDownItems.Add(ToolStripMenuItem_DescMarkerSize);

            ToolStripSeparator TS = new ToolStripSeparator();
            ToolStripMenuItem_MarkerSizeType.DropDownItems.Add(TS);

            foreach (var item in this.input)
            {
                ToolStripMenuItem_DescMarkerSize = new ToolStripMenuItem(item.Name);
                ToolStripMenuItem_DescMarkerSize.Tag = IdxDesc++;
                ToolStripMenuItem_DescMarkerSize.Click += new System.EventHandler(this.ToolStripMenuItem_DescMarkerSize);
                ToolStripMenuItem_MarkerSizeType.DropDownItems.Add(ToolStripMenuItem_DescMarkerSize);

            }
            return this.SpecificContextMenu;
        }

        private void ToolStripMenuItem_DescMarkerSize(object sender, EventArgs e)
        {
            this.IdxDescForMarkerSize = (int)(((ToolStripMenuItem)(sender)).Tag);
            RefreshDisplay();
        }

        private void ToolStripMenuItem_DescX(object sender, EventArgs e)
        {
            this.IdxDesc0 = (int)(((ToolStripMenuItem)(sender)).Tag);
            RefreshDisplay();
        }

        private void ToolStripMenuItem_DescY(object sender, EventArgs e)
        {
            this.IdxDesc1 = (int)(((ToolStripMenuItem)(sender)).Tag);
            RefreshDisplay();
        }


        private void ToolStripMenuItem_MarkerSize(object sender, EventArgs e)
        {
            if (this.SliderForMarkerSize.ShowDialog() != DialogResult.OK) return;
            this.MarkerSize = (int)this.SliderForMarkerSize.numericUpDown.Value;

            //   for (int j = 0; j < this.input.Count; j++)
            {
                foreach (var item in this.Series[0].Points)
                    item.MarkerSize = this.MarkerSize;
            }
        }

        private void ToolStripMenuItem_ChartOpacity(object sender, EventArgs e)
        {
            if (this.SliderForOpacity.ShowDialog() != DialogResult.OK) return;
            this.Opacity = (int)this.SliderForOpacity.numericUpDown.Value;


            //for (int j = 0; j < this.input.Count; j++)
            foreach (var item in this.Series[0].Points)
            {
                Color C = item.Color;
                item.Color = Color.FromArgb(this.Opacity, C);
            }

        }

        //private void ToolStripMenuItem_ChartBar(object sender, EventArgs e)
        //{
        //    IsBar = !IsBar;
        //    for (int IdxSerie = 0; IdxSerie < base.CurrentSeries.Count; IdxSerie++)
        //    {
        //        // Series NewSerie = new System.Windows.Forms.DataVisualization.Charting.Series(base.input[IdxSerie].Name);
        //        base.CurrentSeries[IdxSerie].ChartType = SeriesChartType.Column;
        //    }
        //    base.Update();
        //}

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

            cListWell ListWells = new cListWell(this);
            List<DataPoint> LDP = new List<DataPoint>();
            //cListWell ListWellsToProcess = new cListWell();


            foreach (DataPoint item in this.Series[0].Points)
            {
                if ((item.XValue >= MinX) && (item.XValue <= MaxX) && (item.YValues[0] >= MinY) && (item.YValues[0] <= MaxY))
                {
                    if ((item.Tag != null) && (item.Tag.GetType() == typeof(cWell)))
                    {
                        ListWells.Add((cWell)(item.Tag));
                        LDP.Add(item);
                    }
                }
            }

            if (LDP.Count > 0)
            {
                ToolStripMenuItem SpecificContextMenu = ListWells.GetContextMenu(); //new ToolStripMenuItem("List " + LDP.Count + " wells");
                //ToolStripMenuItem ToolStripMenuItem_ChangeClass = ListWells.GetContextMenu();// new ToolStripMenuItem("Classes");
                //ToolStripMenuItem_CopyClassToClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyClassToClipBoard);
                //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChangeClass);

                //cWell TmpWell = (cWell)(LDP[0].Tag);

                //for (int i = 0; i < TmpWell.Parent.GlobalInfo.ListWellClasses.Count; i++)
                //{
                //    ToolStripMenuItem ToolStripMenuItem_NewClass = new ToolStripMenuItem(TmpWell.Parent.GlobalInfo.ListWellClasses[i].Name);
                //    ToolStripMenuItem_NewClass.Click += new System.EventHandler(this.ToolStripMenuItem_NewClass);
                //    ToolStripMenuItem_NewClass.Tag = LDP;
                //    ToolStripMenuItem_ChangeClass.DropDownItems.Add(ToolStripMenuItem_NewClass);
                //}
                NewMenu.Items.Add(SpecificContextMenu);
            }
            #endregion


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
        #endregion
    }

}
