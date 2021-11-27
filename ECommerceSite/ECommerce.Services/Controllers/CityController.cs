using ECommerce.BLL.Interface;
using ECommerce.DTO.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.Controllers
{
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBLLManager _bLLManager;

        public CityController(ICityBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }
        [HttpPost]
        public async Task<ActionResult>Upsert(CityViewModel model)
        {
            var res = await _bLLManager.UpsertCity(model);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> GetAll()
        {
            return Ok(await _bLLManager.GetAllCity());
        }
    }
}
