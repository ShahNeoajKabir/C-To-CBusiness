
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseContext;
using Ecommerce.BLL.Interface;
using ECommerce.DTO.DTO;
using ECommerce.DTO.View_Model;
using ECommerce.DTO.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Business_Logic
{
    public class CountryBLLManager : ICountryBLLManager
    {
        private readonly ContextClass _contextClass;
        private readonly IMapper _mapper;

        public CountryBLLManager(ContextClass contextClass, IMapper mapper)
        {
            _contextClass = contextClass;
            _mapper = mapper;
        }

        public async Task<int> UpsertCountry(CountryViewModel viewModel)
        {
            Country country ;
            viewModel.CountryName = viewModel.CountryName.Trim();
            country = await _contextClass.Country.FirstOrDefaultAsync(p => p.Id == viewModel.Id);
            if (country == null)
            {
                country = new Country();
                country.CreatedBy = "Bappy";
                country.CreatedDate = DateTime.UtcNow;
                await _contextClass.Country.AddAsync(country);
            }

            if (_contextClass.Country.Any(a => a.CountryName.ToLower() == viewModel.CountryName.ToLower() && a.Id != viewModel.Id))
                throw new DuplicateWaitObjectException("Name", viewModel.CountryName);
            country = _mapper.Map((CountryViewModel)viewModel, country);
            await _contextClass.SaveChangesAsync();
            return country.Id;
        }
        public async Task<List<CountryViewModel>> GetAllActiveCountry()
        {
            List<CountryViewModel> countryViewModels = await _contextClass.Country.Where(p=>p.Status==(int)ECommerce.Common.Enum.Enum.AvailableStatus.Active)
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return countryViewModels;
        }
        public async Task<List<CountryViewModel>> GetAllInActiveCountry()
        {
            List<CountryViewModel> countryViewModels = await _contextClass.Country.Where(p => p.Status == (int)ECommerce.Common.Enum.Enum.AvailableStatus.Inactive)
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return countryViewModels;
        }
        public async Task<List<CountryViewModel>> GetAllCountry()
        {
            List<CountryViewModel> countryViewModels = await _contextClass.Country
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return countryViewModels;
        }

        public Task<bool> IsExits(string CountryName)
        {
            return _contextClass.Country.AnyAsync(p => p.CountryName == CountryName);
        }

     
    }
}
