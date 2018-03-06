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

        public async Task<IActionResult> Post(string body)
        {
            var result = await _api.PostRequest(body);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        public async Task<IActionResult> Put(string id, string body)
        {
            var result = await _api.PutRequest(id, body);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        public async Task<IActionResult> Put(string id)
        {
            var result = await _api.DeleteRequest(id);
            if (result == false)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
