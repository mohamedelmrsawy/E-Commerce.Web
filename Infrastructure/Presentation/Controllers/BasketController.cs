using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string Key)
        {
            var basket =await _serviceManager.basketService.GetBasketAsync(Key);
            return Ok(basket);
        }

        [HttpPost]

        public async Task<ActionResult<BasketDto>> CreateOrUpdatr(BasketDto basket)
        {
            var Basket =await _serviceManager.basketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }

        [HttpDelete("{Key}")]

        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {
            var result =await _serviceManager.basketService.DeletedBasketAsync(Key);
            return Ok(result);
        }

    }
}
