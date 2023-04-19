using csharp_simple_webapi.Main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace csharp_simple_webapi.Main.Controllers
{
    //[Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ProductContext _context;

        public ProductsController(ProductContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;

            if (_context.Products.Any()) return;

            ProductSeed.InitializeData(context);
            _logger = logger;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Product>> GetProducts(ProductRequest productRequest)
        {
            var result = _context.Products as IQueryable<Product>;
            //Response.Headers["x-total-count"] = result.Count().ToString();
            return Ok(result
              .OrderBy(p => p.ProductNumber)
              .Skip(productRequest.Offset)
              .Take(productRequest.Limit));
        }
        //[Route("{productNumber}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProductByProductNumber([FromRoute] string productNumber)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductNumber.Equals(productNumber, StringComparison.InvariantCultureIgnoreCase));

            if (product == null) return NotFound();

            return Ok(product);
        }
        //new item
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return new CreatedResult($"/products/{product.ProductNumber.ToLower()}", product);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Unable to POST product.");

                return ValidationProblem(e.Message);
            }
        }
        //update item
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> PutProduct([FromBody] Product product)
        {
            try
            {
                var db = _context.Products
                  .FirstOrDefault(p => p.ProductNumber.Equals(product.ProductNumber,
                       StringComparison.InvariantCultureIgnoreCase));

                if (db == null) return NotFound();

                db.Name = product.Name;
                db.Price = product.Price;
                db.Department = product.Department;
                _context.SaveChanges();

                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Unable to PUT product.");

                return ValidationProblem(e.Message);
            }
        }
        [HttpDelete]
        [Route("{productNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> DeleteProduct([FromRoute] string productNumber)
        {
            var productDb = _context.Products.FirstOrDefault(p => p.ProductNumber.Equals(productNumber,StringComparison.InvariantCultureIgnoreCase));

            if (productDb == null) return NotFound();

            _context.Products.Remove(productDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
