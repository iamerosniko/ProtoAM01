using API.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [EnableCors("CORS")]

    [Produces("application/json")]
    [Route("api/UserApps")]
    public class UserAppsController : Controller
    {
        private readonly AMContext _context;

        public UserAppsController(AMContext context)
        {
            _context = context;
        }

        // GET: api/UserApps
        [HttpGet]
        public IEnumerable<AM_UserApp> GetUserApps()
        {
            return _context.UserApps;
        }

        // GET: api/UserApps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_UserApp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserApp = await _context.UserApps.SingleOrDefaultAsync(m => m.UserAppID == id);

            if (aM_UserApp == null)
            {
                return NotFound();
            }

            return Ok(aM_UserApp);
        }

        // PUT: api/UserApps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_UserApp([FromRoute] int id, [FromBody] AM_UserApp aM_UserApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_UserApp.UserAppID)
            {
                return BadRequest();
            }

            _context.Entry(aM_UserApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_UserAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_UserApp);
        }

        // POST: api/UserApps
        [HttpPost]
        public async Task<IActionResult> PostAM_UserApp([FromBody] AM_UserApp aM_UserApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_UserApp.UserAppID = 0;

            _context.UserApps.Add(aM_UserApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_UserApp", new { id = aM_UserApp.UserAppID }, aM_UserApp);
        }

        // DELETE: api/UserApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_UserApp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_UserApp = await _context.UserApps.SingleOrDefaultAsync(m => m.UserAppID == id);
            if (aM_UserApp == null)
            {
                return NotFound();
            }

            _context.UserApps.Remove(aM_UserApp);
            await _context.SaveChangesAsync();

            return Ok(aM_UserApp);
        }

        private bool AM_UserAppExists(int id)
        {
            return _context.UserApps.Any(e => e.UserAppID == id);
        }
    }
}