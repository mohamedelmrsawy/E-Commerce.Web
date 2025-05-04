using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
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
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts(ProductQueryParams option)
        {
            var products = await _serviceManager.productService.GetAllProductsAsync(option);
            return Ok(products);
        } 






        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var products = await _serviceManager.productService.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetType()
        {
            var type = await _serviceManager.productService.GetAllTypesAsync();
            return Ok(type);
        }

        [HttpGet("brandes")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetBrandes()
        {
            var brande = await _serviceManager.productService.GetAllPrandsAsync();
            return Ok(brande);
        }

    }
}
