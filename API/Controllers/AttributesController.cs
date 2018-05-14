using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Attributes")]
    public class AttributesController : Controller
    {
        private readonly AMContext _context;

        public AttributesController(AMContext context)
        {
            _context = context;
        }

        // GET: api/Attributes
        [HttpGet]
        public IEnumerable<AM_Attribute> GetAttributes()
        {
            return _context.Attributes.OrderBy(X => X.AttribName);
        }

        // GET: api/Attributes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_Attribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.AttribID == id);

            if (aM_Attribute == null)
            {
                return NotFound();
            }

            return Ok(aM_Attribute);
        }

        // PUT: api/Attributes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_Attribute([FromRoute] int id, [FromBody] AM_Attribute aM_Attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_Attribute.AttribID)
            {
                return BadRequest();
            }

            _context.Entry(aM_Attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_AttributeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_Attribute);
        }

        // POST: api/Attributes
        [HttpPost]
        public async Task<IActionResult> PostAM_Attribute([FromBody] AM_Attribute aM_Attribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_Attribute.AttribID = 0;

            _context.Attributes.Add(aM_Attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_Attribute", new { id = aM_Attribute.AttribID }, aM_Attribute);
        }

        // DELETE: api/Attributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_Attribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.AttribID == id);
            if (aM_Attribute == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(aM_Attribute);
            await _context.SaveChangesAsync();

            return Ok(aM_Attribute);
        }

        private bool AM_AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.AttribID == id);
        }
    }
}