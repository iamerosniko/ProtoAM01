using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class RoleServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public RoleServiceProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_RoleService>> get()
        {
            List<AM_RoleService> entities = new List<AM_RoleService>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_RoleService>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_RoleService> get(string id)
        {
            AM_RoleService entity = new AM_RoleService();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_RoleService>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_RoleService> Post(AM_RoleService entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_RoleService>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_RoleService> Put(string id, AM_RoleService entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_RoleService>(result) : null;

            return entity;
        }

        #endregion

        #region DELETE
        public async Task<AM_RoleService> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_RoleService>(result) : null;
        }

        #endregion

        #endregion


        private void bindApiServices()
        {
            _api = new ApiServices("RoleServices", _authorizationtoken);
        }
    }
}