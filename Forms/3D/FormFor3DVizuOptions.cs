using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCSAnalyzer.Forms._3D
{
    public partial class FormFor3DVizuOptions : Form
    {

        public FormFor3DDataDisplay Parent = null;


        public FormFor3DVizuOptions()
        {
            InitializeComponent();
            
        }

        private void comboBoxDescriptorForScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDownCurrentScale.Value = (decimal)Parent.ListScales[this.comboBoxDescriptorForScale.SelectedIndex];
        }

        private void numericUpDownCurrentScale_ValueChanged(object sender, EventArgs e)
        {
            Parent.ListScales[this.comboBoxDescriptorForScale.SelectedIndex] = (double)this.numericUpDownCurrentScale.Value;
        }

    }
}
