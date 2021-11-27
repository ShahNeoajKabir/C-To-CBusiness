using AutoMapper;
using ECommerce.DTO.DTO;
using ECommerce.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            CreateMap<Division, DivisionViewModel>()
                .ForMember(des => des.CountryName, opt => opt.MapFrom(p => p.Country.CountryName));
            CreateMap<DivisionViewModel,Division>();

            CreateMap<City, CityViewModel>()
                .ForMember(des => des.DivisionName, opt => opt.MapFrom(x => x.Division.DivisionName))
                .ForMember(des => des.CountryName, opt => opt.MapFrom(x => x.Division.Country.CountryName));
            CreateMap<CityViewModel, City>();
        }
    }
}
