using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;

namespace HCSAnalyzer.Classes.Base_Classes.DataProcessing
{
    class cHistogramBuilder : cComponent
    {
        public cHistogramBuilder()
        {
            this.Title = "Histogram builder";
        }

        cExtendedTable Input;
        cExtendedTable Output;

        public double BinNumber = 100;
        public double Min = double.NaN;
        public double Max = double.NaN;


        public void SetInputData(cExtendedTable InputTable)
        {
            this.Input = InputTable;
        }

        public cExtendedTable GetOutPut()
        {
            return this.Output;
        }
        

        public cFeedBackMessage Run()
        {
            cFeedBackMessage FeedBackMessage = new cFeedBackMessage(true);
            if (this.Input == null)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "No input data.";
                return FeedBackMessage;
            }
            Process();

            return FeedBackMessage;
        }

        void Process()
        {
            this.Output = new cExtendedTable();
            this.Output.Name = "Histogram (" + this.Input.Name + ")";

            List<double[]> Res = null;

            if(double.IsNaN(this.Min)||double.IsNaN(this.Max))
                Res = Input[0].CreateHistogram(this.BinNumber);
            else
                Res = Input[0].CreateHistogram(this.Min,this.Max,(int)this.BinNumber);

            cExtendedList ListX = new cExtendedList("Value");
            cExtendedList ListY = new cExtendedList("Histogram value");

            ListX.AddRange(Res[0]);
            ListY.AddRange(Res[1]);

            this.Output.Add(ListX);
            this.Output.Add(ListY);
        }

    }
}
