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
    [RoutePrefix("hoatdongngoaikhoa")]
    public class HoatDongNgoaiKhoaController : Controller
    {
        [Route("index")]
        // GET: HoatDongNgoaiKhoa
        public ActionResult Index()
        {

            using (var province = new ProvinceSerivce())
            {
                ViewBag.Provinces = province.GetProvinces();
            }
            using (var jobTitle = new JobtitlesService())
            {
                ViewBag.JobTitles = jobTitle.GetJobtitles();
            }
            return View();
        }
        [Route("postfile")]
        [HttpPost]
        public ActionResult PostFile(HttpPostedFileBase FileKeHoachToChuc,
            HttpPostedFileBase FilePhuongAnChiTietAnToan,
            HttpPostedFileBase FileQDThanhLapBanToChuc,
            HttpPostedFileBase FileHDKKPhoiHopToChuc,
            HttpPostedFileBase FileLichTrinhHoatDong,
            HttpPostedFileBase FileBaoHiemChuyenDi,
            HttpPostedFileBase FileNoiQuyChuyenDi,
            HttpPostedFileBase FileThuBaoChoChaMe,
            HttpPostedFileBase FileDanhSachPhanXeVaGV

            )
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            try
            {
                if (FileKeHoachToChuc.ContentLength > 0)
                {
                    using (var social = new HoatDongNgoaiKhoaService())
                    {
                        string _FileKeHoachToChuc = Path.GetFileName(FileKeHoachToChuc.FileName);
                        string _FilePhuongAnChiTietAnToan = Path.GetFileName(FilePhuongAnChiTietAnToan.FileName);
                        string _FileQDThanhLapBanToChuc = Path.GetFileName(FileQDThanhLapBanToChuc.FileName);
                        string _FileHDKKPhoiHopToChuc = Path.GetFileName(FileHDKKPhoiHopToChuc.FileName);
                        string _FileLichTrinhHoatDong = Path.GetFileName(FileLichTrinhHoatDong.FileName);
                        string _FileBaoHiemChuyenDi = Path.GetFileName(FileBaoHiemChuyenDi.FileName);
                        string _FileNoiQuyChuyenDi = Path.GetFileName(FileNoiQuyChuyenDi.FileName);
                        string _FileThuBaoChoChaMe = Path.GetFileName(FileThuBaoChoChaMe.FileName);
                        string _FileDanhSachPhanXeVaGV = Path.GetFileName(FileDanhSachPhanXeVaGV.FileName);
                        bool CheckExistedFileBaoHiemChuyenDi = social.CheckExistedFileBaoHiemChuyenDi(_FileBaoHiemChuyenDi);
                        bool CheckExistedFileDanhSachPhanXeVaGV = social.CheckExistedFileDanhSachPhanXeVaGV(_FileDanhSachPhanXeVaGV);
                        bool CheckExistedFileHDKKPhoiHopToChuc = social.CheckExistedFileHDKKPhoiHopToChuc(_FileHDKKPhoiHopToChuc);
                        bool CheckExistedFileKeHoachToChuc = social.CheckExistedFileKeHoachToChuc(_FileKeHoachToChuc);
                        bool CheckExistedFileLichTrinhHoatDong = social.CheckExistedFileLichTrinhHoatDong(_FileLichTrinhHoatDong);
                        bool CheckExistedFileNoiQuyChuyenDi = social.CheckExistedFileNoiQuyChuyenDi(_FileNoiQuyChuyenDi);
                        bool CheckExistedFilePhuongAnChiTietAnToan = social.CheckExistedFilePhuongAnChiTietAnToan(_FilePhuongAnChiTietAnToan);
                        bool CheckExistedFileQDThanhLapBanToChuc = social.CheckExistedFileQDThanhLapBanToChuc(_FileQDThanhLapBanToChuc);
                        bool CheckExistedFileThuBaoChoChaMe = social.CheckExistedFileThuBaoChoChaMe(_FileThuBaoChoChaMe);
                        bool existed = false;
                        string errorText = "Tên file: ";
                        if (CheckExistedFileBaoHiemChuyenDi == true)
                        {
                            existed = true;
                            errorText += "Bảo hiểm chuyến đi cho ban tổ chức và học sinh,";
                        }
                        if (CheckExistedFileDanhSachPhanXeVaGV == true)
                        {
                            existed = true;
                            errorText += "Danh sách phân xe và giáo viên phụ trách,";
                        }
                        if (CheckExistedFileHDKKPhoiHopToChuc == true)
                        {
                            existed = true;
                            errorText += "Hợp đồng ký kết với đơn vị phối hợp tổ chức,";
                        }
                        if (CheckExistedFileKeHoachToChuc == true)
                        {
                            existed = true;
                            errorText += "Kế hoạch tổ chức hoạt động";
                        }
                        if (CheckExistedFileLichTrinhHoatDong == true)
                        {
                            existed = true;
                            errorText += "Lịch trình hoạt động ngoài giờ chính khóa,";
                        }
                        if (CheckExistedFileNoiQuyChuyenDi == true)
                        {
                            existed = true;
                            errorText += "Nội quy chuyến đi,";
                        }
                        if (CheckExistedFilePhuongAnChiTietAnToan == true)
                        {
                            existed = true;
                            errorText += "tài liệu cho học sinh,";
                        }
                        if (CheckExistedFileQDThanhLapBanToChuc == true)
                        {
                            existed = true;
                            errorText += "Quyết định thành lập Ban tổ chức,";
                        }
                        if (CheckExistedFileThuBaoChoChaMe == true)
                        {
                            existed = true;
                            errorText += "Mẫu thư báo cho cha mẹ học sinh,";
                        }
                        if (existed == true)
                        {
                            errorText.Remove(errorText.Length - 1);
                            errorText += " đã tồn tại. Vui lòng đặt tên khác";
                            return Json(new ReturnFormat(409, errorText, null), JsonRequestBehavior.AllowGet);
                        }
                        string _path2 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileBaoHiemChuyenDi"),_FileBaoHiemChuyenDi);
                        string _path3 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileDanhSachPhanXeVaGV"), _FileDanhSachPhanXeVaGV);
                        string _path4 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileHDKKPhoiHopToChuc"), _FileHDKKPhoiHopToChuc);
                        string _path5 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileKeHoachToChuc"), _FileKeHoachToChuc);
                        string _path6 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileLichTrinhHoatDong"), _FileLichTrinhHoatDong);
                        string _path7 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileNoiQuyChuyenDi"), _FileNoiQuyChuyenDi);
                        string _path8 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FilePhuongAnChiTietAnToan"), _FilePhuongAnChiTietAnToan);
                        string _path9 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileQDThanhLapBanToChuc"), _FileQDThanhLapBanToChuc);
                        string _path10 = Path.Combine(Server.MapPath("~/UploadedFiles/HoatDongNgoaiKhoa/FileThuBaoChoChaMe"), _FileThuBaoChoChaMe);
                        FileBaoHiemChuyenDi.SaveAs(_path2);
                        FileDanhSachPhanXeVaGV.SaveAs(_path3);
                        FileHDKKPhoiHopToChuc.SaveAs(_path4);
                        FileKeHoachToChuc.SaveAs(_path5);
                        FileLichTrinhHoatDong.SaveAs(_path6);
                        FileNoiQuyChuyenDi.SaveAs(_path7);
                        FilePhuongAnChiTietAnToan.SaveAs(_path8);
                        FileQDThanhLapBanToChuc.SaveAs(_path9);
                        FileThuBaoChoChaMe.SaveAs(_path10);
                        HoatDongNgoaiKhoa registration = new HoatDongNgoaiKhoa();
                        registration.FileBaoHiemChuyenDi = _FileBaoHiemChuyenDi;
                        registration.FileDanhSachPhanXeVaGV = _FileDanhSachPhanXeVaGV;
                        registration.FileHDKKPhoiHopToChuc = _FileHDKKPhoiHopToChuc;
                        registration.FileKeHoachToChuc = _FileKeHoachToChuc;
                        registration.FileLichTrinhHoatDong = _FileLichTrinhHoatDong;
                        registration.FileNoiQuyChuyenDi = _FileNoiQuyChuyenDi;
                        registration.FilePhuongAnChiTietAnToan = _FilePhuongAnChiTietAnToan;
                        registration.FileQDThanhLapBanToChuc = _FileQDThanhLapBanToChuc;
                        registration.FileThuBaoChoChaMe = _FileThuBaoChoChaMe;
                        var inserted = social.CreateHoatDongNgoaiKhoa(registration);
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
        public ActionResult Create(HoatDongNgoaiKhoaDTO hoatDongNgoaiKhoaDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            using (var ngoaiKhoa = new HoatDongNgoaiKhoaService())
            {
                HoatDongNgoaiKhoa registration = ngoaiKhoa.GetHoatDongNgoaiKhoaById(hoatDongNgoaiKhoaDTO.Id);
                Mapper.Map(hoatDongNgoaiKhoaDTO, registration);
                registration.SchoolName = school.TenTruong;
                registration.CreatedAt = DateTime.Now;
                registration.SchoolId = school.SchoolID;                
                var inserted = ngoaiKhoa.UpdateHoatDongNgoaiKhoa(registration);               
                return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
            }            
        }
        [Route("danhsach")]
        [HttpGet]
        public ActionResult GetHoatDongNgoaiKhoa()
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var ngoaiKhoa = new HoatDongNgoaiKhoaService())
            {
                ViewBag.Registrations = ngoaiKhoa.GetHoatDongNgoaiKhoasBySchoolId(school.SchoolID);
            }
            return View();
        }
        [Route("chitiet/{id}")]
        [HttpGet]
        public ActionResult GetDetail(int id)
        {
            using (var ngoaiKhoa = new HoatDongNgoaiKhoaService())
            {
                var hDNgoaiKhoa = ngoaiKhoa.GetHoatDongNgoaiKhoaById(id);
                var hDNgoaiKhoaJson = JsonConvert.SerializeObject(hDNgoaiKhoa,
           Formatting.None,
           new JsonSerializerSettings()
           {
               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           });
                return Json(new ReturnFormat(200, "success", hDNgoaiKhoaJson), JsonRequestBehavior.AllowGet);
            }

        }
    }
}