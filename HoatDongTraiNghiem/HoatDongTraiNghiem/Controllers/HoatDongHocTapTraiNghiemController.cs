using AutoMapper;
using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("hoatdonghoctaptrainghiem")]
    public class HoatDongHocTapTraiNghiemController : Controller
    {
        // GET: HoatDongHocTapTraiNghiem
        [Route("index")]
        public ActionResult Index()
        {
            using (var province = new ProvinceSerivce())
            {
                ViewBag.Provinces = province.GetProvinces();
            }
            using (var subject = new SubjectService())
            {
                ViewBag.Subjects = subject.GetSubjects();
            }

            return View();
        }
        [Route("postfile")]
        [HttpPost]
        public ActionResult PostFile(HttpPostedFileBase fileKeHoach, HttpPostedFileBase filebaikiemtra, HttpPostedFileBase filetailieuchohocsinh)
        {
            try
            {
                if (fileKeHoach.ContentLength > 0)
                {
                    using (var social = new HDHocTapTraiNghiemService())
                    {
                        string _filekehoach = Path.GetFileName(fileKeHoach.FileName);
                        string _filebaikiemtra = Path.GetFileName(filebaikiemtra.FileName);
                        string _filetailieuchohocsinh = Path.GetFileName(filetailieuchohocsinh.FileName);
                        bool existedFilekehoach = social.CheckExistedFileKeHoach(_filekehoach);
                        bool existedFilebaikiemtra = social.CheckExistedFileKeHoach(_filekehoach);
                        bool existedFiletailieuhocsinh = social.CheckExistedFileKeHoach(_filekehoach);
                        bool existed = false;
                        string errorText = "Tên file: ";
                        if (existedFilekehoach == true)
                        {
                            existed = true;
                            errorText += "kế hoạch,";
                        }
                        if (existedFilebaikiemtra == true)
                        {
                            existed = true;
                            errorText += "bải kiểm tra,";
                        }
                        if (existedFiletailieuhocsinh == true)
                        {
                            existed = true;
                            errorText += "tài liệu cho học sinh,";
                        }
                        if (existed == true)
                        {
                            errorText.Remove(errorText.Length - 1);
                            errorText += " đã tồn tại. Vui lòng đặt tên khác";
                            return Json(new ReturnFormat(409, errorText, null), JsonRequestBehavior.AllowGet);
                        }
                        string _path2 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongHocTapTraiNghiem"), _filekehoach);
                        string _path3 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongHocTapTraiNghiem"), _filebaikiemtra);
                        string _path4 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongHocTapTraiNghiem"), _filetailieuchohocsinh);
                        fileKeHoach.SaveAs(_path2);
                        fileKeHoach.SaveAs(_path3);
                        fileKeHoach.SaveAs(_path4);
                        Registration registration = new Registration();
                        registration.FileKeHoach = _filekehoach;
                        registration.FileBaiKiemTra = _filebaikiemtra;
                        registration.FileTaiLieuChoHS = _filetailieuchohocsinh;
                        var inserted = social.CreateRegistration(registration);
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
        public ActionResult Registration(int id, RegistrationDTO registrationDTO, string SubjectSelected)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            using (var registrationService = new HDHocTapTraiNghiemService())
            {
                Registration registration = registrationService.GetRegistrationsById(id);
                Mapper.Map(registrationDTO, registration);
                registration.SchoolName = school.TenTruong;
                registration.CreatedAt = DateTime.Now;
                registration.SchoolId = school.SchoolID;
                string[] arraySubject = SubjectSelected.Split(new char[] { ',' });               
                var inserted = registrationService.UpdateRegistration(registration);
                foreach (var item in arraySubject)
                {
                    using (var subjectRegisted = new SubjectRegistedService())
                    {
                        SubjectsRegisted subjectsRegisted = new SubjectsRegisted();
                        subjectsRegisted.SubjectId = Convert.ToInt32(item);
                        subjectsRegisted.RegistrationId = registrationDTO.Id;
                        subjectRegisted.CreateSubjectRegisted(subjectsRegisted);
                    }
                }
                return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("danhsach")]
        [HttpGet]
        public ActionResult GetRegistration()
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var hDTraiNghiem = new HDHocTapTraiNghiemService())
            {
                ViewBag.Registrations = hDTraiNghiem.GetRegistrationsBySchoolId(school.SchoolID);
            }
            return View();
        }
    }
}