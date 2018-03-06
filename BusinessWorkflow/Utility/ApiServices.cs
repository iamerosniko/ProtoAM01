using BusinessWorkflow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Utility
{
    public class ApiServices : Controller
    {
        private ApiAccess _api;
        public ApiServices(string controller, string authorizationToken)
        {
            _api = new ApiAccess(controller);
            _api.AssignAuthorization(authorizationToken);
        }

        public async Task<MyResult> Get()
        {
            var result = await _api.GetRequest();
            if (result == null)
            {
                return new MyResult
                {
                    Value = "",
                    StatusCode = 401
                };
            }
            return new MyResult
            {
                Value = result,
                StatusCode = 200
            }; 
        }

        public async Task<IActionResult> Get(string id)
        {
            var result = await _api.GetRequest(id);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
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
