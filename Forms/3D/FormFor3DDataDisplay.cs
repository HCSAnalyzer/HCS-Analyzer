using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kitware.VTK;
using HCSAnalyzer.Classes._3D;
using LibPlateAnalysis;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using HCSAnalyzer.Forms._3D;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms
{
    public partial class FormFor3DDataDisplay : Form
    {
        FormFor3DVizuOptions WindowFormFor3DVizuOptions = new FormFor3DVizuOptions();
        public cScreening CompleteScreening = null;

        vtkOrientationMarkerWidget widget;
        double RadiusSphere = 0.01;

        private bool IsFullScreen;
        c3DWorld CurrentWorld = null;
        vtkAxesActor axes;
        double FontSize = 5;

        public FormFor3DDataDisplay(bool IsFullScreen, cScreening CompleteScreening)
        {
            this.CompleteScreening = CompleteScreening;
            InitializeComponent();
            this.IsFullScreen = IsFullScreen;
          //  WindowFormFor3DVizuOptions.Parent = this;

            for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            {
                ListScales.Add(1);
            }
        }

        private void renderWindowControl1_Load(object sender, EventArgs e)
        {
            DisplayXYZ();
        }




        public List<double> ListScales = new List<double>();


        public void DisplayXYZ()
        {
            if (CompleteScreening == null) return;

            int DescX = this.comboBoxDescriptorX.SelectedIndex;
            int DescY = this.comboBoxDescriptorY.SelectedIndex;
            int DescZ = this.comboBoxDescriptorZ.SelectedIndex;

            if (DescX < 0) DescX = 0;
            if (DescY < 0) DescY = 0;
            if (DescZ < 0) DescZ = 0;

            int[] Pos = new int[2];
            Pos[0] = 0;
            Pos[1] = 0;

            if (CurrentWorld == null)
            {
                CurrentWorld = new c3DWorld(new cPoint3D(1000, 1000, 1000), new cPoint3D(ListScales[DescX], ListScales[DescY], ListScales[DescZ]), this.renderWindowControl1, Pos, CompleteScreening);
            }

            CurrentWorld.SetBackgroundColor(Color.Black);
            CurrentWorld.ren1.RemoveAllViewProps();

            //  if (widget != null) widget.SetEnabled(0);



            Series CurrentSeries = new Series("ScatterPoints");

            double MinX = double.MaxValue;
            double MinY = double.MaxValue;
            double MinZ = double.MaxValue;
            double MaxZ = double.MinValue;
            double MaxX = double.MinValue;
            double MaxY = double.MinValue;

            double TempX, TempY, TempZ;
            int Idx = 0;

            cExtendPlateList ListPlate = new cExtendPlateList();

            cMetaBiologicalObjectList ListMeta = new cMetaBiologicalObjectList("Test");
            cBiologicalSpot CurrentSpot1 = new cBiologicalSpot(Color.White, new cPoint3D(0, 0, 0), 1, 4);
            cMetaBiologicalObject Plate3D = new cMetaBiologicalObject("Data", ListMeta, CurrentSpot1);

            if (!IsFullScreen)
                ListPlate.Add(CompleteScreening.GetCurrentDisplayPlate());
            else
                ListPlate = CompleteScreening.ListPlatesActive;

            vtkUnsignedCharArray colors = vtkUnsignedCharArray.New();
            colors.SetName("colors");
            colors.SetNumberOfComponents(3);
            vtkPoints Allpoints = vtkPoints.New();

            cExtendedList ListPtX = new cExtendedList();
            cExtendedList ListPtY = new cExtendedList();
            cExtendedList ListPtZ = new cExtendedList();

            for (int i = 0; i < ListPlate.Count; i++)
            {
                cPlate CurrentPlate = ListPlate[i];
                for (int IdxValue = 0; IdxValue < CompleteScreening.Columns; IdxValue++)
                    for (int IdxValue0 = 0; IdxValue0 < CompleteScreening.Rows; IdxValue0++)
                    {
                        cWell TmpWell = CurrentPlate.GetWell(IdxValue, IdxValue0, true);
                        if (TmpWell != null)
                        {

                            TempX = TmpWell.ListDescriptors[DescX].GetValue();
                            if (TempX < MinX) MinX = TempX;
                            if (TempX > MaxX) MaxX = TempX;


                            TempY = TmpWell.ListDescriptors[DescY].GetValue();
                            if (TempY < MinY) MinY = TempY;
                            if (TempY > MaxY) MaxY = TempY;

                            TempZ = TmpWell.ListDescriptors[DescZ].GetValue();
                            if (TempZ < MinZ) MinZ = TempZ;
                            if (TempZ > MaxZ) MaxZ = TempZ;

                            //   cBiologicalSpot CurrentSpot = new cBiologicalSpot(TmpWell.GetColor(), new cPoint3D(TempX, TempY, TempZ), 1, 4);

                            List<char> Col = new List<char>();

                            Col.Add((char)(TmpWell.GetColor().R));
                            Col.Add((char)(TmpWell.GetColor().G));
                            Col.Add((char)(TmpWell.GetColor().B));

                            // IntPtr unmanagedPointer = Marshal.UnsafeAddrOfPinnedArrayElement(Col.ToArray(), 0);

                            //colors.InsertNextTupleValue(unmanagedPointer);
                            colors.InsertNextTuple3(Col[0], Col[1], Col[2]);

                            ListPtX.Add(TempX);
                            ListPtY.Add(TempY);
                            ListPtZ.Add(TempZ);




                            //     CurrentSpot.Name = TmpWell.AssociatedPlate.Name + " - " + TmpWell.GetPosX() + "x" + TmpWell.GetPosY() + " :" + TmpWell.Name;
                            //    CurrentSpot.ObjectType = TmpWell.AssociatedPlate.Name + " - " + TmpWell.GetPosX() + "x" + TmpWell.GetPosY() + " :" + TmpWell.Name;
                            //    Plate3D.AddObject(CurrentSpot);
                            // CurrentWorld.AddBiological3DObject(CurrentSpot);
                            //CurrentSeries.Points.Add(TempX, TempY);

                            //                                if (IsFullScreen)
                            //                                    CurrentSeries.Points[Idx].ToolTip = TmpWell.AssociatedPlate.Name + "\n" + TmpWell.GetPosX() + "x" + TmpWell.GetPosY() + " :" + TmpWell.Name;
                            //                                else
                            //                                    CurrentSeries.Points[Idx].ToolTip = TmpWell.GetPosX() + "x" + TmpWell.GetPosY() + " :" + TmpWell.Name;

                            Idx++;
                        }
                    }
            }


            double MinValueX = ListPtX.Min();
            double MaxValueX = ListPtX.Max();
            cExtendedList NormX = ListPtX.Normalize(MinValueX, MaxValueX);

            double MinValueY = ListPtY.Min();
            double MaxValueY = ListPtY.Max();
            cExtendedList NormY = ListPtY.Normalize(MinValueY, MaxValueY);

            double MinValueZ = ListPtZ.Min();
            double MaxValueZ = ListPtZ.Max();
            cExtendedList NormZ = ListPtZ.Normalize(MinValueZ, MaxValueZ);


            for (int IdxPt = 0; IdxPt < ListPtX.Count; IdxPt++)
                Allpoints.InsertNextPoint(NormX[IdxPt], NormY[IdxPt], NormZ[IdxPt]);


            vtkPolyData polydata = vtkPolyData.New();
            polydata.SetPoints(Allpoints);
            polydata.GetPointData().SetScalars(colors);
            vtkSphereSource SphereSource = vtkSphereSource.New();
            SphereSource.SetRadius(RadiusSphere);
            vtkGlyph3D glyph3D = vtkGlyph3D.New();
            glyph3D.SetColorModeToColorByScalar();
            glyph3D.SetSourceConnection(SphereSource.GetOutputPort());

            glyph3D.SetInput(polydata);
            glyph3D.ScalingOff();
            glyph3D.Update();


            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(glyph3D.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            CurrentWorld.ren1.AddActor(actor);

            if ((CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions != null) && (CompleteScreening.GlobalInfo.OptionsWindow.checkBoxConnectDRCPts.Checked))
            {
                foreach (cDRC_Region TmpRegion in CompleteScreening.GetCurrentDisplayPlate().ListDRCRegions)
                {
                    int cpt = 0;

                    cWell[][] ListWells = TmpRegion.GetListWells();

                    foreach (cWell[] item in ListWells)
                    {
                        for (int IdxWell = 0; IdxWell < item.Length - 1; IdxWell++)
                        {
                            //cWell TmpWell0 = CompleteScreening.GetCurrentDisplayPlate().GetWell(item[IdxWell], IdxValue0, true);



                            if ((item[IdxWell] != null) && (item[IdxWell + 1] != null) && (item[IdxWell].GetClass() >= -1))
                            {

                                double StartX = (item[IdxWell].ListDescriptors[DescX].GetValue() - MinValueX) / (MaxValueX - MinValueX);
                                double StartY = (item[IdxWell].ListDescriptors[DescY].GetValue() - MinValueY) / (MaxValueY - MinValueY);
                                double StartZ = (item[IdxWell].ListDescriptors[DescZ].GetValue() - MinValueZ) / (MaxValueZ - MinValueZ);
                                double EndX = (item[IdxWell + 1].ListDescriptors[DescX].GetValue() - MinValueX) / (MaxValueX - MinValueX);
                                double EndY = (item[IdxWell + 1].ListDescriptors[DescY].GetValue() - MinValueY) / (MaxValueY - MinValueY);
                                double EndZ = (item[IdxWell + 1].ListDescriptors[DescZ].GetValue() - MinValueZ) / (MaxValueZ - MinValueZ);



                                cPoint3D StartPt = new cPoint3D(StartX, StartY, StartZ);
                                cPoint3D EndPt = new cPoint3D(EndX, EndY, EndZ);


                                c3DLine NewLine = new c3DLine(StartPt, EndPt);

                                CurrentWorld.AddGeometric3DObject(NewLine);
                            }

                        }
                    }
                    /*List<cDRC> ListDRC = new List<cDRC>();
                    for (int i = 0; i < CompleteScreening.ListDescriptors.Count; i++)
                    {
                        if (CompleteScreening.ListDescriptors[i].IsActive())
                        {
                            cDRC CurrentDRC = new cDRC(TmpRegion, CompleteScreening.ListDescriptors[i]);

                            ListDRC.Add(CurrentDRC);
                            cpt++;
                        }

                    }
                    */
                    //cDRCDisplay DRCDisplay = new cDRCDisplay(ListDRC, GlobalInfo);

                    //if (DRCDisplay.CurrentChart.Series.Count == 0) continue;

                    //DRCDisplay.CurrentChart.Location = new Point((DRCDisplay.CurrentChart.Width + 50) * 0, (DRCDisplay.CurrentChart.Height + 10 + DRCDisplay.CurrentRichTextBox.Height) * h++);
                    //DRCDisplay.CurrentRichTextBox.Location = new Point(DRCDisplay.CurrentChart.Location.X, DRCDisplay.CurrentChart.Location.Y + DRCDisplay.CurrentChart.Height + 5);

                    //WindowforDRCsDisplay.LChart.Add(DRCDisplay.CurrentChart);
                    //WindowforDRCsDisplay.LRichTextBox.Add(DRCDisplay.CurrentRichTextBox);
                }
            }

            // vtkAxesActor axis = vtkAxesActor.New();
            vtkAxisActor axisX = vtkAxisActor.New();
            axisX.SetPoint1(0, 0, 0);
            axisX.SetPoint2(1, 0, 0);
            axisX.SetTickLocationToBoth();
            axisX.SetDeltaMajor(0.1);
            axisX.SetMajorTickSize(0);
            axisX.MinorTicksVisibleOff();
            //axisX.Maj
            CurrentWorld.ren1.AddActor(axisX);


            vtkAxisActor axisY = vtkAxisActor.New();
            axisY.SetPoint1(0, 0, 0);
            axisY.SetPoint2(0, 1, 0);
            axisY.SetTickLocationToBoth();
            axisY.SetDeltaMajor(0.1);
            axisY.SetMajorTickSize(0.05);
            axisY.MinorTicksVisibleOff();
            CurrentWorld.ren1.AddActor(axisY);

            vtkAxisActor axisZ = vtkAxisActor.New();
            axisZ.SetPoint1(0, 0, 0);
            axisZ.SetPoint2(0, 0, 1);
            axisZ.SetTickLocationToBoth();
            axisZ.SetDeltaMajor(0.1);
            axisZ.SetMajorTickSize(0.05);
            axisZ.MinorTicksVisibleOff();
            CurrentWorld.ren1.AddActor(axisZ);


            
            if (widget == null)
            {
                widget = vtkOrientationMarkerWidget.New();

               axes = vtkAxesActor.New();
                widget.SetOutlineColor(0.9300, 0.5700, 0.1300);

                widget.SetInteractor(CurrentWorld.iren);
                widget.SetViewport(0.0, 0.0, 0.4, 0.4);
                 widget.SetEnabled(0);
              //  widget.InteractiveOn();
                
                if (this.comboBoxDescriptorX.SelectedItem == null)
                    axes.SetXAxisLabelText(this.comboBoxDescriptorX.Items[0].ToString());
                else
                axes.SetXAxisLabelText(this.comboBoxDescriptorX.SelectedItem.ToString());

                if (this.comboBoxDescriptorY.SelectedItem == null)
                    axes.SetYAxisLabelText(this.comboBoxDescriptorY.Items[0].ToString());
                else
                    axes.SetYAxisLabelText(this.comboBoxDescriptorY.SelectedItem.ToString());

                if (this.comboBoxDescriptorZ.SelectedItem == null)
                    axes.SetZAxisLabelText(this.comboBoxDescriptorZ.Items[0].ToString());
                else
                    axes.SetZAxisLabelText(this.comboBoxDescriptorZ.SelectedItem.ToString());

                widget.SetOrientationMarker(axes);


            }
            else
            {
                if(this.comboBoxDescriptorX.SelectedItem!=null)
                axes.SetXAxisLabelText(this.comboBoxDescriptorX.SelectedItem.ToString());

                if (this.comboBoxDescriptorY.SelectedItem != null)
                axes.SetYAxisLabelText(this.comboBoxDescriptorY.SelectedItem.ToString());

                if (this.comboBoxDescriptorZ.SelectedItem != null)
                axes.SetZAxisLabelText(this.comboBoxDescriptorZ.SelectedItem.ToString());

                widget.SetOrientationMarker(axes);

            }
            //    



            //vtkCameraWidget Wid = vtkCameraWidget.New();
            //Wid.SetInteractor(CurrentWorld.iren);
            //Wid.SetEnabled(1);
            //  Wid.InteractiveOn();

            //vtkDistanceWidget distanceWidget = vtkDistanceWidget.New();
            //distanceWidget.SetInteractor(CurrentWorld.iren);
            //distanceWidget.SetEnabled(1);
            //distanceWidget.CreateDefaultRepresentation();
            //((vtkDistanceRepresentation)distanceWidget.GetRepresentation()).SetLabelFormat("%-#6.3g mm");
            /*static_cast<vtkDistanceRepresentation*>(distanceWidget->GetRepresentation())
              ->SetLabelFormat("%-#6.3g mm");

                      */
            //  Plate3D.GenerateAndDisplayBoundingBox(1, Color.White, false, CurrentWorld);
            //c3DText CaptionX = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescX].GetName(), new cPoint3D(MaxX, MinY, MinZ), Color.DarkRed, this.FontSize);
            //c3DLine LineX = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MaxX, MinY, MinZ), Color.DarkRed);
            //CurrentWorld.AddGeometric3DObject(LineX);

            //c3DText CaptionY = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescY].GetName(), new cPoint3D(MinX, MaxY, MinZ), Color.DarkGreen, this.FontSize);
            //c3DLine LineY = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MinX, MaxY, MinZ), Color.DarkGreen);
            //CurrentWorld.AddGeometric3DObject(LineY);

            //c3DText CaptionZ = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescZ].GetName(), new cPoint3D(MinX, MinY, MaxZ), Color.DarkBlue, this.FontSize);
            //c3DLine LineZ = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MinX, MinY, MaxZ), Color.DarkBlue);
            //CurrentWorld.AddGeometric3DObject(LineZ);
            CurrentWorld.SimpleRender();// Render();
        }

        private void comboBoxDescriptorZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayXYZ();
        }

        private void comboBoxDescriptorX_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayXYZ();
        }

        private void comboBoxDescriptorY_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayXYZ();
        }




        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowFormFor3DVizuOptions.numericUpDownRadiusSphere.Value = (decimal)(this.RadiusSphere*100.0);
            WindowFormFor3DVizuOptions.numericUpDownFontSize.Value = (decimal)this.FontSize;

            if (WindowFormFor3DVizuOptions.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.RadiusSphere = (double)WindowFormFor3DVizuOptions.numericUpDownRadiusSphere.Value/100.0;
                this.FontSize = (double)WindowFormFor3DVizuOptions.numericUpDownFontSize.Value;
                DisplayXYZ();
            }



        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayXYZ();
        }

        private void axisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axisToolStripMenuItem.Checked)
                widget.SetEnabled(1);
            else
                widget.SetEnabled(0);
        }



    }
}
