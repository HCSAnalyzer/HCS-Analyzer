using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.GUI.FormsForGraphsDisplay.Generic;
using HCSAnalyzer.TMP_ToBeRemoved;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cViewerStackedHistogram : cDataDisplay
    {     
        //cPanelHisto CurrentPanelHisto;
        //public eOrientation Orientation = eOrientation.HORIZONTAL;

        public cChart1DStackedHistogram Chart = new cChart1DStackedHistogram();


        public cViewerStackedHistogram()
        {
            this.Title = "Stacked Histogram Viewer";
        }

        public void SetInputData(cExtendedTable input)
        {
            //CurrentPanelHisto = new cPanelHisto(ListValues, true, eGraphType.LINE, this.Orientation);
          // Chart = new cChart1DGraph();  
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

            //CurrentPanelHisto.WindowForPanelHisto.panelForGraphContainer.Width = CurrentPanel.Width-50;
            //CurrentPanelHisto.WindowForPanelHisto.panelForGraphContainer.Height = CurrentPanel.Height-5;
            Chart.Run();

            CurrentPanel.Controls.Add(Chart);
            return ToReturn;
        }






    }
}
