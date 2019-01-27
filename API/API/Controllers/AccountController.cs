using API.Hashing_Algorithm;
using API.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpStatusCode Register([FromBody] JObject user)
        {
            string username = user["username"].Value<string>();
            byte[] passBytes = Encoding.ASCII.GetBytes(user["password"].Value<string>());

            HashWithSalt hashWithSalt = new HashWithSalt(passBytes);
            DBHelper.Register(username, hashWithSalt.salt, hashWithSalt.hash);

            return HttpStatusCode.OK;
        }
    }
}
