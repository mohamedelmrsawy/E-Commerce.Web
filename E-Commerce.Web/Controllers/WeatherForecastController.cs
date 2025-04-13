using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{id}")]

        // Get : BaseUrl/Product/10
        public ActionResult<Product> Get(int id)
        {
            return new Product() { Id = id };
        }



        [HttpGet]
        // Get : BaseUrl/Product
        public ActionResult<Product> Get()
        {
            return new Product() { Id = 100 };
        }


        [HttpPost]
        // Get : BaseUrl/Product
        public ActionResult<Product> AddProduct(Product product)
        {
            return new Product();
        }


        [HttpPut]
        // Get : BaseUrl/Product
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return new Product();
        }


        [HttpDelete]
        // Get : BaseUrl/Product
        public ActionResult<Product> DeleteProduct(Product product)
        {
            return new Product();
        }
    }
}
