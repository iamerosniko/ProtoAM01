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
    [Route("api/FEUsers")]
    public class FEUsersController : Controller
    {
        private BTAMProviders _bTAMProviders;

        //[HttpGet("{appID}")]
        //public async Task<List<UserAppRoleDTO>> Get(int appID)
        //{
        //    //instantiate
        //    _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

        //    List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();

        //    var userApps = await _bTAMProviders.userAppProviders.get();
        //    userApps = userApps.Where(x => x.AppID == appID).ToList();

        //    foreach (AM_UserApp userApp in userApps)
        //    {
        //        //get user
        //        var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
        //        //get role of that user (using userapproleservices)

        //        //create a UserAppRoleDTO
        //        UserAppRoleDTO userAppRole = new UserAppRoleDTO
        //        {
        //            UserAppID = userApp.UserAppID,
        //            UserID = tempUser.UserID,
        //            UserName = tempUser.UserName,
        //            FirstName = tempUser.FirstName,
        //            LastName = tempUser.LastName
        //        };


        //        if (tempUser != null)
        //        {
        //            users.Add(userAppRole);
        //        }
        //    }

        //    //return all users in selected application
        //    return users;
        //}

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
            #endregion
            #region VerificationOfApplicationInBTAM
            try
            {
                var app = applications.Where(x => x.AppID == appID).FirstOrDefault();
                if (app != null)
                {
                    userApps = userApps.Where(x => x.AppID == app.AppID).ToList();
                    appRoleServices = appRoleServices.Where(x => x.AppID == app.AppID).ToList();

                    //this will get the roles under app
                    #region roles
                    foreach (AM_AppRoleService appRoleService in appRoleServices)
                    {
                        var tempRole = await _bTAMProviders.roleProviders.get(appRoleService.RoleID.ToString());
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
                        var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
                        if (tempUser != null)
                        {
                            AM_Role tempRole = new AM_Role();
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = userAppRoleServices.Where(x => x.UserAppID == userApp.UserAppID).FirstOrDefault();
                            if (tempUserAppRoleService != null)
                            {
                                tempRole = roles.Where(x => x.RoleID == tempUserAppRoleService.RoleID).FirstOrDefault();
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
            return users;
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

        [HttpPut("{userID}")]
        public async void Put([FromRoute]string userID, [FromBody]AM_User user)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempUser = await _bTAMProviders.userProviders.Put(userID, user);
        }
    }
}