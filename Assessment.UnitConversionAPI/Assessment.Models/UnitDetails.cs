using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Models
{
    public class UnitDetails
    {
        public int UnitDetailsId { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        public string UnitShortName { get; set; }
        [Required]
        public double NumberOfBaseUnits { get; set; }
        [Required]
        [ForeignKey("UnitTypeId")]
        public int UnitTypeId { get; set; }
        public UnitTypes UnitType { get; set; }        
    }
}
