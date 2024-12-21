using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Repository.ViewModels
{
    public class ConversionViewModel
    {
        public int UnitConversionRatesId { get; set; }        
        public int SourceUnitDetailsId { get; set; }
        public string SourceUnitName { get; set; }
        public int TargetUnitDetailsId { get; set; }
        public string TargetUnitName { get; set; }
        public double ConversionFactor { get; set; }
              
    }
}
