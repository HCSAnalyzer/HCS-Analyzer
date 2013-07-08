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
    public partial class FormForSingleSlider : Form
    {
        public FormForSingleSlider(string Title)
        {
            InitializeComponent();
            this.Text = Title;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown.Value = this.trackBar.Value;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar.Value = (int)this.numericUpDown.Value;
        }
    }
}
