#region Version Header
/************************************************************************
 *		$Id: Window.cs, 177+1 2010/10/20 08:28:39 HongKee $
 *		$Description: Plugin Template for IM 3.0 $
 *		$Author: HongKee $
 *		$Date: 2010/10/20 08:28:39 $
 *		$Revision: 177+1 $
 /************************************************************************/
#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using LibPlateAnalysis;
using weka.core;
using System.IO;
using HCSAnalyzer.Forms;
using HCSAnalyzer.Controls;
using System.Reflection;
using System.Collections;
using HCSAnalyzer.Classes;
using System.Resources;
using HCSPlugin;
using HCSAnalyzer.Forms.FormsForOptions;
using HCSAnalyzer.Forms.FormsForDRCAnalysis;
using analysis;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using System.Linq;
//using Emgu.CV;
//using Emgu.CV.Structure;
//using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data.SQLite;
using HCSAnalyzer.Forms.ClusteringForms;
using System.Diagnostics;
using System.Threading.Tasks;
using HCSAnalyzer.Forms.IO;
using ImageAnalysis;
using HCSAnalyzer.Forms.FormsForGraphsDisplay.ForClassSelection;
using HCSAnalyzer.Simulator.Classes;
using HCSAnalyzer.Simulator.Forms;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using HCSAnalyzer.Classes.Machine_Learning;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions.Children;
using HCSAnalyzer.TMP_ToBeRemoved;
using HCSAnalyzer.GUI.FormsForGraphsDisplay.Generic;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using HCSAnalyzer.Classes.Base_Classes.Data;
using RDotNet;
using HCSAnalyzer.Classes.Base_Classes.DataAnalysis;
using HCSAnalyzer.Classes.Base_Classes;
using HCSAnalyzer.Classes.Base_Classes.DataProcessing;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.Base_Classes.GUI;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.DataAnalysis;
using HCSAnalyzer.Classes.General;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using HCSAnalyzer.GUI.FormsForGraphsDisplay;
//////////////////////////////////////////////////////////////////////////
// If you want to change Menu & Name of plugin
// Go to "Properties->Resources" in Solution Explorer
// Change Menu & Name
//
// You can also use your own Painter & Mouse event handler
// 
//////////////////////////////////////////////////////////////////////////
// toto
namespace HCSAnalyzer
{
    public partial class HCSAnalyzer : Form
    {
        Boolean bHaveMouse;
        static cScreening CompleteScreening;
        FormConsole MyConsole;
        PlatesListForm PlateListWindow;
        cGlobalInfo GlobalInfo;
        CheckBox checkBoxDisplayClasses = new CheckBox();
        CheckBox checkBoxApplyTo_AllPlates = new CheckBox();

        ContextMenuStrip contextMenuStripStatOptions = new ContextMenuStrip();
        ToolStripMenuItem _StatCVItem;
        ToolStripMenuItem _StatMeanItem;
        ToolStripMenuItem _StatSumItem;

        public HCSAnalyzer()
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.radioButtonDimRedUnsupervised, "Unsupervised feature selection.\nThese approaches use all the active wells as data for the dimensionality reduction.");
            toolTip1.SetToolTip(this.radioButtonDimRedSupervised, "Supervised feature selection.\nThese approaches have learning porcess based on the well classes except for the neutral class.");

            comboBoxMethodForCorrection.SelectedIndex = 0;
            comboBoxCLassificationMethod.SelectedIndex = 0;
            comboBoxNeutralClassForClassif.SelectedIndex = 2;
            comboBoxReduceDimSingleClass.SelectedIndex = 0;
            comboBoxReduceDimMultiClass.SelectedIndex = 0;
            comboBoxDimReductionNeutralClass.SelectedIndex = 2;

            comboBoxMethodForNormalization.SelectedIndex = 1;
            comboBoxNormalizationNegativeCtrl.SelectedIndex = 1;
            comboBoxNormalizationPositiveCtrl.SelectedIndex = 0;

            comboBoxRejectionNegativeCtrl.SelectedIndex = 1;
            comboBoxRejectionPositiveCtrl.SelectedIndex = 0;

            comboBoxRejection.SelectedIndex = 0;

            buttonReduceDim.Focus();
            buttonReduceDim.Select();



            //  ToolStripMenuItem UnselectItem = new ToolStripMenuItem("Options");
            //UnselectItem.Click += new System.EventHandler(this.UnselectItem);
            // contextMenuStripStatOptions.Items.Add(UnselectItem);

            // contextMenuStripStatOptions.Items.Add(new ToolStripSeparator());

            _StatMeanItem = new ToolStripMenuItem("Mean");
            _StatMeanItem.CheckOnClick = true;
            _StatMeanItem.Click += new System.EventHandler(this.StatMeanItem);
            contextMenuStripStatOptions.Items.Add(_StatMeanItem);

            _StatCVItem = new ToolStripMenuItem("Coefficient of Variation");
            _StatCVItem.CheckOnClick = true;
            _StatCVItem.CheckState = CheckState.Checked;
            _StatCVItem.Click += new System.EventHandler(this.StatCVItem);
            contextMenuStripStatOptions.Items.Add(_StatCVItem);


            _StatSumItem = new ToolStripMenuItem("Sum");
            _StatSumItem.CheckOnClick = true;
            _StatSumItem.Click += new System.EventHandler(this.StatSumItem);
            contextMenuStripStatOptions.Items.Add(_StatSumItem);


        }


        private void HCSAnalyzer_Load(object sender, EventArgs e)
        {
            GlobalInfo = new cGlobalInfo(CompleteScreening, this);

            this.comboBoxClass.Items.Add("Inactive");
            foreach (var item in GlobalInfo.ListWellClasses)
            {
                this.comboBoxClass.Items.Add(item.Name);
                //this.comboBoxClass.Items[this.comboBoxClass.Items.Count-1].
            }



            // GlobalInfo.WindowName = this.Text;
            this.Text = GlobalInfo.WindowName + " (Scalar Mode)";

            GlobalInfo.OptionsWindow.Visible = false;
            GlobalInfo.ComboForSelectedDesc = this.comboBoxDescriptorToDisplay;
            GlobalInfo.CheckedListBoxForDescActive = this.checkedListBoxActiveDescriptors;

            //new Kitware.VTK.RenderWindowControl novelRender = new RenderWindowControl

            GlobalInfo.renderWindowControlForVTK = null;//renderWindowControlForVTK;


            MyConsole = new FormConsole();
            MyConsole.Visible = false;

            PlateListWindow = new PlatesListForm();
            GlobalInfo.PlateListWindow = PlateListWindow;

            GlobalInfo.panelForPlate = this.panelForPlate;

            comboBoxClass.SelectedIndex = 1;


            // CheckBox cb = new CheckBox();
            //cb.Text = "test";
            //cb.CheckStateChanged += (s, ex) =&gt;
            //this.Text = cb.CheckState.ToString();
            //ToolStripControlHost host = new ToolStripControlHost(cb);
            //toolStrip1.Items.Insert(0,host);



            // this.toolStripMain.DataBindings.Add("Checked", this.checkBox1, "Checked");


            checkBoxDisplayClasses.Text = "Display Class";
            checkBoxDisplayClasses.Appearance = Appearance.Button;
            checkBoxDisplayClasses.FlatStyle = FlatStyle.Popup;
            checkBoxDisplayClasses.CheckedChanged += new EventHandler(checkBoxDisplayClasses_CheckedChanged);

            ToolStripControlHost host = new ToolStripControlHost(checkBoxDisplayClasses);
            toolStripMain.Items.Insert(0, host);

            checkBoxApplyTo_AllPlates.Text = "Apply to all plates";
            checkBoxApplyTo_AllPlates.Appearance = Appearance.Button;
            checkBoxApplyTo_AllPlates.FlatStyle = FlatStyle.Popup;
            checkBoxApplyTo_AllPlates.CheckedChanged += new EventHandler(checkBoxApplyTo_AllPlates_CheckedChanged);

            ToolStripControlHost hostcheckBoxApplyTo_AllPlates = new ToolStripControlHost(checkBoxApplyTo_AllPlates);
            toolStripMain.Items.Insert(5, hostcheckBoxApplyTo_AllPlates);

            // check command line arguments and process them
            if (System.Environment.GetCommandLineArgs().Length > 1)
            {
                List<string> LArg = new List<string>();
                int FileMode = 0;
                foreach (string arg in System.Environment.GetCommandLineArgs())
                {
                    if (arg.ToLower() == "-todb")
                    {
                        FileMode = 1;
                    }
                    else
                    {
                        LArg.Add(System.Environment.GetCommandLineArgs()[1]);
                    }
                }

                if (FileMode == 0)
                {
                    FormForImportExcel CSVFeedBackWindow = LoadCSVAssay(LArg.ToArray(), false);
                    if (CSVFeedBackWindow == null) return;
                    if (CSVFeedBackWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                    ProcessOK(CSVFeedBackWindow);

                    UpdateUIAfterLoading();
                    return;
                }
                else if (FileMode == 1)
                {
                    CSVtoDB(LArg[0]);

                    return;
                }


            }
        }

        void checkBoxDisplayClasses_CheckedChanged(object sender, EventArgs e)
        {
            GlobalInfo.IsDisplayClassOnly = checkBoxDisplayClasses.Checked;
            classViewToolStripMenuItem.Checked = checkBoxDisplayClasses.Checked;

            if (CompleteScreening == null) return;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);

        }

        void checkBoxApplyTo_AllPlates_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxApplyTo_AllPlates.Checked)
                this.Cursor = Cursors.Default;
            else
                this.Cursor = Cursors.Cross;
            if (CompleteScreening == null) return;
            CompleteScreening.IsSelectionApplyToAllPlates = checkBoxApplyTo_AllPlates.Checked;

        }


        #region Math Tools
        public double std(double[] input)
        {
            double var = 0f, mean = Mean(input);
            foreach (double f in input) var += (f - mean) * (f - mean);
            return Math.Sqrt(var / (double)(input.Length - 1));
        }

        public double Variance(double[] input)
        {
            double var = 0f, mean = Mean(input);
            foreach (double f in input) var += (f - mean) * (f - mean);
            return var / (double)(input.Length - 1);
        }

        public double Mean(double[] input)
        {
            double mean = 0f;
            foreach (double f in input) mean += f;
            return mean / (double)input.Length;
        }

        private double[] CreateGauss(double p, double p_2, int p_3)
        {
            double[] Gauss = new double[p_3];

            for (int x = 0; x < p_3; x++)
            {
                Gauss[x] = Math.Exp(-((x - p) * (x - p)) / (2 * p_2 * p_2));
            }

            return Gauss;
        }

        public List<double[]> CreateHistogram(double[] data, double Bin)
        {
            List<double[]> ToReturn = new List<double[]>();

            //float max = math.Max(data);
            if (data.Length == 0) return ToReturn;
            double Max = data[0];
            double Min = data[0];

            for (int Idx = 1; Idx < data.Length; Idx++)
            {
                if (data[Idx] > Max) Max = data[Idx];
                if (data[Idx] < Min) Min = data[Idx];
            }

            double step = (Max - Min) / Bin;

            int HistoSize = (int)((Max - Min) / step) + 1;
            if (HistoSize <= 0) HistoSize = 1;
            double[] axeX = new double[HistoSize];
            for (int i = 0; i < HistoSize; i++)
            {
                axeX[i] = Min + i * step;
            }
            ToReturn.Add(axeX);

            double[] histogram = new double[HistoSize];
            //double RealPos = Min;

            int PosHisto;
            foreach (double f in data)
            {
                PosHisto = (int)((f - Min) / step);
                if ((PosHisto >= 0) && (PosHisto < HistoSize))
                    histogram[PosHisto]++;
            }
            ToReturn.Add(histogram);

            return ToReturn;
        }

        public double[] MeanCenteringStdStandarization(double[] input)
        {
            double mean = Mean(input);
            double Stdev = std(input);

            double[] OutPut = new double[input.Length];

            for (int i = 0; i < input.Length; i++)
                OutPut[i] = input[i] - mean;

            for (int i = 0; i < input.Length; i++)
                OutPut[i] = OutPut[i] / Stdev;

            return OutPut;
        }

        public double Anderson_Darling(double[] tab)
        {
            double A = 0;
            double Mean1 = Mean(tab);
            double STD = std(tab);
            double[] norm = new double[tab.Length];

            for (int i = 0; i < tab.Length; i++)
                norm[i] = (tab[i] - Mean1) / STD;
            return A = Asquare(norm);
        }

        public double Asquare(double[] data)
        {
            double A = 0;
            double Mean1 = Mean(data);
            double varianceb = Math.Sqrt(2 * Variance(data));
            double err = 0;
            int cpt = 0;
            for (int i = 0; i < data.Length; i++)
            {
                cpt++;
                err += ((2 * cpt - 1) * (Math.Log(CDF(data[i], Mean1, varianceb)) + Math.Log(1 - CDF(data[data.Length - 1 - i], Mean1, varianceb))));
            }
            A = -data.Length - err / data.Length;

            return A;
        }

        public double CDF(double Y, double mu, double varb)
        {
            double Res = 0;
            Res = 0.5 * (1 + alglib.errorfunction((Y - mu) / (varb)));
            return Res;
        }


        #endregion

        #region User Interface Functions
        private void tabControlMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tabControlMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files[0].Remove(0, files[0].Length - 4) == ".csv")
                {
                    FormForImportExcel CSVFeedBackWindow = LoadCSVAssay(files, false);
                    if (CSVFeedBackWindow == null) return;
                    if (CSVFeedBackWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                    ProcessOK(CSVFeedBackWindow);

                    UpdateUIAfterLoading();
                }
            }
            return;
        }

        #region Descriptor List UI management



        private void checkedListBoxActiveDescriptors_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button != System.Windows.Forms.MouseButtons.Right) || (CompleteScreening == null)) return;

            ContextMenuStrip contextMenuStripActorPicker = new ContextMenuStrip();

            ToolStripMenuItem UnselectItem = new ToolStripMenuItem("Unselect all");
            UnselectItem.Click += new System.EventHandler(this.UnselectItem);
            contextMenuStripActorPicker.Items.Add(UnselectItem);

            ToolStripMenuItem SelectAllItem = new ToolStripMenuItem("Select all");
            SelectAllItem.Click += new System.EventHandler(this.SelectAllItem);
            contextMenuStripActorPicker.Items.Add(SelectAllItem);

            ToolStripMenuItem RemoveSelectedItem = new ToolStripMenuItem("Remove Selected Descriptors");
            RemoveSelectedItem.Click += new System.EventHandler(this.RemoveSelectedItem);
            contextMenuStripActorPicker.Items.Add(RemoveSelectedItem);

            contextMenuStripActorPicker.Items.Add(new ToolStripSeparator());

            //ToolStripMenuItem DescriptorsView = new ToolStripMenuItem("Descriptors View");
            //DescriptorsView.Click += new System.EventHandler(this.DescriptorsView);
            //contextMenuStripActorPicker.Items.Add(DescriptorsView);

            ToolStripMenuItem ToolStripGenerateMenuItems = new ToolStripMenuItem("Generate descriptor");

            ToolStripMenuItem ConcentrationToDescriptorItem = new ToolStripMenuItem("Concentration to descriptor");
            ConcentrationToDescriptorItem.Click += new System.EventHandler(this.ConcentrationToDescriptorItem);
            ToolStripGenerateMenuItems.DropDownItems.Add(ConcentrationToDescriptorItem);

            ToolStripMenuItem ColumnToDescriptorItem = new ToolStripMenuItem("Column to descriptor");
            ColumnToDescriptorItem.Click += new System.EventHandler(this.ColumnToDescriptorItem);
            ToolStripGenerateMenuItems.DropDownItems.Add(ColumnToDescriptorItem);

            ToolStripMenuItem RowToDescriptorItem = new ToolStripMenuItem("Row to descriptor");
            RowToDescriptorItem.Click += new System.EventHandler(this.RowToDescriptorItem);
            ToolStripGenerateMenuItems.DropDownItems.Add(RowToDescriptorItem);


            ToolStripMenuItem ToolStripConvertMenuItems = new ToolStripMenuItem("Operations");

            if (GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.CheckedItems.Count >= 2)
            {
                //   ToolStripSeparator ToolStripSep = new ToolStripSeparator();
                //   ToolStripConvertMenuItems.DropDownItems.Add(ToolStripSep);

                ToolStripMenuItem SumCheckedDescToDescriptorItem = new ToolStripMenuItem("Sum checked descriptors");
                SumCheckedDescToDescriptorItem.Click += new System.EventHandler(this.SumCheckedDescToDescriptorItem);
                ToolStripConvertMenuItems.DropDownItems.Add(SumCheckedDescToDescriptorItem);

                ToolStripMenuItem MultiplyCheckedDescToDescriptorItem = new ToolStripMenuItem("Multiply checked descriptors");
                MultiplyCheckedDescToDescriptorItem.Click += new System.EventHandler(this.MultiplyCheckedDescToDescriptorItem);
                ToolStripConvertMenuItems.DropDownItems.Add(MultiplyCheckedDescToDescriptorItem);

                ToolStripMenuItem GenerateLADDescriptorItem = new ToolStripMenuItem("LDA optimized descriptor");
                GenerateLADDescriptorItem.Click += new System.EventHandler(this.GenerateLADDescriptorItem);
                ToolStripConvertMenuItems.DropDownItems.Add(GenerateLADDescriptorItem);

                ToolStripSeparator NewSep = new ToolStripSeparator();
                ToolStripConvertMenuItems.DropDownItems.Add(NewSep);

                ToolStripMenuItem GeneratePCADescriptorItem = new ToolStripMenuItem("PCA projection");
                GeneratePCADescriptorItem.Click += new System.EventHandler(this.GeneratePCADescriptorItem);
                ToolStripConvertMenuItems.DropDownItems.Add(GeneratePCADescriptorItem);

                ToolStripMenuItem GenerateRandomProjectionDescriptorItem = new ToolStripMenuItem("Random projection");
                GenerateRandomProjectionDescriptorItem.Click += new System.EventHandler(this.GenerateRandomProjectionDescriptorItem);
                ToolStripConvertMenuItems.DropDownItems.Add(GenerateRandomProjectionDescriptorItem);


            }

            ToolStripSeparator SepratorStrip = new ToolStripSeparator();

            Point locationOnForm = checkedListBoxActiveDescriptors.FindForm().PointToClient(Control.MousePosition);

            int IdxItem = checkedListBoxActiveDescriptors.IndexFromPoint(e.Location);// locationOnForm.Y - 163;
            //int ItemHeight = checkedListBoxActiveDescriptors.GetItemHeight(0);
            // = VertPos / ItemHeight;
            IntToTransfer = IdxItem;

            if ((IdxItem < CompleteScreening.ListDescriptors.Count) && ((IdxItem >= 0)))
            {
                List<ToolStripMenuItem> ToolStripMenuItems = CompleteScreening.ListDescriptors[IdxItem].GetExtendedContextMenu();

                //new ToolStripMenuItem(CompleteScreening.ListDescriptors[IdxItem].GetName());

                //ToolStripMenuItem InfoDescItem = new ToolStripMenuItem("Info");
                //IntToTransfer = IdxItem;
                //InfoDescItem.Click += new System.EventHandler(this.InfoDescItem);
                //ToolStripMenuItems.DropDownItems.Add(InfoDescItem);

                //ToolStripMenuItem StackedHistoDescItem = new ToolStripMenuItem("Stacked Histo.");
                //StackedHistoDescItem.Click += new System.EventHandler(this.StackedHistoDescItem);
                //ToolStripMenuItems.DropDownItems.Add(StackedHistoDescItem);


                //if (CompleteScreening.ListDescriptors.Count >= 2)
                //{
                //    ToolStripMenuItem RemoveDescItem = new ToolStripMenuItem("Remove");
                //    RemoveDescItem.Click += new System.EventHandler(this.RemoveDescItem);
                //    ToolStripMenuItems.DropDownItems.Add(RemoveDescItem);
                //}

                if (CompleteScreening.ListDescriptors[IdxItem].GetBinNumber() > 1)
                {
                    ToolStripMenuItems[0].DropDownItems.Add(new ToolStripSeparator());

                    ToolStripMenuItem SplitDescItem = new ToolStripMenuItem("Split");
                    SplitDescItem.ToolTipText = "Split the histogram bins in individual descriptor";
                    SplitDescItem.Click += new System.EventHandler(this.SplitDescItem);
                    ToolStripMenuItems[0].DropDownItems.Add(SplitDescItem);

                    ToolStripMenuItem AverageDescItem = new ToolStripMenuItem("Average");
                    AverageDescItem.ToolTipText = "Generate a single value descriptor, resulting from the averaging of the single cell values over a defined phenotype";
                    AverageDescItem.Click += new System.EventHandler(this.AverageDescItem);
                    ToolStripMenuItems[0].DropDownItems.Add(AverageDescItem);
                }
                if (CompleteScreening.ListDescriptors[IdxItem].GetBinNumber() == 1)
                {
                    ToolStripGenerateMenuItems.DropDownItems.Add(new ToolStripSeparator());

                    ToolStripMenuItem AddCorrelatedDescItem = new ToolStripMenuItem("Generate Square");
                    AddCorrelatedDescItem.Click += new System.EventHandler(this.AddCorrelatedSquareDescItem);
                    ToolStripGenerateMenuItems.DropDownItems.Add(AddCorrelatedDescItem);

                    ToolStripMenuItem AddCorrelatedSineDescItem = new ToolStripMenuItem("Generate Sine");
                    AddCorrelatedSineDescItem.Click += new System.EventHandler(this.AddCorrelatedSineDescItem);
                    ToolStripGenerateMenuItems.DropDownItems.Add(AddCorrelatedSineDescItem);

                    ToolStripMenuItem AddCorrelatedCosineDescItem = new ToolStripMenuItem("Generate Cosine");
                    AddCorrelatedCosineDescItem.Click += new System.EventHandler(this.AddCorrelatedCosineDescItem);
                    ToolStripGenerateMenuItems.DropDownItems.Add(AddCorrelatedCosineDescItem);

                    //ToolStripMenuItem AddCorrelatedExpDescItem = new ToolStripMenuItem("Generate Exp.");
                    //AddCorrelatedExpDescItem.Click += new System.EventHandler(this.AddCorrelatedExpDescItem);
                    //ToolStripGenerateMenuItems.DropDownItems.Add(AddCorrelatedExpDescItem);

                    ToolStripGenerateMenuItems.DropDownItems.Add(new ToolStripSeparator());

                    ToolStripMenuItem DuplicateDescItem = new ToolStripMenuItem("Duplicate");
                    DuplicateDescItem.Click += new System.EventHandler(this.DuplicateDescItem);
                    ToolStripGenerateMenuItems.DropDownItems.Add(DuplicateDescItem);
                }
                if (GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.CheckedItems.Count >= 2)
                {
                    contextMenuStripActorPicker.Items.Add(ToolStripGenerateMenuItems);
                    contextMenuStripActorPicker.Items.Add(ToolStripConvertMenuItems);

                    foreach (var item in ToolStripMenuItems)
                        contextMenuStripActorPicker.Items.Add(item);
                }
                else
                {
                    contextMenuStripActorPicker.Items.Add(ToolStripGenerateMenuItems);
                    foreach (var item in ToolStripMenuItems)
                        contextMenuStripActorPicker.Items.Add(item);
                }
            }
            else
            {
                if (GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.CheckedItems.Count >= 2)
                    contextMenuStripActorPicker.Items.AddRange(new ToolStripItem[] { ToolStripGenerateMenuItems, ToolStripConvertMenuItems });
                else
                    contextMenuStripActorPicker.Items.AddRange(new ToolStripItem[] { ToolStripGenerateMenuItems });
            }
            contextMenuStripActorPicker.Show(Control.MousePosition);
        }

        static int IntToTransfer;
        //void RemoveDescItem(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.DialogResult ResWin = MessageBox.Show("By applying this process, the selected descriptor will be definitively removed from this analysis ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (ResWin == System.Windows.Forms.DialogResult.No) return;
        //    CompleteScreening.ListDescriptors.RemoveDesc(CompleteScreening.ListDescriptors[IntToTransfer], CompleteScreening);


        //    //CompleteScreening.UpDatePlateListWithFullAvailablePlate();
        //    for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
        //        CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        //    CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor, false);
        //}


        void RemoveSelectedItem(object sender, EventArgs e)
        {
            if (checkedListBoxActiveDescriptors.Items.Count == CompleteScreening.ListDescriptors.GetListNameActives().Count)
            {
                MessageBox.Show("You cannot remove all the descriptors !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            System.Windows.Forms.DialogResult ResWin = MessageBox.Show("By applying this process, the selected descriptor will be definitively removed from this analysis ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResWin == System.Windows.Forms.DialogResult.No) return;

            int NumDesc = checkedListBoxActiveDescriptors.Items.Count;
            for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
            {
                if ((CompleteScreening.ListDescriptors[i].IsActive()))
                {
                    //CompleteScreening.ListDescriptors[i].;
                    CompleteScreening.ListDescriptors.RemoveDesc(CompleteScreening.ListDescriptors[i], CompleteScreening);
                    i--;
                }
            }

            //CompleteScreening.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }



        //void InfoDescItem(object sender, EventArgs e)
        //{
        //    CompleteScreening.ListDescriptors[IntToTransfer].WindowDescriptorInfo.ShowDialog();
        //    CompleteScreening.ListDescriptors.UpDateDisplay();
        //}

        //void StackedHistoDescItem(object sender, EventArgs e)
        //{
        //    DisplayStackedHisto(IntToTransfer);
        //}


        void UnselectItem(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxActiveDescriptors.Items.Count; i++)
                CompleteScreening.ListDescriptors.SetItemState(i, false);

            RefreshInfoScreeningRichBox();

            if (GlobalInfo.ViewMode == eViewMode.PIE)
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(0, false);

        }

        void SelectAllItem(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxActiveDescriptors.Items.Count; i++)
                CompleteScreening.ListDescriptors.SetItemState(i, true);

            RefreshInfoScreeningRichBox();

            if (GlobalInfo.ViewMode == eViewMode.PIE)
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(0, false);

        }

        private void ConcentrationToDescriptorItem(object sender, EventArgs e)
        {
            cDescriptorsType ConcentrationType = new cDescriptorsType("Concentration", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ConcentrationType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Tmpwell.Concentration, ConcentrationType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void DuplicateDescItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Duplicate(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Tmpwell.ListDescriptors[IntToTransfer].GetValue(), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void AddCorrelatedCosineDescItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Cosine(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Math.Cos(Tmpwell.ListDescriptors[IntToTransfer].GetValue()), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void AddCorrelatedExpDescItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Exp(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Math.Exp(Tmpwell.ListDescriptors[IntToTransfer].GetValue()), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }
        private void AddCorrelatedSineDescItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Sine(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Math.Sin(Tmpwell.ListDescriptors[IntToTransfer].GetValue()), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void AddCorrelatedSquareDescItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Square(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Math.Pow(Tmpwell.ListDescriptors[IntToTransfer].GetValue(), 2), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void SumCheckedDescToDescriptorItem(object sender, EventArgs e)
        {
            string NewName = "";

            for (int Idx = 0; Idx < CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count; Idx++)
            {

                if (CompleteScreening.ListDescriptors[Idx].IsActive())
                    if (CompleteScreening.ListDescriptors[Idx].GetBinNumber() == 1)
                    {
                        NewName += CompleteScreening.ListDescriptors[Idx].GetName() + "+";
                    }
                    else
                    {
                        MessageBox.Show("Descriptor length not consistent (" + CompleteScreening.ListDescriptors[Idx].GetName() + " : " + CompleteScreening.ListDescriptors[Idx].GetBinNumber() + " bins", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            }
            cDescriptorsType ColumnType = new cDescriptorsType(NewName.Remove(NewName.Length - 1), true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    double NewValue = 0;

                    for (int IdxActiveDesc = 0; IdxActiveDesc < CompleteScreening.ListDescriptors.Count - 1; IdxActiveDesc++)
                    {
                        if (CompleteScreening.ListDescriptors[IdxActiveDesc].IsActive())
                            NewValue += Tmpwell.ListDescriptors[IdxActiveDesc].GetValue();
                    }
                    cDescriptor NewDesc = new cDescriptor(NewValue, ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);

                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }


        private void GenerateLADDescriptorItem(object sender, EventArgs e)
        {
            FormForProjections WindowClassification = new FormForProjections(CompleteScreening);
            //WindowClassification.buttonClassification.Text = "Process";
            WindowClassification.label1.Text = "Neutral Class";
            WindowClassification.Text = "LDA";
            WindowClassification.IsPCA = false;
            WindowClassification.numericUpDownNumberOfAxis.Visible = false;
            WindowClassification.labelAxeNumber.Visible = false;

            PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true, eClassType.WELL);
            ClassSelectionPanel.Height = WindowClassification.panelForClasses.Height;
            ClassSelectionPanel.UnSelectAll();
            ClassSelectionPanel.Select(0);
            ClassSelectionPanel.Select(1);
            WindowClassification.panelForClasses.Controls.Add(ClassSelectionPanel);

            cExtendPlateList PlatesToProcess = new cExtendPlateList();
            if (WindowClassification.radioButtonFromCurrentPlate.Checked)
                PlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            else
                PlatesToProcess = CompleteScreening.ListPlatesActive;
            WindowClassification.PlatesToProcess = PlatesToProcess;

            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

        }

        private void GeneratePCADescriptorItem(object sender, EventArgs e)
        {
            FormForProjections WindowClassification = new FormForProjections(CompleteScreening);
            //WindowClassification.buttonClassification.Text = "Process";
            WindowClassification.label1.Text = "Class of Interest";
            WindowClassification.Text = "PCA";
            WindowClassification.IsPCA = true;
            WindowClassification.numericUpDownNumberOfAxis.Maximum = CompleteScreening.GetNumberOfActiveDescriptor();

            PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true, eClassType.WELL);
            ClassSelectionPanel.Height = WindowClassification.panelForClasses.Height;
            ClassSelectionPanel.UnSelectAll();
            ClassSelectionPanel.Select(2);
            WindowClassification.panelForClasses.Controls.Add(ClassSelectionPanel);



            cExtendPlateList PlatesToProcess = new cExtendPlateList();
            if (WindowClassification.radioButtonFromCurrentPlate.Checked)
                PlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            else
                PlatesToProcess = CompleteScreening.ListPlatesActive;

            WindowClassification.PlatesToProcess = PlatesToProcess;
            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
        }

        private void GenerateRandomProjectionDescriptorItem(object sender, EventArgs e)
        {
            FormForProjections WindowClassification = new FormForProjections(CompleteScreening);
            //WindowClassification.buttonClassification.Text = "Process";
            WindowClassification.label1.Text = "Class of Interest";
            WindowClassification.Text = "Random Projection";
            WindowClassification.IsPCA = true;
            WindowClassification.numericUpDownNumberOfAxis.Maximum = CompleteScreening.GetNumberOfActiveDescriptor();

            cExtendPlateList PlatesToProcess = new cExtendPlateList();
            if (WindowClassification.radioButtonFromCurrentPlate.Checked)
                PlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            else
                PlatesToProcess = CompleteScreening.ListPlatesActive;

            WindowClassification.PlatesToProcess = PlatesToProcess;
            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
        }


        private void MultiplyCheckedDescToDescriptorItem(object sender, EventArgs e)
        {
            string NewName = "";

            for (int Idx = 0; Idx < CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count; Idx++)
            {

                if (CompleteScreening.ListDescriptors[Idx].IsActive())
                    if (CompleteScreening.ListDescriptors[Idx].GetBinNumber() == 1)
                    {
                        NewName += CompleteScreening.ListDescriptors[Idx].GetName() + "*";
                    }
                    else
                    {
                        MessageBox.Show("Descriptor length not consistent (" + CompleteScreening.ListDescriptors[Idx].GetName() + " : " + CompleteScreening.ListDescriptors[Idx].GetBinNumber() + " bins", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            }
            cDescriptorsType ColumnType = new cDescriptorsType(NewName.Remove(NewName.Length - 1), true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    double NewValue = 1;

                    for (int IdxActiveDesc = 0; IdxActiveDesc < CompleteScreening.ListDescriptors.Count - 1; IdxActiveDesc++)
                    {
                        if (CompleteScreening.ListDescriptors[IdxActiveDesc].IsActive())
                            NewValue *= Tmpwell.ListDescriptors[IdxActiveDesc].GetValue();
                    }
                    cDescriptor NewDesc = new cDescriptor(NewValue, ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);

                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void ColumnToDescriptorItem(object sender, EventArgs e)
        {
            cDescriptorsType ColumnType = new cDescriptorsType("Column", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Tmpwell.GetPosX(), ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void RowToDescriptorItem(object sender, EventArgs e)
        {
            cDescriptorsType RowType = new cDescriptorsType("Row", true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(RowType);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    cDescriptor NewDesc = new cDescriptor(Tmpwell.GetPosY(), RowType, CompleteScreening);
                    LDesc.Add(NewDesc);

                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void SplitDescItem(object sender, EventArgs e)
        {
            int NumBin = CompleteScreening.ListDescriptors[IntToTransfer].GetBinNumber();

            // first we update the descriptor
            for (int i = 0; i < NumBin; i++)
                CompleteScreening.ListDescriptors.AddNew(new cDescriptorsType(CompleteScreening.ListDescriptors[IntToTransfer].GetName() + "_" + i, true, 1, GlobalInfo));

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();
                    for (int i = 0; i < NumBin; i++)
                    {
                        cDescriptor NewDesc = new cDescriptor(Tmpwell.ListDescriptors[IntToTransfer].GetHistovalue(i), CompleteScreening.ListDescriptors[i + IntToTransfer + 1], CompleteScreening);
                        LDesc.Add(NewDesc);
                    }
                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void AverageDescItem(object sender, EventArgs e)
        {
            //int NumBin = CompleteScreening.ListDescriptors[IntToTransfer].GetBinNumber();





            // first we update the descriptor

            cGUI_ListClasses GUILC = new cGUI_ListClasses();
            GUILC.ClassType = eClassType.PHENOTYPE;
            GUILC.IsSelectAll = true;
            GUILC.Run(GlobalInfo);
            //GUILC.
            // return;


            List<cCellularPhenotype> LCP = new List<cCellularPhenotype>();
            for (int IdxPheno = 0; IdxPheno < GUILC.GetOutPut().Count; IdxPheno++)
            {
                if (GUILC.GetOutPut()[IdxPheno] == 1)
                    LCP.Add(GlobalInfo.ListCellularPhenotypes[IdxPheno]);
            }
            if (LCP.Count == 0) return;

            string description = "This descriptor has been generated using the following phenotypic sub-populations:\n";
            foreach (var item in LCP)
            {
                description += item.Name + "\n";
            }

            cDescriptorsType NewAverageType = new cDescriptorsType("Average(" + CompleteScreening.ListDescriptors[IntToTransfer].GetName() + ")", true, 1, GlobalInfo, description);
            CompleteScreening.ListDescriptors.AddNew(NewAverageType);

            FormForProgress ProgressWindow = new FormForProgress();
            ProgressWindow.Show();

            int IdxProgress = 0;
            int MaxProgress = 0;

            foreach (cPlate CurrentPlateToProcess in GlobalInfo.CurrentScreen.ListPlatesAvailable)
                MaxProgress += (int)CurrentPlateToProcess.ListActiveWells.Count;
            ProgressWindow.progressBar.Maximum = MaxProgress;

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    TmpPlate.DBConnection = new cDBConnection(TmpPlate, Tmpwell.SQLTableName);
                    List<cDescriptorsType> LDT = new List<cDescriptorsType>();
                    LDT.Add(CompleteScreening.ListDescriptors[IntToTransfer]);

                    cExtendedTable CT = TmpPlate.DBConnection.GetWellValues(Tmpwell, LDT, LCP);
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    double Value = 0;
                    if (CT.Count == 1)
                        Value = CT[0].Average();

                    cDescriptor NewDesc = new cDescriptor(Value, NewAverageType, CompleteScreening);
                    LDesc.Add(NewDesc);
                    Tmpwell.AddDescriptors(LDesc);
                    TmpPlate.DBConnection.DB_CloseConnection();

                    ProgressWindow.progressBar.Value = IdxProgress++;
                }
            }
            ProgressWindow.Close();


            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }


        #endregion

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GlobalInfo.CurrentRichTextBox.Clear();
        }

        private void buttonClearConsole_Click(object sender, EventArgs e)
        {
            GlobalInfo.CurrentRichTextBox.Clear();
        }


        //private void distributionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DisplayHistogram(false);
        //}



        /// <summary>
        /// Change the slection mode (global or local)
        /// </summary>
        /// <param name="OnlyOnSelected">True: single plate selection; False: entiere screen selection</param>
        private void GlobalSelection(bool OnlyOnSelected)
        {
            if (CompleteScreening == null) return;

            if (CompleteScreening.GetSelectionType() <= -2) return;

            for (int col = 0; col < CompleteScreening.Columns; col++)
                for (int row = 0; row < CompleteScreening.Rows; row++)
                {

                    if (CompleteScreening.IsSelectionApplyToAllPlates)
                    {
                        int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

                        for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                        {
                            cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx);
                            cWell TmpWell = CurrentPlateToProcess.GetWell(col, row, OnlyOnSelected);
                            if (TmpWell == null) continue;

                            if (CompleteScreening.GetSelectionType() == -1)
                                TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());
                        }
                    }
                    else
                    {
                        cWell TmpWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(col, row, OnlyOnSelected);
                        if (TmpWell != null)
                        {
                            if (CompleteScreening.GetSelectionType() == -1) TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());


                        }
                    }
                }

            CompleteScreening.GetCurrentDisplayPlate().UpdateNumberOfClass();
        }


        /// <summary>
        /// Manage the event related to the active plate selection combo list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripcomboBoxPlateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompleteScreening.CurrentDisplayPlateIdx = this.toolStripcomboBoxPlateList.SelectedIndex;

            if (CompleteScreening.CurrentDisplayPlateIdx == -1) return;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        /// <summary>
        /// Manage the event related to Class selection control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.SetSelectionType(comboBoxClass.SelectedIndex - 1);

            if (comboBoxClass.SelectedIndex >= 1)
                comboBoxClass.BackColor = GlobalInfo.ListWellClasses[comboBoxClass.SelectedIndex - 1].ColourForDisplay;
            CompleteScreening.GetCurrentDisplayPlate().UpdateNumberOfClass();
        }

        /// <summary>
        /// set all the well of the current plate to "unselected" mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int col = 0; col < CompleteScreening.Columns; col++)
                for (int row = 0; row < CompleteScreening.Rows; row++)
                {
                    cWell TmpWell = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.CurrentDisplayPlateIdx).GetWell(col, row, false);
                    if (TmpWell != null) TmpWell.SetAsNoneSelected();
                }
        }

        private void checkedListBoxDescriptorActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompleteScreening.CurrentDisplayPlateIdx == -1) return;


            for (int idxDesc = 0; idxDesc < CompleteScreening.ListDescriptors.Count; idxDesc++)
                CompleteScreening.ListDescriptors[idxDesc].SetActiveState(false);

            for (int IdxDesc = 0; IdxDesc < checkedListBoxActiveDescriptors.CheckedItems.Count; IdxDesc++)
                CompleteScreening.ListDescriptors[checkedListBoxActiveDescriptors.CheckedIndices[IdxDesc]].SetActiveState(true);

            RefreshInfoScreeningRichBox();


            if (GlobalInfo.ViewMode == eViewMode.PIE)
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(0, false);

            return;
        }

        private void comboBoxDescriptorToDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx = (int)comboBoxDescriptorToDisplay.SelectedIndex;

            if ((!checkBoxDisplayClasses.Checked) && (GlobalInfo.ViewMode != eViewMode.PIE))
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);

            //ToolTip ToolTipFor1 = new ToolTip();
            //ToolTipFor1.AutoPopDelay = 5000;
            //ToolTipFor1.InitialDelay = 500;
            //ToolTipFor1.ReshowDelay = 500;
            //ToolTipFor1.ShowAlways = true;
            //ToolTipFor1.SetToolTip(comboBoxDescriptorToDisplay, comboBoxDescriptorToDisplay.Text);

        }

        private void StartingUpDateUI()
        {
            MyConsole = new FormConsole();

            GlobalInfo.CurrentRichTextBox = this.MyConsole.richTextBoxConsole;
            CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx = 0;
            CompleteScreening.CurrentDisplayPlateIdx = 0;
            GlobalInfo.LabelForClass = this.labelNumClasses;
            CompleteScreening.LabelForMin = this.labelMin;
            CompleteScreening.LabelForMax = this.labelMax;
            CompleteScreening.PanelForLUT = this.panelForLUT;
            CompleteScreening.PanelForPlate = this.panelForPlate;

            // CompleteScreening.ListDescriptors = new cListDescriptors(this.checkedListBoxActiveDescriptors, comboBoxDescriptorToDisplay);

            PlateListWindow.listBoxPlateNameToProcess.Items.Clear();
            PlateListWindow.listBoxAvaliableListPlates.Items.Clear();

            // CompleteScreening.ListBoxSelectedPlates = PlateListWindow.listBoxPlateNameToProcess;
            this.toolStripcomboBoxPlateList.Items.Clear();

            CompleteScreening.IsSelectionApplyToAllPlates = checkBoxApplyTo_AllPlates.Checked;
            GlobalInfo.CurrentScreen = CompleteScreening;
        }

        private void panelForLUT_Paint(object sender, PaintEventArgs e)
        {
            if ((CompleteScreening == null) || (CompleteScreening.ListPlatesAvailable.Count == 0) || (CompleteScreening.ISLoading))
                return;

            CompleteScreening.GetCurrentDisplayPlate().DisplayLUT(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx);
        }

        private void dataGridViewForQualityControl_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) || (e.RowIndex == -1)) return;
            String PlateName = (string)dataGridViewForQualityControl.Rows[e.RowIndex].Cells[0].Value;
            String DescName = (string)dataGridViewForQualityControl.Rows[e.RowIndex].Cells[1].Value;
            //  tabControlMain.SelectedTab = tabPageDistribution;

            int PosPlate = this.toolStripcomboBoxPlateList.FindStringExact(PlateName);
            this.toolStripcomboBoxPlateList.SelectedIndex = PosPlate;
            CompleteScreening.CurrentDisplayPlateIdx = this.toolStripcomboBoxPlateList.SelectedIndex;

            int PosDesc = this.comboBoxDescriptorToDisplay.FindStringExact(DescName);
            comboBoxDescriptorToDisplay.SelectedIndex = PosDesc;
            CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx = (int)comboBoxDescriptorToDisplay.SelectedIndex;

            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void comboBoxDimReductionNeutralClass_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush BrushForColor = new SolidBrush(GlobalInfo.ListWellClasses[e.Index].ColourForDisplay);
            e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            e.Graphics.DrawString(comboBoxDimReductionNeutralClass.Items[e.Index].ToString(), comboBoxDimReductionNeutralClass.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void comboBoxNeutralClassForClassif_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush BrushForColor = new SolidBrush(GlobalInfo.ListWellClasses[e.Index].ColourForDisplay);
            e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            e.Graphics.DrawString(comboBoxNeutralClassForClassif.Items[e.Index].ToString(), comboBoxNeutralClassForClassif.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void panelForPlate_Paint(object sender, PaintEventArgs e)
        {
            if ((CompleteScreening == null) || (CompleteScreening.ListPlatesAvailable.Count == 0) || (CompleteScreening.ISLoading))
                return;

            float SizeFont = GlobalInfo.SizeHistoHeight / 2;
            int Gutter = (int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value;
            Graphics g = CompleteScreening.PanelForPlate.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(CompleteScreening.PanelForPlate.BackColor);
            int ScrollShiftY = this.panelForPlate.VerticalScroll.Value;
            int ScrollShiftX = this.panelForPlate.HorizontalScroll.Value;

            for (int i = 1; i <= CompleteScreening.Columns; i++)
                g.DrawString(i.ToString(), new Font("Arial", SizeFont), Brushes.White, new PointF((GlobalInfo.SizeHistoWidth + Gutter) * (i - 1) + (GlobalInfo.SizeHistoWidth + Gutter) / 4
                    - (i.ToString().Length - 1) * (GlobalInfo.SizeHistoWidth + Gutter) / 8 + GlobalInfo.ShiftX - ScrollShiftX, -ScrollShiftY));

            for (int j = 1; j <= CompleteScreening.Rows; j++)
            {
                if (GlobalInfo.OptionsWindow.radioButtonWellPosModeDouble.Checked)
                    g.DrawString(j.ToString(), new Font("Arial", SizeFont), Brushes.White, new PointF(-ScrollShiftX, (GlobalInfo.SizeHistoHeight + Gutter) * (j - 1) + GlobalInfo.ShiftY - ScrollShiftY));
                else
                    g.DrawString(GlobalInfo.ConvertIntPosToStringPos(j), new Font("Arial", SizeFont), Brushes.White, new PointF(-ScrollShiftX, (GlobalInfo.SizeHistoHeight + Gutter) * (j - 1) + GlobalInfo.ShiftY - ScrollShiftY));
            }
        }

        private void UpdateUIAfterLoading()
        {
            if (comboBoxDescriptorToDisplay.Items.Count >= 1)
            {
                pluginsToolStripMenuItem.Enabled = true;
                exportToolStripMenuItem.Enabled = true;
                appendDescriptorsToolStripMenuItem.Enabled = true;
                //linkToolStripMenuItem.Enabled = true;
                copyAverageValuesToolStripMenuItem1.Enabled = true;
                copyClassesToolStripMenuItem.Enabled = true;
                swapClassesToolStripMenuItem.Enabled = true;
                applySelectionToScreenToolStripMenuItem.Enabled = true;
                visualizationToolStripMenuItem.Enabled = true;
                StatisticsToolStripMenuItem.Enabled = true;
                hitIdentificationToolStripMenuItem.Enabled = true;
                buttonReduceDim.Enabled = true;
                visualizationToolStripMenuItemFullScreen.Enabled = true;
                qualityControlToolStripMenuItem.Enabled = true;
                buttonQualityControl.Enabled = true;
                buttonCorrectionPlateByPlate.Enabled = true;
                buttonRejectPlates.Enabled = true;
                buttonNormalize.Enabled = true;
                ButtonClustering.Enabled = true;
                buttonStartClassification.Enabled = true;
                buttonExport.Enabled = true;
                buttonDisplayWellsSelectionData.Enabled = true;
                platesManagerToolStripMenuItem.Enabled = true;
                betaToolStripMenuItem.Enabled = true;
                toolStripMenuItemGeneAnalysis.Enabled = true;
                viewToolStripMenuItem.Enabled = true;

                CompleteScreening.ISLoading = false;
                comboBoxDescriptorToDisplay.SelectedIndex = 0;
                string NamePlate = PlateListWindow.listBoxAvaliableListPlates.Items[0].ToString();
                toolStripcomboBoxPlateList.Text = NamePlate + " ";

                if (checkBoxDisplayClasses.Checked)
                    CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);

            }
        }

        public void RefreshInfoScreeningRichBox()
        {
            if (tabControlMain.SelectedTab.Name != "tabPageExport") return;
            richTextBoxForScreeningInformation.Clear();

            if (CompleteScreening == null) return;

            string TmpText = "Plate dimensions: " + CompleteScreening.Columns + " x " + CompleteScreening.Rows + "\n\n\n";
            richTextBoxForScreeningInformation.AppendText(TmpText);

            TmpText = "Number of plates: " + CompleteScreening.ListPlatesActive.Count + " (/ " + CompleteScreening.ListPlatesAvailable.Count + ")\n\n";
            int TotalWells = 0;
            for (int PlateIdx = 1; PlateIdx <= CompleteScreening.ListPlatesActive.Count; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx - 1);
                TmpText += "Plate " + PlateIdx + " :\t" + CurrentPlateToProcess.Name + "\n";
                TmpText += "\t" + CurrentPlateToProcess.GetNumberOfActiveWells() + " active wells / " + CurrentPlateToProcess.GetNumberOfClasses() + " classes.\n";
                TotalWells += CurrentPlateToProcess.GetNumberOfActiveWells();
            }
            richTextBoxForScreeningInformation.AppendText(TmpText + "\n");

            TmpText = "Number of active wells: " + TotalWells;
            richTextBoxForScreeningInformation.AppendText(TmpText + "\n\n");

            TmpText = "Number of active descriptors: " + CompleteScreening.GetNumberOfActiveDescriptor() + " (/ " + CompleteScreening.ListDescriptors.Count + ")\n\n";
            for (int Desc = 1; Desc <= CompleteScreening.ListDescriptors.Count; Desc++)
            {
                if (CompleteScreening.ListDescriptors[Desc - 1].IsActive() == false) continue;
                TmpText += "Descriptor " + Desc + " :\t" + CompleteScreening.ListDescriptors[Desc - 1].GetName() + "\n";
            }
            richTextBoxForScreeningInformation.AppendText(TmpText + "\n");

            int[] ListClass = CompleteScreening.GetClassPopulation();

            TmpText = "List Classes:\n\n";
            for (int IdxClass = 0; IdxClass < ListClass.Length; IdxClass++)
            {
                TmpText += GlobalInfo.ListWellClasses[IdxClass].Name;
                double Percent = (100 * ListClass[IdxClass]) / (double)TotalWells;
                TmpText += " : " + ListClass[IdxClass] + "\t <=>\t " + Percent.ToString("N3") + " %\n";

            }
            richTextBoxForScreeningInformation.AppendText(TmpText + "\n");

        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInfoScreeningRichBox();
            RefreshSingleCellAnalysis();
            //  RefreshClustering();
        }

        //void RefreshClustering()
        //{
        //    if (tabControlMain.SelectedTab.Name == "tabPageClassification")
        //    {
        //        panelForClassSelectionClustering.Controls.Clear();
        //        PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo);
        //        ClassSelectionPanel.Height = panelForClassSelectionClustering.Height;
        //        ClassSelectionPanel.UnSelectAll();
        //        panelForClassSelectionClustering.Controls.Add(ClassSelectionPanel);
        //    }

        //}

        void RefreshSingleCellAnalysis()
        {
            if (tabControlMain.SelectedTab.Name == "tabPageSingleCellAnalysis")
            {
                PanelForMultipleClassesSelection.Controls.Clear();
                PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true, eClassType.WELL);
                ClassSelectionPanel.Height = PanelForMultipleClassesSelection.Height;
                ClassSelectionPanel.UnSelectAll();
                PanelForMultipleClassesSelection.Controls.Add(ClassSelectionPanel);
            }

        }


        // Convert and normalize the points and draw the reversible frame.
        private void MyDrawReversibleRectangle(Point p1, Point p2)
        {
            Rectangle rc = new Rectangle();

            // Convert the points to screen coordinates.
            p1 = PointToScreen(p1);
            //p1.X += tabControlMain.Location.X;
            //p1.Y += tabControlMain.Location.Y;

            p2 = PointToScreen(p2);
            //p2.X += tabControlMain.Location.X;
            //p2.Y += tabControlMain.Location.Y;

            // Normalize the rectangle.
            if (p1.X < p2.X)
            {
                rc.X = p1.X;
                rc.Width = p2.X - p1.X;
            }
            else
            {
                rc.X = p2.X;
                rc.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rc.Y = p1.Y;
                rc.Height = p2.Y - p1.Y;
            }
            else
            {
                rc.Y = p2.Y;
                rc.Height = p1.Y - p2.Y;
            }
            // Draw the reversible frame.

            ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Dashed);
        }

        private void panelForPlate_MouseDown(object sender, MouseEventArgs e)
        {
            if (CompleteScreening == null) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CompleteScreening.ClientPosFirst.X = e.X;
                CompleteScreening.ClientPosFirst.Y = e.Y;

                //     if (GlobalInfo.WindowForDRCDesign.Visible) return;
                Point locationOnForm = this.panelForPlate.FindForm().PointToClient(Control.MousePosition);
                // int VertPos = locationOnForm.Y - 163;
                // Make a note that we "have the mouse".
                bHaveMouse = true;

                // Store the "starting point" for this rubber-band rectangle.
                CompleteScreening.ptOriginal.X = locationOnForm.X;// e.X + this.panelForPlate.Location.X/* + 10*/;
                CompleteScreening.ptOriginal.Y = locationOnForm.Y;// e.Y + this.panelForPlate.Location.Y/* + 76*/;
                // Special value lets us know that no previous
                // rectangle needs to be erased.
                CompleteScreening.ptLast.X = -1;
                CompleteScreening.ptLast.Y = -1;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int ScrollShiftY = this.panelForPlate.VerticalScroll.Value;
                int ScrollShiftX = this.panelForPlate.HorizontalScroll.Value;
                int Gutter = (int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value;

                int PosX = (int)((e.X - ScrollShiftX) / (GlobalInfo.SizeHistoWidth + Gutter));
                int PosY = (int)((e.Y - ScrollShiftY) / (GlobalInfo.SizeHistoHeight + Gutter));

                bool OnlyOnSelected = false;

                cExtendedList cExL = new cExtendedList();
                List<string> Names = new List<string>();
                string CurrentName = "";

                #region Display plate heat map
                if ((PosX == 0) && (PosY == 0))
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                        if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

                    cDesignerTab DT = new cDesignerTab();

                    for (int IdxDesc = 0; IdxDesc < CompleteScreening.ListDescriptors.Count; IdxDesc++)
                    {
                        if (!CompleteScreening.ListDescriptors[IdxDesc].IsActive()) continue;

                        bool IsMissing;

                        cExtendedTable NewTable = null;
                        if (!checkBoxDisplayClasses.Checked)
                            NewTable = new cExtendedTable(CompleteScreening.GetCurrentDisplayPlate().GetAverageValueDescTable(IdxDesc, out IsMissing));
                        else
                            NewTable = new cExtendedTable(CompleteScreening.GetCurrentDisplayPlate().GetWellClassesTable());

                        foreach (var item in NewTable)
                            item.ListTags = new List<object>();

                        for (int i = 0; i < CompleteScreening.Columns; i++)
                            for (int j = 0; j < CompleteScreening.Rows; j++)
                            {
                                cWell currentWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(i, CompleteScreening.Rows - j - 1, true);
                                NewTable[j].ListTags.Add(currentWell);
                            }

                        for (int IdxCol = 0; IdxCol < NewTable.Count; IdxCol++)
                            NewTable[IdxCol].Name = "Column " + (IdxCol + 1);

                        List<string> ListRow = new List<string>();
                        for (int IdxRow = 0; IdxRow < NewTable[0].Count; IdxRow++)
                            ListRow.Add("Row " + (NewTable[0].Count - IdxRow));

                        NewTable.ListRowNames = ListRow;
                        if (!checkBoxDisplayClasses.Checked)
                            NewTable.Name = CompleteScreening.ListDescriptors[IdxDesc].GetName() + " (" + ListWellsToProcess.Count + " wells)";
                        else
                            NewTable.Name = CompleteScreening.GetCurrentDisplayPlate().Name + " - Well Associated Classes (" + ListWellsToProcess.Count + " wells)";

                        cViewerHeatMap VHM = new cViewerHeatMap();
                        VHM.SetInputData(NewTable);
                        VHM.GlobalInfo = GlobalInfo;
                        VHM.IsDisplayValues = false;
                        if (!checkBoxDisplayClasses.Checked)
                            VHM.Title = CompleteScreening.ListDescriptors[IdxDesc].GetName() + " (" + ListWellsToProcess.Count + " wells)";
                        else
                        {
                            //VHM.ChartToBeIncluded
                            VHM.CurrentLUT = GlobalInfo.ListWellClasses.BuildLUT();
                            VHM.IsAutomatedMinMax = false;
                            VHM.Min = 0;
                            VHM.Max = GlobalInfo.ListWellClasses.Count - 1;
                            VHM.IsWellClassLegend = true;
                            VHM.Title = CompleteScreening.GetCurrentDisplayPlate().Name + " - Well Associated Classes (" + ListWellsToProcess.Count + " wells)";
                        }
                        VHM.Run();

                        DT.SetInputData(VHM.GetOutPut());

                        if (checkBoxDisplayClasses.Checked) break;

                    }

                    DT.Run();

                    cDisplayToWindow DWForPlate = new cDisplayToWindow();
                    DWForPlate.SetInputData(DT.GetOutPut());
                    DWForPlate.Run();
                    DWForPlate.Display();
                    return;
                }
                #endregion
                #region Display column or row graphs
                else if ((PosX == 0) && (PosY > 0))
                {
                    cExL.ListTags = new List<object>();
                    for (int col = 0; col < CompleteScreening.Columns; col++)
                    {
                        cPlate CurrentPlateToProcess = CompleteScreening.GetCurrentDisplayPlate();
                        cWell TmpWell = CurrentPlateToProcess.GetWell(col, PosY - 1, OnlyOnSelected);
                        if (TmpWell == null) continue;
                        cExL.ListTags.Add(TmpWell);
                        cExL.Add(TmpWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                        Names.Add("Column " + col);
                    }
                    CurrentName = "Row " + PosY;
                }
                else if ((PosY == 0) && (PosX > 0))
                {
                    cExL.ListTags = new List<object>();
                    for (int row = 0; row < CompleteScreening.Rows; row++)
                    {
                        cPlate CurrentPlateToProcess = CompleteScreening.GetCurrentDisplayPlate();
                        cWell TmpWell = CurrentPlateToProcess.GetWell(PosX - 1, row, OnlyOnSelected);
                        if (TmpWell == null) continue;
                        cExL.ListTags.Add(TmpWell);

                        cExL.Add(TmpWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                        Names.Add("Row " + row);
                    }
                    CurrentName = "Column " + PosX;
                }
                #endregion
                else
                {
                    ContextMenuStrip NewMenu = new ContextMenuStrip();
                    NewMenu.Items.Add(CompleteScreening.GetCurrentDisplayPlate().GetExtendedContextMenu());
                    NewMenu.Show(Control.MousePosition);
                    return;
                }

                cExtendedTable cExT = new cExtendedTable(cExL);
                cExT.ListRowNames = Names;

                cExT.Name = CurrentName;
                cExT[0].Name = CurrentName;


                cViewerGraph1D CV = new cViewerGraph1D();
                CV.Chart.IsSelectable = true;
                CV.Chart.LabelAxisX = "Well Index";
                CV.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                //V1D.Chart.BackgroundColor = Color.LightYellow;
                CV.Chart.IsXAxis = true;
                CV.Chart.IsLine = true;
                CV.SetInputData(cExT);

                cFeedBackMessage Mess = CV.Run();
                if (!Mess.IsSucceed)
                {
                    MessageBox.Show(Mess.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //cViewerGraph CV = new cViewerGraph();
                //CV.SetInputData(cExT);
                //CV.Run();

                cDesignerSinglePanel CD = new cDesignerSinglePanel();
                CD.SetInputData(CV.GetOutPut());
                CD.Run();

                cDisplayToWindow DW = new cDisplayToWindow();
                DW.SetInputData(CD.GetOutPut());
                DW.Run();
                DW.Display();
                // CV.Display();
            }
        }

        private void panelForPlate_MouseMove(object sender, MouseEventArgs e)
        {
            if (CompleteScreening == null) return;

            //  if (GlobalInfo.WindowForDRCDesign.Visible) return;


            // If we "have the mouse", then we draw our lines.
            if (bHaveMouse)
            {
                Point ptCurrent = this.panelForPlate.FindForm().PointToClient(Control.MousePosition);
                // Point ptCurrent = new Point(e.X + this.panelForPlate.Location.X /*+ 10*/, e.Y + this.panelForPlate.Location.Y /*+ 76*/);
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (CompleteScreening.ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(CompleteScreening.ptOriginal, CompleteScreening.ptLast);
                }
                // Update last point.
                CompleteScreening.ptLast = ptCurrent;
                // Draw new lines.
                MyDrawReversibleRectangle(CompleteScreening.ptOriginal, ptCurrent);
            }
        }

        private void panelForPlate_MouseUp(object sender, MouseEventArgs e)
        {
            if (CompleteScreening == null) return;

            //  if (GlobalInfo.WindowForDRCDesign.Visible) return;

            // Set internal flag to know we no longer "have the mouse".
            bHaveMouse = false;
            // If we have drawn previously, draw again in that spot
            // to remove the lines.
            if (CompleteScreening.ptLast.X != -1)
            {
                Point ptCurrent = this.panelForPlate.FindForm().PointToClient(Control.MousePosition);
                //Point ptCurrent = new Point(e.X + panelForPlate.Location.X /*+ 10*/, e.Y + panelForPlate.Location.Y /*+ 76*/);
                MyDrawReversibleRectangle(CompleteScreening.ptOriginal, CompleteScreening.ptLast);


                CompleteScreening.ClientPosLast.X = e.X;
                CompleteScreening.ClientPosLast.Y = e.Y;

                if (!GlobalInfo.WindowForDRCDesign.Visible)
                {
                    CompleteScreening.GetCurrentDisplayPlate().UpDateWellsSelection();
                    CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
                }
                else
                {
                    int SelectionType = CompleteScreening.GetSelectionType();
                    if (SelectionType == -2) return;

                    int PosMouseXMax = CompleteScreening.ClientPosLast.X;
                    int PosMouseXMin = CompleteScreening.ClientPosFirst.X;

                    if (CompleteScreening.ClientPosFirst.X > PosMouseXMax)
                    {
                        PosMouseXMax = CompleteScreening.ClientPosFirst.X;
                        PosMouseXMin = CompleteScreening.ClientPosLast.X;
                    }

                    int PosMouseYMax = CompleteScreening.ClientPosLast.Y;
                    int PosMouseYMin = CompleteScreening.ClientPosFirst.Y;
                    if (CompleteScreening.ClientPosFirst.Y > PosMouseYMax)
                    {
                        PosMouseYMax = CompleteScreening.ClientPosFirst.Y;
                        PosMouseYMin = CompleteScreening.ClientPosLast.Y;
                    }

                    int GutterSize = (int)CompleteScreening.GlobalInfo.OptionsWindow.numericUpDownGutter.Value;
                    int ScrollShiftX = CompleteScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.HorizontalScroll.Value;
                    int ScrollShiftY = CompleteScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.VerticalScroll.Value;

                    int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

                    //Point ResMin = ParentScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.GetChildAtPoint(new Point(PosMouseXMin, PosMouseYMin));

                    int PosWellMinX = (int)((PosMouseXMin - ScrollShiftX) / (CompleteScreening.GlobalInfo.SizeHistoWidth + GutterSize));
                    int PosWellMinY = (int)((PosMouseYMin - ScrollShiftY) / (CompleteScreening.GlobalInfo.SizeHistoHeight + GutterSize));

                    int PosWellMaxX = (int)((PosMouseXMax - ScrollShiftX) / (CompleteScreening.GlobalInfo.SizeHistoWidth + GutterSize));
                    int PosWellMaxY = (int)((PosMouseYMax - ScrollShiftY) / (CompleteScreening.GlobalInfo.SizeHistoHeight + GutterSize));


                    if (PosWellMaxX > CompleteScreening.Columns) PosWellMaxX = CompleteScreening.Columns;
                    if (PosWellMaxY > CompleteScreening.Rows) PosWellMaxY = CompleteScreening.Rows;
                    if (PosWellMinX < 0) PosWellMinX = 0;
                    if (PosWellMinY < 0) PosWellMinY = 0;

                    GlobalInfo.WindowForDRCDesign.ListWells = new List<cWell>();

                    for (int j = PosWellMinY; j < PosWellMaxY; j++)
                        for (int i = PosWellMinX; i < PosWellMaxX; i++)
                        {

                            cWell TempWell = CompleteScreening.ListPlatesActive[CompleteScreening.CurrentDisplayPlateIdx].GetWell(i, j, false);

                            GlobalInfo.WindowForDRCDesign.ListWells.Add(TempWell);

                            //if (TempWell == null) continue;
                            //   TempWell.SetClass(SelectionType);
                        }


                    //int PosMouseXMax = CompleteScreening.ptLast.X;
                    //int PosMouseXMin = CompleteScreening.ptOriginal.X;
                    //if (CompleteScreening.ptOriginal.X > PosMouseXMax)
                    //{
                    //    PosMouseXMax = CompleteScreening.ptOriginal.X;
                    //    PosMouseXMin = CompleteScreening.ptLast.X;
                    //}

                    //int PosMouseYMax = CompleteScreening.ptLast.Y;
                    //int PosMouseYMin = CompleteScreening.ptOriginal.Y;
                    //if (CompleteScreening.ptOriginal.Y > PosMouseYMax)
                    //{
                    //    PosMouseYMax = CompleteScreening.ptOriginal.Y;
                    //    PosMouseYMin = CompleteScreening.ptLast.Y;
                    //}

                    ////List<cWell> ListWellSelected = new List<cWell>();
                    //GlobalInfo.WindowForDRCDesign.ListWells = new List<cWell>();


                    //for (int j = 0; j < CompleteScreening.Rows; j++)
                    //    for (int i = 0; i < CompleteScreening.Columns; i++)
                    //    {
                    //        cWell TempWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(i, j, false);
                    //        if (TempWell == null) continue;
                    //        //    int PWellX = (int)((TempWell.GetPosX() + 1) * (CompleteScreening.GlobalInfo.SizeHistoWidth + (int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value));// - 2*ParentScreening.GlobalInfo.ShiftX);
                    //        //   int PWellY = (int)((TempWell.GetPosY() + 1) * (CompleteScreening.GlobalInfo.SizeHistoHeight + (int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value) + +(int)((int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value * 2.5) );// (int)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownShiftY.Value);

                    //        //   if ((PWellX > PosMouseXMin) && (PWellX < PosMouseXMax) && (PWellY > PosMouseYMin) && (PWellY < PosMouseYMax))
                    //        {
                    //            GlobalInfo.WindowForDRCDesign.ListWells.Add(TempWell);
                    //        }
                    //    }

                    GlobalInfo.WindowForDRCDesign.DrawSignature();
                }


                //    if (CompleteScreening.GlobalInfo.IsDisplayClassOnly)

            }
            // Set flags to know that there is no "previous" line to reverse.
            CompleteScreening.ptLast.X = -1;
            CompleteScreening.ptLast.Y = -1;
            CompleteScreening.ptOriginal.X = -1;
            CompleteScreening.ptOriginal.Y = -1;
        }

        private void panelForPlate_MouseWheel(object sender, MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.
            if (CompleteScreening == null) return;

            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (numberOfTextLinesToMove > 0)
                CompleteScreening.GlobalInfo.ChangeSize(numberOfTextLinesToMove);
            else
                CompleteScreening.GlobalInfo.ChangeSize(1.0f / (-1 * numberOfTextLinesToMove));

            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }
        #endregion

        #region Selection management
        private void applySelectionToScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.ApplyCurrentClassesToAllPlates();
        }

        private void swapClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            FormForSwapClasses WindowSwapClasses = new FormForSwapClasses(GlobalInfo);

            PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true, eClassType.WELL);
            ClassSelectionPanel.Height = WindowSwapClasses.panelToBeSwapped.Height;
            //ClassSelectionPanel.Location.Y = ClassSelectionPanel.Location.Y+ 20;
            ClassSelectionPanel.UnSelectAll();
            WindowSwapClasses.panelToBeSwapped.Controls.Add(ClassSelectionPanel);

            if (WindowSwapClasses.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int Idx = 0;
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;


            // int OriginalIdx = WindowSwapClasses.comboBoxOriginalClass.SelectedIndex - 1;
            int DestinatonIdx = WindowSwapClasses.comboBoxDestinationClass.SelectedIndex - 1;

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx);

                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlateToProcess.GetWell(IdxValue, IdxValue0, false);
                        if (TmpWell == null) continue;

                        if ((TmpWell.GetClassIdx() > -1) && (ClassSelectionPanel.GetListSelectedClass()[TmpWell.GetClassIdx()]))
                        {
                            if (DestinatonIdx == -1)
                                TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(DestinatonIdx);

                            Idx++;
                        }

                    }
            }
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
            MessageBox.Show(Idx + " wells have been swapped !", "Process over !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion

        #region Scatter point graphs section
        //private void scatterPointsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (CompleteScreening == null) return;
        //    Series CurrentSeries = new Series("ScatterPoints");
        //    CurrentSeries.ShadowOffset = 1;

        //    int Idx = 0;
        //    int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

        //    // loop on all the plate
        //    for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
        //    {
        //        cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

        //        for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
        //            for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
        //            {
        //                cWell TmpWell = CurrentPlateToProcess.GetWell(IdxValue, IdxValue0, true);
        //                if (TmpWell == null) continue;
        //                CurrentSeries.Points.Add(TmpWell.ListDescriptors[comboBoxDescriptorToDisplay.SelectedIndex].GetValue());
        //                CurrentSeries.Points[Idx].Color = TmpWell.GetClassColor();
        //                CurrentSeries.Points[Idx].MarkerStyle = MarkerStyle.Circle;
        //                CurrentSeries.Points[Idx].MarkerSize = 6;
        //                if (!GlobalInfo.OptionsWindow.checkBoxDisplayFastPerformance.Checked) CurrentSeries.Points[Idx].ToolTip = TmpWell.AssociatedPlate.Name + "\n" + TmpWell.GetPosX() + "x" + TmpWell.GetPosY() + " :" + TmpWell.Name;
        //                Idx++;
        //            }
        //    }

        //    SimpleForm NewWindow = new SimpleForm(CompleteScreening);

        //    if (Idx > (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value)
        //        NewWindow.Width = (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value;
        //    else
        //        NewWindow.Width = Idx;
        //    NewWindow.Height = 400;

        //    ChartArea CurrentChartArea = new ChartArea();
        //    CurrentChartArea.BorderColor = Color.Black;
        //    CurrentChartArea.CursorX.IsUserSelectionEnabled = true;
        //    NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

        //    NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        //    CurrentChartArea.BackColor = Color.FromArgb(164, 164, 164);

        //    CurrentChartArea.Axes[1].Title = CompleteScreening.ListDescriptors[comboBoxDescriptorToDisplay.SelectedIndex].GetName();
        //    CurrentChartArea.Axes[0].Title = "Index";
        //    CurrentChartArea.Axes[0].MajorGrid.Enabled = false;

        //    CurrentSeries.ChartType = SeriesChartType.Point;
        //    if (GlobalInfo.OptionsWindow.checkBoxDisplayFastPerformance.Checked) CurrentSeries.ChartType = SeriesChartType.FastPoint;

        //    NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);

        //    double Av = NewWindow.chartForSimpleForm.DataManipulator.Statistics.Mean("ScatterPoints");
        //    double Std = Math.Sqrt(NewWindow.chartForSimpleForm.DataManipulator.Statistics.Variance("ScatterPoints", true));

        //    StripLine StdLine = new StripLine();
        //    StdLine.BackColor = Color.FromArgb(64, Color.BlanchedAlmond);
        //    StdLine.IntervalOffset = Av - 1.5 * Std;
        //    StdLine.StripWidth = 3 * Std;

        //    CurrentChartArea.AxisY.StripLines.Add(StdLine);

        //    StripLine AverageLine = new StripLine();
        //    AverageLine.BackColor = Color.Red;
        //    AverageLine.IntervalOffset = Av;
        //    AverageLine.StripWidth = 0.0001;
        //    AverageLine.Text = Av.ToString("N2");
        //    CurrentChartArea.AxisY.StripLines.Add(AverageLine);

        //    NewWindow.Text = "Scatter Point / " + Idx + " points";
        //    NewWindow.Show();
        //    NewWindow.chartForSimpleForm.Update();
        //    NewWindow.chartForSimpleForm.Show();
        //    NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
        //    return;
        //}

        private void scatterPointsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cFeedBackMessage MessageReturned;

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            cViewerGraph1D V1D = new cViewerGraph1D();
            V1D.Chart.IsSelectable = true;
            V1D.Chart.LabelAxisX = "Well Index";
            V1D.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            //V1D.Chart.BackgroundColor = Color.LightYellow;
            V1D.Chart.IsXAxis = true;

            if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                cExtendedTable DataFromPlate = new cExtendedTable(CompleteScreening.GetCurrentDisplayPlate().ListActiveWells,
                                                CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, ListClassSelected);

                DataFromPlate.Name = CompleteScreening.GetCurrentDisplayPlate().Name;

                V1D.Chart.IsShadow = true;
                V1D.Chart.IsBorder = true;
                V1D.Chart.IsSelectable = true;
                V1D.Chart.CurrentTitle.Tag = CompleteScreening.GetCurrentDisplayPlate();
                V1D.SetInputData(DataFromPlate);
                V1D.Run();

                cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
                Designer0.SetInputData(V1D.GetOutPut());
                Designer0.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(Designer0.GetOutPut());
                Disp0.Title = "Scatter points graph - " + DataFromPlate[0].Count + " wells.";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();
            }
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                V1D.Chart.MarkerSize = 5;
                V1D.Chart.IsBorder = false;

                List<cWell> ListWell = new List<cWell>();
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    foreach (cWell TmpWell in TmpPlate.ListActiveWells)
                        ListWell.Add(TmpWell);

                cExtendedTable DataFromPlate = new cExtendedTable(ListWell,
                                                CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, ListClassSelected);

                DataFromPlate.Name = CompleteScreening.Name + " - " + CompleteScreening.ListPlatesActive.Count + " plates";

                V1D.SetInputData(DataFromPlate);
                V1D.Run();

                cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
                Designer0.SetInputData(V1D.GetOutPut());
                Designer0.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(Designer0.GetOutPut());
                Disp0.Title = "Scatter points graph - " + DataFromPlate[0].Count + " wells.";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();

            }
            else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab CDT = new cDesignerTab();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    cExtendedTable DataFromPlate = new cExtendedTable(TmpPlate.ListActiveWells,
                                                CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, ListClassSelected);

                    DataFromPlate.Name = TmpPlate.Name;

                    V1D = new cViewerGraph1D();
                    V1D.Chart.IsSelectable = true;
                    V1D.Chart.LabelAxisX = "Well Index";
                    V1D.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                    V1D.Chart.BackgroundColor = Color.LightYellow;
                    V1D.Chart.IsXAxis = true;
                    V1D.Chart.CurrentTitle.Tag = TmpPlate;
                    V1D.SetInputData(DataFromPlate);
                    V1D.Title = TmpPlate.Name;
                    V1D.Run();

                    CDT.SetInputData(V1D.GetOutPut());
                }

                CDT.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(CDT.GetOutPut());
                Disp0.Title = "Scatter points graphs";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();
            }


            //if (CurrentSeries.Points.Count < 2)
            //{
            //    MessageBox.Show("Statistical Analyses - More than one data point needed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;

            //}



            //StripLine AverageLine = new StripLine();
            //AverageLine.BackColor = Color.Red;
            //AverageLine.IntervalOffset = Av;
            //AverageLine.StripWidth = 0.01;
            //AverageLine.Text = String.Format("{0:0.###}", Av);
            //CurrentChartArea.AxisY.StripLines.Add(AverageLine);


        }
        #endregion

        #region Options window
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInfo.OptionsWindow.CurrentScreen = CompleteScreening;
            GlobalInfo.OptionsWindow.Visible = !GlobalInfo.OptionsWindow.Visible;
            GlobalInfo.OptionsWindow.Update();
        }

        #endregion

        #region Misc menus (console, plates manager, exit, about)
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyConsole.Visible = !MyConsole.Visible;
            MyConsole.Update();
        }

        private void platesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            PlateListWindow.listBoxPlateNameToProcess.Items.Clear();
            for (int i = 0; i < CompleteScreening.ListPlatesActive.Count; i++)
                PlateListWindow.listBoxPlateNameToProcess.Items.Add(CompleteScreening.ListPlatesActive[i].Name);


            PlateListWindow.ShowDialog();// != System.Windows.Forms.DialogResult.OK) return; 

            while (PlateListWindow.listBoxPlateNameToProcess.Items.Count == 0)
            {
                MessageBox.Show("At least one plate has to bo selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PlateListWindow.ShowDialog();// != System.Windows.Forms.DialogResult.OK) return; 
            }
            toolStripcomboBoxPlateList.Items.Clear();
            CompleteScreening.ListPlatesActive.Clear();
            RefreshInfoScreeningRichBox();

            for (int i = 0; i < PlateListWindow.listBoxPlateNameToProcess.Items.Count; i++)
            {
                CompleteScreening.ListPlatesActive.Add(CompleteScreening.ListPlatesAvailable.GetPlate((string)PlateListWindow.listBoxPlateNameToProcess.Items[i]));
                toolStripcomboBoxPlateList.Items.Add(CompleteScreening.ListPlatesActive[i].Name);
            }
            CompleteScreening.CurrentDisplayPlateIdx = 0;
            toolStripcomboBoxPlateList.SelectedIndex = 0;

            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.CurrentScreen != null)
                GlobalInfo.CurrentScreen.Close3DView();
            this.Dispose();
        }

        private void aboutHCSAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();
            About.Text = "HCS Analyzer";
            //About.Opacity = 0.9;
            About.ShowDialog();
        }
        #endregion

        #region Quality controls - Zfactor, SSMD, Coeff. of variation, descriptor evolution

        /// <summary>
        /// This function displays the evolution of the average value of a certain descriptor through the plates, for a specified class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descriptorEvolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            FormClassification WindowClassification = new FormClassification(CompleteScreening);
            WindowClassification.label1.Text = "Class";
            WindowClassification.Text = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " evolution";
            WindowClassification.buttonClassification.Text = "Display";

            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            int SelectedClass = WindowClassification.comboBoxForNeutralClass.SelectedIndex;
            cExtendedList ListValuePerWell = new cExtendedList();
            List<cDescriptor> List_Averages = new List<cDescriptor>();

            cWell TempWell;
            int Desc = this.comboBoxDescriptorToDisplay.SelectedIndex;

            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            Series CurrentSeries = new Series();
            CurrentSeries.Name = "Series1";

            CurrentSeries.ChartType = SeriesChartType.ErrorBar;
            CurrentSeries.ShadowOffset = 1;

            Series SeriesLine = new Series();
            SeriesLine.Name = "SeriesLine";
            SeriesLine.ShadowOffset = 1;
            SeriesLine.ChartType = SeriesChartType.Line;

            int RealPlateIdx = 0;

            // loop on all the plates
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);
                ListValuePerWell.Clear();

                for (int row = 0; row < CompleteScreening.Rows; row++)
                    for (int col = 0; col < CompleteScreening.Columns; col++)
                    {
                        TempWell = CurrentPlateToProcess.GetWell(col, row, true);
                        if (TempWell == null) continue;
                        else
                        {
                            if (TempWell.GetClassIdx() == SelectedClass)
                            {
                                double Val = TempWell.ListDescriptors[Desc].GetValue();
                                if (double.IsNaN(Val)) continue;

                                ListValuePerWell.Add(Val);
                            }
                        }
                    }

                if (ListValuePerWell.Count >= 1)
                {
                    DataPoint CurrentPt = new DataPoint();
                    CurrentPt.XValue = RealPlateIdx;

                    double[] Values = new double[3];
                    Values[0] = ListValuePerWell.Mean();
                    double Std = ListValuePerWell.Std();
                    if (double.IsInfinity(Std) || (double.IsNaN(Std))) Std = 0;
                    Values[1] = Values[0] - Std;
                    Values[2] = Values[0] + Std;
                    CurrentPt.YValues = Values;//ListValuePerWell.ToArray();
                    CurrentSeries.Points.Add(CurrentPt);

                    CurrentSeries.Points[RealPlateIdx].AxisLabel = CurrentPlateToProcess.Name;
                    CurrentSeries.Points[RealPlateIdx].Font = new Font("Arial", 8);
                    CurrentSeries.Points[RealPlateIdx].Color = CompleteScreening.GlobalInfo.ListWellClasses[SelectedClass].ColourForDisplay;

                    SeriesLine.Points.AddXY(RealPlateIdx, Values[0]);

                    SeriesLine.Points[RealPlateIdx].ToolTip = "Plate name: " + CurrentPlateToProcess.Name + "\nAverage: " + string.Format("{0:0.###}", Values[0]) + "\nStdev: " + string.Format("{0:0.###}", Std);
                    SeriesLine.Points[RealPlateIdx].Font = new Font("Arial", 8);
                    SeriesLine.Points[RealPlateIdx].BorderColor = Color.Black;
                    SeriesLine.Points[RealPlateIdx].MarkerStyle = MarkerStyle.Circle;
                    SeriesLine.Points[RealPlateIdx].MarkerSize = 8;

                    RealPlateIdx++;
                }
            }

            SimpleForm NewWindow = new SimpleForm(CompleteScreening);
            int thisWidth = 200 * SeriesLine.Points.Count;
            if (thisWidth > 1500) thisWidth = 1500;
            NewWindow.Width = thisWidth;
            NewWindow.Height = 400;

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;
            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            CurrentChartArea.AxisX.Interval = 1;
            CurrentChartArea.Axes[1].IsMarksNextToAxis = true;
            CurrentChartArea.Axes[1].Title = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            CurrentChartArea.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            CurrentChartArea.BackSecondaryColor = Color.White;

            CurrentSeries["BoxPlotWhiskerPercentile"] = "false";
            CurrentSeries["BoxPlotShowMedian"] = "false";
            CurrentSeries["BoxPlotWhiskerPercentile"] = "false";
            CurrentSeries["BoxPlotShowAverage"] = "false";
            CurrentSeries["BoxPlotPercentile"] = "false";


            CurrentChartArea.AxisX.IsLabelAutoFit = true;
            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);
            NewWindow.chartForSimpleForm.Series.Add(SeriesLine);

            Title CurrentTitle = new Title("Class " + SelectedClass + " " + CurrentChartArea.Axes[1].Title + " evolution");

            NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);
            NewWindow.chartForSimpleForm.Titles[0].Font = new Font("Arial", 9);
            NewWindow.Show();
            NewWindow.chartForSimpleForm.Update();
            NewWindow.chartForSimpleForm.Show();
            NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
            return;
        }

        //private void zscoreToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    if (CompleteScreening == null) return;

        //    BuildZFactor(this.comboBoxDescriptorToDisplay.SelectedIndex).Show();
        //}



        private SimpleForm BuildZFactor(int Desc)
        {
            List<double> Pos = new List<double>();
            List<double> Neg = new List<double>();
            List<cSimpleSignature> ZFactorList = new List<cSimpleSignature>();

            cWell TempWell;
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

                Pos.Clear();
                Neg.Clear();


                for (int row = 0; row < CompleteScreening.Rows; row++)
                    for (int col = 0; col < CompleteScreening.Columns; col++)
                    {
                        TempWell = CurrentPlateToProcess.GetWell(col, row, true);
                        if (TempWell == null) continue;
                        else
                        {
                            if (TempWell.GetClassIdx() == 0)
                                Pos.Add(TempWell.ListDescriptors[Desc].GetValue());
                            if (TempWell.GetClassIdx() == 1)
                                Neg.Add(TempWell.ListDescriptors[Desc].GetValue());
                        }
                    }

                double ZScore = 1 - 3 * (std(Pos.ToArray()) + std(Neg.ToArray())) / (Math.Abs(Mean(Pos.ToArray()) - Mean(Neg.ToArray())));
                GlobalInfo.ConsoleWriteLine(CurrentPlateToProcess.Name + ", Z-Score = " + ZScore);
                cSimpleSignature TmpDesc = new cSimpleSignature(CurrentPlateToProcess.Name, ZScore);
                ZFactorList.Add(TmpDesc);
            }

            Series CurrentSeries = new Series();
            CurrentSeries.ChartType = SeriesChartType.Column;
            CurrentSeries.ShadowOffset = 1;

            Series SeriesLine = new Series();
            SeriesLine.Name = "SeriesLine";
            SeriesLine.ShadowOffset = 1;
            SeriesLine.ChartType = SeriesChartType.Line;

            int RealIdx = 0;
            for (int IdxValue = 0; IdxValue < ZFactorList.Count; IdxValue++)
            {
                if (ZFactorList[IdxValue].AverageValue.ToString() == "NaN") continue;

                CurrentSeries.Points.Add(ZFactorList[IdxValue].AverageValue);
                CurrentSeries.Points[RealIdx].Label = string.Format("{0:0.###}", ZFactorList[IdxValue].AverageValue);
                CurrentSeries.Points[RealIdx].Font = new Font("Arial", 10);
                CurrentSeries.Points[RealIdx].ToolTip = ZFactorList[IdxValue].Name;
                CurrentSeries.Points[RealIdx].AxisLabel = ZFactorList[IdxValue].Name;

                SeriesLine.Points.Add(ZFactorList[IdxValue].AverageValue);
                SeriesLine.Points[RealIdx].BorderColor = Color.Black;
                SeriesLine.Points[RealIdx].MarkerStyle = MarkerStyle.Circle;
                SeriesLine.Points[RealIdx].MarkerSize = 4;
                RealIdx++;
            }

            SimpleForm NewWindow = new SimpleForm();
            int thisWidth = 200 * RealIdx;
            if (thisWidth > (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value)
                thisWidth = (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value;
            NewWindow.Width = thisWidth;
            NewWindow.Height = 400;
            NewWindow.Text = "Z-factors";

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;
            CurrentChartArea.AxisX.Interval = 1;
            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);
            NewWindow.chartForSimpleForm.Series.Add(SeriesLine);

            CurrentChartArea.AxisX.IsLabelAutoFit = true;
            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            CurrentChartArea.Axes[1].Maximum = 1.1;
            CurrentChartArea.Axes[1].IsMarksNextToAxis = true;
            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            CurrentChartArea.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            CurrentChartArea.BackSecondaryColor = Color.White;

            Title CurrentTitle = new Title(CompleteScreening.ListDescriptors[Desc].GetName() + " Z-factors");
            CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);

            return NewWindow;
        }

        private void sSMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            BuildSSMD(this.comboBoxDescriptorToDisplay.SelectedIndex).Show();
        }


        private class cSimpleSignature
        {
            public cSimpleSignature(string Name, double Value)
            {
                this.Name = Name;
                this.AverageValue = Value;

            }


            public string Name;
            public double AverageValue;

        }

        private SimpleForm BuildSSMD(int Desc)
        {
            List<double> Pos = new List<double>();
            List<double> Neg = new List<double>();
            List<cSimpleSignature> ZFactorList = new List<cSimpleSignature>();

            cWell TempWell;
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

                Pos.Clear();
                Neg.Clear();

                for (int row = 0; row < CompleteScreening.Rows; row++)
                    for (int col = 0; col < CompleteScreening.Columns; col++)
                    {
                        TempWell = CurrentPlateToProcess.GetWell(col, row, true);
                        if (TempWell == null) continue;
                        else
                        {
                            if (TempWell.GetClassIdx() == 0)
                                Pos.Add(TempWell.ListDescriptors[Desc].GetValue());
                            if (TempWell.GetClassIdx() == 1)
                                Neg.Add(TempWell.ListDescriptors[Desc].GetValue());
                        }
                    }

                double SSMDScore = (Mean(Pos.ToArray()) - Mean(Neg.ToArray())) / Math.Sqrt(std(Pos.ToArray()) * std(Pos.ToArray()) + std(Neg.ToArray()) * std(Neg.ToArray()));
                GlobalInfo.ConsoleWriteLine(CurrentPlateToProcess.Name + ", SSMD = " + SSMDScore);

                //cDescriptor TmpDesc = new cDescriptor(SSMDScore, CurrentPlateToProcess.Name);
                cSimpleSignature TmpDesc = new cSimpleSignature(CurrentPlateToProcess.Name, SSMDScore);
                ZFactorList.Add(TmpDesc);
            }

            Series CurrentSeries = new Series();
            CurrentSeries.ChartType = SeriesChartType.Column;
            CurrentSeries.ShadowOffset = 1;

            Series SeriesLine = new Series();
            SeriesLine.Name = "SeriesLine";
            SeriesLine.ShadowOffset = 1;
            SeriesLine.ChartType = SeriesChartType.Line;

            int RealIdx = 0;
            for (int IdxValue = 0; IdxValue < ZFactorList.Count; IdxValue++)
            {
                if (ZFactorList[IdxValue].AverageValue.ToString() == "NaN") continue;

                CurrentSeries.Points.Add(ZFactorList[IdxValue].AverageValue);
                CurrentSeries.Points[RealIdx].Label = string.Format("{0:0.###}", ZFactorList[IdxValue].AverageValue);
                CurrentSeries.Points[RealIdx].Font = new Font("Arial", 10);
                CurrentSeries.Points[RealIdx].ToolTip = ZFactorList[IdxValue].Name;
                CurrentSeries.Points[RealIdx].AxisLabel = ZFactorList[IdxValue].Name;

                SeriesLine.Points.Add(ZFactorList[IdxValue].AverageValue);
                SeriesLine.Points[RealIdx].BorderColor = Color.Black;
                SeriesLine.Points[RealIdx].MarkerStyle = MarkerStyle.Circle;
                SeriesLine.Points[RealIdx].MarkerSize = 4;
                RealIdx++;
            }

            SimpleForm NewWindow = new SimpleForm();
            int thisWidth = 200 * RealIdx;
            if (thisWidth > (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value)
                thisWidth = (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value;
            NewWindow.Width = thisWidth;
            NewWindow.Height = 400;
            NewWindow.Text = "SSMD";

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;
            CurrentChartArea.AxisX.Interval = 1;
            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);
            NewWindow.chartForSimpleForm.Series.Add(SeriesLine);

            CurrentChartArea.AxisX.IsLabelAutoFit = true;
            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            // CurrentChartArea.Axes[1].Maximum = 2;
            CurrentChartArea.Axes[1].IsMarksNextToAxis = true;
            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            CurrentChartArea.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            CurrentChartArea.BackSecondaryColor = Color.White;

            Title CurrentTitle = new Title(CompleteScreening.ListDescriptors[Desc].GetName() + " SSMD");
            CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);

            return NewWindow;
        }


        #endregion

        #region Histograms section

        //private void stackedHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (CompleteScreening == null) return;
        //    if ((CompleteScreening.ListDescriptors == null) || (CompleteScreening.ListDescriptors.Count == 0)) return;
        //    DisplayStackedHisto(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor);
        //}

        //public void DisplayStackedHisto(int IdxDesc)
        //{
        //    FormForMultipleClassSelection WindowForClassSelection = new FormForMultipleClassSelection();
        //    PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, true);
        //    ClassSelectionPanel.Height = WindowForClassSelection.splitContainerForClassSelection.Panel1.Height;
        //    WindowForClassSelection.splitContainerForClassSelection.Panel1.Controls.Add(ClassSelectionPanel);

        //    if (WindowForClassSelection.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
        //    //     WindowForClassSelection.panelForClassesSelection = new 

        //    cExtendedList[] ListValuesForHisto = new cExtendedList[/*ClassSelectionPanel.GetListIndexSelectedClass().Count*/ GlobalInfo.GetNumberofDefinedWellClass()];

        //    List<bool> ListSelectedClass = ClassSelectionPanel.GetListSelectedClass();

        //    for (int i = 0; i < ListValuesForHisto.Length; i++)
        //        ListValuesForHisto[i] = new cExtendedList();

        //    cWell TempWell;

        //    int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

        //    double MinValue = double.MaxValue;
        //    double MaxValue = double.MinValue;
        //    double CurrentValue;

        //    // loop on all the plate
        //    for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
        //    {
        //        cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

        //        for (int row = 0; row < CompleteScreening.Rows; row++)
        //            for (int col = 0; col < CompleteScreening.Columns; col++)
        //            {
        //                TempWell = CurrentPlateToProcess.GetWell(col, row, false);
        //                if (TempWell == null) continue;
        //                else
        //                {
        //                    if (TempWell.GetClassIdx() >= 0)
        //                    {
        //                        CurrentValue = TempWell.ListDescriptors[IdxDesc].GetValue();
        //                        ListValuesForHisto[TempWell.GetClassIdx()].Add(CurrentValue);
        //                        if (CurrentValue < MinValue) MinValue = CurrentValue;
        //                        if (CurrentValue > MaxValue) MaxValue = CurrentValue;
        //                    }
        //                }
        //            }
        //    }
        //    SimpleForm NewWindow = new SimpleForm();
        //    List<double[]>[] HistoPos = new List<double[]>[ListValuesForHisto.Length];
        //    Series[] SeriesPos = new Series[ListValuesForHisto.Length];


        //    for (int i = 0; i < ListValuesForHisto.Length; i++)
        //    {
        //        HistoPos[i] = new List<double[]>();
        //        if (ListSelectedClass[i])
        //            HistoPos[i] = ListValuesForHisto[i].CreateHistogram(MinValue, MaxValue, (int)GlobalInfo.OptionsWindow.numericUpDownHistoBin.Value);

        //        SeriesPos[i] = new Series();
        //    }

        //    for (int i = 0; i < SeriesPos.Length; i++)
        //    {
        //        int Max = 0;
        //        if (HistoPos[i].Count > 0)
        //            Max = HistoPos[i][0].Length;

        //        for (int IdxValue = 0; IdxValue < Max; IdxValue++)
        //        {
        //            SeriesPos[i].Points.AddXY(MinValue + ((MaxValue - MinValue) * IdxValue) / Max, HistoPos[i][1][IdxValue]);
        //            SeriesPos[i].Points[IdxValue].ToolTip = HistoPos[i][1][IdxValue].ToString();
        //            if (CompleteScreening.SelectedClass == -1)
        //                SeriesPos[i].Points[IdxValue].Color = Color.Black;
        //            else
        //                SeriesPos[i].Points[IdxValue].Color = CompleteScreening.GlobalInfo.ListWellClasses[i].ColourForDisplay;
        //        }
        //    }
        //    ChartArea CurrentChartArea = new ChartArea();
        //    CurrentChartArea.BorderColor = Color.Black;

        //    NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
        //    CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
        //    CurrentChartArea.Axes[0].Title = CompleteScreening.ListDescriptors[IdxDesc].GetName();
        //    CurrentChartArea.Axes[1].Title = "Sum";
        //    CurrentChartArea.AxisX.LabelStyle.Format = "N2";

        //    NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        //    CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
        //    CurrentChartArea.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
        //    CurrentChartArea.BackSecondaryColor = Color.White;


        //    for (int i = 0; i < SeriesPos.Length; i++)
        //    {
        //        SeriesPos[i].ChartType = SeriesChartType.StackedColumn;
        //        // SeriesPos[i].Color = CompleteScreening.GlobalInfo.GetColor(1);
        //        if (ListSelectedClass[i])
        //            NewWindow.chartForSimpleForm.Series.Add(SeriesPos[i]);
        //    }
        //    //Series SeriesGaussNeg = new Series();
        //    //SeriesGaussNeg.ChartType = SeriesChartType.Spline;

        //    //Series SeriesGaussPos = new Series();
        //    //SeriesGaussPos.ChartType = SeriesChartType.Spline;

        //    //if (HistoPos.Count != 0)
        //    //{
        //    //    double[] HistoGaussPos = CreateGauss(Mean(Pos.ToArray()), std(Pos.ToArray()), HistoPos[0].Length);

        //    //    SeriesGaussPos.Color = Color.Black;
        //    //    SeriesGaussPos.BorderWidth = 2;
        //    //}
        //    //SeriesGaussNeg.Color = Color.Black;
        //    //SeriesGaussNeg.BorderWidth = 2;

        //    //NewWindow.chartForSimpleForm.Series.Add(SeriesGaussNeg);
        //    //NewWindow.chartForSimpleForm.Series.Add(SeriesGaussPos);
        //    NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserEnabled = true;
        //    NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        //    NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        //    NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

        //    Title CurrentTitle = null;

        //    CurrentTitle = new Title(CompleteScreening.ListDescriptors[IdxDesc].GetName() + " Stacked histogram.");

        //    CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
        //    NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);
        //    NewWindow.Text = CurrentTitle.Text;
        //    NewWindow.Show();
        //    NewWindow.chartForSimpleForm.Update();
        //    NewWindow.chartForSimpleForm.Show();
        //    NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
        //    return;
        //}
        #endregion

        #region PCA


        //private void pCAToolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    ComputeAndDisplayPCA(CompleteScreening.ListPlatesActive);
        //}

        //private void ComputeAndDisplayPCA(cExtendPlateList PlatesToProcess)
        //{
        //    if (CompleteScreening == null) return;
        //    FormClassification WindowClassification = new FormClassification(CompleteScreening);
        //    WindowClassification.label1.Text = "Class of interest";
        //    WindowClassification.Text = "PCA";
        //    WindowClassification.buttonClassification.Text = "Process";

        //    if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

        //    int NeutralClass = WindowClassification.comboBoxForNeutralClass.SelectedIndex;

        //    int NumWell = 0;
        //    int NumWellForLearning = 0;
        //    foreach (cPlate CurrentPlate in PlatesToProcess)
        //    {
        //        foreach (cWell CurrentWell in CurrentPlate.ListActiveWells)
        //        {
        //            if (CurrentWell.GetClassIdx() == NeutralClass)
        //                NumWellForLearning++;
        //        }
        //        NumWell += CurrentPlate.GetNumberOfActiveWells();
        //    }

        //    if (NumWellForLearning == 0)
        //    {
        //        MessageBox.Show("No well of the selected class identified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    int NumDesc = CompleteScreening.GetNumberOfActiveDescriptor();

        //    if (NumDesc <= 1)
        //    {
        //        MessageBox.Show("More than one descriptor are required for this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    double[,] DataForPCA = new double[NumWellForLearning, CompleteScreening.GetNumberOfActiveDescriptor() + 1];

        //    //   return;
        //    Matrix EigenVectors = PCAComputation(DataForPCA, NumWellForLearning, NumDesc, NeutralClass, PlatesToProcess);
        //    if (EigenVectors == null) return;

        //    SimpleForm NewWindow = new SimpleForm(CompleteScreening);
        //    Series CurrentSeries = new Series();
        //    CurrentSeries.ShadowOffset = 1;

        //    Matrix CurrentPt = new Matrix(NumWell, NumDesc);
        //    DataForPCA = new double[NumWell, NumDesc + 1];

        //    for (int desc = 0; desc < NumDesc; desc++)
        //    {
        //        if (CompleteScreening.ListDescriptors[desc].IsActive() == false) continue;
        //        List<double> CurrentDesc = new List<double>();
        //        foreach (cPlate CurrentPlate in PlatesToProcess)
        //        {
        //            for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
        //                for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
        //                {
        //                    cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
        //                    if (TmpWell == null) continue;
        //                    CurrentDesc.Add(TmpWell.ListDescriptors[desc].GetValue());
        //                }
        //        }
        //        for (int i = 0; i < NumWell; i++)
        //            DataForPCA[i, desc] = CurrentDesc[i];
        //    }

        //    int IDx = 0;
        //    foreach (cPlate CurrentPlate in PlatesToProcess)
        //    {
        //        for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
        //            for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
        //            {
        //                cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
        //                if (TmpWell == null) continue;
        //                DataForPCA[IDx++, NumDesc] = TmpWell.GetClassIdx();
        //            }
        //    }

        //    for (int i = 0; i < NumWell; i++)
        //        for (int j = 0; j < NumDesc; j++) CurrentPt.addElement(i, j, DataForPCA[i, j]);

        //    Matrix NewPt = new Matrix(NumWell, NumDesc);

        //    NewPt = CurrentPt.multiply(EigenVectors);

        //    double MinY = double.MaxValue, MaxY = double.MinValue;

        //    for (int IdxValue0 = 0; IdxValue0 < NumWell; IdxValue0++)
        //    {
        //        double CurrentY = NewPt.getElement(IdxValue0, 1);

        //        if (CurrentY < MinY) MinY = CurrentY;
        //        if (CurrentY > MaxY) MaxY = CurrentY;

        //        CurrentSeries.Points.AddXY(NewPt.getElement(IdxValue0, 0), CurrentY);

        //        CurrentSeries.Points[IdxValue0].Color = CompleteScreening.GlobalInfo.ListWellClasses[(int)DataForPCA[IdxValue0, NumDesc]].ColourForDisplay;
        //        CurrentSeries.Points[IdxValue0].MarkerStyle = MarkerStyle.Circle;
        //        CurrentSeries.Points[IdxValue0].MarkerSize = 8;
        //    }

        //    ChartArea CurrentChartArea = new ChartArea();
        //    CurrentChartArea.BorderColor = Color.Black;

        //    NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
        //    NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        //    CurrentChartArea.BackColor = Color.FromArgb(164, 164, 164);

        //    string AxeName = "";
        //    int IDxDesc = 0;
        //    for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
        //    {
        //        if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
        //        AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 0)) + "x" + CompleteScreening.ListDescriptors[Desc].GetName() + " + ";
        //        //   AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];
        //    }
        //    CurrentChartArea.Axes[0].Title = AxeName.Remove(AxeName.Length - 3);
        //    CurrentChartArea.Axes[0].MajorGrid.Enabled = true;

        //    AxeName = "";
        //    IDxDesc = 0;
        //    for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
        //    {
        //        if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
        //        AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 1)) + "x" + CompleteScreening.ListDescriptors[Desc].GetName() + " + ";
        //    }
        //    //AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];

        //    CurrentChartArea.Axes[1].Title = AxeName.Remove(AxeName.Length - 3);
        //    CurrentChartArea.Axes[1].MajorGrid.Enabled = true;
        //    CurrentChartArea.Axes[1].Minimum = MinY;
        //    CurrentChartArea.Axes[1].Maximum = MaxY;
        //    CurrentChartArea.AxisX.LabelStyle.Format = "N2";
        //    CurrentChartArea.AxisY.LabelStyle.Format = "N2";


        //    CurrentSeries.ChartType = SeriesChartType.Point;
        //    if (GlobalInfo.OptionsWindow.checkBoxDisplayFastPerformance.Checked) CurrentSeries.ChartType = SeriesChartType.FastPoint;
        //    NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);


        //    NewWindow.Text = "PCA";
        //    NewWindow.Show();
        //    NewWindow.chartForSimpleForm.Update();
        //    NewWindow.chartForSimpleForm.Show();
        //    NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });


        //}

        private Matrix PCAComputation(double[,] DataForPCA, int NumWellForLearning, int NumDesc, int NeutralClass, cExtendPlateList PlatesToProcess)
        {

            for (int desc = 0; desc < NumDesc; desc++)
            {
                if (CompleteScreening.ListDescriptors[desc].IsActive() == false) continue;
                List<double> CurrentDesc = new List<double>();

                foreach (cPlate CurrentPlate in PlatesToProcess)
                {
                    for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                        for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                        {
                            cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                            if ((TmpWell == null) || (TmpWell.GetClassIdx() != NeutralClass)) continue;
                            CurrentDesc.Add(TmpWell.ListDescriptors[desc].GetValue());
                        }
                }
                for (int i = 0; i < NumWellForLearning; i++)
                {
                    DataForPCA[i, desc] = CurrentDesc[i];
                }
            }
            int IDx = 0;

            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                foreach (cWell CurrentWell in CurrentPlate.ListActiveWells)
                {
                    if (CurrentWell.GetClassIdx() == NeutralClass)
                        DataForPCA[IDx++, NumDesc] = NeutralClass;// CurrentWell.GetClassIdx();
                }
                // NumWell += CompleteScreening.GetCurrentDisplayPlate().GetNumberOfActiveWells();
            }

            double[,] Basis;
            double[] s2;
            int Info;

            alglib.pcabuildbasis(DataForPCA, NumWellForLearning, NumDesc, out Info, out s2, out Basis);

            Matrix EigenVectors = null;
            if (Info > 0)
            {
                EigenVectors = new Matrix(NumDesc, NumDesc);
                for (int row = 0; row < NumDesc; row++)
                    for (int col = 0; col < NumDesc; col++)
                        EigenVectors.addElement(row, col, Basis[row, col]);
            }
            return EigenVectors;
        }
        #endregion

        #region LDA


        private Matrix LDAComputation(double[,] DataForLDA, int NumWellForLearning, int NumWell, int NumDesc, int NeutralClass, cExtendPlateList PlatesToProcess)
        {
            int Info;
            for (int desc = 0; desc < NumDesc; desc++)
            {
                if (CompleteScreening.ListDescriptors[desc].IsActive() == false) continue;
                List<double> CurrentDesc = new List<double>();

                foreach (cPlate CurrentPlate in PlatesToProcess)
                {
                    for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                        for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                        {
                            cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                            if ((TmpWell == null) || (TmpWell.GetClassIdx() == NeutralClass)) continue;
                            CurrentDesc.Add(TmpWell.ListDescriptors[desc].GetValue());
                        }
                }
                for (int i = 0; i < NumWellForLearning; i++)
                {
                    DataForLDA[i, desc] = CurrentDesc[i];
                }
            }
            int IDx = 0;
            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                        if ((TmpWell == null) || (TmpWell.GetClassIdx() == NeutralClass)) continue;
                        DataForLDA[IDx++, NumDesc] = TmpWell.GetClassIdx();
                    }
            }
            double[,] Basis;

            //alglib.pcabuildbasis(DataForLDA, NumWellForLearning, NumWellForLearning, out Info, out Basis);
            alglib.fisherldan(DataForLDA, NumWellForLearning, NumDesc, NumWellForLearning, out Info, out Basis);
            Matrix EigenVectors = null;
            if (Info > 0)
            {
                EigenVectors = new Matrix(NumDesc, NumDesc);
                for (int row = 0; row < NumDesc; row++)
                    for (int col = 0; col < NumDesc; col++)
                        EigenVectors.addElement(row, col, Basis[row, col]);
            }
            return EigenVectors;
        }

        private void ComputeAndDisplayLDA(cExtendPlateList PlatesToProcess)
        {

            FormClassification WindowClassification = new FormClassification(CompleteScreening);
            WindowClassification.buttonClassification.Text = "Process";
            WindowClassification.Text = "LDA";
            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int NeutralClass = WindowClassification.comboBoxForNeutralClass.SelectedIndex;

            int NumWell = 0;
            int NumWellForLearning = 0;
            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                NumWellForLearning += CurrentPlate.GetNumberOfActiveWellsButClass(NeutralClass);
                NumWell += CurrentPlate.GetNumberOfActiveWells();
            }
            // return;
            if (NumWellForLearning == 0)
            {
                MessageBox.Show("No well identified !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int NumDesc = CompleteScreening.GetNumberOfActiveDescriptor();

            if (NumDesc <= 1)
            {
                MessageBox.Show("More than one descriptor are required for this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[,] DataForLDA = new double[NumWellForLearning, CompleteScreening.GetNumberOfActiveDescriptor() + 1];

            //   return;
            Matrix EigenVectors = LDAComputation(DataForLDA, NumWellForLearning, NumWell, NumDesc, NeutralClass, PlatesToProcess);
            if (EigenVectors == null) return;

            SimpleForm NewWindow = new SimpleForm();
            Series CurrentSeries = new Series();
            CurrentSeries.ShadowOffset = 1;

            Matrix CurrentPt = new Matrix(NumWell, NumDesc);
            DataForLDA = new double[NumWell, NumDesc + 1];

            for (int desc = 0; desc < NumDesc; desc++)
            {
                if (CompleteScreening.ListDescriptors[desc].IsActive() == false) continue;
                List<double> CurrentDesc = new List<double>();
                foreach (cPlate CurrentPlate in PlatesToProcess)
                {
                    for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                        for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                        {
                            cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                            if (TmpWell == null) continue;
                            CurrentDesc.Add(TmpWell.ListDescriptors[desc].GetValue());
                        }
                }
                for (int i = 0; i < NumWell; i++)
                    DataForLDA[i, desc] = CurrentDesc[i];
            }

            int IDx = 0;
            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                        if (TmpWell == null) continue;
                        DataForLDA[IDx++, NumDesc] = TmpWell.GetClassIdx();
                    }
            }

            for (int i = 0; i < NumWell; i++)
                for (int j = 0; j < NumDesc; j++) CurrentPt.addElement(i, j, DataForLDA[i, j]);

            Matrix NewPt = new Matrix(NumWell, NumDesc);

            NewPt = CurrentPt.multiply(EigenVectors);

            double MinY = double.MaxValue, MaxY = double.MinValue;

            for (int IdxValue0 = 0; IdxValue0 < NumWell; IdxValue0++)
            {
                double CurrentY = NewPt.getElement(IdxValue0, 1);

                if (CurrentY < MinY) MinY = CurrentY;
                if (CurrentY > MaxY) MaxY = CurrentY;

                CurrentSeries.Points.AddXY(NewPt.getElement(IdxValue0, 0), CurrentY);

                CurrentSeries.Points[IdxValue0].Color = CompleteScreening.GlobalInfo.ListWellClasses[(int)DataForLDA[IdxValue0, NumDesc]].ColourForDisplay;
                CurrentSeries.Points[IdxValue0].MarkerStyle = MarkerStyle.Circle;
                CurrentSeries.Points[IdxValue0].MarkerSize = 8;
            }

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;

            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackColor = Color.FromArgb(164, 164, 164);

            string AxeName = "";
            int IDxDesc = 0;
            for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
            {
                if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
                AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 0)) + "x" + CompleteScreening.ListDescriptors[Desc].GetName() + " + ";
                //   AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];
            }
            CurrentChartArea.Axes[0].Title = AxeName.Remove(AxeName.Length - 3);
            CurrentChartArea.Axes[0].MajorGrid.Enabled = true;

            AxeName = "";
            IDxDesc = 0;
            for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
            {
                if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
                AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 1)) + "x" + CompleteScreening.ListDescriptors[Desc].GetName() + " + ";
            }
            //AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];

            CurrentChartArea.Axes[1].Title = AxeName.Remove(AxeName.Length - 3);
            CurrentChartArea.Axes[1].MajorGrid.Enabled = true;
            CurrentChartArea.Axes[1].Minimum = MinY;
            CurrentChartArea.Axes[1].Maximum = MaxY;
            CurrentChartArea.AxisX.LabelStyle.Format = "N2";
            CurrentChartArea.AxisY.LabelStyle.Format = "N2";


            CurrentSeries.ChartType = SeriesChartType.Point;
            if (GlobalInfo.OptionsWindow.checkBoxDisplayFastPerformance.Checked) CurrentSeries.ChartType = SeriesChartType.FastPoint;

            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);


            NewWindow.Text = "LDA";
            NewWindow.Show();
            NewWindow.chartForSimpleForm.Update();
            NewWindow.chartForSimpleForm.Show();
            NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });


        }
        #endregion

        #region Genes Analysis
        public class cPathWay
        {
            public string Name;
            public int Occurence = 0;
            public List<string> Genesincluded = new List<string>();
            public int GenesActive = 0;
            public double ratio = 0;
            public double pValue = 0;

        }

        private void findGeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            FormForNameRequest FormForRequest = new FormForNameRequest();
            if (FormForRequest.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlateToProcess.GetWell(IdxValue, IdxValue0, true);
                        if (TmpWell == null) continue;

                        if (TmpWell.Name == FormForRequest.textBoxForName.Text)
                        {

                            CurrentPlateToProcess.DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
                            int Col = IdxValue + 1;
                            int row = IdxValue0 + 1;
                            MessageBox.Show("Column " + Col + " x Row " + row, TmpWell.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
            }

            MessageBox.Show("Gene not found !", FormForRequest.textBoxForName.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void pathwayExpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // GET PATHWAYS
            string getpathways = "http://rest.kegg.jp/list/pathway/hsa";

            HttpWebRequest req = WebRequest.Create(string.Format(getpathways)) as HttpWebRequest;
            req.Method = "GET";

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string PathInfo = reader.ReadToEnd();

            reader.Close();

            if (CompleteScreening == null) return;
            FormForNameRequest FormForRequest = new FormForNameRequest();


            string[] path = PathInfo.Split('\n');

            for (int i = 0; i < path.Length - 1; i++)
            {
                path[i] = path[i].Remove(0, 5);
                FormForRequest.listBox1.Items.Add(path[i]);
            }
            FormForRequest.listBox1.EndUpdate();
            FormForRequest.ShowDialog();

            string pathwayselected = FormForRequest.listBox1.SelectedItem.ToString();

            response.Close();

            //if (FormForRequest.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;


            string[] PathwayName = pathwayselected.Split('\t');






            string getvar = "/link/genes/" + PathwayName[0];// "hsa05010";
            HttpWebRequest req2 = WebRequest.Create(string.Format("http://rest.kegg.jp" + getvar)) as HttpWebRequest;
            req2.Method = "GET";

            HttpWebResponse response2 = req2.GetResponse() as HttpWebResponse;
            StreamReader reader2 = new StreamReader(response2.GetResponseStream());


            string GenInfo = reader2.ReadToEnd();

            reader2.Close();

            response2.Close();

            string[] genesarraytmp = GenInfo.Split('\n');
            List<string> genesarray = new List<string>();
            foreach (string item in genesarraytmp)
            {
                if (item.Contains('\t'))
                {
                    genesarray.Add(item.Split('\t')[1]);
                }

            }


            string[] ListGenesinPathway = genesarray.ToArray();
            double[] ListValues = new double[ListGenesinPathway.Length];


            //StreamWriter stw = new StreamWriter(@"C:\alzheimer.csv");
            //stw.WriteLine("Genes" + "," + "Value");

            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

            List<cPathWay> ListPathway = new List<cPathWay>();



            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
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
                            ListValues[IdxGene] = CurrentWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
                            //stw.Write(CurrentWell.Name); stw.Write(","); stw.Write(ListValues[IdxGene]); stw.WriteLine();
                            break;
                        }
                    }
                }
            }
            //stw.Close();
            string webpage = "http://www.kegg.jp/kegg-bin/show_pathway?" + PathwayName[0] + "+";

            List<double> Pos = new List<double>();
            List<double> Neg = new List<double>();


            int NumDesc = CompleteScreening.ListDescriptors.Count;

            cWell TempWell;


            for (int row = 0; row < CompleteScreening.Rows; row++)
                for (int col = 0; col < CompleteScreening.Columns; col++)
                {
                    TempWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(col, row, true);
                    if (TempWell == null) continue;
                    else
                    {
                        if (TempWell.GetClassIdx() == (int)FormForRequest.numericUpDown1.Value)
                            Pos.Add(TempWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                        if (TempWell.GetClassIdx() == (int)FormForRequest.numericUpDown2.Value)
                            Neg.Add(TempWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                    }
                }
            if (Pos.Count < 3)
            {
                MessageBox.Show("No or not enough positive controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Neg.Count < 3)
            {
                MessageBox.Show("No or not enough negative controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




            double MinValue = Neg.Average();
            //MinValue = ListValues.Min();
            double MaxValue = Pos.Average();
            string[] bg_list = new string[ListGenesinPathway.Length];
            string[] fg_list = new string[ListGenesinPathway.Length];
            for (int IdxCol = 0; IdxCol < bg_list.Length; IdxCol++)
            {

                int ConvertedValue = (int)((((CompleteScreening.GlobalInfo.LUTs.LUT_JET[0].Length - 1) * (ListValues[IdxCol] - MinValue)) / (MaxValue - MinValue)));
                if (ConvertedValue > 63)
                {
                    ConvertedValue = 63;
                }
                if (ConvertedValue < 0)
                {
                    ConvertedValue = 0;
                }
                Color Coul = Color.FromArgb(CompleteScreening.GlobalInfo.LUTs.LUT_JET[0][ConvertedValue], CompleteScreening.GlobalInfo.LUTs.LUT_JET[1][ConvertedValue],
                    CompleteScreening.GlobalInfo.LUTs.LUT_JET[2][ConvertedValue]);


                fg_list[IdxCol] = "000000";
                bg_list[IdxCol] = Coul.Name.Remove(0, 2);
                if (ListValues[IdxCol] == 0)
                    bg_list[IdxCol] = "ffffff";
            }
            int ad = 0;
            foreach (string item in genesarray)
            {
                webpage += item + "%09%23" + bg_list[ad] + "+";
                ad++;
            }

            Process.Start("chrome.exe", webpage);

            //FormForKeggGene KeggWin = new FormForKeggGene();

            //KeggWin.webBrowser.Navigate(webpage);
            ////KeggWin.richTextBox.Text = GenInfo;
            ////KeggWin.Text = "Gene Infos";
            //KeggWin.Show();




        }

        static public List<string> Find_Pathways(double LocusID)
        {
            string getvars = "/link/pathway/hsa:" + LocusID;
            HttpWebRequest req = WebRequest.Create(string.Format("http://rest.kegg.jp" + getvars)) as HttpWebRequest;
            req.Method = "GET";


            HttpWebResponse response2 = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response2.GetResponseStream());



            List<string> Pathways2 = new List<string>();

            // Console application output  
            while (reader.Peek() >= 0)
            {

                string[] resukt = reader.ReadLine().Split('\t');
                if (resukt.Length > 1)
                {
                    Pathways2.Add(resukt[1]);
                }

            }

            reader.Close();
            response2.Close();

            List<string> ListPathway = new List<string>();
            foreach (string item in Pathways2)
                ListPathway.Add(item.Remove(0, 5));

            return ListPathway;
        }


        public string Find_Info(string Path)
        {
            HttpWebRequest req2 = WebRequest.Create(string.Format("http://rest.kegg.jp/get/" + Path)) as HttpWebRequest;
            req2.Method = "GET";

            HttpWebResponse response = req2.GetResponse() as HttpWebResponse;
            StreamReader reader2 = new StreamReader(response.GetResponseStream());

            string GenInfo = reader2.ReadToEnd();
            reader2.Close();

            return GenInfo;
        }

        private FormForPie PathWayAnalysis(int Class)
        {

            #region ExtractGenesHits (var=LocusinClass)

            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            List<string> LocusinClass = new List<string>();
            List<string> LocusID = new List<string>();

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlateToProcess.GetWell(IdxValue, IdxValue0, true);
                        if ((TmpWell != null) && (TmpWell.LocusID != -1) && (TmpWell.LocusID != 0))
                            LocusID.Add("hsa:" + TmpWell.LocusID);
                        if ((TmpWell == null) || (TmpWell.GetClassIdx() != Class) || (TmpWell.LocusID == -1) || (TmpWell.LocusID == 0)) continue;

                        LocusinClass.Add("hsa:" + TmpWell.LocusID);

                    }
            }
            #endregion


            #region Request HTTP (var=GenInfo2 && PathInfo)


            //HttpWebRequest req2 = WebRequest.Create(string.Format("http://rest.kegg.jp/list/hsa")) as HttpWebRequest;
            //req2.Method = "GET";

            //HttpWebResponse response2 = req2.GetResponse() as HttpWebResponse;
            //StreamReader reader2 = new StreamReader(response2.GetResponseStream());

            //string GenInfo2 = reader2.ReadToEnd();
            //reader2.Close();

            //string[] ListofGenes = GenInfo2.Split('\n');
            //List<string> GenesList = ListofGenes.Select(x => x.Split('\t')[0]).ToList();

            //List<string> CommonGenes = GenesList.Intersect(LocusID).ToList();

            HttpWebRequest req = WebRequest.Create(string.Format("http://rest.kegg.jp/link/hsa/pathway")) as HttpWebRequest;
            req.Method = "GET";

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string PathInfo = reader.ReadToEnd();
            reader.Close();
            #endregion

            //HttpWebRequest req3 = WebRequest.Create(string.Format("http://rest.kegg.jp/link/pathway/hsa")) as HttpWebRequest;
            //req3.Method = "GET";

            //HttpWebResponse response3 = req3.GetResponse() as HttpWebResponse;
            //StreamReader reader3 = new StreamReader(response3.GetResponseStream());

            //string GenesInfo = reader3.ReadToEnd();
            //reader3.Close();
            //string[] GenesinPathways = GenesInfo.Split('\n');

            #region numberofgenesbypathways

            string[] PathwayGenes = PathInfo.Split('\n');// extract the number of genes by Pathway for p-values
            IEnumerable<IGrouping<string, string>> NumberofGenesByPathways = PathwayGenes.GroupBy(x => x.Split('\t')[0]).ToList();
            IEnumerable<IGrouping<string, string>> Numberofpathwaybygenes = PathwayGenes.Where(x => x.Count() > 0).GroupBy(x => x.Split('\t')[1]).ToList();
            //IEnumerable<IGrouping<string, string>> NumberofGenesby = GenesinPathways.Where(x => x.Count() > 0).GroupBy(x => x.Split('\t')[0]).ToList();


            #endregion


            #region ExtractNumberofpatways

            //string[] GenePathways = GenInfo2.Split('\n');

            List<cPathWay> ListPathway = new List<cPathWay>();


            foreach (IGrouping<string, string> item in Numberofpathwaybygenes)
            {
                if (LocusinClass.Contains(item.Key))
                {
                    foreach (string PathName in item)
                    {

                        if (ListPathway.Count == 0)
                        {
                            cPathWay CurrPath = new cPathWay();
                            CurrPath.Name = PathName.Split('\t')[0];
                            CurrPath.Occurence = 1;
                            ListPathway.Add(CurrPath);
                            continue;
                        }


                        bool DidIt = false;
                        for (int i = 0; i < ListPathway.Count; i++)
                        {
                            if (PathName.Split('\t')[0] == ListPathway[i].Name)
                            {
                                ListPathway[i].Occurence++;
                                DidIt = true;
                                break;
                            }
                        }

                        if (DidIt == false)
                        {
                            cPathWay CurrPath1 = new cPathWay();
                            CurrPath1.Name = PathName.Split('\t')[0];
                            CurrPath1.Occurence = 1;
                            ListPathway.Add(CurrPath1);
                        }


                    }


                }
            }

            int thu = 0;
            foreach (cPathWay item in ListPathway)
            {

                thu += item.Occurence;


            }
            #endregion

            #region now draw the pie
            if (ListPathway.Count == 0)
            {
                MessageBox.Show("No pathway identified !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;

            }

            FormForPie Pie = new FormForPie();

            Series CurrentSeries = Pie.chartForPie.Series[0];
            Pie.chartForPie.Titles.Add("Pathways Enrichment Ratio");

            List<cPathWay> newPathway = new List<cPathWay>();
            newPathway = ListPathway.OrderByDescending(p => p.Occurence).ToList();
            List<string> Pathwaynamehit = new List<string>();
            //List<double> numberofgenesinPathway = new List<double>();

            foreach (var item in newPathway)
                foreach (IGrouping<string, string> item2 in NumberofGenesByPathways)
                {

                    if (item.Name.Contains(item2.Key) && item2.Key != "")
                    {
                        item.Genesincluded.AddRange(item2);

                    }


                }

            List<cPathWay> FinalPathway = new List<cPathWay>();
            foreach (cPathWay item in newPathway)
            {
                cPathWay temp = new cPathWay();
                List<string> tempgenes = new List<string>();
                foreach (string item2 in item.Genesincluded)
                {
                    tempgenes.Add(item2.Replace(item2, item2.Split('\t')[1]));
                }
                temp.Genesincluded.AddRange(tempgenes);
                temp.Name = item.Name;
                temp.Occurence = item.Occurence;

                FinalPathway.Add(temp);
            }

            foreach (cPathWay item in FinalPathway)
            {
                int cpt = 0;
                foreach (string item2 in item.Genesincluded)
                {
                    if (LocusinClass.Contains(item2))
                    {
                        cpt++;
                    }
                }
                item.GenesActive = cpt;
                item.ratio = (double)item.GenesActive / (double)item.Genesincluded.Count();

                //for (int i = item.GenesActive; i < item.Genesincluded.Count(); i++)
                //{
                item.pValue = Pvalue(item.GenesActive, Numberofpathwaybygenes.Count()-item.Genesincluded.Count(), item.Genesincluded.Count(), LocusinClass.Count()-item.GenesActive);
                //}
            }


            List<cPathWay> AfterFinal = new List<cPathWay>();


            AfterFinal = FinalPathway.OrderBy(p => (p.pValue)).ToList();
            cExtendedList ratioac = new cExtendedList();

            foreach (cPathWay item in AfterFinal)
            {

                ratioac.Add(item.pValue);


            }

            cViewerHistogram toto = new cViewerHistogram();
            cExtendedTable data = new cExtendedTable(ratioac);
            toto.SetInputData(data);

            toto.Chart.LabelAxisX = "pValue";
            toto.Chart.LabelAxisY = "Distribution";
            toto.Run();




            cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
            Designer0.SetInputData(toto.GetOutPut());
            Designer0.Run();

            cDisplayToWindow Disp0 = new cDisplayToWindow();
            Disp0.SetInputData(Designer0.GetOutPut());
            Disp0.Title = "Histo- ";
            Disp0.Run();
            Disp0.Display();




            //for (int Idx = 0; Idx < 40; Idx++)
            //{

            int Idx = 0;
            while (AfterFinal[Idx].pValue < 0.05)
            {
                CurrentSeries.Points.Add(AfterFinal[Idx].pValue);
                CurrentSeries.Points[Idx].Label = String.Format("{0:0.##}", ((AfterFinal[Idx].pValue)));

                CurrentSeries.Points[Idx].LegendText = AfterFinal[Idx].Name + "   (" + AfterFinal[Idx].GenesActive + "/" +
                    AfterFinal[Idx].Genesincluded.Count() + ")";

                CurrentSeries.Points[Idx].ToolTip = AfterFinal[Idx].Name + "\n" + (LocusID.Count()) + "\n" + (LocusinClass.Count() + "\n" + AfterFinal[Idx].pValue);
                if (Idx == 0)
                    CurrentSeries.Points[Idx].SetCustomProperty("Exploded", "True");
                //MathNet.Numerics.Distributions.Hypergeometric T =
                //    new MathNet.Numerics.Distributions.Hypergeometric(Numberofpathwaybygenes.Count(), AfterFinal[Idx].Genesincluded.Count(), LocusinClass.Count());

                Idx++;
            }


            #endregion

            #region Display Pathways
            List<string> namepathwaypvalue = new List<string>();
            for (int i = 0; i < Idx; i++)
            {
                namepathwaypvalue.Add(AfterFinal[i].Name.Remove(0, 5));
            }

            PathwayDisplayforpvalue(namepathwaypvalue);
            #endregion
            return Pie;
        }

        public double Pvalue(int x, int m, int k, int n)
        {
            double p = 0;
            double a = MathNet.Numerics.SpecialFunctions.GammaLn(k + 1) - MathNet.Numerics.SpecialFunctions.GammaLn(x + 1)
                - MathNet.Numerics.SpecialFunctions.GammaLn(k - x + 1);

            double b = MathNet.Numerics.SpecialFunctions.GammaLn(m + 1) - MathNet.Numerics.SpecialFunctions.GammaLn(n + 1) -
                MathNet.Numerics.SpecialFunctions.GammaLn(m - n + 1);

            double c = MathNet.Numerics.SpecialFunctions.GammaLn(m - k + 1) - MathNet.Numerics.SpecialFunctions.GammaLn(n - x + 1)
                - MathNet.Numerics.SpecialFunctions.GammaLn(m - k - (n - x) + 1);

            p = Math.Exp(a + c - b);


           
            return p;
        }

        public void PathwayDisplayforpvalue(List<string> Pathway)
        {

            FormForNameRequest FormForRequest = new FormForNameRequest();
            // FormForRequest.Size = new Size(150, 150);
            FormForRequest.ShowDialog();
            int h = (Pathway.Count() < (int)FormForRequest.numericUpDown3.Value) ? Pathway.Count() : (int)FormForRequest.numericUpDown3.Value;
            //int h=Pathway.Count()>FormForRequest.numericUpDown3.Value?:
            for (int i = 0; i < h; i++)
            {



                string getvar = "/link/genes/" + Pathway[i];// "hsa05010";
                HttpWebRequest req2 = WebRequest.Create(string.Format("http://rest.kegg.jp" + getvar)) as HttpWebRequest;
                req2.Method = "GET";

                HttpWebResponse response2 = req2.GetResponse() as HttpWebResponse;
                StreamReader reader2 = new StreamReader(response2.GetResponseStream());


                string GenInfo = reader2.ReadToEnd();

                reader2.Close();

                response2.Close();

                string[] genesarraytmp = GenInfo.Split('\n');
                List<string> genesarray = new List<string>();
                foreach (string item in genesarraytmp)
                {
                    if (item.Contains('\t'))
                    {
                        genesarray.Add(item.Split('\t')[1]);
                    }

                }


                string[] ListGenesinPathway = genesarray.ToArray();
                double[] ListValues = new double[ListGenesinPathway.Length];


                //StreamWriter stw = new StreamWriter(@"C:\alzheimer.csv");
                //stw.WriteLine("Genes" + "," + "Value");

                int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

                List<cPathWay> ListPathway = new List<cPathWay>();



                foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
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
                                ListValues[IdxGene] = CurrentWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
                                //stw.Write(CurrentWell.Name); stw.Write(","); stw.Write(ListValues[IdxGene]); stw.WriteLine();
                                break;
                            }
                        }
                    }
                }
                //stw.Close();
                string webpage = "http://www.kegg.jp/kegg-bin/show_pathway?" + Pathway[i] + "+";

                List<double> Pos = new List<double>();
                List<double> Neg = new List<double>();


                int NumDesc = CompleteScreening.ListDescriptors.Count;

                cWell TempWell;

                if (CompleteScreening == null) return;



                for (int row = 0; row < CompleteScreening.Rows; row++)
                    for (int col = 0; col < CompleteScreening.Columns; col++)
                    {
                        TempWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(col, row, true);
                        if (TempWell == null) continue;
                        else
                        {
                            if (TempWell.GetClassIdx() == (int)FormForRequest.numericUpDown1.Value)
                                Pos.Add(TempWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                            if (TempWell.GetClassIdx() == (int)FormForRequest.numericUpDown2.Value)
                                Neg.Add(TempWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue());
                        }
                    }
                if (Pos.Count < 3)
                {
                    MessageBox.Show("No or not enough positive controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Neg.Count < 3)
                {
                    MessageBox.Show("No or not enough negative controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }




                double MinValue = Neg.Average();
                //MinValue = ListValues.Min();
                double MaxValue = Pos.Average();
                string[] bg_list = new string[ListGenesinPathway.Length];
                string[] fg_list = new string[ListGenesinPathway.Length];
                for (int IdxCol = 0; IdxCol < bg_list.Length; IdxCol++)
                {

                    int ConvertedValue = (int)((((CompleteScreening.GlobalInfo.LUTs.LUT_JET[0].Length - 1) * (ListValues[IdxCol] - MinValue)) / (MaxValue - MinValue)));
                    if (ConvertedValue > 63)
                    {
                        ConvertedValue = 63;
                    }
                    if (ConvertedValue < 0)
                    {
                        ConvertedValue = 0;
                    }
                    Color Coul = Color.FromArgb(CompleteScreening.GlobalInfo.LUTs.LUT_JET[0][ConvertedValue], CompleteScreening.GlobalInfo.LUTs.LUT_JET[1][ConvertedValue],
                        CompleteScreening.GlobalInfo.LUTs.LUT_JET[2][ConvertedValue]);


                    fg_list[IdxCol] = "000000";
                    bg_list[IdxCol] = Coul.Name.Remove(0, 2);
                    if (ListValues[IdxCol] == 0)
                        bg_list[IdxCol] = "ffffff";

                }
                int ad = 0;
                foreach (string item in genesarray)
                {
                    webpage += item + "%09%23" + bg_list[ad] + "+";
                    ad++;
                }

                Process.Start("chrome.exe", webpage);
            }
        }



        //private FormForPie PathWayAnalysis(int Class)
        //{
        //    //int Idx = 0;
        //    int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

        //    KEGG ServKegg = new KEGG();

        //    List<cPathWay> ListPathway = new List<cPathWay>();

        //    // loop on all the plate
        //    for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
        //    {
        //        cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);

        //        for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
        //            for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
        //            {
        //                cWell TmpWell = CurrentPlateToProcess.GetWell(IdxValue, IdxValue0, true);
        //                if ((TmpWell == null) || (TmpWell.GetClassIdx() != Class) || (TmpWell.LocusID == -1)) continue;


        //                string[] intersection_gene_pathways = new string[1];
        //                intersection_gene_pathways[0] = "hsa:" + TmpWell.LocusID;
        //                string[] Pathways = ServKegg.get_pathways_by_genes(intersection_gene_pathways);
        //                if ((Pathways == null) || (Pathways.Length == 0)) continue;

        //                for (int Idx = 0; Idx < Pathways.Length; Idx++)
        //                {
        //                    //  string PathName = Pathways[Idx].Remove(0, 8);
        //                    string GenInfo = ServKegg.bget(Pathways[Idx]);
        //                    string[] Genes = GenInfo.Split(new char[] { '\n' });
        //                    string PathName = "";
        //                    foreach (string item in Genes)
        //                    {
        //                        string[] fre = item.Split(' ');
        //                        string[] STRsection = fre[0].Split('_');

        //                        if (STRsection[0] == "NAME")
        //                        {
        //                            for (int i = 1; i < fre.Length; i++)
        //                            {
        //                                if (fre[i] == "") continue;
        //                                PathName += fre[i] + " ";
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (ListPathway.Count == 0)
        //                    {
        //                        cPathWay CurrPath = new cPathWay();
        //                        CurrPath.Name = PathName;
        //                        CurrPath.Occurence = 1;
        //                        ListPathway.Add(CurrPath);
        //                        continue;
        //                    }

        //                    bool DidIt = false;
        //                    for (int i = 0; i < ListPathway.Count; i++)
        //                    {
        //                        if (PathName == ListPathway[i].Name)
        //                        {
        //                            ListPathway[i].Occurence++;
        //                            DidIt = true;
        //                            break;
        //                        }
        //                    }

        //                    if (DidIt == false)
        //                    {
        //                        cPathWay CurrPath1 = new cPathWay();
        //                        CurrPath1.Name = PathName;
        //                        CurrPath1.Occurence = 1;
        //                        ListPathway.Add(CurrPath1);
        //                    }
        //                }
        //            }
        //    }

        //    // now draw the pie
        //    if (ListPathway.Count == 0)
        //    {
        //        MessageBox.Show("No pathway identified !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return null;

        //    }
        //    FormForPie Pie = new FormForPie();

        //    Series CurrentSeries = Pie.chartForPie.Series[0];

        //    // loop on all the plate
        //    int MaxOccurence = int.MinValue;
        //    int MaxIdx = 0;
        //    int TotalOcurrence = 0;
        //    for (int Idx = 0; Idx < ListPathway.Count; Idx++)
        //    {
        //        if (ListPathway[Idx].Occurence > MaxOccurence)
        //        {
        //            MaxOccurence = ListPathway[Idx].Occurence;
        //            MaxIdx = Idx;
        //        }
        //        TotalOcurrence += ListPathway[Idx].Occurence;
        //    }



        //    //CurrentSeries.CustomProperties = "PieLabelStyle=Outside";
        //    for (int Idx = 0; Idx < ListPathway.Count; Idx++)
        //    {
        //        CurrentSeries.Points.Add(ListPathway[Idx].Occurence);
        //        CurrentSeries.Points[Idx].Label = String.Format("{0:0.###}", ((100.0 * ListPathway[Idx].Occurence) / TotalOcurrence)) + " %";

        //        CurrentSeries.Points[Idx].LegendText = ListPathway[Idx].Name;
        //        CurrentSeries.Points[Idx].ToolTip = ListPathway[Idx].Name;
        //        if (Idx == MaxIdx)
        //            CurrentSeries.Points[Idx].SetCustomProperty("Exploded", "True");
        //    }

        //    return Pie;
        //}

        private void pahtwaysAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            this.Cursor = Cursors.WaitCursor;
            FormForPie CurrentFormForPie = PathWayAnalysis(CompleteScreening.SelectedClass);
            this.Cursor = Cursors.Default;
            if (CurrentFormForPie != null) CurrentFormForPie.Show();
        }
        #endregion

        #region Systematic Error Identification
        private List<string> ComputePlateBasedClassification(int Classes, int MinObjectsNumber, cPlate CurrentPlateToProcess)
        {
            CurrentPlateToProcess.ComputePlateBasedDescriptors();
            weka.core.Instances insts = CurrentPlateToProcess.CreateInstancesWithClassesWithPlateBasedDescriptor(Classes);
            weka.classifiers.trees.J48 ClassificationModel = new weka.classifiers.trees.J48();
            ClassificationModel.setMinNumObj(MinObjectsNumber);

            weka.core.Instances train = new weka.core.Instances(insts, 0, insts.numInstances());
            ClassificationModel.buildClassifier(train);

            // display the tree
            string DotString = ClassificationModel.graph().Remove(0, ClassificationModel.graph().IndexOf("{") + 2);
            int DotLenght = DotString.Length;

            string NewDotString = DotString.Remove(DotLenght - 3, 3);
            ComputeAndDisplayGraph(NewDotString);
            return ComputeGraph(NewDotString, Classes);
        }

        private List<string> ComputeGraph(string DotString, int Classes)
        {
            List<string> ToReturn = new List<string>();

            int CurrentPos = 0;
            int NextReturnPos = CurrentPos;
            List<int> ListNodeId = new List<int>();
            string TmpDotString = DotString;

            int TmpClass = 0;
            string ErrorString = "";
            int ErrorMessage = 0;

            ToReturn.Add(ErrorString);

            ToReturn.Add("");   // edge
            ToReturn.Add("");   // col
            ToReturn.Add("");   // row
            ToReturn.Add("");   // bowl


            while (NextReturnPos != -1)
            {
                int NextBracket = DotString.IndexOf("[");
                string StringToProcess = DotString.Remove(NextBracket - 1);
                string StringToProcess1 = StringToProcess.Remove(0, 1);

                if (StringToProcess1.Contains("N") == false)
                {
                    int Id = Convert.ToInt32(StringToProcess1);


                    int LabelPos = DotString.IndexOf("label=\"");
                    string LabelString = DotString.Remove(0, LabelPos + 7);
                    LabelPos = LabelString.IndexOf("\"");
                    string FinalLabel = LabelString.Remove(LabelPos);

                    if (TmpClass < Classes)
                    {
                        if ((FinalLabel == "Dist_To_Border") || (FinalLabel == "Col_Pos") || (FinalLabel == "Row_Pos") || (FinalLabel == "Dist_To_Center"))
                        {
                            if ((FinalLabel == "Dist_To_Border") && (!ErrorString.Contains(" an edge effect")) && (!ErrorString.Contains(" a bowl effect")) && (ErrorMessage < 2))
                            {
                                if (TmpClass > 0) ErrorString += " combined with";
                                ErrorString += " an " + CompleteScreening.GlobalInfo.ListArtifacts[0];
                                ErrorMessage++;
                                ToReturn[1] = "X";
                            }
                            else if ((FinalLabel == "Col_Pos") && (!ErrorString.Contains(" a column artifact")) && (ErrorMessage < 2))
                            {
                                if (TmpClass > 0) ErrorString += " combined with";
                                ErrorString += " a " + CompleteScreening.GlobalInfo.ListArtifacts[1];
                                ErrorMessage++;
                                ToReturn[2] = "X";

                            }
                            else if ((FinalLabel == "Row_Pos") && (!ErrorString.Contains(" a row artifact")) && (ErrorMessage < 2))
                            {
                                if (TmpClass > 0) ErrorString += " combined with";
                                ErrorString += " a " + CompleteScreening.GlobalInfo.ListArtifacts[2];
                                ErrorMessage++;
                                ToReturn[3] = "X";

                            }
                            else if ((FinalLabel == "Dist_To_Center") && (!ErrorString.Contains(" a bowl effect")) && (!ErrorString.Contains(" an edge effect")) && (ErrorMessage < 2))
                            {
                                if (TmpClass > 0) ErrorString += " combined with";
                                ErrorString += " a " + CompleteScreening.GlobalInfo.ListArtifacts[3];
                                ErrorMessage++;
                                ToReturn[4] = "X";

                            }
                            TmpClass++;
                        }
                    }
                }

                NextReturnPos = DotString.IndexOf("\n");
                if (NextReturnPos != -1)
                {
                    string TmpString = DotString.Remove(0, NextReturnPos + 1);
                    DotString = TmpString;
                }
            }

            if (TmpClass == 0)
            {
                string NoError = "No systematic error detected !";
                ToReturn.Add(NoError);
                return ToReturn;
            }

            string FinalString = "You have a systematic error !\nThis is " + ErrorString;

            DotString = TmpDotString;
            NextReturnPos = 0;
            while (NextReturnPos != -1)
            {
                int NextBracket = DotString.IndexOf("[");
                string StringToProcess = DotString.Remove(NextBracket - 1);
                string StringToProcess1 = StringToProcess.Remove(0, 1);

                if (StringToProcess1.Contains("N"))
                {
                    //// this is an edge
                    string stringNodeIdxStart = StringToProcess1.Remove(StringToProcess1.IndexOf("-"));
                    int NodeIdxStart = Convert.ToInt32(stringNodeIdxStart);

                    string stringNodeIdxEnd = StringToProcess1.Remove(0, StringToProcess1.IndexOf("N") + 1);
                    int NodeIdxSEnd = Convert.ToInt32(stringNodeIdxEnd);

                    int LabelPos = DotString.IndexOf("label=");
                    LabelPos += 7;

                    string CurrLabelString = DotString.Remove(0, LabelPos);
                }
                NextReturnPos = DotString.IndexOf("\n");

                if (NextReturnPos != -1)
                {
                    string TmpString = DotString.Remove(0, NextReturnPos + 1);
                    DotString = TmpString;
                }
            }

            ToReturn[0] = FinalString + ".";

            return ToReturn;


        }

        private List<string> GenerateArtifactMessage(cPlate PlateToProcess, int CurrentDescSel)
        {
            int NumWell = PlateToProcess.GetNumberOfActiveWells();
            List<string> Messages = new List<string>();

            // Normality Test
            List<double> CurrentDesc = new List<double>();
            for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                {
                    cWell TmpWell = PlateToProcess.GetWell(IdxValue, IdxValue0, true);
                    if (TmpWell != null)
                        CurrentDesc.Add(TmpWell.ListDescriptors[CurrentDescSel].GetValue());
                }
            CurrentDesc.Sort();

            if ((std(CurrentDesc.ToArray()) == 0))
            {
                //Messages.Add(/*PlateToProcess.Name + "\n \n*/"No systematic error detected !");
                return null;
            }

            double Anderson_DarlingValue = Anderson_Darling(CurrentDesc.ToArray());

            Messages.Add(string.Format("{0:0.###}", Anderson_DarlingValue));

            // now clustering
            if (!KMeans((int)GlobalInfo.OptionsWindow.numericUpDownSystErrorIdentKMeansClasses.Value, PlateToProcess, CurrentDescSel))
            {
                List<string> ListMessageError = new List<string>();
                ListMessageError.Add("K-Means Error");
                return ListMessageError;
            }

            // and finally classification
            int MinObjectsNumber = (NumWell * (int)GlobalInfo.OptionsWindow.numericUpDownSystemMinWellRatio.Value) / 100;

            List<string> ListMessage = ComputePlateBasedClassification((int)GlobalInfo.OptionsWindow.numericUpDownSystErrorIdentKMeansClasses.Value, MinObjectsNumber, PlateToProcess);

            for (int i = 0; i < ListMessage.Count; i++)
                Messages.Add(ListMessage[i]);

            return Messages;
        }


        private DataTable ComputeSystematicErrorsTable()
        {
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            int NumDesc = CompleteScreening.ListDescriptors.Count;

            DataTable TableForQltControl = new DataTable();
            dataGridViewForQualityControl.Columns.Clear();
            dataGridViewForQualityControl.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            TableForQltControl.Columns.Add(new DataColumn("Plate", typeof(string)));
            TableForQltControl.Columns.Add(new DataColumn("Descriptor", typeof(string)));
            TableForQltControl.Columns.Add(new DataColumn("Anderson-Darling test", typeof(string)));

            for (int iDesc = 0; iDesc < CompleteScreening.GlobalInfo.ListArtifacts.Length; iDesc++)
            {
                TableForQltControl.Columns.Add(new DataColumn(CompleteScreening.GlobalInfo.ListArtifacts[iDesc], typeof(string)));
            }

            int IdxTable = 0;
            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx);

                // loop on all the desciptors
                for (int Desc = 0; Desc < NumDesc; Desc++)
                {
                    if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
                    GlobalInfo.CurrentRichTextBox.AppendText(CurrentPlateToProcess.Name + " \\ " + CompleteScreening.ListDescriptors[Desc].GetName() + "\n");
                    List<string> Messages = GenerateArtifactMessage(CurrentPlateToProcess, Desc);

                    GlobalInfo.CurrentRichTextBox.AppendText("\n-------------------------------------------------------------------\n");
                    if (Messages == null) continue;
                    if (Convert.ToDouble(Messages[0]) < (double)GlobalInfo.OptionsWindow.numericUpDownSystErrorAndersonDarlingThreshold.Value) continue;

                    TableForQltControl.Rows.Add();

                    TableForQltControl.Rows[IdxTable][0] = CurrentPlateToProcess.Name;
                    TableForQltControl.Rows[IdxTable][1] = CompleteScreening.ListDescriptors[Desc].GetName();

                    if (Messages == null)
                    {
                        GlobalInfo.CurrentRichTextBox.AppendText("No variation !");
                        TableForQltControl.Rows[IdxTable][2] = "0";
                    }
                    else
                    {
                        if (Messages.Count == 1)
                        {
                            GlobalInfo.CurrentRichTextBox.AppendText(Messages[0]);
                        }
                        else
                        {
                            GlobalInfo.CurrentRichTextBox.AppendText(Messages[1]);
                            TableForQltControl.Rows[IdxTable][2] = Messages[0];
                        }

                        if (Messages.Count > 2)
                        {
                            for (int i = 0; i < CompleteScreening.GlobalInfo.ListArtifacts.Length; i++)
                                TableForQltControl.Rows[IdxTable][3 + i] = Messages[2 + i];
                        }
                    }
                    IdxTable++;
                }
                GlobalInfo.CurrentRichTextBox.AppendText("*******************************************************************\n");
            }

            return TableForQltControl;


        }

        private void buttonQualityControl_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult Res = MessageBox.Show("By applying this process, classes will be definitively modified ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Res == System.Windows.Forms.DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            DataTable ResultSystematicError = ComputeSystematicErrorsTable();
            dataGridViewForQualityControl.DataSource = ResultSystematicError;
            dataGridViewForQualityControl.Update();
            this.Cursor = Cursors.Default;
            return;
        }
        #endregion

        #region Compute and display Correlation matrix
        private void correlationMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComputeAndDisplayCorrelationMatrix(true, true, null);
        }


        private void ComputeAndDisplayCorrelationMatrix(bool IsFullScreen, bool IsToBeDisplayed, string PathForImage)
        {
            if (CompleteScreening == null) return;
            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool IsDisplayRanking = CompleteScreening.GlobalInfo.OptionsWindow.checkBoxCorrelationMatrixDisplayRanking.Checked;
            //bool IsPearson = CompleteScreening.GlobalInfo.OptionsWindow.radioButtonPearson.Checked;
            Boolean IsDisplayValues = false;


            List<double>[] ListValueDesc = ExtractDesciptorAverageValuesList(IsFullScreen);
            double[,] CorrelationMatrix = ComputeCorrelationMatrix(ListValueDesc);

            if (CorrelationMatrix == null)
            {
                MessageBox.Show("Data error, correlation computation impossible !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //   return;
            List<string> NameX = CompleteScreening.ListDescriptors.GetListNameActives();
            List<string> NameY = CompleteScreening.ListDescriptors.GetListNameActives();

            string TitleForGraph = "";
            if (GlobalInfo.OptionsWindow.radioButtonPearson.Checked) TitleForGraph = "Pearson ";
            else if
                (GlobalInfo.OptionsWindow.radioButtonSpearman.Checked) TitleForGraph = "Spearman's ";
            else if
                (GlobalInfo.OptionsWindow.radioButtonMIC.Checked) TitleForGraph = "MIC's ";
            TitleForGraph += " correlation matrix.";

            int SquareSize;

            if (NameX.Count > 20)
                SquareSize = 5;
            else
                SquareSize = 100 - ((10 * NameX.Count) / 3);
            DisplayMatrix(CorrelationMatrix, NameX, NameY, IsDisplayValues, TitleForGraph, SquareSize, IsToBeDisplayed, PathForImage);
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (IsDisplayRanking == false) return;
            else
                DisplayCorrelationRanking(ListValueDesc, CorrelationMatrix);
        }


        public void DisplayCorrelationRanking(List<double>[] ListValueDesc, double[,] CorrelationMatrix)
        {

            string TitleForGraph;
            Series CurrentSeries1 = new Series("Data1");
            CurrentSeries1.ShadowOffset = 1;
            CurrentSeries1.ChartType = SeriesChartType.Column;


            int RealPosSelectedDesc = -1;

            int realPos = 0;
            for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
            {
                if (CompleteScreening.ListDescriptors[i].IsActive()) realPos++;
                if (i == CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx)
                {
                    RealPosSelectedDesc = i - 2;
                    break;
                }
            }

            // loop on all the desciptors
            int IdxValue = 0;
            for (int iDesc = 0; iDesc < ListValueDesc.Length; iDesc++)
                for (int jDesc = 0; jDesc < ListValueDesc.Length; jDesc++)
                {
                    if (iDesc <= jDesc) continue;
                    CurrentSeries1.Points.Add(Math.Abs(CorrelationMatrix[iDesc, jDesc]));

                    if (GlobalInfo.OptionsWindow.checkBoxCorrelationRankChangeColorForActiveDesc.Checked)
                    {
                        if (CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx < CompleteScreening.ListDescriptors.GetListNameActives().Count)
                        {
                            if ((CompleteScreening.ListDescriptors.GetListNameActives()[iDesc] == CompleteScreening.ListDescriptors.GetListNameActives()[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx]) ||
                                (CompleteScreening.ListDescriptors.GetListNameActives()[jDesc] == CompleteScreening.ListDescriptors.GetListNameActives()[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx]))
                                CurrentSeries1.Points[IdxValue].Color = Color.LightGreen;
                        }
                    }
                    CurrentSeries1.Points[IdxValue].Label = string.Format("{0:0.###}", CorrelationMatrix[iDesc, jDesc]);
                    CurrentSeries1.Points[IdxValue].ToolTip = CompleteScreening.ListDescriptors.GetListNameActives()[iDesc] + "\n vs. \n" + CompleteScreening.ListDescriptors.GetListNameActives()[jDesc];
                    CurrentSeries1.Points[IdxValue].AxisLabel = CurrentSeries1.Points[IdxValue++].ToolTip;
                }

            SimpleForm NewWindow1 = new SimpleForm();
            int thisWidth = CurrentSeries1.Points.Count * 100 + 200;
            if (thisWidth > (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value)
                thisWidth = (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value;
            NewWindow1.Width = thisWidth;
            //NewWindow1.Width = CurrentSeries1.Points.Count * 100 + 200;

            ChartArea CurrentChartArea1 = new ChartArea("Default1");
            CurrentChartArea1.BackGradientStyle = GradientStyle.TopBottom;
            CurrentChartArea1.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            CurrentChartArea1.BackSecondaryColor = Color.White;
            CurrentChartArea1.BorderColor = Color.Black;

            NewWindow1.chartForSimpleForm.ChartAreas.Add(CurrentChartArea1);
            CurrentSeries1.SmartLabelStyle.Enabled = true;
            CurrentChartArea1.AxisY.Title = "Absolute Correlation Coeff.";

            NewWindow1.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            NewWindow1.chartForSimpleForm.Series.Add(CurrentSeries1);

            CurrentChartArea1.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea1.Axes[1].MajorGrid.Enabled = false;
            CurrentChartArea1.Axes[1].Minimum = 0;
            CurrentChartArea1.Axes[1].Maximum = 1.2;

            CurrentChartArea1.AxisX.Interval = 1;
            NewWindow1.chartForSimpleForm.Series[0].Sort(PointSortOrder.Ascending, "Y");

            if (GlobalInfo.OptionsWindow.radioButtonPearson.Checked) TitleForGraph = "Pearson's ";
            else if (GlobalInfo.OptionsWindow.radioButtonPearson.Checked) TitleForGraph = "Spearman's ";
            else TitleForGraph = "MIC's ";

            TitleForGraph += "correlation ranking";

            Title CurrentTitle1 = new Title(TitleForGraph);

            /* if (IsToBeDisplayed) */
            NewWindow1.Show();
            //else
            //    NewWindow1.chartForSimpleForm.SaveImage(PathForImage + "_Ranking.png", ChartImageFormat.Png);

            NewWindow1.chartForSimpleForm.Titles.Add(CurrentTitle1);
            NewWindow1.Text = "Quality Control: Corr. ranking";
            NewWindow1.chartForSimpleForm.Update();
            NewWindow1.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow1.chartForSimpleForm });

            return;
        }



        private double[,] ComputeCorrelationMatrix(List<double>[] ListValueDesc)
        {
            int NumDesc = ListValueDesc.Length;
            double[,] CorrelationMatrix = new double[NumDesc, NumDesc];

            if (GlobalInfo.OptionsWindow.radioButtonMIC.Checked)
            {
                double[][] dataset1 = new double[NumDesc][];
                string[] VarNames = new string[NumDesc];


                for (int iDesc = 0; iDesc < NumDesc; iDesc++)
                {
                    dataset1[iDesc] = new double[ListValueDesc[iDesc].Count];

                    Array.Copy(ListValueDesc[iDesc].ToArray(), dataset1[iDesc], ListValueDesc[iDesc].Count);
                    VarNames[iDesc] = iDesc.ToString();
                }
                data.Dataset data1 = new data.Dataset(dataset1, VarNames, 0);
                VarPairQueue Qu = new VarPairQueue(data1);


                for (int iDesc = 0; iDesc < NumDesc; iDesc++)
                    for (int jDesc = 0; jDesc < NumDesc; jDesc++)
                    {
                        Qu.addPair(iDesc, jDesc);
                    }


                Analysis ana = new Analysis(data1, Qu);
                AnalysisParameters param = new AnalysisParameters();
                double resparam = param.commonValsThreshold;

                analysis.results.FullResult Full = new analysis.results.FullResult();
                //List<analysis.results.BriefResult> Brief = new List<analysis.results.BriefResult>();
                analysis.results.BriefResult Brief = new analysis.results.BriefResult();

                java.lang.Class t = java.lang.Class.forName("analysis.results.BriefResult");

                //java.lang.Class restype = null;
                ana.analyzePairs(t, param);

                //   object o =  (ana.varPairQueue().peek());
                //   ana.getClass();
                //  int resNum = ana.numResults();
                analysis.results.Result[] res = ana.getSortedResults();
                //  double main = res[0].getMainScore();
                for (int iDesc = 0; iDesc < NumDesc; iDesc++)
                    for (int jDesc = 0; jDesc < NumDesc; jDesc++)
                    {
                        int X = int.Parse(res[jDesc + iDesc * NumDesc].getXVar());
                        int Y = int.Parse(res[jDesc + iDesc * NumDesc].getYVar());
                        CorrelationMatrix[X, Y] = res[jDesc + iDesc * NumDesc].getMainScore();

                    }
            }
            else
            {

                //return null;
                for (int iDesc = 0; iDesc < NumDesc; iDesc++)
                    for (int jDesc = 0; jDesc < NumDesc; jDesc++)
                    {
                        try
                        {
                            if (GlobalInfo.OptionsWindow.radioButtonPearson.Checked)
                                CorrelationMatrix[iDesc, jDesc] = (alglib.pearsoncorr2(ListValueDesc[iDesc].ToArray(), ListValueDesc[jDesc].ToArray()));
                            else if (GlobalInfo.OptionsWindow.radioButtonSpearman.Checked)
                                CorrelationMatrix[iDesc, jDesc] = (alglib.spearmancorr2(ListValueDesc[iDesc].ToArray(), ListValueDesc[jDesc].ToArray()));

                        }
                        catch
                        {
                            //Console.WriteLine("Input string is not a sequence of digits.");
                            return null;
                        }

                    }
            }
            return CorrelationMatrix;
        }

        private List<double>[] ExtractDesciptorAverageValuesList(bool IsFullScreen)
        {
            int NumDesc = CompleteScreening.ListDescriptors.GetListNameActives().Count;
            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            List<double>[] ListValueDesc = new List<double>[NumDesc];

            for (int i = 0; i < NumDesc; i++) ListValueDesc[i] = new List<double>();

            List<cPlate> PlatesToProcess = new List<cPlate>();
            if (IsFullScreen)
            {
                for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                {
                    cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);
                    PlatesToProcess.Add(CurrentPlateToProcess);
                }
            }
            else
            {
                PlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            }

            int ActiveDesc;

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < PlatesToProcess.Count; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = PlatesToProcess[PlateIdx];

                int NumActiveWells = CurrentPlateToProcess.GetNumberOfActiveWells();

                for (int Col = 0; Col < CompleteScreening.Columns; Col++)
                    for (int Row = 0; Row < CompleteScreening.Rows; Row++)
                    {
                        cWell TmpWell = CurrentPlateToProcess.GetWell(Col, Row, true);
                        if (TmpWell == null) continue;
                        ActiveDesc = 0;
                        for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
                        {
                            if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;
                            ListValueDesc[ActiveDesc++].Add(TmpWell.ListDescriptors[Desc].GetValue());
                        }
                    }
            }
            return ListValueDesc;
        }

        private void DisplayMatrix(double[,] Matrix, List<string> ListLabelX, List<string> ListLabelY, bool IsDisplayValues, string TitleForGraph, int SquareSize, bool IsToBeDisplayed, string PathName)
        {
            int IdxValue = 0;

            Series CurrentSeries = new Series("Matrix");
            CurrentSeries.ChartType = SeriesChartType.Point;
            // loop on all the desciptors
            for (int iDesc = 0; iDesc < ListLabelX.Count; iDesc++)
            {
                for (int jDesc = 0; jDesc < ListLabelY.Count; jDesc++)
                {
                    CurrentSeries.Points.AddXY(iDesc + 1, jDesc + 1);
                    CurrentSeries.Points[IdxValue].MarkerStyle = MarkerStyle.Square;
                    CurrentSeries.Points[IdxValue].MarkerSize = SquareSize;
                    CurrentSeries.Points[IdxValue].BorderColor = Color.Black;
                    CurrentSeries.Points[IdxValue].BorderWidth = 1;
                    double Value = Matrix[iDesc, jDesc];

                    if (IsDisplayValues) CurrentSeries.Points[IdxValue].Label = string.Format("{0:0.###}", Math.Abs(Value));

                    CurrentSeries.Points[IdxValue].ToolTip = Math.Abs(Value) + " <=> | " + Matrix[iDesc, jDesc].ToString() + " |";

                    int ConvertedValue = (int)(Math.Abs(Value) * (CompleteScreening.GlobalInfo.LUT[0].Length - 1));

                    CurrentSeries.Points[IdxValue++].Color = Color.FromArgb(CompleteScreening.GlobalInfo.LUT[0][ConvertedValue], CompleteScreening.GlobalInfo.LUT[1][ConvertedValue], CompleteScreening.GlobalInfo.LUT[2][ConvertedValue]);
                }
            }

            for (int iDesc = 0; iDesc < ListLabelX.Count * ListLabelX.Count; iDesc++)
                CurrentSeries.Points[iDesc].AxisLabel = CompleteScreening.ListDescriptors.GetListNameActives()[iDesc / ListLabelX.Count];

            SmartLabelStyle SStyle = new SmartLabelStyle();

            SimpleForm NewWindow = new SimpleForm();
            NewWindow.Height = SquareSize * ListLabelY.Count + 220;
            NewWindow.Width = SquareSize * ListLabelX.Count + 245;

            ChartArea CurrentChartArea = new ChartArea("Default");
            for (int i = 0; i < CompleteScreening.ListDescriptors.GetListNameActives().Count; i++)
            {
                CustomLabel lblY = new CustomLabel();
                lblY.ToPosition = i * 2 + 2;
                lblY.Text = ListLabelY[i];
                CurrentChartArea.AxisY.CustomLabels.Add(lblY);
            }

            CurrentChartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
            CurrentChartArea.BorderColor = Color.Black;
            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
            CurrentSeries.SmartLabelStyle.Enabled = true;

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);

            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].Minimum = 0;
            CurrentChartArea.Axes[0].Maximum = ListLabelX.Count + 1;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[1].Minimum = 0;
            CurrentChartArea.Axes[1].Maximum = ListLabelY.Count + 1;
            CurrentChartArea.AxisX.Interval = 1;
            CurrentChartArea.AxisY.Interval = 1;

            Title CurrentTitle = new Title(TitleForGraph);
            NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);
            NewWindow.chartForSimpleForm.Titles[0].Font = new Font("Arial", 9);

            if (IsToBeDisplayed) NewWindow.Show();
            else
                NewWindow.chartForSimpleForm.SaveImage(PathName + "_Matrix.emf", ChartImageFormat.Emf);
            NewWindow.Text = TitleForGraph;
            NewWindow.chartForSimpleForm.Update();
            NewWindow.chartForSimpleForm.Show();
            NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
        }



        #endregion

        #region Edit
        private void copyAverageValuesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.GetCurrentDisplayPlate().CopyValuestoClipBoard();
        }

        private void copyClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.GetCurrentDisplayPlate().CopyClassToClipBoard();
        }
        #endregion

        #region Normal Probability Plot
        /// <summary>
        /// Draw normal probability plot a complete screening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalProbabilityPlotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComputeAndDisplayMormalProbabilityPlot(true);
        }


        private void ComputeAndDisplayMormalProbabilityPlot(bool IsFullScreen)
        {
            if (CompleteScreening == null) return;


            int CurrentDescSel = comboBoxDescriptorToDisplay.SelectedIndex;

            //if(CurrentDes
            if (CompleteScreening.SelectedClass < 0) return;

            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            List<cPlate> PlatesToProcess = new List<cPlate>();
            if (IsFullScreen)
            {
                for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                {
                    cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);
                    PlatesToProcess.Add(CurrentPlateToProcess);
                }
            }
            else
            {
                PlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            }

            List<double> CurrentDesc = new List<double>();

            // loop on all the plate
            for (int PlateIdx = 0; PlateIdx < PlatesToProcess.Count; PlateIdx++)
            {
                cPlate CurrentPlateToProcess = PlatesToProcess[PlateIdx];

                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(IdxValue, IdxValue0, true);
                        if (TmpWell != null)
                        {
                            if (TmpWell.GetClassIdx() == CompleteScreening.SelectedClass)
                                CurrentDesc.Add(TmpWell.ListDescriptors[CurrentDescSel].GetValue());
                        }
                    }
            }

            if (CurrentDesc.Count < 3)
            {
                MessageBox.Show("Not enough data of class " + CompleteScreening.SelectedClass, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentDesc.Sort();
            double[] CenterNormDesc = new double[CurrentDesc.Count];
            CenterNormDesc = MeanCenteringStdStandarization(CurrentDesc.ToArray());

            int N = CurrentDesc.Count;
            double[] CumulativeProba = new double[CurrentDesc.Count];
            for (int i = 1; i < N - 1; i++)
                CumulativeProba[i] = (i - 0.3175) / (N + 0.365);

            CumulativeProba[N - 1] = Math.Pow(0.5, 1.0 / N);
            CumulativeProba[0] = 1 - CumulativeProba[N - 1];

            double[] PercentPointFunction = new double[CurrentDesc.Count];

            for (int i = 0; i < N; i++)
                PercentPointFunction[i] = alglib.normaldistr.invnormaldistribution(CumulativeProba[i]);

            SimpleForm NewWindow = new SimpleForm();
            NewWindow.Width = 600;
            NewWindow.Height = 600;

            NewWindow.Name = CompleteScreening.ListDescriptors[CurrentDescSel].GetName() + " normality plot : " + CompleteScreening.GetCurrentDisplayPlate().GetNumberOfActiveWells() + " points";
            Series CurrentSeries = new Series();
            CurrentSeries.ShadowOffset = 1;
            for (int Pt = 0; Pt < CurrentDesc.Count; Pt++)
            {
                CurrentSeries.Points.AddXY(PercentPointFunction[Pt], CenterNormDesc[Pt]);
                CurrentSeries.Points[Pt].Color = CompleteScreening.GlobalInfo.ListWellClasses[CompleteScreening.SelectedClass].ColourForDisplay;
                CurrentSeries.Points[Pt].MarkerStyle = MarkerStyle.Circle;
                CurrentSeries.Points[Pt].MarkerSize = 6;
            }

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;
            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackColor = Color.FromArgb(164, 164, 164);
            CurrentChartArea.Axes[0].MajorGrid.Enabled = true;
            CurrentChartArea.Axes[1].MajorGrid.Enabled = true;
            CurrentChartArea.AxisY.Minimum = CenterNormDesc[0];
            CurrentChartArea.AxisY.Maximum = CenterNormDesc[CurrentDesc.Count - 1];
            CurrentChartArea.AxisX.Minimum = -3;
            CurrentChartArea.AxisX.Maximum = 3;
            CurrentChartArea.AxisY.LabelStyle.Format = "N1";
            CurrentChartArea.AxisX.LabelStyle.Format = "N1";

            CurrentSeries.ChartType = SeriesChartType.Point;
            NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);

            double Anderson_DarlingValue = Anderson_Darling(CurrentDesc.ToArray());
            GlobalInfo.ConsoleWriteLine("Anderson-Darling Test: " + Anderson_DarlingValue);

            Title AndersonLegend = new Title();
            if (CurrentDesc.Count >= 5)
            {
                double Jarque_BeraValue;
                alglib.jarqueberatest(CurrentDesc.ToArray(), CurrentDesc.Count, out Jarque_BeraValue);
                GlobalInfo.ConsoleWriteLine("Jarque-Bera Test: " + Jarque_BeraValue);
                //  AndersonLegend.Text = "Jarque-Bera: " + String.Format("{0:0.####}", Jarque_BeraValue);
            }

            AndersonLegend.Text += "Anderson-Darling: " + String.Format("{0:0.##}", Anderson_DarlingValue);
            AndersonLegend.Alignment = ContentAlignment.MiddleCenter;
            AndersonLegend.Docking = Docking.Bottom;
            AndersonLegend.TextOrientation = TextOrientation.Horizontal;

            NewWindow.chartForSimpleForm.Titles.Add(AndersonLegend);

            Title MainLegend = new Title();
            MainLegend.Text = CompleteScreening.ListDescriptors[CurrentDescSel].GetName();
            MainLegend.Docking = Docking.Top;
            MainLegend.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            NewWindow.chartForSimpleForm.Titles.Add(MainLegend);

            NewWindow.chartForSimpleForm.Series.Add("TrendLine");
            NewWindow.chartForSimpleForm.Series["TrendLine"].ChartType = SeriesChartType.Line;
            NewWindow.chartForSimpleForm.Series["TrendLine"].BorderWidth = 1;
            NewWindow.chartForSimpleForm.Series["TrendLine"].Color = Color.Red;
            // Line of best fit is linear
            string typeRegression = "Linear";//"Exponential";//
            // The number of days for Forecasting
            string forecasting = "1";
            // Show Error as a range chart.
            string error = "false";
            // Show Forecasting Error as a range chart.
            string forecastingError = "false";
            // Formula parameters
            string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;
            NewWindow.chartForSimpleForm.Series[0].Sort(PointSortOrder.Ascending, "X");
            // Create Forecasting Series.
            NewWindow.chartForSimpleForm.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, NewWindow.chartForSimpleForm.Series[0], NewWindow.chartForSimpleForm.Series["TrendLine"]);

            //  NewWindow.Text = "Normal Probability Plot / " +;
            NewWindow.Show();

            if (IsFullScreen)
            {
                NewWindow.Text = CurrentDesc.Count + " points";
            }
            else
            {
                NewWindow.Text = CompleteScreening.GetCurrentDisplayPlate().Name + " : " + CurrentDesc.Count + " points";
            }
            NewWindow.chartForSimpleForm.Update();
            NewWindow.chartForSimpleForm.Show();
            NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
        }
        #endregion

        #region XY scatter points
        private void xYScatterPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cFeedBackMessage MessageReturned;

            cViewer2DScatterPoint V1D = new cViewer2DScatterPoint();
            V1D.Chart.IsSelectable = true;
            //V1D.Chart.LabelAxisX = "Well Index";
            //V1D.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].GetName();
            //V1D.Chart.BackgroundColor = Color.LightYellow;
            //V1D.Chart.IsXAxis = true;


            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //cDisplayToWindow CDW1 = new cDisplayToWindow();
            // cListWell ListWellsToProcess = new cListWell();

            if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                //cExtendedTable DataFromPlate = new cExtendedTable(CompleteScreening.GetCurrentDisplayPlate().ListActiveWells,
                //                                CompleteScreening.ListDescriptors.CurrentSelectedDescriptor);

                List<cWell> ListWellsToProcess = new List<cWell>();

                //foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                    if (item.GetClassIdx() != -1)
                        if (ListClassSelected[item.GetClassIdx()] == 1) ListWellsToProcess.Add(item);

                cExtendedTable DataFromPlate = new cExtendedTable(ListWellsToProcess, true);
                DataFromPlate.Name = CompleteScreening.GetCurrentDisplayPlate().Name;

                V1D.Chart.IsShadow = true;
                V1D.Chart.IsBorder = true;
                V1D.Chart.IsSelectable = true;
                V1D.Chart.CurrentTitle.Tag = CompleteScreening.GetCurrentDisplayPlate();
                V1D.SetInputData(DataFromPlate);
                V1D.Run();

                cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
                Designer0.SetInputData(V1D.GetOutPut());
                Designer0.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(Designer0.GetOutPut());
                Disp0.Title = "2D Scatter points graph - " + DataFromPlate[0].Count + " wells.";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();
            }
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                V1D.Chart.MarkerSize = 5;
                V1D.Chart.IsBorder = false;

                //List<cWell> ListWell = new List<cWell>();
                //foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                //    foreach (cWell TmpWell in TmpPlate.ListActiveWells)
                //        ListWell.Add(TmpWell);

                //cExtendedTable DataFromPlate = new cExtendedTable(ListWell,
                //                                CompleteScreening.ListDescriptors.CurrentSelectedDescriptor);

                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if (item.GetClassIdx() != -1)
                            if (ListClassSelected[item.GetClassIdx()] == 1) ListWellsToProcess.Add(item);

                cExtendedTable DataFromPlate = new cExtendedTable(ListWellsToProcess, true);

                DataFromPlate.Name = CompleteScreening.Name + " - " + CompleteScreening.ListPlatesActive.Count + " plates";

                V1D.SetInputData(DataFromPlate);
                V1D.Run();

                cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
                Designer0.SetInputData(V1D.GetOutPut());
                Designer0.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(Designer0.GetOutPut());
                Disp0.Title = "2D Scatter points graph - " + DataFromPlate[0].Count + " wells.";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();

            }
            else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab CDT = new cDesignerTab();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    //cExtendedTable DataFromPlate = new cExtendedTable(TmpPlate.ListActiveWells,
                    //                            CompleteScreening.ListDescriptors.CurrentSelectedDescriptor);

                    List<cWell> ListWellsToProcess = new List<cWell>();

                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if (item.GetClassIdx() != -1)
                            if (ListClassSelected[item.GetClassIdx()] == 1) ListWellsToProcess.Add(item);

                    cExtendedTable DataFromPlate = new cExtendedTable(ListWellsToProcess, true);

                    DataFromPlate.Name = TmpPlate.Name;

                    V1D = new cViewer2DScatterPoint();
                    V1D.Chart.IsSelectable = true;
                    V1D.Chart.LabelAxisX = "Well Index";
                    V1D.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                    V1D.Chart.BackgroundColor = Color.LightYellow;
                    V1D.Chart.IsXAxis = true;
                    V1D.Chart.CurrentTitle.Tag = TmpPlate;
                    V1D.SetInputData(DataFromPlate);
                    V1D.Title = TmpPlate.Name;
                    V1D.Run();

                    CDT.SetInputData(V1D.GetOutPut());
                }

                CDT.Run();

                cDisplayToWindow Disp0 = new cDisplayToWindow();
                Disp0.SetInputData(CDT.GetOutPut());
                Disp0.Title = "2D Scatter points graphs";
                if (!Disp0.Run().IsSucceed) return;
                Disp0.Display();
            }


            //if (CompleteScreening == null) return;

            //SimpleFormForXY FormToDisplayXY = new SimpleFormForXY(false);
            //FormToDisplayXY.CompleteScreening = CompleteScreening;

            //for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            //{
            //    FormToDisplayXY.comboBoxDescriptorX.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
            //    FormToDisplayXY.comboBoxDescriptorY.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
            //}

            //FormToDisplayXY.comboBoxDescriptorX.SelectedIndex = 0;
            //FormToDisplayXY.comboBoxDescriptorY.SelectedIndex = 0;


            //FormToDisplayXY.DisplayXY();
            //FormToDisplayXY.ShowDialog();

            //return;
        }


        #endregion

        #region Plugins Management
        private void HCSAnalyzer_Shown(object sender, EventArgs e)
        {
            BuildPluginMenu();
        }

        private void BuildPluginMenu()
        {
            List<PluginDescriptor> paList = null;
            try
            {
                paList = PluginDescriptor.GetList(Application.StartupPath + @"\Plugins");
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory("Plugins");
                paList = PluginDescriptor.GetList(Application.StartupPath + @"\Plugins");
                //MessageBox.Show("Error: " + e.Message, "Plugin's directory not Found" + "\n No Plugin will be loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ToolStripMenuItem currentMenu = null;

            foreach (PluginDescriptor pluginDescriptor in paList)
            {
                currentMenu = pluginsToolStripMenuItem;

                string[] subMenu = pluginDescriptor.MenuPath.Split('|');
                if (pluginDescriptor.MenuPath.Length != 0)
                {
                    foreach (string sm in subMenu)
                    {
                        string menuName = sm.Trim();

                        //if submenu exist , get in
                        if (currentMenu.DropDownItems.ContainsKey(menuName))
                        {
                            currentMenu = (ToolStripMenuItem)currentMenu.DropDownItems[menuName];
                        }
                        else//if not, create it first.
                        {
                            ToolStripMenuItem tsmMenu = new ToolStripMenuItem(menuName);
                            currentMenu.DropDownItems.Add(tsmMenu);
                            tsmMenu.Name = menuName;
                            currentMenu = tsmMenu;
                        }
                    }
                }

                ToolStripMenuItem tsmiName =
                    new ToolStripMenuItem(pluginDescriptor.Name + @" - " + pluginDescriptor.Author);
                currentMenu.DropDownItems.Add(tsmiName);
                tsmiName.Tag = pluginDescriptor;
                tsmiName.Name = pluginDescriptor.Name;
                currentMenu = tsmiName;
                currentMenu.Click += new EventHandler(toolMenuItem_Click);
            }
        }

        private void toolMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem s = (ToolStripMenuItem)sender;

                PluginDescriptor p = (PluginDescriptor)s.Tag;
                Plugin.CurrentScreen = CompleteScreening;
                p.Instanciate();
            }
            catch (PluginException ex)
            {
                MessageBox.Show(ex.Message, "Plugin information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        private void HCSAnalyzer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalInfo.CurrentScreen != null)
                GlobalInfo.CurrentScreen.Close3DView();
            this.Dispose();
        }

        private void SwitchVizuMode(object sender, EventArgs e)
        {
            GlobalInfo.SwitchVisuMode();
        }

        #region DRC management

        private void doseResponseDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.WindowForDRCDesign.IsDisposed) GlobalInfo.WindowForDRCDesign = new FormForDRCDesign();
            GlobalInfo.WindowForDRCDesign.Visible = true;
        }

        private void convertDRCToWellToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult ResWin = MessageBox.Show("By applying this process, the current screening will be entirely updated ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResWin == System.Windows.Forms.DialogResult.No) return;
            //foreach (cDescriptorsType DescType in CompleteScreening.ListDescriptors)
            //{
            //    CompleteScreening.ListDescriptors.RemoveDescUnSafe(DescType, CompleteScreening);
            //}


            if (CompleteScreening != null) CompleteScreening.Close3DView();

            //   CompleteScreening.ListDescriptors.RemoveDesc(CompleteScreening.ListDescriptors[IntToTransfer], CompleteScreening);
            cScreening MergedScreening = new cScreening("Merged Screen", GlobalInfo);
            MergedScreening.PanelForPlate = this.panelForPlate;

            MergedScreening.Rows = CompleteScreening.Rows;
            MergedScreening.Columns = CompleteScreening.Columns;
            MergedScreening.ListPlatesAvailable = new cExtendPlateList();

            // create the descriptor
            MergedScreening.ListDescriptors.Clean();

            int Idesc = 0;

            List<cDescriptorsType> ListDescType = new List<cDescriptorsType>();

            for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
            {
                if (!CompleteScreening.ListDescriptors[i].IsActive()) continue;

                cDescriptorsType DescEC50 = new cDescriptorsType("EC50_" + CompleteScreening.ListDescriptors[i].GetName(), true, 1, GlobalInfo);
                ListDescType.Add(DescEC50);
                MergedScreening.ListDescriptors.AddNew(DescEC50);

                cDescriptorsType DescTop = new cDescriptorsType("Top_" + CompleteScreening.ListDescriptors[i].GetName(), true, 1, GlobalInfo);
                ListDescType.Add(DescTop);
                MergedScreening.ListDescriptors.AddNew(DescTop);

                cDescriptorsType DescBottom = new cDescriptorsType("Bottom_" + CompleteScreening.ListDescriptors[i].GetName(), true, 1, GlobalInfo);
                ListDescType.Add(DescBottom);
                MergedScreening.ListDescriptors.AddNew(DescBottom);

                cDescriptorsType DescSlope = new cDescriptorsType("Slope_" + CompleteScreening.ListDescriptors[i].GetName(), true, 1, GlobalInfo);
                ListDescType.Add(DescSlope);
                MergedScreening.ListDescriptors.AddNew(DescSlope);

                Idesc++;
            }

            MergedScreening.ListDescriptors.CurrentSelectedDescriptorIdx = 0;
            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesAvailable)
            {

                cPlate NewPlate = new cPlate("Cpds", CurrentPlate.Name + " Merged", MergedScreening);
                // check if the plate exist already
                MergedScreening.AddPlate(NewPlate);

                foreach (cDRC_Region CurrentRegion in CurrentPlate.ListDRCRegions)
                {

                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    Idesc = 0;
                    int IDESCBase = 0;

                    for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                    {
                        if (!CompleteScreening.ListDescriptors[i].IsActive()) continue;

                        cDRC CurrentDRC = CurrentRegion.GetDRC(CompleteScreening.ListDescriptors[IDESCBase++]);

                        cDescriptor Desc_EC50 = new cDescriptor(CurrentDRC.EC50, ListDescType[Idesc++], CompleteScreening);
                        LDesc.Add(Desc_EC50);

                        cDescriptor Desc_Top = new cDescriptor(CurrentDRC.Top, ListDescType[Idesc++], CompleteScreening);
                        LDesc.Add(Desc_Top);

                        cDescriptor Desc_Bottom = new cDescriptor(CurrentDRC.Bottom, ListDescType[Idesc++], CompleteScreening);
                        LDesc.Add(Desc_Bottom);

                        cDescriptor Desc_Slope = new cDescriptor(CurrentDRC.Slope, ListDescType[Idesc++], CompleteScreening);
                        LDesc.Add(Desc_Slope);
                    }
                    cWell NewWell = new cWell(LDesc, CurrentRegion.PosXMin + 1, CurrentRegion.PosYMin + 1, MergedScreening, NewPlate);
                    NewWell.Name = "DRC [" + CurrentRegion.PosXMin + ":" + CurrentRegion.PosYMin + "]";
                    NewPlate.AddWell(NewWell);
                }
            }

            // PanelList[0].CurrentScreening.ListPlatesActive.Clear();
            // PanelList[0].CurrentScreening.GlobalInfo.WindowHCSAnalyzer.RefreshInfoScreeningRichBox();
            MergedScreening.ListPlatesActive = new cExtendPlateList();

            for (int i = 0; i < MergedScreening.ListPlatesAvailable.Count; i++)
            {
                MergedScreening.ListPlatesActive.Add(MergedScreening.ListPlatesAvailable[i]);
                // MergedScreening.GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.Items.Add(PanelList[0].CurrentScreening.ListPlatesActive[i].Name);
            }
            //PanelList[0].CurrentScreening.CurrentDisplayPlateIdx = 0;
            //PanelList[0].CurrentScreening.GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.SelectedIndex = 0;

            //PanelList[0].CurrentScreening.GetCurrentDisplayPlate().DisplayDistribution(PanelList[0].CurrentScreening.ListDescriptors.CurrentSelectedDescriptor, false);




            CompleteScreening.ListDescriptors = MergedScreening.ListDescriptors;
            CompleteScreening.ListPlatesAvailable = MergedScreening.ListPlatesAvailable;
            CompleteScreening.ListPlatesActive = MergedScreening.ListPlatesActive;

            CompleteScreening.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, true);
        }

        private void displayDRCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions == null) return;

            int h = 0;
            FormToDisplayDRC WindowforDRCsDisplay = new FormToDisplayDRC();
            List<string> imagenames = new List<string>();
            int cpt = 0;
            foreach (cDRC_Region TmpRegion in CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions)
            {

                List<cDRC> ListDRC = new List<cDRC>();
                for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                {
                    if (CompleteScreening.ListDescriptors[i].IsActive())
                    {
                        cDRC CurrentDRC = new cDRC(TmpRegion, CompleteScreening.ListDescriptors[i]);

                        ListDRC.Add(CurrentDRC);


                    }

                }
                if (ListDRC.Count != 0)
                {

                    cDRCDisplay DRCDisplay = new cDRCDisplay(ListDRC, GlobalInfo);

                    imagenames.Add(@"C:\" + cpt + ".jpg");

                    if (DRCDisplay.CurrentChart.Series.Count == 0) continue;

                    DRCDisplay.CurrentChart.Location = new Point((DRCDisplay.CurrentChart.Width + 50) * 0, (DRCDisplay.CurrentChart.Height + 10 + DRCDisplay.CurrentRichTextBox.Height) * h++);
                    DRCDisplay.CurrentRichTextBox.Location = new Point(DRCDisplay.CurrentChart.Location.X, DRCDisplay.CurrentChart.Location.Y + DRCDisplay.CurrentChart.Height + 5);

                    WindowforDRCsDisplay.LChart.Add(DRCDisplay.CurrentChart);
                    WindowforDRCsDisplay.LRichTextBox.Add(DRCDisplay.CurrentRichTextBox);
                    DRCDisplay.CurrentChart.SaveImage(@"C:\" + cpt + ".jpg", ChartImageFormat.Jpeg);
                }
                cpt++;
            }










            //Clipboard.SetDataObject(Image.FromFile(@"c:\1.jpg"));
            //xlWorkSheet.Range["A1"].Select();
            //xlWorkSheet.PasteSpecial();
            //add some text 
            //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
            //xlWorkSheet.Cells[2, 1] = "Adding picture in Excel File";
            for (int i = 0; i < imagenames.Count; i++)
            {


                // xlWorkSheet.Shapes.AddPicture(imagenames[i], Microsoft.Office.Core.MsoTriState.msoFalse,
                //Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 1+50*i, 300, 45);

            }




            StreamWriter filecsv = null;
            for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
            {

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                // xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                // Microsoft.Office.Interop.Excel.Range cell = GetMyPictureCELL(taperSheet);

                List<cDRC> ListDRC = new List<cDRC>();
                foreach (cDRC_Region TmpRegion in CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions)
                {


                    if (CompleteScreening.ListDescriptors[i].IsActive())
                    {
                        cDRC CurrentDRC = new cDRC(TmpRegion, CompleteScreening.ListDescriptors[i]);

                        ListDRC.Add(CurrentDRC);


                    }

                }


                string str = CompleteScreening.ListDescriptors[i].GetName();
                str = str.Replace("\\", " ");
                str = str.Replace("/", " ");
                //filecsv = new StreamWriter(@"C:\" + str + ".xls");
                //String name = CompleteScreening.GlobalInfo.CurrentScreen.CurrentDisplayPlateIdx.ToString();
                //filecsv.WriteLine("Pos" + "," + "EC50" + "," + "Bottom" + "," + "Top" + "," + "Slope" + "," + "RelativeError");

                xlWorkSheet.Cells[1, 1] = "Pos"; xlWorkSheet.Cells[1, 2] = "EC50"; xlWorkSheet.Cells[1, 3] = "Top"; xlWorkSheet.Cells[1, 4] = "Bottom";
                xlWorkSheet.Cells[1, 5] = "Slope";

                for (int j = 0; j < ListDRC.Count; j++)
                {



                    xlWorkSheet.Cells[j + 2, 1] = ListDRC[j].AssociatedDRCRegion.PosXMin + ":" + ListDRC[j].AssociatedDRCRegion.PosYMin;
                    xlWorkSheet.Cells[j + 2, 2] = ListDRC[j].EC50;
                    xlWorkSheet.Cells[j + 2, 2].AddComment(" ");
                    xlWorkSheet.Cells[j + 2, 2].Comment.Shape.Fill.UserPicture(imagenames[j]);
                    xlWorkSheet.Cells[j + 2, 3] = ListDRC[j].Top;
                    xlWorkSheet.Cells[j + 2, 4] = ListDRC[j].Bottom;
                    xlWorkSheet.Cells[j + 2, 5] = ListDRC[j].Slope;


                    //filecsv.Write(ListDRC[j].AssociatedDRCRegion.PosXMin + ":" + ListDRC[j].AssociatedDRCRegion.PosYMin); filecsv.Write(",");
                    //filecsv.Write(ListDRC[j].EC50); filecsv.Write(","); filecsv.Write(ListDRC[j].Bottom); filecsv.Write(","); filecsv.Write(ListDRC[j].Top);
                    //filecsv.Write(","); filecsv.Write(ListDRC[j].Slope); filecsv.Write(","); filecsv.Write(ListDRC[j].RelativeError); filecsv.WriteLine();

                }

                // filecsv.Close();
                xlWorkBook.SaveAs(@"C:\" + str + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
               Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }







            WindowforDRCsDisplay.panelForDRC.Controls.AddRange(WindowforDRCsDisplay.LChart.ToArray());
            WindowforDRCsDisplay.panelForDRC.Controls.AddRange(WindowforDRCsDisplay.LRichTextBox.ToArray());
            WindowforDRCsDisplay.Show();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }




        private void displayRespondingDRCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions == null) return;

            FormForDRCSelection WindowSelectionDRC = new FormForDRCSelection();
            if (WindowSelectionDRC.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            if (WindowSelectionDRC.checkBoxMOAClassification.Checked == false)
            {
                int h = 0;
                FormToDisplayDRC WindowforDRCsDisplay = new FormToDisplayDRC();

                foreach (cDRC_Region TmpRegion in CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions)
                {
                    int cpt = 0;
                    List<cDRC> ListDRC = new List<cDRC>();
                    for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                    {
                        if (CompleteScreening.ListDescriptors[i].IsActive())
                        {
                            cDRC CurrentDRC = new cDRC(TmpRegion, CompleteScreening.ListDescriptors[i]);
                            if (CurrentDRC.IsResponding(WindowSelectionDRC) == 1)
                            {
                                ListDRC.Add(CurrentDRC);
                                cpt++;
                            }
                        }
                    }
                    if (ListDRC.Count != 0)
                    {
                        cDRCDisplay DRCDisplay = new cDRCDisplay(ListDRC, GlobalInfo);


                        if (DRCDisplay.CurrentChart.Series.Count == 0) continue;

                        DRCDisplay.CurrentChart.Location = new Point((DRCDisplay.CurrentChart.Width + 50) * 0, (DRCDisplay.CurrentChart.Height + 10 + DRCDisplay.CurrentRichTextBox.Height) * h++);
                        DRCDisplay.CurrentRichTextBox.Location = new Point(DRCDisplay.CurrentChart.Location.X, DRCDisplay.CurrentChart.Location.Y + DRCDisplay.CurrentChart.Height + 5);

                        WindowforDRCsDisplay.LChart.Add(DRCDisplay.CurrentChart);
                        WindowforDRCsDisplay.LRichTextBox.Add(DRCDisplay.CurrentRichTextBox);
                    }
                }

                WindowforDRCsDisplay.panelForDRC.Controls.AddRange(WindowforDRCsDisplay.LChart.ToArray());
                WindowforDRCsDisplay.panelForDRC.Controls.AddRange(WindowforDRCsDisplay.LRichTextBox.ToArray());
                WindowforDRCsDisplay.Show();
                return;
            }


            System.Windows.Forms.DialogResult ResWin = MessageBox.Show("By applying this process, the current screening will be entirely updated ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResWin == System.Windows.Forms.DialogResult.No) return;



            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
            {
                foreach (cDRC_Region TmpRegion in CurrentPlate.ListDRCRegions)
                {
                    int cpt = 0;
                    //List<cDRC> ListDRC = new List<cDRC>();
                    //for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                    //{
                    //  if (CompleteScreening.ListDescriptors[i].IsActive())
                    //    {
                    //        cDRC CurrentDRC = new cDRC(TmpRegion, CompleteScreening.ListDescriptors[i]);
                    //        if (CurrentDRC.IsResponding(WindowSelectionDRC))
                    //        {
                    //            ListDRC.Add(CurrentDRC);
                    //            cpt++;
                    //        }
                    //    }


                    //}
                    List<int> ResDescActive = TmpRegion.GetListRespondingDescritpors(CompleteScreening, WindowSelectionDRC);

                    for (int j = 0; j < TmpRegion.NumReplicate; j++)
                        for (int i = 0; i < TmpRegion.NumConcentrations; i++)
                        {

                            cWell CurrentWell = TmpRegion.GetListWells()[j][i];
                            if (CurrentWell == null) continue;

                            for (int IdxDesc = 0; IdxDesc < ResDescActive.Count; IdxDesc++)
                            {
                                if (ResDescActive[IdxDesc] == -1) continue;

                                //CurrentWell.ListDescriptors[IdxDesc].HistoValues = new double[1];
                                CurrentWell.ListDescriptors[IdxDesc].SetHistoValues((double)ResDescActive[IdxDesc]);
                                if ((i == 0) && (j == 0))
                                    CurrentWell.SetClass(0);
                                else
                                    CurrentWell.SetAsNoneSelected();
                                //[0] = ResDescActive[IdxDesc];   
                                CurrentWell.ListDescriptors[IdxDesc].UpDateDescriptorStatistics();

                            }

                        }
                }
                CurrentPlate.UpDataMinMax();
            }
        }

        #endregion

        private void xYZScatterPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            GlobalInfo.OptionsWindow.checkBoxConnectDRCPts.Checked = false;
            FormFor3DDataDisplay FormToDisplayXYZ = new FormFor3DDataDisplay(false, CompleteScreening);
            for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            {
                FormToDisplayXYZ.comboBoxDescriptorX.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorY.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorZ.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
            }
            FormToDisplayXYZ.Show();
            FormToDisplayXYZ.comboBoxDescriptorX.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorY.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorZ.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            return;
        }

        private void xYZScatterPointsToolStripMenuItemFullScreen_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            GlobalInfo.OptionsWindow.checkBoxConnectDRCPts.Checked = false;
            FormFor3DDataDisplay FormToDisplayXYZ = new FormFor3DDataDisplay(true, CompleteScreening);
            for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            {
                FormToDisplayXYZ.comboBoxDescriptorX.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorY.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorZ.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
            }
            FormToDisplayXYZ.Show();
            FormToDisplayXYZ.comboBoxDescriptorX.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorY.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorZ.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            return;

        }

        #region Distributions
        private void distributionsModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInfo.SwitchDistributionMode();
        }

        private void displayReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (CompleteScreening.Reference == null)
            {
                MessageBox.Show("No reference curve generated. Switch to Distribution mode.\n", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormTMP TMPWin = new FormTMP();
            cExtendedList ListValues = CompleteScreening.Reference.GetValues(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx);
            ListValues.Name = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();

            cPanelHisto PanelHisto = new cPanelHisto(ListValues, eGraphType.HISTOGRAM, eOrientation.HORIZONTAL);

            //  cDisplayHisto CpdToDisplayHisto = new cDisplayHisto();
            TMPWin.Controls.Add(PanelHisto.WindowForPanelHisto.panelForGraphContainer);

            //TMPWin.panel.Controls.Add(CpdToDisplayHisto);
            TMPWin.ShowDialog();


            //  cWindowToDisplayHisto NewWindow = new cWindowToDisplayHisto(CompleteScreening,CompleteScreening.Reference.GetValues(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor));
            //   NewWindow.Show();
            //    NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            // cWindowToDisplayScatter NewWindow = new cWindowToDisplayScatter();
            //   NewWindow.chartForSimpleForm.Controls.Add(CompleteScreening.Reference.GetChart(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor));
            //  NewWindow.Show();
            //cDisplayGraph DispGraph = new cDisplayGraph(CompleteScreening.Reference[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].ToArray(),
            //    CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].GetName() + " - Reference distribution.");
        }
        #endregion







        //public void DisplayMINE(List<double>[] ListValueDesc)
        //{
        //    int NumDesc = ListValueDesc.Length;

        //    double[,] CorrelationMatrix = new double[NumDesc, NumDesc];

        //    double[][] dataset1 = new double[NumDesc][];
        //    string[] VarNames = new string[NumDesc];

        //    for (int iDesc = 0; iDesc < NumDesc; iDesc++)
        //    {
        //        dataset1[iDesc] = new double[ListValueDesc[iDesc].Count];

        //        Array.Copy(ListValueDesc[iDesc].ToArray(), dataset1[iDesc], ListValueDesc[iDesc].Count);
        //        VarNames[iDesc] = iDesc.ToString();
        //    }
        //    data.Dataset data1 = new data.Dataset(dataset1, VarNames, 0);
        //    VarPairQueue Qu = new VarPairQueue(data1);

        //    for (int iDesc = 0; iDesc < NumDesc; iDesc++)
        //        for (int jDesc = 0; jDesc < iDesc; jDesc++)
        //        {
        //            Qu.addPair(iDesc, jDesc);
        //        }
        //    Analysis ana = new Analysis(data1, Qu);
        //    AnalysisParameters param = new AnalysisParameters();
        //    double resparam = param.commonValsThreshold;

        //    //    analysis.results.FullResult Full = new analysis.results.FullResult();
        //    //List<analysis.results.BriefResult> Brief = new List<analysis.results.BriefResult>();
        //    //analysis.results.BriefResult Brief = new analysis.results.BriefResult();



        //    java.lang.Class t = java.lang.Class.forName("analysis.results.BriefResult");

        //    //java.lang.Class restype = null;
        //    ana.analyzePairs(t, param);

        //    //   object o =  (ana.varPairQueue().peek());
        //    //   ana.getClass();
        //    //  int resNum = ana.numResults();
        //    analysis.results.Result[] res = ana.getSortedResults();

        //    List<string[]> ListValues = new List<string[]>();
        //    List<string> NameX = CompleteScreening.ListDescriptors.GetListNameActives();

        //    List<bool> ListIscolor = new List<bool>();

        //    for (int Idx = 0; Idx < res.Length; Idx++)
        //    {
        //        ListValues.Add(res[Idx].toString().Split(','));
        //        ListValues[Idx][0] = NameX[int.Parse(ListValues[Idx][0])];
        //        ListValues[Idx][1] = NameX[int.Parse(ListValues[Idx][1])];
        //    }
        //    string[] ListNames = res[0].getHeader().Split(',');


        //    ListNames[0] = "Descriptor A";
        //    ListNames[1] = "Descriptor B";


        //    for (int NIdx = 0; NIdx < ListNames.Length; NIdx++)
        //    {
        //        if (NIdx == 0) ListIscolor.Add(false);
        //        else if (NIdx == 1) ListIscolor.Add(false);
        //        else ListIscolor.Add(true);

        //    }

        //    cDisplayTable DisplayForTable = new cDisplayTable("MINE Analysis results", ListNames, ListValues, GlobalInfo, true);

        //}

        private void findPathwayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //    if (CompleteScreening == null) return;
            //    FormForNameRequest FormForRequest = new FormForNameRequest();
            //    if (FormForRequest.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //    int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

            //    FormForKeggGene KeggWin = new FormForKeggGene();

            //    string[] intersection_gene_pathways = new string[1];
            //    string[] Pathways = { FormForRequest.textBoxForName.Text };
            //    intersection_gene_pathways = ServKegg.get_genes_by_pathway("path:" + Pathways[0]);
            //    if ((Pathways == null) || (Pathways.Length == 0) || (Pathways[0] == ""))
            //    {
            //        MessageBox.Show("No pathway founded !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }

            //    string[] fg_list = { "black" };
            //    string[] bg_list = { "orange" };

            //    string pathway_map_html = "";
            //    //  KEGG ServKegg = new KEGG();
            //    string[] ListGenesinPathway = ServKegg.get_genes_by_pathway("path:" + Pathways[0]);
            //    if (ListGenesinPathway.Length == 0)
            //    {
            //        return;
            //    }
            //    double[] ListValues = new double[ListGenesinPathway.Length];
            //    int IDxGeneOfInterest = 0;
            //    foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
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
            //                    ListValues[IdxGene] = CurrentWell.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetValue();
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

            //        int ConvertedValue = (int)((((CompleteScreening.GlobalInfo.LUTs.LUT_GREEN_TO_RED[0].Length - 1) * (ListValues[IdxCol] - MinValue)) / (MaxValue - MinValue)));

            //        Color Coul = Color.FromArgb(CompleteScreening.GlobalInfo.LUTs.LUT_GREEN_TO_RED[0][ConvertedValue], CompleteScreening.GlobalInfo.LUTs.LUT_GREEN_TO_RED[1][ConvertedValue], CompleteScreening.GlobalInfo.LUTs.LUT_GREEN_TO_RED[2][ConvertedValue]);

            //        if (IdxCol == IDxGeneOfInterest)
            //            fg_list[IdxCol] = "white";
            //        else
            //            fg_list[IdxCol] = "#000000";
            //        bg_list[IdxCol] = "#" + Coul.Name.Remove(0, 2);

            //    }

            //    //  foreach (string item in ListP.listBoxPathways.SelectedItems)
            //    {
            //        pathway_map_html = ServKegg.get_html_of_colored_pathway_by_objects(Pathways[0], ListGenesinPathway, fg_list, bg_list);
            //    }

            //    pathway_map_html = ServKegg.get_html_of_colored_pathway_by_objects((string)(Pathways[0]), intersection_gene_pathways, fg_list, bg_list);

            //    // FormForKegg KeggWin = new FormForKegg();
            //    if (pathway_map_html.Length == 0) return;

            //    //
            //    //KeggWin.Show();
            //    //ListP.listBoxPathways.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
            //    KeggWin.webBrowser.Navigate(pathway_map_html);

            //    KeggWin.Show();
        }



        private void panelForPlate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CompleteScreening == null) return;


            int ScrollShiftY = this.panelForPlate.VerticalScroll.Value;
            int ScrollShiftX = this.panelForPlate.HorizontalScroll.Value;
            int Gutter = (int)GlobalInfo.OptionsWindow.numericUpDownGutter.Value;

            int PosX = (int)((e.X - ScrollShiftX) / (GlobalInfo.SizeHistoWidth + Gutter));
            int PosY = (int)((e.Y - ScrollShiftY) / (GlobalInfo.SizeHistoHeight + Gutter));


            bool OnlyOnSelected = false;
            if ((PosX == 0) && (PosY == 0))
            {
                GlobalSelection(false);
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
                return;
            }


            if ((PosX == 0) && (PosY > 0))
            {
                for (int col = 0; col < CompleteScreening.Columns; col++)
                {
                    if (CompleteScreening.IsSelectionApplyToAllPlates)
                    {
                        int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

                        for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                        {
                            cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx);
                            cWell TmpWell = CurrentPlateToProcess.GetWell(col, PosY - 1, OnlyOnSelected);
                            if (TmpWell == null) continue;

                            if (CompleteScreening.GetSelectionType() == -1)
                                TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());
                        }
                    }
                    else
                    {
                        cWell TmpWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(col, PosY - 1, OnlyOnSelected);
                        if (TmpWell != null)
                        {
                            if (CompleteScreening.GetSelectionType() == -1) TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());
                        }
                    }
                }
                CompleteScreening.GetCurrentDisplayPlate().UpdateNumberOfClass();
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
                return;
            }

            if ((PosY == 0) && (PosX > 0))
            {
                for (int row = 0; row < CompleteScreening.Rows; row++)
                {
                    if (CompleteScreening.IsSelectionApplyToAllPlates)
                    {
                        int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;

                        for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
                        {
                            cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(PlateIdx);
                            cWell TmpWell = CurrentPlateToProcess.GetWell(PosX - 1, row, OnlyOnSelected);
                            if (TmpWell == null) continue;

                            if (CompleteScreening.GetSelectionType() == -1)
                                TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());
                        }
                    }
                    else
                    {
                        cWell TmpWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(PosX - 1, row, OnlyOnSelected);
                        if (TmpWell != null)
                        {
                            if (CompleteScreening.GetSelectionType() == -1) TmpWell.SetAsNoneSelected();
                            else
                                TmpWell.SetClass(CompleteScreening.GetSelectionType());
                        }
                    }
                }
                CompleteScreening.GetCurrentDisplayPlate().UpdateNumberOfClass();
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
                return;
            }
        }

        private void displayGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cExtendPlateList ListToProcess = new cExtendPlateList();
            ListToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            ComputeAndDisplayLDA(ListToProcess);
        }


        public string GenerateLDADescriptor(cExtendPlateList PlatesToProcess, int NeutralClass)
        {

            int NumWell = 0;
            int NumWellForLearning = 0;
            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                NumWellForLearning += CurrentPlate.GetNumberOfActiveWellsButClass(NeutralClass);
                NumWell += CompleteScreening.GetCurrentDisplayPlate().GetNumberOfActiveWells();
            }

            if (NumWellForLearning == 0)
            {
                MessageBox.Show("No well identified !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            int NumDesc = CompleteScreening.GetNumberOfActiveDescriptor();

            if (NumDesc <= 1)
            {
                MessageBox.Show("More than one descriptor are required for this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            double[,] DataForLDA = new double[NumWellForLearning, CompleteScreening.GetNumberOfActiveDescriptor() + 1];

            //   return;
            Matrix EigenVectors = LDAComputation(DataForLDA, NumWellForLearning, NumWell, NumDesc, NeutralClass, PlatesToProcess);


            string AxeName = "";
            int IDxDesc = 0;
            //for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
            //{
            //    if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;

            //    //   AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];
            //}

            for (int Idx = 0; Idx < CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count; Idx++)
            {

                if (CompleteScreening.ListDescriptors[Idx].IsActive())
                    if (CompleteScreening.ListDescriptors[Idx].GetBinNumber() == 1)
                    {
                        AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 0)) + "x" + CompleteScreening.ListDescriptors[Idx].GetName() + " + ";
                    }
                    else
                    {
                        MessageBox.Show("Descriptor length not consistent (" + CompleteScreening.ListDescriptors[Idx].GetName() + " : " + CompleteScreening.ListDescriptors[Idx].GetBinNumber() + " bins", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }


            cDescriptorsType ColumnType = new cDescriptorsType(AxeName.Remove(AxeName.Length - 3), true, 1, GlobalInfo);

            CompleteScreening.ListDescriptors.AddNew(ColumnType);



            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    double NewValue = 0;
                    IDxDesc = 0;
                    for (int Idx = 0; Idx < CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count - 1; Idx++)
                    {
                        if (CompleteScreening.ListDescriptors[Idx].IsActive())
                            // AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, 0)) + "x" + CompleteScreening.ListDescriptors[Idx].GetName() + " + ";
                            NewValue += EigenVectors.getElement(IDxDesc++, 0) * Tmpwell.ListDescriptors[Idx].GetValue();
                    }

                    cDescriptor NewDesc = new cDescriptor(NewValue, ColumnType, CompleteScreening);
                    LDesc.Add(NewDesc);
                    Tmpwell.AddDescriptors(LDesc);
                }
            }

            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();

            StartingUpDateUI();

            return AxeName;

        }

        public string GeneratePCADescriptor(cExtendPlateList PlatesToProcess, int NumberOfAxis, int NeutralClass)
        {
            int NumWell = 0;
            int NumWellForLearning = 0;
            foreach (cPlate CurrentPlate in PlatesToProcess)
            {
                NumWellForLearning += CurrentPlate.GetNumberOfWellOfClass(NeutralClass);
                NumWell += CompleteScreening.GetCurrentDisplayPlate().GetNumberOfActiveWells();
            }

            if (NumWellForLearning == 0)
            {
                MessageBox.Show("No well identified !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int NumDesc = CompleteScreening.GetNumberOfActiveDescriptor();

            if (NumDesc <= 1)
            {
                MessageBox.Show("More than one descriptor are required for this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            double[,] DataForLDA = new double[NumWellForLearning, CompleteScreening.GetNumberOfActiveDescriptor() + 1];

            //   return;
            Matrix EigenVectors = PCAComputation(DataForLDA, NumWellForLearning, NumDesc, NeutralClass, PlatesToProcess);


            string AxeName = "";
            int IDxDesc = 0;
            //for (int Desc = 0; Desc < CompleteScreening.ListDescriptors.Count; Desc++)
            //{
            //    if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;

            //       AxeName += String.Format("{0:0.##}", EigenVectors.getElement(CompleteScreening.ListDescriptors.Count - 1, 0)) + "x" + CompleteScreening.ListDescriptorName[CompleteScreening.ListDescriptors.Count - 1];
            //}

            int OriginalDescNumber = CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count;


            for (int AxesIdx = 0; AxesIdx < NumberOfAxis; AxesIdx++)
            {

                //for (int Idx = 0; Idx < CompleteScreening.GlobalInfo.WindowHCSAnalyzer.checkedListBoxActiveDescriptors.Items.Count; Idx++)
                //{

                //    if (CompleteScreening.ListDescriptors[Idx].IsActive())
                //        if (CompleteScreening.ListDescriptors[Idx].GetBinNumber() == 1)
                //        {
                //            AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc++, AxesIdx)) + "x" + CompleteScreening.ListDescriptors[Idx].GetName() + " + ";
                //        }
                //        else
                //        {
                //            MessageBox.Show("Descriptor length not consistent (" + CompleteScreening.ListDescriptors[Idx].GetName() + " : " + CompleteScreening.ListDescriptors[Idx].GetBinNumber() + " bins", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return "";
                //        }
                //}

                //cDescriptorsType ColumnType = new cDescriptorsType(AxeName.Remove(AxeName.Length - 3), true, 1);

                cDescriptorsType ColumnType = new cDescriptorsType("PCA_" + (AxesIdx + 1), true, 1, GlobalInfo);

                while (CompleteScreening.ListDescriptors.AddNew(ColumnType) == false)
                {
                    FormForNewDescName NewNameWindow = new FormForNewDescName();
                    NewNameWindow.textBoxName.Text = ColumnType.GetName();

                    if (NewNameWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return ColumnType.GetName();

                    ColumnType.ChangeName(NewNameWindow.textBoxName.Text);
                }
                //CompleteScreening.ListDescriptors.AddNew(ColumnType);

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
                {
                    foreach (cWell Tmpwell in TmpPlate.ListActiveWells)
                    {
                        List<cDescriptor> LDesc = new List<cDescriptor>();

                        double NewValue = 0;
                        IDxDesc = 0;

                        //    AxeName += "\nPCA_" + (AxesIdx + 1);
                        for (int Idx = 0; Idx < OriginalDescNumber - 1; Idx++)
                        {
                            if (CompleteScreening.ListDescriptors[Idx].IsActive())
                                // AxeName += String.Format("{0:0.###}", EigenVectors.getElement(IDxDesc, AxesIdx)) + "x" + CompleteScreening.ListDescriptors[Idx].GetName() + " + ";
                                NewValue += EigenVectors.getElement(IDxDesc++, AxesIdx) * Tmpwell.ListDescriptors[Idx].GetValue();
                        }

                        cDescriptor NewDesc = new cDescriptor(NewValue, ColumnType, CompleteScreening);
                        LDesc.Add(NewDesc);
                        Tmpwell.AddDescriptors(LDesc);
                    }
                }
            }
            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();

            StartingUpDateUI();

            return AxeName;
        }

        private void displayGraphToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cExtendPlateList ListToProcess = new cExtendPlateList();
            ListToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());
            ComputeAndDisplayLDA(ListToProcess);
        }


        //private void displayGraphToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ComputeAndDisplayLDA(CompleteScreening.ListPlatesActive);
        //}



        private void buttonNextPlate_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            if ((toolStripcomboBoxPlateList.SelectedIndex == -1) && (CompleteScreening.ListPlatesActive.Count > 1))
            {
                toolStripcomboBoxPlateList.SelectedIndex = 1; return;
            }
            if (toolStripcomboBoxPlateList.SelectedIndex >= (toolStripcomboBoxPlateList.Items.Count - 1)) return;

            toolStripcomboBoxPlateList.SelectedIndex++;
        }

        private void buttonPreviousPlate_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            if (toolStripcomboBoxPlateList.SelectedIndex <= 0) return;

            toolStripcomboBoxPlateList.SelectedIndex--;
        }

        private void distanceMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPlate CurrentPlate = CompleteScreening.ListPlatesActive[CompleteScreening.CurrentDisplayPlateIdx];

            //double[][] Values = new double[CurrentPlate.ListActiveWells.Count][];

            //for (int i = 0; i < Values.Length; i++)
            //    Values[i] = new double[CurrentPlate.ListActiveWells.Count];


            //for (int j = 0; j < Values.Length; j++)
            //{
            //    cWell SourceWell = CurrentPlate.ListActiveWells[j];
            //    for (int i = j; i < Values[0].Length; i++)
            //    {
            //        cWell DestinationWell = CurrentPlate.ListActiveWells[i];
            //        Values[i][j] = Values[j][i] = SourceWell.DistanceTo(DestinationWell, CompleteScreening.ListDescriptors.CurrentSelectedDescriptor, eDistances.EUCLIDEAN);
            //    }
            //}
            FormToDisplayDistanceMap SingleMatrix = new FormToDisplayDistanceMap(CurrentPlate, CompleteScreening);
            cWindowToDisplaySingleMatrix WindowForSingleArray = new cWindowToDisplaySingleMatrix(SingleMatrix, eDistances.EUCLIDEAN);
        }


        private void buttonDisplayWellsSelectionData_Click(object sender, EventArgs e)
        {
            DataTable FinalDataTable = new DataTable();
            cExtendedList ListClasses = new cExtendedList();

            foreach (cWell TmpWell in GlobalInfo.ListSelectedWell)
            {
                if (TmpWell.AssociatedPlate.DBConnection == null)
                {
                    MessageBox.Show("No Database connection.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TmpWell.AssociatedPlate.DBConnection = new cDBConnection(TmpWell.AssociatedPlate, TmpWell.SQLTableName);
                int NumCells = TmpWell.AssociatedPlate.DBConnection.AddWellToDataTable(TmpWell, FinalDataTable, GlobalInfo);

                cListSingleBiologicalObjects LSO = TmpWell.AssociatedPlate.DBConnection.GetWellBiologicalPhenotypes(TmpWell);
                TmpWell.AssociatedPlate.DBConnection.DB_CloseConnection();

                int CurrentWellClass = TmpWell.GetClassIdx();

                if (checkBoxWellClassAsPhenoClass.Checked)
                {
                    for (int IdxCell = 0; IdxCell < NumCells; IdxCell++)
                        ListClasses.Add(CurrentWellClass);
                }
                else
                {
                    for (int IdxCell = 0; IdxCell < NumCells; IdxCell++)
                        ListClasses.Add(LSO[IdxCell].GetAssociatedPhenotype().Idx);
                }
            }

            FormForSingleCellsDisplay WindowForTable = new FormForSingleCellsDisplay(FinalDataTable, GlobalInfo, ListClasses);

            if (FinalDataTable.Columns.Count == 0)
            {
                MessageBox.Show("Data corrupted !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int IdxCol = 0; IdxCol < FinalDataTable.Columns.Count; IdxCol++)
            {
                WindowForTable.comboBoxAxeX.Items.Add(FinalDataTable.Columns[IdxCol].ColumnName);
                WindowForTable.comboBoxAxeY.Items.Add(FinalDataTable.Columns[IdxCol].ColumnName);
                WindowForTable.comboBoxVolume.Items.Add(FinalDataTable.Columns[IdxCol].ColumnName);
            }

            WindowForTable.comboBoxAxeX.Text = WindowForTable.comboBoxAxeX.GetItemText(WindowForTable.comboBoxAxeX.Items[0]);
            WindowForTable.comboBoxAxeY.Text = WindowForTable.comboBoxAxeX.GetItemText(WindowForTable.comboBoxAxeX.Items[0]);
            WindowForTable.comboBoxVolume.Text = WindowForTable.comboBoxAxeX.GetItemText(WindowForTable.comboBoxAxeX.Items[0]);

            WindowForTable.Text = GlobalInfo.ListSelectedWell.Count + " selected wells - " + FinalDataTable.Rows.Count + " points.";// Well.AssociatedPlate.Name + " [" + Well.GetPosX() + "x" + Well.GetPosY() + "]";
            WindowForTable.Show();

        }

        private void comboBoxClassForWellSelection_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush BrushForColor = new SolidBrush(GlobalInfo.ListWellClasses[e.Index].ColourForDisplay);
            e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            e.Graphics.DrawString(comboBoxNeutralClassForClassif.Items[e.Index].ToString(), comboBoxNeutralClassForClassif.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void buttonToSelectWellsFromClass_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            List<bool> ListClassSelected = ((PanelForClassSelection)PanelForMultipleClassesSelection.Controls[0]).GetListSelectedClass();

            foreach (cWell TmpWell in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
            {
                if (ListClassSelected[TmpWell.GetClassIdx()])
                {
                    TmpWell.AddToSingleCellAnalysis();
                    //listBoxSelectedWells.Items.Add(CompleteScreening.GetCurrentDisplayPlate().Name + " : " + TmpWell.GetPosX() + "x" + TmpWell.GetPosY());
                    //GlobalInfo.ListSelectedWell.Add(TmpWell);
                }
            }
        }



        private void cellBasedClassificationTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening.CellBasedClassification.J48Model == null) return;
            CompleteScreening.CellBasedClassification.DisplayTree(GlobalInfo).Show();
        }

        //private void button_Trees_Click(object sender, EventArgs e)
        //{
        //    if (CompleteScreening == null) return;

        //    FormForClassificationTree WindowForTree = new FormForClassificationTree();

        //    WindowForTree.Text = CompleteScreening.GetCurrentDisplayPlate().Name;
        //    string StringForTree = CompleteScreening.GetCurrentDisplayPlate().GetInfoClassif().StringForTree;
        //    if ((StringForTree == null) || (StringForTree.Length == 0))
        //    {
        //        MessageBox.Show("No tree avaliable for the selected plate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    WindowForTree.gViewerForTreeClassif.Graph = ComputeAndDisplayGraph(StringForTree.Remove(StringForTree.Length - 3, 3));

        //    WindowForTree.richTextBoxConsoleForClassification.Clear();
        //    WindowForTree.richTextBoxConsoleForClassification.AppendText(CompleteScreening.GetCurrentDisplayPlate().GetInfoClassif().StringForQuality);
        //    WindowForTree.richTextBoxConsoleForClassification.AppendText(CompleteScreening.GetCurrentDisplayPlate().GetInfoClassif().ConfusionMatrix);

        //    WindowForTree.Show();
        //}

        private void comboBoxClass_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > 0)
            {
                SolidBrush BrushForColor = new SolidBrush(GlobalInfo.ListWellClasses[e.Index - 1].ColourForDisplay);
                e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            }
            e.Graphics.DrawString(comboBoxClass.Items[e.Index].ToString(), comboBoxClass.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void classesDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForPie WindowForClassesDistribution = new FormForPie();
            WindowForClassesDistribution.Text = "Classes Distributions";

            int[] ListClasses = CompleteScreening.GetClassPopulation();

            Series CurrentSeries = WindowForClassesDistribution.chartForPie.Series[0];

            int NumberOfWells = CompleteScreening.GetNumberOfActiveWells();
            int IdxPt = 0;
            //  CurrentSeries.CustomProperties = "PieLabelStyle=Outside";
            for (int Idx = 0; Idx < ListClasses.Length; Idx++)
            {

                if (ListClasses[Idx] == 0)
                {

                    continue;
                }
                CurrentSeries.Points.Add(ListClasses[Idx]);
                CurrentSeries.Points[IdxPt].Color = GlobalInfo.ListWellClasses[Idx].ColourForDisplay;
                CurrentSeries.Points[IdxPt].Label = String.Format("{0:0.###}", ((100.0 * ListClasses[Idx]) / NumberOfWells)) + " %";

                CurrentSeries.Points[IdxPt].LegendText = "Class " + Idx;
                CurrentSeries.Points[IdxPt].ToolTip = ListClasses[Idx] + " / " + NumberOfWells;
                IdxPt++;
            }

            WindowForClassesDistribution.Show();
        }

        private void hierarchicalTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForHierarchical WindowHierarchical = new FormForHierarchical(this.GlobalInfo);
            WindowHierarchical.richTextBoxWarning.AppendText("Warning:\nHierarchical tree visualization is not adpated for large number of experiments !\nIt can rapidly generate out-of-memory exception!");

            System.Windows.Forms.DialogResult Res = WindowHierarchical.ShowDialog();// MessageBox.Show("Hierarchical tree is not adpated for large number of experiments !\n It can rapidly generate out-of-memory exception!\n Proceed anyway ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Res != System.Windows.Forms.DialogResult.OK) return;
            cDendoGram DendoGram = new cDendoGram(GlobalInfo, WindowHierarchical.radioButtonFullScreen.Checked, 1);
            //cDendoGram DendoGram = new cDendoGram(GlobalInfo,
            //    CompleteScreening.ListPlatesActive[CompleteScreening.CurrentDisplayPlateIdx].CreateInstancesWithoutClass(),
            //    1);
            return;
        }

        private void extractPhenotypesOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            FormClassification WindowClassification = new FormClassification(CompleteScreening);
            WindowClassification.label1.Text = "Class";
            WindowClassification.Text = "Phenotypes of Interest";
            WindowClassification.buttonClassification.Text = "Display";

            if (WindowClassification.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            int SelectedClass = WindowClassification.comboBoxForNeutralClass.SelectedIndex;

            List<string> ListDescName = new List<string>();
            ListDescName.Add("Idx");
            ListDescName.Add("Plate");
            ListDescName.Add("Pos X");
            ListDescName.Add("Pos Y");
            ListDescName.AddRange(CompleteScreening.ListDescriptors.GetListNameActives());

            List<string[]> ListValues = new List<string[]>();
            int Idx = 0;

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
            {
                foreach (cWell TmpWell in TmpPlate.ListActiveWells)
                {
                    if (TmpWell.GetClassIdx() == SelectedClass)
                    {
                        List<string> LValues = new List<string>();
                        LValues.Add(Idx.ToString());
                        LValues.Add(TmpPlate.Name);
                        LValues.Add(TmpWell.GetPosX().ToString());
                        LValues.Add(TmpWell.GetPosY().ToString());

                        for (int IdxDesc = 0; IdxDesc < CompleteScreening.ListDescriptors.Count; IdxDesc++)
                        {
                            if (CompleteScreening.ListDescriptors[IdxDesc].IsActive())
                            {
                                double Value = TmpWell.GetAverageValuesList(false)[IdxDesc];
                                LValues.Add(Value.ToString());

                            }

                        }

                        ListValues.Add(LValues.ToArray());

                        Idx++;
                    }
                }

            }
            cDisplayTable WindowDisplayTable = new cDisplayTable("Phenotypes of Interest. Class " + SelectedClass, ListDescName.ToArray(), ListValues, GlobalInfo, false);
            WindowDisplayTable.Show();



        }

        private void plateViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            List<cPanelForDisplayArray> ListPlates = new List<cPanelForDisplayArray>();

            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
            {
                ListPlates.Add(new FormToDisplayPlate(CurrentPlate, CompleteScreening));
            }

            cWindowToDisplayEntireScreening WindowToDisplayArray = new cWindowToDisplayEntireScreening(ListPlates, CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName(), 6, GlobalInfo);

            WindowToDisplayArray.Show();
        }

        private void descriptorViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDescriptorsWindow();
        }

        private void ThreeDVisualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInfo._Is3DVisualization = ThreeDVisualizationToolStripMenuItem.Checked;

            if (!ThreeDVisualizationToolStripMenuItem.Checked)
                CompleteScreening.Close3DView();
            else
                CompleteScreening.GetCurrentDisplayPlate().Display3DDistributionOnly(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx);
            //            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor, false);
        }

        private void generateHitsDistributionMapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (CompleteScreening == null) return;
            List<cPanelForDisplayArray> ListPlates = new List<cPanelForDisplayArray>();

            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
            {
                ListPlates.Add(new FormToDisplayPlate(CurrentPlate, CompleteScreening));
            }

            cWindowToDisplayEntireScreening WindowToDisplayArray = new cWindowToDisplayEntireScreening(ListPlates, CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName(), 6, GlobalInfo);
            WindowToDisplayArray.checkBoxDisplayClasses.Checked = true;
            WindowToDisplayArray.Text = "Generate Hits Distribution Maps";

            WindowToDisplayArray.Show();


            System.Windows.Forms.DialogResult ResWin = MessageBox.Show("By applying this process, the current screening will be entirely updated ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResWin == System.Windows.Forms.DialogResult.No)
            {
                WindowToDisplayArray.Close();
                return;
            }

            WindowToDisplayArray.Close();
            if (CompleteScreening != null) CompleteScreening.Close3DView();

            //   CompleteScreening.ListDescriptors.RemoveDesc(CompleteScreening.ListDescriptors[IntToTransfer], CompleteScreening);
            cScreening MergedScreening = new cScreening("Class Screen", GlobalInfo);
            MergedScreening.PanelForPlate = this.panelForPlate;

            MergedScreening.Rows = CompleteScreening.Rows;
            MergedScreening.Columns = CompleteScreening.Columns;
            MergedScreening.ListPlatesAvailable = new cExtendPlateList();

            // create the descriptor
            MergedScreening.ListDescriptors.Clean();

            List<cDescriptorsType> ListDescType = new List<cDescriptorsType>();
            List<int[][]> Values = new List<int[][]>();

            for (int i = 0; i < GlobalInfo.GetNumberofDefinedWellClass(); i++)
            {
                cDescriptorsType DescClass = new cDescriptorsType("Class_" + i, true, 1, GlobalInfo);
                ListDescType.Add(DescClass);
                MergedScreening.ListDescriptors.AddNew(DescClass);

                int[][] TMpVal = new int[MergedScreening.Columns][];
                for (int ii = 0; ii < MergedScreening.Columns; ii++)
                    TMpVal[ii] = new int[MergedScreening.Rows];

                Values.Add(TMpVal);
            }

            MergedScreening.ListDescriptors.CurrentSelectedDescriptorIdx = 0;

            foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)
            {
                foreach (cWell TmpWell in CurrentPlate.ListActiveWells)
                {
                    int Class = TmpWell.GetClassIdx();
                    if (Class >= 0)
                        Values[Class][TmpWell.GetPosX() - 1][TmpWell.GetPosY() - 1]++;
                }
            }

            cPlate NewPlate = new cPlate("Cpds", CompleteScreening.Name, MergedScreening);

            for (int X = 0; X < CompleteScreening.Columns; X++)
                for (int Y = 0; Y < CompleteScreening.Rows; Y++)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();
                    for (int i = 0; i < GlobalInfo.GetNumberofDefinedWellClass(); i++)
                    {
                        cDescriptor Desc = new cDescriptor(Values[i][X][Y], ListDescType[i], CompleteScreening);
                        LDesc.Add(Desc);

                    }
                    cWell NewWell = new cWell(LDesc, X + 1, Y + 1, MergedScreening, NewPlate);
                    NewWell.Name = "Well [" + (X + 1) + ":" + (Y + 1) + "]";
                    NewPlate.AddWell(NewWell);

                }

            // check if the plate exist already
            MergedScreening.AddPlate(NewPlate);
            MergedScreening.ListPlatesActive = new cExtendPlateList();

            MergedScreening.GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.Items.Clear();

            for (int i = 0; i < MergedScreening.ListPlatesAvailable.Count; i++)
            {
                MergedScreening.ListPlatesActive.Add(MergedScreening.ListPlatesAvailable[i]);
                MergedScreening.GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.Items.Add(NewPlate.Name);
            }

            CompleteScreening.ListDescriptors = MergedScreening.ListDescriptors;
            CompleteScreening.ListPlatesAvailable = MergedScreening.ListPlatesAvailable;
            CompleteScreening.ListPlatesActive = MergedScreening.ListPlatesActive;

            CompleteScreening.UpDatePlateListWithFullAvailablePlate();
            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();

            CompleteScreening.CurrentDisplayPlateIdx = 0;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, true);

            ListPlates = new List<cPanelForDisplayArray>();
            for (int DescIdx = 0; DescIdx < CompleteScreening.ListDescriptors.Count; DescIdx++)
            {
                if (CompleteScreening.ListDescriptors[DescIdx].IsActive())
                    ListPlates.Add(new FormToDisplayDescriptorPlate(CompleteScreening.GetCurrentDisplayPlate(), CompleteScreening, DescIdx));
            }

            cWindowToDisplayEntireDescriptors WindowToDisplayDesc = new cWindowToDisplayEntireDescriptors(ListPlates, CompleteScreening.GetCurrentDisplayPlate().Name, GlobalInfo.GetNumberofDefinedWellClass());
            WindowToDisplayDesc.checkBoxGlobalNormalization.Checked = true;

            WindowToDisplayDesc.Show();
        }

        private void createAveragePlateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPlate NewPlate = new cPlate("Cpds", "Average Plate", CompleteScreening);
            cWell TmpWell;

            for (int X = 0; X < CompleteScreening.Columns; X++)
                for (int Y = 0; Y < CompleteScreening.Rows; Y++)
                {
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                    {
                        double Value = 0;
                        int NumWells = 0;

                        foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                        {
                            TmpWell = TmpPlate.GetWell(X, Y, false);
                            if (TmpWell != null)
                            {
                                Value += TmpWell.ListDescriptors[i].GetValue();
                                NumWells++;
                                // TmpPlate.GetWell(X, Y, false).
                            }
                        }
                        if (NumWells != 0)
                        {
                            cDescriptor Desc = new cDescriptor(Value / (double)NumWells, CompleteScreening.ListDescriptors[i], CompleteScreening);
                            LDesc.Add(Desc);
                        }
                    }
                    cWell NewWell = new cWell(LDesc, X + 1, Y + 1, CompleteScreening, NewPlate);
                    NewWell.Name = "Average Well [" + (X + 1) + ":" + (Y + 1) + "]";
                    NewPlate.AddWell(NewWell);

                }

            CompleteScreening.AddPlate(NewPlate);
            CompleteScreening.ListPlatesActive.Add(NewPlate);
            toolStripcomboBoxPlateList.Items.Add(NewPlate.Name);
            CompleteScreening.ListPlatesActive[CompleteScreening.ListPlatesActive.Count - 1].UpDataMinMax();
            CompleteScreening.CurrentDisplayPlateIdx = 0;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, true);
        }

        private void generateDBFromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog CurrOpenFileDialog = new OpenFileDialog();
            CurrOpenFileDialog.Filter = "csv files (*.csv)|*.csv";//|db files (*.db)|*.db|nc files (*.nc)|*.nc
            CurrOpenFileDialog.Multiselect = false;

            DialogResult Res = CurrOpenFileDialog.ShowDialog();
            if (Res != DialogResult.OK) return;
            CSVtoDB(CurrOpenFileDialog.FileNames[0]);

        }

        private void CSVtoDB(string PathName)
        {
            FormForImportExcel CSVWindow = CellByCellFromCSV(PathName);

            if (CSVWindow == null) return;
            if (CSVWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            if (CompleteScreening != null) CompleteScreening.Close3DView();

            FolderBrowserDialog WorkingFolderDialog = new FolderBrowserDialog();
            WorkingFolderDialog.ShowNewFolderButton = true;
            WorkingFolderDialog.Description = "Select the working directory";
            if (WorkingFolderDialog.ShowDialog() != DialogResult.OK) return;

            //if (IsFileUsed(CurrOpenFileDialog.FileNames[0]))
            //{
            //    MessageBox.Show("File currently used by another application.\n", "Loading error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //Microsoft.Research.Science.Data.DataSet Datacsv = Microsoft.Research.Science.Data.CSV.CsvDataSet.Open(CurrOpenFileDialog.FileNames[0]);

            //int NumDesc = Datacsv.Variables.Count;

            //for (int IdxDesc = 0; IdxDesc < NumDesc; IdxDesc++)
            //{
            //    var DescInfo = Datacsv.Variables[IdxDesc];
            //    string NameDesc = DescInfo.Name;

            //    var TypeData = DescInfo.TypeOfData;
            //    string DataName = TypeData.Name;
            //}


            int NumPlateName = 0;
            int NumRow = 0;
            int NumCol = 0;
            int NumWellPos = 0;
            int NumPhenotypeClass = 0;
            // int NumLocusID = 0;
            // int NumConcentration = 0;
            //  int NumName = 0;
            //   int NumInfo = 0;
            //   int NumClass = 0;

            int numDescritpor = 0;

            for (int i = 0; i < CSVWindow.dataGridViewForImport.Rows.Count; i++)
            {
                string CurrentVal = CSVWindow.dataGridViewForImport.Rows[i].Cells[2].Value.ToString();
                if ((CurrentVal == "Plate name") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    NumPlateName++;
                if ((CurrentVal == "Row") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    NumRow++;
                if ((CurrentVal == "Column") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    NumCol++;
                if ((CurrentVal == "Well position") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    NumWellPos++;
                if ((CurrentVal == "Descriptor") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    numDescritpor++;
                if ((CurrentVal == "Phenotype Class") && ((bool)CSVWindow.dataGridViewForImport.Rows[i].Cells[1].Value))
                    NumPhenotypeClass++;
            }

            if (NumPlateName != 1)
            {
                MessageBox.Show("One and only one \"Plate Name\" has to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((NumRow != 1) && (GlobalInfo.OptionsWindow.radioButtonWellPosModeDouble.Checked == true))
            {
                MessageBox.Show("One and only one \"Row\" has to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((NumCol != 1) && (GlobalInfo.OptionsWindow.radioButtonWellPosModeDouble.Checked == true))
            {
                MessageBox.Show("One and only one \"Column\" has to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((NumWellPos != 1) && (GlobalInfo.OptionsWindow.radioButtonWellPosModeSingle.Checked == true))
            {
                MessageBox.Show("One and only one \"Well position\" has to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((numDescritpor < 1) && (CSVWindow.IsImportCSV))
            {
                MessageBox.Show("You need to select at least one \"Descriptor\" !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int Mode = 2;
            if (GlobalInfo.OptionsWindow.radioButtonWellPosModeSingle.Checked) Mode = 1;
            CsvFileReader CSVsr = new CsvFileReader(PathName);

            CsvRow OriginalNames = new CsvRow();
            if (!CSVsr.ReadRow(OriginalNames))
            {
                CSVsr.Close();
                return;
            }

            int ColPlateName = GetColIdxFor("Plate name", CSVWindow);
            int ColCol = GetColIdxFor("Column", CSVWindow);
            int ColRow = GetColIdxFor("Row", CSVWindow);
            int ColWellPos = GetColIdxFor("Well position", CSVWindow);
            int ColPhenotypeClass = GetColIdxFor("Phenotype Class", CSVWindow);
            int[] ColsForDescriptors = GetColsIdxFor("Descriptor", CSVWindow);

            int WellLoaded = 0;
            int FailToLoad = 0;


            //  CompleteScreening.Columns = (int)CSVWindow.numericUpDownColumns.Value;
            //  CompleteScreening.Rows = (int)CSVWindow.numericUpDownRows.Value;
            //  CompleteScreening.ListDescriptors.Clean();

            FormForProgress ProgressWindow = new FormForProgress();
            ProgressWindow.Show();
            CsvRow CurrentDesc = new CsvRow();
            if (CSVsr.ReadRow(CurrentDesc) == false) return;
            do
            {
                string OriginalPlatePlateName = CurrentDesc[ColPlateName];
                string CurrentPlateName = CurrentDesc[ColPlateName];
                string ConvertedName = "";

                foreach (var c in System.IO.Path.GetInvalidFileNameChars())
                {
                    ConvertedName = OriginalPlatePlateName.Replace(c, '-');
                }



                List<string> ListNameSignature = new List<string>();

                for (int idxDesc = 0/*Mode + 1*/; idxDesc < ColsForDescriptors.Length/* + Mode + 1*/; idxDesc++)
                {
                    ListNameSignature.Add(OriginalNames[ColsForDescriptors[idxDesc]]);
                }
                ListNameSignature.Add("Phenotype_Class");

                cSQLiteDatabase SQDB = new cSQLiteDatabase(WorkingFolderDialog.SelectedPath + "\\" + ConvertedName, ListNameSignature, true);
                do
                {
                    string OriginalWellPos;
                    int[] Pos = new int[2];

                    if (Mode == 1)
                    {
                        Pos = ConvertPosition(CurrentDesc[ColWellPos]);
                        if (Pos == null)
                        {
                            if (MessageBox.Show("Error in converting the current well position.\nGo to Edit->Options->Import-Export->Well Position Mode to fix this.\nDo you want continue ?", "Loading error !", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                            {
                                CSVsr.Close();
                                return;
                            }
                            //else
                            //    goto NEXTLOOP;
                        }
                        OriginalWellPos = CurrentDesc[ColWellPos];
                    }
                    else
                    {
                        if (int.TryParse(CurrentDesc[ColCol], out Pos[0]) == false)
                            goto NEXTLOOP;
                        if (int.TryParse(CurrentDesc[ColRow], out Pos[1]) == false)
                            goto NEXTLOOP;

                        OriginalWellPos = ConvertPosition(int.Parse(CurrentDesc[ColCol]), int.Parse(CurrentDesc[ColRow]));// "("+CurrentDesc[ColCol]+","+CurrentDesc[ColRow]+")";
                    }

                    string CurrentWellPos = OriginalWellPos;

                    cWellForDatabase WellForDB = new cWellForDatabase(OriginalPlatePlateName, Pos[0], Pos[1]);
                    List<List<double>> ListData = new List<List<double>>();
                    //   for (int idxDesc = 0; idxDesc < ColsForDescriptors.Length; idxDesc++)
                    //   ListData[idxDesc] = new List<double>();

                    ProgressWindow.label.Text = CurrentWellPos;
                    ProgressWindow.label.Refresh();

                    do
                    {
                        //  CurrentWellPos = CurrentDesc[ColWellPos];
                        List<double> Signature = new List<double>();

                        for (int idxDesc = 0; idxDesc < ColsForDescriptors.Length; idxDesc++)
                        {
                            double Value;
                            if ((double.TryParse(CurrentDesc[ColsForDescriptors[idxDesc]], out Value))/* && (!double.IsNaN(Value))*/)
                            {
                                if (double.IsNaN(Value) == false)
                                {
                                    //cDescriptor CurrentDescriptor = new cDescriptor(Value, CompleteScreening.ListDescriptors[idxDesc/* + ShiftIdx*/], CompleteScreening);
                                    Signature.Add(Value);
                                }
                                else
                                { }
                            }
                            /*else
                            {
                                FailToLoad++;
                                goto NEXTLOOP;
                            }*/
                        }


                        // if the class of the phenotype is defined in the file then use it
                        // if not, put it at 0
                        double ValueClass;
                        if ((ColPhenotypeClass != -1) && (double.TryParse(CurrentDesc[ColPhenotypeClass], out ValueClass) == true))
                        {
                            double IntValue = (int)(ValueClass) % GlobalInfo.ListCellularPhenotypes.Count;
                            Signature.Add(IntValue);
                        }
                        else
                        {
                            Signature.Add(0);
                        }


                        ListData.Add(Signature);
                        // WellForDB.AddSignature(Signature);

                        if (CSVsr.ReadRow(CurrentDesc) == false)
                        {
                            WellForDB.AddListSignatures(ListData);
                            SQDB.AddNewWell(WellForDB);
                            SQDB.CloseConnection();
                            goto NEXTLOOP;
                        }
                        CurrentPlateName = CurrentDesc[ColPlateName];

                        if (Mode == 1)
                        {
                            CurrentWellPos = CurrentDesc[ColWellPos];
                        }
                        else
                        {
                            int ResCol;
                            int ResRow;
                            if ((!int.TryParse(CurrentDesc[ColCol], out ResCol)) || (!int.TryParse(CurrentDesc[ColRow], out ResRow))) goto NEXTLOOP;

                            CurrentWellPos = ConvertPosition(ResCol, ResRow);
                        }


                    } while (CurrentWellPos == OriginalWellPos);

                    WellForDB.AddListSignatures(ListData);
                    SQDB.AddNewWell(WellForDB);
                    //NEXTSIGNATURE: ;

                } while (OriginalPlatePlateName == CurrentPlateName);

                SQDB.CloseConnection();
            } while (true);


        NEXTLOOP: ;
            ProgressWindow.Close();


            FormForPlateDimensions PlateDim = new FormForPlateDimensions();
            PlateDim.Text = "Load generated screening";
            PlateDim.checkBoxAddCellNumber.Visible = true;
            PlateDim.checkBoxIsOmitFirstColumn.Visible = true;
            PlateDim.labelHisto.Visible = true;
            PlateDim.numericUpDownHistoSize.Visible = true;

            if (PlateDim.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            LoadCellByCellDB(PlateDim, WorkingFolderDialog.SelectedPath);
        }

        private void loadDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening != null) CompleteScreening.Close3DView();

            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();

            if (OpenFolderDialog.ShowDialog() != DialogResult.OK) return;
            string Path = OpenFolderDialog.SelectedPath;


            FormForPlateDimensions PlateDim = new FormForPlateDimensions();
            PlateDim.checkBoxAddCellNumber.Visible = true;
            PlateDim.checkBoxIsOmitFirstColumn.Visible = true;
            PlateDim.labelHisto.Visible = true;
            PlateDim.numericUpDownHistoSize.Visible = true;

            if (PlateDim.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            LoadCellByCellDB(PlateDim, Path);
        }

        private void classViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            checkBoxDisplayClasses.Checked = classViewToolStripMenuItem.Checked;

            // CompleteScreening.GlobalInfo.IsDisplayClassOnly = checkBoxDisplayClasses.Checked;
            //CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor, false);
        }




        private void pieViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            GlobalInfo.ViewMode = eViewMode.PIE;
            averageViewToolStripMenuItem.Checked = false;
            pieViewToolStripMenuItem1.Checked = true;
            histogramViewToolStripMenuItem.Checked = false;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void HCSAnalyzer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CompleteScreening == null) return;

            if (e.KeyChar == 'a')
            {
                CompleteScreening.GlobalInfo.ViewMode = eViewMode.AVERAGE;
                pieViewToolStripMenuItem1.Checked = false;
                averageViewToolStripMenuItem.Checked = true;
                histogramViewToolStripMenuItem.Checked = false;
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
            }
            if (e.KeyChar == 'h')
            {
                CompleteScreening.GlobalInfo.ViewMode = eViewMode.DISTRIBUTION;
                pieViewToolStripMenuItem1.Checked = false;
                averageViewToolStripMenuItem.Checked = false;
                histogramViewToolStripMenuItem.Checked = true;
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
            }
            if (e.KeyChar == 'c')
            {
                checkBoxDisplayClasses.Checked = true;
            }
            if (e.KeyChar == 'p')
            {
                GlobalInfo.ViewMode = eViewMode.PIE;
                pieViewToolStripMenuItem1.Checked = true;
                averageViewToolStripMenuItem.Checked = false;
                histogramViewToolStripMenuItem.Checked = false;
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
            }

        }

        private void averageViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteScreening.GlobalInfo.ViewMode = eViewMode.AVERAGE;
            pieViewToolStripMenuItem1.Checked = false;
            averageViewToolStripMenuItem.Checked = true;
            histogramViewToolStripMenuItem.Checked = false;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void histogramViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteScreening.GlobalInfo.ViewMode = eViewMode.DISTRIBUTION;
            pieViewToolStripMenuItem1.Checked = false;
            averageViewToolStripMenuItem.Checked = false;
            histogramViewToolStripMenuItem.Checked = true;
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void currentPlate3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            GlobalInfo.OptionsWindow.checkBoxConnectDRCPts.Checked = true;

            FormFor3DDataDisplay FormToDisplayXYZ = new FormFor3DDataDisplay(false, CompleteScreening);
            for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            {
                FormToDisplayXYZ.comboBoxDescriptorX.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorY.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorZ.Items.Add(CompleteScreening.ListDescriptors[i].GetName());
            }
            FormToDisplayXYZ.Show();
            FormToDisplayXYZ.comboBoxDescriptorX.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorY.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            FormToDisplayXYZ.comboBoxDescriptorZ.Text = CompleteScreening.ListDescriptors[0].GetName() + " ";
            return;
        }

        private void loadSingleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog CurrOpenFileDialog = new OpenFileDialog();
            CurrOpenFileDialog.Filter = "Tif files (*.tif)|*.tif";
            DialogResult Res = CurrOpenFileDialog.ShowDialog();
            if (Res != DialogResult.OK) return;
            cImage NewIm = new cImage(CurrOpenFileDialog.FileName);



            //cImage TestImage = new cImage(512, 512, 1, 1);
            //TestImage.Name = "First Test";
            //for (int Y = 0; Y < TestImage.Height; Y++)
            //    for (int X = 0; X < TestImage.Width; X++)
            //    {
            //        TestImage.Data[0].Data[X + Y * TestImage.Width] = X;
            //    }


            cImageViewer NewView = new cImageViewer();
            // NewView.SetImage(NewIm);

            cImage FilteredImage = new cImage(NewIm.Width, NewIm.Height, NewIm.Depth, 1/* NewIm.NumChannels*/);

            //   ImageAnalysisFiltering.cImageFilterMedian FilterMedian = new ImageAnalysisFiltering.cImageFilterMedian(NewIm, 0, FilteredImage, 0);
            //  FilterMedian.radius = 5;
            //  FilterMedian.Run();

            ImageAnalysisFiltering.cImageFilterGaussianBlur GaussianBlur = new ImageAnalysisFiltering.cImageFilterGaussianBlur(NewIm, 0, FilteredImage, 0, 3);
            GaussianBlur.Run();
            NewView.SetImage(FilteredImage);


            //cImageViewer NewView1 = new cImageViewer();
            //NewView1.SetImage(FilteredImage);

            //NewView.AddNotation(new ObjectForNotations.cString("This is a test", new Point(100, 100), Color.Red, 20));

            //for (int Idx = 0; Idx < 120; Idx += 10)
            //    NewView.AddNotation(new ObjectForNotations.cDisk(new Point(Idx * 10, Idx * 10), Color.FromArgb(Idx, Idx, 50), Idx));

            GlobalInfo.DisplayViewer(NewView);

            // NewView1.AddNotation(new ObjectForNotations.cString("Median", new Point(100, 100), Color.Red, 20));
            //  GlobalInfo.DisplayViewer(NewView1);

        }

        private void bioFormatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Emgu.CV.Matrix<float> Signature1 = new Emgu.CV.Matrix<float>(10, 2);
            ////List<Emgu.CV.Structure.MCvPoint2D64f> PtList = new List<Emgu.CV.Structure.MCvPoint2D64f>();
            //List<PointF> PtList = new List<PointF>();
            ////Emgu.CV.Structure.MCvPoint2D64f
            //for (int Idx = 0; Idx < 10; Idx++)
            //{
            //    PtList.Add(new PointF(Idx, Idx));

            //    //Signature1[Idx, 0] = Idx;
            //    //Signature1[Idx, 1] = Idx;
            //}

            //Emgu.CV.Structure.Ellipse Ell = Emgu.CV.PointCollection.EllipseLeastSquareFitting(PtList.ToArray());

            List<cExtendedList> BigList = new List<cExtendedList>();

            cExtendedList FirstData = new cExtendedList();
            FirstData.Name = "First";
            cExtendedList ScdData = new cExtendedList();
            ScdData.Name = "Second";
            cExtendedList ThirdData = new cExtendedList();
            ThirdData.Name = "Third";

            for (double Idx = 0; Idx < 6.28; Idx += 0.01)
            {
                FirstData.Add(Math.Cos(4 * Idx));
                ScdData.Add(Math.Sin(3 * Idx));
                ThirdData.Add(Math.Sin(Idx) * Math.Sin(Idx) * Math.Cos(Idx));
            }
            BigList.Add(FirstData);
            BigList.Add(ScdData);
            BigList.Add(ThirdData);


            //cViewerScatter2D ScatterPtsViewer = new cViewerScatter2D();
            //ScatterPtsViewer.SetInputData(BigList);
            //ScatterPtsViewer.Run();
            //ScatterPtsViewer.Display();


            //FormToDisplayDataTable FDT = new FormToDisplayDataTable(BigList);
            //FDT.Show();
            //   createDataTable(BigList);


            //  loci.formats.@in.AVIReader MyReader = new loci.formats.@in.AVIReader();
            //  MyReader.setId("E:\\Downloads\\prnfle435x.avi");

            //Emgu.CV.Structure.MCvBox2D Box = Emgu.CV.CvInvoke.cvFitEllipse2(PtList.ToArray());

            cViewerScatter3D Viewer3D = new cViewerScatter3D(GlobalInfo);
            Viewer3D.Run();
            Viewer3D.Display();


        }





        private void testSingleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //cImage FilteredImage = new cImage(NewIm.Width, NewIm.Height, NewIm.Depth, NewIm.NumChannels);

            //ImageAnalysisFiltering.cImageFilterMedian FilterMedian = new ImageAnalysisFiltering.cImageFilterMedian(NewIm, 0, FilteredImage, 0);
            //FilterMedian.radius = 5;
            //FilterMedian.Run();


            cImage TestImage = new cImage(256, 50, 1, 3);
            TestImage.Name = "First Test";
            for (int IdxChannel = 0; IdxChannel < TestImage.NumChannels; IdxChannel++)
                for (int Y = 0; Y < TestImage.Height; Y++)
                    for (int X = 0; X < TestImage.Width; X++)
                    {
                        TestImage.Data[IdxChannel].Data[X + Y * TestImage.Width] = X * Y / 10;
                    }

            //     cImage FilteredImage = new cImage(TestImage.Width, TestImage.Height, TestImage.Depth, TestImage.NumChannels);
            //     ImageAnalysisFiltering.cImageFilterMedian FilterMedian = new ImageAnalysisFiltering.cImageFilterMedian(TestImage, 0, FilteredImage, 0);
            //     FilterMedian.radius = 2;
            //     FilterMedian.Run();

            cImageViewer NewView = new cImageViewer();
            NewView.SetImage(TestImage);

            //cImageViewer NewView1 = new cImageViewer();
            //NewView1.SetImage(FilteredImage);

            //     NewView.AddNotation(new ObjectForNotations.cString("This is a test", new Point(10, 10), Color.Red, 20));

            //for (int Idx = 0; Idx < 120; Idx += 10)
            //    NewView.AddNotation(new ObjectForNotations.cDisk(new Point(Idx * 10, Idx * 10), Color.FromArgb(Idx, Idx, 50), Idx));

            GlobalInfo.DisplayViewer(NewView);

            // NewView1.AddNotation(new ObjectForNotations.cString("Median", new Point(100, 100), Color.Red, 20));
            //  GlobalInfo.DisplayViewer(NewView1);
        }

        private void newOptionMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cListOptions ListOptions = new cListOptions(GlobalInfo);
            FormForGlobalInfoOptions WindowForOptions = new FormForGlobalInfoOptions(ListOptions);
            WindowForOptions.ShowDialog();
        }

        private void singleCellsSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForSimuGenerator WindowForSimulation = new FormForSimuGenerator(GlobalInfo);
            WindowForSimulation.Show();
        }

        private void hierarchicalTreeToolStripMenuItemFullScreen_Click(object sender, EventArgs e)
        {
            FormForHierarchical WindowHierarchical = new FormForHierarchical(this.GlobalInfo);
            WindowHierarchical.richTextBoxWarning.AppendText("Warning:\nHierarchical tree visualization is not adpated for large number of experiments !\nIt can rapidly generate out-of-memory exception!");

            System.Windows.Forms.DialogResult Res = WindowHierarchical.ShowDialog();// MessageBox.Show("Hierarchical tree is not adpated for large number of experiments !\n It can rapidly generate out-of-memory exception!\n Proceed anyway ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Res != System.Windows.Forms.DialogResult.OK) return;
            // cDendoGram DendoGram = new cDendoGram(GlobalInfo, WindowHierarchical.radioButtonFullScreen.Checked,1);
            cDendoGram DendoGram = new cDendoGram(GlobalInfo,
               true,
                1);
            return;
        }


        #region Clustering
        private void buttonClustering_Click(object sender, EventArgs e)
        {
            List<cPlate> ListPlatesToProcess = new List<cPlate>();

            if (this.ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                foreach (cPlate item in CompleteScreening.ListPlatesActive)
                    ListPlatesToProcess.Add(item);

                PerformScreeningClustering(ListPlatesToProcess, true);
            }
            else if (this.ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                foreach (cPlate item in CompleteScreening.ListPlatesActive)
                    ListPlatesToProcess.Add(item);
                PerformScreeningClustering(ListPlatesToProcess, false);
            }
            else if (this.ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                ListPlatesToProcess.Add(CompleteScreening.ListPlatesActive[CompleteScreening.CurrentDisplayPlateIdx]);
                PerformScreeningClustering(ListPlatesToProcess, true);
            }
        }

        public void PerformScreeningClustering(List<cPlate> ListPlatesToProcess, bool IsOneByOne)
        {


            this.Cursor = Cursors.WaitCursor;
            cMachineLearning MachineLearning = new cMachineLearning(this.GlobalInfo);
            cParamAlgo ParamAlgoForClustering = MachineLearning.AskAndGetClusteringAlgo();
            if (ParamAlgoForClustering == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            DataTable dt = new DataTable();

            for (int IdxDesc = 0; IdxDesc < CompleteScreening.ListDescriptors.Count; IdxDesc++)
            {
                if (CompleteScreening.ListDescriptors[IdxDesc].IsActive())
                    dt.Columns.Add(CompleteScreening.ListDescriptors[IdxDesc].GetName());
            }
            if (IsOneByOne)
            {
                foreach (cPlate itemPlate in ListPlatesToProcess)
                {
                    foreach (cWell item in itemPlate.ListActiveWells)
                    {
                        cExtendedList ListValues = item.GetAverageValuesList(false);
                        dt.Rows.Add();
                        int RealIdx = 0;
                        for (int IdxDesc = 0; IdxDesc < CompleteScreening.ListDescriptors.Count; IdxDesc++)
                        {
                            if (CompleteScreening.ListDescriptors[IdxDesc].IsActive())
                                dt.Rows[dt.Rows.Count - 1][RealIdx++] = ListValues[IdxDesc];
                        }
                    }

                    MachineLearning.SelectedClusterer = MachineLearning.BuildClusterer(ParamAlgoForClustering, dt);

                    if (MachineLearning.SelectedClusterer != null)
                    {
                        double[] Assign = MachineLearning.EvaluteAndDisplayClusterer(richTextBoxInfoClustering,
                                                                null,
                                                                MachineLearning.CreateInstancesWithoutClass(dt)).getClusterAssignments();

                        MachineLearning.Classes = new cExtendedList();
                        MachineLearning.Classes.AddRange(Assign);
                    }
                    if (MachineLearning.Classes.Max() >= GlobalInfo.GetNumberofDefinedWellClass())
                    {
                        MessageBox.Show("The number of cluster is higher than the supported number of classes. Operation cancelled !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    if (MachineLearning.Classes.IsContainNegative() || (MachineLearning.Classes.Count == 0))
                    {
                        MessageBox.Show("Negative or null cluster index identified. Operation cancelled !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    // ----- update well classes ------
                    int IdxWell = 0;
                    foreach (cWell item in itemPlate.ListActiveWells)
                        item.SetClass((int)MachineLearning.Classes[IdxWell++]);
                }
            }
            else
            {
                foreach (cPlate itemPlate in ListPlatesToProcess)
                {
                    foreach (cWell item in itemPlate.ListActiveWells)
                    {
                        cExtendedList ListValues = item.GetAverageValuesList(false);
                        dt.Rows.Add();
                        int RealIdx = 0;
                        for (int IdxDesc = 0; IdxDesc < CompleteScreening.ListDescriptors.Count; IdxDesc++)
                        {
                            if (CompleteScreening.ListDescriptors[IdxDesc].IsActive())
                                dt.Rows[dt.Rows.Count - 1][RealIdx++] = ListValues[IdxDesc];
                        }
                    }
                }
                MachineLearning.SelectedClusterer = MachineLearning.BuildClusterer(ParamAlgoForClustering, dt);

                if (MachineLearning.SelectedClusterer != null)
                {
                    double[] Assign = MachineLearning.EvaluteAndDisplayClusterer(richTextBoxInfoClustering,
                                                            null,
                                                            MachineLearning.CreateInstancesWithoutClass(dt)).getClusterAssignments();

                    MachineLearning.Classes = new cExtendedList();
                    MachineLearning.Classes.AddRange(Assign);
                }
                if (MachineLearning.Classes.Max() >= GlobalInfo.GetNumberofDefinedWellClass())
                {
                    MessageBox.Show("The number of cluster is higher than the supported number of classes. Operation cancelled !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (MachineLearning.Classes.IsContainNegative() || (MachineLearning.Classes.Count == 0))
                {
                    MessageBox.Show("Negative or null cluster index identified. Operation cancelled !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
                int IdxWell = 0;
                // ----- update well classes ------
                foreach (cPlate itemPlate in ListPlatesToProcess)
                {
                    foreach (cWell item in itemPlate.ListActiveWells)
                        item.SetClass((int)MachineLearning.Classes[IdxWell++]);
                }
            }
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void buttonNewClassificationProcess_Click(object sender, EventArgs e)
        {
            cMachineLearning MachineLearningForClassif = new cMachineLearning(this.GlobalInfo);
            //cParamAlgo AlgoAndParameters = MachineLearningForClassif.AskAndGetClassifAlgo();


            // List<bool> ListClassSelected = ((PanelForClassSelection)panelForClassSelectionClustering.Controls[0]).GetListSelectedClass();

            //    cInfoClass InfoClass = new cInfoClass();
            //Instances ListInstances =  CompleteScreening.GetCurrentDisplayPlate().CreateInstancesWithClasses(ListClassSelected);
            cInfoClass InfoClass = CompleteScreening.GetCurrentDisplayPlate().GetNumberOfClassesBut(comboBoxNeutralClassForClassif.SelectedIndex);


            Instances ListInstances = CompleteScreening.GetCurrentDisplayPlate().CreateInstancesWithClasses(InfoClass, comboBoxNeutralClassForClassif.SelectedIndex);

            //panelForClassSelectionClustering

            weka.classifiers.Evaluation EvalClassif = new weka.classifiers.Evaluation(ListInstances);

            MachineLearningForClassif.PerformTraining(MachineLearningForClassif.AskAndGetClassifAlgo(),
                                                        ListInstances,
                                                        InfoClass.NumberOfClass,
                                                        richTextBoxInfoClustering,
                                                        panelTMPForFeedBack,
                                                        out EvalClassif,
                                                        false);
        }





        private void heatMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            List<cPanelForDisplayArray> ListPlates = new List<cPanelForDisplayArray>();

            ListPlates.Add(new FormToDisplayPlate(CompleteScreening.GetCurrentDisplayPlate(), CompleteScreening));

            cWindowToDisplayEntireScreening WindowToDisplayArray = new cWindowToDisplayEntireScreening(ListPlates, CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName(), 6, GlobalInfo);

            WindowToDisplayArray.Show();
        }

        private void testRStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var envPath = System.Environment.GetEnvironmentVariable("PATH");
            var rBinPath = @"C:\Program Files\R\R-2.15.2\bin\i386";
            System.Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);

            using (REngine engine = REngine.CreateInstance("RDotNet"))
            {

                cRandomGenerator NewRNDData = new cRandomGenerator(this.GlobalInfo);
                NewRNDData.List_Number = 2;
                NewRNDData.Size_List = 10;
                NewRNDData.Run();

                NumericVector group1 = engine.CreateNumericVector(NewRNDData.GetOutPut()[0].ToArray());
                engine.SetSymbol(NewRNDData.GetOutPut()[0].Name, group1);

                NumericVector group2 = engine.CreateNumericVector(NewRNDData.GetOutPut()[1].ToArray());
                engine.SetSymbol(NewRNDData.GetOutPut()[1].Name, group2);
                // Direct parsing from R script.
                // NumericVector group2 = engine.EagerEvaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

                // Test difference of mean and get the P-value.
                GenericVector testResult = engine.EagerEvaluate("t.test(group1, group2)").AsList();
                double p = testResult["p.value"].AsNumeric().First();

                Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
                Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
                Console.WriteLine("P-value = {0:0.000}", p);

            }

        }

        private void testNewProjectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cFeedBackMessage MessageReturned;

            cRandomGenerator NewRNDData = new cRandomGenerator(this.GlobalInfo);
            NewRNDData.List_Number = 4;
            NewRNDData.Size_List = 10;
            NewRNDData.Run();

            // in this case we are giving meaningfull names to each data
            int idAxis = 0;
            foreach (var item in NewRNDData.GetOutPut())
                item.Name = "Axis_" + (idAxis++);


            //cDisplayCorrelationMatrix ComputeAndDisplay_SingleCorrelationMatrix = new cDisplayCorrelationMatrix();
            //ComputeAndDisplay_SingleCorrelationMatrix.Set_Data(NewRNDData.GetOutPut());
            //ComputeAndDisplay_SingleCorrelationMatrix.Run();
            //  return;

            #region Build data
            // Step 0: create data (here we are using a "filter" to generate values, but you could 
            // generate manually your own data. Converter from S-stats, and Weka are under dev.
            // soon CSV and Database reader will be added too.
            //cRandomGenerator NewRNDData = new cRandomGenerator(this.GlobalInfo);
            //NewRNDData.List_Number = 4;
            //NewRNDData.Size_List = 10;
            //NewRNDData.Run();

            //// in this case we are giving meaningfull names to each data
            //int idAxis = 0;
            //foreach (var item in NewRNDData.GetOutPut())
            //    item.Name = "Axis_" + (idAxis++);

            // you can get the value from the wells taking into account the GUI information as well...
            cExtendedTable DataFromPlate = new cExtendedTable(CompleteScreening.GetCurrentDisplayPlate().ListActiveWells, true);
            DataFromPlate.Name = CompleteScreening.GetCurrentDisplayPlate().Name;
            #endregion

            #region process
            // step 1: we are processing the data... it can be any kind of operation.
            // here we are computing a PCA.
            // (a) build the "filter"
            // (b) set the input data (mandatory)
            // (b') change the parameters (optional)
            // (c) run the process. Check that everthing went well
            cProjectorPCA PCA = new cProjectorPCA();

            PCA.SetInputData(/*NewRNDData.GetOutPut()*/DataFromPlate);
            MessageReturned = PCA.Run();
            if (!MessageReturned.IsSucceed)
            {
                MessageBox.Show(MessageReturned.Message, "Error: " + PCA.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // here is a short example to compute and display the square values of the PCA coeff.
            cArithmetic_Power SquareValues = new cArithmetic_Power();
            SquareValues.SetInputData(PCA.GetOutPut());
            SquareValues.Set_Power(2.0);
            SquareValues.Run();
            cViewerTable DisplayForTable0 = new cViewerTable();
            DisplayForTable0.SetInputData(SquareValues.GetOutPut());
            if (!DisplayForTable0.Run().IsSucceed) return;
            cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
            Designer0.SetInputData(DisplayForTable0.GetOutPut());
            Designer0.Run();
            cDisplayToWindow Disp0 = new cDisplayToWindow();
            Disp0.SetInputData(Designer0.GetOutPut());
            Disp0.Title = SquareValues.Title;
            if (!Disp0.Run().IsSucceed) return;
            Disp0.Display();

            #endregion

            // here is a filter for projecting and displaying the scatter data
            cLinearProjector LinearProjection = new cLinearProjector();
            LinearProjection.Set_Basis(PCA.GetOutPut());
            LinearProjection.Set_Input(DataFromPlate);
            if (!LinearProjection.Run().IsSucceed)
                MessageReturned = LinearProjection.Run();
            if (!MessageReturned.IsSucceed)
            {
                MessageBox.Show(MessageReturned.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // this will change ... for the moment there's no designer...
            //cViewerScatter2D ProjectedPts = new cViewerScatter2D();
            //ProjectedPts.SetInputData(LinearProjection.GetOutPut());
            //ProjectedPts.Run();
            //ProjectedPts.Display();

            #region Display results
            // step 2: in this case we want to display the results as a table, but we could
            // do the same with a heat-map, a 2d-3d scatter points, etc...
            // (a) build the "filter"
            // (b) set the input data (mandatory)
            // (b') change the parameters (optional)
            // (c) run the process. Check that everthing went well
            cViewerTable DisplayForTable = new cViewerTable();
            DisplayForTable.SetInputData(PCA.GetOutPut());
            if (!DisplayForTable.Run().IsSucceed) return;

            // step 3: at this stage we have to design our interface. In this case it doesn't
            // seem very useful, but think that the final display could be a mix of many different
            // views...
            // (a) build the "filter"
            // (b) set the input data (mandatory)
            // (b') change the parameters (optional)
            // (c) run the process. Check that everthing went well
            cDesignerSinglePanel Designer = new cDesignerSinglePanel();
            Designer.SetInputData(DisplayForTable.GetOutPut());
            Designer.Run();


            // step 4: final display, create a window and show it !
            // (a) build the "filter"
            // (b) set the input data (mandatory)
            // (b') change the parameters (optional)
            // (c) run the process. Check that everthing went well
            // (d) in this case, abd because there nothing after that,
            // the user has to execute a Display function.
            cDisplayToWindow Disp = new cDisplayToWindow();
            Disp.SetInputData(Designer.GetOutPut());
            Disp.Title = PCA.Title;
            if (!Disp.Run().IsSucceed) return;
            Disp.Display();
            #endregion

        }

        private void toolStripButtonZoomOut_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.GlobalInfo.ChangeSize(0.8f);
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);

        }

        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;
            CompleteScreening.GlobalInfo.ChangeSize(1.2f);
            CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);

        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GlobalSelection(false);
            // CompleteScreening.GlobalInfo.IsDisplayClassOnly = checkBoxDisplayClasses.Checked;
            if (CompleteScreening != null)
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void globalIfOnlyActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalSelection(true);

            if (CompleteScreening != null)
                CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, false);
        }

        private void HCSAnalyzer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files[0].Remove(0, files[0].Length - 4) == ".csv")
                {
                    LoadCSVAssay(files, false);
                    UpdateUIAfterLoading();
                }
            }
            return;
        }



        void UpDateProcessModefromGUI()
        {
            if (ProcessModeplateByPlateToolStripMenuItem.Checked)
                GlobalInfo.ProcessMode = eProcessMode.PLATE_BY_PLATE;
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
                GlobalInfo.ProcessMode = eProcessMode.ENTIRE_SCREENING;
            else
                GlobalInfo.ProcessMode = eProcessMode.SINGLE_PLATE;
        }


        private void processModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessModeplateByPlateToolStripMenuItem.Checked = false;
            ProcessModeEntireScreeningToolStripMenuItem.Checked = false;
            toolStripDropDownButtonProcessMode.Text = "Current Plate";

        }

        private void plateByPlateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessModeEntireScreeningToolStripMenuItem.Checked = false;
            ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked = false;
            toolStripDropDownButtonProcessMode.Text = "Plate by Plate";
        }

        private void entireScreeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessModeplateByPlateToolStripMenuItem.Checked = false;
            ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked = false;
            toolStripDropDownButtonProcessMode.Text = "Entire Screening";
        }


        private void listBoxSelectedWells_MouseDown(object sender, MouseEventArgs e)
        {
            // first: get the well
            cWell SelectedWell = null;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip NewMenu = new ContextMenuStrip();

                ToolStripMenuItem ToolStripMenuItem_Clear = new ToolStripMenuItem("Clear");
                ToolStripMenuItem_Clear.Click += new System.EventHandler(this.ToolStripMenuItem_Clear);
                NewMenu.Items.Add(ToolStripMenuItem_Clear);
                int IdxItem = listBoxSelectedWells.IndexFromPoint(e.Location);

                if (IdxItem != -1)
                {
                    SelectedWell = GlobalInfo.ListSelectedWell[IdxItem];
                    foreach (var item in SelectedWell.GetExtendedContextMenu())
                        NewMenu.Items.Add(item);
                }
                NewMenu.Show(Control.MousePosition);
            }
        }

        private void ToolStripMenuItem_Clear(object sender, EventArgs e)
        {
            listBoxSelectedWells.Items.Clear();
            GlobalInfo.ListSelectedWell.Clear();
        }


        private void testBoxPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            cPlate TmpPlate = CompleteScreening.GetCurrentDisplayPlate();
            List<cWell> ListWellsToProcess = new List<cWell>();
            // cExtendedList ListClasses = new cExtendedList();
            // ListClasses.Name = "Classes";
            foreach (cWell item in TmpPlate.ListActiveWells)
            {
                if (item.GetClassIdx() != -1)
                {
                    if (ListClassSelected[item.GetClassIdx()] == 1)
                    {
                        ListWellsToProcess.Add(item);
                        // ListClasses.Add(item.GetClassIdx());
                    }
                }
            }

            cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
            // NewTable.Add(ListClasses);


            cViewerBoxPlot CV = new cViewerBoxPlot();
            CV.SetInputData(NewTable);
            CV.Run();

            //cDesignerSinglePanel CDP = new cDesignerSinglePanel();
            //CDP.SetInputData(CV.GetOutPut());
            //CDP.Run();

            cDisplayToWindow CDW = new cDisplayToWindow();
            CDW.SetInputData(CV.GetOutPut());
            CDW.Title = CV.Title;
            CDW.Run();
            CDW.Display();






        }

        private void zScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region obsolete
            //List<double> Pos = new List<double>();
            //List<double> Neg = new List<double>();
            //List<cSimpleSignature> ZFactorList = new List<cSimpleSignature>();

            //int NumDesc = CompleteScreening.ListDescriptors.Count;

            //cWell TempWell;
            //// loop on all the desciptors
            //for (int Desc = 0; Desc < NumDesc; Desc++)
            //{
            //    Pos.Clear();
            //    Neg.Clear();

            //    if (CompleteScreening.ListDescriptors[Desc].IsActive() == false) continue;

            //    for (int row = 0; row < CompleteScreening.Rows; row++)
            //        for (int col = 0; col < CompleteScreening.Columns; col++)
            //        {
            //            TempWell = CompleteScreening.GetCurrentDisplayPlate().GetWell(col, row, true);
            //            if (TempWell == null) continue;
            //            else
            //            {
            //                if (TempWell.GetClassIdx() == 0)
            //                    Pos.Add(TempWell.ListDescriptors[Desc].GetValue());
            //                if (TempWell.GetClassIdx() == 1)
            //                    Neg.Add(TempWell.ListDescriptors[Desc].GetValue());
            //            }
            //        }
            //    if (Pos.Count < 3)
            //    {
            //        MessageBox.Show("No or not enough positive controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //    if (Neg.Count < 3)
            //    {
            //        MessageBox.Show("No or not enough negative controls !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }


            //    double ZScore = 1 - 3 * (std(Pos.ToArray()) + std(Neg.ToArray())) / (Math.Abs(Mean(Pos.ToArray()) - Mean(Neg.ToArray())));
            //    GlobalInfo.ConsoleWriteLine(CompleteScreening.ListDescriptors[Desc].GetName() + ", Z-Score = " + ZScore);
            //    cSimpleSignature TmpDesc = new cSimpleSignature(CompleteScreening.ListDescriptors[Desc].GetName(), ZScore);
            //    ZFactorList.Add(TmpDesc);
            //}

            //ZFactorList.Sort(delegate(cSimpleSignature p1, cSimpleSignature p2) { return p1.AverageValue.CompareTo(p2.AverageValue); });

            //Series CurrentSeries = new Series();
            //CurrentSeries.ChartType = SeriesChartType.Column;
            //CurrentSeries.ShadowOffset = 1;

            //Series SeriesLine = new Series();
            //SeriesLine.Name = "SeriesLine";
            //SeriesLine.ShadowOffset = 1;
            //SeriesLine.ChartType = SeriesChartType.Line;

            //int RealIdx = 0;
            //for (int IdxValue = 0; IdxValue < ZFactorList.Count; IdxValue++)
            //{
            //    if (double.IsNaN(ZFactorList[IdxValue].AverageValue)) continue;
            //    if (double.IsInfinity(ZFactorList[IdxValue].AverageValue)) continue;

            //    CurrentSeries.Points.Add(ZFactorList[IdxValue].AverageValue);
            //    CurrentSeries.Points[RealIdx].Label = ZFactorList[IdxValue].AverageValue.ToString("N2");
            //    CurrentSeries.Points[RealIdx].Font = new Font("Arial", 10);
            //    CurrentSeries.Points[RealIdx].ToolTip = ZFactorList[IdxValue].Name;
            //    CurrentSeries.Points[RealIdx].AxisLabel = ZFactorList[IdxValue].Name;

            //    SeriesLine.Points.Add(ZFactorList[IdxValue].AverageValue);
            //    SeriesLine.Points[RealIdx].BorderColor = Color.Black;
            //    SeriesLine.Points[RealIdx].MarkerStyle = MarkerStyle.Circle;
            //    SeriesLine.Points[RealIdx].MarkerSize = 4;
            //    RealIdx++;
            //}

            //SimpleForm NewWindow = new SimpleForm(CompleteScreening);
            //int thisWidth = 200 * RealIdx;
            //if (thisWidth > (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value) thisWidth = (int)GlobalInfo.OptionsWindow.numericUpDownMaximumWidth.Value;
            //NewWindow.Width = thisWidth;
            //NewWindow.Height = 400;
            //NewWindow.Text = "Z-factors";

            //ChartArea CurrentChartArea = new ChartArea();
            //CurrentChartArea.BorderColor = Color.Black;
            //CurrentChartArea.AxisX.Interval = 1;
            //NewWindow.chartForSimpleForm.Series.Add(CurrentSeries);
            //NewWindow.chartForSimpleForm.Series.Add(SeriesLine);

            //CurrentChartArea.AxisX.IsLabelAutoFit = true;
            //NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);

            //CurrentChartArea.Axes[1].Maximum = 2;
            //CurrentChartArea.Axes[1].IsMarksNextToAxis = true;
            //CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            //CurrentChartArea.Axes[1].MajorGrid.Enabled = false;

            //NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            //CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            //CurrentChartArea.BackColor = CompleteScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            //CurrentChartArea.BackSecondaryColor = Color.White;

            //CurrentChartArea.AxisX.ScaleView.Zoomable = true;
            //CurrentChartArea.AxisY.ScaleView.Zoomable = true;

            //Title CurrentTitle = new Title(CompleteScreening.GetCurrentDisplayPlate().Name + " Z-factors");
            //CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            //NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);

            //NewWindow.Show();
            //NewWindow.chartForSimpleForm.Update();
            //NewWindow.chartForSimpleForm.Show();
            //NewWindow.AutoScroll = true;
            //NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
            #endregion

            cGUI_2ClassesSelection GUI_ListClasses = new cGUI_2ClassesSelection();

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedTable ListClassSelected = GUI_ListClasses.GetOutPut();

            int IdxClassNeg = -1;
            int IdxClassPos = -1;
            for (int IdxC = 0; IdxC < ListClassSelected[0].Count; IdxC++)
            {
                if (ListClassSelected[0][IdxC] == 1) IdxClassNeg = IdxC;
                if (ListClassSelected[1][IdxC] == 1) IdxClassPos = IdxC;
            }

            #region single plate and plate by plate

            cDesignerTab DT = new cDesignerTab();
            if ((ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked) || (ProcessModeplateByPlateToolStripMenuItem.Checked)/*||(ProcessModeEntireScreeningToolStripMenuItem.Checked)*/)
            {
                List<cPlate> ListPlatesToProcess = new List<cPlate>();
                if ((ProcessModeplateByPlateToolStripMenuItem.Checked)/*||(ProcessModeEntireScreeningToolStripMenuItem.Checked)*/)
                {
                    foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                        ListPlatesToProcess.Add(TmpPlate);
                }
                else
                    ListPlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());

                foreach (cPlate TmpPlate in ListPlatesToProcess)
                {
                    List<cWell> ListWellsToProcess1 = new List<cWell>();
                    List<cWell> ListWellsToProcess2 = new List<cWell>();

                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[0][item.GetClassIdx()] == 1)
                                ListWellsToProcess1.Add(item);
                            if (ListClassSelected[1][item.GetClassIdx()] == 1)
                                ListWellsToProcess2.Add(item);
                        }
                    }

                    cExtendedTable NewTable1 = new cExtendedTable(ListWellsToProcess1, true);
                    cExtendedTable NewTable2 = new cExtendedTable(ListWellsToProcess2, true);

                    if ((NewTable1.Count == 0) || (NewTable1[0].Count < 3) || (NewTable2.Count == 0) || (NewTable2[0].Count < 3))
                    {
                        if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Insufficient number of control wells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            continue;
                    }

                    cExtendedList ListZ = new cExtendedList();
                    List<cDescriptorsType> ListDescForZFactor = new List<cDescriptorsType>();
                    List<string> ListNames = new List<string>();
                    int RealIdx = 0;
                    for (int IDxDesc = 0; IDxDesc < CompleteScreening.ListDescriptors.Count; IDxDesc++)
                    {
                        if (!CompleteScreening.ListDescriptors[IDxDesc].IsActive()) continue;

                        cExtendedTable TableForZ = new cExtendedTable();

                        TableForZ.Add(NewTable1[RealIdx]);
                        TableForZ.Add(NewTable2[RealIdx]);
                        RealIdx++;

                        cZFactor ZF = new cZFactor();
                        ZF.SetInputData(TableForZ);
                        ZF.Run();
                        ListZ.Add(ZF.GetOutPut()[0][1]);

                        ListDescForZFactor.Add(CompleteScreening.ListDescriptors[IDxDesc]);

                    }

                    cExtendedTable ET = new cExtendedTable(new cExtendedTable(ListZ));
                    ET[0].ListTags = new List<object>();
                    ET[0].ListTags.AddRange(ListDescForZFactor);
                    ET.Name = TmpPlate.Name + "\nZ-factor - " + GlobalInfo.ListWellClasses[IdxClassNeg].Name + " (" + NewTable1[0].Count + " wells) vs. " + GlobalInfo.ListWellClasses[IdxClassPos].Name + " (" + NewTable2[0].Count + " wells)";
                    ET[0].Name = ET.Name;

                    cSort S = new cSort();
                    S.SetInputData(ET);
                    S.ColumnIndexForSorting = 0;
                    S.Run();

                    //ZFactorList.Sort(delegate(cSimpleSignature p1, cSimpleSignature p2) { return p1.AverageValue.CompareTo(p2.AverageValue); });
                    cViewerGraph1D VG1 = new cViewerGraph1D();
                    VG1.SetInputData(S.GetOutPut());

                    VG1.Chart.LabelAxisY = "Z-factor";
                    VG1.Chart.LabelAxisX = "Descriptor";
                    VG1.Chart.IsZoomableX = true;
                    VG1.Chart.IsBar = true;
                    VG1.Chart.IsBorder = true;
                    VG1.Chart.IsDisplayValues = true;
                    VG1.Chart.IsShadow = true;
                    VG1.Chart.MarkerSize = 4;
                    VG1.Title = TmpPlate.Name;
                    VG1.Run();

                    DT.SetInputData(VG1.GetOutPut());
                }
                DT.Run();

                cDisplayToWindow CDW = new cDisplayToWindow();
                CDW.SetInputData(DT.GetOutPut());//VG1.GetOutPut());


                if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                    CDW.Title = "Z-factor - " + ListPlatesToProcess[0].Name;
                else
                    CDW.Title = "Z-factor - " + ListPlatesToProcess.Count + " plates";

                CDW.Run();
                CDW.Display();
            }
            #endregion
            #region entire screening
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cPlate> ListPlatesToProcess = new List<cPlate>();
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    ListPlatesToProcess.Add(TmpPlate);

                cExtendedList ListZ = new cExtendedList();
                List<cPlate> ListPlatesForZFactor = new List<cPlate>();
                foreach (cPlate TmpPlate in ListPlatesToProcess)
                {
                    List<cWell> ListWellsToProcess1 = new List<cWell>();
                    List<cWell> ListWellsToProcess2 = new List<cWell>();

                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[0][item.GetClassIdx()] == 1)
                                ListWellsToProcess1.Add(item);
                            if (ListClassSelected[1][item.GetClassIdx()] == 1)
                                ListWellsToProcess2.Add(item);
                        }
                    }

                    cExtendedTable NewTable1 = new cExtendedTable(ListWellsToProcess1, CompleteScreening.ListDescriptors.GetDescriptorIndex(CompleteScreening.ListDescriptors.GetActiveDescriptor()));
                    cExtendedTable NewTable2 = new cExtendedTable(ListWellsToProcess2, CompleteScreening.ListDescriptors.GetDescriptorIndex(CompleteScreening.ListDescriptors.GetActiveDescriptor()));
                    //cExtendedTable NewTable2 = new cExtendedTable(ListWellsToProcess2, false);

                    if ((NewTable1.Count == 0) || (NewTable1[0].Count < 3) || (NewTable2.Count == 0) || (NewTable2[0].Count < 3))
                    {
                        if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Insufficient number of control wells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            continue;
                    }

                    cExtendedTable TableForZ = new cExtendedTable();

                    TableForZ.Add(NewTable1[0]);
                    TableForZ.Add(NewTable2[0]);

                    cZFactor ZF = new cZFactor();
                    ZF.SetInputData(TableForZ);
                    ZF.Run();
                    ListZ.Add(ZF.GetOutPut()[0][1]);

                    ListPlatesForZFactor.Add(TmpPlate);
                }
            #endregion

                cExtendedTable ET = new cExtendedTable(new cExtendedTable(ListZ));
                ET[0].ListTags = new List<object>();
                ET[0].ListTags.AddRange(ListPlatesForZFactor);
                ET.Name = "Z-factor - " + CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();// +" - " + GlobalInfo.ListWellClasses[IdxClassNeg].Name + " (" + NewTable1[0].Count + " wells) vs. " + GlobalInfo.ListWellClasses[IdxClassPos].Name + " (" + NewTable2[0].Count + " wells)";
                ET[0].Name = ET.Name;

                cViewerGraph1D VG1 = new cViewerGraph1D();
                VG1.SetInputData(ET);

                VG1.Chart.LabelAxisY = "Z-factor";
                VG1.Chart.LabelAxisX = "Plate";
                VG1.Chart.IsZoomableX = true;
                VG1.Chart.IsBar = true;
                VG1.Chart.IsBorder = true;
                VG1.Chart.IsDisplayValues = true;
                VG1.Chart.IsShadow = true;
                VG1.Chart.MarkerSize = 4;

                VG1.Title = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                VG1.Run();

                cDisplayToWindow CDW = new cDisplayToWindow();
                CDW.SetInputData(VG1.GetOutPut());
                CDW.Title = "Z-factor - " + ListPlatesToProcess.Count + " plates";
                CDW.Run();
                CDW.Display();
            }
        }

        private void normalProbabilityPlotToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ComputeAndDisplayMormalProbabilityPlot(false);
        }

        private void systematicErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompleteScreening == null) return;

            System.Windows.Forms.DialogResult Res = MessageBox.Show("By applying this process, classes will be definitively modified ! Proceed ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Res == System.Windows.Forms.DialogResult.No) return;

            if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                List<string> Result = GenerateArtifactMessage(CompleteScreening.GetCurrentDisplayPlate(), comboBoxDescriptorToDisplay.SelectedIndex);
                MessageBox.Show(Result[1], "Systematic Error Identification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable ResultSystematicError = ComputeSystematicErrorsTable();
                dataGridViewForQualityControl.DataSource = ResultSystematicError;
                dataGridViewForQualityControl.Update();
            }
        }

        private void aToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            //if (CompleteScreening.ListDescriptors.GetListNameActives().Count <= 1)
            //{
            //    MessageBox.Show("MINE Analysis requires at least two activated descriptors\n", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //bool IsFullScreen = false;
            //List<double>[] ListValueDesc = ExtractDesciptorAverageValuesList(IsFullScreen);

            //DisplayMINE(ListValueDesc);

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab DT = new cDesignerTab();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[item.GetClassIdx()] == 1)
                                ListWellsToProcess.Add(item);
                        }
                    }

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                    cMineAnalysis MA = new cMineAnalysis();
                    MA.SetInputData(NewTable);
                    MA.Is_BriefReport = true;
                    MA.CurrentScreening = CompleteScreening;
                    MA.Run();

                    cDesignerTab SubDT = new cDesignerTab();
                    foreach (var item in MA.GetOutPut())
                    {
                        cViewerTable SubTable = new cViewerTable();

                        SubTable.Title = "MINE - " + item.Name;
                        SubTable.SetInputData(item);
                        SubTable.Run();

                        SubDT.SetInputData(SubTable.GetOutPut());
                    }
                    SubDT.Title = TmpPlate.Name;
                    SubDT.Run();
                    DT.SetInputData(SubDT.GetOutPut());
                }

                DT.Run();
                cDisplayToWindow TmpvD = new cDisplayToWindow();

                TmpvD.SetInputData(DT.GetOutPut());
                TmpvD.Title = "MINE analysis - " + CompleteScreening.ListPlatesActive.Count + " plates";
                TmpvD.Run();
                TmpvD.Display();
            }
            else if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                cPlate TmpPlate = CompleteScreening.GetCurrentDisplayPlate();

                List<cWell> ListWellsToProcess = new List<cWell>();
                foreach (cWell item in TmpPlate.ListActiveWells)
                {
                    if (item.GetClassIdx() != -1)
                    {
                        if (ListClassSelected[item.GetClassIdx()] == 1)
                            ListWellsToProcess.Add(item);
                    }
                }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                cMineAnalysis MA = new cMineAnalysis();
                MA.SetInputData(NewTable);
                MA.Is_BriefReport = true;
                MA.CurrentScreening = CompleteScreening;
                MA.Run();

                cDesignerTab SubDT = new cDesignerTab();
                foreach (var item in MA.GetOutPut())
                {
                    cViewerTable SubTable = new cViewerTable();

                    SubTable.Title = "MINE - " + item.Name;
                    SubTable.SetInputData(item);
                    SubTable.Run();

                    SubDT.SetInputData(SubTable.GetOutPut());
                }
                SubDT.Title = TmpPlate.Name;
                SubDT.Run();

                cDisplayToWindow TmpvD = new cDisplayToWindow();

                TmpvD.SetInputData(SubDT.GetOutPut());
                TmpvD.Title = "MINE analysis - " + TmpPlate.Name + " : " + ListWellsToProcess.Count + " wells";
                TmpvD.Run();
                TmpvD.Display();
            }
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if (item.GetClassIdx() != -1)
                            if (ListClassSelected[item.GetClassIdx()] == 1) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                cMineAnalysis MA = new cMineAnalysis();
                MA.SetInputData(NewTable);
                MA.Is_BriefReport = true;
                MA.CurrentScreening = CompleteScreening;
                MA.Run();

                cDesignerTab SubDT = new cDesignerTab();
                foreach (var item in MA.GetOutPut())
                {
                    cViewerTable SubTable = new cViewerTable();

                    SubTable.Title = "MINE - " + item.Name;
                    SubTable.SetInputData(item);
                    SubTable.Run();

                    SubDT.SetInputData(SubTable.GetOutPut());
                }
                SubDT.Run();

                cDisplayToWindow TmpvD = new cDisplayToWindow();

                TmpvD.SetInputData(SubDT.GetOutPut());
                TmpvD.Title = "MINE analysis : " + ListWellsToProcess.Count + " wells";
                TmpvD.Run();
                TmpvD.Display();
            }

        }

        private void correlationMatrixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            cDesignerTab DT = new cDesignerTab();

            if (this.ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    //ListWellsToProcess.AddRange(TmpPlate.ListActiveWells);
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);
                    }

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                    cCorrelationMatrix CM = new cCorrelationMatrix();
                    CM.SetInputData(NewTable);
                    CM.Run();

                    //cViewerHeatMap VHM = new cViewerHeatMap();
                    cViewerTable VHM = new cViewerTable();
                    VHM.SetInputData(CM.GetOutPut());
                    //VHM.IsDisplayValues = true;
                    VHM.Title = "Correlation - " + TmpPlate.Name + " (" + ListWellsToProcess.Count + " wells)";
                    VHM.Run();

                    DT.SetInputData(VHM.GetOutPut());
                }
            }
            else if (this.ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);
                }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                cCorrelationMatrix CM = new cCorrelationMatrix();
                CM.SetInputData(NewTable);
                CM.Run();

                //cViewerHeatMap VHM = new cViewerHeatMap();
                cViewerTable VHM = new cViewerTable();
                VHM.SetInputData(CM.GetOutPut());
                //VHM.IsDisplayValues = true;
                VHM.Title = "Correlation - Entire screening (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }
            else
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                    if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                cCorrelationMatrix CM = new cCorrelationMatrix();
                CM.SetInputData(NewTable);
                CM.Run();

                //cViewerHeatMap VHM = new cViewerHeatMap();
                cViewerTable VHM = new cViewerTable();
                VHM.SetInputData(CM.GetOutPut());
                //VHM.IsDisplayValues = true;
                VHM.Title = "Correlation - " + CompleteScreening.GetCurrentDisplayPlate().Name + " (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }

            DT.Run();

            //  DT.SetInputData(VT.GetOutPut());

            //cDesignerColumn DC = new cDesignerColumn();  
            //DC.SetInputData(VHM.GetOutPut());
            //DC.SetInputData(VT.GetOutPut());
            //DC.Run();

            //cDisplayDesigner DD = new cDisplayDesigner();
            // DD.SetInputData(VHM.GetOutPut());
            // DD.Run();

            cDisplayToWindow vD = new cDisplayToWindow();
            vD.SetInputData(DT.GetOutPut());
            vD.Title = "Pearson Correlation";
            vD.Run();
            vD.Display();

            //ComputeAndDisplayCorrelationMatrix(false, true, null);
        }

        private void ftestdescBasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cDesignerTab DT = new cDesignerTab();

            cTwoSampleFTest CM = new cTwoSampleFTest();
            CM.FTestTails = eFTestTails.BOTH;

            if (this.ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);


                    CM.SetInputData(NewTable);
                    CM.Run();

                    cViewerHeatMap VHM = new cViewerHeatMap();
                    VHM.SetInputData(CM.GetOutPut());
                    VHM.IsDisplayValues = true;
                    VHM.Title = "F-Test - " + TmpPlate.Name + " (" + ListWellsToProcess.Count + " wells)";
                    VHM.Run();

                    DT.SetInputData(VHM.GetOutPut());
                }
            }
            else if (this.ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);
                }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                //  cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
                CM.Run();

                cViewerHeatMap VHM = new cViewerHeatMap();
                VHM.SetInputData(CM.GetOutPut());
                VHM.IsDisplayValues = true;
                VHM.Title = "F-Test - Entire screening (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }
            else
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                    if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                // cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
                CM.Run();

                cViewerHeatMap VHM = new cViewerHeatMap();
                VHM.SetInputData(CM.GetOutPut());
                VHM.IsDisplayValues = true;
                VHM.Title = "F-Test - " + CompleteScreening.GetCurrentDisplayPlate().Name + " (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }

            DT.Run();
            cDisplayToWindow vD = new cDisplayToWindow();
            vD.SetInputData(DT.GetOutPut());
            vD.Title = "F-Test";
            vD.Run();
            vD.Display();
        }

        private void stackedHistogramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cDisplayToWindow CDW1 = new cDisplayToWindow();


            if ((ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked) || (ProcessModeEntireScreeningToolStripMenuItem.Checked))
            {
                cListWell ListWellsToProcess = new cListWell(null);
                List<cPlate> PlateList = new List<cPlate>();

                if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                    PlateList.Add(CompleteScreening.GetCurrentDisplayPlate());
                else
                {
                    foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive) PlateList.Add(TmpPlate);
                }

                foreach (cPlate TmpPlate in PlateList)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);


                if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                    CDW1.Title = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Stacked Histogram (" + PlateList[0].Name + ")";
                else
                    CDW1.Title = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Stacked Histogram - " + PlateList.Count + " plates";

                cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, true);
                NewTable.Name = CDW1.Title;

                cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
                CV1.SetInputData(NewTable);
                CV1.Chart.LabelAxisX = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                CV1.Run();

                CDW1.SetInputData(CV1.GetOutPut());
            }
            else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab CDT = new cDesignerTab();
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    cListWell ListWellsToProcess = new cListWell(null);
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                    cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx, true);
                    NewTable.Name = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - " + TmpPlate.Name;


                    cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
                    CV1.SetInputData(NewTable);
                    CV1.Chart.LabelAxisX = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                    CV1.Title = TmpPlate.Name;
                    CV1.Run();

                    CDT.SetInputData(CV1.GetOutPut());
                }
                CDT.Run();
                CDW1.SetInputData(CDT.GetOutPut());
                CDW1.Title = "Stacked Histogram - " + CompleteScreening.ListPlatesActive.Count + " plates";
            }

            CDW1.Run();
            CDW1.Display();
        }

        private void testLinearRegressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<cWell> ListWellsToProcess = new List<cWell>();

            foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                if (item.GetClassIdx() != -1) ListWellsToProcess.Add(item);

            cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

            cLinearRegression LR = new cLinearRegression();
            LR.SetInputData(NewTable);
            LR.Run();



            cViewerTable VT = new cViewerTable();
            VT.SetInputData(LR.GetOutPut());
            VT.Run();


            cDisplayToWindow vD = new cDisplayToWindow();
            vD.SetInputData(VT.GetOutPut());
            vD.Title = "Linear regression (Test)";
            vD.Run();
            vD.Display();

        }

        private void covarianceMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cDisplayToWindow vD = new cDisplayToWindow();
            cDesignerTab DT = new cDesignerTab();

            cCovarianceMatrix CM = new cCovarianceMatrix();
            // CM.FTestTails = eFTestTails.BOTH;

            if (this.ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);


                    CM.SetInputData(NewTable);
                    CM.Run();

                    //cViewerHeatMap VHM = new cViewerHeatMap();
                    cViewerTable VHM = new cViewerTable();
                    VHM.SetInputData(CM.GetOutPut());
                    //VHM.IsDisplayValues = true;
                    vD.Title = "Covariance - " + TmpPlate.Name + " (" + ListWellsToProcess.Count + " wells)";
                    VHM.Run();

                    DT.SetInputData(VHM.GetOutPut());
                }
            }
            else if (this.ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);
                }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                //  cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
                CM.Run();

                // cViewerHeatMap VHM = new cViewerHeatMap();
                cViewerTable VHM = new cViewerTable();
                VHM.SetInputData(CM.GetOutPut());
                //VHM.IsDisplayValues = true;
                vD.Title = "Covariance - Entire screening (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }
            else
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                    if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                // cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
                CM.Run();

                //cViewerHeatMap VHM = new cViewerHeatMap();
                cViewerTable VHM = new cViewerTable();
                VHM.SetInputData(CM.GetOutPut());
                //VHM.IsDisplayValues = true;
                vD.Title = "Covariance - " + CompleteScreening.GetCurrentDisplayPlate().Name + " (" + ListWellsToProcess.Count + " wells)";
                VHM.Run();

                DT.SetInputData(VHM.GetOutPut());
            }

            DT.Run();

            vD.SetInputData(DT.GetOutPut());
            // vD.Title = "F-Test";
            vD.Run();
            vD.Display();
        }

        private void mahalanobisDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            //GUI_ListClasses. = true;
            GUI_ListClasses.Title = "Reference cloud";


            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // start by computing the inversed covariance matrix
            if (checkedListBoxActiveDescriptors.CheckedItems.Count <= 1)
            {
                MessageBox.Show("At least two descriptors have to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            cCovarianceMatrix CM = new cCovarianceMatrix();
            // CM.FTestTails = eFTestTails.BOTH;

            cExtendedTable NewTable = null;

            if (this.ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                //foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                //{
                //    List<cWell> ListWellsToProcess = new List<cWell>();
                //    foreach (cWell item in TmpPlate.ListActiveWells)
                //        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                //    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);

                //    CM.SetInputData(NewTable);
                //}
            }
            else if (this.ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                NewTable = new cExtendedTable(ListWellsToProcess, true);

                //  cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
            }
            else
            {
                List<cWell> ListWellsToProcess = new List<cWell>();

                foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                    if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                NewTable = new cExtendedTable(ListWellsToProcess, true);

                // cTwoSampleFTest CM = new cTwoSampleFTest();
                CM.SetInputData(NewTable);
            }

            CM.Run();

            cInverse cI = new cInverse();
            cI.SetInputData(CM.GetOutPut());
            cI.Run();

            // get the cloud center
            cStatistics cstat = new cStatistics();
            cstat.IsMean = true;
            cstat.IsMAD = false;
            cstat.IsMax = false;
            cstat.IsMedian = false;
            cstat.IsStdDev = false;
            cstat.IsSum = false;
            cstat.SetInputData(NewTable);
            cstat.Run();

            if (cstat.GetOutPut() == null) return;

            cExtendedList ListMeans = cstat.GetOutPut().GetRow(0);

            cDescriptorsType MahalanobisType = new cDescriptorsType("Mahalanobis Distance", true, 1, GlobalInfo);

            foreach (cPlate TmpPlate in CompleteScreening.ListPlatesAvailable)
            {
                for (int Col = 0; Col < CompleteScreening.Columns; Col++)
                    for (int Row = 0; Row < CompleteScreening.Rows; Row++)
                    {
                        cWell TmpWell = TmpPlate.GetWell(Col, Row, false);
                        if (TmpWell == null) continue;

                        double Value = TmpWell.GetAverageValuesList(true).Dist_Mahalanobis(ListMeans, cI.GetOutPut());

                        List<cDescriptor> LDesc = new List<cDescriptor>();

                        cDescriptor NewDesc = new cDescriptor(Value, MahalanobisType, CompleteScreening);
                        LDesc.Add(NewDesc);

                        TmpWell.AddDescriptors(LDesc);
                    }
            }


            CompleteScreening.ListDescriptors.AddNew(MahalanobisType);
            CompleteScreening.ListDescriptors.UpDateDisplay();
            CompleteScreening.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < CompleteScreening.ListPlatesActive.Count; idxP++)
                CompleteScreening.ListPlatesActive[idxP].UpDataMinMax();
        }

        private void pCAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            cDisplayToWindow vD = new cDisplayToWindow();

            if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                cPlate TmpPlate = CompleteScreening.GetCurrentDisplayPlate();
                List<cWell> ListWellsToProcess = new List<cWell>();
                //    cExtendedList ListClasses = new cExtendedList();
                //    ListClasses.Name = "Classes";
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                // NewTable.Add(ListClasses);

                cProjectorPCA PCA = new cProjectorPCA();
                PCA.SetInputData(NewTable);
                cFeedBackMessage FM = PCA.Run();
                if (!FM.IsSucceed)
                {
                    MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cViewerTable VHM = new cViewerTable();
                cExtendedTable CT = PCA.GetOutPut();

                foreach (var item in CT)
                {
                    cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);
                    foreach (cDescriptorsType Desc in item.ListTags)
                        DLC.Add(Desc);
                    item.Tag = DLC;
                }

                VHM.SetInputData(CT);
                VHM.Run();

                vD.SetInputData(VHM.GetOutPut());
                vD.Title = "PCA - " + TmpPlate.Name + " : " + ListWellsToProcess.Count + " wells";
            }
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();
                // cExtendedList ListClasses = new cExtendedList();
                //  ListClasses.Name = "Classes";

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                //NewTable.Add(ListClasses);
                cProjectorPCA PCA = new cProjectorPCA();
                PCA.SetInputData(NewTable);
                cFeedBackMessage FM = PCA.Run();
                if (!FM.IsSucceed)
                {
                    MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cViewerTable VHM = new cViewerTable();
                cExtendedTable CT = PCA.GetOutPut();
                foreach (var item in CT)
                {
                    cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);
                    foreach (cDescriptorsType Desc in item.ListTags)
                        DLC.Add(Desc);
                    item.Tag = DLC;
                }

                VHM.SetInputData(CT);
                //VHM.SetInputData(PCA.GetOutPut());
                VHM.Run();

                vD.SetInputData(VHM.GetOutPut());
                vD.Title = "PCA - " + ListWellsToProcess.Count + " wells.";
            }
            else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab CDT = new cDesignerTab();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    //cExtendedList ListClasses = new cExtendedList();
                    //ListClasses.Name = "Classes";

                    foreach (cWell item in TmpPlate.ListActiveWells)
                        if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1)) ListWellsToProcess.Add(item);

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                    //NewTable.Add(ListClasses);
                    NewTable.Name = TmpPlate.Name;

                    cProjectorPCA PCA = new cProjectorPCA();
                    PCA.SetInputData(NewTable);
                    cFeedBackMessage FM = PCA.Run();
                    if (!FM.IsSucceed)
                    {
                        MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cViewerTable VHM = new cViewerTable();
                    cExtendedTable CT = PCA.GetOutPut();

                    foreach (var item in CT)
                    {
                        cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);
                        foreach (cDescriptorsType Desc in item.ListTags)
                            DLC.Add(Desc);
                        item.Tag = DLC;
                    }

                    VHM.SetInputData(CT);

                    //VHM.SetInputData(PCA.GetOutPut());
                    VHM.Run();
                    CDT.SetInputData(VHM.GetOutPut());
                }
                CDT.Run();
                vD.SetInputData(CDT.GetOutPut());
            }
            else
                return;

            vD.Run();
            vD.Display();
        }

        private void lDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 2)
            {
                MessageBox.Show("At least two classes have to be selected to perfom a LDA.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cDisplayToWindow vD = new cDisplayToWindow();

            if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {
                cPlate TmpPlate = CompleteScreening.GetCurrentDisplayPlate();
                List<cWell> ListWellsToProcess = new List<cWell>();
                cExtendedList ListClasses = new cExtendedList();
                ListClasses.Name = "Classes";
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if ((item.GetClassIdx() != -1) && (ListClassSelected[item.GetClassIdx()] == 1))
                    {
                        ListWellsToProcess.Add(item);
                        ListClasses.Add(item.GetClassIdx());
                    }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                NewTable.Add(ListClasses);

                cProjectorLDA LDA = new cProjectorLDA();
                LDA.SetInputData(NewTable);
                cFeedBackMessage FM = LDA.Run();
                if (!FM.IsSucceed)
                {
                    MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cViewerTable VHM = new cViewerTable();
                cExtendedTable CT = LDA.GetOutPut();

                foreach (var item in CT)
                {
                    cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);
                    foreach (cDescriptorsType Desc in item.ListTags)
                        DLC.Add(Desc);
                    item.Tag = DLC;
                }
                VHM.SetInputData(CT);
                VHM.Run();

                vD.SetInputData(VHM.GetOutPut());
                vD.Title = "LDA - " + TmpPlate.Name + " : " + ListWellsToProcess.Count + " wells";
            }
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cWell> ListWellsToProcess = new List<cWell>();
                cExtendedList ListClasses = new cExtendedList();
                ListClasses.Name = "Classes";

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[item.GetClassIdx()] == 1)
                            {
                                ListWellsToProcess.Add(item);
                                ListClasses.Add(item.GetClassIdx());
                            }
                        }
                    }
                }

                cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                NewTable.Add(ListClasses);
                cProjectorLDA LDA = new cProjectorLDA();
                LDA.SetInputData(NewTable);
                cFeedBackMessage FM = LDA.Run();
                if (!FM.IsSucceed)
                {
                    MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cExtendedTable CT = LDA.GetOutPut();

                foreach (var item in CT)
                {
                    cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);

                    foreach (cDescriptorsType Desc in item.ListTags)
                        DLC.Add(Desc);

                    item.Tag = DLC;
                }

                cViewerTable VHM = new cViewerTable();
                VHM.SetInputData(CT);

                VHM.Run();

                vD.SetInputData(VHM.GetOutPut());
                vD.Title = "LDA - " + ListWellsToProcess.Count + " wells.";
            }
            else if (ProcessModeplateByPlateToolStripMenuItem.Checked)
            {
                cDesignerTab CDT = new cDesignerTab();

                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                {
                    List<cWell> ListWellsToProcess = new List<cWell>();
                    cExtendedList ListClasses = new cExtendedList();
                    ListClasses.Name = "Classes";


                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[item.GetClassIdx()] == 1)
                            {
                                ListWellsToProcess.Add(item);
                                ListClasses.Add(item.GetClassIdx());
                            }
                        }
                    }

                    cExtendedTable NewTable = new cExtendedTable(ListWellsToProcess, true);
                    NewTable.Add(ListClasses);
                    NewTable.Name = TmpPlate.Name;

                    cProjectorLDA LDA = new cProjectorLDA();
                    LDA.SetInputData(NewTable);
                    cFeedBackMessage FM = LDA.Run();
                    if (!FM.IsSucceed)
                    {
                        MessageBox.Show(FM.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cExtendedTable CT = LDA.GetOutPut();

                    foreach (var item in CT)
                    {
                        cDescriptorsLinearCombination DLC = new cDescriptorsLinearCombination(item, CompleteScreening.GlobalInfo);

                        foreach (cDescriptorsType Desc in item.ListTags)
                            DLC.Add(Desc);

                        item.Tag = DLC;
                    }

                    cViewerTable VHM = new cViewerTable();
                    VHM.SetInputData(CT);
                    VHM.Run();
                    CDT.SetInputData(VHM.GetOutPut());
                }
                CDT.Run();
                vD.SetInputData(CDT.GetOutPut());
            }
            else
                return;

            vD.Run();
            vD.Display();
        }

        private void testMultiScatterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //V1D.Chart.LabelAxisX = "Well Index";
            //V1D.Chart.LabelAxisY = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptor].GetName();
            //V1D.Chart.BackgroundColor = Color.LightYellow;
            //V1D.Chart.IsXAxis = true;


            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();
            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedList ListClassSelected = GUI_ListClasses.GetOutPut();

            if (ListClassSelected.Sum() < 1)
            {
                MessageBox.Show("At least one classe has to be selected.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            cDesignerSplitter CDC = new cDesignerSplitter();
            List<cWell> ListWellsToProcess = new List<cWell>();

            //foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
            foreach (cWell item in CompleteScreening.GetCurrentDisplayPlate().ListActiveWells)
                if (item.GetClassIdx() != -1)
                    if (ListClassSelected[item.GetClassIdx()] == 1) ListWellsToProcess.Add(item);

            cExtendedTable DataFromPlate = new cExtendedTable(ListWellsToProcess, true);
            DataFromPlate.Name = CompleteScreening.GetCurrentDisplayPlate().Name;

            //if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
            {


                for (int IdxDesc0 = 0; IdxDesc0 < DataFromPlate.Count; IdxDesc0++)
                    for (int IdxDesc1 = 1; IdxDesc1 < DataFromPlate.Count; IdxDesc1++)
                    {


                        cViewer2DScatterPoint V1D = new cViewer2DScatterPoint();
                        V1D.Chart.CurrentTitle.Tag = CompleteScreening.GetCurrentDisplayPlate();
                        V1D.Chart.IdxDesc0 = IdxDesc0;
                        V1D.Chart.IdxDesc1 = IdxDesc1;
                        V1D.SetInputData(DataFromPlate);
                        V1D.Run();
                        V1D.Chart.Width = 0;
                        V1D.Chart.Height = 0;

                        cDesignerSinglePanel Designer0 = new cDesignerSinglePanel();
                        Designer0.SetInputData(V1D.GetOutPut());
                        Designer0.Run();

                        CDC.SetInputData(Designer0.GetOutPut());
                    }
            }

            CDC.Run();

            cDisplayToWindow Disp0 = new cDisplayToWindow();
            Disp0.SetInputData(CDC.GetOutPut());
            Disp0.Title = "2D Scatter points graph - wells.";
            if (!Disp0.Run().IsSucceed) return;
            Disp0.Display();

        }

        private void statisticsToolStripMenuItem1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button != System.Windows.Forms.MouseButtons.Right) || (CompleteScreening == null)) return;

            contextMenuStripStatOptions.Show(Control.MousePosition);
        }



        void StatMeanItem(object sender, EventArgs e)
        {
            statisticsToolStripMenuItem1.Text = "Statistics (Mean)";
            _StatMeanItem.Checked = true;
            _StatCVItem.Checked = false;
            _StatSumItem.Checked = false;

        }

        void StatCVItem(object sender, EventArgs e)
        {
            statisticsToolStripMenuItem1.Text = "Statistics (Coefficient of Variation)";
            _StatCVItem.Checked = true;
            _StatMeanItem.Checked = false;
            _StatSumItem.Checked = false;
        }

        void StatSumItem(object sender, EventArgs e)
        {
            statisticsToolStripMenuItem1.Text = "Statistics (Sum)";
            _StatSumItem.Checked = true;
            _StatCVItem.Checked = false;
            _StatMeanItem.Checked = false;
        }


        private void statisticsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string NameFunction = "";

            if (_StatCVItem.Checked)
                NameFunction = "Coeff. of Variation";
            else if (_StatMeanItem.Checked)
                NameFunction = "Mean";
            else if (_StatSumItem.Checked)
                NameFunction = "Sum";

            cGUI_ListClasses GUI_ListClasses = new cGUI_ListClasses();

            GUI_ListClasses.IsCheckBoxes = true;
            GUI_ListClasses.IsSelectAll = true;

            if (GUI_ListClasses.Run(this.GlobalInfo).IsSucceed == false) return;
            cExtendedTable ListClassSelected = new cExtendedTable(GUI_ListClasses.GetOutPut());// GetOutPut();


            int IdxClass = -1;
            for (int IdxC = 0; IdxC < ListClassSelected[0].Count; IdxC++)
            {
                if (ListClassSelected[0][IdxC] == 1) IdxClass = IdxC;
            }

            #region single plate and plate by plate

            cDesignerTab DT = new cDesignerTab();
            if ((ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked) || (ProcessModeplateByPlateToolStripMenuItem.Checked)/*||(ProcessModeEntireScreeningToolStripMenuItem.Checked)*/)
            {
                List<cPlate> ListPlatesToProcess = new List<cPlate>();
                if ((ProcessModeplateByPlateToolStripMenuItem.Checked)/*||(ProcessModeEntireScreeningToolStripMenuItem.Checked)*/)
                {
                    foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                        ListPlatesToProcess.Add(TmpPlate);
                }
                else
                    ListPlatesToProcess.Add(CompleteScreening.GetCurrentDisplayPlate());

                foreach (cPlate TmpPlate in ListPlatesToProcess)
                {
                    List<cWell> ListWellsToProcess1 = new List<cWell>();

                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[0][item.GetClassIdx()] == 1)
                                ListWellsToProcess1.Add(item);
                        }
                    }

                    cExtendedTable NewTable1 = new cExtendedTable(ListWellsToProcess1, true);

                    if ((NewTable1.Count == 0) || (NewTable1[0].Count < 3))
                    {
                        if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Insufficient number of control wells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            continue;
                    }

                    cExtendedList ListValues = new cExtendedList();
                    List<cDescriptorsType> ListDescs = new List<cDescriptorsType>();
                    List<string> ListNames = new List<string>();
                    int RealIdx = 0;
                    for (int IDxDesc = 0; IDxDesc < CompleteScreening.ListDescriptors.Count; IDxDesc++)
                    {
                        if (!CompleteScreening.ListDescriptors[IDxDesc].IsActive()) continue;

                        cExtendedTable TableForValues = new cExtendedTable();

                        TableForValues.Add(NewTable1[RealIdx]);

                        RealIdx++;

                        cStatistics CS = new cStatistics();
                        CS.UnselectAll();

                        if (_StatCVItem.Checked)
                            CS.IsCV = true;
                        else if (_StatMeanItem.Checked)
                            CS.IsMean = true;
                        else if (_StatSumItem.Checked)
                            CS.IsSum = true;


                        CS.SetInputData(TableForValues);
                        CS.Run();
                        ListValues.Add(CS.GetOutPut()[0][0]);

                        ListDescs.Add(CompleteScreening.ListDescriptors[IDxDesc]);

                    }

                    cExtendedTable ET = new cExtendedTable(new cExtendedTable(ListValues));
                    ET[0].ListTags = new List<object>();
                    ET[0].ListTags.AddRange(ListDescs);
                    ET.Name = TmpPlate.Name + "\n" + NameFunction + " - " + GlobalInfo.ListWellClasses[IdxClass].Name + " (" + NewTable1[0].Count + " wells)";
                    ET[0].Name = ET.Name;

                    cSort S = new cSort();
                    S.SetInputData(ET);
                    S.ColumnIndexForSorting = 0;
                    S.Run();

                    //ZFactorList.Sort(delegate(cSimpleSignature p1, cSimpleSignature p2) { return p1.AverageValue.CompareTo(p2.AverageValue); });
                    cViewerGraph1D VG1 = new cViewerGraph1D();
                    VG1.SetInputData(S.GetOutPut());

                    VG1.Chart.LabelAxisY = NameFunction;
                    VG1.Chart.LabelAxisX = "Descriptor";
                    VG1.Chart.IsZoomableX = true;
                    VG1.Chart.IsBar = true;
                    VG1.Chart.IsBorder = true;
                    VG1.Chart.IsDisplayValues = true;
                    VG1.Chart.IsShadow = true;
                    VG1.Chart.MarkerSize = 4;
                    VG1.Title = TmpPlate.Name;
                    VG1.Run();

                    DT.SetInputData(VG1.GetOutPut());
                }
                DT.Run();

                cDisplayToWindow CDW = new cDisplayToWindow();
                CDW.SetInputData(DT.GetOutPut());//VG1.GetOutPut());


                if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                    CDW.Title = NameFunction + " - " + ListPlatesToProcess[0].Name;
                else
                    CDW.Title = NameFunction + " - " + ListPlatesToProcess.Count + " plates";

                CDW.Run();
                CDW.Display();
            }
            #endregion
            #region entire screening
            else if (ProcessModeEntireScreeningToolStripMenuItem.Checked)
            {
                List<cPlate> ListPlatesToProcess = new List<cPlate>();
                foreach (cPlate TmpPlate in CompleteScreening.ListPlatesActive)
                    ListPlatesToProcess.Add(TmpPlate);

                cExtendedList ListZ = new cExtendedList();
                List<cPlate> ListPlatesForZFactor = new List<cPlate>();
                foreach (cPlate TmpPlate in ListPlatesToProcess)
                {
                    List<cWell> ListWellsToProcess1 = new List<cWell>();

                    foreach (cWell item in TmpPlate.ListActiveWells)
                    {
                        if (item.GetClassIdx() != -1)
                        {
                            if (ListClassSelected[0][item.GetClassIdx()] == 1)
                                ListWellsToProcess1.Add(item);
                        }
                    }


                    cExtendedTable NewTable1 = new cExtendedTable(ListWellsToProcess1, CompleteScreening.ListDescriptors.GetDescriptorIndex(CompleteScreening.ListDescriptors.GetActiveDescriptor()));


                    if ((NewTable1.Count == 0) || (NewTable1[0].Count < 3))
                    {
                        if (ProcessModeCurrentPlateOnlyToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Insufficient number of control wells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            continue;
                    }

                    cStatistics CS = new cStatistics();
                    CS.UnselectAll();

                    if (_StatCVItem.Checked)
                        CS.IsCV = true;
                    else if (_StatMeanItem.Checked)
                        CS.IsMean = true;
                    else if (_StatSumItem.Checked)
                        CS.IsSum = true;

                    CS.SetInputData(NewTable1);
                    CS.Run();
                    ListZ.Add(CS.GetOutPut()[0][0]);

                    ListPlatesForZFactor.Add(TmpPlate);
                }
            #endregion

                cExtendedTable ET = new cExtendedTable(new cExtendedTable(ListZ));
                ET[0].ListTags = new List<object>();
                ET[0].ListTags.AddRange(ListPlatesForZFactor);
                ET.Name = NameFunction + " - " + CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();// +" - " + GlobalInfo.ListWellClasses[IdxClassNeg].Name + " (" + NewTable1[0].Count + " wells) vs. " + GlobalInfo.ListWellClasses[IdxClassPos].Name + " (" + NewTable2[0].Count + " wells)";
                ET[0].Name = ET.Name;

                cViewerGraph1D VG1 = new cViewerGraph1D();
                VG1.SetInputData(ET);

                VG1.Chart.LabelAxisY = NameFunction;
                VG1.Chart.LabelAxisX = "Plate";
                VG1.Chart.IsZoomableX = true;
                VG1.Chart.IsBar = true;
                VG1.Chart.IsBorder = true;
                VG1.Chart.IsDisplayValues = true;
                VG1.Chart.IsShadow = true;
                VG1.Chart.MarkerSize = 4;
                VG1.Title = CompleteScreening.ListDescriptors[CompleteScreening.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
                VG1.Run();

                cDisplayToWindow CDW = new cDisplayToWindow();
                CDW.SetInputData(VG1.GetOutPut());
                CDW.Title = NameFunction + " - " + ListPlatesToProcess.Count + " plates";
                CDW.Run();
                CDW.Display();
            }
        }










    }

    /// <summary>
    /// If you want keep your version information,
    /// Put your version information in the AssemblyInfo.cs file
    /// [assembly: AssemblyVersion("1.0.*")]
    /// [assembly: AssemblyFileVersion("1.0.0.0")]
    /// </summary>
    public static class PluginVersion
    {
        public static string Info
        {
            get
            {
                System.Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                bool isDaylightSavingsTime = TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now);
                DateTime MyTime = new DateTime(2000, 1, 1).AddDays(v.Build).AddSeconds(v.Revision * 2).AddHours(isDaylightSavingsTime ? 1 : 0);

                return string.Format("Version:{0}.{1} - Compiled:{2:s}", v.Major, v.MajorRevision, MyTime);
            }
        }
    }
}