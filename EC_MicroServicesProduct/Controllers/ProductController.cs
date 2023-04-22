using EC_MicroServicesProduct.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EC_MicroServicesProduct.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("controller")]
    [ApiController]


    public class ProductController : Controller
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;
        public ProductController()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }



        List<Models.Product> Products = new List<Models.Product>
        {
            new Models.Product(){Id= 1, Title="Yacine", Description="Yaddaden", Prix=34f},
              new Models.Product(){Id= 2, Title = "Ousmen", Description = "yado", Prix=45f},
                new Models.Product(){Id= 3, Title = "Ahcene", Description = "BenAli", Prix = 33f}
        };
        [HttpGet]
        [Route("Products")]
        public IActionResult GetProduct()
        {
            try
            {
                return Ok(Products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Products/{Id}")]
        public IActionResult GetProduct(int productis)
        {
            try
            {
                Models.Product product = Products.Where(t => t.Id == productis).FirstOrDefault();
                if (product != null)
                {
                    return Ok(product);
                }
                else
                    return StatusCode((int)StatusCodes.Status400BadRequest, new { message = "produit n,existe pas" });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Product")]
        public IActionResult CreateProduct([FromForm] Models.ProductForm productform)
        {
            try
            {
                Products.Add(new Models.Product()
                {
                    Id = Products.Max(t => t.Id) + 1,
                    Title = productform.Title,
                    Description = productform.Description,
                    Prix = productform.Prix,

                });
                return StatusCode(StatusCodes.Status201Created, Products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Products/{Productid}")]
        public IActionResult UpdateProduct(int Productid, [FromForm]Models.ProductForm productForm)
        {
            try
            {
                Models.Product product = Products.Find(t => t.Id == Productid);
                if (product != null)
                {
                    product.Title = productForm.Title;
                    product.Prix = productForm.Prix;
                    product.Description = productForm.Description;

                    // db.save changes
                    return Ok(Products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "ce produit n'existe pas" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("Products/{productId}")]
        public IActionResult RemoveProduct(int productId)
        {
            try
            {
                Models.Product product = Products.Find(t => t.Id == productId);
                if (product != null)
                {
                    Products.Remove(product);
                    return Ok(Products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "ce produit n'existe pas" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

