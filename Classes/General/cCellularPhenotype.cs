using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;
using System.Drawing;

namespace HCSAnalyzer.Classes.General
{
    public class cCellularPhenotype : cGeneralComponent
    {
        public Color ColourForDisplay;
        public string Name;
        public int Idx { get; private set; }
        


        public cCellularPhenotype(Color Colour, int Idx)
        {
            this.ColourForDisplay = Colour;
            this.Name = "Phenotype " + Idx;
            this.Idx = Idx;
        }
    }

}
