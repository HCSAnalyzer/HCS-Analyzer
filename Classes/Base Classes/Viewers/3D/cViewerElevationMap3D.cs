using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.MetaComponents;
using Kitware.VTK;
using System.Windows.Forms;
using System.Drawing;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers
{
    class cViewerElevationMap3D : cDataDisplay
    {
        public cViewerElevationMap3D()
        {
            base.Title = "3D Elevation Map Viewer";
        }

        cExtendedTable Input;

        #region public Parameters
        public Color BackGroundColor = Color.White;
        #endregion

        public void SetInputData(cExtendedTable InputTable)
        {
            base.Title += ": " + InputTable.Name;
            this.Input = InputTable;
        }
        RenderWindowControl renderWindowControl1;
        public cFeedBackMessage Run()
        {
            cFeedBackMessage ToReturn = new cFeedBackMessage(true);

            //CurrentLUT = LUT.LUT_JET;
            //  Kitware.VTK.RenderWindowControl VTKView = GenerateGraph();
            renderWindowControl1 = new RenderWindowControl();
            renderWindowControl1.Load += new EventHandler(renderWindowControl1_Load);

            renderWindowControl1.Width = base.CurrentPanel.Width;
            renderWindowControl1.Height = base.CurrentPanel.Height;

            base.CurrentPanel.Title = this.Title;
            base.CurrentPanel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right);


            renderWindowControl1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right);

            ContextMenuStrip HeatMapContextMenu = new ContextMenuStrip();
            ToolStripMenuItem ToolStripMenuItem_DisplayTable = new ToolStripMenuItem("Display Table");
            HeatMapContextMenu.Items.Add(ToolStripMenuItem_DisplayTable);
            ToolStripMenuItem_DisplayTable.Click += new System.EventHandler(this.DisplayTable);
            CurrentPanel.ContextMenuStrip = HeatMapContextMenu;

            CurrentPanel.Controls.Add(renderWindowControl1);

            return ToReturn;
        }

        private void DisplayTable(object sender, EventArgs e)
        {
            cDisplayExtendedTable CDET = new cDisplayExtendedTable();
            CDET.Set_Data(this.Input);
            CDET.Run();

        }

        private void renderWindowControl1_Load(object sender, EventArgs e)
        {
            try
            {
                GenerateGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
            }
        }


        private void GenerateGraph()
        {
            // get a reference to the renderwindow of our renderWindowControl1
            vtkRenderWindow RenderWindow = renderWindowControl1.RenderWindow;
            // get a reference to the renderer
            vtkRenderer Renderer = RenderWindow.GetRenderers().GetFirstRenderer();
            vtkPoints points = vtkPoints.New();


            double MaxZ = this.Input.Max();
            double MinZ = this.Input.Min();


            for (int IdxY = 0; IdxY < this.Input.Count; IdxY++)
                for (int IdxX = 0; IdxX < this.Input[IdxY].Count; IdxX++)
                {
                    points.InsertNextPoint(IdxY, IdxX, ((this.Input[IdxY][IdxX]-MinZ)/(MaxZ-MinZ)*this.Input.Count)/2);
                }

            double[] bounds = points.GetBounds();

            // Add the grid points to a polydata object
            vtkPolyData inputPolyData = vtkPolyData.New();
            inputPolyData.SetPoints(points);

            // Triangulate the grid points
            vtkDelaunay2D delaunay = vtkDelaunay2D.New();
            delaunay.SetInput(inputPolyData);
            delaunay.Update();

            vtkElevationFilter elevationFilter = vtkElevationFilter.New();
            elevationFilter.SetInputConnection(delaunay.GetOutputPort());
            elevationFilter.SetLowPoint(0.0, 0.0, bounds[4]);
            elevationFilter.SetHighPoint(0.0, 0.0, bounds[5]);
            elevationFilter.Update();

            vtkPolyData output = vtkPolyData.New();
            output.ShallowCopy(vtkPolyData.SafeDownCast(elevationFilter.GetOutput()));

            // Create the color map
            vtkLookupTable colorLookupTable = vtkLookupTable.New();
            colorLookupTable.SetTableRange(bounds[4], bounds[5]);
            colorLookupTable.Build();

            // Generate the colors for each point based on the color map
            //vtkUnsignedCharArray colors = vtkUnsignedCharArray.New();
            //colors.SetNumberOfComponents(3);
            //colors.SetName("Colors");
            //output.GetPointData().AddArray(colors);

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();

            mapper.SetInput(output);
            vtkActor NewActor = vtkActor.New();
            NewActor.SetMapper(mapper);
            Renderer.AddActor(NewActor);

            // set background color
            Renderer.SetBackground(BackGroundColor.R / 255.0, BackGroundColor.G / 255.0, BackGroundColor.B / 255.0);

            // ensure all actors are visible (in this example not necessarely needed,
            // but in case more than one actor needs to be shown it might be a good idea)
            Renderer.ResetCamera();
        }
    }
}
