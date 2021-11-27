using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseContext;
using ECommerce.BLL.Interface;
using ECommerce.DTO.DTO;
using ECommerce.DTO.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Business_Logic
{
    public class CityBLLManager : ICityBLLManager
    {
        private readonly ContextClass _context;
        private readonly IMapper _mapper;

        public CityBLLManager(ContextClass context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> UpsertCity(CityViewModel model)
        {
            City city;
            city = await _context.City.FirstOrDefaultAsync(p => p.Id == p.Id);
            model.CityName = model.CityName.Trim();
            if (city == null)
            {
                city = new City();
                city.CreatedBy = "Bappy";
                city.CreatedDate = DateTime.UtcNow;
                city.Status = (int)Common.Enum.Enum.AvailableStatus.Active;
                await _context.City.AddAsync(city);
            }

            if( _context.City.Any(p=>p.CityName.ToLower()==model.CityName.ToLower() && p.Id!=model.Id))
                throw new DuplicateWaitObjectException("Name", model.CityName);

            city = _mapper.Map((CityViewModel)model, city);
            await _context.SaveChangesAsync();
            return city.Id;

        }


        //public async Task<List<CityViewModel>> GetAll()
        //{
        //    List<CityViewModel> city =await _context.City.AsQueryable()
        //        .ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
        //        .ToListAsync();
        //    return city;
        //}

        public async Task<IEnumerable<CityViewModel>> GetAllActiveCity()
        {
            IEnumerable<CityViewModel> models =await _context.City.Where(p => p.Status == (int)Common.Enum.Enum.AvailableStatus.Active)
                .ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return models;


        }

        public async Task<IEnumerable<CityViewModel>> GetAllCity()
        {
            IEnumerable<CityViewModel> models = await _context.City.ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync();
            return models;
        }

        public async Task<IEnumerable<CityViewModel>> GetAllInActiveCity()
        {
            IEnumerable<CityViewModel> models = await _context.City.Where(p=>p.Status==(int)Common.Enum.Enum.AvailableStatus.Inactive)
                .ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
              .ToListAsync();
            return models;
        }

 
    }
}
