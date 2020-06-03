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
    public class LotController : ApiController
    {
        LotActions la = new LotActions();
        // GET: api/Lot
        public IEnumerable<MLot> Get()
        {
            return la.GetLots();
        }

        // GET: api/Lot/5
        public MLot Get(int id)
        {
            return la.GetLotById(id);
        }

        // POST: api/Lot
        public void Post([FromBody]MLot value)
        {
            la.AddLot(value);
        }

        // PUT: api/Lot/5
        public void Put(int id, [FromBody]MLot value)
        {
            value.Lot_ID = id;
            la.ChangeLot(value);
        }

        // DELETE: api/Lot/5
        public void Delete(int id)
        {
            la.DeleteLotByID(id);
        }
    }
}
