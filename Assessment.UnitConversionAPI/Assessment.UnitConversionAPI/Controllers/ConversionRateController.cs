using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionRateController : ControllerBase
    {

        private readonly ILogger<ConversionRateController> _logger;
        private readonly IUnitConversionRepository _unitconversionRepository;
        public ConversionRateController(ILogger<ConversionRateController> logger, IUnitConversionRepository unitconversionRepository)
        {
            _logger = logger; _unitconversionRepository = unitconversionRepository;

        }

        [HttpGet(Name = "GetAllConversionFactors")]
        public IEnumerable<ConversionViewModel> Get()
        {
            return _unitconversionRepository.GetAllAsync();
        }

        [HttpPost("AddConversions")]
        public async Task<IActionResult> InsertConversions(ConversionViewModel requestDto)
        {
            var response = await _unitconversionRepository.AddAsync(requestDto);
            return Ok(response);
        }
        
    }
}
