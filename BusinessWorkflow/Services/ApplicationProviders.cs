using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class ApplicationProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public ApplicationProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_Application>> get()
        {
            List<AM_Application> applications = new List<AM_Application>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                applications = result == null ? null : JsonConvert.DeserializeObject<List<AM_Application>>(result);

            }
            catch
            {
                return applications;
            }


            return applications;
        }

        public async Task<AM_Application> get(string id)
        {
            AM_Application application = new AM_Application();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                application = result == null ? null : JsonConvert.DeserializeObject<AM_Application>(result);

            }
            catch
            {
                return application;
            }


            return application;
        }
        #endregion

        #region POST
        public async Task<AM_Application> Post(AM_Application application)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(application);

            var result = await _api.Post(body);

            application = result != null ? JsonConvert.DeserializeObject<AM_Application>(result) : null;

            return application;
        }

        #endregion

        #region PUT
        public async Task<AM_Application> Put(string id, AM_Application application)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(application);

            var result = await _api.Put(id, body);

            application = result != null ? JsonConvert.DeserializeObject<AM_Application>(result) : null;

            return application;
        }

        #endregion

        #region DELETE
        public async Task<AM_Application> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_Application>(result) : null;
        }

        #endregion

        #endregion



        private void bindApiServices()
        {
            _api = new ApiServices("Applications", _authorizationtoken);
        }
    }
}