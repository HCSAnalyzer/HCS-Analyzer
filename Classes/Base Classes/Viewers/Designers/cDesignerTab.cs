using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cDesignerTab : cDesignerParent
    {
        public cDesignerTab()
        {
            this.Title = "Tab Designer";
        }

        public void SetInputData(cExtendedControl ControlToAdd)
        {
            this.xListControl.Add(ControlToAdd);
        }

        List<cExtendedControl> xListControl = new List<cExtendedControl>();

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);

            if (xListControl.Count == 0)
            {
                ToReturn.IsSucceed = false;
                ToReturn.Message += ": No input defined!";
                return ToReturn;
            }

            //if (xListControl.Count == 1)
            //    this.Title = xListControl[0].Title;

            TabControl TC = new TabControl();

         

            TC.Multiline = true;


            foreach (cExtendedControl item in this.xListControl)
            {
                TabPage TP = new TabPage();
                TP.Text = item.Title;
              //  TP.AutoScroll = true;
              //  TP.Width = item.Width;
              //  TP.Height = item.Height;

             //   item.Controls[0].Width = TP.Width - 50;
             //   item.Controls[0].Height = TP.Height;
                TP.Width = 1000;// TC.Width * 5;
                TP.Height = 500;// TC.Height * 5;

                TP.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
              | System.Windows.Forms.AnchorStyles.Left| System.Windows.Forms.AnchorStyles.Right);


                item.Width = TP.Width;
                item.Height = TP.Height;
                item.Controls[0].Width = item.Width;
                item.Controls[0].Height = item.Height;
             

                TP.Controls.Add(item);
                TC.TabPages.Add(TP);
            }

            TC.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
              | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.OutPut = new cExtendedControl();
            this.OutPut.Controls.Add(TC);
            this.OutPut.Title = this.Title;
            return ToReturn;
        }



    }
}
