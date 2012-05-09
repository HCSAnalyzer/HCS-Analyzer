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

namespace HCSAnalyzer.Forms
{
    public partial class FormFor3DDataDisplay : Form
    {
        FormFor3DVizuOptions WindowFormFor3DVizuOptions = new FormFor3DVizuOptions();
        public cScreening CompleteScreening = null;

        public FormFor3DDataDisplay(bool IsFullScreen, cScreening CompleteScreening)
        {
            this.CompleteScreening = CompleteScreening;
            InitializeComponent();
            this.IsFullScreen = IsFullScreen;
            WindowFormFor3DVizuOptions.Parent = this;

            for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
            {
                ListScales.Add(1);
            }
        }
        c3DWorld CurrentWorld = null;
        private void renderWindowControl1_Load(object sender, EventArgs e)
        {
            DisplayXYZ();
        }


        private bool IsFullScreen;

        double RadiusSphere = 2;

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
                            //  colors.
                            Allpoints.InsertNextPoint(TempX, TempY, TempZ);


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

            //  Plate3D.GenerateAndDisplayBoundingBox(1, Color.White, false, CurrentWorld);
            c3DText CaptionX = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescX].GetName(), new cPoint3D(MaxX, MinY, MinZ), Color.DarkRed, this.FontSize);
            c3DLine LineX = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MaxX, MinY, MinZ), Color.DarkRed);
            CurrentWorld.AddGeometric3DObject(LineX);

            c3DText CaptionY = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescY].GetName(), new cPoint3D(MinX, MaxY, MinZ), Color.DarkGreen, this.FontSize);
            c3DLine LineY = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MinX, MaxY, MinZ), Color.DarkGreen);
            CurrentWorld.AddGeometric3DObject(LineY);

            c3DText CaptionZ = new c3DText(CurrentWorld, CompleteScreening.ListDescriptors[DescZ].GetName(), new cPoint3D(MinX, MinY, MaxZ), Color.DarkBlue, this.FontSize);
            c3DLine LineZ = new c3DLine(new cPoint3D(MinX, MinY, MinZ), new cPoint3D(MinX, MinY, MaxZ), Color.DarkBlue);
            CurrentWorld.AddGeometric3DObject(LineZ);
            CurrentWorld.Render();
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


        double FontSize = 5;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowFormFor3DVizuOptions.numericUpDownRadiusSphere.Value = (decimal)this.RadiusSphere;
            WindowFormFor3DVizuOptions.numericUpDownFontSize.Value = (decimal)this.FontSize;

            if (this.ListScales.Count != 0)
            {
                for (int i = 0; i < (int)CompleteScreening.ListDescriptors.Count; i++)
                {
                    WindowFormFor3DVizuOptions.comboBoxDescriptorForScale.Items.Add(CompleteScreening.ListDescriptors[i].GetName());

                }
            }
            WindowFormFor3DVizuOptions.comboBoxDescriptorForScale.SelectedIndex = 0;



            if (WindowFormFor3DVizuOptions.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.RadiusSphere = (double)WindowFormFor3DVizuOptions.numericUpDownRadiusSphere.Value;
                this.FontSize = (double)WindowFormFor3DVizuOptions.numericUpDownFontSize.Value;
                DisplayXYZ();
            }



        }



    }
}
