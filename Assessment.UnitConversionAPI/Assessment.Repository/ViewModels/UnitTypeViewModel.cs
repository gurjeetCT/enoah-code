using System.ComponentModel.DataAnnotations;

namespace Assessment.Repository.ViewModels
{
    public class UnitTypeViewModel
    {   
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeDescription { get; set; }               
    }
}