using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HCSAnalyzer.Classes._3D;
using HCSAnalyzer.Classes.Base_Classes;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes
{

    /// <summary>
    /// Contains low level information and GUI for component display
    /// </summary>
    public abstract class cComponent
    {
        protected Color CurrentColor;
        public cPoint3D Position;

        public string Title;

    }

    /// <summary>
    /// Data Filtering Component
    /// </summary>
    public abstract class cDataAnalysisComponent : cComponent
    {
        public cDataAnalysisComponent()
        {
            CurrentColor = Color.DarkGreen;
        }
    }

    public abstract class cDataDisplay : cComponent
    {
        protected int Width = 200;
        protected int Height = 100;
        protected cExtendedControl CurrentPanel;
        public ContextMenuStrip CompleteMenu = new ContextMenuStrip();

        public cDataDisplay()
        {
            CurrentColor = Color.DarkRed;
            this.CurrentPanel = new cExtendedControl();
            this.CurrentPanel.Width = Width;
            this.CurrentPanel.Height = Height;

            ToolStripMenuItem ToolStripMenuItem_CopyDataToClipBoard = new ToolStripMenuItem("Copy Data To Clipboard");
            CompleteMenu.Items.Add(ToolStripMenuItem_CopyDataToClipBoard);
            ToolStripMenuItem_CopyDataToClipBoard.Click += new System.EventHandler(this.CopyDataToClipBoard);
            ToolStripSeparator ToolStripSep = new ToolStripSeparator();
            CompleteMenu.Items.Add(ToolStripSep);

           // CurrentPanel.ContextMenuStrip = DisplayContextMenu;
            //CurrentPanel.Controls.Add(ToolStripMenuItem_CopyDataToClipBoard);
        }


        private void CopyDataToClipBoard(object sender, EventArgs e)
        {

        }

        public cExtendedControl GetOutPut()
        {
            return CurrentPanel;
        }

    }

    public abstract class cDataGenerator : cComponent
    {
        public cDataGenerator()
        {
            CurrentColor = Color.DarkBlue;
        }
    }

    



}
