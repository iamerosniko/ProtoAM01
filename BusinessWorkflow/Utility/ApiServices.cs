using BusinessWorkflow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Utility
{
    public class ApiServices : Controller
    {
        private ApiAccess _api;
        private MyResult _myResult;
        public ApiServices(string controller, string authorizationToken)
        {
            _api = new ApiAccess(controller);
            _api.AssignAuthorization(authorizationToken);
        }

        public async Task<MyResult> GetConfirmation()
        {
            _myResult = new MyResult();
            var result = await _api.GetRequest();

            if (result == null)
            {
                _myResult.StatusCode = 401;
            }
            else
            {
                _myResult.Value = result;
            }
            return _myResult;
        }

        public async Task<string> Get()
        {
            var result = await _api.GetRequest();
            return result;
        }

        public async Task<string> Get(string id)
        {
            var result = await _api.GetRequest(id);
            return result;
        }

        public async Task<string> Post(string body)
        {
            var result = await _api.PostRequest(body);
            return result;
        }

        public async Task<string> Put(string id, string body)
        {
            var result = await _api.PutRequest(id, body);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _api.DeleteRequest(id);
            return result;
        }
    }
}
