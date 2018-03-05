using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAppServices")]
    public class UserAppServicesController : Controller
    {
        private readonly AMContext _context;

        public UserAppServicesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/UserAppServices
        [HttpGet]
        public IEnumerable<AM_UserAppService> GetUserAppServices()
        {
            return _context.UserAppServices;
        }

        // GET: api/UserAppServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_UserAppService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserAppService = await _context.UserAppServices.SingleOrDefaultAsync(m => m.UserAppServicesID == id);

            if (aM_UserAppService == null)
            {
                return NotFound();
            }

            return Ok(aM_UserAppService);
        }

        // PUT: api/UserAppServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_UserAppService([FromRoute] int id, [FromBody] AM_UserAppService aM_UserAppService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_UserAppService.UserAppServicesID)
            {
                return BadRequest();
            }

            _context.Entry(aM_UserAppService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_UserAppServiceExists(id))
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

        // POST: api/UserAppServices
        [HttpPost]
        public async Task<IActionResult> PostAM_UserAppService([FromBody] AM_UserAppService aM_UserAppService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserAppServices.Add(aM_UserAppService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_UserAppService", new { id = aM_UserAppService.UserAppServicesID }, aM_UserAppService);
        }

        // DELETE: api/UserAppServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_UserAppService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserAppService = await _context.UserAppServices.SingleOrDefaultAsync(m => m.UserAppServicesID == id);
            if (aM_UserAppService == null)
            {
                return NotFound();
            }

            _context.UserAppServices.Remove(aM_UserAppService);
            await _context.SaveChangesAsync();

            return Ok(aM_UserAppService);
        }

        private bool AM_UserAppServiceExists(int id)
        {
            return _context.UserAppServices.Any(e => e.UserAppServicesID == id);
        }
    }
}