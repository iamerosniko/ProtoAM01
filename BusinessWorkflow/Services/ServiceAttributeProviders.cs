using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class ServiceAttributeProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public ServiceAttributeProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_ServiceAttribute>> get()
        {
            List<AM_ServiceAttribute> entities = new List<AM_ServiceAttribute>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_ServiceAttribute>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_ServiceAttribute> get(string id)
        {
            AM_ServiceAttribute entity = new AM_ServiceAttribute();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_ServiceAttribute>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_ServiceAttribute> Post(AM_ServiceAttribute entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_ServiceAttribute>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_ServiceAttribute> Put(string id, AM_ServiceAttribute entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_ServiceAttribute>(result) : null;

            return entity;
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
            _api = new ApiServices("ServiceAttributes", _authorizationtoken);
        }
    }
}