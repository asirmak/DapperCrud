using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());    
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productService.Add(product);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpGet("getbyid")]
        public ActionResult Get(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpPut("update")]
        public ActionResult Put(Product product)
        {
            _productService.Update(product);
            return Ok();
        }


    }
}
