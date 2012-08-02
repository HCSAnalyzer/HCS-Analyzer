using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms
{
    public partial class FormForHistogramMode : Form
    {

        cGlobalInfo GlobalInfo;

        public FormForHistogramMode(cGlobalInfo GlobalInfo)
        {
            InitializeComponent();
            this.GlobalInfo = GlobalInfo;
        }

        private void comboBoxOriginalClass_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > 0)
            {
                SolidBrush BrushForColor = new SolidBrush(GlobalInfo.GetColor(e.Index - 1));
                e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            }
            e.Graphics.DrawString(comboBoxOriginalClass.Items[e.Index].ToString(), comboBoxOriginalClass.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void buttonMetric_Click(object sender, EventArgs e)
        {
            this.GlobalInfo.OptionsWindow.tabControlWindowOption.SelectedTab = this.GlobalInfo.OptionsWindow.tabPageHisto;
            GlobalInfo.OptionsWindow.Visible = true;
        }
    }
}
