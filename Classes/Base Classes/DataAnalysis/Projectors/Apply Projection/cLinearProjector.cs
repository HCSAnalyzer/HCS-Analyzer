using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using weka.core;

namespace HCSAnalyzer.Classes.Base_Classes.DataAnalysis
{
    class cLinearProjector : cDataAnalysisComponent
    {
        public cLinearProjector()
        {
            this.Title = "Linear Projection";
        }

        cExtendedTable Basis = null;
        cExtendedTable DataToProject = null;
        cExtendedTable ProjectedData = null;
        
        public void Set_Basis(cExtendedTable Basis)
        {
            this.Basis = Basis;
        }

        public void Set_Input(cExtendedTable DataToProject)
        {
            this.DataToProject = DataToProject;
        }

        public cFeedBackMessage Run()
        {
            cFeedBackMessage FeedBackMessage = new cFeedBackMessage(true);

            if (this.Basis == null)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "No Basis defined.";
                return FeedBackMessage;
            }
            if (this.DataToProject == null)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "No input data defined.";
                return FeedBackMessage;
            }
            // ------------- now proceed ------------- 
            Project();

            return FeedBackMessage;
        }

        private void Project()
        {
            Matrix NewPt = new Matrix(this.DataToProject[0].Count, this.DataToProject.Count);
            NewPt = DataToProject.CopyToWEKAMatrix().multiply(this.Basis.CopyToWEKAMatrix());
            ProjectedData = new cExtendedTable(NewPt);

            int Idx=0;
            foreach (var item in DataToProject)
            {
                ProjectedData[Idx].Name = Basis.ListRowNames[Idx];
                Idx++;
            }

            ProjectedData.ListRowNames.AddRange(DataToProject.ListRowNames);
        }

        public cExtendedTable GetOutPut()
        {
            return this.ProjectedData;
        }


    }
}
