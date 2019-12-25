using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    [RoutePrefix("khoahockithuat")]
    public class KhoaHovKiThuatController : Controller
    {
        // GET: KhoaHovKiThuat
        [Route("index")]
        public ActionResult Index()
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                List<KhoaHocKiThuatDetailDTO> hocKiThuatDetailDTOs = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuatsBySchoolId(school.SchoolID);
                ViewBag.DSKHKT = hocKiThuatDetailDTOs;
            }

            return View();
        }
              
        [Route("dangki")]
        public ActionResult Dangki()
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var hCMLopRepository = new T_DM_LopService())
            {
                List<T_DM_Lop> t_DM_Lops = hCMLopRepository.GetT_DM_LopsBySchoolId(school.SchoolID);
                using (var hCMHocSinhRepository = new T_DM_HocSinhService())
                {
                    List<T_DM_HocSinh> t_DM_HocSinhs = hCMHocSinhRepository.GetT_DM_HocSinhsByClassId(t_DM_Lops[0].LopID.Trim());
                    ViewBag.Lop = t_DM_Lops;
                    ViewBag.HocSinh = t_DM_HocSinhs;
                    using (var kHHTLinhVucRepository = new KHHTLinhVucService())
                    {
                        List<KHKTLinhVucThamGia> kHKTLinhVucThamGias = kHHTLinhVucRepository.GetKHKTLinhVucThamGias();
                        ViewBag.LinhVuc = kHKTLinhVucThamGias;
                    }
                }
                

            }


            return View();
        }
        [Route("gethocsinhbylopid/{lopId}")]
        [HttpGet]
        public ActionResult GetHocSinh(string lopId)
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var hCMHocSinhRepository = new T_DM_HocSinhService())
            {
                List<T_DM_HocSinh> t_DM_HocSinhs = hCMHocSinhRepository.GetT_DM_HocSinhsByClassId(lopId.Trim());

                return Json(new ReturnFormat(200, "success", t_DM_HocSinhs), JsonRequestBehavior.AllowGet);
            }
            
        }
        [Route("submitdangki")]
        [HttpPost]
        public ActionResult DangKiKHKT(KhoaHocKithuatDTO khoaHocKithuatDTO)
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            khoaHocKithuatDTO.SchoolId = school.SchoolID;
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                KhoaHocKiThuat khoaHocKiThuat = kHKTKhoaHocKiThuatRepository.CreateKhoaHocKiThuat(khoaHocKithuatDTO);
                if (khoaHocKiThuat == null)
                {
                    return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
                }
                return Json(new ReturnFormat(200, "success", khoaHocKiThuat.Id), JsonRequestBehavior.AllowGet);
            }
            
        }
        
        [Route("uploadfiletailieu")]
        [HttpPost]
        public ActionResult UploadFileTaiLieu(int id, HttpPostedFileBase fileTaiLieu)
        {
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                try
                {
                    if (fileTaiLieu.ContentLength > 0)
                    {
                        //string filename = Path.GetFileName(fileTaiLieu.FileName);
                        KhoaHocKiThuat khoaHocKiThuat = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuatById(id);
                        if (khoaHocKiThuat == null)
                        {
                            return Json("failed");
                        }
                        string filename = String.Format("{0:00}", khoaHocKiThuat.LinhVucId) + '-' + khoaHocKiThuat.Id.ToString() + Path.GetExtension(fileTaiLieu.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles/KhoaHocKiThuat"), filename);
                        fileTaiLieu.SaveAs(_path);
                        kHKTKhoaHocKiThuatRepository.UpdateFileTaiLieuKhoaHocKiThuat(id, filename.Trim());
                        return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        kHKTKhoaHocKiThuatRepository.DeleteKHKTById(id);
                        return Json("failed");
                    }

                }
                catch
                {
                    kHKTKhoaHocKiThuatRepository.DeleteKHKTById(id);
                    return Json("failed");
                }
            }
            
        }
        [Route("taidsdangkibyschool")]
        [HttpGet]
        public async Task<ActionResult> DownloadFileByTruong()
        {
            var school = (T_DM_Truong)Session[Constant.SCHOOL_SESSION];
            if (school == null)
            {
                return RedirectToRoute("login");
            }
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                List<KhoaHocKiThuatDetailDTO> khoaHocKiThuatDetailDTOs = kHKTKhoaHocKiThuatRepository.GetKhoaHocKiThuatsBySchoolId(school.SchoolID);
                ViewBag.KHKT = khoaHocKiThuatDetailDTOs;
                string fileName = string.Concat("ds-khoahockythuat.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + fileName);
                await Utils.ExportExcel.GenerateXLSKhoaHocKiThuat(khoaHocKiThuatDetailDTOs, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);

            }
            
        }
        [Route("deletekhktbyid/{id}")]
        [HttpGet]
        public ActionResult DeleteKHKTById(int id)
        {
            using (var kHKTKhoaHocKiThuatRepository = new KHKTKhoaHocKiThuatService())
            {
                bool deleted = kHKTKhoaHocKiThuatRepository.DeleteKHKTById(id);
                if (deleted == true)
                {
                    return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
                }
                return Json(new ReturnFormat(400, "failed", null), JsonRequestBehavior.AllowGet);
            }
        }
    }
}