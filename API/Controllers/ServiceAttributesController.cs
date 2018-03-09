using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/ServiceAttributes")]
    public class ServiceAttributesController : Controller
    {
        private readonly AMContext _context;

        public ServiceAttributesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/ServiceAttributes
        [HttpGet]
        public IEnumerable<AM_ServiceAttribute> GetServiceAttribute()
        {
            return _context.ServiceAttribute;
        }

        // GET: api/ServiceAttributes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_ServiceAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_ServiceAttribute = await _context.ServiceAttribute.SingleOrDefaultAsync(m => m.ServiceAttributeID == id);

            if (aM_ServiceAttribute == null)
            {
                return NotFound();
            }

            return Ok(aM_ServiceAttribute);
        }

        // PUT: api/ServiceAttributes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_ServiceAttribute([FromRoute] int id, [FromBody] AM_ServiceAttribute aM_ServiceAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_ServiceAttribute.ServiceAttributeID)
            {
                return BadRequest();
            }

            _context.Entry(aM_ServiceAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_ServiceAttributeExists(id))
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

        // POST: api/ServiceAttributes
        [HttpPost]
        public async Task<IActionResult> PostAM_ServiceAttribute([FromBody] AM_ServiceAttribute aM_ServiceAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceAttribute.Add(aM_ServiceAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_ServiceAttribute", new { id = aM_ServiceAttribute.ServiceAttributeID }, aM_ServiceAttribute);
        }

        // DELETE: api/ServiceAttributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_ServiceAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_ServiceAttribute = await _context.ServiceAttribute.SingleOrDefaultAsync(m => m.ServiceAttributeID == id);
            if (aM_ServiceAttribute == null)
            {
                return NotFound();
            }

            _context.ServiceAttribute.Remove(aM_ServiceAttribute);
            await _context.SaveChangesAsync();

            return Ok(aM_ServiceAttribute);
        }

        private bool AM_ServiceAttributeExists(int id)
        {
            return _context.ServiceAttribute.Any(e => e.ServiceAttributeID == id);
        }
    }
}