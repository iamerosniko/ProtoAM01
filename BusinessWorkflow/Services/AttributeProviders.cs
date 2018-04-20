using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class AttributeProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public AttributeProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_Attribute>> get()
        {
            List<AM_Attribute> entities = new List<AM_Attribute>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_Attribute>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_Attribute> get(string id)
        {
            AM_Attribute entity = new AM_Attribute();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_Attribute>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_Attribute> Post(AM_Attribute entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Attribute>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_Attribute> Put(string id, AM_Attribute entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Attribute>(result) : null;

            return entity;
        }

        #endregion

        #region DELETE
        public async Task<AM_Attribute> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_Attribute>(result) : null; ;
        }

        #endregion

        #endregion



        private void bindApiServices()
        {
            _api = new ApiServices("Attributes", _authorizationtoken);
        }
    }
}