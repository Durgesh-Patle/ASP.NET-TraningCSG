using JoinsSqlWebApi.Inteface;
using JoinsSqlWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinsSqlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _products;

        public ProductsController(IProduct product)
        {
            _products = product;
        }

        [HttpGet("GetProducts")]
        public async Task<List<Products>> GetProducts()
        {
             return await _products.GetProductsAsync();
        }

    }
}
