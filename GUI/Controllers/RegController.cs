using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BLL.Models;

namespace GUI.Controllers
{
    public class RegController : ApiController
    {
        // GET: api/Reg
        public IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // GET: api/Reg/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Reg
        public void Post([FromBody]MUser value)
        {
            UserActions ua = new UserActions();

            ua.AddUser(value);
        }

        // PUT: api/Reg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reg/5
        public void Delete(int id)
        {
        }
    }
}
