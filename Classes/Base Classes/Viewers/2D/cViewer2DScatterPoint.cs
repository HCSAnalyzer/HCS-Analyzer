﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.GUI.FormsForGraphsDisplay.Generic;
using HCSAnalyzer.TMP_ToBeRemoved;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cViewer2DScatterPoint : cDataDisplay
    {     
        public cChart2DScatterPoint Chart = new cChart2DScatterPoint();

        public cViewer2DScatterPoint()
        {
            this.Title = "2D scatter point viewer";
        }

        public void SetInputData(cExtendedTable input)
        {
            Chart.input = input;
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);

            this.CurrentPanel = new cExtendedControl();
            this.CurrentPanel.Title = this.Title;
            this.CurrentPanel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right);

            Chart.Run();

            CurrentPanel.Controls.Add(Chart);
            return ToReturn;
        }
    }
}
