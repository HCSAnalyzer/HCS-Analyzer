using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using System.Windows.Forms;
using System.Data;
using LibPlateAnalysis;
using HCSAnalyzer.Classes.Base_Classes.DataProcessing;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.Base_Classes.DataAnalysis;
using HCSAnalyzer.Classes.DataAnalysis;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cViewerTable : cDataDisplay
    {
        cExtendedTable Input = null;
        DataGridView GridView = new DataGridView();
        ContextMenuStrip ColumnContextMenu;

        public int DigitNumber = 2;

        public cViewerTable()
        {
            Title = "Table Viewer";
        }

        public void SetInputData(cExtendedTable MyData)
        {
            this.Input = MyData;
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);
            GridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            GridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;

            ContextMenuStrip GridViewContextMenu = new ContextMenuStrip();

            ToolStripMenuItem ToolStripMenuItem_DisplayHeatMap= new ToolStripMenuItem("Display Heat Map");
            GridViewContextMenu.Items.Add(ToolStripMenuItem_DisplayHeatMap);
            ToolStripMenuItem_DisplayHeatMap.Click += new System.EventHandler(this.DisplayHeatMap);

            ToolStripMenuItem ToolStripMenuItem_Display2DScatterGraph = new ToolStripMenuItem("Display 2D scatter graph");
            GridViewContextMenu.Items.Add(ToolStripMenuItem_Display2DScatterGraph);
            ToolStripMenuItem_Display2DScatterGraph.Click += new System.EventHandler(this.ToolStripMenuItem_Display2DScatterGraph);
            
            GridView.ContextMenuStrip = GridViewContextMenu;

            ToolStripMenuItem ToolStripMenuItem_Operations = new ToolStripMenuItem("Operations");
            GridViewContextMenu.Items.Add(ToolStripMenuItem_Operations);
           
            ToolStripMenuItem ToolStripMenuItem_OperationsAbs = new ToolStripMenuItem("Abs.");
            ToolStripMenuItem_Operations.DropDownItems.Add(ToolStripMenuItem_OperationsAbs);
            ToolStripMenuItem_OperationsAbs.Click += new System.EventHandler(this.ToolStripMenuItem_OperationsAbs);

            ToolStripMenuItem ToolStripMenuItem_OperationsSquare = new ToolStripMenuItem("Square");
            ToolStripMenuItem_Operations.DropDownItems.Add(ToolStripMenuItem_OperationsSquare);
            ToolStripMenuItem_OperationsSquare.Click += new System.EventHandler(this.ToolStripMenuItem_OperationsSquare);

            if (this.Input.Count == this.Input[0].Count)
            {
                ToolStripMenuItem ToolStripMenuItem_OperationsInverse = new ToolStripMenuItem("Inverse");
                ToolStripMenuItem_Operations.DropDownItems.Add(ToolStripMenuItem_OperationsInverse);
                ToolStripMenuItem_OperationsInverse.Click += new System.EventHandler(this.ToolStripMenuItem_OperationsInverse);
            }

            foreach (var Column in Input)
            {
                DataGridViewColumn DC = new DataGridViewColumn(new DataGridViewTextBoxCell());
                DC.CellTemplate = new DataGridViewTextBoxCell();
                DC.DefaultCellStyle.Format = "N"+this.DigitNumber;
                DC.HeaderText = Column.Name;
                DC.SortMode = DataGridViewColumnSortMode.NotSortable;
                DC.Name = Column.Name;
                //DC.Tag
                
                GridView.Columns.Add(DC);
                GridView.Columns[GridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.Title = this.Input.Name;
             
                ContextMenuStrip ColumnContextMenu = new ContextMenuStrip();

                ToolStripMenuItem ToolStripMenuItem_DisplayGraph = new ToolStripMenuItem("Display graph");
                ColumnContextMenu.Items.Add(ToolStripMenuItem_DisplayGraph);
                ToolStripMenuItem_DisplayGraph.Click += new System.EventHandler(this.DisplayGraph);

                ToolStripMenuItem ToolStripMenuItem_DisplayHisto = new ToolStripMenuItem("Display histogram");
                ColumnContextMenu.Items.Add(ToolStripMenuItem_DisplayHisto);
                ToolStripMenuItem_DisplayHisto.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayHisto);

                ToolStripMenuItem ToolStripMenuItem_Statistics = new ToolStripMenuItem("Statistics");
                ColumnContextMenu.Items.Add(ToolStripMenuItem_Statistics);
                ToolStripMenuItem_Statistics.Click += new System.EventHandler(this.ToolStripMenuItem_Statistics);


               // if (GridView.SelectedColumns.Count >= 2)
                {
                    ToolStripMenuItem ToolStripMenuItem_SimilarityMeasures = new ToolStripMenuItem("Similarity measures");

                    ToolStripMenuItem ToolStripMenuItem_ZFactor = new ToolStripMenuItem("Z-Factor");
                    ToolStripMenuItem_SimilarityMeasures.DropDownItems.Add(ToolStripMenuItem_ZFactor);
                    ToolStripMenuItem_ZFactor.Click += new System.EventHandler(this.ToolStripMenuItem_ZFactor);

                    ToolStripMenuItem ToolStripMenuItem_DotProduct = new ToolStripMenuItem("Dot product");
                    ToolStripMenuItem_SimilarityMeasures.DropDownItems.Add(ToolStripMenuItem_DotProduct);
                    ToolStripMenuItem_DotProduct.Click += new System.EventHandler(this.ToolStripMenuItem_DotProduct);

                    ToolStripMenuItem ToolStripMenuItem_DistEuclidean = new ToolStripMenuItem("Euclidean");
                    ToolStripMenuItem_SimilarityMeasures.DropDownItems.Add(ToolStripMenuItem_DistEuclidean);
                    ToolStripMenuItem_DistEuclidean.Click += new System.EventHandler(this.ToolStripMenuItem_DistEuclidean);

                    ColumnContextMenu.Items.Add(ToolStripMenuItem_SimilarityMeasures);


                    ToolStripMenuItem ToolStripMenuItem_CorrelationAnalysis = new ToolStripMenuItem("Correlation analysis");

                    ToolStripMenuItem ToolStripMenuItem_CorrelationMatrix = new ToolStripMenuItem("Correlation matrix");
                    ToolStripMenuItem_CorrelationAnalysis.DropDownItems.Add(ToolStripMenuItem_CorrelationMatrix);
                    ToolStripMenuItem_CorrelationMatrix.Click += new System.EventHandler(this.ToolStripMenuItem_CorrelationMatrix);
                    
                    ToolStripMenuItem ToolStripMenuItem_MINEAnalysis = new ToolStripMenuItem("MINE analysis");
                    ToolStripMenuItem_CorrelationAnalysis.DropDownItems.Add(ToolStripMenuItem_MINEAnalysis);
                    ToolStripMenuItem_MINEAnalysis.Click += new System.EventHandler(this.ToolStripMenuItem_MINEAnalysis);

                    ColumnContextMenu.Items.Add(ToolStripMenuItem_CorrelationAnalysis);
                }

                ToolStripMenuItem ToolStripMenuItem_DataManipulation = new ToolStripMenuItem("Data manipulations");

                ToolStripMenuItem ToolStripMenuItem_AscendingSorting = new ToolStripMenuItem("Ascending sorting");
                ToolStripMenuItem_DataManipulation.DropDownItems.Add(ToolStripMenuItem_AscendingSorting);
                ToolStripMenuItem_AscendingSorting.Click += new System.EventHandler(this.ToolStripMenuItem_AscendingSorting);

                ToolStripMenuItem ToolStripMenuItem_DescendingSorting = new ToolStripMenuItem("Descending sorting");
                ToolStripMenuItem_DataManipulation.DropDownItems.Add(ToolStripMenuItem_DescendingSorting);
                ToolStripMenuItem_DescendingSorting.Click += new System.EventHandler(this.ToolStripMenuItem_DescendingSorting);

                ColumnContextMenu.Items.Add(ToolStripMenuItem_DataManipulation);

                if ((Column.Tag != null) && (Column.Tag.GetType() == typeof(cDescriptorsType)))
                {
                    cDescriptorsType TmpDescType = (cDescriptorsType)Column.Tag;

                    List<ToolStripMenuItem> MenuItemForDesc = TmpDescType.GetExtendedContextMenu();
                    if (MenuItemForDesc != null)
                        foreach (var item in MenuItemForDesc)   ColumnContextMenu.Items.Add(item);
                }

                if ((Column.Tag != null) && (Column.Tag.GetType() == typeof(cDescriptorsLinearCombination)))
                {
                    cDescriptorsLinearCombination TmpDescType = (cDescriptorsLinearCombination)Column.Tag;

                    List<ToolStripMenuItem> MenuItemForDesc = TmpDescType.GetContextMenu();
                    if (MenuItemForDesc != null)
                        foreach (var item in MenuItemForDesc) ColumnContextMenu.Items.Add(item);
                }

                GridView.Columns[GridView.Columns.Count - 1].HeaderCell.ContextMenuStrip = ColumnContextMenu;
            }

            for (int IdxRow = 0; IdxRow < Input[0].Count; IdxRow++)
                GridView.Rows.Add();

            if (Input.ListRowNames.Count > 0)
            {
                for (int IdxRow = 0; IdxRow < Input.ListRowNames.Count; IdxRow++)
                    GridView.Rows[IdxRow].HeaderCell.Value = Input.ListRowNames[IdxRow];
            }
            else if((GridView.Columns.Count==1)&&(Input[0].ListTags!=null))
            {
                for (int IdxRow = 0; IdxRow < Input[0].ListTags.Count; IdxRow++)
                {
                    GridView.Rows[IdxRow].HeaderCell.Value = ((cGeneralComponent)(Input[0].ListTags[IdxRow])).GetShortInfo();
                }
            }


            for (int IdxRow = 0; IdxRow < Input[0].Count; IdxRow++)
            {
                for (int Col = 0; Col < Input.Count; Col++)
                    GridView[Col, IdxRow].Value = Input[Col][IdxRow];
            }
            //CurrentPanel = new cExtendedControl();           

            CurrentPanel.Title = this.Title;

            this.CurrentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            GridView.Width = CurrentPanel.Width;
            GridView.Height = CurrentPanel.Height;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            GridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //    GridView.
            CurrentPanel.Controls.Add(GridView);

            return ToReturn;
        }

        #region Column based operations

        private void DisplayGraph(object sender, EventArgs e)
        {
            cViewerGraph1D VG = new cViewerGraph1D();
            VG.Chart.IsLine = true;
            VG.Chart.IsSelectable = false;
            VG.Chart.IsZoomableX = true;
            VG.Chart.IsLegend = true;

            cExtendedTable CET = new cExtendedTable();
            CET.Name = Input.Name;
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            VG.SetInputData(CET);
            VG.Run();

            cDesignerSinglePanel CD = new cDesignerSinglePanel();
            CD.SetInputData(VG.GetOutPut());
            CD.Run();

            cDisplayToWindow DW = new cDisplayToWindow();
            DW.Title = CET.Name + " - Graph Viewer";
            DW.SetInputData(CD.GetOutPut());
            DW.Run();
            DW.Display();
        }

        private void ToolStripMenuItem_DisplayHisto(object sender, EventArgs e)
        {
         
            cExtendedTable CET = new cExtendedTable();
            CET.Name = Input.Name;
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);


            cViewerHistogram VH = new cViewerHistogram();
            VH.SetInputData(CET);
            VH.Title = "Histogram";
            //CV1.Chart.IsBar = true;
            //CV1.Chart.ISPoint = false;
            // CV1.Chart.IsDisplayValues = true;
            VH.Run();

            cDisplayToWindow DW = new cDisplayToWindow();
            DW.Title = CET.Name + " - Histogram Viewer";
            DW.SetInputData(VH.GetOutPut());
            DW.Run();
            DW.Display();
        }
        
        private void ToolStripMenuItem_CorrelationMatrix(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cDisplayCorrelationMatrix DCM = new cDisplayCorrelationMatrix();
            DCM.Set_Data(CET);
            DCM.SetCorrelationType(DataAnalysis.eCorrelationType.PEARSON);
            DCM.Title = this.Title + " - Pearson correlation matrix";
            DCM.Run();
        }

        private void ToolStripMenuItem_MINEAnalysis(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cMineAnalysis MA = new cMineAnalysis();
            MA.SetInputData(CET);
            MA.Is_BriefReport = true;
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

            cDisplayToWindow DW = new cDisplayToWindow();
            DW.SetInputData(SubDT.GetOutPut());
            DW.Title = CET.Name + " - MINE analysis";
            DW.Run();
            DW.Display();

        }
        
        private void ToolStripMenuItem_AscendingSorting(object sender, EventArgs e)
        {
            if (GridView.SelectedColumns.Count == 0) return;

            cSort S = new cSort();
            S.SetInputData(this.Input);
            S.ColumnIndexForSorting = GridView.SelectedColumns[0].Index;
            S.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(S.GetOutPut());
            CDT.Run();
        
        }

        private void ToolStripMenuItem_DescendingSorting(object sender, EventArgs e)
        {
            if (GridView.SelectedColumns.Count == 0) return;

            cSort S = new cSort();
            S.SetInputData(this.Input);
            S.IsAscending = false;
            S.ColumnIndexForSorting = GridView.SelectedColumns[0].Index;
            S.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(S.GetOutPut());
            CDT.Run();

        }


        private void ToolStripMenuItem_DistEuclidean(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cDistances CD = new cDistances();
            CD.DistanceType = eDistances.EUCLIDEAN;
            CD.SetInputData(CET);
            CD.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(CD.GetOutPut());
            CDT.Run();
        }

        private void ToolStripMenuItem_ZFactor(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cZFactor S = new cZFactor();
            S.SetInputData(CET);
            S.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(S.GetOutPut());
            CDT.Run();
        }      

        private void ToolStripMenuItem_DotProduct(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cDotProduct S = new cDotProduct();
            S.SetInputData(CET);
            S.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(S.GetOutPut());
            CDT.Run();
        }  
        private void ToolStripMenuItem_Statistics(object sender, EventArgs e)
        {
            cExtendedTable CET = new cExtendedTable();
            foreach (DataGridViewColumn item in GridView.SelectedColumns)
                CET.Add(Input[item.Index]);

            cStatistics S = new cStatistics();
            S.IsMin = true;
            S.IsMax = true;
            S.IsSkewness = true;
            S.IsKurtosis = true;
            S.SetInputData(CET);
            S.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(S.GetOutPut());
            CDT.Run();

        }

        #endregion

        #region global table operations

        private void ToolStripMenuItem_OperationsAbs(object sender, EventArgs e)
        {
            cArithmetic_Abs CAA = new cArithmetic_Abs();
            CAA.SetInputData(this.Input);
            CAA.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(CAA.GetOutPut());
            CDT.Run();
        }

        private void ToolStripMenuItem_OperationsSquare(object sender, EventArgs e)
        {
            cArithmetic_Power CAP = new cArithmetic_Power();
            
            CAP.SetInputData(this.Input);
            CAP.Set_Power(2);
            CAP.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(CAP.GetOutPut());
            CDT.Run();
        }

        private void ToolStripMenuItem_OperationsInverse(object sender, EventArgs e)
        {
            cInverse CI = new cInverse();
            CI.SetInputData(this.Input);
            CI.Run();

            cDisplayExtendedTable CDT = new cDisplayExtendedTable();
            CDT.Set_Data(CI.GetOutPut());
            CDT.Run();
        }

        private void ToolStripMenuItem_Display2DScatterGraph(object sender, EventArgs e)
        {
            cViewer2DScatterPoint V2DSG = new cViewer2DScatterPoint();
            V2DSG.SetInputData(this.Input);
            V2DSG.Run();

            cDesignerSinglePanel CD = new cDesignerSinglePanel();
            CD.SetInputData(V2DSG.GetOutPut());
            CD.Run();

            cDisplayToWindow DW = new cDisplayToWindow();
            DW.SetInputData(CD.GetOutPut());
            DW.Run();
            DW.Display();
        }

        private void DisplayHeatMap(object sender, EventArgs e)
        {
            cViewerHeatMap VHM = new cViewerHeatMap();
            VHM.SetInputData(this.Input);
            VHM.Run();

            cDesignerSinglePanel CD = new cDesignerSinglePanel();
            CD.SetInputData(VHM.GetOutPut());
            CD.Run();

            cDisplayToWindow DW = new cDisplayToWindow();
            DW.SetInputData(CD.GetOutPut());
            DW.Run();
            DW.Display();
        }
        #endregion
    }
}
