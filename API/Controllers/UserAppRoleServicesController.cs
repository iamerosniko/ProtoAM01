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
    [Route("api/UserAppRoleServices")]
    public class UserAppRoleServicesController : Controller
    {
        private readonly AMContext _context;

        public UserAppRoleServicesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/UserAppRoleServices
        [HttpGet]
        public IEnumerable<AM_UserAppRoleService> GetUserAppRoles()
        {
            return _context.UserAppRoles;
        }

        // GET: api/UserAppRoleServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_UserAppRoleService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserAppRoleService = await _context.UserAppRoles.SingleOrDefaultAsync(m => m.UserAppRoleServiceID == id);

            if (aM_UserAppRoleService == null)
            {
                return NotFound();
            }

            return Ok(aM_UserAppRoleService);
        }

        // PUT: api/UserAppRoleServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_UserAppRoleService([FromRoute] int id, [FromBody] AM_UserAppRoleService aM_UserAppRoleService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_UserAppRoleService.UserAppRoleServiceID)
            {
                return BadRequest();
            }

            _context.Entry(aM_UserAppRoleService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_UserAppRoleServiceExists(id))
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

        // POST: api/UserAppRoleServices
        [HttpPost]
        public async Task<IActionResult> PostAM_UserAppRoleService([FromBody] AM_UserAppRoleService aM_UserAppRoleService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserAppRoles.Add(aM_UserAppRoleService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_UserAppRoleService", new { id = aM_UserAppRoleService.UserAppRoleServiceID }, aM_UserAppRoleService);
        }

        // DELETE: api/UserAppRoleServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_UserAppRoleService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserAppRoleService = await _context.UserAppRoles.SingleOrDefaultAsync(m => m.UserAppRoleServiceID == id);
            if (aM_UserAppRoleService == null)
            {
                return NotFound();
            }

            _context.UserAppRoles.Remove(aM_UserAppRoleService);
            await _context.SaveChangesAsync();

            return Ok(aM_UserAppRoleService);
        }

        private bool AM_UserAppRoleServiceExists(int id)
        {
            return _context.UserAppRoles.Any(e => e.UserAppRoleServiceID == id);
        }
    }
}