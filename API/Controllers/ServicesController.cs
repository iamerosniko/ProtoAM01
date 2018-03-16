using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private readonly AMContext _context;

        public ServicesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public IEnumerable<AM_Service> GetServices()
        {
            return _context.Services;
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_Service([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Service = await _context.Services.SingleOrDefaultAsync(m => m.ServiceID == id);

            if (aM_Service == null)
            {
                return NotFound();
            }

            return Ok(aM_Service);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_Service([FromRoute] int id, [FromBody] AM_Service aM_Service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_Service.ServiceID)
            {
                return BadRequest();
            }

            _context.Entry(aM_Service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_ServiceExists(id))
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

        // POST: api/Services
        [HttpPost]
        public async Task<IActionResult> PostAM_Service([FromBody] AM_Service aM_Service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_Service.ServiceID = 0;

            _context.Services.Add(aM_Service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_Service", new { id = aM_Service.ServiceID }, aM_Service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_Service([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Service = await _context.Services.SingleOrDefaultAsync(m => m.ServiceID == id);
            if (aM_Service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(aM_Service);
            await _context.SaveChangesAsync();

            return Ok(aM_Service);
        }

        private bool AM_ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceID == id);
        }
    }
}