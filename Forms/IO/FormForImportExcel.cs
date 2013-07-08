using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibPlateAnalysis;

namespace HCSAnalyzer
{
    public partial class FormForImportExcel : Form
    {
        private bool FirstTime = true;
        public bool IsImportCSV =  false;
        public bool IsAppend;

        public cScreening CurrentScreen = null;
        public HCSAnalyzer thisHCSAnalyzer = null;

        public FormForImportExcel()
        {
            InitializeComponent();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewForImport.Rows.Count; i++)
                this.dataGridViewForImport.Rows[i].Cells[1].Value = true;
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewForImport.Rows.Count; i++)
                this.dataGridViewForImport.Rows[i].Cells[1].Value = false;
        }

        private void buttonChangeMode_Click(object sender, EventArgs e)
        {

            bool Mode = this.CurrentScreen.GlobalInfo.OptionsWindow.radioButtonWellPosModeSingle.Checked;
            int SelectedMode = 0;
            if(Mode) SelectedMode = 1;
            

            this.CurrentScreen.GlobalInfo.OptionsWindow.tabControlWindowOption.SelectedTab = this.CurrentScreen.GlobalInfo.OptionsWindow.tabPageImport;
            CurrentScreen.GlobalInfo.OptionsWindow.Visible = true;

            //if(this.CurrentScreen.GlobalInfo.OptionsWindow.radioButtonWellPosModeSingle.Checked)
            //this.dataGridViewForImport

        }

        private void toolStripMenuItem96_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 12;
            this.numericUpDownRows.Value = 8;
        }

        private void toolStripMenuItem384_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 24;
            this.numericUpDownRows.Value = 16;
        }

        private void toolStripMenuItem1536_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 48;
            this.numericUpDownRows.Value = 32;
        }

    }
}
