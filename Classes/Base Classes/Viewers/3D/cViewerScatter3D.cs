using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Forms;
using System.Windows.Forms;
using HCSAnalyzer.Forms._3D;
using LibPlateAnalysis;
using Kitware.VTK;
using HCSAnalyzer.Classes._3D;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cViewerScatter3D : cDataDisplay
    {
        cGlobalInfo GlobalInfo;

        public cViewerScatter3D(cGlobalInfo GlobalInfo)
        {
            Title = "New Viewer Scatter 3D";
            this.GlobalInfo = GlobalInfo;
        }

        FormFor3DDataDisplay FormToDisplayXYZ;

        public void SetInputData(List<cExtendedList> MyData)
        {
            //FDT = new FormToDisplayDataTable(MyData);
        }

        public void Run()
        {
            FormToDisplayXYZ = new FormFor3DDataDisplay(false, this.GlobalInfo.CurrentScreen);
            for (int i = 0; i < (int)this.GlobalInfo.CurrentScreen.ListDescriptors.Count; i++)
            {
                FormToDisplayXYZ.comboBoxDescriptorX.Items.Add(this.GlobalInfo.CurrentScreen.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorY.Items.Add(this.GlobalInfo.CurrentScreen.ListDescriptors[i].GetName());
                FormToDisplayXYZ.comboBoxDescriptorZ.Items.Add(this.GlobalInfo.CurrentScreen.ListDescriptors[i].GetName());
            }
        }

        public void Display()
        {
            FormToDisplayXYZ.Show();
        }
    }
}
