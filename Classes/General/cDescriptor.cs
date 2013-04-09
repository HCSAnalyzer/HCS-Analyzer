using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows;
using System.Drawing;
using HCSAnalyzer.Forms.IO;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using HCSAnalyzer.Controls;
using HCSAnalyzer.Classes.Base_Classes.GUI;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using HCSAnalyzer.Classes.General;

namespace LibPlateAnalysis
{

    public enum eDistances { EUCLIDEAN, MANHATTAN, VECTOR_COS, BHATTACHARYYA, EMD };

    public class cDescriptorsLinearCombination : List<cDescriptorsType>
    {
        cExtendedList ListWeights;// = new cExtendedList();
        cGlobalInfo GlobalInfo;
        string Name;

        public cDescriptorsLinearCombination(cExtendedList ListWeights, cGlobalInfo GlobalInfo)
        {
            this.ListWeights = new cExtendedList();
            this.ListWeights.Name = ListWeights.Name;
            this.ListWeights = ListWeights;
            this.GlobalInfo = GlobalInfo;
            this.Name = ListWeights.Name;
        }

        public List<ToolStripMenuItem> GetContextMenu()
        {
            List<ToolStripMenuItem> ListToReturn = new List<ToolStripMenuItem>();

            // perform projection
            ToolStripMenuItem PerformProjection = new ToolStripMenuItem("Perform projection");
            PerformProjection.Click += new System.EventHandler(this.PerformProjection);
            ListToReturn.Add(PerformProjection);
            return ListToReturn;
        }

        void PerformProjection(object sender, EventArgs e)
        {
            string NewName = this.Name;
            string Description = "";

            for (int IdxActiveDesc = 0; IdxActiveDesc < this.Count; IdxActiveDesc++)
                Description += this.ListWeights[IdxActiveDesc].ToString("N2") + "\t*\t" + this[IdxActiveDesc].GetName() + "\n";

            cDescriptorsType NewType = new cDescriptorsType(NewName, true, 1, GlobalInfo, Description);
            GlobalInfo.CurrentScreen.ListDescriptors.AddNew(NewType);

            foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();
                    double NewValue = 0;

                    for (int IdxActiveDesc = 0; IdxActiveDesc < this.Count; IdxActiveDesc++)
                        NewValue += this.ListWeights[IdxActiveDesc] * Tmpwell.ListDescriptors[IdxActiveDesc].GetValue();

                    cDescriptor NewDesc = new cDescriptor(NewValue, NewType, GlobalInfo.CurrentScreen);
                    LDesc.Add(NewDesc);
                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            GlobalInfo.CurrentScreen.ListDescriptors.UpDateDisplay();
            GlobalInfo.CurrentScreen.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < GlobalInfo.CurrentScreen.ListPlatesActive.Count; idxP++)
                GlobalInfo.CurrentScreen.ListPlatesActive[idxP].UpDataMinMax();
        }
    }

    public class cDescriptorsType : cGeneralComponent
    {
        public bool IsConnectedToDatabase { get; private set; }
        private string Name;
        public string description;
        private int NumBin;
        cGlobalInfo GlobalInfo;
        public FormForDescriptorInfo WindowDescriptorInfo;
        private bool ActiveState;

        public cDescriptorsType(string Name, bool IsActive, int BinNumber, bool IsConnectedToDB, cGlobalInfo GlobalInfo)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            if (GlobalInfo.CurrentScreen != null)
            {
                int IdxForNewName = -1;
                bool IsAlreadyExisting = false;
                string OriginalName = Name;

                foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                {
                    if (item.Name == Name)
                    {
                        IsAlreadyExisting = true;
                        break;
                    }
                }

                while (IsAlreadyExisting)
                {
                    IdxForNewName++;
                    Name = OriginalName + IdxForNewName;

                    IsAlreadyExisting = false;
                    foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                    {
                        if (item.Name == Name)
                        {
                            IsAlreadyExisting = true;
                            break;
                        }
                    }
                }
            }

            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            this.IsConnectedToDatabase = IsConnectedToDB;
            this.GlobalInfo = GlobalInfo;
            CreateAssociatedWindow();
        }

        public cDescriptorsType(string Name, bool IsActive, int BinNumber, cGlobalInfo GlobalInfo)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            if (GlobalInfo.CurrentScreen != null)
            {
                int IdxForNewName = -1;
                bool IsAlreadyExisting = false;
                string OriginalName = Name;

                foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                {
                    if (item.Name == Name)
                    {
                        IsAlreadyExisting = true;
                        break;
                    }
                }

                while (IsAlreadyExisting)
                {
                    IdxForNewName++;
                    Name = OriginalName + IdxForNewName;

                    IsAlreadyExisting = false;
                    foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                    {
                        if (item.Name == Name)
                        {
                            IsAlreadyExisting = true;
                            break;
                        }
                    }
                }
            }
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            this.IsConnectedToDatabase = false;
            this.GlobalInfo = GlobalInfo;

            CreateAssociatedWindow();
        }

        public cDescriptorsType(string Name, bool IsActive, int BinNumber, cGlobalInfo GlobalInfo, string Description)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            if (GlobalInfo.CurrentScreen != null)
            {
                int IdxForNewName = -1;
                bool IsAlreadyExisting = false;
                string OriginalName = Name;

                foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                {
                    if (item.Name == Name)
                    {
                        IsAlreadyExisting = true;
                        break;
                    }
                }

                while (IsAlreadyExisting)
                {
                    IdxForNewName++;
                    Name = OriginalName + IdxForNewName;

                    IsAlreadyExisting = false;
                    foreach (var item in GlobalInfo.CurrentScreen.ListDescriptors)
                    {
                        if (item.Name == Name)
                        {
                            IsAlreadyExisting = true;
                            break;
                        }
                    }
                }

               
            } 
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            this.IsConnectedToDatabase = false;
            this.GlobalInfo = GlobalInfo;
            this.description = Description;
            CreateAssociatedWindow();
        }
        public string GetName()
        {
            return Name;
        }

        public string GetShortInfo()
        {
            base.ShortInfo = "Descriptor: " + this.Name + "\n";
            return base.GetShortInfo();
        }


        public int GetBinNumber()
        {
            return NumBin;
        }

        public string GetDataType()
        {
            if (NumBin == 1) return "Single";
            else
                return "Histogram";
        }

        public void SetActiveState(bool IsActive)
        {
            this.ActiveState = IsActive;
        }

        public bool IsActive()
        {
            return this.ActiveState;
        }

        public bool ChangeName(string NewName)
        {
            this.Name = NewName;
            return true;
        }

        public void ChangeBinNumber(int NewBinNumber)
        {
            int IdxDesc = GlobalInfo.CurrentScreen.ListDescriptors.GetDescriptorIndex(this);

            foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesAvailable)
            {
                for (int Col = 1; Col <= GlobalInfo.CurrentScreen.Columns; Col++)
                    for (int Row = 1; Row <= GlobalInfo.CurrentScreen.Rows; Row++)
                    {
                        cWell TmpWell = TmpPlate.GetWell(Col, Row, false);
                        if (TmpWell == null) continue;
                        TmpWell.ListDescriptors[IdxDesc].RefreshHisto(NewBinNumber);
                    }
            }

            this.NumBin = NewBinNumber;

        }

        private void CreateAssociatedWindow()
        {
            WindowDescriptorInfo = new FormForDescriptorInfo(this);
            WindowDescriptorInfo.CurrentDesc = this;
            WindowDescriptorInfo.Text = this.Name;
        }

        public List<ToolStripMenuItem> GetExtendedContextMenu()
        {
            List<ToolStripMenuItem> ListToReturn = new List<ToolStripMenuItem>();

            base.SpecificContextMenu = new ToolStripMenuItem(this.Name);

            // info
            ToolStripMenuItem InfoDescItem = new ToolStripMenuItem("Info");
            InfoDescItem.Click += new System.EventHandler(this.InfoDescItem);
            base.SpecificContextMenu.DropDownItems.Add(InfoDescItem);

            ToolStripMenuItem StackedHistoDescItem = new ToolStripMenuItem("Stacked Histo.");
            StackedHistoDescItem.Click += new System.EventHandler(this.StackedHistoDescItem);
            base.SpecificContextMenu.DropDownItems.Add(StackedHistoDescItem);

            if (GlobalInfo.CurrentScreen.ListDescriptors.Count >= 2)
            {
                ToolStripMenuItem RemoveDescItem = new ToolStripMenuItem("Remove");
                RemoveDescItem.Click += new System.EventHandler(this.RemoveDescItem);
                base.SpecificContextMenu.DropDownItems.Add(RemoveDescItem);
            }

            base.SpecificContextMenu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem DescriptorsView = new ToolStripMenuItem("Descriptor view");
            DescriptorsView.Click += new System.EventHandler(this.DescriptorsView);
            base.SpecificContextMenu.DropDownItems.Add(DescriptorsView);

            ToolStripMenuItem DescriptorsSetAsActive = new ToolStripMenuItem("Set as current");
            DescriptorsSetAsActive.Click += new System.EventHandler(this.DescriptorsSetAsActive);
            base.SpecificContextMenu.DropDownItems.Add(DescriptorsSetAsActive);


            string NewState = "";
            if (this.ActiveState)
                NewState = "inactive";
            else
                NewState = "active";

            ToolStripMenuItem DescriptorsSetAsInActive = new ToolStripMenuItem("Set as "+NewState);
            DescriptorsSetAsInActive.Click += new System.EventHandler(this.DescriptorsSetAsInActive);
            base.SpecificContextMenu.DropDownItems.Add(DescriptorsSetAsInActive);

            ListToReturn.Add(base.SpecificContextMenu);
            return ListToReturn;
        }

        void DescriptorsView(object sender, EventArgs e)
        {
          //  GlobalInfo.CurrentScreen.GetCurrentDisplayPlate().DisplayDescriptorsWindow();

            List<cPanelForDisplayArray> ListPlates = new List<cPanelForDisplayArray>();

            foreach (cPlate CurrentPlate in GlobalInfo.CurrentScreen.ListPlatesActive)
                ListPlates.Add(new FormToDisplayPlate(CurrentPlate, GlobalInfo.CurrentScreen));

            cWindowToDisplayEntireScreening WindowToDisplayArray = new cWindowToDisplayEntireScreening(ListPlates, this.GetName(), 6, GlobalInfo);
            WindowToDisplayArray.Show();
        }

        void DescriptorsSetAsActive(object sender, EventArgs e)
        {
            GlobalInfo.WindowHCSAnalyzer.comboBoxDescriptorToDisplay.Text = this.Name;
        }

        void DescriptorsSetAsInActive(object sender, EventArgs e)
        {
            for (int i = 0; i < GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count; i++)
			{
                if (GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items[i].ToString() == this.Name)
                {
                    this.ActiveState = !this.ActiveState;
                    GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.SetItemChecked(i, this.ActiveState);
                    return;
                }
			}
        }

        void StackedHistoDescItem(object sender, EventArgs e)
        {

            #region Obsolete
            //FormForMultipleClassSelection WindowForClassSelection = new FormForMultipleClassSelection();
            //PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true);
            //ClassSelectionPanel.Height = WindowForClassSelection.splitContainerForClassSelection.Panel1.Height;
            //WindowForClassSelection.splitContainerForClassSelection.Panel1.Controls.Add(ClassSelectionPanel);

            //if (WindowForClassSelection.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            ////     WindowForClassSelection.panelForClassesSelection = new 

            //cExtendedList[] ListValuesForHisto = new cExtendedList[/*ClassSelectionPanel.GetListIndexSelectedClass().Count*/ GlobalInfo.GetNumberofDefinedWellClass()];

            //List<bool> ListSelectedClass = ClassSelectionPanel.GetListSelectedClass();

            //for (int i = 0; i < ListValuesForHisto.Length; i++)
            //    ListValuesForHisto[i] = new cExtendedList();

            //cWell TempWell;

            //int NumberOfPlates = GlobalInfo.CurrentScreen.ListPlatesActive.Count;

            //double MinValue = double.MaxValue;
            //double MaxValue = double.MinValue;
            //double CurrentValue;

            //int IdxDesc = -1;

            //for (int Idx = 0; Idx < GlobalInfo.CurrentScreen.ListDescriptors.Count; Idx++)
            //{
            //    if (GlobalInfo.CurrentScreen.ListDescriptors[Idx] == this)
            //    {
            //        IdxDesc = Idx;
            //        break;
            //    }
            //}
            //if (IdxDesc == -1) return;

            //// loop on all the plate
            //for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            //{
            //    cPlate CurrentPlateToProcess = GlobalInfo.CurrentScreen.ListPlatesActive.GetPlate(GlobalInfo.CurrentScreen.ListPlatesActive[PlateIdx].Name);

            //    for (int row = 0; row < GlobalInfo.CurrentScreen.Rows; row++)
            //        for (int col = 0; col < GlobalInfo.CurrentScreen.Columns; col++)
            //        {
            //            TempWell = CurrentPlateToProcess.GetWell(col, row, false);
            //            if (TempWell == null) continue;
            //            else
            //            {
            //                if (TempWell.GetClassIdx() >= 0)
            //                {
            //                    CurrentValue = TempWell.ListDescriptors[IdxDesc].GetValue();
            //                    ListValuesForHisto[TempWell.GetClassIdx()].Add(CurrentValue);
            //                    if (CurrentValue < MinValue) MinValue = CurrentValue;
            //                    if (CurrentValue > MaxValue) MaxValue = CurrentValue;
            //                }
            //            }
            //        }
            //}
            //SimpleForm NewWindow = new SimpleForm();
            //List<double[]>[] HistoPos = new List<double[]>[ListValuesForHisto.Length];
            //Series[] SeriesPos = new Series[ListValuesForHisto.Length];


            //for (int i = 0; i < ListValuesForHisto.Length; i++)
            //{
            //    HistoPos[i] = new List<double[]>();
            //    if (ListSelectedClass[i])
            //        HistoPos[i] = ListValuesForHisto[i].CreateHistogram(MinValue, MaxValue, (int)GlobalInfo.OptionsWindow.numericUpDownHistoBin.Value);

            //    SeriesPos[i] = new Series();
            //}

            //for (int i = 0; i < SeriesPos.Length; i++)
            //{
            //    int Max = 0;
            //    if (HistoPos[i].Count > 0)
            //        Max = HistoPos[i][0].Length;

            //    for (int IdxValue = 0; IdxValue < Max; IdxValue++)
            //    {
            //        SeriesPos[i].Points.AddXY(MinValue + ((MaxValue - MinValue) * IdxValue) / Max, HistoPos[i][1][IdxValue]);
            //        SeriesPos[i].Points[IdxValue].ToolTip = HistoPos[i][1][IdxValue].ToString();
            //        if (GlobalInfo.CurrentScreen.SelectedClass == -1)
            //            SeriesPos[i].Points[IdxValue].Color = Color.Black;
            //        else
            //            SeriesPos[i].Points[IdxValue].Color = GlobalInfo.CurrentScreen.GlobalInfo.ListWellClasses[i].ColourForDisplay;
            //    }
            //}
            //ChartArea CurrentChartArea = new ChartArea();
            //CurrentChartArea.BorderColor = Color.Black;

            //NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
            //CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            //CurrentChartArea.Axes[0].Title = this.Name;
            //CurrentChartArea.Axes[1].Title = "Sum";
            //CurrentChartArea.AxisX.LabelStyle.Format = "N2";

            //NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            //CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            //CurrentChartArea.BackColor = GlobalInfo.CurrentScreen.GlobalInfo.OptionsWindow.panel1.BackColor;
            //CurrentChartArea.BackSecondaryColor = Color.White;


            //for (int i = 0; i < SeriesPos.Length; i++)
            //{
            //    SeriesPos[i].ChartType = SeriesChartType.StackedColumn;
            //    // SeriesPos[i].Color = GlobalInfo.CurrentScreen.GlobalInfo.GetColor(1);
            //    if (ListSelectedClass[i])
            //        NewWindow.chartForSimpleForm.Series.Add(SeriesPos[i]);
            //}
            ////Series SeriesGaussNeg = new Series();
            ////SeriesGaussNeg.ChartType = SeriesChartType.Spline;

            ////Series SeriesGaussPos = new Series();
            ////SeriesGaussPos.ChartType = SeriesChartType.Spline;

            ////if (HistoPos.Count != 0)
            ////{
            ////    double[] HistoGaussPos = CreateGauss(Mean(Pos.ToArray()), std(Pos.ToArray()), HistoPos[0].Length);

            ////    SeriesGaussPos.Color = Color.Black;
            ////    SeriesGaussPos.BorderWidth = 2;
            ////}
            ////SeriesGaussNeg.Color = Color.Black;
            ////SeriesGaussNeg.BorderWidth = 2;

            ////NewWindow.chartForSimpleForm.Series.Add(SeriesGaussNeg);
            ////NewWindow.chartForSimpleForm.Series.Add(SeriesGaussPos);
            //NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserEnabled = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            //Title CurrentTitle = null;

            //CurrentTitle = new Title(this.Name + " Stacked histogram.");

            //CurrentTitle.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);
            //NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);
            //NewWindow.Text = CurrentTitle.Text;
            //NewWindow.Show();
            //NewWindow.chartForSimpleForm.Update();
            //NewWindow.chartForSimpleForm.Show();
            //NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
            //return;
            #endregion

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                System.Windows.Forms.MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cDisplayToWindow CDW1 = new cDisplayToWindow();

            

           // if ((ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked) || (ProcessModeEntireScreeningToolStripMenuItem.Checked))
            {
                cListWell ListWellsToProcess = new cListWell(null);
                List<cPlate> PlateList = new List<cPlate>();

//                if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
//                    PlateList.Add(GlobalInfo.CurrentScreen.GetCurrentDisplayPlate());
//                else
//                {
                    foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesActive) PlateList.Add(TmpPlate);
//                }

                foreach (cPlate TmpPlate in PlateList)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);


               // if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
               //     CDW1.Title = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptor].GetName() + " - Stacked Histogram (" + PlateList[0].Name + ")";
               // else
                    CDW1.Title = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Stacked Histogram - " + PlateList.Count + " plates";

                cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx, true);
                NewTable.Name = CDW1.Title;

                cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
                CV1.SetInputData(NewTable);
                CV1.Chart.LabelAxisX = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                CV1.Run();

                CDW1.SetInputData(CV1.GetOutPut());
            }
            //else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            //{
            //    cDesignerTab CDT = new cDesignerTab();
            //    foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesActive)
            //    {
            //        cListWell ListWellsToProcess = new cListWell(null);
            //        foreach (cWell item in TmpPlate.ListActiveWells)
            //            if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

            //        cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptor, true);
            //        NewTable.Name = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptor].GetName() + " - " + TmpPlate.Name;


            //        cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
            //        CV1.SetInputData(NewTable);
            //        CV1.Chart.LabelAxisX = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptor].GetName();
            //        CV1.Title = TmpPlate.Name;
            //        CV1.Run();

            //        CDT.SetInputData(CV1.GetOutPut());
            //    }
            //    CDT.Run();
            //    CDW1.SetInputData(CDT.GetOutPut());
            //    CDW1.Title = "Stacked Histogram - " + GlobalInfo.CurrentScreen.ListPlatesActive.Count + " plates";
            //}

            CDW1.Run();
            CDW1.Display();

        }

        void RemoveDescItem(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult ResWin = System.Windows.Forms.MessageBox.Show("By applying this process, the selected descriptor will be definitively removed from this analysis ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResWin == System.Windows.Forms.DialogResult.No) return;
            GlobalInfo.CurrentScreen.ListDescriptors.RemoveDesc(this, GlobalInfo.CurrentScreen);

            //GlobalInfo.CurrentScreen.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < GlobalInfo.CurrentScreen.ListPlatesActive.Count; idxP++)
                GlobalInfo.CurrentScreen.ListPlatesActive[idxP].UpDataMinMax();
            GlobalInfo.CurrentScreen.GetCurrentDisplayPlate().DisplayDistribution(GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        void InfoDescItem(object sender, EventArgs e)
        {
            WindowDescriptorInfo.ShowDialog();
            GlobalInfo.CurrentScreen.ListDescriptors.UpDateDisplay();
        }

    }

    public class cListDescriptors : List<cDescriptorsType>
    {
        CheckedListBox AssociatedListBox;
        ComboBox AssociatedListDescriptorToDisplay;
        public int CurrentSelectedDescriptorIdx = -1;

        public int GetDescriptorIndex(cDescriptorsType DescriptorType)
        {
            int DescIndex = -1;
            foreach (cDescriptorsType TmpDescType in this)
            {
                DescIndex++;
                if (TmpDescType.GetName() == DescriptorType.GetName()) return DescIndex;
            }

            return -1;
        }

        public List<cDescriptorsType> GetActiveDescriptors()
        {
            List<cDescriptorsType> ToReturn = new List<cDescriptorsType>();
            
            foreach (cDescriptorsType TmpDesc in this)
                if (TmpDesc.IsActive()) ToReturn.Add(TmpDesc);

            return ToReturn;            
        }

        public cDescriptorsType GetActiveDescriptor()
        {
            if (CurrentSelectedDescriptorIdx == -1) return null;
            return this[CurrentSelectedDescriptorIdx];
        }

        public int GetDescriptorIndex(string DescriptorName)
        {
            int DescIndex = -1;
            foreach (cDescriptorsType TmpDescType in this)
            {
                DescIndex++;
                if (TmpDescType.GetName() == DescriptorName) return DescIndex;
            }

            return -1;
        }

        public void SetCurrentSelectedDescriptor(int Desc)
        {
            this.CurrentSelectedDescriptorIdx = Desc;
            this.AssociatedListDescriptorToDisplay.SelectedIndex = Desc;
        }

        public cListDescriptors(CheckedListBox AssociatedListBox, ComboBox AssociatedComboBox)
        {
            this.AssociatedListBox = AssociatedListBox;
            this.AssociatedListDescriptorToDisplay = AssociatedComboBox;

        }

        /// <summary>
        /// Clear the object as well as the associated control
        /// </summary>
        public void Clean()
        {
            this.Clear();
            AssociatedListBox.Items.Clear();
            AssociatedListDescriptorToDisplay.Items.Clear();
        }

        /// <summary>
        /// Add a descritpor to the global descriptor list
        /// </summary>
        /// <param name="DescriptorsType"></param>
        /// <returns>return false if the descriptor type already exist</returns>
        public bool AddNew(cDescriptorsType DescriptorsType)
        {
            foreach (cDescriptorsType temp in this)
            {
                if (temp.GetName() == DescriptorsType.GetName())
                    return false;
            }


            this.Add(DescriptorsType);
            this.AssociatedListBox.Items.Add(DescriptorsType.GetName(), true);
            this.AssociatedListDescriptorToDisplay.Items.Add(DescriptorsType.GetName());
            return true;
        }

        public void RemoveDesc(cDescriptorsType DescriptorTypeToBeRemoved, cScreening CurrentScreen)
        {
            for (int i = 0; i < this.Count; i++)
            {
                cDescriptorsType TmpType = this[i];

                if (DescriptorTypeToBeRemoved == TmpType)
                {
                    foreach (cPlate TmpPlate in CurrentScreen.ListPlatesAvailable)
                    {
                        foreach (cWell Tmpwell in TmpPlate.ListActiveWells) Tmpwell.ListDescriptors.RemoveAt(i);
                    }

                    this.RemoveAt(i);
                    AssociatedListBox.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.SelectedIndex = 0;
                    return;

                }
            }
        }

        public void RemoveDescUnSafe(cDescriptorsType DescriptorTypeToBeRemoved, cScreening CurrentScreen)
        {
            for (int i = 0; i < this.Count; i++)
            {
                cDescriptorsType TmpType = this[i];

                if (DescriptorTypeToBeRemoved == TmpType)
                {
                    foreach (cPlate TmpPlate in CurrentScreen.ListPlatesAvailable)
                    {
                        foreach (cWell Tmpwell in TmpPlate.ListActiveWells) Tmpwell.ListDescriptors.RemoveAt(i);
                    }

                    this.RemoveAt(i);
                    AssociatedListBox.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.Items.RemoveAt(i);

                    return;

                }
            }
        }

        public List<string> GetListNameActives()
        {
            List<string> NameActiveDesc = new List<string>();

            foreach (cDescriptorsType TmpDesc in this)
            {
                if (TmpDesc.IsActive()) NameActiveDesc.Add(TmpDesc.GetName());
            }
            return NameActiveDesc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsActive"></param>
        public void SetItemState(int IdxDesc, bool IsActive)
        {
            if (IsActive)
            {
                AssociatedListBox.SetItemCheckState(IdxDesc, CheckState.Checked);
                this[IdxDesc].SetActiveState(true);
            }
            else
            {
                AssociatedListBox.SetItemCheckState(IdxDesc, CheckState.Unchecked);
                this[IdxDesc].SetActiveState(false);
            }

        }

        public void UpDateDisplay()
        {
            int Idx = 0;
            foreach (cDescriptorsType TmpType in this)
            {
                AssociatedListBox.Items[Idx] = TmpType.GetName();
                AssociatedListDescriptorToDisplay.Items[Idx] = TmpType.GetName();
                Idx++;
            }
        }

        public cExtendedList GetValue(List<cPlate> ListPlate, cDescriptorsType Desc)
        {
            cExtendedList ToReturn = new cExtendedList();

            int Idx = this.GetDescriptorIndex(Desc);

            foreach (cPlate CurrentPlate in ListPlate)
                foreach (cWell TmpWell in CurrentPlate.ListActiveWells)
                    ToReturn.Add(TmpWell.ListDescriptors[Idx].GetValue());
            return ToReturn;
        }

    }

    public class cDescriptor
    {
        //string Name;
        //public bool IsSingle;

        cDescriptorsType Type;

        public cWell AssociatedWell;

        private cScreening CurrentScreening;

        public cDescriptorsType GetAssociatedType()
        {
            return this.Type;
        }

        public cHisto Histogram;

        private double AverageValue = 0;

        private double ComputeDistributionDistanceToReference()
        {
            return 0;

        }

        public int HistoBins;

        #region public

        /// <summary>
        /// Return the value associated to a descriptor within a well
        /// </summary>
        /// <returns>if scalar mode: average else distance between histograms</returns>
        public double GetValue()
        {
            if (CurrentScreening.Reference == null)
            {
                //if (Type.GetBinNumber() > 1)
                //{
                //   // MessageBox.Show("GetWeightedMean() not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    //return HistoValues.GetWeightedMean();
                //    return -1;
                //}
                //else
                //    return Histogram.GetXvalues()[0];
                return this.AverageValue;// this.Histogram.GetAverageValue();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("GetValue() not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //if (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEuclidean.Checked)
                //    return HistoValues.Dist_Euclidean(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricManhattan.Checked)
                //    return HistoValues.Dist_Manhattan(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricCosine.Checked)
                //    return HistoValues.Dist_VectorCosine(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricBhattacharyya.Checked)
                //    return HistoValues.Dist_BhattacharyyaCoefficient(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEMD.Checked)
                //    return HistoValues.Dist_EarthMover(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else
                return -1;
            }



        }

        public void RefreshHisto(int NewNumBins)
        {
            this.HistoBins = NewNumBins;
            this.Histogram = new cHisto(this.GetOriginalValues(), HistoBins);


        }



        public void SetHistoValues(List<double> ListXValues, List<double> ListYValues)
        {
            this.Histogram = new cHisto(ListXValues, ListYValues);
            UpDateDescriptorStatistics();

        }

        public void SetHistoValues(double Value)
        {
            this.Histogram = new cHisto(Value);
            // HistoValues[0] = Value;
            UpDateDescriptorStatistics();

        }

        public void SetHistoValues(int Idx, double Value)
        {
            this.Histogram.SetYvalues(Value, Idx);
            // HistoValues[Idx] = Value;
            UpDateDescriptorStatistics();

        }

        public cExtendedList GetHistovalues()
        {
            return this.Histogram.GetYvalues();
        }

        public double GetHistovalue(int Idx)
        {
            return this.Histogram.GetYvalues()[Idx];
        }

        public double GetHistoXvalue(int Idx)
        {
            return this.Histogram.GetXvalues()[Idx];
        }

        /// <summary>
        /// return the descriptor name
        /// </summary>
        /// <returns>the Descriptor name</returns>
        public string GetName()
        {
            return this.Type.GetName();
        }


        /// <summary>
        /// Update the descritpor statistic (Average, first and last value)
        /// </summary>
        public void UpDateDescriptorStatistics()
        {
            this.AverageValue = Histogram.GetAverageValue();
            //FirstValue = HistoValues[0];
            //  LastValue = HistoValues[HistoValues.Count - 1];
        }


        #endregion

        // private double AverageValue;

        //  private double FirstValue = -1;
        // private double LastValue = -1;

        private double[] OriginalValues = null;

        public double[] GetOriginalValues()
        {
            if ((CurrentScreening.GlobalInfo.CellByCellDataAccess == eCellByCellDataAccess.MEMORY) && (this.OriginalValues != null))
            {
                return this.OriginalValues;
            }
            else if (CurrentScreening.GlobalInfo.CellByCellDataAccess == eCellByCellDataAccess.HD)
            {
                AssociatedWell.AssociatedPlate.DBConnection = new cDBConnection(AssociatedWell.AssociatedPlate, AssociatedWell.SQLTableName);
                List<cDescriptorsType> LCDT = new List<cDescriptorsType>();
                LCDT.Add(this.GetAssociatedType());
                cExtendedTable ToReturn = AssociatedWell.AssociatedPlate.DBConnection.GetWellValues(AssociatedWell.SQLTableName, LCDT );
                AssociatedWell.AssociatedPlate.DBConnection.DB_CloseConnection();
                return ToReturn[0].ToArray();
            }
            return null;
        }

        //private double getAverageValue(float[] Data)
        //{
        //    double Res = 0;
        //    for (int i = 0; i < Data.Length; i++)
        //        Res += Data[i];

        //    return Res / (double)(Data.Length);
        //}

        //private cExtendedList CreateHistogram(double[] data, double start, double end, double step)
        //{
        //    int HistoSize = (int)((end - start) / step) + 1;

        //    double[] histogram = new double[HistoSize];
        //    double RealPos = start;

        //    int PosHisto;
        //    foreach (double f in data)
        //    {
        //        PosHisto = (int)((f - start) / step);
        //        if ((PosHisto >= 0) && (PosHisto < HistoSize))
        //            histogram[PosHisto]++;
        //    }

        //    return histogram;
        //}

        //private cExtendedList CreateHistogram(float[] data, double start, double end, double step)
        //{
        //    int HistoSize = (int)((end - start) / step) + 1;


        //    double[] histogram = new double[HistoSize];
        //    double RealPos = start;

        //    int PosHisto;
        //    foreach (float f in data)
        //    {
        //        PosHisto = (int)((f - start) / step);
        //        if ((PosHisto >= 0) && (PosHisto < HistoSize))
        //            histogram[PosHisto]++;
        //    }

        //    return histogram;
        //}

        //private double getAverageValue(double[] Data)
        //{
        //    double Res = 0;
        //    for (int i = 0; i < Data.Length; i++)
        //        Res += Data[i];

        //    return Res / (double)(Data.Length);
        //}




        /// <summary>
        /// Create a descriptor based on a list of value (typically an histogram)
        /// </summary>
        /// <param name="ListOriginalValues">Array of values</param>
        /// <param name="Name">Descriptor name</param>
        //public cDescriptor(double[] ListOriginalValues, cDescriptorsType Type)
        //{


        //    this.OriginalValues = new double[ListOriginalValues.Length];
        //    Array.Copy(ListOriginalValues, this.OriginalValues, OriginalValues.Length);

        //    this.Type = Type;

        //    double Max = ListOriginalValues[0];
        //    for (int i = 1; i < ListOriginalValues.Length; i++)
        //    {
        //        if (ListOriginalValues[i] > Max) Max = ListOriginalValues[i];
        //    }

        //    this.FirstValue = 0;
        //    this.LastValue = Max;

        //    HistoValues = this.CreateHistogram(ListOriginalValues, 0, Max, Type.GetBinNumber());

        //    AverageValue = getAverageValue(ListOriginalValues);
        //    //  if (HistoValues.Length == 1) IsSingle = true;
        //    // else IsSingle = false;
        //}

        /// <summary>
        /// Create a descritpor based on a single value
        /// </summary>
        /// <param name="Value">Descritpor value</param>
        /// <param name="Name">Descritpor name</param>
        public cDescriptor(double Value, cDescriptorsType Type, cScreening CurrentScreening)
        {
            this.CurrentScreening = CurrentScreening;
            this.Type = Type;
            this.Histogram = new cHisto(Value);
            this.HistoBins = 1;
            this.AverageValue = Value;
            //this.FirstValue = this.LastValue = this.AverageValue = this.HistoValues[0] = Value;

            if (CurrentScreening.GlobalInfo.CellByCellDataAccess == eCellByCellDataAccess.MEMORY)
            {
                this.OriginalValues = new double[1];
                this.OriginalValues[0] = Value;
            }
        }

        public cDescriptor(cExtendedList Values, int Bin, cDescriptorsType Type, cScreening CurrentScreening)
        {
            this.CurrentScreening = CurrentScreening;
            this.Type = Type;
            this.HistoBins = Bin;
            this.Histogram = new cHisto(Values, HistoBins);

            this.HistoBins = this.Histogram.GetXvalues().Count;
            this.AverageValue = Values.Mean();

            if (CurrentScreening.GlobalInfo.CellByCellDataAccess == eCellByCellDataAccess.MEMORY)
            {
                this.OriginalValues = new double[Values.Count];
                Array.Copy(Values.ToArray(), this.OriginalValues, this.OriginalValues.Length);
            }

            //this.FirstValue = FirstValue;
            // this.LastValue = LastValue;

            //this.HistoValues = new cExtendedList();

            //this.HistoValues.AddRange(HistoGram);

            //if (HistoGram.Length < Type.GetBinNumber())
            //{
            //    for (int i = 0; i < Type.GetBinNumber() - HistoGram.Length; i++)
            //        this.HistoValues.Add(0);
            //}


            //    new double[HistoGram.Length];
            //Array.Copy(HistoGram, this.HistoValues, HistoGram.Length);
            //this.Name = Name;
            //AverageValue = getAverageValue(HistoGram);
            //  if (HistoGram.Length == 1) IsSingle = true;
            //  else IsSingle = false;
        }

    }
}
