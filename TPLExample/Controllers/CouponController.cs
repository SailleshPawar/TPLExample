using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace TPLExample.Controllers
{
    public class CouponController : ApiController
    {
        Random random = new Random();

        [HttpGet]
        public int GetDiscountedValue(int id)
        {
            Thread.Sleep(2000);
            return random.Next(500000,1500000);
        }
    }
}
