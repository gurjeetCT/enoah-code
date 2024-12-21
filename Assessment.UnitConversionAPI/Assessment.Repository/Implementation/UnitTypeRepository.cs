using Assessment.Models;
using Assessment.Models.Data;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assessment.Repository.Implementation
{
    public class UnitTypeRepository : BaseRepository, IUnitTypeRepository
    {
        private readonly UnitConversionDbContext _dbContext;

        public UnitTypeRepository(UnitConversionDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<UnitTypeViewModel> AddAsync(UnitTypeViewModel unit)
        {
            var existingUnitType = await _dbContext.UnitTypes.FirstOrDefaultAsync(t => t.UnitTypeName == unit.UnitTypeName);
            if (existingUnitType != null && existingUnitType.UnitTypeId > 0)
                throw new BusinessException("Unit Type already exists");

            var entity = _mapper.Map<UnitTypes>(unit);
            await _dbContext.UnitTypes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            unit.UnitTypeId = entity.UnitTypeId;
            return unit;
        }

        public async Task DeleteAsync(int Id)
        {
            var item = await _dbContext.UnitTypes.FindAsync(Id);
            _dbContext.UnitTypes.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<UnitTypeViewModel> GetAllAsync()
        {
            var dbResponse = _dbContext.UnitTypes.ToList();
            return _mapper.Map<List<UnitTypeViewModel>>(dbResponse);
        }

        public async Task<UnitTypeViewModel> GetByIdAsync(int Id)
        {
            var item = await _dbContext.UnitTypes.FindAsync(Id);
            return _mapper.Map<UnitTypeViewModel>(item);
        }

        public async Task<UnitTypeViewModel> UpdateAsync(UnitTypeViewModel unit)
        {
            var existingUnit = await _dbContext.UnitTypes.FindAsync(unit.UnitTypeId);
            if (existingUnit == null || existingUnit.UnitTypeId == 0)
                throw new Exception("No Record Exists");
            existingUnit.UnitTypeDescription = unit.UnitTypeDescription;
            existingUnit.UnitTypeName = unit.UnitTypeName;
            _dbContext.UnitTypes.Update(existingUnit);
            await _dbContext.SaveChangesAsync();
            return unit;
        }
    }
}
