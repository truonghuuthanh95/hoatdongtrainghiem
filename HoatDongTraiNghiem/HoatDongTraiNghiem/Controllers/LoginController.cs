using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Services;
using HoatDongTraiNghiem.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoatDongTraiNghiem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        [Route("login", Name = "login")]
        public ActionResult Login()
        {
            using (var PGd = new T_DM_PGDService())
            {
                List<T_DM_PGD> t_DM_PGDs = PGd.GetT_DM_PGDs();
                ViewBag.PGDs = t_DM_PGDs;
                using (var school = new T_DM_TruongService())
                {
                    ViewBag.Schools = school.GetT_DM_TruongsByPGDId(t_DM_PGDs[0].PGDID);
                }
            }
           
            return View();
        }
        [HttpGet]
        [Route("getTruongByPGDId/{id}")]
        public ActionResult GetSchoolsByPGDId(int id)
        {           
                using (var school = new T_DM_TruongService())
                {
                   var schools = school.GetT_DM_TruongsByPGDId(id);
                var schoolsJson = JsonConvert.SerializeObject(schools,
           Formatting.None,
           new JsonSerializerSettings()
           {
               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           });
                return Json(new ReturnFormat(200, "success", schoolsJson), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        [Route("quanlylogin", Name = "quanlylogin")]
        public ActionResult ManagerLogin()
        {

            return View();
        }
        [HttpPost]
        [Route("login")]
        public ActionResult LoginPost(string username, string password, string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {

                var user = _db.Database.SqlQuery<T_User>(@"SELECT [UserID]
      ,[UserName]
      ,[FullName]
      ,[PasswordSalt]
      ,[Password]
      ,[Mobile]
      ,[Email]
      ,[CreatedByUser]
      ,[AccountType]
      ,[DonViID]
      ,[Disabled]
      ,[ForceChangePass]
      ,[InitialPassword]
  FROM [Server_VS].[CSDL].[dbo].[T_User]
  WHERE [DonViID] = @DonViID
",new SqlParameter("@DonViID", schoolId)).SingleOrDefault();
                if (user == null)
                {
                    return Json(new ReturnFormat(400, "Không tồn tại trường", null), JsonRequestBehavior.AllowGet);
                }
                string isValid = _db.Database.SqlQuery<string>("SELECT [HCM_EDU_DATA].[dbo].[F_Password]('" + user.PasswordSalt + "','" + password + "')").FirstOrDefault();
                if (isValid == user.Password)
                {
                    Session.Add(Constant.SCHOOL_SESSION, user);
                    return Json(new ReturnFormat(200, "success", null), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new ReturnFormat(400, "Sai tên truy cập hoặc mật khẩu", null), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("quanlylogin")]
        public ActionResult ManagerLoginPost(string username, string password)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var manager = _db.Accounts.Where(s => s.Username == username && s.Password == password).SingleOrDefault();
                if (manager == null)
                {
                    return Json(new ReturnFormat(400, "Sai tên truy cập hoặc mật khẩu", null), JsonRequestBehavior.AllowGet);
                }
                else if (manager.IsActive == false)
                {
                    return Json(new ReturnFormat(400, "Tài khoản bị khóa", null), JsonRequestBehavior.AllowGet);
                }
                Session.Add(Constant.MANAGER_SESSION, manager);
                var managerPermission = _db.UserPermissions.Where(s => s.AccountId == manager.Id).ToList();
                Session.Add(Constant.MANAGER_PERMISSION_SESSION, managerPermission);
            }
            return View();
        }
    }
}