using ECommerce.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interface
{
    public interface ICityBLLManager
    {
        Task<int> UpsertCity(CityViewModel model);
        Task<IEnumerable<CityViewModel>> GetAllCity();
        Task<IEnumerable<CityViewModel>> GetAllActiveCity();
        Task<IEnumerable<CityViewModel>> GetAllInActiveCity();
        //Task<CityViewModel> GetAll();
    }
}
