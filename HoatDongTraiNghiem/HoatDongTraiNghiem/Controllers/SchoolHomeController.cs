using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("truong")]
    public class SchoolHomeController : Controller
    {
        // GET: SchoolHome
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("maintain")]
        public ActionResult Maintain()
        {
            return View();
        }

    }
}