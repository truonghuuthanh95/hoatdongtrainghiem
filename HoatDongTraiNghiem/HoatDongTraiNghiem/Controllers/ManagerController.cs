using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var manager = (Account)Session[Constant.MANAGER_SESSION];
            if (manager == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            
            var managerPersmission = (List<UserPermission>)Session[Constant.MANAGER_PERMISSION_SESSION];
            //var permission = 1;
            if (managerPersmission.Where(s => s.PermissionId == 1).FirstOrDefault() == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            using (var program = new ProgramsService())
            {
                var programs = program.GetProgramsByAccountId(manager.Id);
                ViewBag.Programs = programs;
                using (var creative = new RegistrationReativeExpService())
                {
                    if (programs.Where(s => s.Id == programId).SingleOrDefault() == null)
                    {
                        ViewBag.Creatives = creative.GetRegistrationCreativeExpsByProgramIdAndDateRange(programs[0].Id, dateFrom, dateTo);
                    }
                    else
                    {
                        ViewBag.Creatives = creative.GetRegistrationCreativeExpsByProgramIdAndDateRange(programId, dateFrom, dateTo);
                    }
                    
                }
                ViewBag.ProgramId = programs[0].Id;
            }           
            return View();
        }
        [Route("kynangxahoikynangsong/{dateFrom}/{dateTo}")]
        [HttpGet]
        public ActionResult SocialLifeskill(DateTime dateFrom, DateTime dateTo)
        {
            var manager = (Account)Session[Constant.MANAGER_SESSION];
            if (manager == null)
            {
                return RedirectToRoute("quanlylogin");
            }

            var managerPersmission = (List<UserPermission>)Session[Constant.MANAGER_PERMISSION_SESSION];
            //var permission = 3;
            if (managerPersmission.Where(s => s.PermissionId == 3).FirstOrDefault() == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            using (var social = new SocialLifeSkillService())
            {
                ViewBag.Socials = social.GetSocialLifeSkills(dateFrom, dateTo);
            }
            ViewBag.DateFrom = dateFrom.ToString("dd-MM-yyyy");
            ViewBag.DateTo = dateTo.ToString("dd-MM-yyyy");
            return View();
        }
        [Route("xuatexceltrainghiemsangtao/{dateFrom}/{dateTo}/{programId}")]
        [HttpGet]
        public async Task<ActionResult> ExportExcelCreativeExp(DateTime dateFrom, DateTime dateTo, int programId)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];
            var school = (T_User)Session[Utils.Constant.SCHOOL_SESSION];
            if (account == null && school == null)
            {
                return RedirectToRoute("login");
            }
            using (var creative = new RegistrationReativeExpService())
            {
                List<RegistrationCreativeExp> registrationCreativeExps = creative.GetRegistrationCreativeExpsByProgramIdAndDateRange(programId, dateFrom, dateTo);
                string fileName = string.Concat("ds-trainghiemsangtao.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                await Utils.ExportExcel.GenerateXLSRegistrationCreativeExp(registrationCreativeExps, dateFrom, dateTo, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }
            
        }
        [Route("xuatexcelkinangsong/{dateFrom}/{dateTo}")]
        [HttpGet]
        public async Task<ActionResult> ExportSocialLifeSkill(DateTime dateFrom, DateTime dateTo)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];
            var school = (T_User)Session[Utils.Constant.SCHOOL_SESSION];
            if (account == null && school == null)
            {
                return RedirectToRoute("login");
            }
            using (var social = new SocialLifeSkillService())
            {
                List<SocialLifeSkill> socialLifeSkills = social.GetSocialLifeSkills(dateFrom, dateTo);
                string fileName = string.Concat("ds-kynangsong.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                await Utils.ExportExcel.GenerateXLSSocialLifeSkill(socialLifeSkills, dateFrom, dateTo, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }
            
        }

    }
}