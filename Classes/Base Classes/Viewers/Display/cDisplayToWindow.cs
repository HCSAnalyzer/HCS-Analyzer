using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cDisplayToWindow : cComponent
    {
        FormForDisplay WindowToDisplay;
        public bool IsModal = false;
        cExtendedControl ControlToDisplay = null;

        public cDisplayToWindow()
        {
            ControlToDisplay = new cExtendedControl();
        }

        public void SetInputData(cExtendedControl Input)
        {
            this.ControlToDisplay = Input;
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);
            WindowToDisplay = new FormForDisplay();

            if ((ControlToDisplay == null)||(ControlToDisplay.Controls.Count==0))
            {
                ToReturn.IsSucceed = false;
                ToReturn.Message += ": No input defined!";
                return ToReturn;
            }
            else
            {
                //this.Title = ControlToDisplay.Title;

                ControlToDisplay.Width = WindowToDisplay.Width - 34;
                ControlToDisplay.Height = WindowToDisplay.Height - 50;

                ControlToDisplay.Controls[0].Width = WindowToDisplay.Width - 34;
                ControlToDisplay.Controls[0].Height = WindowToDisplay.Height - 50;

                ControlToDisplay.Location = new System.Drawing.Point(5, 5);

                ControlToDisplay.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                 | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            }
            WindowToDisplay.Controls.Add(ControlToDisplay);
            WindowToDisplay.Text = base.Title;
            return ToReturn;
        }

        public void Display()
        {


            if (IsModal)
                WindowToDisplay.ShowDialog();
            else
                WindowToDisplay.Show();
        }
    }
}
