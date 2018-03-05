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
    [Route("api/AppRoles")]
    public class AppRolesController : Controller
    {
        private readonly AMContext _context;

        public AppRolesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/AppRoles
        [HttpGet]
        public IEnumerable<AM_AppRole> GetAppRoles()
        {
            return _context.AppRoles;
        }

        // GET: api/AppRoles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_AppRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_AppRole = await _context.AppRoles.SingleOrDefaultAsync(m => m.AppRoleID == id);

            if (aM_AppRole == null)
            {
                return NotFound();
            }

            return Ok(aM_AppRole);
        }

        // PUT: api/AppRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_AppRole([FromRoute] int id, [FromBody] AM_AppRole aM_AppRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_AppRole.AppRoleID)
            {
                return BadRequest();
            }

            _context.Entry(aM_AppRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_AppRoleExists(id))
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

        // POST: api/AppRoles
        [HttpPost]
        public async Task<IActionResult> PostAM_AppRole([FromBody] AM_AppRole aM_AppRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppRoles.Add(aM_AppRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_AppRole", new { id = aM_AppRole.AppRoleID }, aM_AppRole);
        }

        // DELETE: api/AppRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_AppRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_AppRole = await _context.AppRoles.SingleOrDefaultAsync(m => m.AppRoleID == id);
            if (aM_AppRole == null)
            {
                return NotFound();
            }

            _context.AppRoles.Remove(aM_AppRole);
            await _context.SaveChangesAsync();

            return Ok(aM_AppRole);
        }

        private bool AM_AppRoleExists(int id)
        {
            return _context.AppRoles.Any(e => e.AppRoleID == id);
        }
    }
}