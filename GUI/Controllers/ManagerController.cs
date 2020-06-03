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
    public class ManagerController : ApiController
    {
        LotActions la = new LotActions();
        // GET: api/Manager
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Manager/5
        public IEnumerable<MLot> Get([FromBody]string value)
        {
            switch (value)
            {
                case "1":
                    return la.GetActiveLots();
                case "2":
                    return la.GetNonActiveLots();
                default:
                    return null;
            }
        }

        // POST: api/Manager
        public IEnumerable<MLot> Post([FromBody]string[] value)
        {
            return null;
        }

        // PUT: api/Manager/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Manager/5
        public void Delete(int id)
        {
        }
    }
}
