using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HoatDongTraiNghiem.Models.DTO;
using System.IO.Compression;

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
                        programId = programs[0].Id;
                    }
                    else
                    {
                        ViewBag.Creatives = creative.GetRegistrationCreativeExpsByProgramIdAndDateRange(programId, dateFrom, dateTo);
                    }
                    
                }
                ViewBag.ProgramId = programId;
            }
            ViewBag.DateFrom = dateFrom.ToString("dd-MM-yyyy");
            ViewBag.DateTo = dateTo.ToString("dd-MM-yyyy");
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
        [Route("hoatdonghoctaptrainghiem/{dateFrom}/{dateTo}")]
        [HttpGet]
        public ActionResult HDHocTapTraiNghiem(DateTime dateFrom, DateTime dateTo)
        {
            var manager = (Account)Session[Constant.MANAGER_SESSION];
            if (manager == null)
            {
                return RedirectToRoute("quanlylogin");
            }

            var managerPersmission = (List<UserPermission>)Session[Constant.MANAGER_PERMISSION_SESSION];
            //var permission = 5;
            if (managerPersmission.Where(s => s.PermissionId == 5).FirstOrDefault() == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            using (var registration = new HDHocTapTraiNghiemService())
            {
                ViewBag.Registrations = registration.GetRegistrations(dateFrom, dateTo);
            }
            ViewBag.DateFrom = dateFrom.ToString("dd-MM-yyyy");
            ViewBag.DateTo = dateTo.ToString("dd-MM-yyyy");
            return View();
        }
        [Route("hoatdongtrainghiem/{dateFrom}/{dateTo}")]
        [HttpGet]
        public ActionResult HDNgoaiKhoa(DateTime dateFrom, DateTime dateTo)
        {
            var manager = (Account)Session[Constant.MANAGER_SESSION];
            if (manager == null)
            {
                return RedirectToRoute("quanlylogin");
            }

            var managerPersmission = (List<UserPermission>)Session[Constant.MANAGER_PERMISSION_SESSION];
            //var permission = 7;
            if (managerPersmission.Where(s => s.PermissionId == 7).FirstOrDefault() == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            using (var registration = new HoatDongNgoaiKhoaService())
            {
                ViewBag.Registrations = registration.GetHoatDongNgoaiKhoasByRange(dateFrom, dateTo);
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
            if (account == null )
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
        [Route("xuatexcelhdngoaikhoa/{dateFrom}/{dateTo}")]
        [HttpGet]
        public async Task<ActionResult> ExportHDNgoaiKhoa(DateTime dateFrom, DateTime dateTo)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];           
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var social = new HoatDongNgoaiKhoaService())
            {
                List<HoatDongNgoaiKhoa> hoatDongNgoaiKhoas = social.GetHoatDongNgoaiKhoasByRange(dateFrom, dateTo);
                string fileName = string.Concat("ds-hdngoaikhoa.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                await Utils.ExportExcel.GenerateXLSHoatDongNgoaiKhoa(hoatDongNgoaiKhoas, dateFrom, dateTo, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }

        }
        [Route("xuatexcelhdhoctaptrainghiem/{dateFrom}/{dateTo}")]
        [HttpGet]
        public async Task<ActionResult> ExportHDHocTapTraiNghiem(DateTime dateFrom, DateTime dateTo)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];           
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var social = new HDHocTapTraiNghiemService())
            {
                List<Registration> registrations = social.GetRegistrations(dateFrom, dateTo);
                string fileName = string.Concat("ds-hdhoctaptrainghiem.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                List<SubjectsRegisted> subjectsRegisteds = new List<SubjectsRegisted>();
                foreach (var item in registrations)
                {
                    using (var subjectRegistedService = new SubjectRegistedService())
                    {
                        List<SubjectsRegisted> subjectsRegistedsTmp = subjectRegistedService.GetSubjectsRegistedsByRegistrationId(item.Id);
                        foreach (var item01 in subjectsRegistedsTmp)
                        {
                            subjectsRegisteds.Add(item01);
                        }
                    }
                   
                }
                await Utils.ExportExcel.GenerateXLSHoatDongHocTapTraiNghiem(registrations,subjectsRegisteds, dateFrom, dateTo, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }

        }
        [Route("dskhoahockithuat")]
        [HttpGet]
        public ActionResult DsKhoaHocKiThuat()
        {
            var manager = (Account)Session[Constant.MANAGER_SESSION];
            if (manager == null)
            {
                return RedirectToRoute("quanlylogin");
            }

            var managerPersmission = (List<UserPermission>)Session[Constant.MANAGER_PERMISSION_SESSION];
            //var permission = 9;
            if (managerPersmission.Where(s => s.PermissionId == 9).FirstOrDefault() == null)
            {
                return RedirectToRoute("quanlylogin");
            }
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                using (var kHHTLinhVucRepository = new KHHTLinhVucService())
                {
                    List<KHKTLinhVucThamGia> linhVucThamGias = kHHTLinhVucRepository.GetKHKTLinhVucThamGias();
                    List<KhoaHocKiThuatDetailDTO> khoaHocKiThuatDetailDTOs = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuats();
                    ViewBag.KHKT = khoaHocKiThuatDetailDTOs;
                    ViewBag.LinhVucs = linhVucThamGias;
                    return View();
                }
                
            }
        }
        [Route("taidskhoahockithuat")]
        [HttpGet]
        public async Task<ActionResult> TaoDsKhoaHocKithuat()
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                List<KhoaHocKiThuatDetailDTO> khoaHocKiThuatDetailDTOs = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuats();
                ViewBag.KHKT = khoaHocKiThuatDetailDTOs;
                string fileName = string.Concat("ds-khoahockythuat.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                await Utils.ExportExcel.GenerateXLSKhoaHocKiThuat(khoaHocKiThuatDetailDTOs, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }
            

        }
        [Route("taifiletailieukhkt/{id}")]
        [HttpGet]
        public ActionResult TaiFileTaiLieuKHKT(int id)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                KhoaHocKiThuat khoaHocKiThuat = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuatById(id);
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/KhoaHocKiThuat/" + khoaHocKiThuat.FileTaiLieu.Trim());
                if (khoaHocKiThuat.FileTaiLieu.Contains(".docx"))
                {
                    return File(filePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", khoaHocKiThuat.FileTaiLieu);
                }
                else if (khoaHocKiThuat.FileTaiLieu.Contains(".xlsx"))
                {
                    return File(filePath, "application/vnd.ms-excel", khoaHocKiThuat.FileTaiLieu);
                }
                return File(filePath, "application/msword", khoaHocKiThuat.FileTaiLieu);
            }
            
        }
        [Route("downloadzipfile/{deTaiId}")]
        [HttpGet]
        public ActionResult DownloadZipFile(int detaiId)
        {
            Account account = (Account)Session[Utils.Constant.MANAGER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var kHHTLinhVucRepository = new KHHTLinhVucService())
            {
                using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
                {
                    KHKTLinhVucThamGia kHKTLinhVucThamGia = kHHTLinhVucRepository.GetHKTLinhVucThamGiaById(detaiId);
                    List<KhoaHocKiThuat> khoaHocKiThuats = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuatByDeTaiId(detaiId);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                        {
                            for (int i = 0; i < khoaHocKiThuats.Count; i++)
                            {
                                if (khoaHocKiThuats[i].FileTaiLieu != null)
                                {
                                    ziparchive.CreateEntryFromFile(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/KhoaHocKiThuat/" + khoaHocKiThuats[i].FileTaiLieu), khoaHocKiThuats[i].FileTaiLieu);
                                }
                            }
                        }
                        return File(memoryStream.ToArray(), "application/zip", kHKTLinhVucThamGia.Name.Trim() + ".zip");
                    }
                }
            }
            
        }
    }
}