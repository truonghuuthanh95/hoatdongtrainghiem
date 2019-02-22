using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class HDHocTapTraiNghiemService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public Registration CreateRegistration(Registration registration)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.Registrations.Add(registration);
                _db.SaveChanges();
                return registration;
            }
        }
        public Registration UpdateRegistration(Registration registration)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.Entry(registration).State = EntityState.Modified;
                _db.SaveChanges();
                return registration;
            }
        }

        public List<Registration> GetRegistrationsBySchoolId(string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.Registrations.Include("Jobtitle").Include("Province").Where(s => s.SchoolId == schoolId).OrderBy(s => s.DateRegisted).ToList();
                return list;
            }
        }
        public List<Registration> GetRegistrations(DateTime dateFrom, DateTime dateTo)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.Registrations.Include("Jobtitle").Include("Province").Where(s => s.DateRegisted >= dateFrom && s.DateRegisted <= dateTo && s.SchoolId != null).OrderBy(s => s.DateRegisted).ToList();
                return list;
            }
        }
        public Registration GetRegistrationsById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var social = _db.Registrations.Include("Jobtitle").Include("Province").Where(s => s.Id == id).SingleOrDefault();
                return social;
            }
        }
        public bool CheckExistedFileKeHoach(string fileKeHoach)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                Registration registration = _db.Registrations.Where(s => s.FileKeHoach == fileKeHoach && s.SchoolId != null).FirstOrDefault();
                if (registration == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileTaiLieu(string filetailieu)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                Registration registration = _db.Registrations.Where(s => s.FileKeHoach == filetailieu && s.SchoolId != null).FirstOrDefault();
                if (registration == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileKiemTra(string filekiemtra)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                Registration registration = _db.Registrations.Where(s => s.FileBaiKiemTra == filekiemtra && s.SchoolId != null).FirstOrDefault();
                if (registration == null)
                {
                    return false;
                }
                return true;
            }

        }

    }
}