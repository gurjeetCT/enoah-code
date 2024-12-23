using Assessment.Models;
using Assessment.Models.Data;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assessment.Repository.Implementation
{
    public class UnitDetailsRepository : BaseRepository, IUnitDetailsRepository
    {
        private readonly UnitConversionDbContext _dbContext;

        public UnitDetailsRepository(UnitConversionDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<UnitDetailsViewModel> AddAsync(UnitDetailsViewModel details)
        {
            var existingUnit = await _dbContext.UnitDetails.FirstOrDefaultAsync(t => t.UnitName == details.UnitName && t.UnitTypeId == details.UnitTypeId);
            if (existingUnit != null && existingUnit.UnitDetailsId > 0)
                throw new BusinessException("Unit already exists");

            var entity = _mapper.Map<UnitDetails>(details);
            await _dbContext.UnitDetails.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            details.UnitDetailsId = entity.UnitDetailsId;
            return details;
        }

        public async Task DeleteAsync(int Id)
        {
            var item = await _dbContext.UnitDetails.FindAsync(Id);
            _dbContext.UnitDetails.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<UnitDetailsViewModel> GetAllAsync(int unitTypeId)
        {
            var dbResponse = _dbContext.UnitDetails.Where(t => t.UnitTypeId == unitTypeId || unitTypeId == 0).Include(e => e.UnitType).ToList();
            return _mapper.Map<List<UnitDetailsViewModel>>(dbResponse);
        }

        public async Task<UnitDetailsViewModel> GetByIdAsync(int Id)
        {
            var item = await _dbContext.UnitDetails.Include(e => e.UnitType).FirstOrDefaultAsync(t => t.UnitDetailsId == Id);
            var mappedItem = _mapper.Map<UnitDetailsViewModel>(item);
            return mappedItem;
        }

        public async Task<UnitDetailsViewModel> UpdateAsync(UnitDetailsViewModel unit)
        {
            var existingUnit = await _dbContext.UnitDetails.FindAsync(unit.UnitDetailsId);
            if (existingUnit == null || existingUnit.UnitTypeId == 0)
                throw new Exception("No Record Exists");

            existingUnit.UnitShortName = unit.UnitShortName;
            existingUnit.UnitName = unit.UnitName;
            existingUnit.NumberOfBaseUnits = unit.NumberOfBaseUnits;
            _dbContext.UnitDetails.Update(existingUnit);
            await _dbContext.SaveChangesAsync();
            return unit;
        }
    }
}
