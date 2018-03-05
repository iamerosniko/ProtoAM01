using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private readonly AMContext _context;

        public RolesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<AM_Role> GetRoles()
        {
            return _context.Roles;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_Role([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Role = await _context.Roles.SingleOrDefaultAsync(m => m.RoleID == id);

            if (aM_Role == null)
            {
                return NotFound();
            }

            return Ok(aM_Role);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_Role([FromRoute] int id, [FromBody] AM_Role aM_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_Role.RoleID)
            {
                return BadRequest();
            }

            _context.Entry(aM_Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_RoleExists(id))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> PostAM_Role([FromBody] AM_Role aM_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Roles.Add(aM_Role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_Role", new { id = aM_Role.RoleID }, aM_Role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_Role([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Role = await _context.Roles.SingleOrDefaultAsync(m => m.RoleID == id);
            if (aM_Role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(aM_Role);
            await _context.SaveChangesAsync();

            return Ok(aM_Role);
        }

        private bool AM_RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RoleID == id);
        }
    }
}