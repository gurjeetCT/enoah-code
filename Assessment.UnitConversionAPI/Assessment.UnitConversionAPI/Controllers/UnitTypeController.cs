using Assessment.Models;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitTypeController : ControllerBase
    {

        private readonly ILogger<UnitTypeController> _logger;
        private readonly IUnitTypeRepository _unitTypeRepository;
        public UnitTypeController(ILogger<UnitTypeController> logger, IUnitTypeRepository unitTypeRepository)
        {
            _logger = logger; _unitTypeRepository = unitTypeRepository;

        }

        [HttpGet(Name = "GetAllUnitTypes")]
        public IEnumerable<UnitTypeViewModel> Get()
        {
            return _unitTypeRepository.GetAllAsync();
        }

        [HttpPost("AddUnitTypes")]
        public async Task<IActionResult> InsertUnitTypes(UnitTypeViewModel requestDto)
        {
            var response = await _unitTypeRepository.AddAsync(requestDto);
            return Ok(response);
        }
        [HttpPost("UpdateUnitTypes")]
        public async Task<IActionResult> UpdateUnitTypes(UnitTypeViewModel requestDto)
        {
            var response = await _unitTypeRepository.UpdateAsync(requestDto);
            return Ok(response);
        }
    }
}
