using AutoMapper;
using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("ngoainhatruong")]
    public class NgoaiNhaTruongController : Controller
    {
        // GET: NgoaiNhaTruong
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {

            using (var program = new ProgramsService())
            {
                ViewBag.Programs = program.GetPrograms();
                
            }
            using (var jobTitle = new JobtitlesService())
            {
                ViewBag.JobTitles = jobTitle.GetJobtitles();
            }
            
            return View();
        }
        [Route("getValidStudentQuantity/{programId}/{sesstionADay}/{date}")]
        [HttpGet]
        public int GetValidStudentQuantity(int programId, int sesstionADay, DateTime date)
        {
            using (var creative = new RegistrationReativeExpService())
            {            
                int validQuantity = creative.CheckValidQuantityStudent(programId, sesstionADay, date);
                return validQuantity;
            }          
        }
        [Route("dangkitrainghiemsangtao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCreativeExp(CreativeExpDTO creativeExpDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            var school = (T_User)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return Json(new ReturnFormat(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            RegistrationCreativeExp registrationCreativeExp = new RegistrationCreativeExp();
            Mapper.Map(creativeExpDTO, registrationCreativeExp);
            registrationCreativeExp.CreatedAt = DateTime.Now;
            registrationCreativeExp.SchoolId = school.DonViID;
            using (var creative = new RegistrationReativeExpService())
            {
                RegistrationCreativeExp registrationCreativeExpInserted = creative.SaveRegistrationCreativeExp(registrationCreativeExp);
                //SendMailService sendMailService = new SendMailService();
                //sendMailService.SendMailToTeacherAsyncRegistrationCreative(registrationCreativeExpDetail);
            }                                              
            return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
        }
        [Route("danhsach/{programId}")]
        [HttpGet]
        public ActionResult GetRegisted(int programId)
        {
            var school = (T_User)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var program = new ProgramsService())
            {
                ViewBag.Programs = program.GetPrograms();
            }
            using (var creative = new RegistrationReativeExpService())
            {
                ViewBag.Creatives = creative.GetRegistrationCreativeExpsBySchoolIdAndProgramId("123213", programId);
            }
            return View();
        }
    }
}