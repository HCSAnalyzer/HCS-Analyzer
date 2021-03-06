using System.Windows.Forms;
namespace HCSAnalyzer
{
    partial class HCSAnalyzer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Classification Tree");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Classification", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Correlation Matrix and Ranking");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Systematic Errors Table");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Z-Factors");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Quality Control", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Pathway Analysis");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("siRNA screening", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Weka .Arff File");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Misc", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCSAnalyzer));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDImRed = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNewDimension = new System.Windows.Forms.NumericUpDown();
            this.radioButtonDimRedSupervised = new System.Windows.Forms.RadioButton();
            this.radioButtonDimRedUnsupervised = new System.Windows.Forms.RadioButton();
            this.buttonReduceDim = new System.Windows.Forms.Button();
            this.groupBoxUnsupervised = new System.Windows.Forms.GroupBox();
            this.richTextBoxUnsupervisedDimRec = new System.Windows.Forms.RichTextBox();
            this.comboBoxReduceDimSingleClass = new System.Windows.Forms.ComboBox();
            this.groupBoxSupervised = new System.Windows.Forms.GroupBox();
            this.comboBoxDimReductionNeutralClass = new System.Windows.Forms.ComboBox();
            this.richTextBoxSupervisedDimRec = new System.Windows.Forms.RichTextBox();
            this.comboBoxReduceDimMultiClass = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageQualityQtrl = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRejectPlates = new System.Windows.Forms.Button();
            this.comboBoxRejectionPositiveCtrl = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxRejectionNegativeCtrl = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownRejectionThreshold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxInformationRejection = new System.Windows.Forms.RichTextBox();
            this.comboBoxRejection = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxInformationForPlateCorrection = new System.Windows.Forms.RichTextBox();
            this.comboBoxMethodForCorrection = new System.Windows.Forms.ComboBox();
            this.buttonCorrectionPlateByPlate = new System.Windows.Forms.Button();
            this.dataGridViewForQualityControl = new System.Windows.Forms.DataGridView();
            this.buttonQualityControl = new System.Windows.Forms.Button();
            this.tabPageNormalization = new System.Windows.Forms.TabPage();
            this.buttonNormalize = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.comboBoxNormalizationPositiveCtrl = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxNormalizationNegativeCtrl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxInfoForNormalization = new System.Windows.Forms.RichTextBox();
            this.comboBoxMethodForNormalization = new System.Windows.Forms.ComboBox();
            this.tabPageClassification = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonStartManualSelection = new System.Windows.Forms.Button();
            this.numericUpDownManualThreshold = new System.Windows.Forms.NumericUpDown();
            this.radioButtonManualLowerThan = new System.Windows.Forms.RadioButton();
            this.comboBoxManualClassToBeAnalyzed = new System.Windows.Forms.ComboBox();
            this.radioButtonManualHigherThan = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.richTextBoxForManualSelection = new System.Windows.Forms.RichTextBox();
            this.comboBoxdescriptorToBeAnalyzed = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.radioButtonClusterFullScreen = new System.Windows.Forms.RadioButton();
            this.radioButtonClusterPlateByPlate = new System.Windows.Forms.RadioButton();
            this.buttonCluster = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxAutomatedClusterNumber = new System.Windows.Forms.CheckBox();
            this.richTextBoxInfoClustering = new System.Windows.Forms.RichTextBox();
            this.comboBoxClusteringMethod = new System.Windows.Forms.ComboBox();
            this.numericUpDownClusterNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button_Trees = new System.Windows.Forms.Button();
            this.radioButtonClassifGlobal = new System.Windows.Forms.RadioButton();
            this.comboBoxNeutralClassForClassif = new System.Windows.Forms.ComboBox();
            this.buttonStartClassification = new System.Windows.Forms.Button();
            this.radioButtonClassifPlateByPlate = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxInfoClassif = new System.Windows.Forms.RichTextBox();
            this.comboBoxCLassificationMethod = new System.Windows.Forms.ComboBox();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.splitContainerExport = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxExportScreeningInformation = new System.Windows.Forms.CheckBox();
            this.richTextBoxForScreeningInformation = new System.Windows.Forms.RichTextBox();
            this.checkBoxExportFullScreen = new System.Windows.Forms.CheckBox();
            this.treeViewSelectionForExport = new System.Windows.Forms.TreeView();
            this.checkBoxExportPlateFormat = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.tabPageWellsSelection = new System.Windows.Forms.TabPage();
            this.buttonToSelectWellsFromClass = new System.Windows.Forms.Button();
            this.comboBoxClassForWellSelection = new System.Windows.Forms.ComboBox();
            this.listBoxSelectedWells = new System.Windows.Forms.ListBox();
            this.contextMenuStripForListSelectedWells = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDisplayWellsSelectionData = new System.Windows.Forms.Button();
            this.imageListForTab = new System.Windows.Forms.ImageList(this.components);
            this.panelForTools = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.labelNumClasses = new System.Windows.Forms.Label();
            this.buttonGlobalOnlySelected = new System.Windows.Forms.Button();
            this.checkBoxDisplayClasses = new System.Windows.Forms.CheckBox();
            this.buttonSizeIncrease = new System.Windows.Forms.Button();
            this.buttonSizeDecrease = new System.Windows.Forms.Button();
            this.checkBoxApplyToAllPlates = new System.Windows.Forms.CheckBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.panelForLUT = new System.Windows.Forms.Panel();
            this.buttonGlobalSelection = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.panelForPlate = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStripFile = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellByCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDBFromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateScreenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.univariateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multivariateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveScreentoCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentPlateTomtrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toARFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendDescriptorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAverageValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAverageValuesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.applySelectionToScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.platesManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.plateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptorViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.classViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.averageViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.ThreeDVisualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripcomboBoxPlateList = new System.Windows.Forms.ToolStripComboBox();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scatterPointsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xYScatterPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYZScatterPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.visualizationToolStripMenuItemPCA = new System.Windows.Forms.ToolStripMenuItem();
            this.scatterPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYScatterPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYZScatterPointsToolStripMenuItemFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stackedHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cellBasedClassificationTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.hierarchicalTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PCAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lDAToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionsFullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGraphToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pCAToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zscoreSinglePlateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalProbabilityPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.systematicErrorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mINEAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zscoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalProbabilityPlotToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coeffOfVariationEvolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptorEvolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPhenotypesOfInterestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.generateHitsDistributionMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGeneAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.findGeneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pahtwaysAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPathwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dRCAnalysisToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.doseResponseDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.convertDRCToWellToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDRCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayRespondingDRCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.currentPlate3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.generateDRCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionsModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHCSAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBoxActiveDescriptors = new System.Windows.Forms.CheckedListBox();
            this.comboBoxDescriptorToDisplay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contextMenuStripForLUT = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.buttonPreviousPlate = new System.Windows.Forms.Button();
            this.buttonNextPlate = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageDImRed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewDimension)).BeginInit();
            this.groupBoxUnsupervised.SuspendLayout();
            this.groupBoxSupervised.SuspendLayout();
            this.tabPageQualityQtrl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRejectionThreshold)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForQualityControl)).BeginInit();
            this.tabPageNormalization.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tabPageClassification.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualThreshold)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClusterNumber)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExport)).BeginInit();
            this.splitContainerExport.Panel1.SuspendLayout();
            this.splitContainerExport.Panel2.SuspendLayout();
            this.splitContainerExport.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPageWellsSelection.SuspendLayout();
            this.contextMenuStripForListSelectedWells.SuspendLayout();
            this.panelForTools.SuspendLayout();
            this.panelForPlate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStripFile.SuspendLayout();
            this.contextMenuStripForLUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.AllowDrop = true;
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageDImRed);
            this.tabControlMain.Controls.Add(this.tabPageQualityQtrl);
            this.tabControlMain.Controls.Add(this.tabPageNormalization);
            this.tabControlMain.Controls.Add(this.tabPageClassification);
            this.tabControlMain.Controls.Add(this.tabPageExport);
            this.tabControlMain.Controls.Add(this.tabPageWellsSelection);
            this.tabControlMain.Location = new System.Drawing.Point(0, 429);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1216, 303);
            this.tabControlMain.TabIndex = 5;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            this.tabControlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControlMain_DragDrop);
            this.tabControlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControlMain_DragEnter);
            // 
            // tabPageDImRed
            // 
            this.tabPageDImRed.Controls.Add(this.label3);
            this.tabPageDImRed.Controls.Add(this.numericUpDownNewDimension);
            this.tabPageDImRed.Controls.Add(this.radioButtonDimRedSupervised);
            this.tabPageDImRed.Controls.Add(this.radioButtonDimRedUnsupervised);
            this.tabPageDImRed.Controls.Add(this.buttonReduceDim);
            this.tabPageDImRed.Controls.Add(this.groupBoxUnsupervised);
            this.tabPageDImRed.Controls.Add(this.groupBoxSupervised);
            this.tabPageDImRed.ImageIndex = 5;
            this.tabPageDImRed.Location = new System.Drawing.Point(4, 22);
            this.tabPageDImRed.Name = "tabPageDImRed";
            this.tabPageDImRed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDImRed.Size = new System.Drawing.Size(1208, 277);
            this.tabPageDImRed.TabIndex = 8;
            this.tabPageDImRed.Text = "Dimensionality Reduction";
            this.tabPageDImRed.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Dimension";
            // 
            // numericUpDownNewDimension
            // 
            this.numericUpDownNewDimension.Location = new System.Drawing.Point(45, 57);
            this.numericUpDownNewDimension.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNewDimension.Name = "numericUpDownNewDimension";
            this.numericUpDownNewDimension.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownNewDimension.TabIndex = 1;
            this.numericUpDownNewDimension.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // radioButtonDimRedSupervised
            // 
            this.radioButtonDimRedSupervised.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonDimRedSupervised.AutoSize = true;
            this.radioButtonDimRedSupervised.Location = new System.Drawing.Point(570, 6);
            this.radioButtonDimRedSupervised.Name = "radioButtonDimRedSupervised";
            this.radioButtonDimRedSupervised.Size = new System.Drawing.Size(78, 17);
            this.radioButtonDimRedSupervised.TabIndex = 3;
            this.radioButtonDimRedSupervised.TabStop = true;
            this.radioButtonDimRedSupervised.Text = "Supervised";
            this.radioButtonDimRedSupervised.UseVisualStyleBackColor = true;
            this.radioButtonDimRedSupervised.CheckedChanged += new System.EventHandler(this.radioButtonDimRedSupervised_CheckedChanged);
            // 
            // radioButtonDimRedUnsupervised
            // 
            this.radioButtonDimRedUnsupervised.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonDimRedUnsupervised.AutoSize = true;
            this.radioButtonDimRedUnsupervised.Checked = true;
            this.radioButtonDimRedUnsupervised.Location = new System.Drawing.Point(256, 6);
            this.radioButtonDimRedUnsupervised.Name = "radioButtonDimRedUnsupervised";
            this.radioButtonDimRedUnsupervised.Size = new System.Drawing.Size(90, 17);
            this.radioButtonDimRedUnsupervised.TabIndex = 2;
            this.radioButtonDimRedUnsupervised.TabStop = true;
            this.radioButtonDimRedUnsupervised.Text = "Unsupervised";
            this.radioButtonDimRedUnsupervised.UseVisualStyleBackColor = true;
            this.radioButtonDimRedUnsupervised.CheckedChanged += new System.EventHandler(this.radioButtonDimRedUnsupervised_CheckedChanged);
            // 
            // buttonReduceDim
            // 
            this.buttonReduceDim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReduceDim.Enabled = false;
            this.buttonReduceDim.Location = new System.Drawing.Point(1052, 234);
            this.buttonReduceDim.Name = "buttonReduceDim";
            this.buttonReduceDim.Size = new System.Drawing.Size(150, 37);
            this.buttonReduceDim.TabIndex = 9;
            this.buttonReduceDim.Text = "Reduce Dimensionality";
            this.buttonReduceDim.UseVisualStyleBackColor = true;
            this.buttonReduceDim.Click += new System.EventHandler(this.buttonReduceDim_Click);
            // 
            // groupBoxUnsupervised
            // 
            this.groupBoxUnsupervised.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxUnsupervised.Controls.Add(this.richTextBoxUnsupervisedDimRec);
            this.groupBoxUnsupervised.Controls.Add(this.comboBoxReduceDimSingleClass);
            this.groupBoxUnsupervised.Location = new System.Drawing.Point(174, 29);
            this.groupBoxUnsupervised.Name = "groupBoxUnsupervised";
            this.groupBoxUnsupervised.Size = new System.Drawing.Size(263, 245);
            this.groupBoxUnsupervised.TabIndex = 7;
            this.groupBoxUnsupervised.TabStop = false;
            // 
            // richTextBoxUnsupervisedDimRec
            // 
            this.richTextBoxUnsupervisedDimRec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxUnsupervisedDimRec.Location = new System.Drawing.Point(6, 89);
            this.richTextBoxUnsupervisedDimRec.Name = "richTextBoxUnsupervisedDimRec";
            this.richTextBoxUnsupervisedDimRec.ReadOnly = true;
            this.richTextBoxUnsupervisedDimRec.Size = new System.Drawing.Size(251, 149);
            this.richTextBoxUnsupervisedDimRec.TabIndex = 5;
            this.richTextBoxUnsupervisedDimRec.Text = "";
            this.richTextBoxUnsupervisedDimRec.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxUnsupervisedDimRec_LinkClicked);
            // 
            // comboBoxReduceDimSingleClass
            // 
            this.comboBoxReduceDimSingleClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxReduceDimSingleClass.FormattingEnabled = true;
            this.comboBoxReduceDimSingleClass.Items.AddRange(new object[] {
            "PCA",
            "Greedy Stepwise"});
            this.comboBoxReduceDimSingleClass.Location = new System.Drawing.Point(45, 25);
            this.comboBoxReduceDimSingleClass.Name = "comboBoxReduceDimSingleClass";
            this.comboBoxReduceDimSingleClass.Size = new System.Drawing.Size(169, 21);
            this.comboBoxReduceDimSingleClass.TabIndex = 4;
            this.comboBoxReduceDimSingleClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxReduceDimSingleClass_SelectedIndexChanged);
            // 
            // groupBoxSupervised
            // 
            this.groupBoxSupervised.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSupervised.Controls.Add(this.comboBoxDimReductionNeutralClass);
            this.groupBoxSupervised.Controls.Add(this.richTextBoxSupervisedDimRec);
            this.groupBoxSupervised.Controls.Add(this.comboBoxReduceDimMultiClass);
            this.groupBoxSupervised.Controls.Add(this.label6);
            this.groupBoxSupervised.Enabled = false;
            this.groupBoxSupervised.Location = new System.Drawing.Point(483, 29);
            this.groupBoxSupervised.Name = "groupBoxSupervised";
            this.groupBoxSupervised.Size = new System.Drawing.Size(263, 245);
            this.groupBoxSupervised.TabIndex = 8;
            this.groupBoxSupervised.TabStop = false;
            // 
            // comboBoxDimReductionNeutralClass
            // 
            this.comboBoxDimReductionNeutralClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxDimReductionNeutralClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDimReductionNeutralClass.FormattingEnabled = true;
            this.comboBoxDimReductionNeutralClass.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxDimReductionNeutralClass.Location = new System.Drawing.Point(111, 57);
            this.comboBoxDimReductionNeutralClass.Name = "comboBoxDimReductionNeutralClass";
            this.comboBoxDimReductionNeutralClass.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDimReductionNeutralClass.TabIndex = 7;
            this.comboBoxDimReductionNeutralClass.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDimReductionNeutralClass_DrawItem);
            // 
            // richTextBoxSupervisedDimRec
            // 
            this.richTextBoxSupervisedDimRec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxSupervisedDimRec.Location = new System.Drawing.Point(6, 89);
            this.richTextBoxSupervisedDimRec.Name = "richTextBoxSupervisedDimRec";
            this.richTextBoxSupervisedDimRec.ReadOnly = true;
            this.richTextBoxSupervisedDimRec.Size = new System.Drawing.Size(251, 149);
            this.richTextBoxSupervisedDimRec.TabIndex = 8;
            this.richTextBoxSupervisedDimRec.Text = "";
            this.richTextBoxSupervisedDimRec.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxSupervisedDimRec_LinkClicked);
            // 
            // comboBoxReduceDimMultiClass
            // 
            this.comboBoxReduceDimMultiClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxReduceDimMultiClass.FormattingEnabled = true;
            this.comboBoxReduceDimMultiClass.Items.AddRange(new object[] {
            "InfoGain",
            "OneR",
            "Greedy"});
            this.comboBoxReduceDimMultiClass.Location = new System.Drawing.Point(40, 25);
            this.comboBoxReduceDimMultiClass.Name = "comboBoxReduceDimMultiClass";
            this.comboBoxReduceDimMultiClass.Size = new System.Drawing.Size(182, 21);
            this.comboBoxReduceDimMultiClass.TabIndex = 6;
            this.comboBoxReduceDimMultiClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxReduceDimMultiClass_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Neutral Class";
            // 
            // tabPageQualityQtrl
            // 
            this.tabPageQualityQtrl.Controls.Add(this.groupBox1);
            this.tabPageQualityQtrl.Controls.Add(this.groupBox2);
            this.tabPageQualityQtrl.Controls.Add(this.dataGridViewForQualityControl);
            this.tabPageQualityQtrl.Controls.Add(this.buttonQualityControl);
            this.tabPageQualityQtrl.ImageIndex = 1;
            this.tabPageQualityQtrl.Location = new System.Drawing.Point(4, 22);
            this.tabPageQualityQtrl.Name = "tabPageQualityQtrl";
            this.tabPageQualityQtrl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQualityQtrl.Size = new System.Drawing.Size(1208, 277);
            this.tabPageQualityQtrl.TabIndex = 7;
            this.tabPageQualityQtrl.Text = "Systematic Error Identification & Correction";
            this.tabPageQualityQtrl.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonRejectPlates);
            this.groupBox1.Controls.Add(this.comboBoxRejectionPositiveCtrl);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBoxRejectionNegativeCtrl);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numericUpDownRejectionThreshold);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.richTextBoxInformationRejection);
            this.groupBox1.Controls.Add(this.comboBoxRejection);
            this.groupBox1.Location = new System.Drawing.Point(694, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 268);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rejection";
            // 
            // buttonRejectPlates
            // 
            this.buttonRejectPlates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRejectPlates.Enabled = false;
            this.buttonRejectPlates.Location = new System.Drawing.Point(65, 225);
            this.buttonRejectPlates.Name = "buttonRejectPlates";
            this.buttonRejectPlates.Size = new System.Drawing.Size(150, 34);
            this.buttonRejectPlates.TabIndex = 14;
            this.buttonRejectPlates.Text = "Reject Plates";
            this.buttonRejectPlates.UseVisualStyleBackColor = true;
            this.buttonRejectPlates.Click += new System.EventHandler(this.buttonRejectPlates_Click);
            // 
            // comboBoxRejectionPositiveCtrl
            // 
            this.comboBoxRejectionPositiveCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxRejectionPositiveCtrl.FormattingEnabled = true;
            this.comboBoxRejectionPositiveCtrl.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxRejectionPositiveCtrl.Location = new System.Drawing.Point(161, 101);
            this.comboBoxRejectionPositiveCtrl.Name = "comboBoxRejectionPositiveCtrl";
            this.comboBoxRejectionPositiveCtrl.Size = new System.Drawing.Size(108, 21);
            this.comboBoxRejectionPositiveCtrl.TabIndex = 31;
            this.comboBoxRejectionPositiveCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxRejectionPositiveCtrl_DrawItem);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Positive Control";
            // 
            // comboBoxRejectionNegativeCtrl
            // 
            this.comboBoxRejectionNegativeCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxRejectionNegativeCtrl.FormattingEnabled = true;
            this.comboBoxRejectionNegativeCtrl.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxRejectionNegativeCtrl.Location = new System.Drawing.Point(27, 101);
            this.comboBoxRejectionNegativeCtrl.Name = "comboBoxRejectionNegativeCtrl";
            this.comboBoxRejectionNegativeCtrl.Size = new System.Drawing.Size(110, 21);
            this.comboBoxRejectionNegativeCtrl.TabIndex = 30;
            this.comboBoxRejectionNegativeCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxRejectionNegativeCtrl_DrawItem);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Negative Control";
            // 
            // numericUpDownRejectionThreshold
            // 
            this.numericUpDownRejectionThreshold.DecimalPlaces = 2;
            this.numericUpDownRejectionThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRejectionThreshold.Location = new System.Drawing.Point(118, 50);
            this.numericUpDownRejectionThreshold.Name = "numericUpDownRejectionThreshold";
            this.numericUpDownRejectionThreshold.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRejectionThreshold.TabIndex = 6;
            this.numericUpDownRejectionThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Threshold";
            // 
            // richTextBoxInformationRejection
            // 
            this.richTextBoxInformationRejection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInformationRejection.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxInformationRejection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxInformationRejection.Location = new System.Drawing.Point(6, 128);
            this.richTextBoxInformationRejection.Name = "richTextBoxInformationRejection";
            this.richTextBoxInformationRejection.ReadOnly = true;
            this.richTextBoxInformationRejection.Size = new System.Drawing.Size(279, 89);
            this.richTextBoxInformationRejection.TabIndex = 4;
            this.richTextBoxInformationRejection.Text = "";
            this.richTextBoxInformationRejection.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxInformationRejection_LinkClicked);
            // 
            // comboBoxRejection
            // 
            this.comboBoxRejection.FormattingEnabled = true;
            this.comboBoxRejection.Items.AddRange(new object[] {
            "Z-Factor"});
            this.comboBoxRejection.Location = new System.Drawing.Point(54, 16);
            this.comboBoxRejection.Name = "comboBoxRejection";
            this.comboBoxRejection.Size = new System.Drawing.Size(182, 21);
            this.comboBoxRejection.TabIndex = 3;
            this.comboBoxRejection.SelectedIndexChanged += new System.EventHandler(this.comboBoxRejection_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBoxInformationForPlateCorrection);
            this.groupBox2.Controls.Add(this.comboBoxMethodForCorrection);
            this.groupBox2.Controls.Add(this.buttonCorrectionPlateByPlate);
            this.groupBox2.Location = new System.Drawing.Point(426, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 268);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Correction";
            // 
            // richTextBoxInformationForPlateCorrection
            // 
            this.richTextBoxInformationForPlateCorrection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInformationForPlateCorrection.Location = new System.Drawing.Point(5, 64);
            this.richTextBoxInformationForPlateCorrection.Name = "richTextBoxInformationForPlateCorrection";
            this.richTextBoxInformationForPlateCorrection.ReadOnly = true;
            this.richTextBoxInformationForPlateCorrection.Size = new System.Drawing.Size(251, 153);
            this.richTextBoxInformationForPlateCorrection.TabIndex = 4;
            this.richTextBoxInformationForPlateCorrection.Text = "";
            this.richTextBoxInformationForPlateCorrection.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxInformationForPlateCorrection_LinkClicked);
            // 
            // comboBoxMethodForCorrection
            // 
            this.comboBoxMethodForCorrection.FormattingEnabled = true;
            this.comboBoxMethodForCorrection.Items.AddRange(new object[] {
            "B-Score",
            "Diffusion Model"});
            this.comboBoxMethodForCorrection.Location = new System.Drawing.Point(38, 32);
            this.comboBoxMethodForCorrection.Name = "comboBoxMethodForCorrection";
            this.comboBoxMethodForCorrection.Size = new System.Drawing.Size(182, 21);
            this.comboBoxMethodForCorrection.TabIndex = 3;
            this.comboBoxMethodForCorrection.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethodForCorrection_SelectedIndexChanged);
            // 
            // buttonCorrectionPlateByPlate
            // 
            this.buttonCorrectionPlateByPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCorrectionPlateByPlate.Enabled = false;
            this.buttonCorrectionPlateByPlate.Location = new System.Drawing.Point(57, 226);
            this.buttonCorrectionPlateByPlate.Name = "buttonCorrectionPlateByPlate";
            this.buttonCorrectionPlateByPlate.Size = new System.Drawing.Size(150, 34);
            this.buttonCorrectionPlateByPlate.TabIndex = 5;
            this.buttonCorrectionPlateByPlate.Text = "Plate-by-plate Correction";
            this.buttonCorrectionPlateByPlate.UseVisualStyleBackColor = true;
            this.buttonCorrectionPlateByPlate.Click += new System.EventHandler(this.buttonCorrectionPlateByPlate_Click);
            // 
            // dataGridViewForQualityControl
            // 
            this.dataGridViewForQualityControl.AllowUserToAddRows = false;
            this.dataGridViewForQualityControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewForQualityControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForQualityControl.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewForQualityControl.Name = "dataGridViewForQualityControl";
            this.dataGridViewForQualityControl.Size = new System.Drawing.Size(414, 228);
            this.dataGridViewForQualityControl.TabIndex = 1;
            this.dataGridViewForQualityControl.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForQualityControl_CellContentDoubleClick);
            // 
            // buttonQualityControl
            // 
            this.buttonQualityControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQualityControl.Enabled = false;
            this.buttonQualityControl.Location = new System.Drawing.Point(5, 240);
            this.buttonQualityControl.Name = "buttonQualityControl";
            this.buttonQualityControl.Size = new System.Drawing.Size(414, 34);
            this.buttonQualityControl.TabIndex = 2;
            this.buttonQualityControl.Text = "Systematic error identification";
            this.buttonQualityControl.UseVisualStyleBackColor = true;
            this.buttonQualityControl.Click += new System.EventHandler(this.buttonQualityControl_Click);
            // 
            // tabPageNormalization
            // 
            this.tabPageNormalization.Controls.Add(this.buttonNormalize);
            this.tabPageNormalization.Controls.Add(this.groupBox15);
            this.tabPageNormalization.ImageIndex = 2;
            this.tabPageNormalization.Location = new System.Drawing.Point(4, 22);
            this.tabPageNormalization.Name = "tabPageNormalization";
            this.tabPageNormalization.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormalization.Size = new System.Drawing.Size(1208, 277);
            this.tabPageNormalization.TabIndex = 3;
            this.tabPageNormalization.Text = "Normalization";
            this.tabPageNormalization.UseVisualStyleBackColor = true;
            // 
            // buttonNormalize
            // 
            this.buttonNormalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNormalize.Enabled = false;
            this.buttonNormalize.Location = new System.Drawing.Point(1055, 237);
            this.buttonNormalize.Name = "buttonNormalize";
            this.buttonNormalize.Size = new System.Drawing.Size(150, 34);
            this.buttonNormalize.TabIndex = 5;
            this.buttonNormalize.Text = "Normalize";
            this.buttonNormalize.UseVisualStyleBackColor = true;
            this.buttonNormalize.Click += new System.EventHandler(this.buttonNormalize_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox15.Controls.Add(this.comboBoxNormalizationPositiveCtrl);
            this.groupBox15.Controls.Add(this.label7);
            this.groupBox15.Controls.Add(this.comboBoxNormalizationNegativeCtrl);
            this.groupBox15.Controls.Add(this.label4);
            this.groupBox15.Controls.Add(this.richTextBoxInfoForNormalization);
            this.groupBox15.Controls.Add(this.comboBoxMethodForNormalization);
            this.groupBox15.Location = new System.Drawing.Point(6, 6);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(476, 271);
            this.groupBox15.TabIndex = 8;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Normalization";
            // 
            // comboBoxNormalizationPositiveCtrl
            // 
            this.comboBoxNormalizationPositiveCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxNormalizationPositiveCtrl.FormattingEnabled = true;
            this.comboBoxNormalizationPositiveCtrl.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxNormalizationPositiveCtrl.Location = new System.Drawing.Point(335, 69);
            this.comboBoxNormalizationPositiveCtrl.Name = "comboBoxNormalizationPositiveCtrl";
            this.comboBoxNormalizationPositiveCtrl.Size = new System.Drawing.Size(120, 21);
            this.comboBoxNormalizationPositiveCtrl.TabIndex = 3;
            this.comboBoxNormalizationPositiveCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxNormalizationPositiveCtrl_DrawItem);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Positive Class";
            // 
            // comboBoxNormalizationNegativeCtrl
            // 
            this.comboBoxNormalizationNegativeCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxNormalizationNegativeCtrl.FormattingEnabled = true;
            this.comboBoxNormalizationNegativeCtrl.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxNormalizationNegativeCtrl.Location = new System.Drawing.Point(100, 69);
            this.comboBoxNormalizationNegativeCtrl.Name = "comboBoxNormalizationNegativeCtrl";
            this.comboBoxNormalizationNegativeCtrl.Size = new System.Drawing.Size(120, 21);
            this.comboBoxNormalizationNegativeCtrl.TabIndex = 2;
            this.comboBoxNormalizationNegativeCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxNormalizationNegativeCtrl_DrawItem);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Negative Class";
            // 
            // richTextBoxInfoForNormalization
            // 
            this.richTextBoxInfoForNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInfoForNormalization.Location = new System.Drawing.Point(6, 96);
            this.richTextBoxInfoForNormalization.Name = "richTextBoxInfoForNormalization";
            this.richTextBoxInfoForNormalization.ReadOnly = true;
            this.richTextBoxInfoForNormalization.Size = new System.Drawing.Size(464, 169);
            this.richTextBoxInfoForNormalization.TabIndex = 4;
            this.richTextBoxInfoForNormalization.Text = "";
            this.richTextBoxInfoForNormalization.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxInfoForNormalization_LinkClicked);
            // 
            // comboBoxMethodForNormalization
            // 
            this.comboBoxMethodForNormalization.FormattingEnabled = true;
            this.comboBoxMethodForNormalization.Items.AddRange(new object[] {
            "Percent of control ",
            "Normalized percent inhibition",
            "Z-score"});
            this.comboBoxMethodForNormalization.Location = new System.Drawing.Point(147, 21);
            this.comboBoxMethodForNormalization.Name = "comboBoxMethodForNormalization";
            this.comboBoxMethodForNormalization.Size = new System.Drawing.Size(182, 21);
            this.comboBoxMethodForNormalization.TabIndex = 1;
            this.comboBoxMethodForNormalization.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethodForNormalization_SelectedIndexChanged);
            // 
            // tabPageClassification
            // 
            this.tabPageClassification.Controls.Add(this.groupBox6);
            this.tabPageClassification.Controls.Add(this.groupBox12);
            this.tabPageClassification.Controls.Add(this.groupBox11);
            this.tabPageClassification.ImageIndex = 3;
            this.tabPageClassification.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassification.Name = "tabPageClassification";
            this.tabPageClassification.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClassification.Size = new System.Drawing.Size(1208, 277);
            this.tabPageClassification.TabIndex = 4;
            this.tabPageClassification.Text = "Classification & Clustering";
            this.tabPageClassification.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.buttonStartManualSelection);
            this.groupBox6.Controls.Add(this.numericUpDownManualThreshold);
            this.groupBox6.Controls.Add(this.radioButtonManualLowerThan);
            this.groupBox6.Controls.Add(this.comboBoxManualClassToBeAnalyzed);
            this.groupBox6.Controls.Add(this.radioButtonManualHigherThan);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.richTextBoxForManualSelection);
            this.groupBox6.Controls.Add(this.comboBoxdescriptorToBeAnalyzed);
            this.groupBox6.Location = new System.Drawing.Point(278, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(263, 268);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Manual Selection";
            // 
            // buttonStartManualSelection
            // 
            this.buttonStartManualSelection.Location = new System.Drawing.Point(69, 228);
            this.buttonStartManualSelection.Name = "buttonStartManualSelection";
            this.buttonStartManualSelection.Size = new System.Drawing.Size(125, 34);
            this.buttonStartManualSelection.TabIndex = 28;
            this.buttonStartManualSelection.Text = "Select";
            this.buttonStartManualSelection.UseVisualStyleBackColor = true;
            this.buttonStartManualSelection.Click += new System.EventHandler(this.buttonStartManualSelection_Click);
            // 
            // numericUpDownManualThreshold
            // 
            this.numericUpDownManualThreshold.DecimalPlaces = 3;
            this.numericUpDownManualThreshold.Location = new System.Drawing.Point(77, 53);
            this.numericUpDownManualThreshold.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownManualThreshold.Minimum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            -2147483648});
            this.numericUpDownManualThreshold.Name = "numericUpDownManualThreshold";
            this.numericUpDownManualThreshold.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownManualThreshold.TabIndex = 27;
            // 
            // radioButtonManualLowerThan
            // 
            this.radioButtonManualLowerThan.AutoSize = true;
            this.radioButtonManualLowerThan.Location = new System.Drawing.Point(16, 53);
            this.radioButtonManualLowerThan.Name = "radioButtonManualLowerThan";
            this.radioButtonManualLowerThan.Size = new System.Drawing.Size(54, 17);
            this.radioButtonManualLowerThan.TabIndex = 6;
            this.radioButtonManualLowerThan.TabStop = true;
            this.radioButtonManualLowerThan.Text = "Lower";
            this.radioButtonManualLowerThan.UseVisualStyleBackColor = true;
            // 
            // comboBoxManualClassToBeAnalyzed
            // 
            this.comboBoxManualClassToBeAnalyzed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxManualClassToBeAnalyzed.FormattingEnabled = true;
            this.comboBoxManualClassToBeAnalyzed.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxManualClassToBeAnalyzed.Location = new System.Drawing.Point(113, 80);
            this.comboBoxManualClassToBeAnalyzed.Name = "comboBoxManualClassToBeAnalyzed";
            this.comboBoxManualClassToBeAnalyzed.Size = new System.Drawing.Size(133, 21);
            this.comboBoxManualClassToBeAnalyzed.TabIndex = 26;
            this.comboBoxManualClassToBeAnalyzed.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxManualClassToBeAnalyzed_DrawItem);
            // 
            // radioButtonManualHigherThan
            // 
            this.radioButtonManualHigherThan.AutoSize = true;
            this.radioButtonManualHigherThan.Checked = true;
            this.radioButtonManualHigherThan.Location = new System.Drawing.Point(190, 53);
            this.radioButtonManualHigherThan.Name = "radioButtonManualHigherThan";
            this.radioButtonManualHigherThan.Size = new System.Drawing.Size(56, 17);
            this.radioButtonManualHigherThan.TabIndex = 2;
            this.radioButtonManualHigherThan.TabStop = true;
            this.radioButtonManualHigherThan.Text = "Higher";
            this.radioButtonManualHigherThan.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Desc.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "To Be Classified";
            // 
            // richTextBoxForManualSelection
            // 
            this.richTextBoxForManualSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxForManualSelection.Location = new System.Drawing.Point(6, 110);
            this.richTextBoxForManualSelection.Name = "richTextBoxForManualSelection";
            this.richTextBoxForManualSelection.ReadOnly = true;
            this.richTextBoxForManualSelection.Size = new System.Drawing.Size(251, 112);
            this.richTextBoxForManualSelection.TabIndex = 0;
            this.richTextBoxForManualSelection.Text = "";
            // 
            // comboBoxdescriptorToBeAnalyzed
            // 
            this.comboBoxdescriptorToBeAnalyzed.FormattingEnabled = true;
            this.comboBoxdescriptorToBeAnalyzed.Location = new System.Drawing.Point(64, 20);
            this.comboBoxdescriptorToBeAnalyzed.Name = "comboBoxdescriptorToBeAnalyzed";
            this.comboBoxdescriptorToBeAnalyzed.Size = new System.Drawing.Size(182, 21);
            this.comboBoxdescriptorToBeAnalyzed.TabIndex = 19;
            this.comboBoxdescriptorToBeAnalyzed.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxdescriptorToBeAnalyzed_DrawItem);
            this.comboBoxdescriptorToBeAnalyzed.DropDown += new System.EventHandler(this.comboBoxdescriptorToBeAnalyzed_DropDown);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox12.Controls.Add(this.radioButtonClusterFullScreen);
            this.groupBox12.Controls.Add(this.radioButtonClusterPlateByPlate);
            this.groupBox12.Controls.Add(this.buttonCluster);
            this.groupBox12.Controls.Add(this.label10);
            this.groupBox12.Controls.Add(this.checkBoxAutomatedClusterNumber);
            this.groupBox12.Controls.Add(this.richTextBoxInfoClustering);
            this.groupBox12.Controls.Add(this.comboBoxClusteringMethod);
            this.groupBox12.Controls.Add(this.numericUpDownClusterNumber);
            this.groupBox12.Location = new System.Drawing.Point(9, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(263, 268);
            this.groupBox12.TabIndex = 5;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Clustering";
            // 
            // radioButtonClusterFullScreen
            // 
            this.radioButtonClusterFullScreen.AutoSize = true;
            this.radioButtonClusterFullScreen.Checked = true;
            this.radioButtonClusterFullScreen.Location = new System.Drawing.Point(153, 53);
            this.radioButtonClusterFullScreen.Name = "radioButtonClusterFullScreen";
            this.radioButtonClusterFullScreen.Size = new System.Drawing.Size(78, 17);
            this.radioButtonClusterFullScreen.TabIndex = 28;
            this.radioButtonClusterFullScreen.TabStop = true;
            this.radioButtonClusterFullScreen.Text = "Full Screen";
            this.radioButtonClusterFullScreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonClusterPlateByPlate
            // 
            this.radioButtonClusterPlateByPlate.AutoSize = true;
            this.radioButtonClusterPlateByPlate.Location = new System.Drawing.Point(36, 53);
            this.radioButtonClusterPlateByPlate.Name = "radioButtonClusterPlateByPlate";
            this.radioButtonClusterPlateByPlate.Size = new System.Drawing.Size(91, 17);
            this.radioButtonClusterPlateByPlate.TabIndex = 27;
            this.radioButtonClusterPlateByPlate.Text = "Plate By Plate";
            this.radioButtonClusterPlateByPlate.UseVisualStyleBackColor = true;
            this.radioButtonClusterPlateByPlate.CheckedChanged += new System.EventHandler(this.radioButtonClusterPlateByPlate_CheckedChanged);
            // 
            // buttonCluster
            // 
            this.buttonCluster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCluster.Enabled = false;
            this.buttonCluster.Location = new System.Drawing.Point(58, 228);
            this.buttonCluster.Name = "buttonCluster";
            this.buttonCluster.Size = new System.Drawing.Size(146, 34);
            this.buttonCluster.TabIndex = 1;
            this.buttonCluster.Text = "Cluster";
            this.buttonCluster.UseVisualStyleBackColor = true;
            this.buttonCluster.Click += new System.EventHandler(this.buttonCluster_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Cluster Number";
            // 
            // checkBoxAutomatedClusterNumber
            // 
            this.checkBoxAutomatedClusterNumber.AutoSize = true;
            this.checkBoxAutomatedClusterNumber.Location = new System.Drawing.Point(176, 86);
            this.checkBoxAutomatedClusterNumber.Name = "checkBoxAutomatedClusterNumber";
            this.checkBoxAutomatedClusterNumber.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutomatedClusterNumber.TabIndex = 22;
            this.checkBoxAutomatedClusterNumber.Text = "Automated";
            this.checkBoxAutomatedClusterNumber.UseVisualStyleBackColor = true;
            this.checkBoxAutomatedClusterNumber.CheckedChanged += new System.EventHandler(this.checkBoxAutomatedClusterNumber_CheckedChanged);
            // 
            // richTextBoxInfoClustering
            // 
            this.richTextBoxInfoClustering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInfoClustering.Location = new System.Drawing.Point(6, 110);
            this.richTextBoxInfoClustering.Name = "richTextBoxInfoClustering";
            this.richTextBoxInfoClustering.ReadOnly = true;
            this.richTextBoxInfoClustering.Size = new System.Drawing.Size(251, 112);
            this.richTextBoxInfoClustering.TabIndex = 0;
            this.richTextBoxInfoClustering.Text = "";
            this.richTextBoxInfoClustering.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxInfoClustering_LinkClicked);
            // 
            // comboBoxClusteringMethod
            // 
            this.comboBoxClusteringMethod.FormattingEnabled = true;
            this.comboBoxClusteringMethod.Items.AddRange(new object[] {
            "K-Means",
            "EM",
            "Hierarchical"});
            this.comboBoxClusteringMethod.Location = new System.Drawing.Point(40, 20);
            this.comboBoxClusteringMethod.Name = "comboBoxClusteringMethod";
            this.comboBoxClusteringMethod.Size = new System.Drawing.Size(182, 21);
            this.comboBoxClusteringMethod.TabIndex = 19;
            this.comboBoxClusteringMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxClusteringMethod_SelectedIndexChanged);
            // 
            // numericUpDownClusterNumber
            // 
            this.numericUpDownClusterNumber.Location = new System.Drawing.Point(91, 84);
            this.numericUpDownClusterNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownClusterNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownClusterNumber.Name = "numericUpDownClusterNumber";
            this.numericUpDownClusterNumber.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownClusterNumber.TabIndex = 21;
            this.numericUpDownClusterNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox11.Controls.Add(this.button_Trees);
            this.groupBox11.Controls.Add(this.radioButtonClassifGlobal);
            this.groupBox11.Controls.Add(this.comboBoxNeutralClassForClassif);
            this.groupBox11.Controls.Add(this.buttonStartClassification);
            this.groupBox11.Controls.Add(this.radioButtonClassifPlateByPlate);
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.richTextBoxInfoClassif);
            this.groupBox11.Controls.Add(this.comboBoxCLassificationMethod);
            this.groupBox11.Location = new System.Drawing.Point(547, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(263, 268);
            this.groupBox11.TabIndex = 5;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Classification";
            // 
            // button_Trees
            // 
            this.button_Trees.Location = new System.Drawing.Point(140, 228);
            this.button_Trees.Name = "button_Trees";
            this.button_Trees.Size = new System.Drawing.Size(85, 34);
            this.button_Trees.TabIndex = 27;
            this.button_Trees.Text = "Vizualize Tree";
            this.button_Trees.UseVisualStyleBackColor = true;
            this.button_Trees.Click += new System.EventHandler(this.button_Trees_Click);
            // 
            // radioButtonClassifGlobal
            // 
            this.radioButtonClassifGlobal.AutoSize = true;
            this.radioButtonClassifGlobal.Location = new System.Drawing.Point(144, 53);
            this.radioButtonClassifGlobal.Name = "radioButtonClassifGlobal";
            this.radioButtonClassifGlobal.Size = new System.Drawing.Size(78, 17);
            this.radioButtonClassifGlobal.TabIndex = 6;
            this.radioButtonClassifGlobal.TabStop = true;
            this.radioButtonClassifGlobal.Text = "Full Screen";
            this.radioButtonClassifGlobal.UseVisualStyleBackColor = true;
            // 
            // comboBoxNeutralClassForClassif
            // 
            this.comboBoxNeutralClassForClassif.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxNeutralClassForClassif.FormattingEnabled = true;
            this.comboBoxNeutralClassForClassif.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxNeutralClassForClassif.Location = new System.Drawing.Point(113, 80);
            this.comboBoxNeutralClassForClassif.Name = "comboBoxNeutralClassForClassif";
            this.comboBoxNeutralClassForClassif.Size = new System.Drawing.Size(133, 21);
            this.comboBoxNeutralClassForClassif.TabIndex = 26;
            this.comboBoxNeutralClassForClassif.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxNeutralClassForClassif_DrawItem);
            // 
            // buttonStartClassification
            // 
            this.buttonStartClassification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartClassification.Enabled = false;
            this.buttonStartClassification.Location = new System.Drawing.Point(38, 228);
            this.buttonStartClassification.Name = "buttonStartClassification";
            this.buttonStartClassification.Size = new System.Drawing.Size(88, 34);
            this.buttonStartClassification.TabIndex = 1;
            this.buttonStartClassification.Text = "Classify";
            this.buttonStartClassification.UseVisualStyleBackColor = true;
            this.buttonStartClassification.Click += new System.EventHandler(this.buttonStartClassification_Click_1);
            // 
            // radioButtonClassifPlateByPlate
            // 
            this.radioButtonClassifPlateByPlate.AutoSize = true;
            this.radioButtonClassifPlateByPlate.Checked = true;
            this.radioButtonClassifPlateByPlate.Location = new System.Drawing.Point(27, 53);
            this.radioButtonClassifPlateByPlate.Name = "radioButtonClassifPlateByPlate";
            this.radioButtonClassifPlateByPlate.Size = new System.Drawing.Size(91, 17);
            this.radioButtonClassifPlateByPlate.TabIndex = 2;
            this.radioButtonClassifPlateByPlate.TabStop = true;
            this.radioButtonClassifPlateByPlate.Text = "Plate By Plate";
            this.radioButtonClassifPlateByPlate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "To Be Classified";
            // 
            // richTextBoxInfoClassif
            // 
            this.richTextBoxInfoClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInfoClassif.Location = new System.Drawing.Point(6, 110);
            this.richTextBoxInfoClassif.Name = "richTextBoxInfoClassif";
            this.richTextBoxInfoClassif.ReadOnly = true;
            this.richTextBoxInfoClassif.Size = new System.Drawing.Size(251, 112);
            this.richTextBoxInfoClassif.TabIndex = 0;
            this.richTextBoxInfoClassif.Text = "";
            this.richTextBoxInfoClassif.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxInfoClassif_LinkClicked);
            // 
            // comboBoxCLassificationMethod
            // 
            this.comboBoxCLassificationMethod.FormattingEnabled = true;
            this.comboBoxCLassificationMethod.Items.AddRange(new object[] {
            "C4.5",
            "Support Vector Machine",
            "Neural Network",
            "K Nearest Neighbor(s)",
            "Random Forest"});
            this.comboBoxCLassificationMethod.Location = new System.Drawing.Point(40, 20);
            this.comboBoxCLassificationMethod.Name = "comboBoxCLassificationMethod";
            this.comboBoxCLassificationMethod.Size = new System.Drawing.Size(182, 21);
            this.comboBoxCLassificationMethod.TabIndex = 19;
            this.comboBoxCLassificationMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxCLassificationMethod_SelectedIndexChanged);
            // 
            // tabPageExport
            // 
            this.tabPageExport.Controls.Add(this.splitContainerExport);
            this.tabPageExport.Controls.Add(this.buttonExport);
            this.tabPageExport.ImageIndex = 4;
            this.tabPageExport.Location = new System.Drawing.Point(4, 22);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExport.Size = new System.Drawing.Size(1208, 277);
            this.tabPageExport.TabIndex = 5;
            this.tabPageExport.Text = "Report Export";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // splitContainerExport
            // 
            this.splitContainerExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerExport.Location = new System.Drawing.Point(6, 13);
            this.splitContainerExport.Name = "splitContainerExport";
            // 
            // splitContainerExport.Panel1
            // 
            this.splitContainerExport.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainerExport.Panel2
            // 
            this.splitContainerExport.Panel2.Controls.Add(this.checkBoxExportFullScreen);
            this.splitContainerExport.Panel2.Controls.Add(this.treeViewSelectionForExport);
            this.splitContainerExport.Panel2.Controls.Add(this.checkBoxExportPlateFormat);
            this.splitContainerExport.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerExport.Panel2.Controls.Add(this.groupBox4);
            this.splitContainerExport.Size = new System.Drawing.Size(1033, 261);
            this.splitContainerExport.SplitterDistance = 402;
            this.splitContainerExport.TabIndex = 17;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.checkBoxExportScreeningInformation);
            this.groupBox5.Controls.Add(this.richTextBoxForScreeningInformation);
            this.groupBox5.Location = new System.Drawing.Point(3, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(396, 250);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "                                             ";
            // 
            // checkBoxExportScreeningInformation
            // 
            this.checkBoxExportScreeningInformation.AutoSize = true;
            this.checkBoxExportScreeningInformation.Checked = true;
            this.checkBoxExportScreeningInformation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportScreeningInformation.Location = new System.Drawing.Point(13, -1);
            this.checkBoxExportScreeningInformation.Name = "checkBoxExportScreeningInformation";
            this.checkBoxExportScreeningInformation.Size = new System.Drawing.Size(129, 17);
            this.checkBoxExportScreeningInformation.TabIndex = 11;
            this.checkBoxExportScreeningInformation.Text = "Screening Information";
            this.checkBoxExportScreeningInformation.UseVisualStyleBackColor = true;
            // 
            // richTextBoxForScreeningInformation
            // 
            this.richTextBoxForScreeningInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxForScreeningInformation.Location = new System.Drawing.Point(6, 23);
            this.richTextBoxForScreeningInformation.Name = "richTextBoxForScreeningInformation";
            this.richTextBoxForScreeningInformation.Size = new System.Drawing.Size(384, 221);
            this.richTextBoxForScreeningInformation.TabIndex = 0;
            this.richTextBoxForScreeningInformation.Text = "";
            // 
            // checkBoxExportFullScreen
            // 
            this.checkBoxExportFullScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxExportFullScreen.AutoSize = true;
            this.checkBoxExportFullScreen.Checked = true;
            this.checkBoxExportFullScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportFullScreen.Location = new System.Drawing.Point(163, 8);
            this.checkBoxExportFullScreen.Name = "checkBoxExportFullScreen";
            this.checkBoxExportFullScreen.Size = new System.Drawing.Size(79, 17);
            this.checkBoxExportFullScreen.TabIndex = 9;
            this.checkBoxExportFullScreen.Text = "Full Screen";
            this.checkBoxExportFullScreen.UseVisualStyleBackColor = true;
            // 
            // treeViewSelectionForExport
            // 
            this.treeViewSelectionForExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewSelectionForExport.CheckBoxes = true;
            this.treeViewSelectionForExport.FullRowSelect = true;
            this.treeViewSelectionForExport.Location = new System.Drawing.Point(67, 111);
            this.treeViewSelectionForExport.Name = "treeViewSelectionForExport";
            treeNode1.Name = "NodeClassifTree";
            treeNode1.Text = "Classification Tree";
            treeNode2.Name = "NodeClassification";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "Classification";
            treeNode3.Checked = true;
            treeNode3.Name = "NodeCorrelationMatRank";
            treeNode3.Text = "Correlation Matrix and Ranking";
            treeNode4.Checked = true;
            treeNode4.Name = "NodeSystematicError";
            treeNode4.Text = "Systematic Errors Table";
            treeNode5.Checked = true;
            treeNode5.Name = "NodeZfactor";
            treeNode5.Text = "Z-Factors";
            treeNode6.Checked = true;
            treeNode6.Name = "NodeQualityControl";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Quality Control";
            treeNode7.Name = "NodePathwayAnalysis";
            treeNode7.Text = "Pathway Analysis";
            treeNode8.Name = "NodesiRNA";
            treeNode8.Text = "siRNA screening";
            treeNode9.Name = "NodeWekaArff";
            treeNode9.Text = "Weka .Arff File";
            treeNode10.Name = "NodeMisc";
            treeNode10.Text = "Misc";
            this.treeViewSelectionForExport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode8,
            treeNode10});
            this.treeViewSelectionForExport.Size = new System.Drawing.Size(450, 141);
            this.treeViewSelectionForExport.TabIndex = 16;
            // 
            // checkBoxExportPlateFormat
            // 
            this.checkBoxExportPlateFormat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxExportPlateFormat.AutoSize = true;
            this.checkBoxExportPlateFormat.Checked = true;
            this.checkBoxExportPlateFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportPlateFormat.Location = new System.Drawing.Point(376, 7);
            this.checkBoxExportPlateFormat.Name = "checkBoxExportPlateFormat";
            this.checkBoxExportPlateFormat.Size = new System.Drawing.Size(85, 17);
            this.checkBoxExportPlateFormat.TabIndex = 10;
            this.checkBoxExportPlateFormat.Text = "Plate Format";
            this.checkBoxExportPlateFormat.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(99, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::HCSAnalyzer.Properties.Resources.Capture;
            this.pictureBox1.Location = new System.Drawing.Point(13, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Location = new System.Drawing.Point(316, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 87);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::HCSAnalyzer.Properties.Resources.Capture1;
            this.pictureBox2.Location = new System.Drawing.Point(13, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(1078, 232);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(124, 39);
            this.buttonExport.TabIndex = 0;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // tabPageWellsSelection
            // 
            this.tabPageWellsSelection.Controls.Add(this.buttonToSelectWellsFromClass);
            this.tabPageWellsSelection.Controls.Add(this.comboBoxClassForWellSelection);
            this.tabPageWellsSelection.Controls.Add(this.listBoxSelectedWells);
            this.tabPageWellsSelection.Controls.Add(this.buttonDisplayWellsSelectionData);
            this.tabPageWellsSelection.Location = new System.Drawing.Point(4, 22);
            this.tabPageWellsSelection.Name = "tabPageWellsSelection";
            this.tabPageWellsSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWellsSelection.Size = new System.Drawing.Size(1208, 277);
            this.tabPageWellsSelection.TabIndex = 9;
            this.tabPageWellsSelection.Text = "Cell-by-cell Analysis";
            this.tabPageWellsSelection.UseVisualStyleBackColor = true;
            // 
            // buttonToSelectWellsFromClass
            // 
            this.buttonToSelectWellsFromClass.Location = new System.Drawing.Point(320, 52);
            this.buttonToSelectWellsFromClass.Name = "buttonToSelectWellsFromClass";
            this.buttonToSelectWellsFromClass.Size = new System.Drawing.Size(133, 33);
            this.buttonToSelectWellsFromClass.TabIndex = 29;
            this.buttonToSelectWellsFromClass.Text = "Add wells From class";
            this.buttonToSelectWellsFromClass.UseVisualStyleBackColor = true;
            this.buttonToSelectWellsFromClass.Click += new System.EventHandler(this.buttonToSelectWellsFromClass_Click);
            // 
            // comboBoxClassForWellSelection
            // 
            this.comboBoxClassForWellSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxClassForWellSelection.FormattingEnabled = true;
            this.comboBoxClassForWellSelection.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxClassForWellSelection.Location = new System.Drawing.Point(320, 101);
            this.comboBoxClassForWellSelection.Name = "comboBoxClassForWellSelection";
            this.comboBoxClassForWellSelection.Size = new System.Drawing.Size(133, 21);
            this.comboBoxClassForWellSelection.TabIndex = 28;
            this.comboBoxClassForWellSelection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxClassForWellSelection_DrawItem);
            // 
            // listBoxSelectedWells
            // 
            this.listBoxSelectedWells.ContextMenuStrip = this.contextMenuStripForListSelectedWells;
            this.listBoxSelectedWells.FormattingEnabled = true;
            this.listBoxSelectedWells.HorizontalScrollbar = true;
            this.listBoxSelectedWells.Location = new System.Drawing.Point(9, 6);
            this.listBoxSelectedWells.Name = "listBoxSelectedWells";
            this.listBoxSelectedWells.Size = new System.Drawing.Size(291, 264);
            this.listBoxSelectedWells.TabIndex = 1;
            // 
            // contextMenuStripForListSelectedWells
            // 
            this.contextMenuStripForListSelectedWells.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStripForListSelectedWells.Name = "contextMenuStripForListSelectedWells";
            this.contextMenuStripForListSelectedWells.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click_1);
            // 
            // buttonDisplayWellsSelectionData
            // 
            this.buttonDisplayWellsSelectionData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisplayWellsSelectionData.Location = new System.Drawing.Point(1063, 230);
            this.buttonDisplayWellsSelectionData.Name = "buttonDisplayWellsSelectionData";
            this.buttonDisplayWellsSelectionData.Size = new System.Drawing.Size(139, 39);
            this.buttonDisplayWellsSelectionData.TabIndex = 0;
            this.buttonDisplayWellsSelectionData.Text = "Cell-by-Cell Analysis";
            this.buttonDisplayWellsSelectionData.UseVisualStyleBackColor = true;
            this.buttonDisplayWellsSelectionData.Click += new System.EventHandler(this.buttonDisplayWellsSelectionData_Click);
            // 
            // imageListForTab
            // 
            this.imageListForTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForTab.ImageStream")));
            this.imageListForTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForTab.Images.SetKeyName(0, "Picture1.png");
            this.imageListForTab.Images.SetKeyName(1, "Picture2.png");
            this.imageListForTab.Images.SetKeyName(2, "Picture3.png");
            this.imageListForTab.Images.SetKeyName(3, "Picture4.png");
            this.imageListForTab.Images.SetKeyName(4, "Picture5.png");
            this.imageListForTab.Images.SetKeyName(5, "Picture6.png");
            // 
            // panelForTools
            // 
            this.panelForTools.AutoScroll = true;
            this.panelForTools.BackColor = System.Drawing.Color.Transparent;
            this.panelForTools.Controls.Add(this.label1);
            this.panelForTools.Controls.Add(this.comboBoxClass);
            this.panelForTools.Controls.Add(this.labelNumClasses);
            this.panelForTools.Controls.Add(this.buttonGlobalOnlySelected);
            this.panelForTools.Controls.Add(this.checkBoxDisplayClasses);
            this.panelForTools.Controls.Add(this.buttonSizeIncrease);
            this.panelForTools.Controls.Add(this.buttonSizeDecrease);
            this.panelForTools.Controls.Add(this.checkBoxApplyToAllPlates);
            this.panelForTools.Controls.Add(this.labelMax);
            this.panelForTools.Controls.Add(this.panelForLUT);
            this.panelForTools.Controls.Add(this.buttonGlobalSelection);
            this.panelForTools.Controls.Add(this.labelMin);
            this.panelForTools.Location = new System.Drawing.Point(0, 31);
            this.panelForTools.Name = "panelForTools";
            this.panelForTools.Size = new System.Drawing.Size(166, 392);
            this.panelForTools.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Class selection";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Items.AddRange(new object[] {
            "Unselected (-1)",
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxClass.Location = new System.Drawing.Point(12, 359);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(101, 21);
            this.comboBoxClass.TabIndex = 31;
            this.comboBoxClass.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxClass_DrawItem_1);
            this.comboBoxClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxClass_SelectedIndexChanged);
            // 
            // labelNumClasses
            // 
            this.labelNumClasses.AutoSize = true;
            this.labelNumClasses.Location = new System.Drawing.Point(119, 362);
            this.labelNumClasses.Name = "labelNumClasses";
            this.labelNumClasses.Size = new System.Drawing.Size(28, 13);
            this.labelNumClasses.TabIndex = 33;
            this.labelNumClasses.Text = "###";
            // 
            // buttonGlobalOnlySelected
            // 
            this.buttonGlobalOnlySelected.Location = new System.Drawing.Point(52, 39);
            this.buttonGlobalOnlySelected.Name = "buttonGlobalOnlySelected";
            this.buttonGlobalOnlySelected.Size = new System.Drawing.Size(61, 54);
            this.buttonGlobalOnlySelected.TabIndex = 3;
            this.buttonGlobalOnlySelected.Text = "Global only selected";
            this.buttonGlobalOnlySelected.UseVisualStyleBackColor = true;
            this.buttonGlobalOnlySelected.Click += new System.EventHandler(this.buttonGlobalOnlySelected_Click);
            // 
            // checkBoxDisplayClasses
            // 
            this.checkBoxDisplayClasses.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxDisplayClasses.AutoSize = true;
            this.checkBoxDisplayClasses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxDisplayClasses.Location = new System.Drawing.Point(20, 188);
            this.checkBoxDisplayClasses.Name = "checkBoxDisplayClasses";
            this.checkBoxDisplayClasses.Size = new System.Drawing.Size(78, 23);
            this.checkBoxDisplayClasses.TabIndex = 5;
            this.checkBoxDisplayClasses.Text = "Display class";
            this.checkBoxDisplayClasses.UseVisualStyleBackColor = true;
            this.checkBoxDisplayClasses.CheckedChanged += new System.EventHandler(this.checkBoxDisplayClasses_CheckedChanged);
            // 
            // buttonSizeIncrease
            // 
            this.buttonSizeIncrease.Image = global::HCSAnalyzer.Properties.Resources.zoom_in_41;
            this.buttonSizeIncrease.Location = new System.Drawing.Point(61, 263);
            this.buttonSizeIncrease.Name = "buttonSizeIncrease";
            this.buttonSizeIncrease.Size = new System.Drawing.Size(48, 40);
            this.buttonSizeIncrease.TabIndex = 7;
            this.buttonSizeIncrease.UseVisualStyleBackColor = true;
            this.buttonSizeIncrease.Click += new System.EventHandler(this.buttonSizeIncrease_Click);
            // 
            // buttonSizeDecrease
            // 
            this.buttonSizeDecrease.Image = global::HCSAnalyzer.Properties.Resources.zoom_out_41;
            this.buttonSizeDecrease.Location = new System.Drawing.Point(10, 263);
            this.buttonSizeDecrease.Name = "buttonSizeDecrease";
            this.buttonSizeDecrease.Size = new System.Drawing.Size(45, 40);
            this.buttonSizeDecrease.TabIndex = 6;
            this.buttonSizeDecrease.UseVisualStyleBackColor = true;
            this.buttonSizeDecrease.Click += new System.EventHandler(this.buttonSizeDecrease_Click);
            // 
            // checkBoxApplyToAllPlates
            // 
            this.checkBoxApplyToAllPlates.AutoSize = true;
            this.checkBoxApplyToAllPlates.Checked = true;
            this.checkBoxApplyToAllPlates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxApplyToAllPlates.Location = new System.Drawing.Point(6, 125);
            this.checkBoxApplyToAllPlates.Name = "checkBoxApplyToAllPlates";
            this.checkBoxApplyToAllPlates.Size = new System.Drawing.Size(108, 17);
            this.checkBoxApplyToAllPlates.TabIndex = 4;
            this.checkBoxApplyToAllPlates.Text = "Apply to all plates";
            this.checkBoxApplyToAllPlates.UseVisualStyleBackColor = true;
            this.checkBoxApplyToAllPlates.CheckedChanged += new System.EventHandler(this.checkBoxApplyToAllPlates_CheckedChanged);
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax.Location = new System.Drawing.Point(99, 8);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(20, 12);
            this.labelMax.TabIndex = 10;
            this.labelMax.Text = "###";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelForLUT
            // 
            this.panelForLUT.BackgroundImage = global::HCSAnalyzer.Properties.Resources.LUT;
            this.panelForLUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForLUT.Location = new System.Drawing.Point(120, 28);
            this.panelForLUT.Name = "panelForLUT";
            this.panelForLUT.Size = new System.Drawing.Size(27, 294);
            this.panelForLUT.TabIndex = 30;
            this.panelForLUT.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForLUT_Paint);
            // 
            // buttonGlobalSelection
            // 
            this.buttonGlobalSelection.Location = new System.Drawing.Point(5, 39);
            this.buttonGlobalSelection.Name = "buttonGlobalSelection";
            this.buttonGlobalSelection.Size = new System.Drawing.Size(45, 54);
            this.buttonGlobalSelection.TabIndex = 2;
            this.buttonGlobalSelection.Text = "Global";
            this.buttonGlobalSelection.UseVisualStyleBackColor = true;
            this.buttonGlobalSelection.Click += new System.EventHandler(this.buttonGlobalSelection_Click);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMin.Location = new System.Drawing.Point(99, 334);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(20, 12);
            this.labelMin.TabIndex = 11;
            this.labelMin.Text = "###";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelForPlate
            // 
            this.panelForPlate.AllowDrop = true;
            this.panelForPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForPlate.AutoScroll = true;
            this.panelForPlate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(63)))));
            this.panelForPlate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelForPlate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelForPlate.Controls.Add(this.pictureBox3);
            this.panelForPlate.Location = new System.Drawing.Point(25, 5);
            this.panelForPlate.Name = "panelForPlate";
            this.panelForPlate.Size = new System.Drawing.Size(769, 382);
            this.panelForPlate.TabIndex = 0;
            this.panelForPlate.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForPlate_Paint);
            this.panelForPlate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseDoubleClick);
            this.panelForPlate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseDown);
            this.panelForPlate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseMove);
            this.panelForPlate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseUp);
            this.panelForPlate.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseWheel);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::HCSAnalyzer.Properties.Resources.DarkLogo;
            this.pictureBox3.Location = new System.Drawing.Point(638, 258);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(124, 117);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // menuStripFile
            // 
            this.menuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.copyAverageValuesToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripcomboBoxPlateList,
            this.visualizationToolStripMenuItem,
            this.projectionsToolStripMenuItem,
            this.StatisticsToolStripMenuItem,
            this.toolStripMenuItemGeneAnalysis,
            this.betaToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStripFile.Location = new System.Drawing.Point(0, 0);
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(1220, 27);
            this.menuStripFile.TabIndex = 12;
            this.menuStripFile.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.cellByCellToolStripMenuItem,
            this.loadScreenToolStripMenuItem,
            this.generateScreenToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.appendDescriptorsToolStripMenuItem,
            this.linkToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.db_comit;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.importToolStripMenuItem.Text = "Import Screen";
            this.importToolStripMenuItem.ToolTipText = "Load screen from regular format";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // cellByCellToolStripMenuItem
            // 
            this.cellByCellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDBToolStripMenuItem,
            this.generateDBFromCSVToolStripMenuItem});
            this.cellByCellToolStripMenuItem.Name = "cellByCellToolStripMenuItem";
            this.cellByCellToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.cellByCellToolStripMenuItem.Text = "Cell by Cell";
            // 
            // loadDBToolStripMenuItem
            // 
            this.loadDBToolStripMenuItem.Name = "loadDBToolStripMenuItem";
            this.loadDBToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.loadDBToolStripMenuItem.Text = "Load Database";
            this.loadDBToolStripMenuItem.Click += new System.EventHandler(this.loadDBToolStripMenuItem_Click);
            // 
            // generateDBFromCSVToolStripMenuItem
            // 
            this.generateDBFromCSVToolStripMenuItem.Name = "generateDBFromCSVToolStripMenuItem";
            this.generateDBFromCSVToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.generateDBFromCSVToolStripMenuItem.Text = "CSV -> DB";
            this.generateDBFromCSVToolStripMenuItem.Click += new System.EventHandler(this.generateDBFromCSVToolStripMenuItem_Click);
            // 
            // loadScreenToolStripMenuItem
            // 
            this.loadScreenToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.document_open_5;
            this.loadScreenToolStripMenuItem.Name = "loadScreenToolStripMenuItem";
            this.loadScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadScreenToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.loadScreenToolStripMenuItem.Text = "Load Histogram Based Screen";
            this.loadScreenToolStripMenuItem.ToolTipText = "Load distributions based screens";
            this.loadScreenToolStripMenuItem.Click += new System.EventHandler(this.loadScreenToolStripMenuItem_Click);
            // 
            // generateScreenToolStripMenuItem1
            // 
            this.generateScreenToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.univariateToolStripMenuItem,
            this.multivariateToolStripMenuItem,
            this.histogramBasedToolStripMenuItem});
            this.generateScreenToolStripMenuItem1.Name = "generateScreenToolStripMenuItem1";
            this.generateScreenToolStripMenuItem1.Size = new System.Drawing.Size(271, 22);
            this.generateScreenToolStripMenuItem1.Text = "Generate Screen";
            // 
            // univariateToolStripMenuItem
            // 
            this.univariateToolStripMenuItem.Name = "univariateToolStripMenuItem";
            this.univariateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.univariateToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.univariateToolStripMenuItem.Text = "Univariate";
            this.univariateToolStripMenuItem.Click += new System.EventHandler(this.univariateToolStripMenuItem_Click);
            // 
            // multivariateToolStripMenuItem
            // 
            this.multivariateToolStripMenuItem.Name = "multivariateToolStripMenuItem";
            this.multivariateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.multivariateToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.multivariateToolStripMenuItem.Text = "Multivariate";
            this.multivariateToolStripMenuItem.Click += new System.EventHandler(this.multivariateToolStripMenuItem_Click);
            // 
            // histogramBasedToolStripMenuItem
            // 
            this.histogramBasedToolStripMenuItem.Enabled = false;
            this.histogramBasedToolStripMenuItem.Name = "histogramBasedToolStripMenuItem";
            this.histogramBasedToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.histogramBasedToolStripMenuItem.Text = "Histogram Based";
            this.histogramBasedToolStripMenuItem.Click += new System.EventHandler(this.histogramBasedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(268, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveScreentoCSVToolStripMenuItem,
            this.currentPlateTomtrToolStripMenuItem,
            this.toARFFToolStripMenuItem});
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.db_update;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.exportToolStripMenuItem.Text = "Save Screen";
            // 
            // SaveScreentoCSVToolStripMenuItem
            // 
            this.SaveScreentoCSVToolStripMenuItem.Name = "SaveScreentoCSVToolStripMenuItem";
            this.SaveScreentoCSVToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.SaveScreentoCSVToolStripMenuItem.Text = "To CSV";
            this.SaveScreentoCSVToolStripMenuItem.Click += new System.EventHandler(this.toExcelToolStripMenuItem_Click);
            // 
            // currentPlateTomtrToolStripMenuItem
            // 
            this.currentPlateTomtrToolStripMenuItem.Name = "currentPlateTomtrToolStripMenuItem";
            this.currentPlateTomtrToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.currentPlateTomtrToolStripMenuItem.Text = "To MTR";
            this.currentPlateTomtrToolStripMenuItem.ToolTipText = "Warning: only the selected descriptor will be saved in this format";
            this.currentPlateTomtrToolStripMenuItem.Click += new System.EventHandler(this.currentPlateTomtrToolStripMenuItem_Click);
            // 
            // toARFFToolStripMenuItem
            // 
            this.toARFFToolStripMenuItem.Name = "toARFFToolStripMenuItem";
            this.toARFFToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.toARFFToolStripMenuItem.Text = "To ARFF";
            this.toARFFToolStripMenuItem.Click += new System.EventHandler(this.toARFFToolStripMenuItem_Click);
            // 
            // appendDescriptorsToolStripMenuItem
            // 
            this.appendDescriptorsToolStripMenuItem.Enabled = false;
            this.appendDescriptorsToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.db_add;
            this.appendDescriptorsToolStripMenuItem.Name = "appendDescriptorsToolStripMenuItem";
            this.appendDescriptorsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.appendDescriptorsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.appendDescriptorsToolStripMenuItem.Text = "Add Plates";
            this.appendDescriptorsToolStripMenuItem.Click += new System.EventHandler(this.appendAssayToolStripMenuItem_Click);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.Enabled = false;
            this.linkToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.insert_link;
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.linkToolStripMenuItem.Text = "Link Data";
            this.linkToolStripMenuItem.Click += new System.EventHandler(this.linkToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(268, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.application_exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // copyAverageValuesToolStripMenuItem
            // 
            this.copyAverageValuesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAverageValuesToolStripMenuItem1,
            this.copyClassesToolStripMenuItem,
            this.swapClassesToolStripMenuItem,
            this.toolStripSeparator3,
            this.applySelectionToScreenToolStripMenuItem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem});
            this.copyAverageValuesToolStripMenuItem.Name = "copyAverageValuesToolStripMenuItem";
            this.copyAverageValuesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyAverageValuesToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.copyAverageValuesToolStripMenuItem.Text = "Edit";
            // 
            // copyAverageValuesToolStripMenuItem1
            // 
            this.copyAverageValuesToolStripMenuItem1.Enabled = false;
            this.copyAverageValuesToolStripMenuItem1.Name = "copyAverageValuesToolStripMenuItem1";
            this.copyAverageValuesToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.copyAverageValuesToolStripMenuItem1.Size = new System.Drawing.Size(282, 22);
            this.copyAverageValuesToolStripMenuItem1.Text = "Copy values to clipboard";
            this.copyAverageValuesToolStripMenuItem1.ToolTipText = "Copy the average values of the current plate and descriptor to the clipboard";
            this.copyAverageValuesToolStripMenuItem1.Click += new System.EventHandler(this.copyAverageValuesToolStripMenuItem1_Click);
            // 
            // copyClassesToolStripMenuItem
            // 
            this.copyClassesToolStripMenuItem.Enabled = false;
            this.copyClassesToolStripMenuItem.Name = "copyClassesToolStripMenuItem";
            this.copyClassesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyClassesToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.copyClassesToolStripMenuItem.Text = "Copy classes to clipboard";
            this.copyClassesToolStripMenuItem.ToolTipText = "Copy current plate classes to the clipboard";
            this.copyClassesToolStripMenuItem.Click += new System.EventHandler(this.copyClassesToolStripMenuItem_Click);
            // 
            // swapClassesToolStripMenuItem
            // 
            this.swapClassesToolStripMenuItem.Enabled = false;
            this.swapClassesToolStripMenuItem.Name = "swapClassesToolStripMenuItem";
            this.swapClassesToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.swapClassesToolStripMenuItem.Text = "Swap Classes";
            this.swapClassesToolStripMenuItem.Click += new System.EventHandler(this.swapClassesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(279, 6);
            // 
            // applySelectionToScreenToolStripMenuItem
            // 
            this.applySelectionToScreenToolStripMenuItem.Enabled = false;
            this.applySelectionToScreenToolStripMenuItem.Name = "applySelectionToScreenToolStripMenuItem";
            this.applySelectionToScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.applySelectionToScreenToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.applySelectionToScreenToolStripMenuItem.Text = "Apply selection To screen";
            this.applySelectionToScreenToolStripMenuItem.ToolTipText = "Apply the current plate classes to all the rest of the screen";
            this.applySelectionToScreenToolStripMenuItem.Click += new System.EventHandler(this.applySelectionToScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.configure_4;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.platesManagerToolStripMenuItem,
            this.toolStripSeparator6,
            this.plateViewToolStripMenuItem,
            this.descriptorViewToolStripMenuItem,
            this.toolStripSeparator7,
            this.classViewToolStripMenuItem,
            this.toolStripSeparator13,
            this.averageViewToolStripMenuItem,
            this.histogramViewToolStripMenuItem,
            this.pieViewToolStripMenuItem1,
            this.toolStripSeparator12,
            this.ThreeDVisualizationToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(114, 23);
            this.viewToolStripMenuItem.Text = "Windows && Views";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.CheckOnClick = true;
            this.consoleToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.format_justify_fill;
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // platesManagerToolStripMenuItem
            // 
            this.platesManagerToolStripMenuItem.Enabled = false;
            this.platesManagerToolStripMenuItem.Name = "platesManagerToolStripMenuItem";
            this.platesManagerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.platesManagerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.platesManagerToolStripMenuItem.Text = "Plates manager";
            this.platesManagerToolStripMenuItem.Click += new System.EventHandler(this.platesManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(189, 6);
            // 
            // plateViewToolStripMenuItem
            // 
            this.plateViewToolStripMenuItem.Name = "plateViewToolStripMenuItem";
            this.plateViewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.plateViewToolStripMenuItem.Text = "Plate Window";
            this.plateViewToolStripMenuItem.Click += new System.EventHandler(this.plateViewToolStripMenuItem_Click);
            // 
            // descriptorViewToolStripMenuItem
            // 
            this.descriptorViewToolStripMenuItem.Name = "descriptorViewToolStripMenuItem";
            this.descriptorViewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.descriptorViewToolStripMenuItem.Text = "Descriptor Window";
            this.descriptorViewToolStripMenuItem.Click += new System.EventHandler(this.descriptorViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(189, 6);
            // 
            // classViewToolStripMenuItem
            // 
            this.classViewToolStripMenuItem.CheckOnClick = true;
            this.classViewToolStripMenuItem.Name = "classViewToolStripMenuItem";
            this.classViewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.classViewToolStripMenuItem.Text = "Class View";
            this.classViewToolStripMenuItem.Click += new System.EventHandler(this.classViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(189, 6);
            // 
            // averageViewToolStripMenuItem
            // 
            this.averageViewToolStripMenuItem.Checked = true;
            this.averageViewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.averageViewToolStripMenuItem.Name = "averageViewToolStripMenuItem";
            this.averageViewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.averageViewToolStripMenuItem.Text = "Average View";
            this.averageViewToolStripMenuItem.Click += new System.EventHandler(this.averageViewToolStripMenuItem_Click);
            // 
            // histogramViewToolStripMenuItem
            // 
            this.histogramViewToolStripMenuItem.Name = "histogramViewToolStripMenuItem";
            this.histogramViewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.histogramViewToolStripMenuItem.Text = "Histogram View";
            this.histogramViewToolStripMenuItem.Click += new System.EventHandler(this.histogramViewToolStripMenuItem_Click);
            // 
            // pieViewToolStripMenuItem1
            // 
            this.pieViewToolStripMenuItem1.CheckOnClick = true;
            this.pieViewToolStripMenuItem1.Name = "pieViewToolStripMenuItem1";
            this.pieViewToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.pieViewToolStripMenuItem1.Text = "Pie View";
            this.pieViewToolStripMenuItem1.Click += new System.EventHandler(this.pieViewToolStripMenuItem1_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(189, 6);
            // 
            // ThreeDVisualizationToolStripMenuItem
            // 
            this.ThreeDVisualizationToolStripMenuItem.CheckOnClick = true;
            this.ThreeDVisualizationToolStripMenuItem.Name = "ThreeDVisualizationToolStripMenuItem";
            this.ThreeDVisualizationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.ThreeDVisualizationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ThreeDVisualizationToolStripMenuItem.Text = "3D Visualization";
            this.ThreeDVisualizationToolStripMenuItem.Click += new System.EventHandler(this.ThreeDVisualizationToolStripMenuItem_Click);
            // 
            // toolStripcomboBoxPlateList
            // 
            this.toolStripcomboBoxPlateList.DropDownWidth = 121;
            this.toolStripcomboBoxPlateList.Name = "toolStripcomboBoxPlateList";
            this.toolStripcomboBoxPlateList.Size = new System.Drawing.Size(250, 23);
            this.toolStripcomboBoxPlateList.SelectedIndexChanged += new System.EventHandler(this.toolStripcomboBoxPlateList_SelectedIndexChanged);
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scatterPointsToolStripMenuItem1,
            this.xYScatterPointsToolStripMenuItem,
            this.xYZScatterPointsToolStripMenuItem,
            this.distributionToolStripMenuItem,
            this.distanceMatrixToolStripMenuItem,
            this.toolStripSeparator9,
            this.visualizationToolStripMenuItemPCA,
            this.toolStripSeparator8,
            this.hierarchicalTreeToolStripMenuItem});
            this.visualizationToolStripMenuItem.Enabled = false;
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.visualizationToolStripMenuItem.Text = "Data Visualization";
            // 
            // scatterPointsToolStripMenuItem1
            // 
            this.scatterPointsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("scatterPointsToolStripMenuItem1.Image")));
            this.scatterPointsToolStripMenuItem1.Name = "scatterPointsToolStripMenuItem1";
            this.scatterPointsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.scatterPointsToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.scatterPointsToolStripMenuItem1.Text = "Scatter Points";
            this.scatterPointsToolStripMenuItem1.ToolTipText = "Display 1D points ";
            this.scatterPointsToolStripMenuItem1.Click += new System.EventHandler(this.scatterPointsToolStripMenuItem1_Click);
            // 
            // xYScatterPointsToolStripMenuItem
            // 
            this.xYScatterPointsToolStripMenuItem.Name = "xYScatterPointsToolStripMenuItem";
            this.xYScatterPointsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.xYScatterPointsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.xYScatterPointsToolStripMenuItem.Text = "XY Scatter Points";
            this.xYScatterPointsToolStripMenuItem.ToolTipText = "Display 2D points";
            this.xYScatterPointsToolStripMenuItem.Click += new System.EventHandler(this.xYScatterPointsToolStripMenuItem_Click);
            // 
            // xYZScatterPointsToolStripMenuItem
            // 
            this.xYZScatterPointsToolStripMenuItem.Name = "xYZScatterPointsToolStripMenuItem";
            this.xYZScatterPointsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.xYZScatterPointsToolStripMenuItem.Text = "XYZ Scatter Points";
            this.xYZScatterPointsToolStripMenuItem.ToolTipText = "Display 3D points";
            this.xYZScatterPointsToolStripMenuItem.Click += new System.EventHandler(this.xYZScatterPointsToolStripMenuItem_Click);
            // 
            // distributionToolStripMenuItem
            // 
            this.distributionToolStripMenuItem.Name = "distributionToolStripMenuItem";
            this.distributionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.distributionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.distributionToolStripMenuItem.Text = "Histogram";
            this.distributionToolStripMenuItem.ToolTipText = "Display Histogram";
            this.distributionToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // distanceMatrixToolStripMenuItem
            // 
            this.distanceMatrixToolStripMenuItem.Name = "distanceMatrixToolStripMenuItem";
            this.distanceMatrixToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.distanceMatrixToolStripMenuItem.Text = "Distance Matrix";
            this.distanceMatrixToolStripMenuItem.Click += new System.EventHandler(this.distanceMatrixToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(201, 6);
            // 
            // visualizationToolStripMenuItemPCA
            // 
            this.visualizationToolStripMenuItemPCA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scatterPointsToolStripMenuItem,
            this.xYScatterPointToolStripMenuItem,
            this.xYZScatterPointsToolStripMenuItemFullScreen,
            this.histogramToolStripMenuItem,
            this.stackedHistogramToolStripMenuItem,
            this.toolStripSeparator11,
            this.cellBasedClassificationTreeToolStripMenuItem});
            this.visualizationToolStripMenuItemPCA.Name = "visualizationToolStripMenuItemPCA";
            this.visualizationToolStripMenuItemPCA.Size = new System.Drawing.Size(204, 22);
            this.visualizationToolStripMenuItemPCA.Text = "Visualization Full Screen";
            // 
            // scatterPointsToolStripMenuItem
            // 
            this.scatterPointsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scatterPointsToolStripMenuItem.Image")));
            this.scatterPointsToolStripMenuItem.Name = "scatterPointsToolStripMenuItem";
            this.scatterPointsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.scatterPointsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.scatterPointsToolStripMenuItem.Text = "Scatter Points";
            this.scatterPointsToolStripMenuItem.Click += new System.EventHandler(this.scatterPointsToolStripMenuItem_Click);
            // 
            // xYScatterPointToolStripMenuItem
            // 
            this.xYScatterPointToolStripMenuItem.Name = "xYScatterPointToolStripMenuItem";
            this.xYScatterPointToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Y)));
            this.xYScatterPointToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.xYScatterPointToolStripMenuItem.Text = "XY Scatter Points";
            this.xYScatterPointToolStripMenuItem.Click += new System.EventHandler(this.xYScatterPointToolStripMenuItem_Click);
            // 
            // xYZScatterPointsToolStripMenuItemFullScreen
            // 
            this.xYZScatterPointsToolStripMenuItemFullScreen.Name = "xYZScatterPointsToolStripMenuItemFullScreen";
            this.xYZScatterPointsToolStripMenuItemFullScreen.Size = new System.Drawing.Size(246, 22);
            this.xYZScatterPointsToolStripMenuItemFullScreen.Text = "XYZ Scatter Points";
            this.xYZScatterPointsToolStripMenuItemFullScreen.Click += new System.EventHandler(this.xYZScatterPointsToolStripMenuItemFullScreen_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // stackedHistogramToolStripMenuItem
            // 
            this.stackedHistogramToolStripMenuItem.Name = "stackedHistogramToolStripMenuItem";
            this.stackedHistogramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.stackedHistogramToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.stackedHistogramToolStripMenuItem.Text = "Stacked Histogram";
            this.stackedHistogramToolStripMenuItem.Click += new System.EventHandler(this.stackedHistogramToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(243, 6);
            // 
            // cellBasedClassificationTreeToolStripMenuItem
            // 
            this.cellBasedClassificationTreeToolStripMenuItem.Name = "cellBasedClassificationTreeToolStripMenuItem";
            this.cellBasedClassificationTreeToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.cellBasedClassificationTreeToolStripMenuItem.Text = "Cell-based Classification Tree";
            this.cellBasedClassificationTreeToolStripMenuItem.Click += new System.EventHandler(this.cellBasedClassificationTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(201, 6);
            // 
            // hierarchicalTreeToolStripMenuItem
            // 
            this.hierarchicalTreeToolStripMenuItem.Name = "hierarchicalTreeToolStripMenuItem";
            this.hierarchicalTreeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hierarchicalTreeToolStripMenuItem.Text = "Hierarchical Tree";
            this.hierarchicalTreeToolStripMenuItem.Click += new System.EventHandler(this.hierarchicalTreeToolStripMenuItem_Click);
            // 
            // projectionsToolStripMenuItem
            // 
            this.projectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PCAToolStripMenuItem,
            this.lDAToolStripMenuItem2,
            this.projectionsFullScreenToolStripMenuItem});
            this.projectionsToolStripMenuItem.Enabled = false;
            this.projectionsToolStripMenuItem.Name = "projectionsToolStripMenuItem";
            this.projectionsToolStripMenuItem.Size = new System.Drawing.Size(78, 23);
            this.projectionsToolStripMenuItem.Text = "Projections";
            // 
            // PCAToolStripMenuItem
            // 
            this.PCAToolStripMenuItem.Name = "PCAToolStripMenuItem";
            this.PCAToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.PCAToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.PCAToolStripMenuItem.Text = "PCA";
            this.PCAToolStripMenuItem.ToolTipText = "Project Data after Principal Component Analysis ";
            this.PCAToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // lDAToolStripMenuItem2
            // 
            this.lDAToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayGraphToolStripMenuItem});
            this.lDAToolStripMenuItem2.Name = "lDAToolStripMenuItem2";
            this.lDAToolStripMenuItem2.Size = new System.Drawing.Size(193, 22);
            this.lDAToolStripMenuItem2.Text = "LDA";
            this.lDAToolStripMenuItem2.ToolTipText = "Project data after Linear Discreminent Analysis";
            // 
            // displayGraphToolStripMenuItem
            // 
            this.displayGraphToolStripMenuItem.Name = "displayGraphToolStripMenuItem";
            this.displayGraphToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.displayGraphToolStripMenuItem.Text = "Display Graph";
            this.displayGraphToolStripMenuItem.Click += new System.EventHandler(this.displayGraphToolStripMenuItem_Click);
            // 
            // projectionsFullScreenToolStripMenuItem
            // 
            this.projectionsFullScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lDAToolStripMenuItem,
            this.pCAToolStripMenuItem2});
            this.projectionsFullScreenToolStripMenuItem.Name = "projectionsFullScreenToolStripMenuItem";
            this.projectionsFullScreenToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.projectionsFullScreenToolStripMenuItem.Text = "Projections Full Screen";
            // 
            // lDAToolStripMenuItem
            // 
            this.lDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayGraphToolStripMenuItem1});
            this.lDAToolStripMenuItem.Name = "lDAToolStripMenuItem";
            this.lDAToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.lDAToolStripMenuItem.Text = "LDA Full Screen";
            // 
            // displayGraphToolStripMenuItem1
            // 
            this.displayGraphToolStripMenuItem1.Name = "displayGraphToolStripMenuItem1";
            this.displayGraphToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.displayGraphToolStripMenuItem1.Text = "Display Graph";
            this.displayGraphToolStripMenuItem1.Click += new System.EventHandler(this.displayGraphToolStripMenuItem1_Click);
            // 
            // pCAToolStripMenuItem2
            // 
            this.pCAToolStripMenuItem2.Name = "pCAToolStripMenuItem2";
            this.pCAToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.pCAToolStripMenuItem2.Size = new System.Drawing.Size(231, 22);
            this.pCAToolStripMenuItem2.Text = "PCA Full Screen";
            this.pCAToolStripMenuItem2.Click += new System.EventHandler(this.pCAToolStripMenuItem2_Click);
            // 
            // StatisticsToolStripMenuItem
            // 
            this.StatisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zscoreSinglePlateToolStripMenuItem,
            this.normalProbabilityPlotToolStripMenuItem,
            this.toolStripMenuItem2,
            this.systematicErrorsToolStripMenuItem1,
            this.mINEAnalysisToolStripMenuItem,
            this.qualityControlToolStripMenuItem});
            this.StatisticsToolStripMenuItem.Enabled = false;
            this.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            this.StatisticsToolStripMenuItem.Size = new System.Drawing.Size(124, 23);
            this.StatisticsToolStripMenuItem.Text = "Statistics && Analysis";
            // 
            // zscoreSinglePlateToolStripMenuItem
            // 
            this.zscoreSinglePlateToolStripMenuItem.Name = "zscoreSinglePlateToolStripMenuItem";
            this.zscoreSinglePlateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.zscoreSinglePlateToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.zscoreSinglePlateToolStripMenuItem.Text = "Z-score";
            this.zscoreSinglePlateToolStripMenuItem.ToolTipText = "Compute Z-score between two controls";
            this.zscoreSinglePlateToolStripMenuItem.Click += new System.EventHandler(this.zscoreSinglePlateToolStripMenuItem_Click);
            // 
            // normalProbabilityPlotToolStripMenuItem
            // 
            this.normalProbabilityPlotToolStripMenuItem.Name = "normalProbabilityPlotToolStripMenuItem";
            this.normalProbabilityPlotToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.normalProbabilityPlotToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.normalProbabilityPlotToolStripMenuItem.Text = "Normal Probability Plot";
            this.normalProbabilityPlotToolStripMenuItem.ToolTipText = "Data should fit random distribution";
            this.normalProbabilityPlotToolStripMenuItem.Click += new System.EventHandler(this.normalProbabilityPlotToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem2.Text = "Correlation Matrix";
            this.toolStripMenuItem2.ToolTipText = "Correlation Matrix of descriptors";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // systematicErrorsToolStripMenuItem1
            // 
            this.systematicErrorsToolStripMenuItem1.Name = "systematicErrorsToolStripMenuItem1";
            this.systematicErrorsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.systematicErrorsToolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
            this.systematicErrorsToolStripMenuItem1.Text = "Systematic Errors";
            this.systematicErrorsToolStripMenuItem1.ToolTipText = "Evaluate the systematic spatial errors  ";
            this.systematicErrorsToolStripMenuItem1.Click += new System.EventHandler(this.systematicErrorsToolStripMenuItem1_Click);
            // 
            // mINEAnalysisToolStripMenuItem
            // 
            this.mINEAnalysisToolStripMenuItem.Name = "mINEAnalysisToolStripMenuItem";
            this.mINEAnalysisToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.mINEAnalysisToolStripMenuItem.Text = "MINE analysis";
            this.mINEAnalysisToolStripMenuItem.ToolTipText = "Compute nonlinear correlation factors (Science2012)";
            this.mINEAnalysisToolStripMenuItem.Click += new System.EventHandler(this.mINEAnalysisToolStripMenuItem_Click);
            // 
            // qualityControlToolStripMenuItem
            // 
            this.qualityControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zscoreToolStripMenuItem,
            this.sSMDToolStripMenuItem,
            this.normalProbabilityPlotToolStripMenuItem1,
            this.correlationMatrixToolStripMenuItem,
            this.coeffOfVariationEvolutionToolStripMenuItem,
            this.descriptorEvolutionToolStripMenuItem,
            this.classesDistributionToolStripMenuItem,
            this.extractPhenotypesOfInterestToolStripMenuItem,
            this.toolStripSeparator10,
            this.generateHitsDistributionMapToolStripMenuItem});
            this.qualityControlToolStripMenuItem.Name = "qualityControlToolStripMenuItem";
            this.qualityControlToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.qualityControlToolStripMenuItem.Text = "Statistics Full Screen";
            // 
            // zscoreToolStripMenuItem
            // 
            this.zscoreToolStripMenuItem.Name = "zscoreToolStripMenuItem";
            this.zscoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.zscoreToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.zscoreToolStripMenuItem.Text = "Z-score";
            this.zscoreToolStripMenuItem.Click += new System.EventHandler(this.zscoreToolStripMenuItem_Click_1);
            // 
            // sSMDToolStripMenuItem
            // 
            this.sSMDToolStripMenuItem.Name = "sSMDToolStripMenuItem";
            this.sSMDToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.sSMDToolStripMenuItem.Text = "SSMD";
            this.sSMDToolStripMenuItem.Click += new System.EventHandler(this.sSMDToolStripMenuItem_Click);
            // 
            // normalProbabilityPlotToolStripMenuItem1
            // 
            this.normalProbabilityPlotToolStripMenuItem1.Name = "normalProbabilityPlotToolStripMenuItem1";
            this.normalProbabilityPlotToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.normalProbabilityPlotToolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.normalProbabilityPlotToolStripMenuItem1.Text = "Normal Probability Plot";
            this.normalProbabilityPlotToolStripMenuItem1.Click += new System.EventHandler(this.normalProbabilityPlotToolStripMenuItem1_Click);
            // 
            // correlationMatrixToolStripMenuItem
            // 
            this.correlationMatrixToolStripMenuItem.Name = "correlationMatrixToolStripMenuItem";
            this.correlationMatrixToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.correlationMatrixToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.correlationMatrixToolStripMenuItem.Text = "Correlation Matrix";
            this.correlationMatrixToolStripMenuItem.Click += new System.EventHandler(this.correlationMatrixToolStripMenuItem_Click);
            // 
            // coeffOfVariationEvolutionToolStripMenuItem
            // 
            this.coeffOfVariationEvolutionToolStripMenuItem.Name = "coeffOfVariationEvolutionToolStripMenuItem";
            this.coeffOfVariationEvolutionToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.coeffOfVariationEvolutionToolStripMenuItem.Text = "Coeff. of Variation Evolution";
            this.coeffOfVariationEvolutionToolStripMenuItem.Click += new System.EventHandler(this.coeffOfVariationEvolutionToolStripMenuItem_Click);
            // 
            // descriptorEvolutionToolStripMenuItem
            // 
            this.descriptorEvolutionToolStripMenuItem.Name = "descriptorEvolutionToolStripMenuItem";
            this.descriptorEvolutionToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.descriptorEvolutionToolStripMenuItem.Text = "Descriptor Evolution";
            this.descriptorEvolutionToolStripMenuItem.Click += new System.EventHandler(this.descriptorEvolutionToolStripMenuItem_Click);
            // 
            // classesDistributionToolStripMenuItem
            // 
            this.classesDistributionToolStripMenuItem.Name = "classesDistributionToolStripMenuItem";
            this.classesDistributionToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.classesDistributionToolStripMenuItem.Text = "Classes Distribution";
            this.classesDistributionToolStripMenuItem.Click += new System.EventHandler(this.classesDistributionToolStripMenuItem_Click);
            // 
            // extractPhenotypesOfInterestToolStripMenuItem
            // 
            this.extractPhenotypesOfInterestToolStripMenuItem.Name = "extractPhenotypesOfInterestToolStripMenuItem";
            this.extractPhenotypesOfInterestToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.extractPhenotypesOfInterestToolStripMenuItem.Text = "Extract Phenotypes of Interest";
            this.extractPhenotypesOfInterestToolStripMenuItem.Click += new System.EventHandler(this.extractPhenotypesOfInterestToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(270, 6);
            // 
            // generateHitsDistributionMapToolStripMenuItem
            // 
            this.generateHitsDistributionMapToolStripMenuItem.Name = "generateHitsDistributionMapToolStripMenuItem";
            this.generateHitsDistributionMapToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.generateHitsDistributionMapToolStripMenuItem.Text = "Hits Distribution Maps";
            this.generateHitsDistributionMapToolStripMenuItem.Click += new System.EventHandler(this.generateHitsDistributionMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItemGeneAnalysis
            // 
            this.toolStripMenuItemGeneAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findGeneToolStripMenuItem,
            this.pahtwaysAnalysisToolStripMenuItem,
            this.findPathwayToolStripMenuItem});
            this.toolStripMenuItemGeneAnalysis.Enabled = false;
            this.toolStripMenuItemGeneAnalysis.Name = "toolStripMenuItemGeneAnalysis";
            this.toolStripMenuItemGeneAnalysis.Size = new System.Drawing.Size(113, 23);
            this.toolStripMenuItemGeneAnalysis.Text = "Genomic Analysis";
            // 
            // findGeneToolStripMenuItem
            // 
            this.findGeneToolStripMenuItem.Name = "findGeneToolStripMenuItem";
            this.findGeneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.findGeneToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.findGeneToolStripMenuItem.Text = "Find Gene";
            this.findGeneToolStripMenuItem.Click += new System.EventHandler(this.findGeneToolStripMenuItem_Click);
            // 
            // pahtwaysAnalysisToolStripMenuItem
            // 
            this.pahtwaysAnalysisToolStripMenuItem.Name = "pahtwaysAnalysisToolStripMenuItem";
            this.pahtwaysAnalysisToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.pahtwaysAnalysisToolStripMenuItem.Text = "Pathways analysis";
            this.pahtwaysAnalysisToolStripMenuItem.ToolTipText = "Compute Pathway redundancies among one class ";
            this.pahtwaysAnalysisToolStripMenuItem.Click += new System.EventHandler(this.pahtwaysAnalysisToolStripMenuItem_Click);
            // 
            // findPathwayToolStripMenuItem
            // 
            this.findPathwayToolStripMenuItem.Name = "findPathwayToolStripMenuItem";
            this.findPathwayToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.findPathwayToolStripMenuItem.Text = "Find Pathway";
            this.findPathwayToolStripMenuItem.Click += new System.EventHandler(this.findPathwayToolStripMenuItem_Click);
            // 
            // betaToolStripMenuItem
            // 
            this.betaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dRCAnalysisToolStripMenuItem2,
            this.distributionsToolStripMenuItem,
            this.toolStripMenuItem3});
            this.betaToolStripMenuItem.Name = "betaToolStripMenuItem";
            this.betaToolStripMenuItem.Size = new System.Drawing.Size(42, 23);
            this.betaToolStripMenuItem.Text = "Beta";
            this.betaToolStripMenuItem.ToolTipText = "At your own risk!!!";
            // 
            // dRCAnalysisToolStripMenuItem2
            // 
            this.dRCAnalysisToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doseResponseDesignerToolStripMenuItem,
            this.toolStripSeparator5,
            this.convertDRCToWellToolStripMenuItem1,
            this.displayDRCToolStripMenuItem1,
            this.displayRespondingDRCToolStripMenuItem1,
            this.toolStripSeparator14,
            this.currentPlate3DToolStripMenuItem,
            this.toolStripSeparator15,
            this.generateDRCsToolStripMenuItem});
            this.dRCAnalysisToolStripMenuItem2.Name = "dRCAnalysisToolStripMenuItem2";
            this.dRCAnalysisToolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.dRCAnalysisToolStripMenuItem2.Text = "DRC Analysis";
            // 
            // doseResponseDesignerToolStripMenuItem
            // 
            this.doseResponseDesignerToolStripMenuItem.Name = "doseResponseDesignerToolStripMenuItem";
            this.doseResponseDesignerToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.doseResponseDesignerToolStripMenuItem.Text = "Dose Response Designer";
            this.doseResponseDesignerToolStripMenuItem.Click += new System.EventHandler(this.doseResponseDesignerToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // convertDRCToWellToolStripMenuItem1
            // 
            this.convertDRCToWellToolStripMenuItem1.Name = "convertDRCToWellToolStripMenuItem1";
            this.convertDRCToWellToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.convertDRCToWellToolStripMenuItem1.Text = "Convert DRC To Well";
            this.convertDRCToWellToolStripMenuItem1.Click += new System.EventHandler(this.convertDRCToWellToolStripMenuItem1_Click);
            // 
            // displayDRCToolStripMenuItem1
            // 
            this.displayDRCToolStripMenuItem1.Name = "displayDRCToolStripMenuItem1";
            this.displayDRCToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.displayDRCToolStripMenuItem1.Text = "Display DRC";
            this.displayDRCToolStripMenuItem1.Click += new System.EventHandler(this.displayDRCToolStripMenuItem1_Click);
            // 
            // displayRespondingDRCToolStripMenuItem1
            // 
            this.displayRespondingDRCToolStripMenuItem1.Name = "displayRespondingDRCToolStripMenuItem1";
            this.displayRespondingDRCToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.displayRespondingDRCToolStripMenuItem1.Text = "Display Responding DRC";
            this.displayRespondingDRCToolStripMenuItem1.Click += new System.EventHandler(this.displayRespondingDRCToolStripMenuItem1_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(246, 6);
            // 
            // currentPlate3DToolStripMenuItem
            // 
            this.currentPlate3DToolStripMenuItem.Name = "currentPlate3DToolStripMenuItem";
            this.currentPlate3DToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.currentPlate3DToolStripMenuItem.Text = "XYZ Scatter Pts with Connections";
            this.currentPlate3DToolStripMenuItem.Click += new System.EventHandler(this.currentPlate3DToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(246, 6);
            // 
            // generateDRCsToolStripMenuItem
            // 
            this.generateDRCsToolStripMenuItem.Name = "generateDRCsToolStripMenuItem";
            this.generateDRCsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.generateDRCsToolStripMenuItem.Text = "Generate DRCs";
            this.generateDRCsToolStripMenuItem.Click += new System.EventHandler(this.generateDRCsToolStripMenuItem_Click);
            // 
            // distributionsToolStripMenuItem
            // 
            this.distributionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distributionsModeToolStripMenuItem,
            this.displayReferenceToolStripMenuItem});
            this.distributionsToolStripMenuItem.Name = "distributionsToolStripMenuItem";
            this.distributionsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.distributionsToolStripMenuItem.Text = "Histograms Analysis";
            // 
            // distributionsModeToolStripMenuItem
            // 
            this.distributionsModeToolStripMenuItem.CheckOnClick = true;
            this.distributionsModeToolStripMenuItem.Name = "distributionsModeToolStripMenuItem";
            this.distributionsModeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.distributionsModeToolStripMenuItem.Text = "Histogram Mode";
            this.distributionsModeToolStripMenuItem.Click += new System.EventHandler(this.distributionsModeToolStripMenuItem_Click);
            // 
            // displayReferenceToolStripMenuItem
            // 
            this.displayReferenceToolStripMenuItem.Name = "displayReferenceToolStripMenuItem";
            this.displayReferenceToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.displayReferenceToolStripMenuItem.Text = "Display Reference";
            this.displayReferenceToolStripMenuItem.Click += new System.EventHandler(this.displayReferenceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "Load FACS data";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Enabled = false;
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.pluginsToolStripMenuItem.Text = "Plug-ins";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHCSAnalyzerToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutHCSAnalyzerToolStripMenuItem
            // 
            this.aboutHCSAnalyzerToolStripMenuItem.Image = global::HCSAnalyzer.Properties.Resources.help_about;
            this.aboutHCSAnalyzerToolStripMenuItem.Name = "aboutHCSAnalyzerToolStripMenuItem";
            this.aboutHCSAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutHCSAnalyzerToolStripMenuItem.Text = "About HCS analyzer";
            this.aboutHCSAnalyzerToolStripMenuItem.Click += new System.EventHandler(this.aboutHCSAnalyzerToolStripMenuItem_Click);
            // 
            // checkedListBoxActiveDescriptors
            // 
            this.checkedListBoxActiveDescriptors.AllowDrop = true;
            this.checkedListBoxActiveDescriptors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxActiveDescriptors.CheckOnClick = true;
            this.checkedListBoxActiveDescriptors.FormattingEnabled = true;
            this.checkedListBoxActiveDescriptors.Location = new System.Drawing.Point(3, 85);
            this.checkedListBoxActiveDescriptors.Name = "checkedListBoxActiveDescriptors";
            this.checkedListBoxActiveDescriptors.Size = new System.Drawing.Size(216, 304);
            this.checkedListBoxActiveDescriptors.TabIndex = 8;
            this.checkedListBoxActiveDescriptors.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDescriptorActive_SelectedIndexChanged);
            this.checkedListBoxActiveDescriptors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxActiveDescriptors_MouseDown);
            // 
            // comboBoxDescriptorToDisplay
            // 
            this.comboBoxDescriptorToDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDescriptorToDisplay.FormattingEnabled = true;
            this.comboBoxDescriptorToDisplay.Location = new System.Drawing.Point(3, 26);
            this.comboBoxDescriptorToDisplay.Name = "comboBoxDescriptorToDisplay";
            this.comboBoxDescriptorToDisplay.Size = new System.Drawing.Size(216, 21);
            this.comboBoxDescriptorToDisplay.TabIndex = 9;
            this.comboBoxDescriptorToDisplay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescriptorToDisplay_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Current Descriptor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Descriptor List";
            // 
            // contextMenuStripForLUT
            // 
            this.contextMenuStripForLUT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStripForLUT.Name = "contextMenuStripForLUT";
            this.contextMenuStripForLUT.Size = new System.Drawing.Size(170, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem1.Text = "Copy to clipboard";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(172, 33);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.buttonPreviousPlate);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonNextPlate);
            this.splitContainerMain.Panel1.Controls.Add(this.panelForPlate);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.checkedListBoxActiveDescriptors);
            this.splitContainerMain.Panel2.Controls.Add(this.label2);
            this.splitContainerMain.Panel2.Controls.Add(this.comboBoxDescriptorToDisplay);
            this.splitContainerMain.Panel2.Controls.Add(this.label8);
            this.splitContainerMain.Size = new System.Drawing.Size(1048, 390);
            this.splitContainerMain.SplitterDistance = 821;
            this.splitContainerMain.TabIndex = 35;
            // 
            // buttonPreviousPlate
            // 
            this.buttonPreviousPlate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPreviousPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousPlate.Location = new System.Drawing.Point(4, 3);
            this.buttonPreviousPlate.Name = "buttonPreviousPlate";
            this.buttonPreviousPlate.Size = new System.Drawing.Size(19, 384);
            this.buttonPreviousPlate.TabIndex = 2;
            this.buttonPreviousPlate.Text = "<";
            this.buttonPreviousPlate.UseVisualStyleBackColor = true;
            this.buttonPreviousPlate.Click += new System.EventHandler(this.buttonPreviousPlate_Click);
            // 
            // buttonNextPlate
            // 
            this.buttonNextPlate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextPlate.Location = new System.Drawing.Point(795, 3);
            this.buttonNextPlate.Name = "buttonNextPlate";
            this.buttonNextPlate.Size = new System.Drawing.Size(19, 384);
            this.buttonNextPlate.TabIndex = 1;
            this.buttonNextPlate.Text = ">";
            this.buttonNextPlate.UseVisualStyleBackColor = true;
            this.buttonNextPlate.Click += new System.EventHandler(this.buttonNextPlate_Click);
            // 
            // HCSAnalyzer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 732);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelForTools);
            this.Controls.Add(this.menuStripFile);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripFile;
            this.Name = "HCSAnalyzer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HCSAnalyzer_FormClosed);
            this.Load += new System.EventHandler(this.HCSAnalyzer_Load);
            this.Shown += new System.EventHandler(this.HCSAnalyzer_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HCSAnalyzer_KeyPress);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForPlate_MouseWheel);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDImRed.ResumeLayout(false);
            this.tabPageDImRed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewDimension)).EndInit();
            this.groupBoxUnsupervised.ResumeLayout(false);
            this.groupBoxSupervised.ResumeLayout(false);
            this.groupBoxSupervised.PerformLayout();
            this.tabPageQualityQtrl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRejectionThreshold)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForQualityControl)).EndInit();
            this.tabPageNormalization.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tabPageClassification.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualThreshold)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClusterNumber)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPageExport.ResumeLayout(false);
            this.splitContainerExport.Panel1.ResumeLayout(false);
            this.splitContainerExport.Panel2.ResumeLayout(false);
            this.splitContainerExport.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExport)).EndInit();
            this.splitContainerExport.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPageWellsSelection.ResumeLayout(false);
            this.contextMenuStripForListSelectedWells.ResumeLayout(false);
            this.panelForTools.ResumeLayout(false);
            this.panelForTools.PerformLayout();
            this.panelForPlate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStripFile.ResumeLayout(false);
            this.menuStripFile.PerformLayout();
            this.contextMenuStripForLUT.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadScreenToolStripMenuItem;
        private System.Windows.Forms.Button buttonSizeIncrease;
        private System.Windows.Forms.Button buttonSizeDecrease;
        private System.Windows.Forms.CheckedListBox checkedListBoxActiveDescriptors;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentPlateTomtrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAverageValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAverageValuesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyClassesToolStripMenuItem;
        private System.Windows.Forms.Button buttonGlobalSelection;
        private System.Windows.Forms.CheckBox checkBoxApplyToAllPlates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem platesManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveScreentoCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem applySelectionToScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHCSAnalyzerToolStripMenuItem;
        public System.Windows.Forms.Panel panelForLUT;
        public System.Windows.Forms.Label labelMax;
        public System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TabPage tabPageNormalization;
        private System.Windows.Forms.TabPage tabPageClassification;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCorrectionPlateByPlate;
        private System.Windows.Forms.Button buttonNormalize;
        private System.Windows.Forms.Button buttonStartClassification;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageQualityQtrl;
        private System.Windows.Forms.ComboBox comboBoxDescriptorToDisplay;
        private System.Windows.Forms.CheckBox checkBoxDisplayClasses;
        private System.Windows.Forms.Panel panelForTools;
        private System.Windows.Forms.RadioButton radioButtonClassifPlateByPlate;
        private System.Windows.Forms.Button buttonQualityControl;
        private System.Windows.Forms.ToolStripMenuItem appendDescriptorsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewForQualityControl;
        private System.Windows.Forms.Button buttonGlobalOnlySelected;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBoxForScreeningInformation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox checkBoxExportPlateFormat;
        private System.Windows.Forms.CheckBox checkBoxExportFullScreen;
        private System.Windows.Forms.CheckBox checkBoxExportScreeningInformation;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ImageList imageListForTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReduceDim;
        private System.Windows.Forms.GroupBox groupBoxUnsupervised;
        private System.Windows.Forms.NumericUpDown numericUpDownNewDimension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageDImRed;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RichTextBox richTextBoxInfoClustering;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RichTextBox richTextBoxInfoClassif;
        private System.Windows.Forms.Button buttonCluster;
        private System.Windows.Forms.ComboBox comboBoxClusteringMethod;
        private System.Windows.Forms.ComboBox comboBoxCLassificationMethod;
        private System.Windows.Forms.RadioButton radioButtonClassifGlobal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxSupervised;
        private System.Windows.Forms.ComboBox comboBoxReduceDimMultiClass;
        private System.Windows.Forms.ComboBox comboBoxReduceDimSingleClass;
        private System.Windows.Forms.RichTextBox richTextBoxSupervisedDimRec;
        private System.Windows.Forms.RichTextBox richTextBoxUnsupervisedDimRec;
        private System.Windows.Forms.RadioButton radioButtonDimRedSupervised;
        private System.Windows.Forms.RadioButton radioButtonDimRedUnsupervised;
        private System.Windows.Forms.ComboBox comboBoxDimReductionNeutralClass;
        private System.Windows.Forms.ComboBox comboBoxNeutralClassForClassif;
        private System.Windows.Forms.ComboBox comboBoxMethodForCorrection;
        private System.Windows.Forms.RichTextBox richTextBoxInformationForPlateCorrection;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.RichTextBox richTextBoxInfoForNormalization;
        private System.Windows.Forms.ComboBox comboBoxMethodForNormalization;
        private System.Windows.Forms.ComboBox comboBoxNormalizationPositiveCtrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxNormalizationNegativeCtrl;
        private System.Windows.Forms.Label label4;
        private Label label8;
        private ToolStripMenuItem swapClassesToolStripMenuItem;
        public ToolStripComboBox toolStripcomboBoxPlateList;
        private Button buttonRejectPlates;
        private GroupBox groupBox1;
        private RichTextBox richTextBoxInformationRejection;
        private ComboBox comboBoxRejection;
        private NumericUpDown numericUpDownRejectionThreshold;
        private Label label9;
        private TreeView treeViewSelectionForExport;
        private ToolStripMenuItem generateScreenToolStripMenuItem1;
        private ToolStripMenuItem univariateToolStripMenuItem;
        private ToolStripMenuItem multivariateToolStripMenuItem;
        private ContextMenuStrip contextMenuStripForLUT;
        private ToolStripMenuItem toolStripMenuItem1;
        private RadioButton radioButtonClusterFullScreen;
        private RadioButton radioButtonClusterPlateByPlate;
        private Label label10;
        private CheckBox checkBoxAutomatedClusterNumber;
        private NumericUpDown numericUpDownClusterNumber;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem toARFFToolStripMenuItem;
        private ComboBox comboBoxRejectionPositiveCtrl;
        private Label label11;
        private ComboBox comboBoxRejectionNegativeCtrl;
        private Label label12;
        private ToolStripMenuItem betaToolStripMenuItem;
        private ToolStripMenuItem dRCAnalysisToolStripMenuItem2;
        private ToolStripMenuItem doseResponseDesignerToolStripMenuItem;
        private ToolStripMenuItem convertDRCToWellToolStripMenuItem1;
        private ToolStripMenuItem displayDRCToolStripMenuItem1;
        private ToolStripMenuItem displayRespondingDRCToolStripMenuItem1;
        private ToolStripMenuItem distributionsToolStripMenuItem;
        private ToolStripMenuItem distributionsModeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private SplitContainer splitContainerExport;
        private ToolStripMenuItem displayReferenceToolStripMenuItem;
        private ToolStripMenuItem histogramBasedToolStripMenuItem;
        public TabControl tabControlMain;
        private SplitContainer splitContainerMain;
        public Panel panelForPlate;
        private Button buttonNextPlate;
        private Button buttonPreviousPlate;
        private TabPage tabPageWellsSelection;
        private Button buttonDisplayWellsSelectionData;
        private ComboBox comboBoxClassForWellSelection;
        private ListBox listBoxSelectedWells;
        private Button buttonToSelectWellsFromClass;
        private ContextMenuStrip contextMenuStripForListSelectedWells;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem projectionsToolStripMenuItem;
        private ToolStripMenuItem PCAToolStripMenuItem;
        private ToolStripMenuItem lDAToolStripMenuItem2;
        private ToolStripMenuItem displayGraphToolStripMenuItem;
        private ToolStripMenuItem visualizationToolStripMenuItem;
        private ToolStripMenuItem scatterPointsToolStripMenuItem1;
        private ToolStripMenuItem xYScatterPointsToolStripMenuItem;
        private ToolStripMenuItem xYZScatterPointsToolStripMenuItem;
        private ToolStripMenuItem distributionToolStripMenuItem;
        private ToolStripMenuItem distanceMatrixToolStripMenuItem;
        private ToolStripMenuItem visualizationToolStripMenuItemPCA;
        private ToolStripMenuItem scatterPointsToolStripMenuItem;
        private ToolStripMenuItem xYScatterPointToolStripMenuItem;
        private ToolStripMenuItem xYZScatterPointsToolStripMenuItemFullScreen;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem stackedHistogramToolStripMenuItem;
        private ToolStripMenuItem cellBasedClassificationTreeToolStripMenuItem;
        private ToolStripMenuItem StatisticsToolStripMenuItem;
        private ToolStripMenuItem zscoreSinglePlateToolStripMenuItem;
        private ToolStripMenuItem normalProbabilityPlotToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem systematicErrorsToolStripMenuItem1;
        private ToolStripMenuItem mINEAnalysisToolStripMenuItem;
        private ToolStripMenuItem qualityControlToolStripMenuItem;
        private ToolStripMenuItem zscoreToolStripMenuItem;
        private ToolStripMenuItem sSMDToolStripMenuItem;
        private ToolStripMenuItem normalProbabilityPlotToolStripMenuItem1;
        private ToolStripMenuItem correlationMatrixToolStripMenuItem;
        private ToolStripMenuItem coeffOfVariationEvolutionToolStripMenuItem;
        private ToolStripMenuItem descriptorEvolutionToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemGeneAnalysis;
        private ToolStripMenuItem findGeneToolStripMenuItem;
        private ToolStripMenuItem pahtwaysAnalysisToolStripMenuItem;
        private ToolStripMenuItem findPathwayToolStripMenuItem;
        private Label label1;
        private ComboBox comboBoxClass;
        private Label labelNumClasses;
        private ToolStripMenuItem projectionsFullScreenToolStripMenuItem;
        private ToolStripMenuItem lDAToolStripMenuItem;
        private ToolStripMenuItem displayGraphToolStripMenuItem1;
        private ToolStripMenuItem pCAToolStripMenuItem2;
        private Button button_Trees;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem classesDistributionToolStripMenuItem;
        private ToolStripMenuItem hierarchicalTreeToolStripMenuItem;
        private ToolStripMenuItem extractPhenotypesOfInterestToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem plateViewToolStripMenuItem;
        private ToolStripMenuItem descriptorViewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem pieViewToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator8;
        public ToolStripMenuItem ThreeDVisualizationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem generateHitsDistributionMapToolStripMenuItem;
        private ToolStripMenuItem cellByCellToolStripMenuItem;
        private ToolStripMenuItem generateDBFromCSVToolStripMenuItem;
        private ToolStripMenuItem loadDBToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem classViewToolStripMenuItem;
        private ToolStripMenuItem averageViewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem histogramViewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem currentPlate3DToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem generateDRCsToolStripMenuItem;
        private GroupBox groupBox6;
        private NumericUpDown numericUpDownManualThreshold;
        private RadioButton radioButtonManualLowerThan;
        private ComboBox comboBoxManualClassToBeAnalyzed;
        private RadioButton radioButtonManualHigherThan;
        private Label label13;
        private RichTextBox richTextBoxForManualSelection;
        private ComboBox comboBoxdescriptorToBeAnalyzed;
        private Button buttonStartManualSelection;
        private Label label14;
    }
}

