
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.ViewModels;
using ProductCatalog.Application.Interfaces.IUnitOfWorks;
using ProductCatalog.Domain;
using System;
using System.Collections.Generic;


namespace ProductCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery]string searchKey)
        {
            if (searchKey != null)
            {
            return Ok(_unitOfWork.Products.Get(x=>x.Name.ToLower().Contains(searchKey.ToLower())));

            }
            else
            {
                return Ok(_unitOfWork.Products.Get());
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct([FromRoute]int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var entity = _unitOfWork.Products.FindById(id);
            if (entity==null)
            {
                return NotFound();
            }

            return Ok(entity);
        }


        [HttpPost]
        public IActionResult PostProduct([FromBody]PostProductVM productVM)
        {

            var product = new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Photo = productVM.Photo,
                LastUpdated=productVM.LastUpdated
            };
             _unitOfWork.Products.Insert(product);
             _unitOfWork.Complete();
  

            return CreatedAtAction("GetProduct",new { id=product.Id},product);
        }


        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id,[FromBody] Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
           
            var entity = _unitOfWork.Products.FindById(id);

            if (entity == null)
            {
                return NotFound();
            }
            product.LastUpdated = DateTime.Now;
            _unitOfWork.Products.Update(product);

            _unitOfWork.Complete();


            return NoContent(); 

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var entity = _unitOfWork.Products.FindById(id);

            if (entity == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Delete(entity);

            _unitOfWork.Complete();

            return NoContent();

        }

       
    }
}
