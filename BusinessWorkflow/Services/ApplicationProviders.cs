using BusinessWorkflow.Models;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Services
{
    public class ApplicationProviders : Controller
    {
        private ApiServices _api;
        private string _authorizationtoken;

        private AppRoleProviders _appRoleProviders;
        private AttributeProviders _attributeProviders;
        private RoleProviders _roleProviders;
        private ServiceProviders _serviceProviders;
        private ServiceAttributeProviders _serviceAttributeProviders;
        private UserProviders _userProviders;
        private UserAppProviders _userAppProviders;
        private UserAppServiceProviders _userAppServiceProviders;


        public ApplicationProviders(string token)
        {
            _authorizationtoken = token;
            //instantiate providers
            _appRoleProviders = new AppRoleProviders(token);
            _attributeProviders = new AttributeProviders(token);
            _roleProviders = new RoleProviders(token);
            _serviceProviders = new ServiceProviders(token);
            _serviceAttributeProviders = new ServiceAttributeProviders(token);
            _userProviders = new UserProviders(token);
            _userAppProviders = new UserAppProviders(token);
            _userAppServiceProviders = new UserAppServiceProviders(token);
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

            application.Status = 1;

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
        public async Task<bool> Delete(string id)
        {
            bindApiServices();

            var result = await _api.Delete(id);
            return result;
        }

        #endregion

        #endregion


        #region APP-BEHAVIOR

        #region AppRoleBehavior

        private async Task<bool> DeleteAssocToAppRole(List<AM_AppRole> appRoles)
        {
            foreach (AM_AppRole appRole in appRoles)
            {
                //delete 
                await _roleProviders.Delete(appRole.AppID.ToString());
            }

            return true;
        }

        private async Task<bool> DeleteAssocToUserApp(List<AM_UserApp> userApps)
        {
            foreach (AM_UserApp appRole in userApps)
            {
                //await _userProviders.Delete(appRole.AppID.ToString());
            }

            return true;
        }

        //private async Task<bool>

        #endregion

        private async Task<bool> OnApplicationDelete(int id)
        {
            //get all the lists of every table except application table

            var approles = await _appRoleProviders.get();
            var attributes = await _attributeProviders.get();
            var roles = await _roleProviders.get();
            var service = await _serviceProviders.get();
            var serviceAttribs = await _serviceAttributeProviders.get();
            var users = await _userProviders.get();
            var userApps = await _userAppProviders.get();
            var userAppServices = await _userAppServiceProviders.get();

            //filter every tables accoring to its application

            approles = approles.Where(x => x.AppID == id).ToList();

            return true;
        }
        #endregion


        private void bindApiServices()
        {
            _api = new ApiServices("Applications", _authorizationtoken);
        }
    }
}