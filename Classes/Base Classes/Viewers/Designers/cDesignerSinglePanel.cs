using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cDesignerSinglePanel : cDesignerParent
    {
        public cDesignerSinglePanel()
        {
            this.Title = "Simple Display Designer";
        }

        public void SetInputData(cExtendedControl Input)
        {
            base.OutPut = Input;
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);

            if (base.OutPut == null)
            {
                ToReturn.IsSucceed = false;
                ToReturn.Message += ": No input defined!";
                return ToReturn;
            }
            this.Title = base.OutPut.Title;
            return ToReturn;
        }
    }
}
