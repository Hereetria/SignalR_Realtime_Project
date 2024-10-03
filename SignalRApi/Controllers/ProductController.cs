using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL.Abstract;
using SignalRApi.DAL.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDal _productDal; 

        public ProductController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productDal.GetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productDal.Add(product);
            return Ok("Ürün başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productDal.GetById(id);
            _productDal.Delete(values);
            return Ok("Ürün alanı silindi");
        }

        [HttpPut]

        public IActionResult UpdateProduct(Product product)
        {
            _productDal.Update(product);
            return Ok("Ürün alanı başarıyla güncellendi");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetProduct(int id)
        {
            var values = _productDal.GetById(id);
            return Ok(values);
        }
    }
}
