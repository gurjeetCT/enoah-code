using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Repository.ViewModels
{
    public class UnitDetailsViewModel
    {
        public int UnitDetailsId { get; set; }
        [Required]
        public string UnitName { get; set; }
        public double NumberOfBaseUnits { get; set; }
        public string UnitShortName { get; set; }
        [Required]        
        public int UnitTypeId { get; set; }        
        public string? UnitTypeName { get; set; }
    }
}
