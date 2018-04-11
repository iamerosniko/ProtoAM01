using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        ApplicationProviders _applicationProviders;
        UserAppProviders _userAppProviders;
        UserProviders _userProviders;
        AppRoleServiceProviders _appRoleServiceProviders;
        RoleProviders _roleProviders;
        UserAppRoleServiceProviders _userAppRoleServiceProviders;
        #endregion

        [Route("AppSignIn")]
        [HttpPost]
        public async Task<AppToken> AppSignIn([FromBody] AM_AppSignIn appSignIn)
        {
            //lists of users, roles, and apps in btam
            #region ListsInitialization
            List<UserAppRoleDTO> users = new List<UserAppRoleDTO>();
            List<AM_Application> apps = new List<AM_Application>();
            List<AM_Role> roles = new List<AM_Role>();
            AppToken appToken = new AppToken();
            appToken.TokenName = "Authentication";
            #endregion
            #region ProvidersInitialization
            _appRoleServiceProviders = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _applicationProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));
            _userAppProviders = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            _userAppRoleServiceProviders = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            #endregion
            #region BTAMData
            //to see the user in every application 
            var userApps = await _userAppProviders.get();
            //to see the user app role services in all application
            var userAppRoleServices = await _userAppRoleServiceProviders.get();
            //to see the app role in all applications
            var appRoleServices = await _appRoleServiceProviders.get();
            //get apps in btam
            var applications = await _applicationProviders.get();
            #endregion
            #region VerificationOfApplicationInBTAM
            var app = applications.Where(x => x.AppID == appSignIn.AppID).First();
            if (app != null)
            {
                userApps = userApps.Where(x => x.AppID == appSignIn.AppID).ToList();
                appRoleServices = appRoleServices.Where(x => x.AppID == appSignIn.AppID).ToList();

                //this will get the roles under app
                #region roles
                foreach (AM_AppRoleService appRoleService in appRoleServices)
                {
                    var tempRole = await _roleProviders.get(appRoleService.RoleID.ToString());
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
                    var tempUser = await _userProviders.get(userApp.UserID.ToString());
                    //get role of that user (using userapproleservices)
                    var tempUserAppRoleService = userAppRoleServices.Where(x => x.UserAppID == userApp.UserAppID).First();
                    var tempRole = roles.Where(x => x.RoleID == tempUserAppRoleService.RoleID).First();
                    //create a UserAppRoleDTO
                    UserAppRoleDTO userAppRole = new UserAppRoleDTO
                    {
                        UserAppID = userApp.UserAppID,
                        UserID = tempUser.UserID,
                        UserName = tempUser.UserName,
                        FirstName = tempUser.FirstName,
                        LastName = tempUser.LastName,
                        Status = tempUser.Status,
                        RoleID = tempRole.RoleID,
                        RoleName = tempRole.RoleName
                    };

                    if (tempUser != null)
                    {
                        users.Add(userAppRole);
                    }
                }

                #endregion

                #region Authentication
                //filter users to specific user and send it
                var signedUser = users.Where(x => x.UserName == appSignIn.UserName).First();
                //this area will provide jwt token.
                if (signedUser != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(app.AppSecurityKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                       claims: GetCurrentClaims(signedUser),
                       signingCredentials: creds
                    );

                    var myToken = new JwtSecurityTokenHandler().WriteToken(token);

                    appToken.Token = myToken;
                }
                #endregion
            }
            #endregion
            return appToken;
        }

        private List<Claim> GetCurrentClaims(UserAppRoleDTO currentUser)
        {

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.GivenName, currentUser.FirstName == null ? "" : currentUser.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, currentUser.LastName == null ? "" : currentUser.LastName));
            claims.Add(new Claim(ClaimTypes.Role, currentUser.RoleName == null ? "" : currentUser.RoleName));

            return claims;
        }
    }

}