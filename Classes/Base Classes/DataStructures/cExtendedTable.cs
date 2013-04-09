using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;
using System.Data;
using HCSAnalyzer.Classes.General;

namespace HCSAnalyzer.Classes.Base_Classes.DataStructures
{
    public class cExtendedTable : List<cExtendedList>
    {
        public string Name = "New Table";
        public List<string> ListRowNames = new List<string>();

        public double[,] CopyToArray()
        {
            double[,] ToReturn = new double[this[0].Count, this.Count];
            for (int Row = 0; Row < this[0].Count; Row++)
            {
                for (int Col = 0; Col < this.Count; Col++)
                {
                    ToReturn[Row, Col] = this[Col][Row];
                }
            }
            return ToReturn;
        }

        public weka.core.Matrix CopyToWEKAMatrix()
        {
            weka.core.Matrix MatrixToBeReturned = new weka.core.Matrix(this[0].Count, this.Count);

            for (int Col = 0; Col < this.Count; Col++)
                for (int Row = 0; Row < this[0].Count; Row++)
                    MatrixToBeReturned.addElement(Row, Col, this[Col][Row]);

            return MatrixToBeReturned;
        }

        public cExtendedTable()
        {

        }

        public cExtendedTable(cExtendedTable Source)
        {
            this.Name = Source.Name + "_Copy";
            foreach (var item in Source)
            {
                
                cExtendedList NewCol = new cExtendedList();

                NewCol.Name = item.Name;
                NewCol.AddRange(item);
                this.Add(NewCol);


                if (item.Tag != null)
                {
                    this[0].Tag = new object();
                    this[0].Tag = item.Tag;


                  
                }

                if (item.ListTags != null)
                {
                    this[this.Count - 1].ListTags = new List<object>();
                    this[this.Count - 1].ListTags.AddRange(item.ListTags);
                }
            }

            this.ListRowNames.AddRange(Source.ListRowNames);
        }

        public cExtendedTable(cExtendedList Source)
        {
            this.Name = Source.Name + "_Copy";
            cExtendedList NewCol = new cExtendedList();
            NewCol.Name = Source.Name;
            NewCol.AddRange(Source);
            this.Add(NewCol);

            if (Source.ListTags != null)
            {
                this[0].ListTags = new List<object>();
                this[0].ListTags.AddRange(Source.ListTags);
            }

            //this.ListRowNames.AddRange(Source.ListRowNames);
        }

        public cExtendedTable(double[,] Table)
        {
            int NumRow = Table.GetLength(0);
            int NumCol = Table.GetLength(1);

            for (int Col = 0; Col < NumCol; Col++)
            {
                cExtendedList NewCol = new cExtendedList();
                for (int Row = 0; Row < NumRow; Row++)
                {
                    NewCol.Add(Table[Row, Col]);
                }
                this.Add(NewCol);
            }
        }

        public cExtendedTable(weka.core.Matrix Table)
        {
            int NumRow = Table.numRows();
            int NumCol = Table.numColumns();

            for (int Col = 0; Col < NumCol; Col++)
            {
                cExtendedList NewCol = new cExtendedList();
                for (int Row = 0; Row < NumRow; Row++)
                {
                    NewCol.Add(Table.getElement(Row, Col));
                }
                this.Add(NewCol);
            }
        }

        public cExtendedTable(DataTable Table)
        {
            // int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
            //cExtendedTable ListValueDesc = new cExtendedTable();

            for (int i = 0; i < Table.Columns.Count; i++) this.Add(new cExtendedList());
            for (int i = 0; i < Table.Columns.Count; i++) this[i].Name = Table.Columns[i].ColumnName;

            // loop on all the plate
            for (int RowIdx = 0; RowIdx < Table.Rows.Count; RowIdx++)
            {
                for (int ColIdx = 0; ColIdx < Table.Columns.Count; ColIdx++)
                    this[ColIdx].Add((double)Table.Rows[RowIdx][ColIdx]);
            }
            //return ListValueDesc;
        }

        /// <summary>
        /// Build a table containing the well values
        /// </summary>
        /// <param name="ListWell">List of the wells</param>
        /// <param name="GlobalInfo">Required to take into account the selected descriptors</param>
        public cExtendedTable(List<cWell> ListWell, bool OnlySelectedDescriptors)
        {
            if (ListWell.Count == 0) return;

            foreach (var Desc in ListWell[0].Parent.ListDescriptors)
            {
                if (Desc.IsActive())
                {
                    cExtendedList NewList = new cExtendedList(Desc.GetName());

                    this.Add(NewList);
                    this[this.Count - 1].Tag = Desc;
                }    
            }

            cExtendedList Values;
            int IdxWell =0;
            foreach (cWell CurrentWell in ListWell)
            {
                Values = CurrentWell.GetAverageValuesList(OnlySelectedDescriptors);
                ListRowNames.Add(CurrentWell.Name);

                for (int i = 0; i < Values.Count; i++)
                    this[i].Add(Values[i]);

                IdxWell++;
            }

            // in this specific case, we can add the tags
            for(int i=0;i<this.Count;i++)
            {
                this[i].ListTags = new List<object>();
                    
                for(int j=0;j<ListWell.Count;j++)
                    this[i].ListTags.Add(ListWell[j]);
            }
        }

        public cExtendedList GetRow(int Idx)
        {
            if (Idx >= this[0].Count) return null;

            cExtendedList ToReturn = new cExtendedList();
            for (int i = 0; i < this.Count; i++)
            {
                ToReturn.Add(this[i][Idx]);
            }

            ToReturn.Name = this.Name + "_Row_" + Idx;
            return ToReturn;
        }

        public cExtendedTable(List<cWell> ListWell, int IdxDesc)
        {
            cExtendedList NewList = new cExtendedList(ListWell[0].Parent.ListDescriptors[IdxDesc].GetName());
            this.Add(NewList);
            
            foreach (cWell CurrentWell in ListWell)
            {
                double Value = CurrentWell.ListDescriptors[IdxDesc].GetValue();
                ListRowNames.Add(CurrentWell.Name);

               this[0].Add(Value);
            }

            // in this specific case, we can add the tags
            for (int i = 0; i < this.Count; i++)
            {
                this[i].ListTags = new List<object>();

                for (int j = 0; j < ListWell.Count; j++)
                    this[i].ListTags.Add(ListWell[j]);
            }
        }

        public cExtendedTable(List<cWell> ListWell, int IdxDesc, cExtendedList ListActiveClasses)
        {
            cExtendedList NewList = new cExtendedList(ListWell[0].Parent.ListDescriptors[IdxDesc].GetName());
            this.Add(NewList);

            foreach (cWell CurrentWell in ListWell)
            {
                if ((CurrentWell.GetClassIdx() >= 0)&&(ListActiveClasses[CurrentWell.GetClassIdx()]==1))
                {
                    double Value = CurrentWell.ListDescriptors[IdxDesc].GetValue();
                    ListRowNames.Add(CurrentWell.Name);

                    this[0].Add(Value);
                }
            }

            // in this specific case, we can add the tags
            for (int i = 0; i < this.Count; i++)
            {
                this[i].ListTags = new List<object>();

                for (int j = 0; j < ListWell.Count; j++)
                {
                    if((ListWell[j].GetClassIdx()>=0)&&(ListActiveClasses[ListWell[j].GetClassIdx()]==1))
                     this[i].ListTags.Add(ListWell[j]);
                }
            }
        }


        public double Max()
        {
            cExtendedList ListMaxima = new cExtendedList();

            foreach (var item in this)
                ListMaxima.Add(item.Max());

            return ListMaxima.Max();
        }

        public double Min()
        {
            cExtendedList ListMinima = new cExtendedList();

            foreach (var item in this)
                ListMinima.Add(item.Min());

            return ListMinima.Min();

        }

    }
}
