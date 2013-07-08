using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;
using weka.core;
using weka.clusterers;
using weka.classifiers;
using LibPlateAnalysis;
using HCSAnalyzer.Forms.IO;
using System.Threading.Tasks;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions;
using HCSAnalyzer.Forms.FormsForOptions;
using HCSAnalyzer.Forms.FormsForOptions.ClusteringInfo;
using Microsoft.Msagl.GraphViewerGdi;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions.Children;
using HCSAnalyzer.Forms.FormsForOptions.ClassificationInfo;
using weka.classifiers.trees;
using weka.classifiers.lazy;
using weka.classifiers.functions;
using weka.classifiers.functions.supportVector;
using weka.classifiers.rules;
using weka.classifiers.bayes;
using HCSAnalyzer.Classes.Machine_Learning;
using HCSAnalyzer.Cell_by_Cell_and_DB.Simulator.Forms;
using HCSAnalyzer.GUI.FormsForGraphsDisplay.Generic;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.Base_Classes.Data;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    public partial class FormForSingleCellsDisplay : Form
    {
        private DataTable dt;
        private cGlobalInfo GlobalInfo;
        cMachineLearning MachineLearning;
        FormForModelsHistory WindowForModelHistory = new FormForModelsHistory();
        ToolTip ToolTipForX = new ToolTip();
        ToolTip ToolTipForY = new ToolTip();
        ToolTip ToolTipForVolume = new ToolTip();

        public FormForSingleCellsDisplay(DataTable dt, cGlobalInfo GlobalInfo, cExtendedList ListClasses)
        {
            InitializeComponent();

            markerBorderToolStripMenuItem.Checked = IsDisplayBorder;

            this.dt = dt;
            this.GlobalInfo = GlobalInfo;

            #region initialize histograms display
            splitContainerHorizontal.Panel1Collapsed = true;
            splitContainerVertical.Panel2Collapsed = true;

            System.Drawing.Image ImageOriginal = (System.Drawing.Image)(Properties.Resources.Arrow);
            if (splitContainerVertical.Panel2Collapsed)
                ImageOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
            else
                ImageOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);

            buttonCollapseVertical.BackgroundImage = ImageOriginal;
            #endregion

            MachineLearning = new cMachineLearning(GlobalInfo);

            MachineLearning.Classes.AddRange(ListClasses);

            WindowForModelHistory.Show();
            WindowForModelHistory.Visible = false;

            ToolTipForX.AutoPopDelay = ToolTipForY.AutoPopDelay = 5000;
            ToolTipForX.InitialDelay = ToolTipForY.InitialDelay = 500;
            ToolTipForX.ReshowDelay = ToolTipForY.ReshowDelay = 500;
            ToolTipForX.ShowAlways = ToolTipForY.ShowAlways = true;
            ToolTipForX.SetToolTip(comboBoxAxeX, comboBoxAxeX.Text);
            ToolTipForY.SetToolTip(comboBoxAxeY, comboBoxAxeY.Text);
            ToolTipForVolume.SetToolTip(comboBoxVolume, comboBoxVolume.Text);
        }

        public FormForSingleCellsDisplay()
        {
            InitializeComponent();
        }

        private void ReDraw()
        {
            cExtendedList ListX = new cExtendedList();
            cExtendedList ListY = new cExtendedList();

            if (this.comboBoxAxeY.SelectedIndex == -1) return;
            if (this.comboBoxVolume.SelectedIndex == -1) return;

            cExtendedList ListVolumes = new cExtendedList();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListX.Add(double.Parse(dt.Rows[j][this.comboBoxAxeX.SelectedIndex].ToString()));
                ListY.Add(double.Parse(dt.Rows[j][this.comboBoxAxeY.SelectedIndex].ToString()));
                ListVolumes.Add(double.Parse(dt.Rows[j][this.comboBoxVolume.SelectedIndex].ToString()));
            }

            this.chartForPoints.ChartAreas[0].AxisX.Title = this.comboBoxAxeX.SelectedItem.ToString();
            this.chartForPoints.ChartAreas[0].AxisY.Title = this.comboBoxAxeY.SelectedItem.ToString();
            this.chartForPoints.Series[0].Points.DataBindXY(ListX, ListY);

            this.chartForPoints.ChartAreas[0].AxisX.Minimum = ListX.Min();
            this.chartForPoints.ChartAreas[0].AxisX.Maximum = ListX.Max();

            this.chartForPoints.ChartAreas[0].AxisY.Minimum = ListY.Min();
            this.chartForPoints.ChartAreas[0].AxisY.Maximum = ListY.Max();

            //for (int j = 0; j < dt.Rows.Count; j++)
            //    this.chartForPoints.Series[0].Points[j].Tag = dataGridViewForTable.Rows[j];//dt.Rows[j];

            this.chartForPoints.ChartAreas[0].AxisX.LabelStyle.Format = "N2";
            this.chartForPoints.ChartAreas[0].AxisY.LabelStyle.Format = "N2";

            byte[][] LUT = GlobalInfo.LUT;

            int BorderSize = 1;
            if (!IsDisplayBorder) BorderSize = 0;

            if (MachineLearning.Classes.Count > 0)
            {
                for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                {
                    //int ConvertedValue = (int)(((Classes[j] - 0) * (LUT[0].Length - 1)) / (eval.getNumClusters() - 0));
                    //  this.chartForPoints.Series[0].Points[j].MarkerColor = GlobalInfo.ListCellularPhenotypes[(int)MachineLearning.Classes[j]].ColourForDisplay;
                    this.chartForPoints.Series[0].Points[j].MarkerColor = Color.FromArgb(128, GlobalInfo.ListCellularPhenotypes[(int)MachineLearning.Classes[j]].ColourForDisplay);
                    this.chartForPoints.Series[0].Points[j].MarkerBorderWidth = BorderSize;
                }
                if (checkBoxIsVolumeConstant.Checked)
                {
                    for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                        this.chartForPoints.Series[0].Points[j].MarkerSize = WindowPtSize.trackBarPointSize.Value;
                }

                if (SecondListClassesForValidation != null)
                {
                    // int NumBadAssociation = 0;

                    for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                    {
                        int ClassificationClass = (int)SecondListClassesForValidation[j];
                        this.chartForPoints.Series[0].Points[j].MarkerBorderColor = GlobalInfo.ListCellularPhenotypes[ClassificationClass].ColourForDisplay;
                        this.chartForPoints.Series[0].Points[j].MarkerBorderWidth = BorderSize * (this.chartForPoints.Series[0].Points[j].MarkerSize / 3);

                        //if (SecondListClassesForValidation[j] != Classes[j])
                        //    NumBadAssociation++;
                    }
                    //  this.richTextBoxForResults.AppendText(NumBadAssociation + " bad associations");
                }
            }
            else
            {
                for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                {
                    //int ConvertedValue = (int)(((Classes[j] - 0) * (LUT[0].Length - 1)) / (eval.getNumClusters() - 0));

                    int WellClass = 0; // int.Parse(dt.Rows[j][dt.Columns.Count - 1].ToString());

                    //this.chartForPoints.Series[0].Points[j].MarkerColor = ;
                    this.chartForPoints.Series[0].Points[j].MarkerColor = Color.FromArgb(128, GlobalInfo.ListWellClasses[WellClass].ColourForDisplay);
                    this.chartForPoints.Series[0].Points[j].MarkerSize = WindowPtSize.trackBarPointSize.Value;
                }

                if (checkBoxIsVolumeConstant.Checked)
                    for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                        this.chartForPoints.Series[0].Points[j].MarkerSize = WindowPtSize.trackBarPointSize.Value;
            }
            //this.chartForPoints.ChartAreas[0].CursorX.IsUserEnabled = false;
            //this.chartForPoints.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //this.chartForPoints.ChartAreas[0].CursorY.IsUserEnabled = false;
            //this.chartForPoints.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            if (!checkBoxIsVolumeConstant.Checked)
            {
                double MaxVolume = ListVolumes.Max();
                double MinVolume = ListVolumes.Min();

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int MarkerArea = (int)((50 * (ListVolumes[j] - MinVolume)) / (MaxVolume - MinVolume));
                    this.chartForPoints.Series[0].Points[j].MarkerSize = MarkerArea + 3;
                }
            }
        }

        private void comboBoxAxeX_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();

            if (comboBoxAxeX.Text == "")
                ToolTipForX.SetToolTip(comboBoxAxeX, comboBoxAxeX.Items[0].ToString());
            else
                ToolTipForX.SetToolTip(comboBoxAxeX, comboBoxAxeX.Text);

            if (splitContainerVertical.Panel2Collapsed) return;
            RedrawHistoHorizontal();
        }

        private void comboBoxAxeY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
            if (comboBoxAxeY.Text == "")
                ToolTipForY.SetToolTip(comboBoxAxeY, comboBoxAxeY.Items[0].ToString());
            else
                ToolTipForY.SetToolTip(comboBoxAxeY, comboBoxAxeY.Text);

            RedrawHistoVertical();
        }

        private void RedrawHistoVertical()
        {
            cExtendedList ListValue = new cExtendedList();
            for (int Idx = 0; Idx < this.dt.Rows.Count; Idx++)
                ListValue.Add(double.Parse(this.dt.Rows[Idx][comboBoxAxeY.SelectedIndex].ToString()));

            cPanelHisto PanelHisto = new cPanelHisto(ListValue, eGraphType.HISTOGRAM, eOrientation.VERTICAL);
            PanelHisto.WindowForPanelHisto.UserEnable = false;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.BackColor = Color.White;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Size = new System.Drawing.Size(splitContainerHorizontal.Panel1.Width, splitContainerVertical.Panel1.Height);
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Location = new Point(0, 0);

            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.BorderStyle = BorderStyle.None;

            PanelHisto.WindowForPanelHisto.CurrentChartArea.AxisX.Minimum = chartForPoints.ChartAreas[0].AxisY.Minimum;
            PanelHisto.WindowForPanelHisto.CurrentChartArea.AxisX.Maximum = chartForPoints.ChartAreas[0].AxisY.Maximum;

            splitContainerHorizontal.Panel1.Controls.Clear();
            splitContainerHorizontal.Panel1.Controls.Add(PanelHisto.WindowForPanelHisto.panelForGraphContainer);

        }

        private void RedrawHistoHorizontal()
        {
            cExtendedList ListValue = new cExtendedList();
            for (int Idx = 0; Idx < this.dt.Rows.Count; Idx++)
                ListValue.Add(double.Parse(this.dt.Rows[Idx][comboBoxAxeX.SelectedIndex].ToString()));

            cPanelHisto PanelHisto = new cPanelHisto(ListValue, eGraphType.HISTOGRAM, eOrientation.HORIZONTAL);
            PanelHisto.WindowForPanelHisto.UserEnable = false;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Size = new System.Drawing.Size(splitContainerVertical.Panel2.Width - 23, splitContainerVertical.Panel2.Height);
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.BackColor = Color.White;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Location = new Point(23, 0);

            PanelHisto.WindowForPanelHisto.panelForGraphContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelHisto.WindowForPanelHisto.panelForGraphContainer.BorderStyle = BorderStyle.None;

            PanelHisto.WindowForPanelHisto.CurrentChartArea.AxisX.Minimum = chartForPoints.ChartAreas[0].AxisX.Minimum;
            PanelHisto.WindowForPanelHisto.CurrentChartArea.AxisX.Maximum = chartForPoints.ChartAreas[0].AxisX.Maximum;

            splitContainerVertical.Panel2.Controls.Clear();
            splitContainerVertical.Panel2.Controls.Add(PanelHisto.WindowForPanelHisto.panelForGraphContainer);
        }

        double[] SecondListClassesForValidation = null;

        FormForPointSize WindowPtSize = new FormForPointSize();

        private void buttonStartCluster_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            // -------------------------- Clustering -------------------------------

            cParamAlgo ParaAlgo = MachineLearning.AskAndGetClusteringAlgo();
            if (ParaAlgo == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }



            MachineLearning.SelectedClusterer = MachineLearning.BuildClusterer(ParaAlgo, dt);

            //if (MachineLearning.SelectedClusterer == null)
            //{
            //    MessageBox.Show("Clustering failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Cursor = Cursors.Default;
            //    return;
            //}

            if (MachineLearning.SelectedClusterer.numberOfClusters() > GlobalInfo.ListCellularPhenotypes.Count)
            {
                MessageBox.Show("Number of identifed clusters (" + MachineLearning.SelectedClusterer.numberOfClusters() + ") not handled by the application !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            SecondListClassesForValidation = null;

            if (MachineLearning.SelectedClusterer != null)
            {
                double[] Assign = MachineLearning.EvaluteAndDisplayClusterer(this.richTextBoxForResults,
                                        this.panelForGraphicalResults,
                                        MachineLearning.CreateInstancesWithoutClass(dt)).getClusterAssignments();

                MachineLearning.Classes = new cExtendedList();
                MachineLearning.Classes.AddRange(Assign);

            }
            buttonTraining.Enabled = true;
            ReDraw();
            this.Cursor = Cursors.Default;

        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            // ----------------------- Training ------------------------------
            //if (MessageBox.Show("Do you want perform a j48 training process ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

            //InstancesList = GlobalInfo.CurrentScreen.CellBasedClassification.CreateInstancesWithoutClass(dt);

            weka.classifiers.Evaluation ModelEvaluation = null;

            Instances InstancesList = GlobalInfo.CurrentScreen.CellBasedClassification.CreateInstancesWithoutClass(dt);

            FormForClassificationInfo WinClassifInfo = MachineLearning.AskAndGetClassifAlgo();
            if (WinClassifInfo == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            MachineLearning.PerformTraining(WinClassifInfo,
                                            InstancesList,
                                            MachineLearning.NumberOfClusters,
                                            this.richTextBoxForResults,
                                            this.panelForGraphicalResults,
                                            out ModelEvaluation, true);

            if (MachineLearning.CurrentClassifier == null) return;

            #region Add Object to history (if the model has been cross validated)
            if (ModelEvaluation != null)
            {
                cClusteringObject NewObjectFOrHistory = new cClusteringObject(MachineLearning.CurrentClassifier, ModelEvaluation, (int)WinClassifInfo.numericUpDownFoldNumber.Value);

                List<string> ListNamesForItem = new List<string>();
                ListNamesForItem.Add(WinClassifInfo.GetSelectedAlgoAndParameters().Name);
                ListNamesForItem.Add(NewObjectFOrHistory.FoldNumber.ToString());
                ListNamesForItem.Add(NewObjectFOrHistory.Evaluation.meanAbsoluteError().ToString());
                ListViewItem NewItem = new ListViewItem(ListNamesForItem.ToArray());

                NewItem.Tag = NewObjectFOrHistory;
                WindowForModelHistory.listViewForClassifHistory.Items.Add(NewItem);
                NewItem.ToolTipText = MachineLearning.CurrentClassifier.ToString();
            }
            #endregion

            //Instances ListInstancesTOClassify = ListInstances;
            SecondListClassesForValidation = new double[InstancesList.numInstances()];
            //// ListInstances.setClassIndex(ListInstances.numAttributes() - 1);
            for (int i = 0; i < InstancesList.numInstances(); i++)
            {
                SecondListClassesForValidation[i] = MachineLearning.CurrentClassifier.classifyInstance(InstancesList.instance(i));
            }

            buttonClassify.Enabled = true;
            ReDraw();

            this.Cursor = Cursors.Default;
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            // FormForCellbyCellClassif WindowFormForCellbyCellClassif = new FormForCellbyCellClassif();

            //  if (WindowFormForCellbyCellClassif.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            MachineLearning.PerformClassification();
        }

        private void mINEAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GlobalInfo.WindowHCSAnalyzer.DisplayMINE(ExtractCellsValuesList(true));
        }

        private cExtendedTable ExtractCellsValuesList(bool SelectedDescriptorsOnly)
        {
            int NumDesc = dt.Columns.Count;

            if (SelectedDescriptorsOnly)
            {
                // int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
                cExtendedTable ListValueDesc = new cExtendedTable();

                //new List<double>[GlobalInfo.CurrentScreen.ListDescriptors.GetListNameActives().Count];

                for (int i = 0; i < GlobalInfo.CurrentScreen.ListDescriptors.GetListNameActives().Count; i++)
                    ListValueDesc[i] = new cExtendedList();

                // loop on all the plate
                for (int RowIdx = 0; RowIdx < dt.Rows.Count; RowIdx++)
                {
                    int Idx = 0;
                    for (int ColIdx = 0; ColIdx < dt.Columns.Count; ColIdx++)
                        if (GlobalInfo.CurrentScreen.ListDescriptors[ColIdx].IsActive())
                        {
                            ListValueDesc[Idx++].Add((double)dt.Rows[RowIdx][ColIdx]);
                        }
                }
                return ListValueDesc;
            }

            else
            {
                // int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
                cExtendedTable ListValueDesc = new cExtendedTable();

                for (int i = 0; i < NumDesc; i++) ListValueDesc.Add(new cExtendedList());
                for (int i = 0; i < NumDesc; i++) ListValueDesc[i].Name = dt.Columns[i].ColumnName;

                // loop on all the plate
                for (int RowIdx = 0; RowIdx < dt.Rows.Count; RowIdx++)
                {
                    for (int ColIdx = 0; ColIdx < dt.Columns.Count; ColIdx++)
                        ListValueDesc[ColIdx].Add((double)dt.Rows[RowIdx][ColIdx]);
                }
                return ListValueDesc;
            }
        }

        private void pointSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chartForPoints.Series[0].Points.Count == 0) return;
            int CurrentMarkerSize = this.chartForPoints.Series[0].Points[0].MarkerSize;
            WindowPtSize.labelForPointSize.Text = CurrentMarkerSize.ToString();

            WindowPtSize.trackBarPointSize.Value = CurrentMarkerSize;

            if (WindowPtSize.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in this.chartForPoints.Series[0].Points)
                    item.MarkerSize = WindowPtSize.trackBarPointSize.Value;
            }
            WindowPtSize.Visible = false;
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxForResults.Clear();
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cListOptions ListOptions = new cListOptions(GlobalInfo);

            FormForGlobalInfoOptions WindowForOptions = new FormForGlobalInfoOptions(ListOptions);
            WindowForOptions.SelectOption("Cellular Phenotypes");
            if (WindowForOptions.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ReDraw();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowForModelHistory.Visible = true;
        }

        private void checkBoxIsVolumeConstant_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxVolume.Enabled = !checkBoxIsVolumeConstant.Checked;
            ReDraw();
        }

        private void comboBoxVolume_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();

            if (comboBoxVolume.Text == "")
                ToolTipForVolume.SetToolTip(comboBoxVolume, comboBoxVolume.Items[0].ToString());
            else
                ToolTipForVolume.SetToolTip(comboBoxVolume, comboBoxVolume.Text);

        }

        private void buttonCollapseVertical_Click(object sender, EventArgs e)
        {
            splitContainerVertical.Panel2Collapsed = !splitContainerVertical.Panel2Collapsed;

            if ((!splitContainerVertical.Panel2Collapsed) && (splitContainerVertical.Panel2.Controls.Count == 0))
            {
                RedrawHistoHorizontal();
            }

            System.Drawing.Image ImageOriginal = (System.Drawing.Image)(Properties.Resources.Arrow);
            if (splitContainerVertical.Panel2Collapsed)
            {
                ImageOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else
            {
                ImageOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            buttonCollapseVertical.BackgroundImage = ImageOriginal;
        }

        private void buttonCollapseHorizontal_Click(object sender, EventArgs e)
        {
            splitContainerHorizontal.Panel1Collapsed = !splitContainerHorizontal.Panel1Collapsed;
            System.Drawing.Image ImageOriginal = (System.Drawing.Image)(Properties.Resources.Arrow);
            if (splitContainerHorizontal.Panel1Collapsed)
            {
                // ImageOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else
            {
                ImageOriginal.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            buttonCollapseHorizontal.BackgroundImage = ImageOriginal;
        }

        private void chartForPoints_Resize(object sender, EventArgs e)
        {
            if (splitContainerHorizontal.Panel1.Controls.Count == 0) return;
            splitContainerHorizontal.Panel1.Controls[0].Size = new System.Drawing.Size(splitContainerHorizontal.Panel1.Width, splitContainerVertical.Panel1.Height);

        }

        bool IsDisplayBorder = true;

        private void markerBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsDisplayBorder = markerBorderToolStripMenuItem.Checked;
            ReDraw();
        }

        private void correlationMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cFeedBackMessage MessageReturned;

            // cExtendedTable CurrentData =  ExtractCellsValuesList(false);

            cExtendedTable CurrentData = new cExtendedTable(this.dt);

            cDisplayCorrelationMatrix ComputeAndDisplay_SingleCorrelationMatrix = new cDisplayCorrelationMatrix();
            ComputeAndDisplay_SingleCorrelationMatrix.Set_Data(CurrentData);
            ComputeAndDisplay_SingleCorrelationMatrix.Run();
        }


    }




}
