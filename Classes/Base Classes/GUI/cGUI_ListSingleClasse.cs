using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using System.Windows.Forms;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;

namespace HCSAnalyzer.Classes.Base_Classes.GUI
{
    public class cGUI_ListSingleClasse : cComponentGUI
    {

        public cGUI_ListSingleClasse()
        {
            this.Title = "GUI - Classes selection";
        }


        cExtendedList ListSelectedClass = null;

        public cExtendedList GetOutPut()
        {
            return this.ListSelectedClass;
        }

        public bool IsCheckBoxes = true;
        public eClassType ClassType = eClassType.WELL;

        public cFeedBackMessage Run(cGlobalInfo GlobalInfo)
        {
            FormForDisplay WindowToDisplay = new FormForDisplay();
            WindowToDisplay.Text = "Class Selection";
            WindowToDisplay.FormBorderStyle = FormBorderStyle.FixedSingle;

            PanelForClassSelection ClassSelectionPanel = new PanelForClassSelection(GlobalInfo, this.IsCheckBoxes, this.ClassType);
            //ClassSelectionPanel.Height = WindowToDisplay.Height;
            ClassSelectionPanel.UnSelectAll();
            ClassSelectionPanel.Select(0);
            ClassSelectionPanel.Select(1);
            ClassSelectionPanel.Location = new System.Drawing.Point(10, 10);
            ClassSelectionPanel.Width = 150;
            ClassSelectionPanel.Height = ClassSelectionPanel.ListCheckBoxes.Count * 25;
            ClassSelectionPanel.BorderStyle = BorderStyle.Fixed3D;
            // MyPanel.Controls.Add(ClassSelectionPanel);

            Button ReturnButton = new Button();
            ReturnButton.Text = "Ok";
            ReturnButton.DialogResult = DialogResult.OK;
            ReturnButton.Location = new System.Drawing.Point(ClassSelectionPanel.Location.X, ClassSelectionPanel.Location.Y + ClassSelectionPanel.Height + 5);
            WindowToDisplay.Controls.Add(ReturnButton);

            WindowToDisplay.Controls.Add(ClassSelectionPanel);
            WindowToDisplay.Width = ClassSelectionPanel.Width + 28;
            WindowToDisplay.Height = ClassSelectionPanel.Height + ReturnButton.Height + 48;

            cFeedBackMessage FeedBackMessage = new cFeedBackMessage(true);

            if (WindowToDisplay.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "Selection aborded !";
                return FeedBackMessage;
            }

            List<bool> ListBool = ClassSelectionPanel.GetListSelectedClass();

            int NumSelected = 0;
            this.ListSelectedClass = new cExtendedList();
            foreach (var item in ListBool)
            {
                if (item)
                {
                    this.ListSelectedClass.Add(1);
                    NumSelected++;
                }
                else
                    this.ListSelectedClass.Add(0);
            }

            if (NumSelected == 0)
            {
                FeedBackMessage = new cFeedBackMessage(false);
                FeedBackMessage.Message = "No class selected !";
                return FeedBackMessage;
            }


            return FeedBackMessage;

        }
    }
}
