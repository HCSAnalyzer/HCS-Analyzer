using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;
using System.Windows.Forms.DataVisualization.Charting;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    class cWindowToDisplayScatter : SimpleForm
    {


        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chartForSimpleForm.Series[0].Points.Count >= 1)
                RequestWindow.numericUpDownMarkerSize.Value = (decimal)this.chartForSimpleForm.Series[0].Points[0].MarkerSize;


            RequestWindow.numericUpDownMax.Value = (decimal)this.chartForSimpleForm.ChartAreas[0].AxisY.Maximum;
            RequestWindow.numericUpDownMin.Value = (decimal)this.chartForSimpleForm.ChartAreas[0].AxisY.Minimum;

            if (RequestWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            if (RequestWindow.numericUpDownMax.Value <= RequestWindow.numericUpDownMin.Value) return;

            this.chartForSimpleForm.ChartAreas[0].AxisY.Maximum = (double)RequestWindow.numericUpDownMax.Value;
            this.chartForSimpleForm.ChartAreas[0].AxisY.Minimum = (double)RequestWindow.numericUpDownMin.Value;
            foreach (DataPoint Pt in this.chartForSimpleForm.Series[0].Points)
            {
                Pt.MarkerSize = (int)RequestWindow.numericUpDownMarkerSize.Value;

            }
        }


    }
}
