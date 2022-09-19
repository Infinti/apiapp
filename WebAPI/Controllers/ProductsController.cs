using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //API isimleri çoğul verilir.
    [Route("api/[controller]")]
    [ApiController]//c#-->Attribute, java-->Annotation
    public class ProductsController : ControllerBase
    {
        //loosely coupled//soyuta bağlı gevşek bağ
        //müşteriler için özel servisler oluşturulur. if felan kullanılmaz
        //somut =efproductdal, manager gibi sınıflar
        //IoC Container --inversion of control
        IProductService _productService;//_ javada 'this' ile kullanma c# da '_'

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //hiç bir katman diğerini new'lemiyor yani bağımsız yapı
        //resolve yani çözümleme sınıfı newleme anlamına gelir
        [HttpGet("getall")]
        public IActionResult GetAll ()
        {
            var result=_productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
