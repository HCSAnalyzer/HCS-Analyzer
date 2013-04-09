using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cDesignerSplitter : cDesignerParent
    {
        public Orientation Orientation = Orientation.Horizontal;
        List<cExtendedControl> xListControl = new List<cExtendedControl>();

        public cDesignerSplitter()
        {
            this.Title = "Column Splitter Designer";
        }

        public void SetInputData(cExtendedControl ControlToAdd)
        {
            this.xListControl.Add(ControlToAdd);
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);

            if (xListControl.Count == 0)
            {
                ToReturn.IsSucceed = false;
                ToReturn.Message += ": No input defined!";
                return ToReturn;
            }
            if (xListControl.Count == 1)
            {
                ToReturn.IsSucceed = false;
                ToReturn.Message += ": At least 2 inputs have to be defined for this control!";
                return ToReturn;
            }

            this.OutPut = new cExtendedControl();

            cExtendedControl Tmp1 = this.CreateSplitter(xListControl[0], xListControl[1]);

            for(int IDx=2;IDx<this.xListControl.Count;IDx++)
                Tmp1 = this.CreateSplitter(Tmp1, xListControl[IDx]);

            this.OutPut.Controls.Add(Tmp1);
            return ToReturn;
        }

        cExtendedControl CreateSplitter(cExtendedControl Ctrl1, cExtendedControl Ctrl2)
        {
            SplitContainer SC = new SplitContainer();

            SC.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left
                       | System.Windows.Forms.AnchorStyles.Right);
            SC.BorderStyle = BorderStyle.FixedSingle;
            SC.Orientation = this.Orientation;

            Ctrl1.Width = SC.Panel1.Width;
            
            Ctrl1.Height = SC.Panel1.Height;
            SC.Panel1.Controls.Add(Ctrl1);

            Ctrl2.Width = SC.Panel2.Width;
            Ctrl2.Height = SC.Panel2.Height;
            SC.Panel2.Controls.Add(Ctrl2);

            cExtendedControl ToBeReturned = new cExtendedControl();

            ToBeReturned.Width = SC.Width;
            ToBeReturned.Height = SC.Height;
            ToBeReturned.Controls.Add(SC);
            ToBeReturned.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left
                       | System.Windows.Forms.AnchorStyles.Right);

            //ToBeReturned.Controls.Add(SC);
            return ToBeReturned;
        }
    }
}
