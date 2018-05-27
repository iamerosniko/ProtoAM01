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
    [Route("api/RoleServices")]
    public class RoleServicesController : Controller
    {
        private readonly AMContext _context;

        public RoleServicesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/RoleServices
        [HttpGet]
        public IEnumerable<AM_RoleServices> GetRoleServices()
        {
            return _context.RoleServices;
        }

        // GET: api/RoleServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_RoleServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_RoleServices = await _context.RoleServices.SingleOrDefaultAsync(m => m.RoleServiceID == id);

            if (aM_RoleServices == null)
            {
                return NotFound();
            }

            return Ok(aM_RoleServices);
        }

        // PUT: api/RoleServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_RoleServices([FromRoute] int id, [FromBody] AM_RoleServices aM_RoleServices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_RoleServices.RoleServiceID)
            {
                return BadRequest();
            }

            _context.Entry(aM_RoleServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_RoleServicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_RoleServices);
        }

        // POST: api/RoleServices
        [HttpPost]
        public async Task<IActionResult> PostAM_RoleServices([FromBody] AM_RoleServices aM_RoleServices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoleServices.Add(aM_RoleServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_RoleServices", new { id = aM_RoleServices.RoleServiceID }, aM_RoleServices);
        }

        // DELETE: api/RoleServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_RoleServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_RoleServices = await _context.RoleServices.SingleOrDefaultAsync(m => m.RoleServiceID == id);
            if (aM_RoleServices == null)
            {
                return NotFound();
            }

            _context.RoleServices.Remove(aM_RoleServices);
            await _context.SaveChangesAsync();

            return Ok(aM_RoleServices);
        }

        private bool AM_RoleServicesExists(int id)
        {
            return _context.RoleServices.Any(e => e.RoleServiceID == id);
        }
    }
}