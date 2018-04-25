using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Applications")]
    public class ApplicationsController : Controller
    {
        private readonly AMContext _context;

        public ApplicationsController(AMContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public IEnumerable<AM_Application> GetApplications()
        {
            return _context.Applications;
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAM_Application([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Application = await _context.Applications.SingleOrDefaultAsync(m => m.AppID == id);

            if (aM_Application == null)
            {
                return NotFound();
            }

            return Ok(aM_Application);
        }

        // PUT: api/Applications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAM_Application([FromRoute] int id, [FromBody] AM_Application aM_Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aM_Application.AppID)
            {
                return BadRequest();
            }

            _context.Entry(aM_Application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AM_ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(aM_Application);
        }

        // POST: api/Applications
        [HttpPost]
        public async Task<IActionResult> PostAM_Application([FromBody] AM_Application aM_Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            aM_Application.AppID = 0;

            _context.Applications.Add(aM_Application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAM_Application", new { id = aM_Application.AppID }, aM_Application);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAM_Application([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aM_Application = await _context.Applications.SingleOrDefaultAsync(m => m.AppID == id);
            if (aM_Application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(aM_Application);
            await _context.SaveChangesAsync();

            //await Cascade(id);
            return Ok(aM_Application);
        }

        private bool AM_ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.AppID == id);
        }

        //Extensions
        public async Task<bool> Cascade(int applicationID)
        {
            try
            {
                MyControllers myControllers = new MyControllers(_context);
                //for deletion of users
                var userapps = myControllers.userAppsController.GetUserApps().Where(x => x.AppID == applicationID);
                //for deletion of roles
                var approleservices = myControllers.appRoleServicesController.GetAppRoleServices().Where(x => x.AppID == applicationID);

                foreach (var userapp in userapps)
                {
                    //users
                    await myControllers.usersController.DeleteAM_User(userapp.UserID);
                    //userapps
                    await myControllers.userAppsController.DeleteAM_UserApp(userapp.UserAppID);
                }

                foreach (var approleservice in approleservices)
                {
                    var serviceattributes = myControllers.serviceAttributesController.GetServiceAttribute().Where(x => x.ServiceID == approleservice.ServiceID);

                    var userapproleservices = myControllers.userAppRoleServicesController.GetUserAppRoles().Where(x => x.RoleID == approleservice.RoleID);

                    var inheritedroles = myControllers.inheritedRolesController.GetInheritedRoles().Where(x => x.RoleID == approleservice.RoleID);
                    //roles
                    await myControllers.rolesController.DeleteAM_Role(approleservice.RoleID);
                    //approleservices
                    await myControllers.appRoleServicesController.DeleteAM_AppRoleService(approleservice.AppRoleServiceID);

                    foreach (var serviceattribute in serviceattributes)
                    {
                        //serviceattributes
                        await myControllers.serviceAttributesController.DeleteAM_ServiceAttribute(serviceattribute.ServiceAttributeID);
                        //attributes
                        await myControllers.attributesController.DeleteAM_Attribute(serviceattribute.AttribID);
                        //services
                        await myControllers.servicesController.DeleteAM_Service(approleservice.ServiceID);
                    }

                    foreach (var userapproleservice in userapproleservices)
                    {
                        //userapproleservices
                        await myControllers.userAppRoleServicesController.DeleteAM_UserAppRoleService(userapproleservice.UserAppRoleServiceID);
                    }

                    foreach (var inheritedrole in inheritedroles)
                    {
                        //inheritedroles
                        await myControllers.inheritedRolesController.DeleteAM_InheritedRole(inheritedrole.InheritedRolesID);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}