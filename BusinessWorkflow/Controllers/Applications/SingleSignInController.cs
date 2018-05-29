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
        BTAMProviders _bTAMProviders;
        //string _authorization;
        List<AM_Application> _allApps;
        List<AM_Role> _allRoles;
        List<AM_User> _allUsers;
        List<AM_UserApp> _allUserApps;
        List<AM_UserAppRoleService> _allUserAppRoleServices;
        List<AM_AppRoleService> _allAppRoleServices;
        List<AM_RoleService> _allRoleServices;
        List<AM_ServiceAttribute> _allServiceAttributes;
        List<AM_InheritedRole> _allInheritedRoles;

        List<ServiceDTO> _myServiceDTOs;
        UserAppRoleDTO _signedUser;
        //List<UserAppRoleDTO> _allUsersDTO;

        [Route("AppSignIn")]
        [HttpPost]
        public async Task<UserAppRoleDTO> AppSignIn([FromBody] AM_AppSignIn appSignIn)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            //get all data that is needed
            _allApps = await _bTAMProviders.applicationProviders.get();
            _allUserApps = await _bTAMProviders.userAppProviders.get();
            _allAppRoleServices = await _bTAMProviders.appRoleServiceProviders.get();
            _allRoles = await _bTAMProviders.roleProviders.get();
            _allUsers = await _bTAMProviders.userProviders.get();
            _allUserAppRoleServices = await _bTAMProviders.userAppRoleServiceProviders.get();

            List<AM_Role> roles = new List<AM_Role>();
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();

            try
            {
                var app = _allApps.Find(x => x.AppUrl == appSignIn.AppURL);
                if (app != null)
                {
                    var userApps = _allUserApps.Where(x => x.AppID == app.AppID).ToList();
                    var appRoleServices = _allAppRoleServices.Where(x => x.AppID == app.AppID).ToList();

                    //this will get the roles under app
                    foreach (AM_AppRoleService appRoleService in appRoleServices)
                    {
                        var tempRole = _allRoles.Find(x => x.RoleID == appRoleService.RoleID);
                        if (tempRole != null)
                        {
                            roles.Add(tempRole);
                        }
                    }

                    foreach (AM_UserApp userApp in userApps)
                    {
                        //get user
                        var tempUser = _allUsers.Find(x => x.UserID == userApp.UserID);
                        //var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
                        if (tempUser != null)
                        {
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = _allUserAppRoleServices.Find(x => x.UserAppID == userApp.UserAppID);
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

                    _signedUser = users.Find(x => x.UserName == appSignIn.UserName.ToLower());
                }
            }
            catch (Exception Ex)
            {
                _signedUser.UserName = Ex.ToString();
            }

            return _signedUser;
        }

        [Route("GetUsersInApp")]
        [HttpPost]
        public async Task<List<UserAppRoleDTO>> GetUsersInApp([FromBody] AM_AppSignIn appSignIn)
        {
            //lists of users, roles, and apps in btam
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            //get all data that is needed
            _allApps = await _bTAMProviders.applicationProviders.get();
            _allUserApps = await _bTAMProviders.userAppProviders.get();
            _allAppRoleServices = await _bTAMProviders.appRoleServiceProviders.get();
            _allRoles = await _bTAMProviders.roleProviders.get();
            _allUsers = await _bTAMProviders.userProviders.get();
            _allUserAppRoleServices = await _bTAMProviders.userAppRoleServiceProviders.get();

            List<AM_Role> roles = new List<AM_Role>();
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            try
            {
                var app = _allApps.Find(x => x.AppUrl == appSignIn.AppURL);
                if (app != null)
                {
                    var userApps = _allUserApps.Where(x => x.AppID == app.AppID).ToList();
                    var appRoleServices = _allAppRoleServices.Where(x => x.AppID == app.AppID).ToList();

                    //this will get the roles under app
                    foreach (AM_AppRoleService appRoleService in appRoleServices)
                    {
                        var tempRole = _allRoles.Find(x => x.RoleID == appRoleService.RoleID);
                        if (tempRole != null)
                        {
                            roles.Add(tempRole);
                        }
                    }

                    foreach (AM_UserApp userApp in userApps)
                    {
                        //get user
                        var tempUser = _allUsers.Find(x => x.UserID == userApp.UserID);
                        //var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
                        if (tempUser != null)
                        {
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = _allUserAppRoleServices.Find(x => x.UserAppID == userApp.UserAppID);
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

                }
            }
            catch
            {

            }

            return users;
        }

        [Route("Authenticate/{appSecurityKey}")]
        [HttpPost]
        public AppToken Authenticate([FromRoute] string appSecurityKey, [FromBody] UserAppRoleDTO signedUser)
        {
            AppToken appToken = new AppToken();
            appToken.TokenName = "Authentication";

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
        }

        [Route("AppSignIn2")]
        [HttpPost]
        public async Task<UserAppRoleDTO> AppSignInWithServiceAttributes([FromBody] AM_AppSignIn appSignIn)
        {
            int applicationID = 0;
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            //get all data that is needed
            _allApps = await _bTAMProviders.applicationProviders.get();
            _allUserApps = await _bTAMProviders.userAppProviders.get();
            _allAppRoleServices = await _bTAMProviders.appRoleServiceProviders.get();
            _allRoles = await _bTAMProviders.roleProviders.get();
            _allUsers = await _bTAMProviders.userProviders.get();
            _allUserAppRoleServices = await _bTAMProviders.userAppRoleServiceProviders.get();
            _allRoleServices = await _bTAMProviders.roleServiceProviders.get();
            _allInheritedRoles = await _bTAMProviders.inheritedRolesProviders.get();
            _allServiceAttributes = await _bTAMProviders.serviceAttributeProviders.get();

            List<AM_Role> roles = new List<AM_Role>();
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            try
            {
                var app = _allApps.Find(x => x.AppUrl == appSignIn.AppURL);
                if (app != null)
                {
                    applicationID = app.AppID;
                    var userApps = _allUserApps.Where(x => x.AppID == app.AppID).ToList();
                    var appRoleServices = _allAppRoleServices.Where(x => x.AppID == app.AppID).ToList();

                    //this will get the roles under app
                    foreach (AM_AppRoleService appRoleService in appRoleServices)
                    {
                        var tempRole = _allRoles.Find(x => x.RoleID == appRoleService.RoleID);
                        if (tempRole != null)
                        {
                            roles.Add(tempRole);
                        }
                    }

                    foreach (AM_UserApp userApp in userApps)
                    {
                        //get user
                        var tempUser = _allUsers.Find(x => x.UserID == userApp.UserID);
                        //var tempUser = await _bTAMProviders.userProviders.get(userApp.UserID.ToString());
                        if (tempUser != null)
                        {
                            //get role of that user (using userapproleservices)
                            var tempUserAppRoleService = _allUserAppRoleServices.Find(x => x.UserAppID == userApp.UserAppID);
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

                    _signedUser = users.Find(x => x.UserName == appSignIn.UserName.ToLower());
                    _myServiceDTOs = new List<ServiceDTO>();
                    GetInheritedRoles(_signedUser.RoleID);
                    //signedUser = await getServiceAttributes(applicationID, signedUser, HttpContext.Session.GetString("authorizationToken"));
                    _signedUser.services = _myServiceDTOs;
                }
            }
            catch (Exception Ex)
            {
                _signedUser.UserName = Ex.ToString();
            }

            return _signedUser;
        }

        public void GetInheritedRoles(int roleID)
        {
            var inheritedRoles = _allInheritedRoles.Where(x => x.MainRoleID == roleID);
            foreach (var inheritedRole in inheritedRoles)
            {
                GetInheritedRoles(inheritedRole.RoleID);
            }
            _myServiceDTOs.AddRange(GetRoleServices(roleID));
        }

        public List<ServiceDTO> GetRoleServices(int roleID)
        {
            List<ServiceDTO> serviceAttributes = new List<ServiceDTO>();
            var roleServices = _allRoleServices.Where(x => x.RoleID == roleID);
            foreach (var roleService in roleServices)
            {
                ServiceDTO serviceAttribute = new ServiceDTO
                {
                    ServiceName = roleService.ServiceName,
                    ServiceDesc = roleService.ServiceDesc,
                };
                serviceAttribute.Attributes = GetAttributes(roleService.RoleServiceID);
                serviceAttributes.Add(serviceAttribute);
            }
            return serviceAttributes;
        }

        public List<AttributesDTO> GetAttributes(int roleServiceID)
        {
            List<AttributesDTO> attributesDTO = new List<AttributesDTO>();
            var attributes = _allServiceAttributes.Where(x => x.RoleServiceID == roleServiceID);

            foreach (var attribute in attributes)
            {
                attributesDTO.Add(new AttributesDTO
                {
                    AttribDesc = attribute.AttribDesc,
                    AttribName = attribute.AttribName
                });
            }

            return attributesDTO;
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