using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/AppRoleServices")]
    public class AppRoleServicesController : Controller
    {
        private readonly AMContext _context;

        public AppRoleServicesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/AppRoleServices
        [HttpGet]
        public IEnumerable<AM_AppRoleService> GetAppRoleServices()
        {
            return _context.AppRoleServices;
        }

        // GET: api/AppRoleServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_AppRoleService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_AppRoleService = await _context.AppRoleServices.SingleOrDefaultAsync(m => m.AppRoleServiceID == id);

            if (aM_AppRoleService == null)
            {
                return NotFound();
            }

            return Ok(aM_AppRoleService);
        }

        // PUT: api/AppRoleServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_AppRoleService([FromRoute] int id, [FromBody] AM_AppRoleService aM_AppRoleService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_AppRoleService.AppRoleServiceID)
            {
                return BadRequest();
            }

            _context.Entry(aM_AppRoleService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_AppRoleServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_AppRoleService);
        }

        // POST: api/AppRoleServices
        [HttpPost]
        public async Task<IActionResult> PostAM_AppRoleService([FromBody] AM_AppRoleService aM_AppRoleService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_AppRoleService.AppRoleServiceID = 0;

            _context.AppRoleServices.Add(aM_AppRoleService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_AppRoleService", new { id = aM_AppRoleService.AppRoleServiceID }, aM_AppRoleService);
        }

        // DELETE: api/AppRoleServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_AppRoleService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_AppRoleService = await _context.AppRoleServices.SingleOrDefaultAsync(m => m.AppRoleServiceID == id);
            if (aM_AppRoleService == null)
            {
                return NotFound();
            }

            _context.AppRoleServices.Remove(aM_AppRoleService);
            await _context.SaveChangesAsync();

            return Ok(aM_AppRoleService);
        }

        private bool AM_AppRoleServiceExists(int id)
        {
            return _context.AppRoleServices.Any(e => e.AppRoleServiceID == id);
        }
    }
}