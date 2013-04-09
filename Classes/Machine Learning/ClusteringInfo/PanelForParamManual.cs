using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCSAnalyzer.Classes.Machine_Learning.ClusteringInfo
{
    public partial class PanelForParamManual : UserControl
    {
        public PanelForParamManual(List<string> ListDescritpors)
        {
            InitializeComponent();

            foreach (var item in ListDescritpors)
            {
                comboBoxForDescriptorManualClustering.Items.Add(item);
            }



        }
    }
}
