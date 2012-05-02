using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms.IO
{
    public partial class FormForHistogramScreen : Form
    {

        cGlobalInfo GlobalInfo = null;

        public List<FormForVariability> AverageVariabilityWindows = new List<FormForVariability>();
        public List<FormForVariability> StDevVariabilityWindows = new List<FormForVariability>();
        public List<FormForVariability> EventsNumberVariabilityWindows = new List<FormForVariability>();

        public FormForHistogramScreen(cGlobalInfo GlobalInfo)
        {
            this.GlobalInfo = GlobalInfo;
            InitializeComponent(); 
            if (GlobalInfo.CurrentScreen == null) this.checkBoxAddAsDescriptor.Enabled = false;

            FormForVariability WindowAveragePop1 = new FormForVariability();
            AverageVariabilityWindows.Add(WindowAveragePop1);

            FormForVariability WindowAveragePop2 = new FormForVariability();
            AverageVariabilityWindows.Add(WindowAveragePop2);

            FormForVariability WindowStdevPop1 = new FormForVariability();
            StDevVariabilityWindows.Add(WindowStdevPop1);

            FormForVariability WindowStdevPop2 = new FormForVariability();
            StDevVariabilityWindows.Add(WindowStdevPop2);

            FormForVariability WindowEventsPop1 = new FormForVariability();
            EventsNumberVariabilityWindows.Add(WindowEventsPop1);

            FormForVariability WindowEventsPop2 = new FormForVariability();
            EventsNumberVariabilityWindows.Add(WindowEventsPop2);
        }

        private void checkBoxAddAsDescriptor_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxGeneralInfo.Enabled = !checkBoxAddAsDescriptor.Checked;

            if (checkBoxAddAsDescriptor.Checked)
            {
                numericUpDownPlateNumber.Value = GlobalInfo.CurrentScreen.GetNumberOfOriginalPlates();
                numericUpDownColumns.Value = GlobalInfo.CurrentScreen.Columns;
                numericUpDownRows.Value = GlobalInfo.CurrentScreen.Rows;
            }
        }

        private void labelMeanPop1_MouseClick(object sender, MouseEventArgs e)
        {
            int IdxPop = 0;

            double CurrentVariability = (double)AverageVariabilityWindows[IdxPop].numericUpDownVariability.Value;
            bool IsColumnVariable = AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked;
           
            bool IsPositiveCol = AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked;
            bool IsPositiveRow = AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked;

            bool IsRowVariable = AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked;

            AverageVariabilityWindows[IdxPop].Text = "Population "+IdxPop+" - Average";

            if (AverageVariabilityWindows[IdxPop].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                AverageVariabilityWindows[IdxPop].numericUpDownVariability.Value = (decimal)CurrentVariability;
                AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked = IsRowVariable;

                if (IsPositiveCol)
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = true;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = false;
                }
                else
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = false;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = true;
                }
                if (IsPositiveRow)
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = true;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = false;
                }
                else
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = false;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = true;
                }
            }
        }

        private void labelMeanPop2_MouseClick(object sender, MouseEventArgs e)
        {
            int IdxPop = 1;

            double CurrentVariability = (double)AverageVariabilityWindows[IdxPop].numericUpDownVariability.Value;
            bool IsColumnVariable = AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked;

            bool IsPositiveCol = AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked;
            bool IsPositiveRow = AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked;

            bool IsRowVariable = AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked;

            AverageVariabilityWindows[IdxPop].Text = "Population " + IdxPop + " - Average";

            if (AverageVariabilityWindows[IdxPop].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                AverageVariabilityWindows[IdxPop].numericUpDownVariability.Value = (decimal)CurrentVariability;
                AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                AverageVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked = IsRowVariable;

                if (IsPositiveCol)
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = true;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = false;
                }
                else
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = false;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = true;
                }
                if (IsPositiveRow)
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = true;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = false;
                }
                else
                {
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = false;
                    AverageVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = true;
                }
            }

        }

        private void labelStdevPop1_MouseClick(object sender, MouseEventArgs e)
        {
            int IdxPop = 0;

            double CurrentVariability = (double)StDevVariabilityWindows[IdxPop].numericUpDownVariability.Value;
            bool IsColumnVariable = StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked;
            bool IsRowVariable = StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked;

            bool IsPositiveCol = StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked;
            bool IsPositiveRow = StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked;

            StDevVariabilityWindows[IdxPop].Text = "Population " + IdxPop + " - Standard Deviation";

            if (StDevVariabilityWindows[IdxPop].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                StDevVariabilityWindows[IdxPop].numericUpDownVariability.Value = (decimal)CurrentVariability;
                StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked = IsRowVariable;

                if (IsPositiveCol)
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = true;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = false;
                }
                else
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = false;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = true;
                }
                if (IsPositiveRow)
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = true;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = false;
                }
                else
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = false;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = true;
                }

            }
        }

        private void labelStdevPop2_MouseClick(object sender, MouseEventArgs e)
        {
            int IdxPop = 1;

            double CurrentVariability = (double)StDevVariabilityWindows[IdxPop].numericUpDownVariability.Value;
            bool IsColumnVariable = StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked;
            bool IsRowVariable = StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked;

            bool IsPositiveCol = StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked;
            bool IsPositiveRow = StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked;

            StDevVariabilityWindows[IdxPop].Text = "Population " + IdxPop + " - Standard Deviation";

            if (StDevVariabilityWindows[IdxPop].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                StDevVariabilityWindows[IdxPop].numericUpDownVariability.Value = (decimal)CurrentVariability;
                StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                StDevVariabilityWindows[IdxPop].checkBoxVariableAlongTheRows.Checked = IsRowVariable;

                if (IsPositiveCol)
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = true;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = false;
                }
                else
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsPositive.Checked = false;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheColumnsNegative.Checked = true;
                }
                if (IsPositiveRow)
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = true;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = false;
                }
                else
                {
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsPositive.Checked = false;
                    StDevVariabilityWindows[IdxPop].radioButtonVariableAlongTheRowsNegative.Checked = true;
                }

            }
        }

        private void labelEventsPop1_MouseClick(object sender, MouseEventArgs e)
        {

            double CurrentVariability = (double)EventsNumberVariabilityWindows[0].numericUpDownVariability.Value;
            bool IsColumnVariable = EventsNumberVariabilityWindows[0].checkBoxVariableAlongTheColumns.Checked;
            bool IsRowVariable = EventsNumberVariabilityWindows[0].checkBoxVariableAlongTheRows.Checked;

            EventsNumberVariabilityWindows[0].Text = "Population 1 - Number of Events";

            if (EventsNumberVariabilityWindows[0].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                EventsNumberVariabilityWindows[0].numericUpDownVariability.Value = (decimal)CurrentVariability;
                EventsNumberVariabilityWindows[0].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                EventsNumberVariabilityWindows[0].checkBoxVariableAlongTheRows.Checked = IsRowVariable;
            }

        }

        private void labelEventsPop2_MouseClick(object sender, MouseEventArgs e)
        {
            double CurrentVariability = (double)EventsNumberVariabilityWindows[1].numericUpDownVariability.Value;
            bool IsColumnVariable = EventsNumberVariabilityWindows[1].checkBoxVariableAlongTheColumns.Checked;
            bool IsRowVariable = EventsNumberVariabilityWindows[1].checkBoxVariableAlongTheRows.Checked;

            EventsNumberVariabilityWindows[1].Text = "Population 2 - Number of Events";

            if (EventsNumberVariabilityWindows[1].ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                EventsNumberVariabilityWindows[1].numericUpDownVariability.Value = (decimal)CurrentVariability;
                EventsNumberVariabilityWindows[1].checkBoxVariableAlongTheColumns.Checked = IsColumnVariable;
                EventsNumberVariabilityWindows[1].checkBoxVariableAlongTheRows.Checked = IsRowVariable;
            }

        }



    }
}
