using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserServices : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public UserServices(string token)
        {
            _authorizationtoken = token;
        }

        public async Task<List<AM_User>> get()
        {
            List<AM_User> users = new List<AM_User>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                users = result == null ? null : JsonConvert.DeserializeObject<List<AM_User>>(result);

            }
            catch
            {
                return users;
            }


            return users;
        }

        public async Task<AM_User> get(string id)
        {
            AM_User user = new AM_User();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                user = result == null ? null : JsonConvert.DeserializeObject<AM_User>(result);

            }
            catch
            {
                return user;
            }


            return user;
        }

        private void bindApiServices()
        {
            _api = new ApiServices("Users", _authorizationtoken);
        }
    }
}
