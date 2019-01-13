using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [Route("lienhe")]
        public ActionResult Index()
        {
            return View();
        }
    }
}