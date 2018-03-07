using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserAppProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public UserAppProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_Role>> get()
        {
            List<AM_Role> entities = new List<AM_Role>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_Role>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_Role> get(string id)
        {
            AM_Role entity = new AM_Role();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_Role>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_Role> Post(AM_Role entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Role>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_Role> Put(string id, AM_Role entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Role>(result) : null;

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
            _api = new ApiServices("UserApps", _authorizationtoken);
        }
    }
}