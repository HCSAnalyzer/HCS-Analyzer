

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using HCSAnalyzer.Classes;
using System.Windows.Forms;
using System.Drawing;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    class PanelForClassEditing : System.Windows.Forms.Panel
    {
        List<System.Windows.Forms.TextBox> ListTextBoxes;
        List<System.Windows.Forms.Panel> ListPanelColor;
        cGlobalInfo GlobalInfo;

        public PanelForClassEditing(cGlobalInfo GlobalInfo)
        {
            this.GlobalInfo = GlobalInfo;
            int NumClass = GlobalInfo.GetNumberofDefinedWellClass();
            this.Height = GlobalInfo.OptionsWindow.panelForWellClasses.Height;
            this.AutoScroll = true;
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForClassSelection_MouseDown);
            ListTextBoxes = new List<System.Windows.Forms.TextBox>();
            ListPanelColor = new List<System.Windows.Forms.Panel>();

            for (int IdxClass = 0; IdxClass < NumClass; IdxClass++)
            {
                System.Windows.Forms.Panel PanelForColor = new System.Windows.Forms.Panel();
                PanelForColor.Width = 13;
                PanelForColor.Height = 13;
                PanelForColor.BackColor = GlobalInfo.ListWellClasses[IdxClass].ColourForDisplay;
                PanelForColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                PanelForColor.Location = new System.Drawing.Point(5, PanelForColor.Height * IdxClass-2);
                PanelForColor.Tag = IdxClass;
                PanelForColor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseDoubleClick);
                ListPanelColor.Add(PanelForColor);
                 
                System.Windows.Forms.TextBox CurrentTextBox = new System.Windows.Forms.TextBox();
                CurrentTextBox.Text = "Class " + IdxClass;
                CurrentTextBox.Location = new System.Drawing.Point(PanelForColor.Width+15, (CurrentTextBox.Height+5) * IdxClass);
                CurrentTextBox.TextChanged += new EventHandler(CurrentTextBox_TextChanged);
                CurrentTextBox.Tag = IdxClass;
                ListTextBoxes.Add(CurrentTextBox);

                PanelForColor.Location = new System.Drawing.Point(5, CurrentTextBox.Location.Y+5);
               
            }
            this.Controls.AddRange(ListPanelColor.ToArray());
            this.Controls.AddRange(ListTextBoxes.ToArray());
        }

        void CurrentTextBox_TextChanged(object sender, EventArgs e)
        {
            int Idx = (int)(((System.Windows.Forms.TextBox)sender).Tag);
            GlobalInfo.ListWellClasses[Idx].Name = ((System.Windows.Forms.TextBox)sender).Text;
        }

        void MouseDoubleClick(object sender, EventArgs e)
        {
            int Idx = (int)(((System.Windows.Forms.Panel)sender).Tag);
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Color backgroundColor = colorDialog.Color;
            ListPanelColor[Idx].BackColor = backgroundColor;

            GlobalInfo.ListWellClasses[Idx].ColourForDisplay = backgroundColor;
        }


    }
}
