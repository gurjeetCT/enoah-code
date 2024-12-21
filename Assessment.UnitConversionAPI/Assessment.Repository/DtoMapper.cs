using Assessment.Models;
using Assessment.Repository.ViewModels;
using AutoMapper;

namespace Assessment.Repository
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            this.CreateMap<UnitTypeViewModel, UnitTypes>();
            this.CreateMap<UnitTypes, UnitTypeViewModel>();
            this.CreateMap<UnitDetailsViewModel, UnitDetails>();
            this.CreateMap<UnitDetails, UnitDetailsViewModel>()
                .ForMember(res => res.UnitTypeName, opt => opt.MapFrom(src =>
                src.UnitType.UnitTypeName));

            //this.CreateMap<ConversionViewModel, UnitConversionRates>();
            //this.CreateMap<UnitConversionRates, ConversionViewModel>()
            //    .ForMember(res => res.SourceUnitName, opt => opt.MapFrom(src =>
            //    src.Source.UnitName))
            //    .ForMember(res => res.TargetUnitName, opt => opt.MapFrom(src =>
            //    src.Target.UnitName));

            this.CreateMap<ConversionHistory, ConversionHistoryViewModel>();

        }
    }
}

