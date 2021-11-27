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
    public class DivisionBLLManager : IDivisionBLLManager
    {
        private readonly ContextClass _context;
        private readonly IMapper _mapper;

        public DivisionBLLManager( ContextClass context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> UpsertDivision(DivisionViewModel model)
        {
            Division division;
            model.DivisionName = model.DivisionName.Trim();
            division = await _context.Division.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (division == null)
            {
                division = new Division();
                division.CreatedBy = "Bappy";
                division.CreatedDate = DateTime.UtcNow;
                division.Status = (int)Common.Enum.Enum.AvailableStatus.Active;
                await _context.Division.AddAsync(division);
            }

            if(_context.Division.Any(p=>p.DivisionName.ToLower()==model.DivisionName.ToLower() 
            && p.Id !=model.Id ))
                throw new DuplicateWaitObjectException("Division Name", model.DivisionName);

            division = _mapper.Map((DivisionViewModel)model, division);
            await _context.SaveChangesAsync();
            return division.Id;

        }
        public async Task<List<DivisionViewModel>> GetAllActiveDivision()
        {
            List<DivisionViewModel> divisions = await _context.Division.
                Where(p => p.Status == (int)Common.Enum.Enum.AvailableStatus.Active)
                .ProjectTo<DivisionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return divisions;
        }

        public async Task<List<DivisionViewModel>> GetAllDivision()
        {
            List<DivisionViewModel> divisions = await _context.Division
                .ProjectTo<DivisionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return divisions;
        }

        public async Task<List<DivisionViewModel>> GetAllInActiveDivision()
        {
            List<DivisionViewModel> divisions = await _context.Division.
                 Where(p => p.Status == (int)Common.Enum.Enum.AvailableStatus.Inactive)
                 .ProjectTo<DivisionViewModel>(_mapper.ConfigurationProvider)
                 .ToListAsync();
            return divisions;
        }

      
    }
}
