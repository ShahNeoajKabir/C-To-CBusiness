using Ecommerce.BLL.Interface;
using ECommerce.DTO.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.Controllers
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBLLManager _bLLManager;

        public CountryController(ICountryBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        public async Task<ActionResult>Upsert(CountryViewModel viewModel)
        {
            try
            {
                var res = await _bLLManager.UpsertCountry(viewModel);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
