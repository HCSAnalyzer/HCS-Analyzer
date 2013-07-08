using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;
using System.Windows.Forms;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer.Classes.Base_Classes.Viewers;

namespace HCSAnalyzer.Classes.General
{
    public class cListWell : List<cWell>
    {
        cGlobalInfo GlobalInfo;
        int NewClass;
        public object Sender;

        public cListWell(object Sender)
        {
            this.Sender = Sender;
        }

        public cWell GetWell(int PosX, int PosY)
        {
            return null;
        }

        public cWell GetWell(int Idx)
        {
            if (Idx < 0) return null;
            if (this.Count == 0) return null;
            // if (Idx > this.Count) return null;
            return this[Idx];
        }

        public void SetNewClass(int IdxClass)
        {
            foreach (var item in this)
                item.SetClass(IdxClass);
        }

        void ToolStripMenuItem_GetTable(object sender, EventArgs e)
        {
            cExtendedTable DT = GetDescriptorValuesFull();
            cDisplayExtendedTable DET = new cDisplayExtendedTable();
            DET.Set_Data(DT);
            DET.Run();
        }

        public cExtendedTable GetDescriptorValuesFull()
        {
            cExtendedTable ToBeReturned = new cExtendedTable();
            ToBeReturned.Name = this.Count + " wells associated data table";
            ToBeReturned.ListRowNames = new List<string>();
            this.GlobalInfo = this[0].Parent.GlobalInfo;

            foreach (var item in this[0].Parent.ListDescriptors)
            {
                if(item.IsActive())
                {
                    ToBeReturned.Add(new cExtendedList(item.GetName()));
                    ToBeReturned[ToBeReturned.Count-1].Tag = item;
                    ToBeReturned[ToBeReturned.Count - 1].ListTags = new List<object>();
                }
            }
            ToBeReturned.Add(new cExtendedList("Class"));
            ToBeReturned[ToBeReturned.Count - 1].ListTags = new List<object>();

            foreach (var item in this)
            {
                cExtendedList CEL =  item.GetAverageValuesList(true);
                int IdxDesc=0;
                foreach (var Desc in CEL)
                {
                    ToBeReturned[IdxDesc].Add(CEL[IdxDesc]);
                    ToBeReturned[IdxDesc++].ListTags.Add(item);
                }
                ToBeReturned[ToBeReturned.Count-1].Add(item.GetClassIdx());
                ToBeReturned[ToBeReturned.Count - 1].ListTags.Add(item);
                ToBeReturned.ListRowNames.Add(item.GetShortInfo());
            }
            return ToBeReturned;
        }

        public cExtendedTable GetDescriptorValues(int IDxDesc, bool IsClassesSplitted)
        {
            if (this.Count == 0) return null;
            if (IDxDesc >= this[0].ListDescriptors.Count) return null;

            cExtendedTable ToBeReturned = new cExtendedTable();
            this.GlobalInfo = this[0].Parent.GlobalInfo;

            if (IsClassesSplitted)
            {
                foreach (var item in GlobalInfo.ListWellClasses)
                {
                    ToBeReturned.Add(new cExtendedList(item.Name));
                    ToBeReturned[ToBeReturned.Count - 1].Tag = item;
                    ToBeReturned[ToBeReturned.Count - 1].ListTags = new List<object>();
                }

                foreach (cWell TmpWell in this)
                {
                    ToBeReturned[TmpWell.GetClassIdx()].Add(TmpWell.ListDescriptors[IDxDesc].GetValue());
                    ToBeReturned[TmpWell.GetClassIdx()].ListTags.Add(TmpWell);
                }
            }
            else
            {

            }



            return ToBeReturned;
        }

        #region Context Menu
        public ToolStripMenuItem GetContextMenu()
        {

            if (this.Count == 0) return null;

            ToolStripMenuItem SpecificContextMenu = new ToolStripMenuItem("List " + this.Count + " wells");
            // ToolStripSeparator Sep = new ToolStripSeparator();
            // base.SpecificContextMenu.Items.Add(Sep);


            //ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Test Automated Menu");

            //base.SpecificContextMenu.Items.Add(ToolStripMenuItem_Info);

            ////   contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_Info, ToolStripMenuItem_Histo, ToolStripSep, ToolStripMenuItem_Kegg, ToolStripSep1, ToolStripMenuItem_Copy });

            ////ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            //// contextMenuStrip.Show(Control.MousePosition);
            //ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);


            ToolStripMenuItem ToolStripMenuItem_ChangeClass = new ToolStripMenuItem("Classes");
            //ToolStripMenuItem_CopyClassToClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyClassToClipBoard);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_ChangeClass);


            for (int i = 0; i < this[0].Parent.GlobalInfo.ListWellClasses.Count; i++)
            {
                ToolStripMenuItem ToolStripMenuItem_NewClass = new ToolStripMenuItem(this[0].Parent.GlobalInfo.ListWellClasses[i].Name);
                ToolStripMenuItem_NewClass.Click += new System.EventHandler(this.ToolStripMenuItem_NewClass);
                ToolStripMenuItem_NewClass.Tag = i;// this[0].Parent.GlobalInfo.ListWellClasses[i];
                ToolStripMenuItem_ChangeClass.DropDownItems.Add(ToolStripMenuItem_NewClass);
            }

            ToolStripMenuItem ToolStripMenuItem_GetTable = new ToolStripMenuItem("Get associated data table");
            ToolStripMenuItem_GetTable.Click += new System.EventHandler(this.ToolStripMenuItem_GetTable);
            // ToolStripMenuItem_NewClass.Tag = i;// this[0].Parent.GlobalInfo.ListWellClasses[i];
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_GetTable);


            //ToolStripMenuItem ToolStripMenuItem_CopyValuestoClipBoard = new ToolStripMenuItem("Copy values to clipboard");
            //ToolStripMenuItem_CopyValuestoClipBoard.Click += new System.EventHandler(this.ToolStripMenuItem_CopyValuestoClipBoard);
            //base.SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_CopyValuestoClipBoard);

            return SpecificContextMenu;

        }

        private void ToolStripMenuItem_NewClass(object sender, EventArgs e)
        {
            //CopyValuestoClipBoard();
            foreach (var item in this)
            {
                int Classe = 0;
                int ResultClasse = -1;
                foreach (var Class in item.Parent.GlobalInfo.ListWellClasses)
                {
                    if (Class.Name == sender.ToString())
                    {
                        ResultClasse = Classe;
                        break;
                    }

                    Classe++;
                }

                item.SetClass(ResultClasse);
            }


            if ((this.Sender!=null)&&(this.Sender.GetType() == typeof(cChart2DScatterPoint)))
            {
                ((cChart2DScatterPoint)(this.Sender)).RefreshDisplay();
            }

        }
        #endregion

    }
}
