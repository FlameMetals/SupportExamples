using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FFM.DataAccess.App;
using FFM.DataAccessModels.App;

namespace FFM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderParts1Controller : ControllerBase
    {
        private readonly FFM_DbContext _context;

        public orderParts1Controller(FFM_DbContext context)
        {
            _context = context;
        }

        // GET: api/orderParts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<orderParts>>> GetorderParts()
        {
            return await _context.orderParts.ToListAsync();
        }

        // GET: api/orderParts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<orderParts>> GetorderParts(Guid id)
        {
            var orderParts = await _context.orderParts.FindAsync(id);

            if (orderParts == null)
            {
                return NotFound();
            }

            return orderParts;
        }

        // PUT: api/orderParts1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutorderParts(Guid id, orderParts orderParts)
        {
            if (id != orderParts.id)
            {
                return BadRequest();
            }

            _context.Entry(orderParts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderPartsExists(id))
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

        // POST: api/orderParts1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<orderParts>> PostorderParts(orderParts orderParts)
        {
            _context.orderParts.Add(orderParts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetorderParts", new { id = orderParts.id }, orderParts);
        }

        // DELETE: api/orderParts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteorderParts(Guid id)
        {
            var orderParts = await _context.orderParts.FindAsync(id);
            if (orderParts == null)
            {
                return NotFound();
            }

            _context.orderParts.Remove(orderParts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool orderPartsExists(Guid id)
        {
            return _context.orderParts.Any(e => e.id == id);
        }
    }
}
