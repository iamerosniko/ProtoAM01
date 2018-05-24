using BusinessWorkflow.Controllers.FrontEnd;
using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/SingleSignIn")]
    public class SingleSignInController : Controller
    {
        #region PrivateVariables
        BTAMProviders _bTAMProviders;
        #endregion

        [Route("AppSignIn")]
        [HttpPost]
        public async Task<UserAppRoleDTO> AppSignIn([FromBody] AM_AppSignIn appSignIn)
        {
            //lists of users, roles, and apps in btam
            #region ListsInitialization
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            List<AM_Application> apps = new List<AM_Application>();
            List<AM_Role> roles = new List<AM_Role>();
            UserAppRoleDTO signedUser = new UserAppRoleDTO();
            #endregion
            #region ProvidersInitialization
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
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
                var app = applications.Where(x => x.AppUrl == appSignIn.AppURL).FirstOrDefault();
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
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = userAppRoleServices.Where(x => x.UserAppID == userApp.UserAppID).FirstOrDefault();
                            if (tempUserAppRoleService != null)
                            {
                                var tempRole = roles.Where(x => x.RoleID == tempUserAppRoleService.RoleID).FirstOrDefault();
                                if (tempRole != null)
                                {
                                    UserAppRoleDTO userAppRole = new UserAppRoleDTO
                                    {
                                        UserAppID = userApp.UserAppID,
                                        UserID = tempUser.UserID,
                                        UserName = tempUser.UserName,
                                        FirstName = tempUser.FirstName,
                                        LastName = tempUser.LastName,
                                        RoleID = tempRole.RoleID,
                                        Role = tempRole.RoleName
                                    };
                                    //create a UserAppRoleDTO

                                    users.Add(userAppRole);
                                }

                            }
                        }
                    }

                    #endregion
                    signedUser = users.Where(x => x.UserName == appSignIn.UserName.ToLower()).FirstOrDefault();


                }
            }
            catch (Exception Ex)
            {
                signedUser.UserName = Ex.ToString();
            }

            #endregion
            return signedUser;
        }

        [Route("GetUsersInApp")]
        [HttpPost]
        public async Task<List<UserAppRoleDTO>> GetUsersInApp([FromBody] AM_AppSignIn appSignIn)
        {
            //lists of users, roles, and apps in btam
            #region ListsInitialization
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            List<AM_Application> apps = new List<AM_Application>();
            List<AM_Role> roles = new List<AM_Role>();
            UserAppRoleDTO signedUser = new UserAppRoleDTO();
            #endregion
            #region ProvidersInitialization
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
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
                var app = applications.Where(x => x.AppUrl == appSignIn.AppURL).FirstOrDefault();
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
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = userAppRoleServices.Where(x => x.UserAppID == userApp.UserAppID).FirstOrDefault();
                            if (tempUserAppRoleService != null)
                            {
                                var tempRole = roles.Where(x => x.RoleID == tempUserAppRoleService.RoleID).FirstOrDefault();
                                if (tempRole != null)
                                {
                                    UserAppRoleDTO userAppRole = new UserAppRoleDTO
                                    {
                                        UserAppID = userApp.UserAppID,
                                        UserID = tempUser.UserID,
                                        UserName = tempUser.UserName,
                                        FirstName = tempUser.FirstName,
                                        LastName = tempUser.LastName,
                                        RoleID = tempRole.RoleID,
                                        Role = tempRole.RoleName
                                    };
                                    //create a UserAppRoleDTO

                                    users.Add(userAppRole);
                                }

                            }
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

        [Route("Authenticate/{appSecurityKey}")]
        [HttpPost]
        public AppToken Authenticate([FromRoute] string appSecurityKey, [FromBody] UserAppRoleDTO signedUser)
        {
            AppToken appToken = new AppToken();
            appToken.TokenName = "Authentication";

            #region Authentication
            //this area will provide jwt token.
            if (signedUser.Role != null && appSecurityKey != null)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                   claims: GetCurrentClaims(signedUser),
                   signingCredentials: creds
                );

                var myToken = new JwtSecurityTokenHandler().WriteToken(token);

                appToken.Token = myToken;
            }
            return appToken;
            #endregion
        }

        [Route("AppSignIn")]
        [HttpPost]
        public async Task<UserAppRoleDTO> AppSignInWithServiceAttributes([FromBody] AM_AppSignIn appSignIn)
        {
            int applicationID = 0;
            //lists of users, roles, and apps in btam
            #region ListsInitialization
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            List<AM_Application> apps = new List<AM_Application>();
            List<AM_Role> roles = new List<AM_Role>();
            UserAppRoleDTO signedUser = new UserAppRoleDTO();
            #endregion
            #region ProvidersInitialization
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
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
                var app = applications.Where(x => x.AppUrl == appSignIn.AppURL).FirstOrDefault();
                if (app != null)
                {
                    applicationID = app.AppID;
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
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = userAppRoleServices.Where(x => x.UserAppID == userApp.UserAppID).FirstOrDefault();
                            if (tempUserAppRoleService != null)
                            {
                                var tempRole = roles.Where(x => x.RoleID == tempUserAppRoleService.RoleID).FirstOrDefault();
                                if (tempRole != null)
                                {
                                    UserAppRoleDTO userAppRole = new UserAppRoleDTO
                                    {
                                        UserAppID = userApp.UserAppID,
                                        UserID = tempUser.UserID,
                                        UserName = tempUser.UserName,
                                        FirstName = tempUser.FirstName,
                                        LastName = tempUser.LastName,
                                        RoleID = tempRole.RoleID,
                                        Role = tempRole.RoleName
                                    };
                                    //create a UserAppRoleDTO
                                    users.Add(userAppRole);
                                }
                            }
                        }
                    }
                    #endregion
                    signedUser = users.Where(x => x.UserName == appSignIn.UserName.ToLower()).FirstOrDefault();
                    signedUser = await getServices(applicationID, signedUser, HttpContext.Session.GetString("authorizationToken"));
                }
            }
            catch (Exception Ex)
            {
                signedUser.UserName = Ex.ToString();
            }

            #endregion
            return signedUser;
        }

        public async Task<UserAppRoleDTO> getServices(int appID, UserAppRoleDTO userDetails, string authorizaion)
        {
            //get inherited roles
            FEInheritedRolesController inheritedrolesController = new FEInheritedRolesController();
            FEServicesController servicesController = new FEServicesController();
            FEAttributesController attributesController = new FEAttributesController();
            List<ServiceDTO> serviceAttributes = new List<ServiceDTO>();

            var roles = await inheritedrolesController.GetRoles(appID, userDetails.RoleID, authorizaion);

            foreach (var role in roles)
            {
                var services = await servicesController.Get(role.RoleID, authorizaion);

                foreach (var service in services)
                {
                    List<AttributesDTO> attributes = new List<AttributesDTO>();
                    var tempAttributes = await attributesController.GetAttributes(service.ServiceID, authorizaion);

                    foreach (var attribute in tempAttributes)
                    {
                        attributes.Add(new AttributesDTO
                        {
                            AttribDesc = attribute.AttribDesc,
                            AttribName = attribute.AttribName
                        });
                    }
                    serviceAttributes.Add(new ServiceDTO
                    {
                        ServiceName = service.ServiceName,
                        ServiceID = service.ServiceID,
                        ServiceDesc = service.ServiceDesc,
                        Attributes = attributes
                    });
                }
            }
            //filter service

            //add services
            userDetails.services = serviceAttributes;

            return userDetails;
        }

        private List<Claim> GetCurrentClaims(UserAppRoleDTO currentUser)
        {

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.GivenName, currentUser.FirstName == null ? "" : currentUser.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, currentUser.LastName == null ? "" : currentUser.LastName));
            claims.Add(new Claim(ClaimTypes.Role, currentUser.Role == null ? "" : currentUser.Role));

            return claims;
        }
    }

}