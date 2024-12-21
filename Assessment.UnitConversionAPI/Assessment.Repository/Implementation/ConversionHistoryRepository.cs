using Assessment.Models;
using Assessment.Models.Data;
using Assessment.Repository.Interfaces;
using Assessment.Repository.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Assessment.Repository.Implementation
{
    public class ConversionHistoryRepository : BaseRepository, IConversionHistoryRepository
    {
        private readonly UnitConversionDbContext _dbContext;

        public ConversionHistoryRepository(UnitConversionDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<ConversionHistoryViewModel> AddAsync(ConversionOperationModel details)
        {
            var unitDetails = await _dbContext.UnitDetails.Where(t => t.UnitDetailsId == details.SourceUnitId || t.UnitDetailsId == details.TargetUnitId).ToListAsync();
            if (unitDetails != null && unitDetails.Count == 2 && unitDetails[0].UnitTypeId == unitDetails[1].UnitTypeId)
            {
                var unitType = await _dbContext.UnitTypes.FirstOrDefaultAsync(t => t.UnitTypeId == unitDetails[0].UnitTypeId);
                //var conversionRate = await _dbContext.ConversionRates.SingleOrDefaultAsync(t => t.SourceUnitDetailsId == details.SourceUnitId && t.TargetUnitDetailsId == details.TargetUnitId);
                var targetFactor = unitDetails.FirstOrDefault(t => t.UnitDetailsId == details.TargetUnitId);
                var sourceFactor = unitDetails.FirstOrDefault(t => t.UnitDetailsId == details.SourceUnitId);
                var entity = new ConversionHistory
                {
                    DerivedFactor = targetFactor.NumberOfBaseUnits / sourceFactor.NumberOfBaseUnits,
                    InputValue = details.InputValue,
                    OutputValue = (targetFactor.NumberOfBaseUnits / sourceFactor.NumberOfBaseUnits) * details.InputValue,
                    SourceUnitName = sourceFactor.UnitName,
                    TargetUnitName = targetFactor.UnitName,
                    UnitType = unitType.UnitTypeName,
                    UserName = details.UserName
                };
                await _dbContext.ConversionHistories.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                var retValue = _mapper.Map<ConversionHistoryViewModel>(entity);
                return retValue;
            }
            throw new BusinessException("Source/Target Unit Not  Found");
        }

        public IEnumerable<ConversionHistoryViewModel> GetAllAsync()
        {
            var dbResponse = _dbContext.ConversionHistories.ToList();
            return _mapper.Map<List<ConversionHistoryViewModel>>(dbResponse);
        }
        public IEnumerable<ConversionHistoryViewModel> GetAllByUserNameAsync(string UserName)
        {
            //return _dbContext.ConversionHistories.Where(t => t.UserName == UserName).Include(e => e.ConversionRateUsed).ThenInclude(e => e.Source)
            //    .Include(t => t.ConversionRateUsed).ThenInclude(t => t.Target);

            var dbResponse = _dbContext.ConversionHistories.Where(t => t.UserName == UserName).ToList();
            return _mapper.Map<List<ConversionHistoryViewModel>>(dbResponse);
        }
    }
}
