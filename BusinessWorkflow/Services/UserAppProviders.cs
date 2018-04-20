using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class UserAppProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;
        private UserProviders _userProviders;
        private UserAppRoleServiceProviders _userAppRoleServiceProviders;

        public UserAppProviders(string token)
        {
            _authorizationtoken = token;
            _userProviders = new UserProviders(token);
            _userAppRoleServiceProviders = new UserAppRoleServiceProviders(token);
        }

        #region API

        #region GET
        public async Task<List<AM_UserApp>> get()
        {
            List<AM_UserApp> entities = new List<AM_UserApp>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                entities = result == null ? null : JsonConvert.DeserializeObject<List<AM_UserApp>>(result);

            }
            catch
            {
                return entities;
            }


            return entities;
        }

        public async Task<AM_UserApp> get(string id)
        {
            AM_UserApp entity = new AM_UserApp();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                entity = result == null ? null : JsonConvert.DeserializeObject<AM_UserApp>(result);

            }
            catch
            {
                return entity;
            }


            return entity;
        }
        #endregion

        #region POST
        public async Task<AM_UserApp> Post(AM_UserApp entity)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Post(body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_UserApp>(result) : null;

            return entity;
        }

        #endregion

        #region PUT
        public async Task<AM_UserApp> Put(string id, AM_UserApp entity)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(entity);

            var result = await _api.Put(id, body);

            entity = result != null ? JsonConvert.DeserializeObject<AM_UserApp>(result) : null;

            return entity;
        }

        #endregion

        #region DELETE
        public async Task<AM_UserApp> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result != null ? JsonConvert.DeserializeObject<AM_UserApp>(result) : null; ;
        }

        #endregion

        #endregion

        #region On Delete

        public async Task<bool> DeleteUserApps(List<AM_UserApp> userapps)
        {
            foreach (AM_UserApp userapp in userapps)
            {
                await DeleteUserAppRoleServices(userapp.UserAppID);
                await _userProviders.Delete(userapp.UserID.ToString());
                await Delete(userapp.UserAppID.ToString());
            }

            return true;
        }

        public async Task<bool> DeleteUserAppRoleServices(int userAppID)
        {
            var userAppRoleServices = await _userAppRoleServiceProviders.get();
            userAppRoleServices = userAppRoleServices.Where(x => x.UserAppID == userAppID).ToList();

            foreach (AM_UserAppRoleService userAppRoleService in userAppRoleServices)
            {
                await _userAppRoleServiceProviders.Delete(userAppRoleService.UserAppRoleServiceID.ToString());
            }
            return true;
        }

        #endregion

        private void bindApiServices()
        {
            _api = new ApiServices("UserApps", _authorizationtoken);
        }
    }
}