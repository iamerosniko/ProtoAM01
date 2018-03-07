using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public UserProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
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
        #endregion

        #region POST
        public async Task<AM_User> Post(AM_User user)
        {
            bindApiServices();

            user.Status = 1;

            string body = JsonConvert.SerializeObject(user);

            var result = await _api.Post(body);

            user = result != null ? JsonConvert.DeserializeObject<AM_User>(result) : null;

            return user;
        }

        #endregion

        #region PUT
        public async Task<AM_User> Put(string id, AM_User user)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(user);

            var result = await _api.Put(id, body);

            user = result != null ? JsonConvert.DeserializeObject<AM_User>(result) : null;

            return user;
        }

        #endregion

        #region DELETE
        public async Task<bool> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result;
        }

        #endregion

        #endregion



        private void bindApiServices()
        {
            _api = new ApiServices("Users", _authorizationtoken);
        }
    }
}
