using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    public partial class FormToDisplayTable : Form
    {
        private DataTable dt;

        public FormToDisplayTable(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            this.dataGridViewForTable.DataSource = dt;
        }

        public FormToDisplayTable()
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
        }

        private void comboBoxAxeX_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void comboBoxAxeY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }


    }
}
