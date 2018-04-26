using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/FERolesToUsers")]
    public class FERolesToUsersController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpPost]
        public async Task<List<AM_UserAppRoleService>> AddRoleToUser([FromBody] List<UserAppRoleServicesDTO> users)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            List<AM_UserAppRoleService> userAppRoleServices = new List<AM_UserAppRoleService>();
            foreach (var userapproleservice in users)
            {
                var verifyUser = (await _bTAMProviders.userAppRoleServiceProviders.get())
                    .Where(x => x.RoleID == userapproleservice.RoleID && x.UserAppID == userapproleservice.UserAppID).FirstOrDefault();

                //verify if not exists then create else check if the entry is unchecked then delete else do nothing
                if (verifyUser == null)
                {
                    if (userapproleservice.IsChecked)
                    {
                        var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
                            .Post(new AM_UserAppRoleService
                            {
                                RoleID = userapproleservice.RoleID,
                                UserAppID = userapproleservice.UserAppID
                            });

                        if (tempUserAppRoleService != null)
                        {
                            userAppRoleServices.Add(tempUserAppRoleService);
                        }
                    }
                }
                else
                {
                    if (!userapproleservice.IsChecked)
                    {
                        var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
                            .Delete(userapproleservice.UserAppRoleServiceID.ToString());

                        if (tempUserAppRoleService != null)
                        {
                            userAppRoleServices.Add(tempUserAppRoleService);
                        }
                    }
                }
            }

            return userAppRoleServices;
        }

    }
}