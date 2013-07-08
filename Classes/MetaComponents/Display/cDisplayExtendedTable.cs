using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes.Viewers;

namespace HCSAnalyzer.Classes.MetaComponents
{
    class cDisplayExtendedTable : cComponent
    {
        cExtendedTable Input;
    
    
        public cDisplayExtendedTable()
        {
            this.Title = "Display ExtendedDataTable";
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage FeedBackMessage;
            if (this.Input == null)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "No input data defined.";
                return FeedBackMessage;
            }
            Process();
            FeedBackMessage = new cFeedBackMessage(true);
            return FeedBackMessage;
        }

        void Process()
        {
            // here is the core of the meta component ...
            // just a list of Component steps

            cViewerTable MyTable = new cViewerTable();
            MyTable.SetInputData(this.Input);
            MyTable.DigitNumber = 5;
            MyTable.Run();

            cDesignerSinglePanel MyDesigner = new cDesignerSinglePanel();
            MyDesigner.SetInputData(MyTable.GetOutPut());
            MyDesigner.Run();

            cDisplayToWindow MyDisplay = new cDisplayToWindow();
            MyDisplay.SetInputData(MyDesigner.GetOutPut());
            MyDisplay.Title = this.Input.Name;
            MyDisplay.Run();
            MyDisplay.Display();
        }


        public void Set_Data(cExtendedTable Input)
        {
            this.Input = Input;
        }
    }
}

