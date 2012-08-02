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
    public partial class FormSingleCellClusteringInfo : Form
    {
        public FormSingleCellClusteringInfo(cGlobalInfo GlobalInfo)
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip();
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.labelDescForClass, "Choose a descriptor that contains the class of the objects.");
           // toolTip1.SetToolTip(this.labelNeutralClass, "Define (if necessary !) a class value that not be taken into account for the learning process.");
            toolTip1.SetToolTip(this.radioButtonAutomated, "The object classes will be evaluated automatically.");
            toolTip1.SetToolTip(this.radioButtonDescriptorBased, "One descriptor represents already the object class.");

            foreach (var item in GlobalInfo.CheckedListBoxForDescActive.Items)
            {
                this.comboBoxDescriptorForClass.Items.Add(item);    
            }
        }

        private void checkBoxEMAutomated_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDownClassNumber.Enabled = !checkBoxEMAutomated.Checked;
        }

        private void radioButtonAutomated_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAutomated.Enabled = true;
            groupBoxDescriptorBased.Enabled = false;
        }

        private void radioButtonDescriptorBased_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAutomated.Enabled = false;
            groupBoxDescriptorBased.Enabled = true;

        }



    }
}
