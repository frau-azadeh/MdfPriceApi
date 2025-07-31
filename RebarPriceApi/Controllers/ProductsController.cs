using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RebarPriceApi.Data;
using RebarPriceApi.Models;

namespace RebarPriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly RebarDbContext _context;

        public ProductsController(RebarDbContext context)
        {
            _context = context;
        }

        //  GET: api/Products 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .OrderByDescending(p => p.LastPriceDate)
                .ToListAsync();
        }

        //  GET: api/Products/latest 
        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<Product>>> GetLatestProducts()
        {
            var latestDate = await _context.Products.MaxAsync(p => p.LastPriceDate);
            var latestProducts = await _context.Products
                .Where(p => p.LastPriceDate == latestDate)
                .ToListAsync();

            return Ok(latestProducts);
        }



        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        // Python: api/products/analyze
        [HttpGet("analyze")]
        public async Task<IActionResult> AnalyzeProducts()
        {
            try
            {
                using var httpClient = new HttpClient();
                // python refer api
                var pythonApiUrl = "http://127.0.0.1:8000/analyze";

                var response = await httpClient.GetAsync(pythonApiUrl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطا در ارتباط با سرویس تحلیل: {ex.Message}");
            }
        }

        // python refer api analyze-latest
        [HttpGet("analyze-latest")]
        public async Task<IActionResult> AnalyzeLatestProducts()
        {
            try
            {
                using var httpClient = new HttpClient();
                
                var pythonApiUrl = "http://127.0.0.1:8000/analyze-latest";

                var response = await httpClient.GetAsync(pythonApiUrl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطا در ارتباط با سرویس تحلیل (آخرین رکورد): {ex.Message}");
            }
        }



    }
}
