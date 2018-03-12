using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class AppRoleServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public AppRoleServiceProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_AppRoleService>> get()
        {
            List<AM_AppRoleService> appRoleServices = new List<AM_AppRoleService>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                appRoleServices = result == null ? null : JsonConvert.DeserializeObject<List<AM_AppRoleService>>(result);

            }
            catch
            {
                return appRoleServices;
            }


            return appRoleServices;
        }

        public async Task<AM_AppRoleService> get(string id)
        {
            AM_AppRoleService appRoleService = new AM_AppRoleService();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                appRoleService = result == null ? null : JsonConvert.DeserializeObject<AM_AppRoleService>(result);

            }
            catch
            {
                return appRoleService;
            }


            return appRoleService;
        }
        #endregion

        #region POST
        public async Task<AM_AppRoleService> Post(AM_AppRoleService appRoleService)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(appRoleService);

            var result = await _api.Post(body);

            appRoleService = result != null ? JsonConvert.DeserializeObject<AM_AppRoleService>(result) : null;

            return appRoleService;
        }

        #endregion

        #region PUT
        public async Task<AM_AppRoleService> Put(string id, AM_AppRoleService appRoleService)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(appRoleService);

            var result = await _api.Put(id, body);

            appRoleService = result != null ? JsonConvert.DeserializeObject<AM_AppRoleService>(result) : null;

            return appRoleService;
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
            _api = new ApiServices("AppRoleServices", _authorizationtoken);
        }
    }
}