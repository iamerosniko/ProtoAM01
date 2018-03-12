using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class InheritedRolesProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        public InheritedRolesProviders(string token)
        {
            _authorizationtoken = token;
        }

        #region API

        #region GET
        public async Task<List<AM_InheritedRole>> get()
        {
            List<AM_InheritedRole> inheritedRoles = new List<AM_InheritedRole>();
            bindApiServices();

            var result = await _api.Get();
            try
            {
                inheritedRoles = result == null ? null : JsonConvert.DeserializeObject<List<AM_InheritedRole>>(result);

            }
            catch
            {
                return inheritedRoles;
            }


            return inheritedRoles;
        }

        public async Task<AM_InheritedRole> get(string id)
        {
            AM_InheritedRole inheritedRole = new AM_InheritedRole();
            bindApiServices();

            var result = await _api.Get(id);
            try
            {
                inheritedRole = result == null ? null : JsonConvert.DeserializeObject<AM_InheritedRole>(result);

            }
            catch
            {
                return inheritedRole;
            }


            return inheritedRole;
        }
        #endregion

        #region POST
        public async Task<AM_InheritedRole> Post(AM_InheritedRole inheritedRole)
        {
            bindApiServices();

            string body = JsonConvert.SerializeObject(inheritedRole);

            var result = await _api.Post(body);

            inheritedRole = result != null ? JsonConvert.DeserializeObject<AM_InheritedRole>(result) : null;

            return inheritedRole;
        }

        #endregion

        #region PUT
        public async Task<AM_InheritedRole> Put(string id, AM_InheritedRole inheritedRole)
        {
            bindApiServices();
            string body = JsonConvert.SerializeObject(inheritedRole);

            var result = await _api.Put(id, body);

            inheritedRole = result != null ? JsonConvert.DeserializeObject<AM_InheritedRole>(result) : null;

            return inheritedRole;
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
            _api = new ApiServices("InheritedRoles", _authorizationtoken);
        }
    }
}