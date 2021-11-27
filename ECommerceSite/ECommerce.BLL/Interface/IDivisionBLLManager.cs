using ECommerce.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interface
{
    public interface IDivisionBLLManager
    {
        Task<int> UpsertDivision(DivisionViewModel model);
        Task<List<DivisionViewModel>> GetAllDivision();
        Task<List<DivisionViewModel>> GetAllActiveDivision();
        Task<List<DivisionViewModel>> GetAllInActiveDivision();

    }
}
