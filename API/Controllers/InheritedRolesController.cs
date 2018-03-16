using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/InheritedRoles")]
    public class InheritedRolesController : Controller
    {
        private readonly AMContext _context;

        public InheritedRolesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/InheritedRoles
        [HttpGet]
        public IEnumerable<AM_InheritedRole> GetInheritedRoles()
        {
            return _context.InheritedRoles;
        }

        // GET: api/InheritedRoles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_InheritedRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_InheritedRole = await _context.InheritedRoles.SingleOrDefaultAsync(m => m.InheritedRolesID == id);

            if (aM_InheritedRole == null)
            {
                return NotFound();
            }

            return Ok(aM_InheritedRole);
        }

        // PUT: api/InheritedRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_InheritedRole([FromRoute] int id, [FromBody] AM_InheritedRole aM_InheritedRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_InheritedRole.InheritedRolesID)
            {
                return BadRequest();
            }

            _context.Entry(aM_InheritedRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_InheritedRoleExists(id))
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

        // POST: api/InheritedRoles
        [HttpPost]
        public async Task<IActionResult> PostAM_InheritedRole([FromBody] AM_InheritedRole aM_InheritedRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_InheritedRole.InheritedRolesID = 0;

            _context.InheritedRoles.Add(aM_InheritedRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_InheritedRole", new { id = aM_InheritedRole.InheritedRolesID }, aM_InheritedRole);
        }

        // DELETE: api/InheritedRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_InheritedRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_InheritedRole = await _context.InheritedRoles.SingleOrDefaultAsync(m => m.InheritedRolesID == id);
            if (aM_InheritedRole == null)
            {
                return NotFound();
            }

            _context.InheritedRoles.Remove(aM_InheritedRole);
            await _context.SaveChangesAsync();

            return Ok(aM_InheritedRole);
        }

        private bool AM_InheritedRoleExists(int id)
        {
            return _context.InheritedRoles.Any(e => e.InheritedRolesID == id);
        }
    }
}