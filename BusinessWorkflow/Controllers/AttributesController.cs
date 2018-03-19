using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Attributes")]
    public class AttributesController : Controller
    {
        private AttributeProviders _attributeProviders;

        [HttpGet]
        public async Task<List<AM_Attribute>> Get()
        {
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var atributes = await _attributeProviders.get();
            return atributes;
        }

        [HttpGet("{id}")]
        public async Task<AM_Attribute> Get(string id)
        {
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var atribute = await _attributeProviders.get(id);
            return atribute;
        }

        [HttpPost]
        public async Task<AM_Attribute> Post([FromBody]AM_Attribute value)
        {
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _attributeProviders.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_Attribute> Put(string id, [FromBody]AM_Attribute value)
        {
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _attributeProviders.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            await _attributeProviders.Delete(id);
        }

    }
}