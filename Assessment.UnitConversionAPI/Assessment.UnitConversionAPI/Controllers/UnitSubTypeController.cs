using Assessment.Models;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitSubTypeController : ControllerBase
    {

        private readonly ILogger<UnitSubTypeController> _logger;
        private readonly IUnitDetailsRepository _unitDtlsRepository;
        public UnitSubTypeController(ILogger<UnitSubTypeController> logger, IUnitDetailsRepository unitDtlsRepository)
        {
            _logger = logger; _unitDtlsRepository = unitDtlsRepository;

        }

        [HttpGet("GetAllUnitSubTypes/{unitTypeId}")]
        public IEnumerable<UnitDetailsViewModel> Get(int unitTypeId)
        {
            return _unitDtlsRepository.GetAllAsync(unitTypeId);
        }

        [HttpPost("AddUnitSubType")]
        public async Task<IActionResult> InsertUnitTypes(UnitDetailsViewModel requestDto)
        {
            var response = await _unitDtlsRepository.AddAsync(requestDto);
            return Ok(response);
        }
        [HttpPost("UpdateUnitSubTypes")]
        public async Task<IActionResult> UpdateUnitTypes(UnitDetailsViewModel requestDto)
        {
            var response = await _unitDtlsRepository.UpdateAsync(requestDto);
            return Ok(response);
        }
    }
}
