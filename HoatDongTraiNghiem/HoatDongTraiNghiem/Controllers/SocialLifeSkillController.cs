using AutoMapper;
using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var social = new SocialLifeSkillService())
            {
                ViewBag.Socials = social.GetSocialLifeSkillsBySchoolId(school.SchoolID);
            }
            return View();
        }
        [Route("postfile")]
        [HttpPost]
        public ActionResult PostFile(HttpPostedFileBase fileKeHoach)
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return Json(new ReturnFormat(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            try
            {
                if (fileKeHoach.ContentLength > 0)
                {                   
                    using (var social = new SocialLifeSkillService())
                    {
                        string _filekehoach = Path.GetFileName(fileKeHoach.FileName);

                        bool existedFilekehoach = social.CheckExistedFileKeHoach(_filekehoach);
                        if (existedFilekehoach == true)
                        {
                            return Json(new ReturnFormat(409, "Tên file đã tồn tại. Vui lòng chọn tên khác", null), JsonRequestBehavior.AllowGet);
                        }
                        string _path2 = Path.Combine(Server.MapPath("~/UploadedFiles/SocialSkill"), _filekehoach);
                        fileKeHoach.SaveAs(_path2);
                        SocialLifeSkill socialLifeSkill = new SocialLifeSkill();
                        socialLifeSkill.FileKeHoach = _filekehoach;
                        var inserted = social.CreateSocialLifeSkills(socialLifeSkill);
                        return Json(new ReturnFormat(200, "success", inserted.Id), JsonRequestBehavior.AllowGet);
                    }                                 
                }
                else
                {
                    return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("dangki")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(int id, SocialLifeSkillDTO socialLifeSkillDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            using (var social = new SocialLifeSkillService())
            {
                SocialLifeSkill socialLifeSkill = social.GetSocialLifeSkillsById(id);
                Mapper.Map(socialLifeSkillDTO, socialLifeSkill);
                socialLifeSkill.SchoolName = school.TenTruong;
                socialLifeSkill.CreatedAt = DateTime.Now;
                socialLifeSkill.SchoolId = school.SchoolID;
                var inserted = social.UpdateSocialLifeSkills(socialLifeSkill);
                return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
            }           
        }
        [Route("chitiet/{id}")]
        [HttpGet]
        public ActionResult GetDetail(int id)
        {


            using (var social = new SocialLifeSkillService())
            {
                var socialDetail = social.GetSocialLifeSkillsById(id);
                var socialDetailJson = JsonConvert.SerializeObject(socialDetail,
           Formatting.None,
           new JsonSerializerSettings()
           {
               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           });
                return Json(new ReturnFormat(200, "success", socialDetailJson), JsonRequestBehavior.AllowGet);
            }


        }
    }
}