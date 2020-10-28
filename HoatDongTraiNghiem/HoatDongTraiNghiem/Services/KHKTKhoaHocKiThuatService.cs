using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class KHKTKhoaHocKiThuatService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public KhoaHocKiThuat CreateKhoaHocKiThuat(KhoaHocKithuatDTO khoaHocKithuatDTO)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                KhoaHocKiThuat khoaHocKiThuat = new KhoaHocKiThuat();
                khoaHocKiThuat.DongGopHs1 = khoaHocKithuatDTO.DongGopHs1;
                khoaHocKiThuat.DongGopHs2 = khoaHocKithuatDTO.DongGopHs2;
                khoaHocKiThuat.HocSinh1 = khoaHocKithuatDTO.HocSinh1;
                khoaHocKiThuat.HocSinh2 = khoaHocKithuatDTO.HocSinh2;
                khoaHocKiThuat.IsCaNhan = khoaHocKithuatDTO.IsCaNhan;
                khoaHocKiThuat.LinhVucId = khoaHocKithuatDTO.LinhVucId;
                khoaHocKiThuat.LopIdHocSinh1 = khoaHocKithuatDTO.LopIdHocSinh1;
                khoaHocKiThuat.LopIdhocSinh2 = khoaHocKithuatDTO.LopIdhocSinh2;
                khoaHocKiThuat.TenDeTai = khoaHocKithuatDTO.TenDeTai;
                khoaHocKiThuat.SchoolId = khoaHocKithuatDTO.SchoolId;
                khoaHocKiThuat.CreatedAt = DateTime.Now;
                khoaHocKiThuat.GVHD = khoaHocKithuatDTO.GVHD;
                khoaHocKiThuat.Email = khoaHocKithuatDTO.Email;
                khoaHocKiThuat.SDT = khoaHocKithuatDTO.SDT;
                khoaHocKiThuat.DVCongTac = khoaHocKithuatDTO.DVCongTac;
                _db.KhoaHocKiThuats.Add(khoaHocKiThuat);
                _db.SaveChanges();
                return khoaHocKiThuat;
            }
            
        }


        public bool DeleteKHKTById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                //KhoaHocKiThuat khoaHocKiThuat = GetKhoaHocKiThuatById(id);
                //_db.KhoaHocKiThuats.Remove(khoaHocKiThuat);
                //_db.SaveChanges();
                _db.Database.ExecuteSqlCommand($"DELETE FROM [KhoaHocKiThuat] WHERE Id ={id}");
                return true;
            }
                
        }

        public List<KhoaHocKiThuat> GetKhoaHocKiThuatByDeTaiId(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                List<KhoaHocKiThuat> khoaHocKiThuats = _db.KhoaHocKiThuats.Where(s => s.LinhVucId == id && s.CreatedAt.Value.Year == DateTime.Now.Year).ToList();
                return khoaHocKiThuats;
            }
        }

        public KhoaHocKiThuat GetKhoaHocKiThuatById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {

                KhoaHocKiThuat khoaHocKiThuat = _db.KhoaHocKiThuats.Where(s => s.Id == id).SingleOrDefault();
                return khoaHocKiThuat;
            }
        }

        public List<KhoaHocKiThuatDetailDTO> GetKhoaHocKiThuats()
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {

                List<KhoaHocKiThuat> dsDaDangKi = _db.KhoaHocKiThuats.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year).ToList();
                List<KhoaHocKiThuatDetailDTO> khoaHocKiThuatDetailDTOs = new List<KhoaHocKiThuatDetailDTO>();
                if (dsDaDangKi.Count() > 0)
                {
                    foreach (var item in dsDaDangKi)
                    {
                        KhoaHocKiThuatDetailDTO khoaHocKiThuatDetailDTO = new KhoaHocKiThuatDetailDTO();
                        using (var _dbhocsinh = new T_DM_HocSinhService())
                        {
                            using (var _dblop = new T_DM_LopService())
                            {
                                using (var _dbSchool = new T_DM_TruongService())
                                {

                                    if (item.HocSinh2 != null)
                                    {

                                        khoaHocKiThuatDetailDTO.KhoaHocKiThuat = item;
                                        khoaHocKiThuatDetailDTO.KHKTLinhVucThamGia = _db.KHKTLinhVucThamGias.Where(s => s.Id == item.LinhVucId).SingleOrDefault();
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong1 = _dbhocsinh.GetHocSinhById(item.HocSinh1);
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong2 = _dbhocsinh.GetHocSinhById(item.HocSinh2);
                                        khoaHocKiThuatDetailDTOs.Add(khoaHocKiThuatDetailDTO);
                                    }
                                    else
                                    {
                                        khoaHocKiThuatDetailDTO.KhoaHocKiThuat = item;
                                        khoaHocKiThuatDetailDTO.KHKTLinhVucThamGia = _db.KHKTLinhVucThamGias.Where(s => s.Id == item.LinhVucId).SingleOrDefault();
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong1 = _dbhocsinh.GetHocSinhById(item.HocSinh1);
                                        khoaHocKiThuatDetailDTOs.Add(khoaHocKiThuatDetailDTO);
                                    }
                                }
                            }
                        }
                    }


                }
                return khoaHocKiThuatDetailDTOs;
            }
        }

        public List<KhoaHocKiThuatDetailDTO> GetKhoaHocKiThuatsBySchoolId(string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                List<KhoaHocKiThuat> dsDaDangKi = _db.KhoaHocKiThuats.Where(s => s.SchoolId == schoolId && s.CreatedAt.Value.Year == DateTime.Now.Year).ToList();
                List<KhoaHocKiThuatDetailDTO> khoaHocKiThuatDetailDTOs = new List<KhoaHocKiThuatDetailDTO>();
                if (dsDaDangKi.Count() > 0)
                {
                    foreach (var item in dsDaDangKi)
                    {
                        KhoaHocKiThuatDetailDTO khoaHocKiThuatDetailDTO = new KhoaHocKiThuatDetailDTO();
                        using (var _dbhocsinh = new T_DM_HocSinhService())
                        {
                            using (var _dblop = new T_DM_LopService())
                            {
                                using (var _dbSchool = new T_DM_TruongService())
                                {
                                    if (item.HocSinh2 != null)
                                    {

                                        khoaHocKiThuatDetailDTO.KhoaHocKiThuat = item;
                                        khoaHocKiThuatDetailDTO.KHKTLinhVucThamGia = _db.KHKTLinhVucThamGias.Where(s => s.Id == item.LinhVucId).SingleOrDefault();
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong1 = _dbhocsinh.GetHocSinhById(item.HocSinh1);
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong2 = _dbhocsinh.GetHocSinhById(item.HocSinh2);
                                        khoaHocKiThuatDetailDTOs.Add(khoaHocKiThuatDetailDTO);
                                    }
                                    else
                                    {
                                        khoaHocKiThuatDetailDTO.KhoaHocKiThuat = item;
                                        khoaHocKiThuatDetailDTO.KHKTLinhVucThamGia = _db.KHKTLinhVucThamGias.Where(s => s.Id == item.LinhVucId).SingleOrDefault();
                                        khoaHocKiThuatDetailDTO.HocSinhLopTruong1 = _dbhocsinh.GetHocSinhById(item.HocSinh1);
                                        khoaHocKiThuatDetailDTOs.Add(khoaHocKiThuatDetailDTO);
                                    }
                                }
                            }
                        }
                    }
                }
                return khoaHocKiThuatDetailDTOs;
            }
        }

        public KhoaHocKiThuat UpdateFileTaiLieuKhoaHocKiThuat(int id, string tenFile)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                KhoaHocKiThuat khoaHocKiThuat = _db.KhoaHocKiThuats.Where(s => s.Id == id).SingleOrDefault();
                khoaHocKiThuat.FileTaiLieu = tenFile.Trim();
                _db.Entry(khoaHocKiThuat).State = EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    return null;

                }
                return khoaHocKiThuat;
            }
        }
    }
}