using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;
using weka.core;

namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    public partial class FormToDisplayTable : Form
    {
        private DataTable dt;
        cGlobalInfo GlobalInfo;

        public FormToDisplayTable(DataTable dt, cGlobalInfo GlobalInfo)
        {
            InitializeComponent();
            this.dt = dt;
            this.dataGridViewForTable.DataSource = dt;
            this.GlobalInfo = GlobalInfo;
        }

        //public FormToDisplayTable()
        //{
        //    InitializeComponent();
           
        //}

        private void ReDraw()
        {
            cExtendedList ListX = new cExtendedList();
            cExtendedList ListY = new cExtendedList();


            if (this.comboBoxAxeY.SelectedIndex == -1) return;
            if (this.comboBoxVolume.SelectedIndex == -1) return;

            cExtendedList ListVolumes = new cExtendedList();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                
                ListX.Add(double.Parse(dt.Rows[j][this.comboBoxAxeX.SelectedIndex].ToString()));
                ListY.Add(double.Parse(dt.Rows[j][this.comboBoxAxeY.SelectedIndex].ToString()));
                ListVolumes.Add(double.Parse(dt.Rows[j][this.comboBoxVolume.SelectedIndex].ToString()));

            }

            this.chartForPoints.ChartAreas[0].AxisX.Title = this.comboBoxAxeX.SelectedItem.ToString();
            this.chartForPoints.ChartAreas[0].AxisY.Title = this.comboBoxAxeY.SelectedItem.ToString();


            this.chartForPoints.Series[0].Points.DataBindXY(ListX, ListY);

            if (!checkBoxIsVolumeConstant.Checked)
            {
                double MaxVolume = ListVolumes.Max();
                double MinVolume = ListVolumes.Min();

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    int MarkerArea = (int)((50 * (ListVolumes[j] - MinVolume)) / (MaxVolume - MinVolume));
                    this.chartForPoints.Series[0].Points[j].MarkerSize = MarkerArea;

                }
            }

        }

        private void comboBoxAxeX_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void comboBoxAxeY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void comboBoxVolume_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void showClassificationTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalInfo.CurrentScreen.CellBasedClassification.J48Model == null) return;
            GlobalInfo.CurrentScreen.CellBasedClassification.DisplayTree(GlobalInfo).Show();
        }

        private void applyClassificationModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
            
            Instances ListInstancesTOClassify = GlobalInfo.CurrentScreen.CellBasedClassification.CreateInstancesWithoutClass(dt);


            FastVector attVals = new FastVector();
            for (int i = 0; i  <  GlobalInfo.CurrentScreen.CellBasedClassification.NumClasses; i++)
                attVals.addElement(i.ToString());

  

            ListInstancesTOClassify.insertAttributeAt(new weka.core.Attribute("Class", attVals), ListInstancesTOClassify.numAttributes());
            ListInstancesTOClassify.setClassIndex(ListInstancesTOClassify.numAttributes() - 1);

            List<int> ListIdx = new List<int>();
            int Max = int.MinValue;
            int Min = int.MaxValue;

            for (int i = 0; i < ListInstancesTOClassify.numInstances(); i++)
            {
                Instance InstToProcess = ListInstancesTOClassify.instance(i);
               int Value =(int)GlobalInfo.CurrentScreen.CellBasedClassification.J48Model.classifyInstance(InstToProcess);
               if (Value > Max) Max = Value;
               if (Value < Min) Min = Value;

               ListIdx.Add(Value);
            }

            byte[][] LUT = GlobalInfo.LUT;
   
                for (int j = 0; j < this.chartForPoints.Series[0].Points.Count; j++)
                {
                    int ConvertedValue = (int)(((ListIdx[j] - Min) * (LUT[0].Length - 1)) / (Max - Min));
                    this.chartForPoints.Series[0].Points[j].MarkerColor = Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);
                }



        }



        private void checkBoxIsVolumeConstant_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxVolume.Enabled = !checkBoxIsVolumeConstant.Checked;
            ReDraw();
        }


    }
}
