using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class AppRoleServiceProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;
        private RoleProviders _roleProviders;
        private InheritedRolesProviders _inheritedRolesProviders;


        public AppRoleServiceProviders(string token)
        {
            _authorizationtoken = token;
            _roleProviders = new RoleProviders(token);
            _inheritedRolesProviders = new InheritedRolesProviders(token);
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

        #region On Delete

        public async Task<bool> DeleteAppRoles(List<AM_AppRoleService> appRoleServices)
        {
            foreach (AM_AppRoleService appRoleService in appRoleServices)
            {
                await _roleProviders.Delete(appRoleService.RoleID.ToString());
                await DeleteInheritedRoles(appRoleService.AppRoleServiceID);
                await Delete(appRoleService.AppRoleServiceID.ToString());
            }

            return true;
        }

        public async Task<bool> DeleteInheritedRoles(int appRoleServiceID)
        {
            var inheritedRoles = await _inheritedRolesProviders.get();
            inheritedRoles = inheritedRoles.Where(x => x.AppRoleServiceID == appRoleServiceID).ToList();

            foreach (AM_InheritedRole inheritedRole in inheritedRoles)
            {
                await _inheritedRolesProviders.Delete(inheritedRole.InheritedRolesID.ToString());
            }
            return true;
        }

        #endregion

        private void bindApiServices()
        {
            _api = new ApiServices("AppRoleServices", _authorizationtoken);
        }
    }
}