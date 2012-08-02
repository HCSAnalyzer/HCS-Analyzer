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

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    public partial class FormForSingleCellsDisplay : Form
    {
        private DataTable dt;
        private cGlobalInfo GlobalInfo;

        public FormForSingleCellsDisplay(DataTable dt, cGlobalInfo GlobalInfo)
        {
            InitializeComponent();
            this.dt = dt;
            this.GlobalInfo = GlobalInfo;
            // this.dataGridViewForTable.DataSource = dt;
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

            for (int j = 0; j < dt.Rows.Count; j++)
            {

                ListX.Add(double.Parse(dt.Rows[j][this.comboBoxAxeX.SelectedIndex].ToString()));
                ListY.Add(double.Parse(dt.Rows[j][this.comboBoxAxeY.SelectedIndex].ToString()));
            }

            this.chartForPoints.ChartAreas[0].AxisX.Title = this.comboBoxAxeX.SelectedItem.ToString();
            this.chartForPoints.ChartAreas[0].AxisY.Title = this.comboBoxAxeY.SelectedItem.ToString();


            this.chartForPoints.Series[0].Points.DataBindXY(ListX, ListY);
            byte[][] LUT = GlobalInfo.LUT;
            if (Classes != null)
                for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                {
                    int ConvertedValue = (int)(((Classes[j] - 0) * (LUT[0].Length - 1)) / (NumClusters - 0));
                    this.chartForPoints.Series[0].Points[j].MarkerColor = Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);
                    this.chartForPoints.Series[0].Points[j].MarkerSize = WindowPtSize.trackBarPointSize.Value;
                }
            else
                for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                {
                    //int ConvertedValue = (int)(((Classes[j] - 0) * (LUT[0].Length - 1)) / (eval.getNumClusters() - 0));

                    int WellClass = int.Parse(dt.Rows[j][dt.Columns.Count-1].ToString());

                    this.chartForPoints.Series[0].Points[j].MarkerColor = GlobalInfo.GetColor(WellClass);
                    this.chartForPoints.Series[0].Points[j].MarkerSize = WindowPtSize.trackBarPointSize.Value;
                }
        }


        private void comboBoxAxeX_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void comboBoxAxeY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        cExtendedList Classes = null;
            int NumClusters=0;
        
        private void buttonStartCluster_Click(object sender, EventArgs e)
        {

            FormSingleCellClusteringInfo WindowClusteringInfo = new FormSingleCellClusteringInfo(GlobalInfo);
            if (WindowClusteringInfo.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;



           
            Instances ListInstances = GlobalInfo.CurrentScreen.CellBasedClassification.CreateInstancesWithoutClass(dt);
            if ((WindowClusteringInfo.radioButtonAutomated.Checked) && (WindowClusteringInfo.radioButtonEM.Checked))
            {
                ClusterEvaluation eval;
                Classes = new cExtendedList();
                weka.clusterers.EM EMCluster = new EM();
                if(WindowClusteringInfo.checkBoxEMAutomated.Checked)
                    EMCluster.setNumClusters(-1);
                else
                    EMCluster.setNumClusters((int)WindowClusteringInfo.numericUpDownClassNumber.Value);
                EMCluster.buildClusterer(ListInstances);
                EMCluster.getClusterModelsNumericAtts();

                eval = new ClusterEvaluation();
                eval.setClusterer(EMCluster);

                eval.evaluateClusterer(ListInstances);

                Classes.AddRange(eval.getClusterAssignments()); 
                NumClusters= eval.getNumClusters();
                ReDraw();
                FormForCellByCellClusteringResults WindowFormForCellByCellClusteringResults = new FormForCellByCellClusteringResults();
                WindowFormForCellByCellClusteringResults.richTextBoxResults.Clear();
                WindowFormForCellByCellClusteringResults.richTextBoxResults.AppendText(eval.clusterResultsToString());
                if (WindowFormForCellByCellClusteringResults.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

              

            }
            else if (WindowClusteringInfo.radioButtonDescriptorBased.Checked)
            {
                Classes = new cExtendedList();
                DataTable FinalDataTable = new DataTable();
                int IdxDescForClassSelect = WindowClusteringInfo.comboBoxDescriptorForClass.SelectedIndex;
                for (int IdxWell = 0; IdxWell < GlobalInfo.ListSelectedWell.Count; IdxWell++)
                {
                    cWell TmpWell = GlobalInfo.ListSelectedWell[IdxWell];

                 //   if (IdxWell == 0) 
                    if (TmpWell.ListDescriptors[IdxDescForClassSelect].GetAssociatedType().DataType == eDataType.HISTOGRAM)
                    {
                        Classes.AddRange(TmpWell.ListDescriptors[IdxDescForClassSelect].GetOriginalValues());
                    }
                    else
                    {
                        double ClasseValue = TmpWell.ListDescriptors[IdxDescForClassSelect].GetValue();

                        for (int IdxCell = 0; IdxCell < TmpWell.CellNumber; IdxCell++)
                            Classes.Add(ClasseValue);
                        //TmpWell.AddDescriptors
                    }
                }


                List<double> ListClassValues = new List<double>();
                foreach (var item in Classes.Distinct())
                {
                    ListClassValues.Add(item);
                }
                    
                    //(List<double>)Classes.Distinct();
                NumClusters = ListClassValues.Count();
                //Classes = new cExtendedList();
                for (int IdxClust = 0; IdxClust < Classes.Count; IdxClust++)
                {
                    for (int IdxCl = 0; IdxCl < ListClassValues.Count; IdxCl++)
                    {
                        if (ListClassValues[IdxCl] == Classes[IdxClust])
                        {
                            Classes[IdxClust] = IdxCl;
                            break;
                        }
                    }
                    //Classes[IdxClust] = ListClassValues.Find(Classes[IdxClust]);
                }
                //int NumClusters =
                ReDraw();
            
            }

        //    ReDraw();




            //if (MessageBox.Show("Do you want perform a j48 training process ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

            weka.core.FastVector attVals = new FastVector();
            for (int i = 0; i < NumClusters; i++)
                attVals.addElement("Class__" + (i).ToString());

            ListInstances.insertAttributeAt(new weka.core.Attribute("Class__", attVals), ListInstances.numAttributes());

            for (int i = 0; i < Classes.Count; i++)
            {
                ListInstances.get(i).setValue(ListInstances.numAttributes() - 1, Classes[i]);
            }
            ListInstances.setClassIndex(ListInstances.numAttributes() - 1);


           GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased = new weka.classifiers.trees.J48();
           GlobalInfo.CurrentScreen.CellBasedClassification.SetJ48Tree((weka.classifiers.trees.J48)GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased,Classes.Count);
           GlobalInfo.CurrentScreen.CellBasedClassification.J48Model.setMinNumObj((int)GlobalInfo.OptionsWindow.numericUpDownJ48MinNumObjects.Value);


            weka.core.Instances train = new weka.core.Instances(ListInstances, 0, ListInstances.numInstances());

            GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased.buildClassifier(train);
            GlobalInfo.ConsoleWriteLine(GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased.ToString());

           GlobalInfo.CurrentScreen.CellBasedClassification.evaluation = new weka.classifiers.Evaluation(ListInstances);
           GlobalInfo.CurrentScreen.CellBasedClassification.evaluation.crossValidateModel(GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased, ListInstances, 2, new java.util.Random(1));

            GlobalInfo.CurrentScreen.CellBasedClassification.DisplayTree(GlobalInfo).Show();

            FormForCellbyCellClassif WindowFormForCellbyCellClassif = new FormForCellbyCellClassif();
            if (WindowFormForCellbyCellClassif.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;



            int DescrCount = GlobalInfo.CurrentScreen.ListDescriptors.Count;

            // first we update the descriptor
            for (int i = 0; i < ListInstances.numClasses(); i++)
                GlobalInfo.CurrentScreen.ListDescriptors.AddNew(new cDescriptorsType("Ratio_Class " + i, true, 1, GlobalInfo));



            FormForProgress ProgressWindow = new FormForProgress();
            ProgressWindow.Show();

            int IdxProgress = 0;
            int MaxProgress = 0;

            foreach (cPlate CurrentPlateToProcess in GlobalInfo.CurrentScreen.ListPlatesAvailable)
                MaxProgress += CurrentPlateToProcess.ParentScreening.Columns * CurrentPlateToProcess.ParentScreening.Rows;
            ProgressWindow.progressBar.Maximum = MaxProgress;


            attVals = new FastVector();
            for (int i = 0; i < NumClusters; i++)
                attVals.addElement(i.ToString());


            //ParallelOptions options = new ParallelOptions();
            //options.MaxDegreeOfParallelism = -1; // -1 is for unlimited. 1 is for sequential.
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //////for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
            //int NumberOfPlates = CompleteScreening.ListPlatesAvailable.Count;
            //Parallel.For(0, NumberOfPlates, options, (PlateIdx) =>
            //{
            //    cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate((string)Parent.GlobalInfo.PlateListWindow.listBoxPlateNameToProcess.Items[PlateIdx]);

            //    for (int row = 0; row < Parent.Rows; row++)
            //        for (int col = 0; col < Parent.Columns; col++)
            //        {
            //            TempWell = CurrentPlateToProcess.GetWell(col, row, false);
            //            if (TempWell == null) continue;
            //            else
            //            {
            //                if (TempWell.GetClass() == this.ClassForClassif)
            //                    Pos.Add(TempWell.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue());
            //            }
            //        }
            //}
            //);




            foreach (cPlate CurrentPlateToProcess in GlobalInfo.CurrentScreen.ListPlatesAvailable)
            //Parallel.ForEach(GlobalInfo.CurrentScreen.ListPlatesActive, options, CurrentPlateToProcess =>
            {
                //Parallel.ForEach(CurrentPlateToProcess.ListActiveWells, options, TmpWell =>
                for(int j=0;j<CurrentPlateToProcess.ParentScreening.Rows;j++)
                    for (int k = 0; k < CurrentPlateToProcess.ParentScreening.Columns; k++)
                {
                    cWell TmpWell = CurrentPlateToProcess.GetWell(k, j, false);
                    if (TmpWell == null) continue;
                    ProgressWindow.progressBar.Value = IdxProgress++;


                    //DataTable FinalDataTable = new DataTable();
                    //TmpWell.AssociatedPlate.DBConnection = new cDBConnection(TmpWell.AssociatedPlate, TmpWell.SQLTableName);
                    //TmpWell.AssociatedPlate.DBConnection.AddWellToDataTable(TmpWell, FinalDataTable, false);
                    DataTable FinalDataTable = TmpWell.GetDescDataTable(true);
                    Instances ListInstancesTOClassify = GlobalInfo.CurrentScreen.CellBasedClassification.CreateInstancesWithoutClass(FinalDataTable);

                    ListInstancesTOClassify.insertAttributeAt(new weka.core.Attribute("Class", attVals), ListInstancesTOClassify.numAttributes());
                    ListInstancesTOClassify.setClassIndex(ListInstancesTOClassify.numAttributes() - 1);

                    cExtendedList ListClasses = new cExtendedList();

                    for (int i = 0; i < ListInstancesTOClassify.numInstances(); i++)
                    {
                        double classId = GlobalInfo.CurrentScreen.CellBasedClassification.ClassificationModel_CellBased.classifyInstance(ListInstancesTOClassify.instance(i));
                        ListClasses.Add(classId);
                    }
                    List<double[]> Histo = ListClasses.CreateHistogram(0, ListInstances.numClasses() - 1, ListInstances.numClasses() - 1);
                    List<cDescriptor> LDesc = new List<cDescriptor>();

                    for (int IdxHisto = 0; IdxHisto < Histo[1].Length; IdxHisto++)
                    {
                        double Value = (100.0 * Histo[1][IdxHisto]) / (double)ListInstancesTOClassify.numInstances();

                        cDescriptor NewDesc = new cDescriptor(Value, GlobalInfo.CurrentScreen.ListDescriptors[IdxHisto + DescrCount], GlobalInfo.CurrentScreen);
                        LDesc.Add(NewDesc);
                    }



                    TmpWell.AddDescriptors(LDesc);
                    //TmpWell.AssociatedPlate.DBConnection.DB_CloseConnection();

                }//);
            }
            ProgressWindow.Close();

            if (WindowFormForCellbyCellClassif.checkBoxKeepOriginalDesc.Checked == false)
            {

               // int DescNumToRemove = GlobalInfo.CurrentScreen.ListDescriptors.Count - 
                for (int IdxDesc = 0; IdxDesc < DescrCount; IdxDesc++)
                GlobalInfo.CurrentScreen.ListDescriptors.RemoveDesc(GlobalInfo.CurrentScreen.ListDescriptors[0], GlobalInfo.CurrentScreen);

            }



            GlobalInfo.CurrentScreen.ListDescriptors.UpDateDisplay();
            GlobalInfo.CurrentScreen.UpDatePlateListWithFullAvailablePlate();

            for (int idxP = 0; idxP < GlobalInfo.CurrentScreen.ListPlatesActive.Count; idxP++)
                GlobalInfo.CurrentScreen.ListPlatesActive[idxP].UpDataMinMax();

            if (WindowFormForCellbyCellClassif.checkBoxKeepOriginalDesc.Checked == false)
                GlobalInfo.CurrentScreen.GetCurrentDisplayPlate().DisplayDistribution(0, false);

            //WindowFormForCellbyCellClassif.Close();
            //WindowClusteringInfo.Close();

        }

        private void mINEAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInfo.WindowHCSAnalyzer.DisplayMINE(ExtractCellsValuesList(true));
        }

        private List<double>[] ExtractCellsValuesList(bool SelectedDescriptorsOnly)
        {
            int NumDesc = dt.Columns.Count;


            if (SelectedDescriptorsOnly)
            {
                // int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
                List<double>[] ListValueDesc = new List<double>[GlobalInfo.CurrentScreen.ListDescriptors.GetListNameActives().Count];

                for (int i = 0; i < ListValueDesc.Length; i++) ListValueDesc[i] = new List<double>();

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
                List<double>[] ListValueDesc = new List<double>[NumDesc];

                for (int i = 0; i < NumDesc; i++) ListValueDesc[i] = new List<double>();

                // loop on all the plate
                for (int RowIdx = 0; RowIdx < dt.Rows.Count; RowIdx++)
                {
                    for (int ColIdx = 0; ColIdx < dt.Columns.Count; ColIdx++)
                        ListValueDesc[ColIdx].Add((double)dt.Rows[RowIdx][ColIdx]);
                }
                return ListValueDesc;
            }
        }


        FormForPointSize WindowPtSize = new FormForPointSize();

        private void pointSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            int CurrentMarkerSize = this.chartForPoints.Series[0].Points[0].MarkerSize;
            WindowPtSize.trackBarPointSize.Value = CurrentMarkerSize;

            if (WindowPtSize.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in this.chartForPoints.Series[0].Points)
                    item.MarkerSize = WindowPtSize.trackBarPointSize.Value;
            }

            WindowPtSize.Visible = false;


        }










    }
}
