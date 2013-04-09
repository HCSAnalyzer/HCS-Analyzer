using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using LibPlateAnalysis;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using System.Windows.Forms.DataVisualization.Charting;

namespace HCSAnalyzer.Classes.General
{
    public class cWellClass : cGeneralComponent
    {
        public Color ColourForDisplay;
        public string Name;
        cGlobalInfo GlobalInfo;
        int IdxClass = -1;

        public cWellClass(Color Colour, string Name, cGlobalInfo GlobalInfo)
        {
            this.ColourForDisplay = Colour;
            this.Name = Name;
            this.GlobalInfo = GlobalInfo;

            
          

        }

        public ToolStripMenuItem GetExtendedContextMenu()
        {

            #region Context Menu
            base.SpecificContextMenu = new ToolStripMenuItem(this.Name);
           
            
            ToolStripMenuItem ToolStripMenuItem_DisplayDescriptorEvolution = new ToolStripMenuItem("Descriptor evolution");
            ToolStripMenuItem_DisplayDescriptorEvolution.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayDescriptorEvolution);
            base.SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayDescriptorEvolution);

            ToolStripMenuItem ToolStripMenuItem_DisplayDataTable = new ToolStripMenuItem("Display data table");
            ToolStripMenuItem_DisplayDataTable.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayDataTable);
            base.SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayDataTable);

            ToolStripMenuItem ToolStripMenuItem_DisplayHistograms = new ToolStripMenuItem("Display histograms");
            ToolStripMenuItem_DisplayHistograms.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayHistograms);
            base.SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayHistograms);


            
            ToolStripSeparator ToolStripSep = new ToolStripSeparator();
            base.SpecificContextMenu.DropDownItems.Add(ToolStripSep);


            ToolStripMenuItem ToolStripMenuItem_SetAsActivePlate = new ToolStripMenuItem("Set as active");
            ToolStripMenuItem_SetAsActivePlate.Click += new System.EventHandler(this.ToolStripMenuItem_SetAsActivePlate);
            base.SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_SetAsActivePlate);

            #endregion

            return base.SpecificContextMenu;


        }

        private void ToolStripMenuItem_SetAsActivePlate(object sender, EventArgs e)
        {
            int PosPlate = GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.FindStringExact(this.Name);
            this.GlobalInfo.WindowHCSAnalyzer.comboBoxClass.Text = this.Name;
        }

        private void ToolStripMenuItem_DisplayDescriptorEvolution(object sender, EventArgs e)
        {
            //int PosPlate = GlobalInfo.WindowHCSAnalyzer.toolStripcomboBoxPlateList.FindStringExact(this.Name);
            //this.GlobalInfo.WindowHCSAnalyzer.comboBoxClass.Text = this.Name;
        }

        private void ToolStripMenuItem_DisplayHistograms(object sender, EventArgs e)
        {
            if (GlobalInfo == null) return;
            for (int i = 0; i < GlobalInfo.ListWellClasses.Count; i++)
            {
                if (GlobalInfo.ListWellClasses[i].Name == this.Name)
                {
                    IdxClass = i;
                    break;
                }
            }
           
            if (IdxClass == -1) return;

            if ((GlobalInfo.CurrentScreen.ListDescriptors == null) || (GlobalInfo.CurrentScreen.ListDescriptors.Count == 0)) return;

            cDisplayToWindow CDW1 = new cDisplayToWindow();

            cListWell ListWellsToProcess = new cListWell(null);
            List<cPlate> PlateList = new List<cPlate>();
            cDesignerSplitter DS = new cDesignerSplitter();

            foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesActive) PlateList.Add(TmpPlate);

            foreach (cPlate TmpPlate in PlateList)
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if (item.GetClassIdx() == IdxClass) ListWellsToProcess.Add(item);

            cExtendedTable NewTable2 = ListWellsToProcess.GetDescriptorValues(GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx, true);
            NewTable2.Name = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Histogram - " + PlateList.Count + " plates";

            cViewerStackedHistogram CV2 = new cViewerStackedHistogram();
            CV2.SetInputData(NewTable2);
            CV2.Chart.LabelAxisX = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            CV2.Chart.IsBorder = false;
            CV2.Chart.Width = 0;
            CV2.Chart.Height = 0;

            //StripLine AverageLine = new StripLine();
            //AverageLine.BackColor = Color.Red;
            //AverageLine.IntervalOffset = GlobalInfo.CurrentScreen.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue();
            //AverageLine.StripWidth = 0.0001;
            //AverageLine.Text = this.ListDescriptors[Parent.ListDescriptors.CurrentSelectedDescriptor].GetValue().ToString("N2");

            CV2.Run();

            //CV2.Chart.ChartAreas[0].AxisX.StripLines.Add(AverageLine);

            DS.SetInputData(CV2.GetOutPut());


            PlateList.Clear();
            PlateList.Add(GlobalInfo.CurrentScreen.GetCurrentDisplayPlate());
            ListWellsToProcess.Clear();
            foreach (cPlate TmpPlate in PlateList)
                foreach (cWell item in TmpPlate.ListActiveWells)
                    if (item.GetClassIdx() == IdxClass) ListWellsToProcess.Add(item);

            CDW1.Title = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName() + " - Histogram (" + PlateList[0].Name + ")";

            cExtendedTable NewTable = ListWellsToProcess.GetDescriptorValues(GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx, true);
            NewTable.Name = CDW1.Title;

            cViewerStackedHistogram CV1 = new cViewerStackedHistogram();
            CV1.SetInputData(NewTable);
            CV1.Chart.LabelAxisX = GlobalInfo.CurrentScreen.ListDescriptors[GlobalInfo.CurrentScreen.ListDescriptors.CurrentSelectedDescriptorIdx].GetName();
            CV1.Chart.Width = 0;
            CV1.Chart.Height = 0;

            //  CV1.Chart.ChartAreas[0].AxisX.Minimum = CV2.Chart.ChartAreas[0].AxisX.Minimum;
            //  CV1.Chart.ChartAreas[0].AxisX.Maximum = CV2.Chart.ChartAreas[0].AxisX.Maximum;
            CV1.Run();

           // CV1.Chart.ChartAreas[0].AxisX.StripLines.Add(AverageLine);
            DS.SetInputData(CV1.GetOutPut());
            DS.Run();

            CDW1.SetInputData(DS.GetOutPut());
            CDW1.Run();
            CDW1.Display();

            return;
        }


        private void ToolStripMenuItem_DisplayDataTable(object sender, EventArgs e)
        {
            if (GlobalInfo == null) return;
            List<cWell> ListWellsToProcess = new List<cWell>();

            for (int i = 0; i < GlobalInfo.ListWellClasses.Count; i++)
            {
                if (GlobalInfo.ListWellClasses[i].Name == this.Name)
                {
                    IdxClass = i;
                    break;
                }
            }
           
            if (IdxClass == -1) return;

            foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesActive)
                foreach (cWell item in TmpPlate.ListActiveWells)
                   if (item.GetClassIdx() ==IdxClass) ListWellsToProcess.Add(item);

            cExtendedTable DataFromPlate = new cExtendedTable(ListWellsToProcess, true);
            DataFromPlate.Name = this.Name + " : " + ListWellsToProcess.Count + " wells";
            DataFromPlate.ListRowNames.Clear();

            foreach (var item in ListWellsToProcess)
            {
                DataFromPlate.ListRowNames.Add(item.GetShortInfo());
            }

            cDisplayExtendedTable DEXT = new cDisplayExtendedTable();
            DEXT.Set_Data(DataFromPlate);
            DEXT.Run();


        }

    }

}
