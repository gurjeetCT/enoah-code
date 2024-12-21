using Assessment.Models;
using Assessment.Repository.ViewModels;

namespace Assessment.Repository.Interfaces
{
    public interface IConversionHistoryRepository
    {        
        IEnumerable<ConversionHistoryViewModel> GetAllAsync();
        Task<ConversionHistoryViewModel> AddAsync(ConversionOperationModel history);
    }    
}
