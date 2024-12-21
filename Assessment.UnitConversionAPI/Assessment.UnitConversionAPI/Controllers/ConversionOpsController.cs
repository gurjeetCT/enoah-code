using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionOpsController : ControllerBase
    {

        private readonly ILogger<ConversionOpsController> _logger;
        private readonly IConversionHistoryRepository _conversionHistoryRepository;
        public ConversionOpsController(ILogger<ConversionOpsController> logger, IConversionHistoryRepository conversionHistoryRepository)
        {
            _logger = logger; _conversionHistoryRepository = conversionHistoryRepository;

        }

        [HttpGet(Name = "GetConversionHistory")]
        public IEnumerable<ConversionHistoryViewModel> Get()
        {
            return _conversionHistoryRepository.GetAllAsync();
        }

        [HttpPost("AddConversions")]
        public async Task<IActionResult> InsertConversions(ConversionOperationModel requestDto)
        {
            var response = await _conversionHistoryRepository.AddAsync(requestDto);
            return Ok(response);
        }
        
    }
}
