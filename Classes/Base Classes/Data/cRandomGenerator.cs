using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Drawing;

namespace HCSAnalyzer.Classes.Base_Classes.Data
{
    class cRandomGenerator : cDataGenerator
    {
        #region Parameters
        public int List_Number = 1;
        public int Size_List = 100;
        public double Min = 0;
        public double Max = 100;
        #endregion


        Random RND = new Random();
        cGlobalInfo GlobalInfo;
        cExtendedTable ToReturn = null;


        public cRandomGenerator(cGlobalInfo GlobalInfo)
        {
            this.GlobalInfo = GlobalInfo;
        }

        public cExtendedTable GetOutPut()
        {
            return this.ToReturn;
        }

        public void Run()
        {
            ToReturn = new cExtendedTable();
            for (int IdxList = 0; IdxList < this.List_Number; IdxList++)
            {

                cExtendedList CurrentList = new cExtendedList("List" + IdxList, GlobalInfo.ListCellularPhenotypes[IdxList % GlobalInfo.ListCellularPhenotypes.Count].ColourForDisplay);


                for (int IdxValue = 0; IdxValue < this.Size_List; IdxValue++)
                {
                    CurrentList.Add(RND.NextDouble() * (Max - Min) + Min);
                }

                ToReturn.Add(CurrentList);
            }
        }


    }
}
