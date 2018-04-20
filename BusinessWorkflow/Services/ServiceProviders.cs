using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class ServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;
        private AttributeProviders _attributeProviders;
        private ServiceAttributeProviders _serviceAttributeProviders;

        public ServiceProviders(string token)
        {
            _authorizationtoken = token;
            _attributeProviders = new AttributeProviders(token);
            _serviceAttributeProviders = new ServiceAttributeProviders(token);
        }

        #region API

        #region GET
        public async Task<List<AM_Service>> get()
        {
            List<AM_Service> entities = new List<AM_Service>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_Service>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_Service> get(string id)
        {
            AM_Service entity = new AM_Service();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_Service>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_Service> Post(AM_Service entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Service>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_Service> Put(string id, AM_Service entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_Service>(result) : null;

            return entity;
        }

        #endregion

        #region DELETE
        public async Task<AM_Service> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_Service>(result) : null;
        }

        #endregion

        #endregion

        #region On Delete

        public async Task<bool> DeleteServices(List<AM_Service> services)
        {
            foreach (AM_Service service in services)
            {
                await DeleteServiceAttributes(service.ServiceID);
                await Delete(service.ServiceID.ToString());
            }

            return true;
        }

        public async Task<bool> DeleteServiceAttributes(int serviceID)
        {
            var serviceAttributes = await _serviceAttributeProviders.get();
            serviceAttributes = serviceAttributes.Where(x => x.ServiceID == serviceID).ToList();

            foreach (AM_ServiceAttribute serviceAttribute in serviceAttributes)
            {
                //delete attributes
                await _attributeProviders.Delete(serviceAttribute.AttribID.ToString());
                await _serviceAttributeProviders.Delete(serviceAttribute.ServiceAttributeID.ToString());
            }
            return true;
        }

        #endregion

        private void bindApiServices()
        {
            _api = new ApiServices("Services", _authorizationtoken);
        }
    }
}