using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibPlateAnalysis;

namespace HCSAnalyzer.Forms
{
    public partial class FormForPCAAxisGeneration : Form
    {
        
        cScreening CurrentScreening;
        public cExtendPlateList PlatesToProcess;
        public bool IsPCA;

        public FormForPCAAxisGeneration(cScreening CurrentScreening)
        {
            InitializeComponent();
            this.CurrentScreening = CurrentScreening;
        }

        private void comboBoxForNeutralClass_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            SolidBrush BrushForColor = new SolidBrush(CurrentScreening.GlobalInfo.GetColor(e.Index));
            e.Graphics.FillRectangle(BrushForColor, e.Bounds.X + 1, e.Bounds.Y + 1, 10, 10);
            e.Graphics.DrawString(comboBoxForNeutralClass.Items[e.Index].ToString(), comboBoxForNeutralClass.Font,
                System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void buttonClassification_Click(object sender, EventArgs e)
        {
            int NeutralClass = comboBoxForNeutralClass.SelectedIndex;
            string Result;
            if(IsPCA)
                Result = CurrentScreening.GlobalInfo.WindowHCSAnalyzer.GeneratePCADescriptor(PlatesToProcess, (int)numericUpDownNumberOfAxis.Value, NeutralClass);
            else
                Result = CurrentScreening.GlobalInfo.WindowHCSAnalyzer.GenerateLDADescriptor(PlatesToProcess, NeutralClass);

         
            this.Close();
        }


    }
}
