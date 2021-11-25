using ECommerce.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interface
{
    public interface ICountryBLLManager
    {
        Task<int> UpsertCountry(CountryViewModel viewModel);
        Task<List<CountryViewModel>> GetAllCountry();
        Task<List<CountryViewModel>> GetAllActiveCountry();
        Task<List<CountryViewModel>> GetAllInActiveCountry();
        Task<bool> IsExits(string CountryName);
    }
}
