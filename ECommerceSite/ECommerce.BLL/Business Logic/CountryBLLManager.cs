
using AutoMapper;
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
            country = await _contextClass.Country.FirstOrDefaultAsync(p => p.Id == viewModel.Id);
            if (country == null)
            {
                country = new Country();
                country.CreatedBy = "Bappy";
                country.CreatedDate = DateTime.UtcNow;
                await _contextClass.Country.AddAsync(country);
            }

            country = _mapper.Map((CountryViewModel)viewModel, country);
            await _contextClass.SaveChangesAsync();
            return country.Id;
        }
        public async Task<List<CountryViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExits(string CountryName)
        {
            return _contextClass.Country.AnyAsync(p => p.CountryName == CountryName);
        }

     
    }
}
