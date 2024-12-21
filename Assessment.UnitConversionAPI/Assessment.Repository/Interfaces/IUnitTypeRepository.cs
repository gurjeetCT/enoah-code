using Assessment.Models;
using Assessment.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Repository.Interfaces
{
    public interface IUnitTypeRepository
    {
        Task<UnitTypeViewModel> GetByIdAsync(int id);
        IEnumerable<UnitTypeViewModel> GetAllAsync();
        Task<UnitTypeViewModel> AddAsync(UnitTypeViewModel unit);
        Task<UnitTypeViewModel> UpdateAsync(UnitTypeViewModel unit);
        Task DeleteAsync(int Id);
    }    
}
