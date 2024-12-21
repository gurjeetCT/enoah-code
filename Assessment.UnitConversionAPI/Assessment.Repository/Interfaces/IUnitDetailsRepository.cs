using Assessment.Models;
using Assessment.Repository.ViewModels;

namespace Assessment.Repository.Interfaces
{
    public interface IUnitDetailsRepository
    {
        Task<UnitDetailsViewModel> GetByIdAsync(int id);
        IEnumerable<UnitDetailsViewModel> GetAllAsync(int unitTypeId);
        Task<UnitDetailsViewModel> AddAsync(UnitDetailsViewModel unit);
        Task<UnitDetailsViewModel> UpdateAsync(UnitDetailsViewModel unit);
        Task DeleteAsync(int Id);
    }    
}
