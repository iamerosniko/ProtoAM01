using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly AMContext _context;

        public UsersController(AMContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<AM_User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_User([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_User = await _context.Users.SingleOrDefaultAsync(m => m.UserID == id);

            if (aM_User == null)
            {
                return NotFound();
            }

            return Ok(aM_User);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_User([FromRoute] int id, [FromBody] AM_User aM_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_User.UserID)
            {
                return BadRequest();
            }

            _context.Entry(aM_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_User);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostAM_User([FromBody] AM_User aM_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_User.UserID = 0;

            _context.Users.Add(aM_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_User", new { id = aM_User.UserID }, aM_User);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_User([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_User = await _context.Users.SingleOrDefaultAsync(m => m.UserID == id);
            if (aM_User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(aM_User);
            await _context.SaveChangesAsync();

            return Ok(aM_User);
        }

        private bool AM_UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}