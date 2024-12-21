using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class UnitTypes
    {
        [Key]
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeDescription { get; set; }          
        public ICollection<UnitDetails> unitDetails { get; set; }//collection navigation 
        //property to represent one -to - many
    }
}