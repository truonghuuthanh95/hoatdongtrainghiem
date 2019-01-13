using AutoMapper;
using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DTO;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("kynangxahoikynangsong")]
    public class SocialLifeSkillController : Controller
    {
        // GET: SocialLifeSkill
        [Route("index")]
        [HttpGet]
        public ActionResult Index()
        {
            using (var jobTitle = new JobtitlesService())
            {
                ViewBag.JobTitles = jobTitle.GetJobtitles();
            }
            return View();
        }
        [Route("danhsach")]
        [HttpGet]
        public ActionResult GetSocialLifeSkill()
        {
           
            return View();
        }
        [Route("dangki")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(SocialLifeSkillDTO socialLifeSkillDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            SocialLifeSkill socialLifeSkill = new SocialLifeSkill();
            Mapper.Map(socialLifeSkillDTO, socialLifeSkill);
            using (var social = new SocialLifeSkillService())
            {
                var inserted = social.CreateSocialLifeSkills(socialLifeSkill);
                return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
            }           
        }
    }
}