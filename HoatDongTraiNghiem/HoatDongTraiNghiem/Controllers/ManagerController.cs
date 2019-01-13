using HoatDongTraiNghiem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("quanly")]
    public class ManagerController : Controller
    {
        // GET: Manager
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("hoatdongtrainghiem/{programId}/{dateFrom}/{dateTo}")]
        [HttpGet]
        public ActionResult CreativeExp(int programId, DateTime dateFrom, DateTime dateTo)
        {
            using (var program = new ProgramsService())
            {
                ViewBag.Programs = program.GetPrograms();
            }
            using (var creative = new RegistrationReativeExpService())
            {
                ViewBag.Creatives = creative.GetRegistrationCreativeExpsByProgramIdAndDateRange(programId, dateFrom, dateTo);
            }
            return View();
        }
        [Route("kynangxahoikynangsong/{dateFrom}/{dateTo}")]
        [HttpGet]
        public ActionResult SocialLifeskill(DateTime dateFrom, DateTime dateTo)
        {
            using (var social = new SocialLifeSkillService())
            {
                ViewBag.Socials = social.GetSocialLifeSkills(dateFrom, dateTo);
            }
            return View();
        }

    }
}