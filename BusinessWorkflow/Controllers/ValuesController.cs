﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BusinessWorkflow.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            HttpContext.Session.SetString("sample", "ahahah");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("getvalues/{id}")]
        public string Get([FromRoute]string id)
        {
            HttpContext.Session.SetString("authorizationToken", "saaaaaaam");
            return HttpContext.Session.GetString("authorizationToken");
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
