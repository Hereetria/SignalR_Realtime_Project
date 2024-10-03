using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL.Abstract;
using SignalRApi.DAL.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryDal.GetListAll();
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryDal.CategoryCount());
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            return Ok(_categoryDal.GetActiveCategories());
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryDal.Add(category);
            return Ok("Kategori başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryDal.GetById(id);
            _categoryDal.Delete(values);
            return Ok("Kategori alanı silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryDal.GetById(id);
            return Ok(values);
        }
        [HttpPut]

        public IActionResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return Ok("Kategori alanı başarıyla güncellendi");
        }

    }
}
