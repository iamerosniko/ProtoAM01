using API.BTAMUSER;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/BTAM_Users")]
    public class BTAM_UsersController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public BTAM_UsersController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public BTAM_User[] Get()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var jsonText = System.IO.File.ReadAllText(contentRootPath + "/BTAMUSER/user.json");
            var sponsors = JsonConvert.DeserializeObject<BTAM_User[]>(jsonText);
            return sponsors;
        }
        [HttpGet("{id}")]
        public BTAM_User[] Get([FromRoute]int id)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var jsonText = System.IO.File.ReadAllText(contentRootPath + "/BTAMUSER/user.json");

            var sponsors = JsonConvert.DeserializeObject<BTAM_User[]>(jsonText);
            //sponsors.BTAM_PassWord = "2";
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(sponsors, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(contentRootPath + "/BTAMUSER/user.json", output);

            return Get();
        }

        [Route("ResetAdmin/{securityID}")]
        [HttpPost]
        public void ResetAdmin([FromBody]BTAM_User btamuser)
        {
            var users = Get();
            var user = users.Where(x => x.BTAM_UserName == btamuser.BTAM_UserName && x.BTAM_PassWord == btamuser.BTAM_PassWord && x.BTAMSECURITYKEY == btamuser.BTAMSECURITYKEY).FirstOrDefault();
            if (user != null)
            {
                var adminuser = new BTAM_User
                {
                    BTAMSECURITYKEY = "9aefcfcb-50ff-47a7-9998-1b6d1eb491d1",
                    BTAM_PassWord = "Admin",
                    BTAM_UserName = "Admin"
                };
            }
        }

        [Route("UpdateAdminPassword")]
        [HttpPost]
        public void Update([FromBody]BTAM_User btamuser)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var users = Get();
            var tempUsers = users.Where(x => x.BTAM_UserName.ToLower() != "admin");
            tempUsers = tempUsers.Append(btamuser);

            if (btamuser != null)
            {
                if (btamuser.BTAM_PassWord != null || !btamuser.BTAM_PassWord.Equals(""))
                {
                    btamuser.BTAMSECURITYKEY = "9aefcfcb-50ff-47a7-9998-1b6d1eb491d1";
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(tempUsers, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(contentRootPath + "/BTAMUSER/user.json", output);
                }
            }
        }
    }
}