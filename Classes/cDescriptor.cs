using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace LibPlateAnalysis
{

    public enum eDistances { EUCLIDEAN , MANHATTAN, VECTOR_COS, BHATTACHARYYA, EMD };
    public enum eDataType { HISTOGRAM, SINGLE };

    public class cDescriptorsType
    {
        public bool IsConnectedToDatabase { get; private set;}

        public eDataType DataType { get; private set; }

        public cDescriptorsType(string Name, bool IsActive, int BinNumber, bool IsConnectedToDB, cGlobalInfo GlobalInfo)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            
            if (BinNumber == 1) DataType = eDataType.SINGLE;
            else
                DataType = eDataType.HISTOGRAM;

            this.IsConnectedToDatabase = IsConnectedToDB;
            this.GlobalInfo = GlobalInfo;
            CreateAssociatedWindow();
        }
        public cDescriptorsType(string Name, bool IsActive, int BinNumber, cGlobalInfo GlobalInfo)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;

            if (BinNumber == 1) DataType = eDataType.SINGLE;
            else
                DataType = eDataType.HISTOGRAM;


            this.IsConnectedToDatabase = false;
            this.GlobalInfo = GlobalInfo;
            CreateAssociatedWindow();
        }
        /*public cDescriptorsType(cDescriptor Example, bool IsActive)
        {
            this.Name = Example.GetName();
            this.ActiveState = IsActive;
            this.IsSingle = Example.GetAssociatedType().IsSingle;
            CreateAssociatedWindow();

        }*/

        private string Name;

        public string GetName()
        {
            return Name;
        }

        // private cListDescriptors AssociatedcListDescriptors = null;

        private int NumBin;


        public int GetBinNumber()
        {
            return NumBin;
        }

        //public string GetDataType()
        //{
        //    if (NumBin == 1) return "Single";
        //    else
        //        return "Histogram";
        //}

        private bool ActiveState;

        public void SetActiveState(bool IsActive)
        {
            this.ActiveState = IsActive;
        }

        public bool IsActive()
        {
            return this.ActiveState;
        }

        public bool ChangeName(string NewName)
        {
            this.Name = NewName;
            return true;
        }


        public void ChangeBinNumber(int NewBinNumber)
        {
            int IdxDesc = GlobalInfo.CurrentScreen.ListDescriptors.GetDescriptorIndex(this);

            foreach (cPlate TmpPlate in GlobalInfo.CurrentScreen.ListPlatesAvailable)
            {
                for (int Col = 0; Col <= GlobalInfo.CurrentScreen.Columns; Col++)
                    for (int Row = 0; Row <= GlobalInfo.CurrentScreen.Rows; Row++)
                    {
                        cWell TmpWell = TmpPlate.GetWell(Col, Row, false);
                        if (TmpWell == null) continue;
                        TmpWell.ListDescriptors[IdxDesc].RefreshHisto(NewBinNumber);
                    }
            }

            this.NumBin = NewBinNumber;
        
        }
        cGlobalInfo GlobalInfo;
        public FormForDescriptorInfo WindowDescriptorInfo;// = new FormForDescriptorInfo();   

        private void CreateAssociatedWindow()
        {
            WindowDescriptorInfo = new FormForDescriptorInfo(this);
            WindowDescriptorInfo.CurrentDesc = this;
            WindowDescriptorInfo.Text = this.Name;
        }

    }

    public class cListDescriptors : List<cDescriptorsType>
    {
        CheckedListBox AssociatedListBox;
        ComboBox AssociatedListDescriptorToDisplay;
        public int CurrentSelectedDescriptor = -1;

        public int GetDescriptorIndex(cDescriptorsType DescriptorType)
        {
            int DescIndex = -1;
            foreach (cDescriptorsType TmpDescType in this)
            {
                DescIndex++;
                if (TmpDescType.GetName() == DescriptorType.GetName()) return DescIndex;
            }
            DescIndex = -1;

            return -1;
        }

        public int GetDescriptorIndex(string DescriptorName)
        {
            int DescIndex = -1;
            foreach (cDescriptorsType TmpDescType in this)
            {
                DescIndex++;
                if (TmpDescType.GetName() == DescriptorName) return DescIndex;
            }


            return -1;
        }

        public void SetCurrentSelectedDescriptor(int Desc)
        {
            this.CurrentSelectedDescriptor = Desc;
            this.AssociatedListDescriptorToDisplay.SelectedIndex = Desc;
        }

        public cListDescriptors(CheckedListBox AssociatedListBox, ComboBox AssociatedComboBox)
        {
            this.AssociatedListBox = AssociatedListBox;
            this.AssociatedListDescriptorToDisplay = AssociatedComboBox;

        }

        /// <summary>
        /// Clear the object as well as the associated control
        /// </summary>
        public void Clean()
        {
            this.Clear();
            AssociatedListBox.Items.Clear();
            AssociatedListDescriptorToDisplay.Items.Clear();
        }

        /// <summary>
        /// Add a descritpor to the global descriptor list
        /// </summary>
        /// <param name="DescriptorsType"></param>
        /// <returns>return false if the descriptor type already exist</returns>
        public bool AddNew(cDescriptorsType DescriptorsType)
        {
            foreach (cDescriptorsType temp in this)
            {
                if (temp.GetName() == DescriptorsType.GetName())
                    return false;
            }

            this.Add(DescriptorsType);
            this.AssociatedListBox.Items.Add(DescriptorsType.GetName(), true);
            this.AssociatedListDescriptorToDisplay.Items.Add(DescriptorsType.GetName());
            return true;
        }

        public void RemoveDesc(cDescriptorsType DescriptorTypeToBeRemoved, cScreening CurrentScreen)
        {
            for (int i = 0; i < this.Count; i++)
            {
                cDescriptorsType TmpType = this[i];

                if (DescriptorTypeToBeRemoved == TmpType)
                {
                    foreach (cPlate TmpPlate in CurrentScreen.ListPlatesAvailable)
                    {
                        foreach (cWell Tmpwell in TmpPlate.ListActiveWells) Tmpwell.ListDescriptors.RemoveAt(i);
                    }

                    this.RemoveAt(i);
                    AssociatedListBox.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.SelectedIndex = 0;
                    return;

                }
            }
        }

        public void RemoveDescUnSafe(cDescriptorsType DescriptorTypeToBeRemoved, cScreening CurrentScreen)
        {
            for (int i = 0; i < this.Count; i++)
            {
                cDescriptorsType TmpType = this[i];

                if (DescriptorTypeToBeRemoved == TmpType)
                {
                    foreach (cPlate TmpPlate in CurrentScreen.ListPlatesAvailable)
                    {
                        foreach (cWell Tmpwell in TmpPlate.ListActiveWells) Tmpwell.ListDescriptors.RemoveAt(i);
                    }

                    this.RemoveAt(i);
                    AssociatedListBox.Items.RemoveAt(i);
                    AssociatedListDescriptorToDisplay.Items.RemoveAt(i);

                    return;

                }
            }
        }

        public List<string> GetListNameActives()
        {
            List<string> NameActiveDesc = new List<string>();

            foreach (cDescriptorsType TmpDesc in this)
            {
                if (TmpDesc.IsActive()) NameActiveDesc.Add(TmpDesc.GetName());
            }
            return NameActiveDesc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsActive"></param>
        public void SetItemState(int IdxDesc, bool IsActive)
        {
            if (IsActive)
            {
                AssociatedListBox.SetItemCheckState(IdxDesc, CheckState.Checked);
                this[IdxDesc].SetActiveState(true);
            }
            else
            {
                AssociatedListBox.SetItemCheckState(IdxDesc, CheckState.Unchecked);
                this[IdxDesc].SetActiveState(false);
            }

        }

        public void UpDateDisplay()
        {
            int Idx = 0;
            foreach (cDescriptorsType TmpType in this)
            {
                AssociatedListBox.Items[Idx] = TmpType.GetName();
                AssociatedListDescriptorToDisplay.Items[Idx] = TmpType.GetName();
                Idx++;
            }
        }

        public cExtendedList GetValue(List<cPlate> ListPlate, cDescriptorsType Desc)
        {
            cExtendedList ToReturn = new cExtendedList();

            int Idx = this.GetDescriptorIndex(Desc);

            foreach (cPlate CurrentPlate in ListPlate)
                foreach (cWell TmpWell in CurrentPlate.ListActiveWells)
                    ToReturn.Add(TmpWell.ListDescriptors[Idx].GetValue());
            return ToReturn;
        }

    }


    public class cDescriptor
    {
        //string Name;
        //public bool IsSingle;

        public cDescriptorsType Type{ get; private set;}

        public cWell AssociatedWell;

        private cScreening CurrentScreening;

        public cDescriptorsType GetAssociatedType()
        {
            return this.Type;
        }

        public cHisto Histogram;

        private double AverageValue = 0;
        
        private double ComputeDistributionDistanceToReference()
        {
            return 0;

        }

        public int HistoBins;

        #region public

        /// <summary>
        /// Return the value associated to a descriptor within a well
        /// </summary>
        /// <returns>if scalar mode: average else distance between histograms</returns>
        public double GetValue()
        {
            if (CurrentScreening.Reference == null)
            {
                //if (Type.GetBinNumber() > 1)
                //{
                //   // MessageBox.Show("GetWeightedMean() not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    //return HistoValues.GetWeightedMean();
                //    return -1;
                //}
                //else
                //    return Histogram.GetXvalues()[0];
                return this.AverageValue;// this.Histogram.GetAverageValue();
            }
            else
            {
                MessageBox.Show("GetValue() not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //if (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEuclidean.Checked)
                //    return HistoValues.Dist_Euclidean(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricManhattan.Checked)
                //    return HistoValues.Dist_Manhattan(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricCosine.Checked)
                //    return HistoValues.Dist_VectorCosine(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricBhattacharyya.Checked)
                //    return HistoValues.Dist_BhattacharyyaCoefficient(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else if
                //    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEMD.Checked)
                //    return HistoValues.Dist_EarthMover(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                //else
                return -1;
            }



        }

        public void RefreshHisto(int NewNumBins)
        {
            this.HistoBins = NewNumBins;
            this.Histogram = new cHisto(this.GetOriginalValues(), HistoBins);
        
        
        }



        public void SetHistoValues(List<double> ListXValues, List<double> ListYValues)
        {
            this.Histogram = new cHisto(ListXValues, ListYValues);
            UpDateDescriptorStatistics();

        }

        public void SetHistoValues(double Value)
        {
            this.Histogram = new cHisto(Value);
            this.AverageValue = Value;
           // HistoValues[0] = Value;
           // UpDateDescriptorStatistics();

        }

        public void SetHistoValues(int Idx, double Value)
        {
            this.Histogram.SetYvalues(Value, Idx);
           // HistoValues[Idx] = Value;
            UpDateDescriptorStatistics();

        }

        public cExtendedList GetHistovalues()
        {
            return this.Histogram.GetYvalues();
        }

        public double GetHistovalue(int Idx)
        {
            return this.Histogram.GetYvalues()[Idx];
        }

        public double GetHistoXvalue(int Idx)
        {
            return this.Histogram.GetXvalues()[Idx];
        }

        /// <summary>
        /// return the descriptor name
        /// </summary>
        /// <returns>the Descriptor name</returns>
        public string GetName()
        {
            return this.Type.GetName();
        }


        /// <summary>
        /// Update the descritpor statistic (Average, first and last value)
        /// </summary>
        public void UpDateDescriptorStatistics()
        {
            // this.HistoBins = 1;
            // this.AverageValue = Value;


            //FirstValue = HistoValues[0];
            //  LastValue = HistoValues[HistoValues.Count - 1];
        }


        #endregion

       // private double AverageValue;

        //  private double FirstValue = -1;
        // private double LastValue = -1;

        private double[] OriginalValues = null;

        public double[] GetOriginalValues()
        {
            if ((CurrentScreening.GlobalInfo.CellByCellDataAccessMode == eCellByCellDataAccess.MEMORY) && (this.OriginalValues != null))
            {
                return this.OriginalValues;
            }
            else if (CurrentScreening.GlobalInfo.CellByCellDataAccessMode == eCellByCellDataAccess.HD)
            {
                AssociatedWell.AssociatedPlate.DBConnection = new cDBConnection(AssociatedWell.AssociatedPlate, AssociatedWell.SQLTableName);
                cExtendedList ToReturn = AssociatedWell.AssociatedPlate.DBConnection.GetWellValues(AssociatedWell.SQLTableName, this.GetAssociatedType());
                AssociatedWell.AssociatedPlate.DBConnection.DB_CloseConnection();
                return ToReturn.ToArray();
            }
            return null;
        }

        //private double getAverageValue(float[] Data)
        //{
        //    double Res = 0;
        //    for (int i = 0; i < Data.Length; i++)
        //        Res += Data[i];

        //    return Res / (double)(Data.Length);
        //}

        //private cExtendedList CreateHistogram(double[] data, double start, double end, double step)
        //{
        //    int HistoSize = (int)((end - start) / step) + 1;

        //    double[] histogram = new double[HistoSize];
        //    double RealPos = start;

        //    int PosHisto;
        //    foreach (double f in data)
        //    {
        //        PosHisto = (int)((f - start) / step);
        //        if ((PosHisto >= 0) && (PosHisto < HistoSize))
        //            histogram[PosHisto]++;
        //    }

        //    return histogram;
        //}

        //private cExtendedList CreateHistogram(float[] data, double start, double end, double step)
        //{
        //    int HistoSize = (int)((end - start) / step) + 1;


        //    double[] histogram = new double[HistoSize];
        //    double RealPos = start;

        //    int PosHisto;
        //    foreach (float f in data)
        //    {
        //        PosHisto = (int)((f - start) / step);
        //        if ((PosHisto >= 0) && (PosHisto < HistoSize))
        //            histogram[PosHisto]++;
        //    }

        //    return histogram;
        //}

        //private double getAverageValue(double[] Data)
        //{
        //    double Res = 0;
        //    for (int i = 0; i < Data.Length; i++)
        //        Res += Data[i];

        //    return Res / (double)(Data.Length);
        //}




        /// <summary>
        /// Create a descriptor based on a list of value (typically an histogram)
        /// </summary>
        /// <param name="ListOriginalValues">Array of values</param>
        /// <param name="Name">Descriptor name</param>
        //public cDescriptor(double[] ListOriginalValues, cDescriptorsType Type)
        //{


        //    this.OriginalValues = new double[ListOriginalValues.Length];
        //    Array.Copy(ListOriginalValues, this.OriginalValues, OriginalValues.Length);

        //    this.Type = Type;

        //    double Max = ListOriginalValues[0];
        //    for (int i = 1; i < ListOriginalValues.Length; i++)
        //    {
        //        if (ListOriginalValues[i] > Max) Max = ListOriginalValues[i];
        //    }

        //    this.FirstValue = 0;
        //    this.LastValue = Max;

        //    HistoValues = this.CreateHistogram(ListOriginalValues, 0, Max, Type.GetBinNumber());

        //    AverageValue = getAverageValue(ListOriginalValues);
        //    //  if (HistoValues.Length == 1) IsSingle = true;
        //    // else IsSingle = false;
        //}

        /// <summary>
        /// Create a descritpor based on a single value
        /// </summary>
        /// <param name="Value">Descritpor value</param>
        /// <param name="Name">Descritpor name</param>
        public cDescriptor(double Value, cDescriptorsType Type, cScreening CurrentScreening)
        {
            this.CurrentScreening = CurrentScreening;
            this.Type = Type;
            this.Histogram = new cHisto(Value);
            this.HistoBins = 1;
            this.AverageValue = Value;

            this.CellNumber = 0;
            //this.FirstValue = this.LastValue = this.AverageValue = this.HistoValues[0] = Value;

            if (CurrentScreening.GlobalInfo.CellByCellDataAccessMode == eCellByCellDataAccess.MEMORY)
            {
                  this.OriginalValues = new double[1];
                  this.OriginalValues[0] = Value;
            }
        }



        public int CellNumber { get; private set; }

        public cDescriptor(cExtendedList Values, int Bin, cDescriptorsType Type, cScreening CurrentScreening)
        {
            this.CurrentScreening = CurrentScreening;
            this.Type = Type;
            this.HistoBins = Bin;
            this.Histogram = new cHisto(Values, HistoBins);

            this.HistoBins = this.Histogram.GetXvalues().Count;
            this.AverageValue = Values.Mean();
            this.CellNumber = Values.Count;

            if (CurrentScreening.GlobalInfo.CellByCellDataAccessMode == eCellByCellDataAccess.MEMORY)
            {
                this.OriginalValues = new double[Values.Count];
                Array.Copy(Values.ToArray(), this.OriginalValues, this.OriginalValues.Length);
            }

            //this.FirstValue = FirstValue;
            // this.LastValue = LastValue;

            //this.HistoValues = new cExtendedList();

            //this.HistoValues.AddRange(HistoGram);

            //if (HistoGram.Length < Type.GetBinNumber())
            //{
            //    for (int i = 0; i < Type.GetBinNumber() - HistoGram.Length; i++)
            //        this.HistoValues.Add(0);
            //}


            //    new double[HistoGram.Length];
            //Array.Copy(HistoGram, this.HistoValues, HistoGram.Length);
            //this.Name = Name;
            //AverageValue = getAverageValue(HistoGram);
            //  if (HistoGram.Length == 1) IsSingle = true;
            //  else IsSingle = false;
        }

    }
}
