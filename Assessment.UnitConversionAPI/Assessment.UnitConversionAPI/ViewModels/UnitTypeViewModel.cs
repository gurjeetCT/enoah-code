using System.ComponentModel.DataAnnotations;

namespace Assessment.UnitConversionAPI.ViewModels
{
    public class UnitTypeViewModel
    {   
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeDescription { get; set; }               
    }
}