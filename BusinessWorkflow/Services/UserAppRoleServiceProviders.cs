using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserAppRoleServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public UserAppRoleServiceProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_UserAppRoleService>> get()
        {
            List<AM_UserAppRoleService> userAppRoleServices = new List<AM_UserAppRoleService>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                userAppRoleServices = result == null ? null : JsonConvert.DeserializeObject<List<AM_UserAppRoleService>>(result);

            }
            catch
            {
                return userAppRoleServices;
            }


            return userAppRoleServices;
        }

        public async Task<AM_UserAppRoleService> get(string id)
        {
            AM_UserAppRoleService userAppRoleService = new AM_UserAppRoleService();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                userAppRoleService = result == null ? null : JsonConvert.DeserializeObject<AM_UserAppRoleService>(result);

            }
            catch
            {
                return userAppRoleService;
            }


            return userAppRoleService;
        }
        #endregion

        #region POST
        public async Task<AM_UserAppRoleService> Post(AM_UserAppRoleService userAppRoleService)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(userAppRoleService);

            var result = await _api.Post(body);

            userAppRoleService = result != null ? JsonConvert.DeserializeObject<AM_UserAppRoleService>(result) : null;

            return userAppRoleService;
        }

        #endregion

        #region PUT
        public async Task<AM_UserAppRoleService> Put(string id, AM_UserAppRoleService userAppRoleService)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(userAppRoleService);

            var result = await _api.Put(id, body);

            userAppRoleService = result != null ? JsonConvert.DeserializeObject<AM_UserAppRoleService>(result) : null;

            return userAppRoleService;
        }

        #endregion

        #region DELETE
        public async Task<AM_UserAppRoleService> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_UserAppRoleService>(result) : null;
        }

        #endregion

        #endregion



        private void bindApiServices()
        {
            _api = new ApiServices("UserAppRoleServices", _authorizationtoken);
        }
    }
}