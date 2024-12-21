using Assessment.Models;
using Assessment.Repository.ViewModels;

namespace Assessment.Repository.Interfaces
{
    public interface IUnitConversionRepository
    {
        Task<ConversionViewModel> GetByIdAsync(int id);
        IEnumerable<ConversionViewModel> GetAllAsync();
        Task<ConversionViewModel> AddAsync(ConversionViewModel unit);
        Task<ConversionViewModel> UpdateAsync(ConversionViewModel unit);
    }    
}
