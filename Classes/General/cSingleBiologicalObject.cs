using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.General
{
    public class cSingleBiologicalObject : cGeneralComponent
    {
        //public int Class = 0;
       // cGlobalInfo GlobalInfo;
        cCellularPhenotype CellularPhenotypeType;
        cWell AssociatedWell;

        public cSingleBiologicalObject(cCellularPhenotype CellularPhenotypeType, cWell AssociatedWell)
        {
         //   this.GlobalInfo = GlobalInfo;
         //   this.Class = Class;
            this.CellularPhenotypeType = CellularPhenotypeType;
            this.AssociatedWell = AssociatedWell;

        }

        public Color GetColor()
        {
            return this.CellularPhenotypeType.ColourForDisplay;

        }

        public cCellularPhenotype GetAssociatedPhenotype()
        {
            return this.CellularPhenotypeType;
        }

        public List<ToolStripMenuItem> GetExtendedContextMenu()
        {
            List<ToolStripMenuItem> ListToReturn = new List<ToolStripMenuItem>();

            List<ToolStripMenuItem> WellMenu  = this.AssociatedWell.GetExtendedContextMenu();

            for (int IdxMenu = 0; IdxMenu < WellMenu.Count; IdxMenu++)
            {
                ListToReturn.Add(WellMenu[IdxMenu]);
            }
            #region Context Menu
            base.SpecificContextMenu = new ToolStripMenuItem(this.CellularPhenotypeType.Name);
            // ToolStripSeparator Sep = new ToolStripSeparator();
            // base.SpecificContextMenu.Items.Add(Sep);


            //ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Test Automated Menu");

            //base.SpecificContextMenu.Items.Add(ToolStripMenuItem_Info);

            ////   contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_Info, ToolStripMenuItem_Histo, ToolStripSep, ToolStripMenuItem_Kegg, ToolStripSep1, ToolStripMenuItem_Copy });

            ////ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            //// contextMenuStrip.Show(Control.MousePosition);
            //ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);


            ToolStripMenuItem ToolStripMenuItem_Info = new ToolStripMenuItem("Info");
            ToolStripMenuItem_Info.Click += new System.EventHandler(this.DisplayInfo);
            SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Info);

            //ToolStripMenuItem ToolStripMenuItem_Histo = new ToolStripMenuItem("Histograms");
            //ToolStripMenuItem_Histo.Click += new System.EventHandler(this.DisplayHisto);
            //SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Histo);

            //if (this.LocusID != -1.0)
            //{
            //    ToolStripMenuItem ToolStripMenuItem_Kegg = new ToolStripMenuItem("Kegg");
            //    ToolStripMenuItem_Kegg.Click += new System.EventHandler(this.DisplayPathways);
            //    SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_Kegg);
            //}

            //if (this.SQLTableName != "")
            //{
            //    ToolStripSeparator ToolStripSep = new ToolStripSeparator();
            //    SpecificContextMenu.DropDownItems.Add(ToolStripSep);

            //    ToolStripMenuItem ToolStripMenuItem_DisplayData = new ToolStripMenuItem("Display Single Object Data");
            //    ToolStripMenuItem_DisplayData.Click += new System.EventHandler(this.ToolStripMenuItem_DisplayData);
            //    SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_DisplayData);

            //    ToolStripMenuItem ToolStripMenuItem_AddToSingleCellAnalysis = new ToolStripMenuItem("Add to Single Object Analysis");
            //    ToolStripMenuItem_AddToSingleCellAnalysis.Click += new System.EventHandler(this.ToolStripMenuItem_AddToSingleCellAnalysis);
            //    SpecificContextMenu.DropDownItems.Add(ToolStripMenuItem_AddToSingleCellAnalysis);
            //}

            //if (this.GetClassIdx() >= 0)
            //    base.SpecificContextMenu.DropDownItems.Add(Parent.GlobalInfo.ListWellClasses[this.GetClassIdx()].GetExtendedContextMenu());

            //ToolStripSeparator ToolStripSep1 = new ToolStripSeparator();
            //ToolStripMenuItem ToolStripMenuItem_Copy = new ToolStripMenuItem("Copy Visu.");

            //ToolStripSeparator SepratorStrip = new ToolStripSeparator();
            //base.SpecificContextMenu.Show(Control.MousePosition);
            //ToolStripMenuItem_Copy.Click += new System.EventHandler(this.CopyVisu);
            #endregion

            ListToReturn.Add(base.SpecificContextMenu);

            return ListToReturn;
        }
        //ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        private void DisplayInfo(object sender, EventArgs e)
        {
           // DisplayInfoWindow(CurrentDescriptorToDisplay);
        }


    
    
    }
}
