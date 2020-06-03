using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GUI.Controllers
{
    public class AutoController : ApiController
    {
        // GET: api/Auto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auto
        public string Post([FromBody]MUser value)
        {
            UserActions UA = new UserActions();
            var t = UA.GetUsers().Where(o => o.Login == value.Login && o.Pass == value.Pass).FirstOrDefault();
            if (t != null)
            {
                return t.Role.Role_name;
            }
            else
            {
                return null;
            }
        }

        // PUT: api/Auto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auto/5
        public void Delete(int id)
        {
        }
    }
}
