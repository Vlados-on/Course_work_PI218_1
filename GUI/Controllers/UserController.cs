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
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<MUser> Get()
        {
            UserActions u1 = new UserActions();
            return u1.GetUsers();
        }

        // GET: api/User/5
        public MUser Get(int id)
        {
            UserActions u1 = new UserActions();
            return u1.GetUserById(id);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            UserActions u1 = new UserActions();
            u1.DeleteUserByID(id);
        }
    }
}
