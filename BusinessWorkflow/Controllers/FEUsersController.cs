using BusinessWorkflow.Models;
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
        private UserProviders _userProviders;
        private UserAppProviders _userAppProviders;

        [HttpPost("{applicationID}")]
        public async Task<AM_UserApp> Post([FromRoute]int applicationID, [FromBody]AM_User user)
        {
            //instantiate
            _userAppProviders = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempUser = await _userProviders.Post(user);
            AM_UserApp userApp = new AM_UserApp
            {
                AppID = applicationID,
                UserID = tempUser.UserID
            };
            return await _userAppProviders.Post(userApp);
        }

        [HttpGet("{appID}")]
        public async Task<List<AM_User>> Get(int appID)
        {
            //instantiate
            _userAppProviders = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_User> users = new List<AM_User>();

            var userApps = await _userAppProviders.get();
            userApps = userApps.Where(x => x.AppID == appID).ToList();

            foreach (AM_UserApp userApp in userApps)
            {
                var tempUser = await _userProviders.get(userApp.UserID.ToString());
                if (tempUser != null)
                {
                    users.Add(tempUser);
                }
            }

            //return all users in selected application
            return users;
        }
    }
}