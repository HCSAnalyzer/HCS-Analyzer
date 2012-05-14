using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Classes;

namespace LibPlateAnalysis
{

    public enum eDistances { EUCLIDEAN , MANHATTAN, VECTOR_COS, BHATTACHARYYA, EMD };

    public class cDescriptorsType
    {
        public bool IsConnectedToDatabase { get; private set;}


        public cDescriptorsType(string Name, bool IsActive, int BinNumber, bool IsConnectedToDB)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            this.IsConnectedToDatabase = IsConnectedToDB;
            CreateAssociatedWindow();
        }
        public cDescriptorsType(string Name, bool IsActive, int BinNumber)
        {
            //this.AssociatedcListDescriptors = AssociatedcListDescriptors;
            this.Name = Name;
            this.ActiveState = IsActive;
            this.NumBin = BinNumber;
            this.IsConnectedToDatabase = false;
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

        public string GetDataType()
        {
            if (NumBin == 1) return "Single";
            else
                return "Histogram - " + this.GetBinNumber() + " bins.";
        }

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

            return DescIndex;
        }

        public int GetDescriptorIndex(string DescriptorName)
        {
            int DescIndex = -1;
            foreach (cDescriptorsType TmpDescType in this)
            {
                DescIndex++;
                if (TmpDescType.GetName() == DescriptorName) return DescIndex;
            }


            return DescIndex;
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

        cDescriptorsType Type;

        private cScreening CurrentScreening;

        public cDescriptorsType GetAssociatedType()
        {
            return this.Type;
        }

        private cExtendedList HistoValues;

        private double ComputeDistributionDistanceToReference()
        {
            return 0;

        }

        #region public

        /// <summary>
        /// Return the value associated to a descriptor within a well
        /// </summary>
        /// <returns>if scalar mode: average else distance between histograms</returns>
        public double GetValue()
        {
            if (CurrentScreening.Reference == null)
            {
                if (Type.GetBinNumber() > 1)
                {
                    return HistoValues.GetWeightedMean();
                }
                else
                    return HistoValues.Mean();
            }
            else
            {
                if (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEuclidean.Checked)
                    return HistoValues.Dist_Euclidean(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                else if
                    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricManhattan.Checked)
                    return HistoValues.Dist_Manhattan(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                else if
                    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricCosine.Checked)
                    return HistoValues.Dist_VectorCosine(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                else if
                    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricBhattacharyya.Checked)
                    return HistoValues.Dist_BhattacharyyaCoefficient(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);
                else if
                    (CurrentScreening.GlobalInfo.OptionsWindow.radioButtonDistributionMetricEMD.Checked)
                    return HistoValues.Dist_EarthMover(CurrentScreening.Reference[CurrentScreening.ListDescriptors.IndexOf(Type)]);


                else return -1;
            }



        }

        public void SetHistoValues(List<double> ListValues)
        {
            HistoValues = new cExtendedList();
            HistoValues.AddRange(ListValues);

            UpDateDescriptorStatistics();

        }

        public void SetHistoValues(double Value)
        {
            HistoValues[0] = Value;
            UpDateDescriptorStatistics();

        }

        public void SetHistoValues(int Idx, double Value)
        {
            HistoValues[Idx] = Value;
            UpDateDescriptorStatistics();

        }

        public cExtendedList Getvalues()
        {
            return this.HistoValues;
        }

        public double Getvalue(int Idx)
        {
            return HistoValues[Idx];
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
            AverageValue = HistoValues.Mean();
            //FirstValue = HistoValues[0];
            //  LastValue = HistoValues[HistoValues.Count - 1];
        }


        #endregion

        private double AverageValue;

        //  private double FirstValue = -1;
        // private double LastValue = -1;

        private double[] OriginalValues = null;

        private double getAverageValue(float[] Data)
        {
            double Res = 0;
            for (int i = 0; i < Data.Length; i++)
                Res += Data[i];

            return Res / (double)(Data.Length);
        }

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

        private double getAverageValue(double[] Data)
        {
            double Res = 0;
            for (int i = 0; i < Data.Length; i++)
                Res += Data[i];

            return Res / (double)(Data.Length);
        }


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
            this.HistoValues = new cExtendedList();
            this.HistoValues.Add(Value);
            //this.FirstValue = this.LastValue = this.AverageValue = this.HistoValues[0] = Value;
        }

        public cDescriptor(double[] HistoGram, double FirstValue, double LastValue, cDescriptorsType Type, cScreening CurrentScreening)
        {
            this.CurrentScreening = CurrentScreening;
            this.Type = Type;

            //this.FirstValue = FirstValue;
            // this.LastValue = LastValue;

            this.HistoValues = new cExtendedList();

            this.HistoValues.AddRange(HistoGram);

            if (HistoGram.Length < Type.GetBinNumber())
            {
                for (int i = 0; i < Type.GetBinNumber() - HistoGram.Length; i++)
                    this.HistoValues.Add(0);
            }


            //    new double[HistoGram.Length];
            //Array.Copy(HistoGram, this.HistoValues, HistoGram.Length);
            //this.Name = Name;
            AverageValue = getAverageValue(HistoGram);
            //  if (HistoGram.Length == 1) IsSingle = true;
            //  else IsSingle = false;
        }

    }
}
