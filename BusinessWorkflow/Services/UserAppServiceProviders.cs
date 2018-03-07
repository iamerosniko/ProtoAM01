﻿using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserAppServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public UserAppServiceProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_UserAppService>> get()
        {
            List<AM_UserAppService> entities = new List<AM_UserAppService>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_UserAppService>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_UserAppService> get(string id)
        {
            AM_UserAppService entity = new AM_UserAppService();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_UserAppService>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_UserAppService> Post(AM_UserAppService entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_UserAppService>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_UserAppService> Put(string id, AM_UserAppService entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_UserAppService>(result) : null;

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
            _api = new ApiServices("UserAppServices", _authorizationtoken);
        }
    }
}