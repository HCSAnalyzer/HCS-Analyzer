using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Windows.Forms;
using HCSAnalyzer;
using HCSAnalyzer.Forms;
using HCSAnalyzer.Classes;
using weka.core;
using System.Runtime.InteropServices;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using FreeImageAPI;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using HCSAnalyzer.Classes.General;
using System.Data;
using System.Net;
using System.Diagnostics;

namespace LibPlateAnalysis
{
    public class cWell : cGeneralComponent
    {
        private int PosX = -1;
        private int PosY = -1;
        public List<cDescriptor> ListDescriptors;
        public List<cDescriptor> ListPlateBasedDescriptors;

        private PlateChart AssociatedChart;
        public string StateForClassif = "Class2";

        private int CurrentDescriptorToDisplay;
        private int ClassForClassif = 2;
        public cScreening Parent;
        public cPlate AssociatedPlate;
        //private Color CurrentColor;
        // private string CurrentSelectedPathway = "";
        public double LocusID = -1;

        public string SQLTableName = "";

        public string Name = "";
        public string Info = "";
        public double Concentration = 0;

        FormForPathway ListP = new FormForPathway();

        static IList images = null;

        #region Constructors
        public cWell(cDescriptor Desc, int Col, int Row, cScreening screenParent, cPlate CurrentPlate)
        {
            this.Parent = screenParent;
            this.AssociatedPlate = CurrentPlate;
            this.ListDescriptors = new List<cDescriptor>();

            this.ListDescriptors.Add(Desc);

            this.PosX = Col;
            this.PosY = Row;

            //   this.CurrentColor = this.Parent.GlobalInfo.ListClasses[ClassForClassif].ColourForDisplay;

            Desc.AssociatedWell = this;

        }

        public cWell(List<cDescriptor> ListDesc, int Col, int Row, cScreening screenParent, cPlate CurrentPlate)
        {
            this.Parent = screenParent;
            this.AssociatedPlate = CurrentPlate;
            this.ListDescriptors = new List<cDescriptor>();

            this.ListDescriptors = ListDesc;

            this.PosX = Col;
            this.PosY = Row;

            //   this.CurrentColor = this.Parent.GlobalInfo.ListClasses[ClassForClassif].ColourForDisplay;

            foreach (var item in this.ListDescriptors)
            {
                item.AssociatedWell = this;
            }

        }

        public cWell(string FileName, cScreening screenParent, cPlate CurrentPlate)
        {
            this.Parent = screenParent;
            this.AssociatedPlate = CurrentPlate;

            StreamReader sr = new StreamReader(FileName);
            int Idx;
            string NewLine;
            string TmpLine;
            string line;

            // we have to build the descriptor list
            if (screenParent.ListDescriptors.Count == 0)
            {
                Idx = FileName.LastIndexOf("\\");
                NewLine = FileName.Remove(0, Idx + 1);
                TmpLine = NewLine;

                Idx = TmpLine.IndexOf("x");
                NewLine = TmpLine.Remove(Idx);

                if (!int.TryParse(NewLine, out this.PosX))
                {
                    MessageBox.Show("Error in load the current file.\n", "Loading error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return;
                }




                NewLine = TmpLine.Remove(0, Idx + 1);
                Idx = NewLine.IndexOf(".");
                TmpLine = NewLine.Remove(Idx);

                this.PosY = Convert.ToInt16(TmpLine);

                line = sr.ReadLine();
                while (line != null)
                {
                    if (line != null)
                    {
                        Idx = line.IndexOf("\t");
                        string DescName = line.Remove(Idx);

                        List<double> readData = new List<double>();

                        NewLine = line.Remove(0, Idx + 1);
                        line = NewLine;

                        Idx = line.IndexOf("\t");
                        int NumValue = 0;
                        while (Idx > 0)
                        {
                            string DescValue = line.Remove(Idx);
                            double CurrentValue = Convert.ToDouble(DescValue);

                            readData.Add(CurrentValue);
                            NewLine = line.Remove(0, Idx + 1);
                            line = NewLine;
                            Idx = line.IndexOf("\t");
                            NumValue++;
                        }
                        if (line.Length > 0)
                        {
                            double Value = Convert.ToDouble(line);
                            readData.Add(Value);
                        }
                        // first check if the descriptor exist
                        screenParent.ListDescriptors.AddNew(new cDescriptorsType(DescName, true, NumValue, screenParent.GlobalInfo));

                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }

            this.ListDescriptors = new List<cDescriptor>();
            sr = new StreamReader(FileName);

            Idx = FileName.LastIndexOf("\\");
            NewLine = FileName.Remove(0, Idx + 1);
            TmpLine = NewLine;

            Idx = TmpLine.IndexOf("x");
            NewLine = TmpLine.Remove(Idx);
            this.PosX = Convert.ToInt16(NewLine);

            NewLine = TmpLine.Remove(0, Idx + 1);
            Idx = NewLine.IndexOf(".");
            TmpLine = NewLine.Remove(Idx);

            this.PosY = Convert.ToInt16(TmpLine);

            line = sr.ReadLine();
            int IDxLine = 0;
            while (line != null)
            {
                if (line != null)
                {
                    Idx = line.IndexOf("\t");
                    string DescName = line.Remove(Idx);
                    cExtendedList readData = new cExtendedList();

                    NewLine = line.Remove(0, Idx + 1);
                    line = NewLine;

                    Idx = line.IndexOf("\t");

                    while (Idx > 0)
                    {
                        string DescValue = line.Remove(Idx);
                        double CurrentValue = Convert.ToDouble(DescValue);

                        readData.Add(CurrentValue);
                        NewLine = line.Remove(0, Idx + 1);
                        line = NewLine;
                        Idx = line.IndexOf("\t");
                    }
                    if (line.Length > 0)
                    {
                        double Value = Convert.ToDouble(line);
                        readData.Add(Value);
                    }
                    cDescriptor CurrentDesc = new cDescriptor(readData, screenParent.ListDescriptors[IDxLine].GetBinNumber() - 1, screenParent.ListDescriptors[IDxLine], this.Parent);
                    this.ListDescriptors.Add(CurrentDesc);
                }
                line = sr.ReadLine();
                IDxLine++;
            }
            sr.Close();
            //    this.CurrentColor = this.Parent.GlobalInfo.ListClasses[ClassForClassif].ColourForDisplay;
            return;
        }
        #endregion

        #region inter wells distance
        public double DistanceTo(cWell DestinationWell, int Idxdescriptor, eDistances DistanceType)
        {
            double Distance = 0;
            switch (DistanceType)
            {
                case eDistances.EUCLIDEAN:
                    Distance = this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_Euclidean(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues());
                    break;
                case eDistances.MANHATTAN:
                    Distance = this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_Manhattan(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues());
                    break;
                case eDistances.VECTOR_COS:
                    Distance = this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_VectorCosine(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues());
                    break;
                case eDistances.BHATTACHARYYA:
                    Distance = this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_BhattacharyyaCoefficient(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues());
                    break;
                case eDistances.EMD:
                    Distance = this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_EarthMover(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues());
                    break;
                default:
                    break;
            }
            return Distance;
        }

        public double DistanceTo(cWell DestinationWell, eDistances DistanceType)
        {
            double Distance = 0;

            switch (DistanceType)
            {
                case eDistances.EUCLIDEAN:
                    Distance += this.GetAverageValuesList(true).Dist_Euclidean(DestinationWell.GetAverageValuesList(true));
                    break;
                case eDistances.MANHATTAN:
                    Distance += this.GetAverageValuesList(true).Dist_Manhattan(DestinationWell.GetAverageValuesList(true));
                    break;
                case eDistances.VECTOR_COS:
                    Distance += this.GetAverageValuesList(true).Dist_VectorCosine(DestinationWell.GetAverageValuesList(true));
                    break;
                case eDistances.BHATTACHARYYA:
                    Distance += this.GetAverageValuesList(true).Dist_BhattacharyyaCoefficient(DestinationWell.GetAverageValuesList(true));
                    break;
                case eDistances.EMD:
                    Distance += this.GetAverageValuesList(true).Dist_EarthMover(DestinationWell.GetAverageValuesList(true));
                    break;
                default:
                    break;
            }

            return Distance;
        }

        public double DistanceTo(cWell DestinationWell, eDistances IntraHistoDistanceType, eDistances InterHistoDistanceType)
        {
            double Distance = 0;

            cExtendedList ListDistSource = new cExtendedList();
            cExtendedList ListDistDest = new cExtendedList();

            for (int Idxdescriptor = 0; Idxdescriptor < this.Parent.ListDescriptors.Count; Idxdescriptor++)
            {
                if (this.Parent.ListDescriptors[Idxdescriptor].IsActive() == false) continue;


                switch (IntraHistoDistanceType)
                {
                    case eDistances.EUCLIDEAN:
                        ListDistSource.Add(this.ListDescriptors[Idxdescriptor].GetHistovalues().Dist_Euclidean(DestinationWell.ListDescriptors[Idxdescriptor].GetHistovalues()));
                        ListDistDest.Add(DestinationWell.ListDescriptors[Idxdescriptor].GetValue());


                        Distance = ListDistSource.Dist_Euclidean(ListDistDest);
                        break;
                    case eDistances.MANHATTAN:
                        Distance = ListDistSource.Dist_Manhattan(ListDistDest);
                        break;
                    case eDistances.VECTOR_COS:
                        Distance = ListDistSource.Dist_VectorCosine(ListDistDest);
                        break;
                    case eDistances.BHATTACHARYYA:
                        Distance = ListDistSource.Dist_BhattacharyyaCoefficient(ListDistDest);
                        break;
                    case eDistances.EMD:
                        Distance = ListDistSource.Dist_EarthMover(ListDistDest);
                        break;
                    default:
                        break;
                }





            }



            switch (InterHistoDistanceType)
            {
                case eDistances.EUCLIDEAN:
                    Distance = ListDistSource.Dist_Euclidean(ListDistDest);
                    break;
                case eDistances.MANHATTAN:
                    Distance = ListDistSource.Dist_Manhattan(ListDistDest);
                    break;
                case eDistances.VECTOR_COS:
                    Distance = ListDistSource.Dist_VectorCosine(ListDistDest);
                    break;
                case eDistances.BHATTACHARYYA:
                    Distance = ListDistSource.Dist_BhattacharyyaCoefficient(ListDistDest);
                    break;
                case eDistances.EMD:
                    Distance = ListDistSource.Dist_EarthMover(ListDistDest);
                    break;
                default:
                    break;
            }

            return Distance;
        }
        #endregion

        /// <summary>
        /// Get the class index related to the well
        /// </summary>
        /// <returns>the class index</returns>
        public int GetClassIdx()
        {
            return ClassForClassif;
        }

        /// <summary>
        /// Return the color of the well (related to the class or the selection mode)
        /// </summary>
        /// <returns>The color</returns>
        public Color GetClassColor()
        {
            if (this.GetClassIdx() == -1) return Color.Transparent;

            return this.Parent.GlobalInfo.ListWellClasses[this.GetClassIdx()].ColourForDisplay;
        }

        public string GetShortInfo()
        {
            base.ShortInfo = "Well [" + this.PosX + "x" + this.PosY + "] - " + this.Name + "\t- ";
            base.ShortInfo += "Plate: " + Parent.Name + "\n";
            return base.GetShortInfo();
        }

        public string GetClassName()
        {
            if (this.GetClassIdx() == -1) return "Inactive";
            return this.Parent.GlobalInfo.ListWellClasses[this.GetClassIdx()].Name;
        }

        public cExtendedList GetAverageValuesList(bool IsOnlySelectedDescriptors)
        {
            cExtendedList ValuesToReturn = new cExtendedList();

            if (IsOnlySelectedDescriptors)
            {
                for (int i = 0; i < ListDescriptors.Count; i++)
                {
                    if (Parent.ListDescriptors[i].IsActive())
                        ValuesToReturn.Add(ListDescriptors[i].GetValue());
                }
            }
            else
            {
                for (int i = 0; i < ListDescriptors.Count; i++)
                    ValuesToReturn.Add(ListDescriptors[i].GetValue());

            }
            return ValuesToReturn;
        }

        public void SetClass(int Class)
        {
            ClassForClassif = Class;
            //if (Class == 0)
            //    StateForClassif = "0";
            //else if (Class == 1)
            //    StateForClassif = "1";
            //else
            //    StateForClassif = "Class" + Class;

            //CurrentColor = Parent.GlobalInfo.ListClasses[Class].ColourForDisplay;
            if (AssociatedChart == null) return;
            AssociatedChart.BackColor = Parent.GlobalInfo.ListWellClasses[Class].ColourForDisplay;//CurrentColor;
            AssociatedChart.Update();
        }

        public void SetAsNoneSelected()
        {
            ClassForClassif = -1;
            StateForClassif = "Unselected (-1)";
            //CurrentColor = Parent.GlobalInfo.panelForPlate.BackColor;
            if (AssociatedChart == null) return;
            AssociatedChart.BackColor = Parent.GlobalInfo.panelForPlate.BackColor;//CurrentColor;
            AssociatedChart.Update();
        }

        public int GetPosX()
        {
            return this.PosX;
        }

        public int GetPosY()
        {
            return this.PosY;
        }

        public PlateChart BuildChartForClass()
        {

            if (AssociatedChart != null) AssociatedChart.Dispose();
            AssociatedChart = new PlateChart();
            Series CurrentSeries = new Series("ChartSeries" + PosX + "x" + PosY);
            ChartArea CurrentChartArea = new ChartArea("ChartArea" + PosX + "x" + PosY);

            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].LabelStyle.Enabled = false;

            CurrentChartArea.Axes[1].LabelStyle.Enabled = false;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].Enabled = AxisEnabled.False;
            CurrentChartArea.Axes[1].Enabled = AxisEnabled.False;

            CurrentChartArea.BackColor = this.GetClassColor();// Parent.GlobalInfo.ListClasses[this.ClassForClassif].ColourForDisplay;// CurrentColor; //Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);
            AssociatedChart.ChartAreas.Add(CurrentChartArea);
            //AssociatedChart.Location = new System.Drawing.Point((PosX - 1) * (Parent.SizeHistoWidth + Parent.GutterSize), (PosY - 1) * (Parent.SizeHistoHeight + Parent.GutterSize));
            //AssociatedChart.Series.Add(CurrentSeries);

            int GutterSize = (int)Parent.GlobalInfo.OptionsWindow.numericUpDownGutter.Value;

            AssociatedChart.Location = new System.Drawing.Point((int)((PosX - 1) * (Parent.GlobalInfo.SizeHistoWidth + GutterSize) + Parent.GlobalInfo.ShiftX), (int)((PosY - 1) * (Parent.GlobalInfo.SizeHistoHeight + GutterSize) + Parent.GlobalInfo.ShiftY));
            AssociatedChart.Series.Add(CurrentSeries);

            AssociatedChart.BackColor = this.GetClassColor();//Parent.GlobalInfo.ListClasses[this.ClassForClassif].ColourForDisplay;// CurrentColor;
            AssociatedChart.Width = (int)Parent.GlobalInfo.SizeHistoWidth;
            AssociatedChart.Height = (int)Parent.GlobalInfo.SizeHistoHeight;

            if (Parent.GlobalInfo.OptionsWindow.checkBoxDisplayWellInformation.Checked)
            {
                Title MainLegend = new Title();

                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoName.Checked)
                    MainLegend.Text = Name;
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoInfo.Checked)
                    MainLegend.Text = Info;
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoDescValue.Checked)
                    MainLegend.Text = ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue().ToString("N3");
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoLocusID.Checked)
                    MainLegend.Text = ((int)(LocusID)).ToString();
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoConcentration.Checked)
                {
                    if (Concentration >= 0)
                        MainLegend.Text = Concentration.ToString("e4");
                }

                MainLegend.Docking = Docking.Bottom;
                MainLegend.Font = new System.Drawing.Font("Arial", Parent.GlobalInfo.SizeHistoWidth / 10 + 1, FontStyle.Regular);
                MainLegend.BackColor = MainLegend.BackImageTransparentColor;

                AssociatedChart.Titles.Add(MainLegend);
            }
            AssociatedChart.Update();
            AssociatedChart.Show();
            AssociatedChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssociatedChart_MouseClick);
            AssociatedChart.GetToolTipText += new System.EventHandler<ToolTipEventArgs>(this.AssociatedChart_GetToolTipText);
            return this.AssociatedChart;
        }

        public PlateChart BuildChart(int IdxDescriptor, double[] MinMax)
        {
            if (Parent.GlobalInfo.IsDisplayClassOnly) return BuildChartForClass();

            int borderSize = 8;
            int GutterSize = (int)Parent.GlobalInfo.OptionsWindow.numericUpDownGutter.Value;

            if (AssociatedChart != null) AssociatedChart.Dispose();
            if (IdxDescriptor >= ListDescriptors.Count) return null;
            CurrentDescriptorToDisplay = IdxDescriptor;
            AssociatedChart = new PlateChart();
            Series CurrentSeries = new Series("ChartSeries" + PosX + "x" + PosY);
            ChartArea CurrentChartArea = new ChartArea("ChartArea" + PosX + "x" + PosY);

            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].LabelStyle.Enabled = false;

            #region Pie
            if (Parent.GlobalInfo.ViewMode == eViewMode.PIE)
            {
                CurrentSeries.ChartType = SeriesChartType.Pie;
                //AssociatedChart.Palette = ChartColorPalette.Grayscale;
                //ChartColorPalette a = new ChartColorPalette();

                int RealIdx = 0;

                for (int IdxValue = 0; IdxValue < ListDescriptors.Count; IdxValue++)
                {
                    if (ListDescriptors[IdxValue].GetAssociatedType().IsActive())
                    {

                        CurrentSeries.Points.Add(ListDescriptors[IdxValue].GetValue());
                        //CurrentSeries.Points[Idx].Label = String.Format("{0:0.###}", ((100.0 * ListPathway[Idx].Occurence) / TotalOcurrence)) + " %";

                        CurrentSeries.Points[CurrentSeries.Points.Count - 1].Color = Parent.GlobalInfo.ListCellularPhenotypes[RealIdx++ % Parent.GlobalInfo.ListCellularPhenotypes.Count].ColourForDisplay;


                        //CurrentSeries.Points[Idx].LegendText = ListPathway[Idx].Name;
                        //CurrentSeries.Points[CurrentSeries.Points.Count - 1] = 2;
                        //CurrentSeries.Points[CurrentSeries.Points.Count - 1].Label = ListDescriptors[IdxValue].GetAssociatedType().GetName() + " : ";
                    }
                }
                //CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
                //CurrentChartArea.Axes[1].MajorGrid.LineColor = Color.FromArgb(127, 127, 127);
                //CurrentChartArea.Axes[1].LineColor = Color.FromArgb(127, 127, 127);
                //CurrentChartArea.Axes[1].MajorTickMark.LineColor = Color.FromArgb(127, 127, 127);
                //CurrentChartArea.Axes[1].LabelStyle.Enabled = false;
                //CurrentChartArea.Axes[0].LineColor = Color.FromArgb(127, 127, 127);
                //CurrentChartArea.Axes[0].MajorTickMark.LineColor = Color.FromArgb(127, 127, 127);
                //CurrentSeries.Color = Color.White;
                //CurrentSeries.BorderWidth = 1;
                //CurrentChartArea.BackColor = Color.FromArgb(16, 37, 63);

                //CurrentChartArea.BorderWidth = borderSize;
                AssociatedChart.ChartAreas.Add(CurrentChartArea);
            }
            #endregion

            #region Average
            else if ((ListDescriptors[IdxDescriptor].GetAssociatedType().GetBinNumber() == 1) || (Parent.GlobalInfo.ViewMode == eViewMode.AVERAGE))
            {
                CurrentChartArea.Axes[1].LabelStyle.Enabled = false;
                CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
                CurrentChartArea.Axes[0].Enabled = AxisEnabled.False;
                CurrentChartArea.Axes[1].Enabled = AxisEnabled.False;

                int ConvertedValue;

                byte[][] LUT = Parent.GlobalInfo.LUT;

                if (MinMax[0] == MinMax[1])
                    ConvertedValue = 0;
                else
                    ConvertedValue = (int)(((ListDescriptors[IdxDescriptor].GetValue() - MinMax[0]) * (LUT[0].Length - 1)) / (MinMax[1] - MinMax[0]));
                if ((ConvertedValue >= 0) && (ConvertedValue < LUT[0].Length))
                    CurrentChartArea.BackColor = Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);
                AssociatedChart.ChartAreas.Add(CurrentChartArea);
            }
            #endregion

            #region Histogram
            else
            {
                CurrentSeries.ChartType = SeriesChartType.Column;

                int HistoSize = ListDescriptors[IdxDescriptor].GetHistovalues().Count;
                for (int IdxValue = 0; IdxValue < /* ListDescriptors[IdxDescriptor].GetAssociatedType().GetBinNumber()*/ HistoSize; IdxValue++)
                {
                    if ((Parent.GlobalInfo.OptionsWindow.radioButtonHistoDisplayAutomatedMinMax.Checked) || (Parent.GlobalInfo.OptionsWindow.radioButtonHistoDisplayManualMinMax.Checked))
                        CurrentSeries.Points.AddXY(ListDescriptors[IdxDescriptor].GetHistoXvalue(IdxValue), ListDescriptors[IdxDescriptor].GetHistovalue(IdxValue));
                    else
                        CurrentSeries.Points.Add(ListDescriptors[IdxDescriptor].GetHistovalue(IdxValue));
                }

                CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
                CurrentChartArea.Axes[1].MajorGrid.LineColor = Color.FromArgb(127, 127, 127);
                CurrentChartArea.Axes[1].LineColor = Color.FromArgb(127, 127, 127);
                CurrentChartArea.Axes[1].MajorTickMark.LineColor = Color.FromArgb(127, 127, 127);
                CurrentChartArea.Axes[1].LabelStyle.Enabled = false;
                CurrentChartArea.Axes[0].LineColor = Color.FromArgb(127, 127, 127);
                CurrentChartArea.Axes[0].MajorTickMark.LineColor = Color.FromArgb(127, 127, 127);
                if (Parent.GlobalInfo.OptionsWindow.radioButtonHistoDisplayAutomatedMinMax.Checked)
                {
                    CurrentChartArea.Axes[0].Minimum = Parent.GetCurrentDisplayPlate().MinMaxHisto[0];
                    CurrentChartArea.Axes[0].Maximum = Parent.GetCurrentDisplayPlate().MinMaxHisto[1];
                }
                else if (Parent.GlobalInfo.OptionsWindow.radioButtonHistoDisplayManualMinMax.Checked)
                {
                    CurrentChartArea.Axes[0].Minimum = (double)Parent.GlobalInfo.OptionsWindow.numericUpDownManualMin.Value;
                    CurrentChartArea.Axes[0].Maximum = (double)Parent.GlobalInfo.OptionsWindow.numericUpDownManualMax.Value;
                }
                CurrentSeries.Color = Color.White;
                CurrentSeries.BorderWidth = 1;

                int ConvertedValue;
                if (MinMax[0] == MinMax[1])
                    ConvertedValue = 0;
                else
                    ConvertedValue = (int)(((ListDescriptors[IdxDescriptor].GetValue() - MinMax[0]) * (Parent.GlobalInfo.LUT[0].Length - 1)) / (MinMax[1] - MinMax[0]));
                if ((ConvertedValue >= 0) && (ConvertedValue < Parent.GlobalInfo.LUT[0].Length))
                    //CurrentChartArea.BackColor = Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);

                    if (Parent.GlobalInfo.OptionsWindow.radioButtonBackColorDefault.Checked)
                        CurrentChartArea.BackColor = Color.FromArgb(16, 37, 63);
                    else
                        CurrentChartArea.BackColor = Color.FromArgb(Parent.GlobalInfo.LUT[0][ConvertedValue],
                                            Parent.GlobalInfo.LUT[1][ConvertedValue],
                                            Parent.GlobalInfo.LUT[2][ConvertedValue]);

                CurrentChartArea.BorderWidth = borderSize;
                AssociatedChart.ChartAreas.Add(CurrentChartArea);
            }
            #endregion

            AssociatedChart.Location = new System.Drawing.Point((int)((PosX - 1) * (Parent.GlobalInfo.SizeHistoWidth + GutterSize) + Parent.GlobalInfo.ShiftX), (int)((PosY - 1) * (Parent.GlobalInfo.SizeHistoHeight + GutterSize) + Parent.GlobalInfo.ShiftY));
            AssociatedChart.Series.Add(CurrentSeries);

            AssociatedChart.BackColor = this.GetClassColor();
            AssociatedChart.Width = (int)Parent.GlobalInfo.SizeHistoWidth;
            AssociatedChart.Height = (int)Parent.GlobalInfo.SizeHistoHeight;

            if ((Parent.GlobalInfo.OptionsWindow.checkBoxDisplayWellInformation.Checked) && (Parent.GlobalInfo.ViewMode != eViewMode.PIE))
            {
                Title MainLegend = new Title();

                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoName.Checked)
                    MainLegend.Text = Name;
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoInfo.Checked)
                    MainLegend.Text = Info;
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoDescValue.Checked)
                    MainLegend.Text = ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue().ToString("N3");
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoLocusID.Checked)
                    MainLegend.Text = ((int)(LocusID)).ToString();
                if (Parent.GlobalInfo.OptionsWindow.radioButtonWellInfoConcentration.Checked)
                    if (Concentration >= 0) MainLegend.Text = Concentration.ToString("e4");

                MainLegend.Docking = Docking.Bottom;
                MainLegend.Font = new System.Drawing.Font("Arial", Parent.GlobalInfo.SizeHistoWidth / 10 + 1, FontStyle.Regular);
                MainLegend.BackColor = MainLegend.BackImageTransparentColor;

                AssociatedChart.Titles.Add(MainLegend);
            }
            AssociatedChart.Update();
            AssociatedChart.Show();
            AssociatedChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssociatedChart_MouseClick);
            AssociatedChart.GetToolTipText += new System.EventHandler<ToolTipEventArgs>(this.AssociatedChart_GetToolTipText);
            return this.AssociatedChart;
        }

        private void AssociatedChart_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            byte[] strArray = new byte[1];
            strArray[0] = (byte)(this.PosY + 64);

            string Chara = Encoding.UTF7.GetString(strArray);
            Chara += this.PosX + ": " + Name + "\n";
            for (int i = 0; i < ListDescriptors.Count; i++)  // to be checked
            {
                if (Parent.ListDescriptors[i].IsActive() == false) continue;
                if (i == Parent.ListDescriptors.CurrentSelectedDescriptorIdx)
                    Chara += "\t-> " + Parent.ListDescriptors[i].GetName() + ": " + string.Format("{0:0.######}", ListDescriptors[i].GetValue()) + "\n";
                else
                    Chara += Parent.ListDescriptors[i].GetName() + ": " + string.Format("{0:0.######}", ListDescriptors[i].GetValue()) + "\n";
            }
            Chara += this.GetClassName();
            e.Text = Chara;
        }

        private void AssociatedChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1) return;

            if (e.Button == MouseButtons.Left)
            {
                int ClassSelected = Parent.GetSelectionType();
                if (ClassSelected == -2) return;

                if (!Parent.IsSelectionApplyToAllPlates)
                {
                    if (ClassSelected == -1)
                    {
                        SetAsNoneSelected();
                        return;
                    }
                    else
                        SetClass(ClassSelected);

                    int[] a = Parent.GetCurrentDisplayPlate().UpdateNumberOfClass();
                }
                else
                {
                    cWell TempWell;
                    int NumberOfPlates = Parent.ListPlatesActive.Count;

                    for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                    {
                        cPlate CurrentPlateToProcess = Parent.ListPlatesActive.GetPlate(PlateIdx);
                        TempWell = CurrentPlateToProcess.GetWell(this.PosX - 1, this.PosY - 1, false);
                        if (TempWell == null) continue;
                        if (ClassSelected == -1)
                            TempWell.SetAsNoneSelected();
                        else
                            TempWell.SetClass(ClassSelected);

                        CurrentPlateToProcess.UpdateNumberOfClass();
                    }
                }

                if (ClassSelected == -1)
                {
                    Parent.GetCurrentDisplayPlate().UpDataMinMax();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip NewMenu = new ContextMenuStrip();

                foreach (var item in this.GetExtendedContextMenu())
                    NewMenu.Items.Add(item);

                NewMenu.Show(Control.MousePosition);
            }

        }

        public void BuildAndisplaySimpleContextMenu(ToolStripItem[] ToBeAdded)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Info");
            ToolStripMenuItem ToolStripMenuItem_Histo = new ToolStripMenuItem("Histogram");
            ToolStripMenuItem ToolStripMenuItem_DisplayData = new ToolStripMenuItem("Display Data");
            ToolStripSeparator ToolStripSep = new ToolStripSeparator();


            if (this.SQLTableName != "")
                contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_Info, ToolStripMenuItem_DisplayData, ToolStripMenuItem_Histo, ToolStripSep });
            else
                contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_Info, ToolStripMenuItem_Histo, ToolStripSep });

            if (ToBeAdded != null)
                contextMenuStrip.Items.AddRange(ToBeAdded);
            //ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            contextMenuStrip.Show(Control.MousePosition);

            ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);
            ToolStripMenuItem_Histo.Click += new System.EventHandler(this.DisplayHisto);
            ToolStripMenuItem_DisplayData.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayData);
        }

        public List<ToolStripMenuItem> GetExtendedContextMenu()
        {
            List<ToolStripMenuItem> ListToReturn = new List<ToolStripMenuItem>();

            ListToReturn.Add(AssociatedPlate.GetExtendedContextMenu());

            #region Context Menu
            base.SpecificContextMenu = new ToolStripMenuItem("Well [" + this.PosX + "x" + this.PosY + "]");
            // ToolStripSeparator Sep = new ToolStripSeparator();
            // base.SpecificContextMenu.Items.Add(Sep);


            //ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Test Automated Menu");

            //base.SpecificContextMenu.Items.Add(ToolStripMenuItem_Info);

            ////   contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_Info, ToolStripMenuItem_Histo, ToolStripSep, ToolStripMenuItem_Kegg, ToolStripSep1, ToolStripMenuItem_Copy });

            ////ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            //// contextMenuStrip.Show(Control.MousePosition);
            //ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);


            ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Info");
            ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Info);

            ToolStripMenuItem ToolStripMenuItem_Histo = new ToolStripMenuItem("Histograms");
            ToolStripMenuItem_Histo.Click += new System.EventHandler(this.DisplayHisto);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Histo);

            if (this.LocusID != -1.0)
            {
                ToolStripMenuItem ToolStripMenuItem_Kegg = new ToolStripMenuItem("Kegg");
                ToolStripMenuItem_Kegg.Click += new System.EventHandler(this.DisplayPathways);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Kegg);
            }

            if (this.SQLTableName != "")
            {
                ToolStripSeparator ToolStripSep = new ToolStripSeparator();
                SpecificContextMenu.DropDownItems.Add(ToolStripSep);

                ToolStripMenuItem ToolStripMenuItem_DisplayData = new ToolStripMenuItem("Display Single Object Data");
                ToolStripMenuItem_DisplayData.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayData);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayData);

                ToolStripMenuItem ToolStripMenuItem_AddToSingleCellAnalysis = new ToolStripMenuItem("Add to Single Object Analysis");
                ToolStripMenuItem_AddToSingleCellAnalysis.Click += new System.EventHandler(this.ToolStripMenuItem_AddToSingleCellAnalysis);
                SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_AddToSingleCellAnalysis);
            }

            if (this.GetClassIdx() >= 0)
                base.SpecificContextMenu.DropDownItems.Add(Parent.GlobalInfo.ListWellClasses[this.GetClassIdx()].GetExtendedContextMenu());

            //ToolStripSeparator ToolStripSep1 = new ToolStripSeparator();
            //ToolStripMenuItem ToolStripMenuItem_Copy = new ToolStripMenuItem("Copy Visu.");

            //ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            //base.SpecificContextMenu.Show(Control.MousePosition);
            //ToolStripMenuItem_Copy.Click += new System.EventHandler(this.CopyVisu);
            #endregion

            ListToReturn.Add(base.SpecificContextMenu);

            return ListToReturn;
        }
        //ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        private void ToolStripMenuItem_AddToSingleCellAnalysis(object sender, EventArgs e)
        {
            AddToSingleCellAnalysis();
        }

        public void AddToSingleCellAnalysis()
        {
            Parent.GlobalInfo.WindowHCSAnalyzer.listBoxSelectedWells.Items.Add(Parent.GetCurrentDisplayPlate().Name + " : " + this.GetPosX() + "x" + this.GetPosY());
            Parent.GlobalInfo.ListSelectedWell.Add(this);
        }

        private void ToolStripMenuItem_DisplayData(object sender, EventArgs e)
        {
            this.AssociatedPlate.DBConnection = new cDBConnection(this.AssociatedPlate, this.SQLTableName);
            // this.AssociatedPlate.DBConnection.DB_EstablishConnection();

            //            DataTable DT = new DataTable();

            //          this.AssociatedPlate.DBConnection.AddWellToDataTable(this, DT, false, Parent.GlobalInfo);

            cListSingleBiologicalObjects ListPhenotypes =
                this.AssociatedPlate.DBConnection.GetWellBiologicalPhenotypes(this);

            cExtendedTable ET = this.AssociatedPlate.DBConnection.GetWellValues(this, Parent.ListDescriptors.GetActiveDescriptors());

            //cExtendedTable ET = new cExtendedTable(ListPhenotypes);

            for (int i = 0; i < ET.Count; i++)
            {
                ET[i].ListTags = new List<object>();

                for (int j = 0; j < ListPhenotypes.Count; j++)
                    ET[i].ListTags.Add(ListPhenotypes[j]);
            }

            ET.Name = this.Name;
            cViewer2DScatterPoint VS = new cViewer2DScatterPoint();
            VS.SetInputData(ET);
            VS.Chart.IsSelectable = true;
            //VS.Chart.IsSelectable = true;
            VS.Run();

            cDisplayToWindow DTW = new cDisplayToWindow();
            DTW.SetInputData(VS.GetOutPut());
            DTW.Title = "Well [" + this.PosX + "x" + this.PosY + "] - " + this.Name;
            DTW.Run();
            DTW.Display();


            //  this.AssociatedPlate.DBConnection.DisplayTable(this);
            this.AssociatedPlate.DBConnection.DB_CloseConnection();
            //this.SQLTableName

        }

        private void DisplayHisto(object sender, EventArgs e)
        {
            if ((Parent.ListDescriptors == null) || (Parent.ListDescriptors.Count == 0)) return;

            cDisplayToWindow CDW1 = new cDisplayToWindow();

            cListWell ListWellsToProcess = new cListWell(null);
            List<cPlate> PlateList = new List<cPlate>();
            cDesignerSplitter DS = new cDesignerSplitter();

            foreach (cPlate TmpPlate in Parent.ListPlatesActive) PlateList.Add(TmpPlate);

            foreach (cPlate TmpPlate in PlateList)
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

            cExtendedTable NewTable2 = ListWellsToProcess.GetDescriptorValues(Parent.ListDescriptors.CurrentSelectedDescriptorIdx, true);
            NewTable2.Name = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Stacked Histogram - " + PlateList.Count + " plates";

            cViewerStackedHistogram CV2 = new cViewerStackedHistogram();
            CV2.SetInputData(NewTable2);
            CV2.Chart.LabelAxisX = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            CV2.Chart.IsBorder = false;
            CV2.Chart.Width = 0;
            CV2.Chart.Height = 0;

            StripLine AverageLine = new StripLine();
            AverageLine.BackColor = Color.Red;
            AverageLine.IntervalOffset = this.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
            AverageLine.StripWidth = 0.0001;
            AverageLine.Text = this.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue().ToString("N2");

            CV2.Run();

            CV2.Chart.ChartAreas[0].AxisX.StripLines.Add(AverageLine);

            DS.SetInputData(CV2.GetOutPut());


            PlateList.Clear();
            PlateList.Add(Parent.GetCurrentDisplayPlate());
            ListWellsToProcess.Clear();
            foreach (cPlate TmpPlate in PlateList)
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

            CDW1.Title = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Stacked Histogram (" + PlateList[0].Name + ")";

            cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(Parent.ListDescriptors.CurrentSelectedDescriptorIdx, true);
            NewTable.Name = CDW1.Title;

            cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
            CV1.SetInputData(NewTable);
            CV1.Chart.LabelAxisX = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            CV1.Chart.Width = 0;
            CV1.Chart.Height = 0;



            //  CV1.Chart.ChartAreas[0].AxisX.Minimum = CV2.Chart.ChartAreas[0].AxisX.Minimum;
            //  CV1.Chart.ChartAreas[0].AxisX.Maximum = CV2.Chart.ChartAreas[0].AxisX.Maximum;
            CV1.Run();

            CV1.Chart.ChartAreas[0].AxisX.StripLines.Add(AverageLine);

            DS.SetInputData(CV1.GetOutPut());

            DS.Run();

            CDW1.SetInputData(DS.GetOutPut());

            CDW1.Run();
            CDW1.Display();

            return;



            //cExtendedList Pos = new cExtendedList();
            //cWell TempWell;

            //int NumberOfPlates = Parent.GlobalInfo.PlateListWindow.listBoxPlateNameToProcess.Items.Count;

            //// loop on all the plate
            //for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            //{
            //    cPlate CurrentPlateToProcess = Parent.ListPlatesActive.GetPlate((string)Parent.GlobalInfo.PlateListWindow.listBoxPlateNameToProcess.Items[PlateIdx]);

            //    for (int row = 0; row < Parent.Rows; row++)
            //        for (int col = 0; col < Parent.Columns; col++)
            //        {
            //            TempWell = CurrentPlateToProcess.GetWell(col, row, false);
            //            if (TempWell == null) continue;
            //            else
            //            {
            //                if (TempWell.GetClassIdx() == this.ClassForClassif)
            //                    Pos.Add(TempWell.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue());
            //            }
            //        }
            //}

            //if (Pos.Count == 0)
            //{
            //    MessageBox.Show("No well of class " + Parent.SelectedClass + " selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //List<double[]> HistoPos = Pos.CreateHistogram((int)Parent.GlobalInfo.OptionsWindow.numericUpDownHistoBin.Value);
            //if (HistoPos == null) return;
            //cWindowToDisplayHisto NewWindow = new cWindowToDisplayHisto(this.Parent, Pos);

            //Series SeriesPos = new Series();
            //SeriesPos.ShadowOffset = 1;

            //if (HistoPos.Count == 0) return;

            //for (int IdxValue = 0; IdxValue < HistoPos[0].Length; IdxValue++)
            //{
            //    SeriesPos.Points.AddXY(HistoPos[0][IdxValue], HistoPos[1][IdxValue]);
            //    SeriesPos.Points[IdxValue].ToolTip = HistoPos[1][IdxValue].ToString();

            //    if (this.ClassForClassif == -1)
            //        SeriesPos.Points[IdxValue].Color = Color.Black;
            //    else
            //        SeriesPos.Points[IdxValue].Color = Parent.GlobalInfo.ListWellClasses[this.ClassForClassif].ColourForDisplay;
            //}

            //ChartArea CurrentChartArea = new ChartArea();
            //CurrentChartArea.BorderColor = Color.Black;

            //NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
            //CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            //CurrentChartArea.Axes[0].Title = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetName();
            //CurrentChartArea.Axes[1].Title = "Sum";
            //CurrentChartArea.AxisX.LabelStyle.Format = "N2";

            //NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            //CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            //CurrentChartArea.BackColor = Parent.GlobalInfo.OptionsWindow.panel1.BackColor;
            //CurrentChartArea.BackSecondaryColor = Color.White;

            //SeriesPos.ChartType = SeriesChartType.Column;
            //// SeriesPos.Color = Parent.GetColor(1);
            //NewWindow.chartForSimpleForm.Series.Add(SeriesPos);

            //NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserEnabled = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            //StripLine AverageLine = new StripLine();
            //AverageLine.BackColor = Color.Red;
            //AverageLine.IntervalOffset = this.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue();
            //AverageLine.StripWidth = 0.0001;
            //AverageLine.Text = String.Format("{0:0.###}", this.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue());
            //CurrentChartArea.AxisX.StripLines.Add(AverageLine);

            //if (Parent.GlobalInfo.OptionsWindow.checkBoxDisplayHistoStats.Checked)
            //{
            //    StripLine NAverageLine = new StripLine();
            //    NAverageLine.BackColor = Color.Black;
            //    NAverageLine.IntervalOffset = Pos.Mean();
            //    NAverageLine.StripWidth = 0.0001;// double.Epsilon;
            //    CurrentChartArea.AxisX.StripLines.Add(NAverageLine);
            //    NAverageLine.Text = String.Format("{0:0.###}", NAverageLine.IntervalOffset);

            //    StripLine StdLine = new StripLine();
            //    StdLine.BackColor = Color.FromArgb(64, Color.Black);
            //    double Std = Pos.Std();
            //    StdLine.IntervalOffset = NAverageLine.IntervalOffset - 0.5 * Std;
            //    StdLine.StripWidth = Std;
            //    CurrentChartArea.AxisX.StripLines.Add(StdLine);
            //    //NAverageLine.StripWidth = 0.01;
            //}

            //Title CurrentTitle = new Title(this.StateForClassif + " - " + Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetName() + " histogram.");
            //CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            //NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);

            //NewWindow.Text = CurrentTitle.Text;
            //NewWindow.Show();
            //NewWindow.chartForSimpleForm.Update();
            //NewWindow.chartForSimpleForm.Show();
            //NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });

            //return;
        }

        //void DisplayPathways(object sender, EventArgs e)
        //{
        //    if (LocusID == -1) return;
        //    FormForKeggGene KeggWin = new FormForKeggGene();
        //    KEGG ServKegg = new KEGG();
        //    string[] intersection_gene_pathways = new string[1];

        //    intersection_gene_pathways[0] = "hsa:" + LocusID;
        //    string[] Pathways = ServKegg.get_pathways_by_genes(intersection_gene_pathways);
        //    if ((Pathways == null) || (Pathways.Length == 0))
        //    {
        //        MessageBox.Show("No pathway founded !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    string GenInfo = ServKegg.bget(intersection_gene_pathways[0]);



        //    // FormForPathway PathwaysGenes = new FormForPathway();

        //    KeggWin.richTextBox.Text = GenInfo;
        //    KeggWin.Text = "Gene Infos";
        //    //PathwaysGenes.Show();
        //    ListP = new FormForPathway();

        //    ListP.listBoxPathways.DataSource = Pathways;

        //    ListP.Text = this.Name;
        //    ListP.Show();
        //    //foreach (string item in Pathways)
        //    //{
        //    //     string PathwayInfo = ServKegg.bget(item);
        //    //     FormPathwaysGenes PathwaysGenes = new FormPathwaysGenes();

        //    //     PathwaysGenes.richTextBox1.Text = PathwayInfo;
        //    //     PathwaysGenes.Text = "Pathways Infos";
        //    //     PathwaysGenes.Show();

        //    //}



        //    string[] fg_list = { "black" };
        //    string[] bg_list = { "orange" };
        //    // string[] intersection_gene_pathways = new string[1];

        //    // intersection_gene_pathways[0] = "hsa:" + LocusID;


        //    string pathway_map_html = "";
        //    //  KEGG ServKegg = new KEGG();

        //    pathway_map_html = ServKegg.get_html_of_colored_pathway_by_objects((string)(ListP.listBoxPathways.SelectedItem), intersection_gene_pathways, fg_list, bg_list);

        //    // FormForKegg KeggWin = new FormForKegg();
        //    if (pathway_map_html.Length == 0) return;

        //    //
        //    //KeggWin.Show();
        //    ListP.listBoxPathways.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
        //    KeggWin.webBrowser.Navigate(pathway_map_html);

        //    KeggWin.Show();

        //}

        void DisplayPathways(object sender, EventArgs e)
        {
            if (LocusID == -1 || LocusID == 0)
            {
                MessageBox.Show("No pathway founded !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<string> Pathways2 = HCSAnalyzer.HCSAnalyzer.Find_Pathways(LocusID); //appel de la function static je ne sais pas pourquoi elle doit etre static…

            if (Pathways2.Count > 0 || Pathways2.Count == 0)
            {
                string getvars2 = "/get/hsa:" + LocusID;
                string getvar = "/link/genes/" + "hsa05010";
                HttpWebRequest req2 = WebRequest.Create(string.Format("http://rest.kegg.jp" + getvar)) as HttpWebRequest;
                req2.Method = "GET";

                HttpWebResponse response = req2.GetResponse() as HttpWebResponse;
                StreamReader reader2 = new StreamReader(response.GetResponseStream());


                string GenInfo = reader2.ReadToEnd();

                reader2.Close();



                string[] genesarraytmp = GenInfo.Split('\n');
                List<string> genesarray = new List<string>();
                foreach (string item in genesarraytmp)
                {
                    if (item.Contains('\t'))
                    {
                        genesarray.Add(item.Split('\t')[1]);
                    }

                }
                int yup = 0;

                string[] ListGenesinPathway = genesarray.ToArray();
                double[] ListValues = new double[ListGenesinPathway.Length];
                int IDxGeneOfInterest = 0;
                //StreamWriter stw = new StreamWriter(@"C:\alzheimer.csv");
                //stw.WriteLine("Genes" + "," + "Value");
                foreach (cPlate CurrentPlate in Parent.ListPlatesActive)
                {
                    foreach (cWell CurrentWell in CurrentPlate.ListActiveWells)
                    {
                        string CurrentLID = "hsa:" + (int)CurrentWell.LocusID;

                        for (int IdxGene = 0; IdxGene < ListGenesinPathway.Length; IdxGene++)
                        {

                            //if (CurrentLID == ListGenesinPathway[IdxGene])
                            //    IDxGeneOfInterest = IdxGene;

                            if (CurrentLID == ListGenesinPathway[IdxGene])
                            {
                                ListValues[IdxGene] = CurrentWell.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
                                //stw.Write(CurrentWell.Name); stw.Write(","); stw.Write(ListValues[IdxGene]); stw.WriteLine();
                                break;
                            }
                        }
                    }
                }
                //stw.Close();
                string webpage = "http://www.kegg.jp/kegg-bin/show_pathway?hsa05010+";

                double MinValue = ListValues.Min();
                double MaxValue = ListValues.Max();
                string[] bg_list = new string[ListGenesinPathway.Length];
              string[]  fg_list = new string[ListGenesinPathway.Length];
                for (int IdxCol = 0; IdxCol < bg_list.Length; IdxCol++)
                {

                    int ConvertedValue = (int)((((Parent.GlobalInfo.LUTs.LUT_JET[0].Length - 1) * (ListValues[IdxCol] - MinValue)) / (MaxValue - MinValue)));

                    Color Coul = Color.FromArgb(Parent.GlobalInfo.LUTs.LUT_JET[0][ConvertedValue], Parent.GlobalInfo.LUTs.LUT_JET[1][ConvertedValue], 
                        Parent.GlobalInfo.LUTs.LUT_JET[2][ConvertedValue]);

                   
                        fg_list[IdxCol] = "000000";
                    bg_list[IdxCol] = Coul.Name.Remove(0, 2);

                }
                int ad=0;
                foreach (string item in genesarray)
                {
                    webpage += item+"%09%23"+bg_list[ad]+"+";
                    ad++;
                }
                
                Process.Start("chrome.exe",webpage);

                //FormForKeggGene KeggWin = new FormForKeggGene();
                
                //KeggWin.webBrowser.Navigate(webpage);
                ////KeggWin.richTextBox.Text = GenInfo;
                ////KeggWin.Text = "Gene Infos";
                //KeggWin.Show();
                response.Close();
            }
            else
            {
                MessageBox.Show("No pathway founded !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


      






        //void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    string[] fg_list = { "black" };
        //    string[] bg_list = { "orange" };
        //    string[] intersection_gene_pathways = new string[1];

        //    intersection_gene_pathways[0] = "hsa:" + LocusID;

        //    string pathway_map_html = "";
        //    KEGG ServKegg = new KEGG();

        //    string[] ListGenesinPathway = ServKegg.get_genes_by_pathway((string)ListP.listBoxPathways.SelectedItem);
        //    double[] ListValues = new double[ListGenesinPathway.Length];
        //    int IDxGeneOfInterest = 0;
        //    foreach (cPlate CurrentPlate in Parent.ListPlatesActive)
        //    {
        //        foreach (cWell CurrentWell in CurrentPlate.ListActiveWells)
        //        {
        //            string CurrentLID = "hsa:" + (int)CurrentWell.LocusID;

        //            for (int IdxGene = 0; IdxGene < ListGenesinPathway.Length; IdxGene++)
        //            {

        //                if (CurrentLID == intersection_gene_pathways[0])
        //                    IDxGeneOfInterest = IdxGene;

        //                if (CurrentLID == ListGenesinPathway[IdxGene])
        //                {
        //                    ListValues[IdxGene] = CurrentWell.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    bg_list = new string[ListGenesinPathway.Length];
        //    fg_list = new string[ListGenesinPathway.Length];

        //    double MinValue = ListValues.Min();
        //    double MaxValue = ListValues.Max();

        //    for (int IdxCol = 0; IdxCol < bg_list.Length; IdxCol++)
        //    {

        //        int ConvertedValue = (int)((((Parent.GlobalInfo.LUTs.LUT_JET[0].Length - 1) * (ListValues[IdxCol] - MinValue)) / (MaxValue - MinValue)));

        //        Color Coul = Color.FromArgb(Parent.GlobalInfo.LUTs.LUT_JET[0][ConvertedValue], Parent.GlobalInfo.LUTs.LUT_JET[1][ConvertedValue], Parent.GlobalInfo.LUTs.LUT_JET[2][ConvertedValue]);

        //        if (IdxCol == IDxGeneOfInterest)
        //            fg_list[IdxCol] = "white";
        //        else
        //            fg_list[IdxCol] = "#000000";
        //        bg_list[IdxCol] = "#" + Coul.Name.Remove(0, 2);

        //    }

        //    pathway_map_html = ServKegg.get_html_of_colored_pathway_by_objects((string)ListP.listBoxPathways.SelectedItem, ListGenesinPathway, fg_list, bg_list);

        //    string GenInfo = ServKegg.bget((string)ListP.listBoxPathways.SelectedItem);
        //    string[] Genes = GenInfo.Split(new char[] { '\n' });
        //    string Res = "";
        //    foreach (string item in Genes)
        //    {
        //        string[] fre = item.Split(' ');
        //        string[] STRsection = fre[0].Split('_');

        //        if (STRsection[0] != "NAME") continue;

        //        for (int i = 1; i < fre.Length; i++)
        //        {
        //            if (fre[i] == "") continue;
        //            Res += fre[i] + " ";
        //        }
        //    }

        //    FormForKegg KeggWin = new FormForKegg();

        //    if (pathway_map_html.Length == 0) return;

        //    KeggWin.Text = Res;
        //    KeggWin.Show();

        //    KeggWin.webBrowser.Navigate(pathway_map_html);
        //}

        public Chart GetChart()
        {
            if (ListDescriptors[CurrentDescriptorToDisplay].GetAssociatedType().GetBinNumber() == 1) return null;

            Series CurrentSeries = new Series("ChartSeries" + PosX + "x" + PosY);
            //CurrentSeries.ShadowOffset = 2;

            for (int IdxValue = 0; IdxValue < ListDescriptors[CurrentDescriptorToDisplay].GetAssociatedType().GetBinNumber(); IdxValue++)
                CurrentSeries.Points.Add(ListDescriptors[CurrentDescriptorToDisplay].GetHistovalue(IdxValue));

            ChartArea CurrentChartArea = new ChartArea("ChartArea" + PosX + "x" + PosY);
            CurrentChartArea.BorderColor = Color.White;

            Chart ChartToReturn = new Chart();
            ChartToReturn.ChartAreas.Add(CurrentChartArea);
            // ChartToReturn.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackColor = Color.White;

            CurrentChartArea.Axes[1].LabelStyle.Enabled = false;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].Enabled = AxisEnabled.False;
            CurrentChartArea.Axes[1].Enabled = AxisEnabled.False;


            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            //  CurrentChartArea.Axes[0].Title = ListDescriptors[CurrentDescriptorToDisplay].GetName();
            CurrentSeries.ChartType = SeriesChartType.Line;
            CurrentSeries.Color = Color.Black;
            // CurrentSeries.BorderWidth = 3;
            CurrentSeries.ChartArea = "ChartArea" + PosX + "x" + PosY;

            CurrentSeries.Name = "Series" + PosX + "x" + PosY;
            ChartToReturn.Series.Add(CurrentSeries);

            Title CurrentTitle = new Title(PosX + "x" + PosY);
            // ChartToReturn.Titles.Add(CurrentTitle);

            ChartToReturn.Width = 100;
            ChartToReturn.Height = 48;

            ChartToReturn.Update();
            //  ChartToReturn.Show();

            return ChartToReturn;

        }

        /// <summary>
        /// Display the information window related to the selected well
        /// </summary>
        public void DisplayInfoWindow(int IdxDescriptor)
        {
            FormForWellInformation NewWindow = new FormForWellInformation(this);

            NewWindow.textBoxName.Text = Name;
            NewWindow.textBoxInfo.Text = Info;

            if (Concentration >= 0)
                NewWindow.textBoxConcentration.Text = Concentration.ToString("e4");

            if (LocusID != -1)
                NewWindow.textBoxLocusID.Text = ((int)(LocusID)).ToString();


            if (Parent.GlobalInfo.ViewMode != eViewMode.PIE)
            {
                this.AssociatedPlate.DBConnection = new cDBConnection(this.AssociatedPlate, this.SQLTableName);
                // this.AssociatedPlate.DBConnection.DB_EstablishConnection();

                //  DataTable DT = new DataTable();
                //  this.AssociatedPlate.DBConnection.AddWellToDataTable(this, DT, false, Parent.GlobalInfo);



                // cExtendedList Values = 
                List<cDescriptorsType> LCDT = new List<cDescriptorsType>();
                LCDT.Add(Parent.ListDescriptors.GetActiveDescriptor());
                cExtendedTable ET = new cExtendedTable();

                foreach (var item in Parent.GlobalInfo.ListCellularPhenotypes)
                {
                    List<cCellularPhenotype> ListCellularPhenotypesToBeSelected = new List<cCellularPhenotype>();
                    ListCellularPhenotypesToBeSelected.Add(item);

                    cExtendedTable TmpET = this.AssociatedPlate.DBConnection.GetWellValues(this,
                                             LCDT,
                                             ListCellularPhenotypesToBeSelected);
                    if (TmpET.Count == 0) continue;
                    TmpET[0].Name = item.Name;
                    TmpET[0].Tag = item;

                    ET.Add(TmpET[0]);

                }


                ET.Name = this.Name;
                cViewerStackedHistogram VSH = new cViewerStackedHistogram();
                VSH.SetInputData(ET);
                VSH.Chart.BinNumber = LCDT[0].GetBinNumber();
                //VS.Chart.IsSelectable = true;
                //VSH.Chart.BackgroundColor = Color.LightGray;
                VSH.Chart.IsShadow = true;
                VSH.Chart.IsXAxis = true;
                VSH.Chart.IsYAxis = true;
                VSH.Chart.LabelAxisX = Parent.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();


                VSH.Run();
                VSH.Chart.Width = 0;// NewWindow.chartForFormWell.Width;
                VSH.Chart.Height = 0;// NewWindow.chartForFormWell.Height;
                // NewWindow.chartForFormWell = (Chart)(VSH.Chart);
                // NewWindow.Controls.Add(VSH.GetOutPut());

                cExtendedControl EC = VSH.GetOutPut();
                EC.Width = NewWindow.chartForFormWell.Width;
                EC.Height = NewWindow.chartForFormWell.Height;

                NewWindow.chartForFormWell.Controls.Add(EC);



                //cDisplayToWindow DTW = new cDisplayToWindow();
                //DTW.SetInputData(VSH.GetOutPut());
                //   DTW.Title = "Well [" + this.PosX + "x" + this.PosY + "] - " + this.Name;
                // DTW.Run();
                // DTW.Display();


                //  this.AssociatedPlate.DBConnection.DisplayTable(this);

                this.AssociatedPlate.DBConnection.DB_CloseConnection();
                //this.SQLTableName


                //this.db


                //CurrentSeries.ShadowOffset = 2;

                //for (int IdxValue = 0; IdxValue < ListDescriptors[IdxDescriptor].GetAssociatedType().GetBinNumber(); IdxValue++)
                //{
                //    double Value = ListDescriptors[IdxDescriptor].GetHistovalue(IdxValue);
                //    //CurrentSeries.Points.Add(Value);

                //    CurrentSeries.Points.AddXY(ListDescriptors[IdxDescriptor].GetHistoXvalue(IdxValue), Value);
                //    CurrentSeries.Points[IdxValue].ToolTip = Value.ToString();
                //}

                //CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
                //CurrentChartArea.Axes[0].Title = ListDescriptors[IdxDescriptor].GetName();
                ////  if (CurrentSeries.Points.Count == 1)
                //CurrentSeries.ChartType = SeriesChartType.Column;
                ////  else
                ////    CurrentSeries.ChartType = SeriesChartType.Line;
                //CurrentSeries.Color = Color.White;
                //CurrentSeries.BorderWidth = 3;
            }
            else
            {
                Series CurrentSeries = new Series("ChartSeries" + PosX + "x" + PosY);
                ChartArea CurrentChartArea = new ChartArea("ChartArea" + PosX + "x" + PosY);
                CurrentSeries.ChartType = SeriesChartType.Pie;
                for (int IdxValue = 0; IdxValue < ListDescriptors.Count; IdxValue++)
                {
                    if (ListDescriptors[IdxValue].GetAssociatedType().IsActive())
                    {
                        double Value = ListDescriptors[IdxValue].GetValue();
                        CurrentSeries.Points.Add(Value);
                        if (Value > 0)
                        {
                            CurrentSeries.Points[CurrentSeries.Points.Count - 1].Label = ListDescriptors[IdxValue].GetAssociatedType().GetName();

                            CurrentSeries.Points[CurrentSeries.Points.Count - 1].ToolTip = Value.ToString();
                        }
                    }
                }
                CurrentChartArea.BorderColor = Color.Black;

                NewWindow.chartForFormWell.ChartAreas.Add(CurrentChartArea);
                NewWindow.chartForFormWell.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                CurrentChartArea.BackColor = Color.FromArgb(64, 64, 64);
                CurrentSeries.ChartArea = "ChartArea" + PosX + "x" + PosY;

                CurrentSeries.Name = "Series" + PosX + "x" + PosY;
                NewWindow.chartForFormWell.Series.Add(CurrentSeries);
            }


            //     GlobalInfo.SwitchDistributionMode();
            //}

            //private void displayReferenceToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    CDisplayGraph DispGraph = new CDisplayGraph(CompleteScreening.Reference[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].ToArray(), CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].GetName() + " - Reference distribution.");
            //}

            NewWindow.richTextBoxDescription.AppendText("Plate: " + this.AssociatedPlate.Name + "\nWell: [" + this.GetPosX() + "x" + this.GetPosY() + "]");

            if (Parent.GlobalInfo.IsDistributionMode() && (Parent.Reference != null))
            {
                //Series CurrentSeriesReference = new Series("Reference");

                //CurrentSeriesReference.ChartType = SeriesChartType.Line;
                //CurrentSeriesReference.BorderWidth = 2;
                //CurrentSeriesReference.Color = Color.Red;
                ////  CurrentSeriesReference.ShadowOffset = 2;

                //double[] ReferenceCurve = Parent.Reference[Parent.ListDescriptors.CurrentSelectedDescriptor].ToArray();

                //for (int IdxValue = 0; IdxValue < ReferenceCurve.Length; IdxValue++)
                //{
                //    double Value = ReferenceCurve[IdxValue];
                //    CurrentSeriesReference.Points.Add(Value);
                //    CurrentSeriesReference.Points[IdxValue].ToolTip = "[Reference] " + Value.ToString();
                //}
                //NewWindow.chartForFormWell.Series.Add(CurrentSeriesReference);

                //if (Parent.GlobalInfo.OptionsWindow.checkBoxDisplayHistoStats.Checked)
                //{
                //    StripLine AverageLine = new StripLine();
                //    AverageLine.BackColor = Color.Red;
                //    AverageLine.IntervalOffset = Parent.Reference[Parent.ListDescriptors.CurrentSelectedDescriptor].GetWeightedMean();
                //    AverageLine.StripWidth = double.Epsilon;
                //    CurrentChartArea.AxisX.StripLines.Add(AverageLine);
                //    AverageLine.Text = String.Format("{0:0.###}", AverageLine.IntervalOffset);
                //    AverageLine.ForeColor = Color.White;
                //    AverageLine.StripWidth = 0.0001;
                //}

            }

            //if (Parent.GlobalInfo.OptionsWindow.checkBoxDisplayHistoStats.Checked)
            //{

            //    StripLine AverageLineHisto = new StripLine();
            //    AverageLineHisto.BackColor = Color.Red;
            //    AverageLineHisto.IntervalOffset = ListDescriptors[IdxDescriptor].Histogram.GetAverageValue();
            //    //   AverageLineHisto.IntervalOffset = ListDescriptors[CurrentDescriptorToDisplay].Getvalues().GetWeightedMean();
            //    AverageLineHisto.StripWidth = double.Epsilon;
            //    CurrentChartArea.AxisX.StripLines.Add(AverageLineHisto);
            //    AverageLineHisto.Text = String.Format("{0:0.###}", AverageLineHisto.IntervalOffset);
            //    AverageLineHisto.ForeColor = Color.White;
            //    AverageLineHisto.StripWidth = 0.0001;
            //}

            //Title CurrentTitle = new Title(PosX + "x" + PosY);
            //NewWindow.chartForFormWell.Titles.Add(CurrentTitle);

            NewWindow.Text = PosX + "x" + PosY + " / " + StateForClassif;

            string connec = string.Concat(new string[] { "server=", "192.168.10.10", ";uid=", "***", ";pwd=", "***", ";database=", "OPERA_DB" });

            string[] ListOpera = new string[3];
            ListOpera[0] = "OPERA-COMMON";
            ListOpera[1] = "OPERA-P3";
            ListOpera[2] = "OPERA-SUWON";
            List<string> strf = new List<string>();


            string[] SplittedString = Parent.ListPlatesActive[Parent.CurrentDisplayPlateIdx].Name.Split('(');
            if (SplittedString.Length == 1) goto THEEND;
            string PlateName = "(" + SplittedString[1];
            SqlConnection sqc = new SqlConnection(connec);
            for (int OperaIdx = 0; OperaIdx < ListOpera.Length; OperaIdx++)
            {
                string queryString = "SELECT A.PATH, A.TREE_NAME,B.MEA_NAME,B.MEA_YEAR, B.MEA_TYPE,B.BARCODE, C.MEA, C.[CIA-1],C.[CIA-2],C.[CIA-3], C.[CIA-4],C.[CIA-5],C.[CIA-6],";
                queryString += " A.END_FLAG FROM TB_OPERA_DB_TREE A LEFT OUTER JOIN TB_OPERA_MEA B ON A.ITEM_SEQ = B.MEA_PATH AND B.MEA_TYPE = '" + ListOpera[OperaIdx] + "' LEFT OUTER JOIN TB_OPERA_PATH C ON B.MEA_YEAR = C.EQ_YEAR";
                queryString += " AND B.MEA_TYPE = C.EQ_TYPE AND C.EQ_TYPE = '" + ListOpera[OperaIdx] + "' WHERE A.EQ_TYPE = '" + ListOpera[OperaIdx] + "' ORDER BY A.PATH ASC, A.LVL ASC, A.P_SEQ ASC";


                //  string queryString = "SELECT B.MEA_NAME, B.BARCODE, C.[CIA-1],C.[CIA-2],C.[CIA-3], C.[CIA-4],C.[CIA-5],C.[CIA-6]";
                //  queryString += " FROM TB_OPERA_DB_TREE A LEFT OUTER JOIN TB_OPERA_MEA B ON A.ITEM_SEQ = B.MEA_PATH AND B.MEA_TYPE = '" + ListOpera[OperaIdx] + "' LEFT OUTER JOIN TB_OPERA_PATH C ON B.MEA_YEAR = C.EQ_YEAR";
                //  queryString += " AND B.MEA_TYPE = C.EQ_TYPE AND C.EQ_TYPE = '" + ListOpera[OperaIdx] + "' WHERE A.EQ_TYPE = '" + ListOpera[OperaIdx] + "' ORDER BY A.PATH ASC, A.LVL ASC, A.P_SEQ ASC";

                SqlCommand command = new SqlCommand(queryString, sqc);
                sqc.Open();
                SqlDataReader reader = command.ExecuteReader();

                int cpt = 0;



                while (reader.Read())
                {

                    if (reader.GetSqlString(2).ToString().Contains(PlateName))
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            strf.Add(reader.GetSqlString(i).ToString());
                        }
                        goto THELOOPEND;
                    }

                    cpt++;
                }
                sqc.Close();

            }

        THELOOPEND: sqc.Close();

            if (strf.Count > 1)
            {

                string MeaFileLocation = strf[6] + strf[0] + "\\" + strf[2];

                StreamReader st = new StreamReader(MeaFileLocation);
                string FileRead = "";
                while (!st.EndOfStream)
                {
                    FileRead = st.ReadToEnd();
                }
                string[] Splter = new string[1];
                Splter[0] = "Wavelength";
                int NumWaveLength = FileRead.Split(Splter, StringSplitOptions.None).Length;

                string specifier = "000";

                string PX = this.GetPosX().ToString(specifier);
                string PY = this.GetPosY().ToString(specifier);


                for (int IdxCIA = 0; IdxCIA < 6; IdxCIA++)
                {

                    if (strf[IdxCIA + 2] == "Null") break;
                    string FinalName = strf[0].Remove(strf[0].Length - 4);

                    string NewTemp1 = strf[IdxCIA + 2] + "\\" + strf[1] + "\\" + FinalName + "\\" + PY + PX + "000.flex";
                    if (File.Exists(NewTemp1))
                    {
                        //  Bitmap NewBMP = new Bitmap(NewTemp1);

                        images = new ArrayList();

                        FreeImageAPI.FIMULTIBITMAP LoadedMultiPageImage = FreeImage.OpenMultiBitmap(FREE_IMAGE_FORMAT.FIF_TIFF, NewTemp1, false, true, true, FREE_IMAGE_LOAD_FLAGS.DEFAULT);



                        //int count = NewBMP.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                        for (int idx = 0; idx < FreeImage.GetPageCount(LoadedMultiPageImage); idx++)
                        {
                            // save each frame to a bytestream
                            //NewBMP.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, idx);
                            //MemoryStream byteStream = new MemoryStream();
                            //NewBMP.Save(byteStream, System.Drawing.Imaging.ImageFormat.Bmp);

                            FreeImageAPI.FIBITMAP LoadedPage = FreeImage.LockPage(LoadedMultiPageImage, idx);

                            FreeImageAPI.BITMAPINFO ImageInfo = FreeImage.GetInfoEx(LoadedPage);
                            int NumBands = (int)ImageInfo.bmiHeader.biPlanes;

                            FreeImageAPI.FIBITMAP LoadedImage = FreeImage.ConvertToStandardType(LoadedPage, true);
                            FreeImage.FlipVertical(LoadedImage);

                            images.Add((Image)FreeImage.GetBitmap(LoadedImage));



                            // and then create a new Image from it
                            //images.Add(Image.FromStream(byteStream));
                        }

                        NewWindow.numericUpDownIdxImage.Maximum = images.Count - 1;

                        DrawPic(NewWindow, null, null);
                        break;
                    }
                }

            }


            //    // display Image

            //    string toSearch = AssociatedPlate.Name;
        //    string[] ToSplit = toSearch.Split('/');

            //    if (Parent.GlobalInfo.OptionsWindow.textBoxMainServer.Text == "") goto THEEND;
        //    string[] ResultsPath = Directory.GetDirectories(Parent.GlobalInfo.OptionsWindow.textBoxMainServer.Text, ToSplit[0], SearchOption.AllDirectories);
        //    string RealDir = "";
        //    if (ResultsPath.Length == 0) goto THEEND;
        //    foreach (string CurrPath in ResultsPath)
        //    {
        //        string[] Results = Directory.GetFiles(CurrPath, ToSplit[1] + ".mea", SearchOption.AllDirectories);
        //        if (Results.Length == 1)
        //        {
        //            RealDir = Results[0];
        //            break;
        //        }
        //    }

            //    if (RealDir == "") goto THEEND;
        //    //XmlReader XMLRead = XmlReader.Create(RealDir);
        //    List<string> ListHosts = new List<string>();

            //    XmlReader xmlReader = new XmlTextReader(RealDir);
        //    xmlReader.MoveToContent();
        //    while (!xmlReader.EOF)
        //    {
        //        string localName = xmlReader.LocalName;
        //        switch (localName)
        //        {
        //            case "Host":
        //                {
        //                    string HostName = xmlReader["name"];
        //                    if (HostName != null) ListHosts.Add(HostName);
        //                    break;
        //                }
        //            default: break;
        //        }
        //        xmlReader.Read();
        //    }

            //    StreamReader st = new StreamReader(RealDir);
        //    string FileRead = "";
        //    while (!st.EndOfStream)
        //    {
        //        FileRead = st.ReadToEnd();
        //    }

            //    int Idx = FileRead.IndexOf("path");
        //    string Stemp = FileRead.Remove(0, Idx + 6);
        //    int Idx1 = Stemp.IndexOf("table_");

            //    string NewTmp = Stemp.Remove(Idx1 - 11);

            //    //string PX = "0"+this.GetPosX().ToString("N3");
        //    string specifier = "000";

            //    string PX = this.GetPosX().ToString(specifier);
        //    string PY = this.GetPosY().ToString(specifier);

            //    string NewHost = "";
        //    foreach (string Host in ListHosts)
        //    {
        //        if (Host == "CIA-1") NewHost = "CIA-01";
        //        if (Host == "CIA-2") NewHost = "CIA-02";
        //        if (Host == "CIA-3") NewHost = "CIA-03";
        //        if (Host == "CIA-4") NewHost = "CIA-04";

            //        string NewTemp1 = "\\\\ip-korea.org\\REQ\\opr_p2_2012\\" + NewHost + "\\screening\\" + NewTmp + PY + PX + "000.flex";
        //        if (File.Exists(NewTemp1))
        //        {

            //            //  Graphics g = Graphics.FromImage(NewBMP);
        //            Bitmap NewBMP = new Bitmap(NewTemp1);

            //            //XmpParser parser = new XmpParser();
        //            //System.Xml.XmlDocument xml = (System.Xml.XmlDocument)parser.ParseFromImage(stream, frameIndex);


            //            images = new ArrayList();


            //            int count = NewBMP.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
        //            for (int idx = 0; idx < count; idx++)
        //            {
        //                // save each frame to a bytestream
        //                NewBMP.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, idx);
        //                MemoryStream byteStream = new MemoryStream();
        //                NewBMP.Save(byteStream, System.Drawing.Imaging.ImageFormat.Bmp);

            //                // and then create a new Image from it
        //                images.Add(Image.FromStream(byteStream));
        //            }

            //            NewWindow.numericUpDownIdxImage.Maximum = images.Count - 1;

            //            DrawPic(NewWindow, null, null);
        //        }
        //    }
        ////Graphics g = NewWindow.pictureBoxForImage.CreateGraphics();
        ////g.DrawImage((Image)NewBMP, 1, 1);
        ////NewBMP.PixelFormat = System.Drawing.Imaging.PixelFormat.Format16bppRgb555;
        //// NewWindow.pictureBoxForImage.Image = (Image)NewBMP;
        ////NewWindow.pictureBoxForImage.Image = System.Drawing.Image.FromFile("005001000.tiff", true);
        ////  NewWindow.pictureBoxForImage.Image = System.Drawing.Image.FromFile("hilbert.tif");
        ////NewWindow.pictureBoxForImage.
        //THEEND: ;

            THEEND: ;

            NewWindow.chartForFormWell.Update();
            //NewWindow.chartForFormWell.Show();


            NewWindow.Show();
            return;
        }

        public void DrawPic(FormForWellInformation NewWindow, List<double> lMin, List<double> lMax)
        {
            if (images == null) return;

            Graphics ThisGraph = NewWindow.panelForImage.CreateGraphics();
            //   ThisGraph.Clear(Color.White);
            //NewWindow.pictureBoxForImage.Image = (Image)images[(int)NewWindow.numericUpDownIdxImage.Value];
            //Graphics bmG = Graphics.FromImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value]);
            ThisGraph.DrawImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value], new Point(0, 0));
            ThisGraph.DrawString("Image " + (int)NewWindow.numericUpDownIdxImage.Value, new Font(FontFamily.GenericSansSerif, 10), System.Drawing.Brushes.LightYellow, 5, 5);
            //  ThisGraph.DrawImage((Image)images[(int)NewWindow.numericUpDownIdxImage.Value], new Point(0, 0));

            //  NewWindow.pictureBoxForImage.Invalidate();

        }

        private void DisplayInfo(object sender, EventArgs e)
        {
            DisplayInfoWindow(CurrentDescriptorToDisplay);
        }

        internal void AddDescriptors(List<cDescriptor> LDesc)
        {
            this.ListDescriptors.AddRange(LDesc);
        }

        /// <summary>
        /// copy the plate visualization to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyVisu(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();

            Graphics g = Parent.GlobalInfo.panelForPlate.CreateGraphics();
            Bitmap bmp = new Bitmap(Parent.GlobalInfo.panelForPlate.Width, Parent.GlobalInfo.panelForPlate.Height);

            Parent.GlobalInfo.panelForPlate.DrawToBitmap(bmp, new Rectangle(0, 0, Parent.GlobalInfo.panelForPlate.Width, Parent.GlobalInfo.panelForPlate.Height));
            Clipboard.SetImage(bmp);

            return;
        }

        /// <summary>
        /// Create a single instance for WEKA
        /// </summary>
        /// <param name="NClasses">Number of classes</param>
        /// <returns>the weka instances</returns>
        public Instances CreateInstanceForNClasses(cInfoClass InfoClass)
        {
            List<double> AverageList = new List<double>();

            for (int i = 0; i < Parent.ListDescriptors.Count; i++)
                if (Parent.ListDescriptors[i].IsActive()) AverageList.Add(GetAverageValuesList(false)[i]);

            weka.core.FastVector atts = new FastVector();

            List<string> NameList = Parent.ListDescriptors.GetListNameActives();

            for (int i = 0; i < NameList.Count; i++)
                atts.addElement(new weka.core.Attribute(NameList[i]));

            weka.core.FastVector attVals = new FastVector();
            for (int i = 0; i < InfoClass.NumberOfClass; i++)
                attVals.addElement("Class" + i);

            atts.addElement(new weka.core.Attribute("Class__", attVals));

            Instances data1 = new Instances("SingleInstance", atts, 0);

            double[] newTable = new double[AverageList.Count + 1];
            Array.Copy(AverageList.ToArray(), 0, newTable, 0, AverageList.Count);
            //newTable[AverageList.Count] = 1;

            data1.add(new DenseInstance(1.0, newTable));
            data1.setClassIndex((data1.numAttributes() - 1));
            return data1;
        }

        //public Instances CreateInstanceWithClass(List<bool> ListClassSelected)
        //{
        //    List<double> AverageList = new List<double>();

        //    for (int i = 0; i < Parent.ListDescriptors.Count; i++)
        //        if (Parent.ListDescriptors[i].IsActive()) AverageList.Add(GetAverageValuesList(false)[i]);

        //    weka.core.FastVector atts = new FastVector();

        //    List<string> NameList = Parent.ListDescriptors.GetListNameActives();

        //    for (int i = 0; i < NameList.Count; i++)
        //        atts.addElement(new weka.core.Attribute(NameList[i]));

        //    weka.core.FastVector attVals = new FastVector();

        //    for (int i = 0; i < InfoClass.NumberOfClass; i++)
        //        attVals.addElement("Class" + i);

        //    atts.addElement(new weka.core.Attribute("Class", attVals));

        //    Instances InstancesToReturn = new Instances("SingleInstance", atts, 0);

        //    double[] newTable = new double[AverageList.Count + 1];
        //    Array.Copy(AverageList.ToArray(), 0, newTable, 0, AverageList.Count);
        //    //newTable[AverageList.Count] = 1;

        //    InstancesToReturn.add(new DenseInstance(1.0, newTable));
        //    InstancesToReturn.setClassIndex((InstancesToReturn.numAttributes() - 1));
        //    return InstancesToReturn;


        //}


    }
}
