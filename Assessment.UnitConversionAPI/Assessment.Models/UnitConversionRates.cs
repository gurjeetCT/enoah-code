using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class UnitConversionRates
    {
        public int UnitConversionRatesId { get; set; }        
        public int SourceUnitDetailsId { get; set; }
        public int TargetUnitDetailsId { get; set; }
        //Conversion Factor is multiplied to SourceUnit to get TargetUnit
        public double ConversionFactor { get; set; }
        public UnitDetails Source { get; set; }
        public UnitDetails Target { get; set; }       
    }
}
