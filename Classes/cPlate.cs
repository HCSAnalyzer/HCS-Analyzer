using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using HCSAnalyzer;
using HCSAnalyzer.Classes;
using weka.core;
using System.Windows.Threading;
using HCSAnalyzer.Classes._3D;
using System.Data.SQLite;
using System.Data;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using HCSAnalyzer.Controls;

namespace LibPlateAnalysis
{
    public class cExtendWellList : List<cWell>
    {
        public cWell GetWell(int PosX, int PosY)
        {
            return null;
        }

        public cWell GetWell(int Idx)
        {
            if (Idx < 0) return null;
            if (this.Count == 0) return null;
            // if (Idx > this.Count) return null;
            return this[Idx];
        }
    }


    public class cDBConnection
    {
        private SQLiteConnection _SQLiteConnection;
        public string SQLFileDBName = "";
        // cPlate AssociatedPlate;

        private void DB_EstablishConnection()
        {
            this._SQLiteConnection = new SQLiteConnection("Data Source=" + SQLFileDBName);
            this._SQLiteConnection.Open();
        }

        public void DB_CloseConnection()
        {
            this._SQLiteConnection.Close();
        }

        public List<string> GetListTableNames()
        {

            List<string> Toreturn = new List<string>();
            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            mycommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name";
            SQLiteDataReader value = mycommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(value);

            for (int i = 0; i < dt.Rows.Count; i++)
                Toreturn.Add(dt.Rows[i][0].ToString());

            return Toreturn;

        }

        public void DisplayTable(cWell Well)
        {
            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            mycommand.CommandText = "SELECT * FROM \"" + Well.SQLTableName + "\"";
            SQLiteDataReader value = mycommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(value);
            FormToDisplayTable WindowForTable = new FormToDisplayTable(dt, Well.AssociatedPlate.ParentScreening.GlobalInfo);
            WindowForTable.comboBoxAxeX.DataSource = this.GetDescriptorNames(Well);
            WindowForTable.comboBoxAxeY.DataSource = this.GetDescriptorNames(Well);
            WindowForTable.comboBoxVolume.DataSource = this.GetDescriptorNames(Well);
            WindowForTable.chartForPoints.Series[0].MarkerColor = Well.GetColor();

            // WindowForTable.ch
            WindowForTable.Text = Well.AssociatedPlate.Name + " [" + Well.GetPosX() + "x" + Well.GetPosY() + "]";

            WindowForTable.Show();
        }

        public void AddWellToDataTable(cWell Well, DataTable DataTableToAddedTo, bool IsAddWellClass, bool IsOnlyActiveDesc)
        {
            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            List<string> Names = new List<string>();
            string NameDesc = "*";
            if (IsOnlyActiveDesc)
            {
                NameDesc = "";
                for (int IdxDesc = 0; IdxDesc < Well.ListDescriptors.Count; IdxDesc++)
                    if (Well.ListDescriptors[IdxDesc].GetAssociatedType().IsActive())
                    {
                        NameDesc += Well.ListDescriptors[IdxDesc].GetAssociatedType().GetName() + ", ";
                        Names.Add(Well.ListDescriptors[IdxDesc].GetAssociatedType().GetName());
                    }
                if (NameDesc == "") return;

                NameDesc = NameDesc.Remove(NameDesc.Length - 2);
            }

            mycommand.CommandText = "SELECT "+ NameDesc+" FROM \"" + Well.SQLTableName + "\"";
            SQLiteDataReader value = mycommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(value);

            if (!IsOnlyActiveDesc)
                Names = this.GetDescriptorNames(Well);

            int CurrentClass = Well.GetClass();

            if (DataTableToAddedTo.Columns.Count == 0)
            {
                foreach (string TmpName in Names)
                {

                    DataTableToAddedTo.Columns.Add(new DataColumn(TmpName, typeof(double)));
                }

                if (IsAddWellClass)
                    DataTableToAddedTo.Columns.Add(new DataColumn("Well_Class", typeof(int)));
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTableToAddedTo.Rows.Add();

                for (int IdxCol = 0; IdxCol < Names.Count; IdxCol++)
                    DataTableToAddedTo.Rows[DataTableToAddedTo.Rows.Count - 1][IdxCol] = dt.Rows[i][IdxCol];

                if (IsAddWellClass)
                    DataTableToAddedTo.Rows[DataTableToAddedTo.Rows.Count - 1][Names.Count] = CurrentClass;
            }
            return;
        }


        public cExtendedList GetWellValues(string TableName, cDescriptorsType DescType)
        {
            cExtendedList ToReturn = new cExtendedList();
            //for (int i = 0; i < 1000; i++)
            //    ToReturn.Add(i);
            //return ToReturn;
            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            mycommand.CommandText = "SELECT *, \"" + DescType.GetName() + "\" FROM \"" + TableName + "\"";
            //mycommand.CommandText = "SELECT *, FROM \"" + TableName + "\"";
            SQLiteDataReader value = mycommand.ExecuteReader();
            // value.Read();
            int Pos = value.GetOrdinal(DescType.GetName());

            while (value.Read())
            {
                ToReturn.Add(value.GetFloat(Pos));
            }


            return ToReturn;
        }

        public DataTable GetWellAllDescriptorValues(string TableName)
        {
            //  cExtendedList ToReturn = new cExtendedList();

            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            // mycommand.CommandText = "SELECT *, \"" + DescType.GetName() + "\" FROM \"" + TableName + "\"";
            mycommand.CommandText = "SELECT * FROM \"" + TableName + "\"";
            SQLiteDataReader value = mycommand.ExecuteReader();
            // value.Read();

            //object[] myObjectArray = new object[value.FieldCount];



            //while (value.Read())
            //{
            //    value.GetValues(myObjectArray);
            //    int a = 1;
            //    //ToReturn.Add((double)myObjectArray[0]);
            //}



            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(mycommand.CommandText, _SQLiteConnection);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            //Get the collection of rows from the DataSet
            //  DataRowCollection dataRowCol = ds.Tables[0].Rows;

            DataTable TableToReturn = ds.Tables[0];
            //Add the tables available in the DB to the combo box
            //foreach (DataRow dr in dataRowCol)
            //{
            //    tablecombobox.Items.Add(dr["name"]);
            //}


            /*int Pos = value.GetOrdinal(DescType.GetName());

            while (value.Read())
            {
                ToReturn.Add(value.GetFloat(Pos));
            }
            */

            return TableToReturn;
        }


        public List<string> GetDescriptorNames(int IdxWell)
        {
            List<string> ToReturn = new List<string>();
            string NameWell = "\"" + GetListTableNames()[IdxWell] + "\"";

            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            mycommand.CommandText = "SELECT * FROM " + NameWell;
            SQLiteDataReader value = mycommand.ExecuteReader();

            for (int i = 0; i < value.FieldCount; i++)
                ToReturn.Add(value.GetName(i));

            return ToReturn;
        }

        public List<string> GetDescriptorNames(cWell Well)
        {
            List<string> ToReturn = new List<string>();
            //  string NameWell = GetListTableNames()[IdxWell];

            SQLiteCommand mycommand = new SQLiteCommand(_SQLiteConnection);
            mycommand.CommandText = "SELECT * FROM \"" + Well.SQLTableName + "\"";
            SQLiteDataReader value = mycommand.ExecuteReader();

            for (int i = 0; i < value.FieldCount; i++)
                ToReturn.Add(value.GetName(i));

            return ToReturn;
        }
        public cDBConnection(cPlate Plate, string SQLFileDBName)
        {
            if (Plate.DBConnection == null)
                this.SQLFileDBName = SQLFileDBName;
            else
                this.SQLFileDBName = Plate.DBConnection.SQLFileDBName;

            this.DB_EstablishConnection();
        }

    }




    public class cPlate
    {
        string PlateType;
        cWell[,] ListWell = null;
        public string Name;
        public cScreening ParentScreening;
        List<double[]> ListMinMax = null;
        public cExtendWellList ListActiveWells = new cExtendWellList();

        public cListDRCRegion ListDRCRegions;

        public cDBConnection DBConnection = null;
        //public void DBConnection_Establish(string FileName)
        //{
        //    DBConnection = new cDBConnection(this, FileName);
        //}


        int NumberOfActiveWells = 0;
        int[] ListNumObjectPerClasse;
        cInfoClassif InfoClassif = new cInfoClassif();


        #region Weka based clustering and classification

        /// <summary>
        /// Create an instances structure without classes for unsupervised methods
        /// </summary>
        /// <returns>a weka Instances object</returns>
        public Instances CreateInstancesWithoutClass()
        {
            weka.core.FastVector atts = new FastVector();
            int columnNo = 0;

            // Descriptors loop
            for (int i = 0; i < ParentScreening.ListDescriptors.Count; i++)
            {
                if (ParentScreening.ListDescriptors[i].IsActive() == false) continue;
                atts.addElement(new weka.core.Attribute(ParentScreening.ListDescriptors[i].GetName()));
                columnNo++;
            }
            weka.core.FastVector attVals = new FastVector();
            Instances data1 = new Instances("MyRelation", atts, 0);

            foreach (cWell CurrentWell in this.ListActiveWells)
            {
                double[] vals = new double[data1.numAttributes()];

                int IdxRealCol = 0;

                for (int Col = 0; Col < ParentScreening.ListDescriptors.Count; Col++)
                {
                    if (ParentScreening.ListDescriptors[Col].IsActive() == false) continue;
                    vals[IdxRealCol++] = CurrentWell.ListDescriptors[Col].GetValue();
                }
                data1.add(new DenseInstance(1.0, vals));
            }

            return data1;
        }


        /// <summary>
        /// Create an instances structure with classes for supervised methods
        /// </summary>
        /// <param name="NumClass"></param>
        /// <returns></returns>
        public Instances CreateInstancesWithClasses(cInfoClass InfoClass, int NeutralClass)
        {
            weka.core.FastVector atts = new FastVector();

            int columnNo = 0;

            for (int i = 0; i < ParentScreening.ListDescriptors.Count; i++)
            {
                if (ParentScreening.ListDescriptors[i].IsActive() == false) continue;
                atts.addElement(new weka.core.Attribute(ParentScreening.ListDescriptors[i].GetName()));
                columnNo++;
            }

            weka.core.FastVector attVals = new FastVector();

            for (int i = 0; i < InfoClass.NumberOfClass; i++)
                attVals.addElement("Class__" + (i).ToString());


            atts.addElement(new weka.core.Attribute("Class__", attVals));

            Instances data1 = new Instances("MyRelation", atts, 0);
            int IdxWell = 0;
            foreach (cWell CurrentWell in this.ListActiveWells)
            {
                if (CurrentWell.GetClass() == NeutralClass) continue;
                double[] vals = new double[data1.numAttributes()];

                int IdxCol = 0;
                for (int Col = 0; Col < ParentScreening.ListDescriptors.Count; Col++)
                {
                    if (ParentScreening.ListDescriptors[Col].IsActive() == false) continue;
                    vals[IdxCol++] = CurrentWell.ListDescriptors[Col].GetValue();
                }
                vals[columnNo] = InfoClass.CorrespondanceTable[CurrentWell.GetClass()];
                data1.add(new DenseInstance(1.0, vals));
                IdxWell++;
            }
            data1.setClassIndex((data1.numAttributes() - 1));

            return data1;
        }


        /// <summary>
        /// Create an instances structure with classes for supervised methods
        /// </summary>
        /// <param name="NumClass"></param>
        /// <returns></returns>
        public Instances CreateInstancesWithClassesWithPlateBasedDescriptor(int NumberOfClass)
        {
            weka.core.FastVector atts = new FastVector();

            int columnNo = 0;

            for (int i = 0; i < ParentScreening.ListPlateBaseddescriptorNames.Count; i++)
            {
                atts.addElement(new weka.core.Attribute(ParentScreening.ListPlateBaseddescriptorNames[i]));
                columnNo++;
            }

            weka.core.FastVector attVals = new FastVector();

            for (int i = 0; i < NumberOfClass; i++)
                attVals.addElement("Class" + (i).ToString());

            atts.addElement(new weka.core.Attribute("Class", attVals));

            Instances data1 = new Instances("MyRelation", atts, 0);
            int IdxWell = 0;
            foreach (cWell CurrentWell in this.ListActiveWells)
            {
                if (CurrentWell.GetClass() == -1) continue;
                double[] vals = new double[data1.numAttributes()];
                int IdxCol = 0;
                for (int Col = 0; Col < ParentScreening.ListPlateBaseddescriptorNames.Count; Col++)
                {
                    vals[IdxCol++] = CurrentWell.ListPlateBasedDescriptors[Col].GetValue();
                }
                vals[columnNo] = CurrentWell.GetClass();
                data1.add(new DenseInstance(1.0, vals));
                IdxWell++;
            }
            data1.setClassIndex((data1.numAttributes() - 1));

            return data1;
        }


        public cInfoForHierarchical CreateInstancesWithUniqueClasse()
        {
            cInfoForHierarchical InfoForHierarchical = new cInfoForHierarchical();
            weka.core.FastVector atts = new FastVector();

            int columnNo = 0;

            for (int i = 0; i < this.ParentScreening.ListDescriptors.Count; i++)
            {
                if (this.ParentScreening.ListDescriptors[i].IsActive() == false) continue;
                atts.addElement(new weka.core.Attribute(this.ParentScreening.ListDescriptors[i].GetName()));
                columnNo++;
            }

            weka.core.FastVector attVals = new FastVector();
            atts.addElement(new weka.core.Attribute("Class_____", attVals));

            InfoForHierarchical.Ninsts = new Instances("MyRelation", atts, 0);
            int IdxWell = 0;
            foreach (cWell CurrentWell in this.ListActiveWells)
            {
                if (CurrentWell.GetClass() == -1) continue;
                attVals.addElement("Class_____" + (IdxWell).ToString());

                InfoForHierarchical.ListIndexedWells.Add(CurrentWell);

                double[] vals = new double[InfoForHierarchical.Ninsts.numAttributes()];
                int IdxCol = 0;
                for (int Col = 0; Col < this.ParentScreening.ListDescriptors.Count; Col++)
                {
                    if (this.ParentScreening.ListDescriptors[Col].IsActive() == false) continue;
                    vals[IdxCol++] = CurrentWell.ListDescriptors[Col].GetValue();
                }
                vals[columnNo] = IdxWell;
                InfoForHierarchical.Ninsts.add(new DenseInstance(1.0, vals));
                IdxWell++;
            }

            InfoForHierarchical.Ninsts.setClassIndex((InfoForHierarchical.Ninsts.numAttributes() - 1));
            return InfoForHierarchical;
        }

        /// <summary>
        /// Assign a class to each well based on table
        /// </summary>
        /// <param name="ListClasses">Table containing the classes</param>
        public void AssignClass(double[] ListClasses)
        {
            int i = 0;
            foreach (cWell CurrentWell in this.ListActiveWells)
                CurrentWell.SetClass((int)ListClasses[i++]);
        }
        #endregion

        public void DisplayHistogram(int DescIdx)
        {
            cExtendedList Pos = new cExtendedList();
            //cWell TempWell;

            foreach (cWell item in this.ListActiveWells)
            {
                Pos.Add(item.ListDescriptors[DescIdx].GetValue());

            }

            if (Pos.Count == 0)
            {
                MessageBox.Show("Not enough active well selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<double[]> HistoPos = ParentScreening.GlobalInfo.WindowHCSAnalyzer.CreateHistogram(Pos.ToArray(), (int)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownHistoBin.Value);
            SimpleForm NewWindow = new SimpleForm();

            Series SeriesPos = new Series();
            SeriesPos.ShadowOffset = 1;

            if (HistoPos.Count == 0) return;

            for (int IdxValue = 0; IdxValue < HistoPos[0].Length; IdxValue++)
            {
                SeriesPos.Points.AddXY(HistoPos[0][IdxValue], HistoPos[1][IdxValue]);
                SeriesPos.Points[IdxValue].ToolTip = HistoPos[1][IdxValue].ToString();
                SeriesPos.Points[IdxValue].Color = Color.DarkBlue;

            }

            ChartArea CurrentChartArea = new ChartArea();
            CurrentChartArea.BorderColor = Color.Black;

            NewWindow.chartForSimpleForm.ChartAreas.Add(CurrentChartArea);
            CurrentChartArea.Axes[0].MajorGrid.Enabled = false;
            CurrentChartArea.Axes[0].Title = ParentScreening.ListDescriptors[DescIdx].GetName();
            CurrentChartArea.Axes[1].Title = "Sum";
            CurrentChartArea.AxisX.LabelStyle.Format = "N2";

            NewWindow.chartForSimpleForm.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            CurrentChartArea.BackGradientStyle = GradientStyle.TopBottom;
            CurrentChartArea.BackColor = ParentScreening.GlobalInfo.OptionsWindow.panel1.BackColor;
            CurrentChartArea.BackSecondaryColor = Color.White;

            SeriesPos.ChartType = SeriesChartType.Column;
            SeriesPos.Color = ParentScreening.GlobalInfo.GetColor(1);
            NewWindow.chartForSimpleForm.Series.Add(SeriesPos);

            NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserEnabled = true;
            NewWindow.chartForSimpleForm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            NewWindow.chartForSimpleForm.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            if (ParentScreening.GlobalInfo.OptionsWindow.checkBoxDisplayHistoStats.Checked)
            {
                StripLine AverageLine = new StripLine();
                AverageLine.BackColor = Color.Black;
                AverageLine.IntervalOffset = Pos.Mean();
                AverageLine.StripWidth = double.Epsilon;
                CurrentChartArea.AxisX.StripLines.Add(AverageLine);
                AverageLine.Text = String.Format("{0:0.###}", AverageLine.IntervalOffset);

                StripLine StdLine = new StripLine();
                StdLine.BackColor = Color.FromArgb(64, Color.Black);
                double Std = Pos.Std();
                StdLine.IntervalOffset = AverageLine.IntervalOffset - 0.5 * Std;
                StdLine.StripWidth = Std;
                CurrentChartArea.AxisX.StripLines.Add(StdLine);
                AverageLine.StripWidth = 0.0001;
            }

            Title CurrentTitle = null;

            CurrentTitle = new Title(ParentScreening.GetCurrentDisplayPlate().Name + " - " + ParentScreening.ListDescriptors[DescIdx].GetName() + " histogram.");

            CurrentTitle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            NewWindow.chartForSimpleForm.Titles.Add(CurrentTitle);
            NewWindow.Text = CurrentTitle.Text;
            NewWindow.Show();
            NewWindow.chartForSimpleForm.Update();
            NewWindow.chartForSimpleForm.Show();
            NewWindow.Controls.AddRange(new System.Windows.Forms.Control[] { NewWindow.chartForSimpleForm });
            return;
        }

        public void DisplayDescriptorsWindow()
        {
            List<cPanelForDisplayArray> ListPlates = new List<cPanelForDisplayArray>();

            //foreach (cPlate CurrentPlate in CompleteScreening.ListPlatesActive)

            for (int DescIdx = 0; DescIdx < this.ParentScreening.ListDescriptors.Count; DescIdx++)
            {
                if (this.ParentScreening.ListDescriptors[DescIdx].IsActive())
                    ListPlates.Add(new FormToDisplayDescriptorPlate(this, this.ParentScreening, DescIdx));
            }

            cWindowToDisplayEntireDescriptors WindowToDisplayArray = new cWindowToDisplayEntireDescriptors(ListPlates, this.ParentScreening.GetCurrentDisplayPlate().Name, 6);

            WindowToDisplayArray.Show();
        }


        public int[] UpdateNumberOfClass()
        {
            ListNumObjectPerClasse = new int[11];

            for (int j = 0; j < ParentScreening.Rows; j++)
                for (int i = 0; i < ParentScreening.Columns; i++)
                {
                    cWell TempWell = GetWell(i, j, true);
                    if (TempWell == null) continue;
                    //if (TempWell.GetClass() == -1) continue;
                    ListNumObjectPerClasse[TempWell.GetClass() + 1]++;
                }

            if (ParentScreening.GetSelectionType() >= -1)
            {
                ParentScreening.GlobalInfo.LabelForClass.Text = ListNumObjectPerClasse[ParentScreening.GetSelectionType() + 1].ToString();
                ParentScreening.GlobalInfo.LabelForClass.Update();
            }
            return ListNumObjectPerClasse;
        }

        public int GetNumberOfClasses()
        {
            int NumberOfClasses = 0;
            int[] ListClasses = UpdateNumberOfClass();

            for (int i = 0; i < ListClasses.Length; i++)
            {
                if (ListClasses[i] > 0) NumberOfClasses++;
            }

            return NumberOfClasses;
        }

        public int GetNumberOfWellOfClass(int Class)
        {
            int[] ListClasses = UpdateNumberOfClass();
            return ListClasses[Class + 1];
        }

        public cInfoClassif GetInfoClassif()
        {
            return this.InfoClassif;
        }

        public cInfoClass GetNumberOfClassesBut(int NeutralClass)
        {

            NeutralClass++;
            int[] ListClasses = UpdateNumberOfClass();

            cInfoClass InfoClass = new cInfoClass();
            InfoClass.CorrespondanceTable = new int[ParentScreening.GlobalInfo.GetNumberofDefinedClass()];

            for (int i = 1; i < ListClasses.Length; i++)
            {
                if ((ListClasses[i] > 0) && (i != NeutralClass))
                {
                    InfoClass.CorrespondanceTable[i - 1] = InfoClass.NumberOfClass++;
                    InfoClass.ListBackAssociation.Add(i - 1);
                }
                else
                    InfoClass.CorrespondanceTable[i - 1] = -1;
            }

            return InfoClass;
        }

        public int GetNumberOfActiveWellsButClass(int NeutralClass)
        {
            int NumberOfActive = 0;

            for (int row = 0; row < ParentScreening.Rows; row++)
                for (int col = 0; col < ParentScreening.Columns; col++)
                    if ((GetWell(col, row, true) != null) && (GetWell(col, row, true).GetClass() != NeutralClass)) NumberOfActive++;
            return NumberOfActive;
        }

        public void ComputePlateBasedDescriptors()
        {

            cDescriptorsType TypeRow = new cDescriptorsType("Row_Pos", true, 1, ParentScreening.GlobalInfo);
            cDescriptorsType TypeCol = new cDescriptorsType("Col_Pos", true, 1, ParentScreening.GlobalInfo);
            cDescriptorsType TypeDistBorder = new cDescriptorsType("Dist_To_Border", true, 1, ParentScreening.GlobalInfo);
            cDescriptorsType TypeDistCenter = new cDescriptorsType("Dist_To_Center", true, 1, ParentScreening.GlobalInfo);


            for (int j = 0; j < ParentScreening.Rows; j++)
                for (int i = 0; i < ParentScreening.Columns; i++)
                {
                    cWell TempWell = GetWell(i, j, false);
                    if (TempWell == null) continue;

                    TempWell.ListPlateBasedDescriptors = new List<cDescriptor>();

                    cDescriptor Descriptor0 = new cDescriptor(j, TypeRow, this.ParentScreening);
                    TempWell.ListPlateBasedDescriptors.Add(Descriptor0);

                    cDescriptor Descriptor1 = new cDescriptor(i, TypeCol, this.ParentScreening);
                    TempWell.ListPlateBasedDescriptors.Add(Descriptor1);

                    double MinDist = i + 1;
                    double DistToRight = ParentScreening.Columns - i;
                    if (DistToRight < MinDist) MinDist = DistToRight;
                    double DistToTop = j + 1;
                    if (DistToTop < MinDist) MinDist = DistToTop;
                    double DistToBottom = ParentScreening.Rows - j;
                    if (DistToBottom < MinDist) MinDist = DistToBottom;

                    cDescriptor Descriptor2 = new cDescriptor(MinDist, TypeDistBorder, this.ParentScreening);
                    TempWell.ListPlateBasedDescriptors.Add(Descriptor2);


                    double X_Center = ParentScreening.Columns / 2;
                    double Y_Center = ParentScreening.Rows / 2;

                    double DistToCenter = Math.Sqrt((i - X_Center) * (i - X_Center) + (j - Y_Center) * (j - Y_Center));

                    cDescriptor Descriptor3 = new cDescriptor(DistToCenter, TypeDistCenter, this.ParentScreening);
                    TempWell.ListPlateBasedDescriptors.Add(Descriptor3);

                }

            return;
        }

        public void AddWell(cWell NewWell)
        {
            ListWell[NewWell.GetPosX() - 1, NewWell.GetPosY() - 1] = NewWell;
            ListActiveWells.Add(NewWell);
        }

        public void UpDateWellsSelection()
        {
            int SelectionType = ParentScreening.GetSelectionType();
            if (SelectionType == -2) return;

            int PosMouseXMax = ParentScreening.ClientPosLast.X;
            int PosMouseXMin = ParentScreening.ClientPosFirst.X;

            if (ParentScreening.ClientPosFirst.X > PosMouseXMax)
            {
                PosMouseXMax = ParentScreening.ClientPosFirst.X;
                PosMouseXMin = ParentScreening.ClientPosLast.X;
            }

            int PosMouseYMax = ParentScreening.ClientPosLast.Y;
            int PosMouseYMin = ParentScreening.ClientPosFirst.Y;
            if (ParentScreening.ClientPosFirst.Y > PosMouseYMax)
            {
                PosMouseYMax = ParentScreening.ClientPosFirst.Y;
                PosMouseYMin = ParentScreening.ClientPosLast.Y;
            }

            int GutterSize = (int)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownGutter.Value;
            int ScrollShiftX = ParentScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.HorizontalScroll.Value;
            int ScrollShiftY = ParentScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.VerticalScroll.Value;

            List<cPlate> ListPlateToProcess = new List<cPlate>();
            if (ParentScreening.IsSelectionApplyToAllPlates == true)
            {
                ListPlateToProcess = ParentScreening.ListPlatesActive;
            }
            else
            {
                ListPlateToProcess.Add(this);
            }
            int NumberOfPlates = ParentScreening.ListPlatesActive.Count;

            //Point ResMin = ParentScreening.GlobalInfo.WindowHCSAnalyzer.panelForPlate.GetChildAtPoint(new Point(PosMouseXMin, PosMouseYMin));

            int PosWellMinX = (int)((PosMouseXMin - ScrollShiftX) / (ParentScreening.GlobalInfo.SizeHistoWidth + GutterSize));
            int PosWellMinY = (int)((PosMouseYMin - ScrollShiftY) / (ParentScreening.GlobalInfo.SizeHistoHeight + GutterSize));

            int PosWellMaxX = (int)((PosMouseXMax - ScrollShiftX) / (ParentScreening.GlobalInfo.SizeHistoWidth + GutterSize));
            int PosWellMaxY = (int)((PosMouseYMax - ScrollShiftY) / (ParentScreening.GlobalInfo.SizeHistoHeight + GutterSize));


            if (PosWellMaxX > ParentScreening.Columns) PosWellMaxX = ParentScreening.Columns;
            if (PosWellMaxY > ParentScreening.Rows) PosWellMaxY = ParentScreening.Rows;
            if (PosWellMinX < 0) PosWellMinX = 0;
            if (PosWellMinY < 0) PosWellMinY = 0;


            foreach (cPlate CurrentPlate in ListPlateToProcess)
            {

                for (int j = PosWellMinY; j < PosWellMaxY; j++)
                    for (int i = PosWellMinX; i < PosWellMaxX; i++)
                    {
                        cWell TempWell = CurrentPlate.GetWell(i, j, false);

                        if (TempWell == null) continue;
                        if (SelectionType == -1)
                            TempWell.SetAsNoneSelected();
                        else
                            TempWell.SetClass(SelectionType);
                    }
            }
            ParentScreening.GetCurrentDisplayPlate().UpdateNumberOfClass();
            ParentScreening.UpdateListActiveWell();

        }


        public void Display3Dplate(int IdxDescriptor, cPoint3D MinimumPosition)
        {
            ParentScreening._3DWorldForPlateDisplay.ListMetaObjectList = new List<cMetaBiologicalObjectList>();
            cMetaBiologicalObjectList ListMetacells = new cMetaBiologicalObjectList("List Meta Objects");
            ParentScreening._3DWorldForPlateDisplay.ListMetaObjectList.Add(ListMetacells);

            c3DWell NewPlate3D = new c3DWell(new cPoint3D(0, 0, 0), new cPoint3D(ParentScreening.Columns, ParentScreening.Rows, 1), Color.Black, null);
            NewPlate3D.SetOpacity(0.0);

            cMetaBiologicalObject Plate3D = new cMetaBiologicalObject(this.Name, ListMetacells, NewPlate3D);



            #region  display the well list

            foreach (cWell TmpWell in this.ListWell)
            {
                if ((TmpWell == null) || (TmpWell.GetClass() == -1)) continue;

                double PosZ = 8 - ((TmpWell.ListDescriptors[IdxDescriptor].GetValue() - this.ListMinMax[IdxDescriptor][0]) * 8) / (this.ListMinMax[IdxDescriptor][1] - this.ListMinMax[IdxDescriptor][0]);


                double WellSize = (double)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownWellSize.Value;
                double WellBorder = (1 - WellSize) / 2.0;

                cPoint3D CurrentPos = new cPoint3D(TmpWell.GetPosX() - WellBorder + MinimumPosition.X, TmpWell.GetPosY() + WellBorder + MinimumPosition.Y - WellSize / 2, PosZ + MinimumPosition.Z - WellBorder);
                Color WellColor = Color.Black;

                if (ParentScreening.GlobalInfo.IsDisplayClassOnly)
                    WellColor = TmpWell.GetColor();
                else
                {
                    int ConvertedValue;
                    byte[][] LUT = ParentScreening.GlobalInfo.LUT;

                    if (this.ListMinMax[IdxDescriptor][0] == this.ListMinMax[IdxDescriptor][1])
                        ConvertedValue = 0;
                    else
                        ConvertedValue = (int)(((TmpWell.ListDescriptors[IdxDescriptor].GetValue() - this.ListMinMax[IdxDescriptor][0]) * (LUT[0].Length - 1)) / (this.ListMinMax[IdxDescriptor][1] - this.ListMinMax[IdxDescriptor][0]));
                    if ((ConvertedValue >= 0) && (ConvertedValue < LUT[0].Length))
                        WellColor = Color.FromArgb(LUT[0][ConvertedValue], LUT[1][ConvertedValue], LUT[2][ConvertedValue]);
                }



                c3DWell New3DWell = new c3DWell(CurrentPos, new cPoint3D(CurrentPos.X + WellSize, CurrentPos.Y + WellSize, CurrentPos.Z + WellSize / 2.0), WellColor, TmpWell);


                New3DWell.SetType("[" + TmpWell.GetPosX() + " x " + TmpWell.GetPosY() + "]");

                if (ParentScreening.GlobalInfo.OptionsWindow.checkBoxDisplayWellInformation.Checked)
                {
                    string ToDisp = "";
                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellInfoName.Checked)
                        ToDisp = TmpWell.Name;
                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellInfoInfo.Checked)
                        ToDisp = TmpWell.Info;
                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellInfoDescValue.Checked)
                        ToDisp = TmpWell.ListDescriptors[ParentScreening.ListDescriptors.CurrentSelectedDescriptor].GetValue().ToString("N3");
                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellInfoLocusID.Checked)
                        ToDisp = ((int)(TmpWell.LocusID)).ToString();
                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellInfoConcentration.Checked)
                        if (TmpWell.Concentration >= 0) ToDisp = TmpWell.Concentration.ToString("e4");

                    New3DWell.AddText(ToDisp, ParentScreening._3DWorldForPlateDisplay, 0.1);
                }

                New3DWell.SetOpacity((double)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownWellOpacity.Value);
                ParentScreening._3DWorldForPlateDisplay.AddBiological3DObject(New3DWell);
                Plate3D.AddObject(New3DWell);
            }

            #endregion

            #region Well numbering
            if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DPlateInformation.Checked)
            {
                for (int i = 1; i <= ParentScreening.Columns; i++)
                {
                    c3DText CurrentText = new c3DText(ParentScreening._3DWorldForPlateDisplay, i.ToString(), new cPoint3D(i - 1 + MinimumPosition.X, -0.5 + MinimumPosition.Y, 0 + MinimumPosition.Z), Color.White, 0.35);
                    ParentScreening._3DWorldForPlateDisplay.AddGeometric3DObject(CurrentText);
                }
                for (int j = 1; j <= ParentScreening.Rows; j++)
                {
                    c3DText CurrentText1;

                    if (ParentScreening.GlobalInfo.OptionsWindow.radioButtonWellPosModeDouble.Checked)
                        CurrentText1 = new c3DText(ParentScreening._3DWorldForPlateDisplay, j.ToString(), new cPoint3D(-1 + MinimumPosition.X, j - 0.5 + MinimumPosition.Y, 0 + MinimumPosition.Z), Color.White, 0.35);
                    else
                        CurrentText1 = new c3DText(ParentScreening._3DWorldForPlateDisplay, ParentScreening.GlobalInfo.ConvertIntPosToStringPos(j), new cPoint3D(-1 + MinimumPosition.X, j - 0.5 + MinimumPosition.Y, 0 + MinimumPosition.Z), Color.White, 0.35);

                    ParentScreening._3DWorldForPlateDisplay.AddGeometric3DObject(CurrentText1);
                }
            }
            #endregion

            if (this.ListDRCRegions != null)
            {
                foreach (cDRC_Region Region in this.ListDRCRegions)
                {

                    if (ParentScreening.GlobalInfo.OptionsWindow.checkBox1.Checked)
                    {

                        cDRC CurrentDRC = Region.GetDRC(this.ParentScreening.ListDescriptors[IdxDescriptor]);
                        if ((CurrentDRC == null) || (CurrentDRC.ResultFit == null) || (CurrentDRC.ResultFit.Y_Estimated.Count <= 1)) continue;


                        c3DDRC New3DDRC = new c3DDRC(CurrentDRC, Region, Color.White, this.ListMinMax[IdxDescriptor][0], this.ListMinMax[IdxDescriptor][1]);
                        New3DDRC.SetOpacity((double)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownDRCOpacity.Value);
                        //New3DDRC.SetType("[" + TmpWell.GetPosX() + " x " + TmpWell.GetPosY() + "]");
                        ParentScreening._3DWorldForPlateDisplay.AddGeometric3DObject(New3DDRC);
                        //Plate3D.AddObject(New3DDRC);
                    }

                    if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DComputeThinPlate.Checked)
                    {
                        c3DThinPlate NewThinPlate = new c3DThinPlate(Region, (double)ParentScreening.GlobalInfo.OptionsWindow.numericUpDown3DThinPlateRegularization.Value);

                        if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DDisplayThinPlate.Checked)
                        {
                            NewThinPlate.SetOpacity(0.5);
                            NewThinPlate.SetToWireFrame();
                            ParentScreening._3DWorldForPlateDisplay.AddGeometric3DObject(NewThinPlate);
                        }
                        if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DDisplayIsoboles.Checked)
                        {
                            for (double PosZContour = 0; PosZContour <= 10.0; PosZContour += 1.5)
                            {
                                c3DIsoContours NewContour = new c3DIsoContours(NewThinPlate, Region, Color.Red, PosZContour, true);
                                ParentScreening._3DWorldForPlateDisplay.AddBiological3DObject(NewContour);
                            }
                        }
                        if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DDisplayIsoRatioCurves.Checked)
                        {
                            //   for (double PosZContour = 0; PosZContour <= 15.0; PosZContour += 3)
                            {
                                c3DIsoContours NewContour = new c3DIsoContours(NewThinPlate, Region, Color.Blue, 0/*PosZContour*/, false);
                                ParentScreening._3DWorldForPlateDisplay.AddBiological3DObject(NewContour);
                            }
                        }
                    }


                }

            }




        }

        public void Refresh3D(int IdxDescriptor)
        {
            if (ParentScreening.GlobalInfo.Is3DVisu())
            {
                if (ParentScreening._3DWorldForPlateDisplay == null)
                {
                    ParentScreening._3DWorldForPlateDisplay = new c3DWorld(new cPoint3D(ParentScreening.Columns, ParentScreening.Rows, 1), new cPoint3D(1, 1, 1), ParentScreening.GlobalInfo.renderWindowControlForVTK, ParentScreening.GlobalInfo.WinSize, this.ParentScreening);


                    Display3Dplate(IdxDescriptor, new cPoint3D(0, 0, 0));

                    ParentScreening._3DWorldForPlateDisplay.DisplayBottom(Color.FromArgb(255, 255, 255));
                    ParentScreening._3DWorldForPlateDisplay.SetBackgroundColor(Color.Black);

                    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().Zoom(1.8);
                    ParentScreening._3DWorldForPlateDisplay.Render();


                    double[] p = ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().GetPosition();
                    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().SetPosition(p[0], p[1], p[2] - 4);
                }
                else
                {
                    double[] View = ParentScreening._3DWorldForPlateDisplay.ren1.GetViewPoint();

                    //this.ren1.ResetCamera();
                    double[] fp = ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().GetFocalPoint();
                    double[] p = ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().GetPosition();
                    double[] ViewUp = ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().GetViewUp();



                    double dist = Math.Sqrt((p[0] - fp[0]) * (p[0] - fp[0]) + (p[1] - fp[1]) * (p[1] - fp[1]) + (p[2] - fp[2]) * (p[2] - fp[2]));
                    //  int[] WinPos = new int[2];

                    if (ParentScreening._3DWorldForPlateDisplay == null)
                    {
                        ParentScreening.GlobalInfo.WinSize[0] = 750;
                        ParentScreening.GlobalInfo.WinSize[1] = 400;
                    }
                    else
                    {
                        ParentScreening.GlobalInfo.WinSize[0] = ParentScreening._3DWorldForPlateDisplay.renWin.GetSize()[0];
                        ParentScreening.GlobalInfo.WinSize[1] = ParentScreening._3DWorldForPlateDisplay.renWin.GetSize()[1];

                    }


                    //WinPos[0] = ParentScreening._3DWorldForPlateDisplay.renWin.GetSize()[0];
                    //WinPos[1] = ParentScreening._3DWorldForPlateDisplay.renWin.GetSize()[1];


                    //  ParentScreening._3DWorldForPlateDisplay.Terminate();
                    //  ParentScreening._3DWorldForPlateDisplay = null;
                    //  ParentScreening._3DWorldForPlateDisplay = new c3DWorld(new cPoint3D(ParentScreening.Columns, ParentScreening.Rows, 1), new cPoint3D(1, 1, 1), ParentScreening.GlobalInfo.renderWindowControlForVTK, ParentScreening.GlobalInfo.WinSize);

                    //ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().Roll(180);
                    //ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().Azimuth(180);

                    ParentScreening._3DWorldForPlateDisplay.ren1.RemoveAllViewProps();



                    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().SetFocalPoint(fp[0], fp[1], fp[2]);
                    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().SetPosition(p[0], p[1], p[2]);
                    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().SetViewUp(ViewUp[0], ViewUp[1], ViewUp[2]);

                    //    ParentScreening._3DWorldForPlateDisplay.ren1.GetActiveCamera().Zoom(1.8);

                }



                Display3Dplate(IdxDescriptor, new cPoint3D(0, 0, 0));

                if (ParentScreening.GlobalInfo.OptionsWindow.checkBox3DPlateInformation.Checked) ParentScreening._3DWorldForPlateDisplay.DisplayBottom(Color.FromArgb(255, 255, 255));
                ParentScreening._3DWorldForPlateDisplay.SetBackgroundColor(Color.Black);
                ParentScreening._3DWorldForPlateDisplay.SimpleRender();
            }

            #region Close the 3D view
            else
            {
                if (ParentScreening._3DWorldForPlateDisplay != null)
                {
                    ParentScreening._3DWorldForPlateDisplay.Terminate();
                    ParentScreening._3DWorldForPlateDisplay = null;
                }
            }
            #endregion



        }




        public void DisplayDistribution(int IdxDescriptor, bool IsFirstTime)
        {
            if (ListMinMax == null) this.UpDataMinMax();

            if (IdxDescriptor >= ListMinMax.Count) return;

            double[] MinMax = this.ListMinMax[IdxDescriptor];


            //if(ParentScreening.GlobalInfo.IsPieView==false)
            Refresh3D(IdxDescriptor);

            #region 2D display
            //   if (!this.ParentScreening.GlobalInfo.IsDisplayClassOnly)
            {
                //  ParentScreening.PanelForPlate.Controls.Clear();

                //double[] MinMax = ListMinMax[IdxDescriptor];
                // List<PlateChart> LChart = new List<PlateChart>();
                //int PosScrollX = ParentScreening.GlobalInfo.panelForPlate.HorizontalScroll.Value;
                //int PosScrollY = ParentScreening.GlobalInfo.panelForPlate.VerticalScroll.Value;

                ParentScreening.GlobalInfo.panelForPlate.Controls.Clear();
                List<PlateChart> LChart = new List<PlateChart>();
                if (ParentScreening.GlobalInfo.IsDisplayClassOnly)
                {

                    for (int j = 0; j < ParentScreening.Rows; j++)
                        for (int i = 0; i < ParentScreening.Columns; i++)
                        {
                            cWell TempWell = GetWell(i, j, false);
                            if (TempWell == null) continue;

                            // Add chart control to the form
                            LChart.Add(TempWell.BuildChartForClass());
                        }

                    // return;
                }
                else
                {
                    if (ParentScreening.GlobalInfo.ViewMode == eViewMode.DISTRIBUTION)
                    {
                        UpdateMinMaxHisto(IdxDescriptor);
                    
                    }
                    // Display Axes
                    //int Gutter = (int)ParentScreening.GlobalInfo.OptionsWindow.numericUpDownGutter.Value;
                    for (int j = 0; j < ParentScreening.Rows; j++)
                        for (int i = 0; i < ParentScreening.Columns; i++)
                        {
                            cWell TempWell = GetWell(i, j, false);
                            if (TempWell == null) continue;
                            LChart.Add(TempWell.BuildChart(IdxDescriptor, MinMax));
                        }
                }
                //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate()    {  ParentScreening.PanelForPlate.BeginInvoke(new Action(delegate() {            })); }));
                //thread.Start();

                ParentScreening.GlobalInfo.panelForPlate.Controls.AddRange(LChart.ToArray());
            #endregion
                //ParentScreening.GlobalInfo.panelForPlate.HorizontalScroll.Value = PosScrollX;
                //ParentScreening.GlobalInfo.panelForPlate.VerticalScroll.Value = PosScrollY;
                if (MinMax[0] != MinMax[1]) DisplayLUT(IdxDescriptor);
            }
            return;
        }

        public double[] MinMaxHisto = new double[2];

        private void UpdateMinMaxHisto(int IdxDescriptor)
        {
            MinMaxHisto[0] = double.MaxValue;
            MinMaxHisto[1] = double.MinValue;

            double CurrentValue;

            foreach (cWell CurrentWell in this.ListWell)
            {
                if (CurrentWell == null) continue;

                CurrentValue = CurrentWell.ListDescriptors[IdxDescriptor].Histogram.Min();
                if (CurrentValue < MinMaxHisto[0])
                    MinMaxHisto[0] = CurrentValue;

                CurrentValue = CurrentWell.ListDescriptors[IdxDescriptor].Histogram.Max();
                if (CurrentValue > MinMaxHisto[1])
                    MinMaxHisto[1] = CurrentValue;

            }

            ParentScreening.GlobalInfo.OptionsWindow.numericUpDownAutomatedMin.Value = (decimal)MinMaxHisto[0];
            ParentScreening.GlobalInfo.OptionsWindow.numericUpDownAutomatedMax.Value = (decimal)MinMaxHisto[1];

        }

        

        public void DisplayLUT(int IdxDescriptor)
        {
            if (ParentScreening.LabelForMin == null) return;

            ParentScreening.LabelForMin.Text = String.Format("{0:0.######}", ListMinMax[IdxDescriptor][0]);
            ParentScreening.LabelForMax.Text = String.Format("{0:0.######}", ListMinMax[IdxDescriptor][1]);
        }


        public cWell GetWell(int Col, int Row, bool OnlyIfSelected)
        {
            if ((Col >= this.ParentScreening.Columns) || (Row >= this.ParentScreening.Rows)) return null;
            if (ListWell[Col, Row] == null) return null;
            if ((OnlyIfSelected) && (ListWell[Col, Row].GetClass() == -1))
                return null;
            else return ListWell[Col, Row];
        }

        public cPlate(string Type, string Name, cScreening ParentScreening)
        {
            this.ParentScreening = ParentScreening;
            this.Name = Name;
            this.PlateType = Type;
            ListWell = new cWell[ParentScreening.Columns, ParentScreening.Rows];
            return;
        }

        double[] GetMinMax(int IdxDescriptor)
        {
            double[] Boundaries = new double[2];

            double Min = double.MaxValue;
            double Max = double.MinValue;
            double CurrentVal;



            for (int x = 0; x < ParentScreening.Columns; x++)
                for (int y = 0; y < ParentScreening.Rows; y++)
                {

                    if (ListWell[x, y] == null) continue;


                    cWell TWell = GetWell(x, y, false);

                    if (IdxDescriptor >= TWell.ListDescriptors.Count) return null;


                    if (TWell == null) continue;
                    CurrentVal = TWell.ListDescriptors[IdxDescriptor].GetValue();// ListWell[x, y].ListDescriptors[IdxDescriptor].AverageValue;
                    if (CurrentVal < Min) Min = CurrentVal;
                    if (CurrentVal > Max) Max = CurrentVal;
                }
            Boundaries[0] = Min;
            Boundaries[1] = Max;

            return Boundaries;
        }

        public void LoadFromDisk(string Path)
        {
            if (ListWell == null)
            {
                ParentScreening.GlobalInfo.ConsoleWriteLine("ListWell NULL");
                return;
            }
            IEnumerable<string> ListFile = Directory.EnumerateFiles(Path, "*.txt", SearchOption.TopDirectoryOnly);
            int ProcessedWell = 0;
            foreach (string FileName in ListFile)
            {
                cWell NewWell = new cWell(FileName, this.ParentScreening, this);
                if (NewWell.GetPosX() != -1) ProcessedWell++;
                this.AddWell(NewWell);
                //ListWell[NewWell.GetPosX() - 1, NewWell.GetPosY() - 1] = NewWell;
            }

            ListMinMax = new List<double[]>();
            for (int i = 0; i < ParentScreening.ListDescriptors.Count; i++)
            {
                double[] TmpMinMax = GetMinMax(i);
                ListMinMax.Add(TmpMinMax);
            }

            this.NumberOfActiveWells = ProcessedWell;
            ParentScreening.GlobalInfo.ConsoleWriteLine(ProcessedWell + " well(s) succesfully processed");
        }

        public void UpDataMinMax()
        {
            ListMinMax = new List<double[]>();
            for (int i = 0; i < ParentScreening.ListDescriptors.Count; i++)
            {
                double[] TmpMinMax = GetMinMax(i);
                if (ListMinMax != null) ListMinMax.Add(TmpMinMax);
            }
            return;
        }

        public int GetNumberOfActiveWells()
        {
            int NumberOfActive = 0;

            for (int row = 0; row < ParentScreening.Rows; row++)
                for (int col = 0; col < ParentScreening.Columns; col++)
                    if (GetWell(col, row, true) != null) NumberOfActive++;
            return NumberOfActive;
        }

        public double[,] GetAverageValueDescTable(int Desc, out bool IsMissingWell)
        {
            IsMissingWell = false;
            double[,] Table = new double[ParentScreening.Columns, ParentScreening.Rows];

            for (int j = 0; j < ParentScreening.Rows; j++)
                for (int i = 0; i < ParentScreening.Columns; i++)
                {
                    cWell currentWell = this.GetWell(i, j, true);
                    if (currentWell == null)
                        IsMissingWell = true;
                    else
                        Table[i, j] = currentWell.GetAverageValuesList(false)[Desc];
                }

            return Table;
        }

        public double[][] GetAverageValueDescTable1(int Desc, out bool IsMissingWell)
        {
            IsMissingWell = false;
            double[][] Table = new double[ParentScreening.Rows][];
            for (int J = 0; J < Table.Length; J++)
                Table[J] = new double[ParentScreening.Columns];

            for (int j = 0; j < ParentScreening.Rows; j++)
                for (int i = 0; i < ParentScreening.Columns; i++)
                {
                    cWell currentWell = this.GetWell(i, j, true);
                    if (currentWell == null)
                    {
                        IsMissingWell = true;
                        Table[j][i] = double.NaN;
                    }
                    else
                        Table[j][i] = currentWell.GetAverageValuesList(false)[Desc];
                }

            return Table;
        }

        public void SetAverageValueDescTable(int Desc, double[,] Table)
        {

            for (int j = 0; j < ParentScreening.Rows; j++)
                for (int i = 0; i < ParentScreening.Columns; i++)
                {
                    cWell currentWell = this.GetWell(i, j, true);
                    if (currentWell == null)
                        continue;

                    currentWell.ListDescriptors[Desc].SetHistoValues(Table[i, j]);
                    currentWell.ListDescriptors[Desc].UpDateDescriptorStatistics();
                }

            UpDataMinMax();
        }




    }
}
