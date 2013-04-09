using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms.FormsForImages
{
    public partial class UserControlSingleLUT : UserControl
    {
        FormForImageDisplay CurrentFormForImageDisplay = null;

        public byte[][] SelectedLUT { get; private set; }

        cGlobalInfo GlobalInfo;

        public UserControlSingleLUT(FormForImageDisplay CurrentFormForImageDisplay)
        {
            this.CurrentFormForImageDisplay = CurrentFormForImageDisplay;
            this.GlobalInfo = CurrentFormForImageDisplay.GlobalInfo;
            this.SelectedLUT = new cLUT().LUT_GREEN_TO_RED;
            InitializeComponent();
        }

        private void numericUpDownMinValue_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMinValue.Value > numericUpDownMaxValue.Value) numericUpDownMinValue.Value = numericUpDownMaxValue.Value;
            CurrentFormForImageDisplay.DrawPic();
        }

        private void numericUpDownMaxValue_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMaxValue.Value < numericUpDownMinValue.Value) numericUpDownMaxValue.Value = numericUpDownMinValue.Value;
            CurrentFormForImageDisplay.DrawPic();
        }

        private void comboBoxForLUT_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxForLUT.SelectedIndex)
            {
                case 0:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_LINEAR;
                    break;
                case 1:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_HSV;
                    break;
                case 2:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_FIRE;
                    break;
                case 3:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_GREEN_TO_RED;
                    break;
                case 4:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_JET;
                    break;
                case 5:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_HOT;
                    break;
                case 6:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_COOL;
                    break;
                case 7:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_SPRING;
                    break;
                case 8:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_SUMMER;
                    break;
                case 9:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_AUTOMN;
                    break;
                case 10:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_WINTER;
                    break;
                case 11:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_BONE;
                    break;
                case 12:
                    this.SelectedLUT = CurrentFormForImageDisplay.GlobalInfo.LUTs.LUT_COPPER;
                    break;

            }

            CurrentFormForImageDisplay.DrawPic();
        }

        private void checkBoxIsActive_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFormForImageDisplay.DrawPic();
        }
    }
}
