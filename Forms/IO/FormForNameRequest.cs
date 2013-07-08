using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCSAnalyzer.Forms
{
    public partial class FormForNameRequest : Form
    {
        public FormForNameRequest()
        {
            InitializeComponent();
        }

        private void textBoxForName_TextChanged(object sender, EventArgs e)
        {
            
            char[] searchchar = textBoxForName.Text.ToCharArray();
            string searchstring = textBoxForName.Text;
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().ToUpper().Contains(searchstring.ToUpper()) && searchstring!="")
                {
                  listBox1.SetSelected(i, true);
                }
                else
                {
                    listBox1.SetSelected(i, false);
                }
            }
           

        }
    }
}
