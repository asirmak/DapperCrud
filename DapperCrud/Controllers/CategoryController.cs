using Business.Abstract;
using Dapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            var categorias = _categoryService.GetAll();
            return Ok(categorias);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Ok();
        }

        [HttpGet("getbyid")]
        public ActionResult Get(int id)
        {
            return Ok(_categoryService.GetById(id));
        }

        [HttpPut("update")]
        public ActionResult Put(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(_categoryService.GetById(id));
            return Ok();
        }

    }
}
