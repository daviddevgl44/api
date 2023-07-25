using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DfvApiPrueba.Models;

namespace DfvApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly dfv2Context _context;

        public ArticleController(dfv2Context context)
        {
            _context = context;
        }

        // GET: api/Article
        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetProducts()
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }

            //return await _context.Articles.ToListAsync();
            return _context.Articles
                .FromSqlRaw($"exec Glapp_SP_DrugsDeliveryConsumerViewArticles 'admin'")
                .ToList();
            
           /* 
                return _context.Articles
          .FromSqlRaw($"SELECT TOP (1) venfac,codcli FROM acccccxc")
          .ToList();
           */

            //_context.Articles.FromSqlRaw("SELECT * FROM products").ToList();
        }

        /*
        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Articles == null)
          {
              return NotFound();
          }
            var product = await _context.Articles.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.IdColumn)
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

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Articles == null)
          {
              return Problem("Entity set 'dfv2Context.Articles'  is null.");
          }
            _context.Articles.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.IdColumn }, product);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Articles == null)
            {
                return NotFound();
            }
            var product = await _context.Articles.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Articles?.Any(e => e.IdColumn == id)).GetValueOrDefault();
        }
        */
    }
}
