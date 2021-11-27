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
    [Route("api/Division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionBLLManager _bLLManager;

        public DivisionController(IDivisionBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        public async Task<ActionResult>Upsert(DivisionViewModel model)
        {
            var res = await _bLLManager.UpsertDivision(model);
            return Ok(res);
        }

        [HttpGet]

        public async Task<ActionResult<List<DivisionViewModel>>> GetAllDivision()
        {
            return Ok(await _bLLManager.GetAllDivision());
        }
    }
}
