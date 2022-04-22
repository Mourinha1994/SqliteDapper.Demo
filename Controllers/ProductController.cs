using Microsoft.AspNetCore.Mvc;
using SqliteDapper.Demo.Models;
using SqliteDapper.Demo.Providers;
using SqliteDapper.Demo.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductRepository _productRepository;
        public ProductController(IProductProvider productProvider, IProductRepository productRepository)
        {
            _productProvider = productProvider;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
            => await _productProvider.Get();

        [HttpPost]
        public async Task Post([FromBody] Product product)
            => await _productRepository.Create(product);
    }
}
