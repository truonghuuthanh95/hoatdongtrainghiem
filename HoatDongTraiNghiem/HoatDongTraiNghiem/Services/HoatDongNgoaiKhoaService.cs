using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class HoatDongNgoaiKhoaService : IDisposable
    {
        public void Dispose()
        {
           
        }

        public HoatDongNgoaiKhoa GetHoatDongNgoaiKhoaById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Include("JobTitle").Include("Province").Where(s => s.Id == id).SingleOrDefault();
                return hoatDongNgoaiKhoa;
            }
        }
        public HoatDongNgoaiKhoa CreateHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hoatDongNgoaiKhoa)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.HoatDongNgoaiKhoas.Add(hoatDongNgoaiKhoa);
                _db.SaveChanges();
                return hoatDongNgoaiKhoa;
            }
        }
        public HoatDongNgoaiKhoa UpdateHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hoatDongNgoaiKhoa)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.Entry(hoatDongNgoaiKhoa).State = EntityState.Modified;
                _db.SaveChanges();
                return hoatDongNgoaiKhoa;
            }
        }
        public List<HoatDongNgoaiKhoa> GetHoatDongNgoaiKhoasBySchoolId(string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.HoatDongNgoaiKhoas.Include("JobTitle").Include("Province").Where(s => s.SchoolId == schoolId).OrderBy(s => s.DateRegisted).ToList();
                return list;
            }
        }
        public List<HoatDongNgoaiKhoa> GetHoatDongNgoaiKhoasByRange(DateTime dateFrom, DateTime dateTo)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.HoatDongNgoaiKhoas.Include("JobTitle").Include("Province").Where(s => s.DateRegisted >= dateFrom && s.DateRegisted <= dateTo).Where(s => s.SchoolId != null).OrderBy(s => s.DateRegisted).ToList();
                return list;
            }
        }
        public bool CheckExistedFileKeHoachToChuc(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileKeHoachToChuc == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileBaoHiemChuyenDi(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileBaoHiemChuyenDi == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileDanhSachPhanXeVaGV(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileDanhSachPhanXeVaGV == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileHDKKPhoiHopToChuc(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileHDKKPhoiHopToChuc == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileLichTrinhHoatDong(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileLichTrinhHoatDong == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileNoiQuyChuyenDi(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileNoiQuyChuyenDi == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFilePhuongAnChiTietAnToan(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FilePhuongAnChiTietAnToan == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileQDThanhLapBanToChuc(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileQDThanhLapBanToChuc == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }
        public bool CheckExistedFileThuBaoChoChaMe(string fileName)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                HoatDongNgoaiKhoa hoatDongNgoaiKhoa = _db.HoatDongNgoaiKhoas.Where(s => s.FileThuBaoChoChaMe == fileName).SingleOrDefault();
                if (hoatDongNgoaiKhoa == null)
                {
                    return false;
                }
                return true;
            }

        }

    }
}