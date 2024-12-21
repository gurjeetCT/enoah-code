using Assessment.Models;
using Assessment.Models.Data;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assessment.Repository.Implementation
{
    public class UnitConversionRepository : BaseRepository, IUnitConversionRepository
    {
        private readonly UnitConversionDbContext _dbContext;

        public UnitConversionRepository(UnitConversionDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<ConversionViewModel> AddAsync(ConversionViewModel conversionRates)
        {
            var existingRate = await _dbContext.ConversionRates.FirstOrDefaultAsync(t => t.SourceUnitDetailsId == conversionRates.SourceUnitDetailsId && t.TargetUnitDetailsId == conversionRates.TargetUnitDetailsId);
            if (existingRate != null && existingRate.UnitConversionRatesId > 0)
                throw new Exception("Conversion already exists");

            var entity = _mapper.Map<UnitConversionRates>(conversionRates);
            await _dbContext.ConversionRates.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            conversionRates.UnitConversionRatesId = entity.UnitConversionRatesId;
            return conversionRates;
        }


        public IEnumerable<ConversionViewModel> GetAllAsync()
        {
            var dbResponse = _dbContext.ConversionRates.Include(e => e.Source).Include(e => e.Target).ToList();
            return _mapper.Map<List<ConversionViewModel>>(dbResponse);
        }

        public async Task<ConversionViewModel> GetByIdAsync(int Id)
        {
            var item = await _dbContext.ConversionRates.FindAsync(Id);
            return item;
        }

        public async Task<ConversionViewModel> UpdateAsync(ConversionViewModel unit)
        {
            var existingUnit = await _dbContext.ConversionRates.FindAsync(unit.UnitConversionRatesId);
            if (existingUnit == null || existingUnit.UnitConversionRatesId == 0)
                throw new Exception("No Record Exists");

            existingUnit.ConversionFactor = unit.ConversionFactor;
            _dbContext.ConversionRates.Update(existingUnit);
            await _dbContext.SaveChangesAsync();
            return unit;

        }
    }
}
