using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using HCSAnalyzer.Classes;
using System.Windows.Forms;
using HCSAnalyzer.Classes.Base_Classes.GUI;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    class PanelForClassSelection : System.Windows.Forms.Panel
    {
        public List<System.Windows.Forms.CheckBox> ListCheckBoxes;
        public List<System.Windows.Forms.RadioButton> ListRadioButtons;



        public PanelForClassSelection(cGlobalInfo GlobalInfo, bool IsCheckBoxes, eClassType ClassType)
        {
            int NumClass = GlobalInfo.GetNumberofDefinedWellClass();
            if (ClassType == eClassType.PHENOTYPE)
                NumClass = GlobalInfo.GetNumberofDefinedCellularPhenotypes();

            this.AutoScroll = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForClassSelection_MouseDown);


             if (IsCheckBoxes)
                    ListCheckBoxes = new List<System.Windows.Forms.CheckBox>();
                else
                    ListRadioButtons = new List<System.Windows.Forms.RadioButton>();

                for (int IdxClass = 0; IdxClass < NumClass; IdxClass++)
                {
                    System.Windows.Forms.Panel PanelForColor = new System.Windows.Forms.Panel();
                    PanelForColor.Width = 13;
                    PanelForColor.Height = 13;
                    if (ClassType == eClassType.WELL)
                        PanelForColor.BackColor = GlobalInfo.ListWellClasses[IdxClass].ColourForDisplay;
                    else if (ClassType == eClassType.PHENOTYPE)
                        PanelForColor.BackColor = GlobalInfo.ListCellularPhenotypes[IdxClass].ColourForDisplay;

                    PanelForColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    PanelForColor.Location = new System.Drawing.Point(5, PanelForColor.Height * IdxClass);
                    PanelForColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForClassSelection_MouseDown);

                    if (IsCheckBoxes)
                    {
                        System.Windows.Forms.CheckBox CurrentCheckBox = new System.Windows.Forms.CheckBox();
                        if (ClassType == eClassType.WELL)
                            CurrentCheckBox.Text = GlobalInfo.ListWellClasses[IdxClass].Name;
                        else if (ClassType == eClassType.PHENOTYPE)
                            CurrentCheckBox.Text = GlobalInfo.ListCellularPhenotypes[IdxClass].Name;

                        CurrentCheckBox.Location = new System.Drawing.Point(PanelForColor.Width + 15, CurrentCheckBox.Height * IdxClass);
                        CurrentCheckBox.Checked = true;
                        CurrentCheckBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForClassSelection_MouseDown);
                        ListCheckBoxes.Add(CurrentCheckBox);
                        PanelForColor.Location = new System.Drawing.Point(5, CurrentCheckBox.Location.Y + 5);
                    }
                    else
                    {
                        System.Windows.Forms.RadioButton CurrentRadioButton = new System.Windows.Forms.RadioButton();
                        CurrentRadioButton.Text = GlobalInfo.ListWellClasses[IdxClass].Name;
                        CurrentRadioButton.Location = new System.Drawing.Point(PanelForColor.Width + 15, CurrentRadioButton.Height * IdxClass);
                        CurrentRadioButton.Checked = false;
                        CurrentRadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForClassSelection_MouseDown);
                        ListRadioButtons.Add(CurrentRadioButton);
                        PanelForColor.Location = new System.Drawing.Point(5, CurrentRadioButton.Location.Y + 5);
                    }
                    this.Controls.Add(PanelForColor);
                }

                if (IsCheckBoxes)
                    this.Controls.AddRange(ListCheckBoxes.ToArray());
                else
                    this.Controls.AddRange(ListRadioButtons.ToArray());

        }


        private void PanelForClassSelection_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button != System.Windows.Forms.MouseButtons.Right)||(this.ListRadioButtons!=null)) return;

            ContextMenuStrip contextMenuStripPicker = new ContextMenuStrip();

            ToolStripMenuItem SelectItem = new ToolStripMenuItem("Select all");
            SelectItem.Click += new System.EventHandler(this.SelectItem);
            contextMenuStripPicker.Items.Add(SelectItem);

            ToolStripMenuItem UnselectItem = new ToolStripMenuItem("Unselect all");
            UnselectItem.Click += new System.EventHandler(this.UnselectItem);
            contextMenuStripPicker.Items.Add(UnselectItem);

            contextMenuStripPicker.Show(System.Windows.Forms.Control.MousePosition);
            //ToolStripMenuItem SelectAllItem = new ToolStripMenuItem("Select all");
            //SelectAllItem.Click += new System.EventHandler(this.SelectAllItem);
            //contextMenuStripActorPicker.Items.Add(SelectAllItem);
        }

        public List<int> GetListIndexSelectedClass()
        {
            List<int> SelectedClass = new List<int>();
            int Idx = 0;
            foreach (var item in this.ListCheckBoxes)
            {
                if (item.Checked)
                    SelectedClass.Add(Idx);
                Idx++;
            }
            return SelectedClass;
        }

        public List<bool> GetListSelectedClass()
        {
            List<bool> SelectedClass = new List<bool>();

            if (this.ListCheckBoxes != null)
            {
                foreach (var item in this.ListCheckBoxes)
                {
                    if (item.Checked)
                        SelectedClass.Add(true);
                    else
                        SelectedClass.Add(false);
                }
            }
            else
            {
           foreach (var item in this.ListRadioButtons)
                {
                    if (item.Checked)
                        SelectedClass.Add(true);
                    else
                        SelectedClass.Add(false);
                }  
            
            }
            return SelectedClass;
        }

        public void UnSelectAll()
        {
            if (this.ListCheckBoxes != null)
            {

                foreach (var item in this.ListCheckBoxes)
                    item.Checked = false;
            }
        }

        public void SelectAll()
        {
            foreach (var item in this.ListCheckBoxes)
                item.Checked = true;
        }

        public void Select(int SelectedIdx)
        {
            int Idx = 0;

            if (this.ListCheckBoxes != null)
            {
                foreach (var item in this.ListCheckBoxes)
                {
                    if (Idx == SelectedIdx)
                    {
                        item.Checked = true;
                        return;
                    }
                    Idx++;
                }
            }
            else
            {
                foreach (var item in this.ListRadioButtons)
                {
                    if (Idx == SelectedIdx)
                    {
                        item.Checked = true;
                        return;
                    }
                    Idx++;
                }
            
            }
        }

        void UnselectItem(object sender, EventArgs e)
        {
            UnSelectAll();
        }

        void SelectItem(object sender, EventArgs e)
        {
            foreach (var item in this.ListCheckBoxes)
                item.Checked = true;
        }

    }
}
