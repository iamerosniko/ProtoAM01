using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/FEUsers")]
    public class FEUsersController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet("{appID}")]
        public async Task<List<UserAppRoleDTO>> Get(int appID)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            #region ListsInitialization
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            List<AM_Application> apps = new List<AM_Application>();
            List<AM_Role> roles = new List<AM_Role>();
            UserAppRoleDTO signedUser = new UserAppRoleDTO();
            #endregion
            #region BTAMData
            //to see the user in every application 
            var userApps = await _bTAMProviders.userAppProviders.get();
            //to see the user app role services in all application
            var userAppRoleServices = await _bTAMProviders.userAppRoleServiceProviders.get();
            //to see the app role in all applications
            var appRoleServices = await _bTAMProviders.appRoleServiceProviders.get();
            //get apps in btam
            var applications = await _bTAMProviders.applicationProviders.get();
            var allRoles = await _bTAMProviders.roleProviders.get();
            var allUsers = await _bTAMProviders.userProviders.get();
            #endregion
            #region VerificationOfApplicationInBTAM
            try
            {
                var app = applications.Find(x => x.AppID == appID);
                if (app != null)
                {
                    userApps = userApps.Where(x => x.AppID == app.AppID).ToList();
                    appRoleServices = appRoleServices.Where(x => x.AppID == app.AppID).ToList();

                    //this will get the roles under app
                    #region roles
                    foreach (AM_AppRoleService appRoleService in appRoleServices)
                    {
                        //var tempRole = await _bTAMProviders.roleProviders.get(appRoleService.RoleID.ToString());
                        var tempRole = allRoles.Find(x => x.RoleID == appRoleService.RoleID);
                        if (tempRole != null)
                        {
                            roles.Add(tempRole);
                        }
                    }
                    #endregion

                    #region userswithroles
                    foreach (AM_UserApp userApp in userApps)
                    {
                        //get user
                        var tempUser = allUsers.Find(x => x.UserID == userApp.UserID);
                        //var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
                        if (tempUser != null)
                        {
                            AM_Role tempRole = new AM_Role();
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = userAppRoleServices.Find(x => x.UserAppID == userApp.UserAppID);
                            if (tempUserAppRoleService != null)
                            {
                                tempRole = roles.Find(x => x.RoleID == tempUserAppRoleService.RoleID);
                            }

                            UserAppRoleDTO userAppRole = new UserAppRoleDTO
                            {
                                UserAppID = userApp.UserAppID,
                                UserID = tempUser.UserID,
                                UserName = tempUser.UserName,
                                FirstName = tempUser.FirstName,
                                LastName = tempUser.LastName,
                                RoleID = tempRole != null ? tempRole.RoleID : 0,
                                Role = tempRole != null ? tempRole.RoleName : ""
                            };
                            //create a UserAppRoleDTO

                            users.Add(userAppRole);
                        }
                    }

                    #endregion
                }
            }
            catch
            {

            }

            #endregion
            return users.OrderBy(x => x.FirstName).ToList();
        }

        [HttpPost("{applicationID}")]
        public async Task<AM_UserApp> Post([FromRoute]int applicationID, [FromBody]AM_User user)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempUser = await _bTAMProviders.userProviders.Post(user);
            AM_UserApp userApp = new AM_UserApp
            {
                AppID = applicationID,
                UserID = tempUser.UserID
            };
            return await _bTAMProviders.userAppProviders.Post(userApp);
        }

        [HttpPost("Bulk/{applicationID}")]
        public async Task<List<AM_UserApp>> PostAll([FromRoute]int applicationID, [FromBody]AM_User[] users)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            List<AM_UserApp> userapps = new List<AM_UserApp>();

            //bulk add users
            foreach (var user in users)
            {
                var tempUser = await _bTAMProviders.userProviders.Post(user);
                if (tempUser != null)
                {
                    userapps.Add(new AM_UserApp
                    {
                        AppID = applicationID,
                        UserID = tempUser.UserID
                    });
                }
            }

            //bulk add userapps

            for (int i = 0; i < userapps.Count(); i++)
            {
                userapps[i] = await _bTAMProviders.userAppProviders.Post(userapps[i]);
            }

            return userapps;
            //return await _bTAMProviders.userAppProviders.Post(userApp);
        }

        [HttpDelete("{userID}")]
        public async Task<AM_User> Delete([FromRoute]string userID)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempUser = await _bTAMProviders.userProviders.Delete(userID);
            var a = await Cascade(Convert.ToInt32(userID));

            return tempUser;
        }

        [HttpPut("{userID}")]
        public async Task<AM_User> Put([FromRoute]string userID, [FromBody]AM_User user)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempUser = await _bTAMProviders.userProviders.Put(userID, user);
            return tempUser;
        }

        public async Task<bool> Cascade(int userID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            try
            {
                //for deletion of users
                var userapps = (await _bTAMProviders.userAppProviders.get()).Where(x => x.UserID == userID).ToList();

                foreach (var userapp in userapps)
                {
                    //userapps
                    await _bTAMProviders.userAppProviders.Delete(userapp.UserAppID.ToString());

                    var userapproleservices = (await _bTAMProviders.userAppRoleServiceProviders.get()).Where(x => x.UserAppID == userapp.UserAppID).ToList();

                    foreach (var userapproleservice in userapproleservices)
                    {
                        //userapproleservices
                        await _bTAMProviders.userAppRoleServiceProviders.Delete(userapproleservice.UserAppRoleServiceID.ToString());
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}