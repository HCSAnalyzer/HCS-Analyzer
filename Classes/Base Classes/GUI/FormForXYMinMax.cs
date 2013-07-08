using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.Base_Classes.GUI
{
    public partial class FormForXYMinMax : Form
    {
        public FormForXYMinMax()
        {
            InitializeComponent();
        }

        private void numericUpDownXMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownXMax.Value < numericUpDownXMin.Value) numericUpDownXMax.Value = numericUpDownXMin.Value;
        }

        private void numericUpDownXMax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownXMax.Value < numericUpDownXMin.Value) numericUpDownXMax.Value = numericUpDownXMin.Value;
        }

        private void numericUpDownYMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownYMax.Value < numericUpDownYMin.Value) numericUpDownYMax.Value = numericUpDownYMin.Value;
        }

        private void numericUpDownYMax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownYMax.Value < numericUpDownYMin.Value) numericUpDownYMax.Value = numericUpDownYMin.Value;
        }
    }
}
