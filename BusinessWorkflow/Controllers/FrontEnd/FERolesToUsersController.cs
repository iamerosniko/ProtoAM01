using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [EnableCors("CORS")]

    [Produces("application/json")]
    [Route("api/FERolesToUsers")]
    public class FERolesToUsersController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpPost]
        public async Task<AM_UserAppRoleService> AddRoleToUser([FromBody] UserAppRoleServicesDTO user)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            AM_UserAppRoleService userAppRoleService = new AM_UserAppRoleService();

            var verifyUser = (await _bTAMProviders.userAppRoleServiceProviders.get())
                .Where(x => x.RoleID == user.RoleID && x.UserAppID == user.UserAppID).FirstOrDefault();

            //verify if not exists then create else check if the entry is unchecked then delete else do nothing
            if (verifyUser == null)
            {
                if (user.IsChecked)
                {
                    var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
                        .Post(new AM_UserAppRoleService
                        {
                            RoleID = user.RoleID,
                            UserAppID = user.UserAppID
                        });

                    if (tempUserAppRoleService != null)
                    {
                        userAppRoleService = tempUserAppRoleService;
                    }
                }
            }
            else
            {
                if (!user.IsChecked)
                {
                    var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
                        .Delete(verifyUser.UserAppRoleServiceID.ToString());

                    if (tempUserAppRoleService != null)
                    {
                        userAppRoleService = tempUserAppRoleService;
                    }
                }
            }

            return userAppRoleService;
        }


        //public async Task<List<AM_UserAppRoleService>> AddRoleToUser([FromBody] List<UserAppRoleServicesDTO> users)
        //{
        //    _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
        //    List<AM_UserAppRoleService> userAppRoleServices = new List<AM_UserAppRoleService>();
        //    foreach (var userapproleservice in users)
        //    {
        //        var verifyUser = (await _bTAMProviders.userAppRoleServiceProviders.get())
        //            .Where(x => x.RoleID == userapproleservice.RoleID && x.UserAppID == userapproleservice.UserAppID).FirstOrDefault();

        //        //verify if not exists then create else check if the entry is unchecked then delete else do nothing
        //        if (verifyUser == null)
        //        {
        //            if (userapproleservice.IsChecked)
        //            {
        //                var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
        //                    .Post(new AM_UserAppRoleService
        //                    {
        //                        RoleID = userapproleservice.RoleID,
        //                        UserAppID = userapproleservice.UserAppID
        //                    });

        //                if (tempUserAppRoleService != null)
        //                {
        //                    userAppRoleServices.Add(tempUserAppRoleService);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (!userapproleservice.IsChecked)
        //            {
        //                var tempUserAppRoleService = await _bTAMProviders.userAppRoleServiceProviders
        //                    .Delete(userapproleservice.UserAppRoleServiceID.ToString());

        //                if (tempUserAppRoleService != null)
        //                {
        //                    userAppRoleServices.Add(tempUserAppRoleService);
        //                }
        //            }
        //        }
        //    }

        //    return userAppRoleServices;
        //}

    }
}