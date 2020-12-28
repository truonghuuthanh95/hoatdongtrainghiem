using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HoatDongTraiNghiem.Services
{
    public class T_DM_HocSinhService : IDisposable
    {
        public void Dispose()
        {

        }
        public List<T_DM_HocSinh> GetT_DM_HocSinhsByClassId(string classId)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                List<T_DM_HocSinh> t_DM_HocSinhs = _db.T_DM_HocSinh.SqlQuery($"SELECT s1.[HocSinhID], s1.[SchoolID], s2.[Ho], s2.[Ten], s2.[GioiTinh], s2.[NgaySinh], s2.[ClientHocSinhID] ,s2.[NoiSinh], s2.[CMND], s2.[DanTocID], s2.[TonGiaoID], s2.[KhuyetTatID], s2.[DoiTuongChinhSachID], s2.[SDT], s2.[HoKhau_DiaChi], s2.[HoKhau_XaID], s2.[DCTT_DiaChi], s2.[DCTT_XaID], s2.[TenCha], s2.[SDTCha], s2.[TenMe], s2.[SDTMe], s2.[TenNguoiGiamHo], s2.[SDTNguoiGiamHo], s2.[CreateBy] , s2.[CreateTime], s2.[ModifyTime] , s2.[SoQuyetDinh] , s2.[IsPending], s2.[NguoiDuyetCD], s2.[NgayDuyetCD] , s2.[LopID], s2.[LogID], s2.[CheckKey] FROM[115.74.212.98,2424].[CSDL].[dbo].[T_BienDong_Cache] as s1, [115.74.212.98,2424].[CSDL].[dbo].[T_DM_Hocsinh] as s2 WHERE s1.[HocSinhID] = s2.[HocSinhID] AND s1.[LopID] = '{classId}' AND DOTDIEMID = 12").ToList();
                return t_DM_HocSinhs;
            }

        }
        public T_DM_HocSinh GetT_DM_HocSinhHocSinhId(string hocSinhId)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                T_DM_HocSinh t_DM_HocSinhs = _db.T_DM_HocSinh.SqlQuery($"SELECT * FROM [115.74.212.98,2424].[CSDL].[dbo].[T_DM_Hocsinh] WHERE [HocSinhID] = '{hocSinhId}'").SingleOrDefault();
                return t_DM_HocSinhs;
            }

        }
        public HocSinhLopTruongDTO GetHocSinhById(string hocSinhid)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                var hocsinhloptruong = _db.Database.SqlQuery<HocSinhLopTruongDTO>($"SELECT TOP 1 s1.[HocSinhID], s1.[SchoolID], s4.[TenTruong], s2.[Ho], s2.[Ten], s2.[GioiTinh], s2.[NgaySinh], s3.[LopID], s3.[TenLop] FROM[115.74.212.98,2424].[CSDL].[dbo].[T_BienDong_Cache] as s1, [115.74.212.98,2424].[CSDL].[dbo].[T_DM_HocSinh] as s2, [115.74.212.98,2424].[CSDL].[dbo].[T_DM_Lop] as s3, [115.74.212.98,2424].[CSDL].[dbo].[T_DM_Truong] as s4 WHERE s1.[HocSinhID] = s2.[HocSinhID] AND s1.[HocSinhID] = '{hocSinhid}' AND DOTDIEMID = 12 AND s1.[LopID] = s3.[LopID] AND s1.[SchoolID] = s4.[SchoolID] ORDER BY s1.[BienDongID]").SingleOrDefault();
                return hocsinhloptruong;
            }
        }
        public List<HocSinhLopTruongDTO> GetHocSinhByListId(List<string> hocSinhid)
        {

            using (var _db = new HCM_EDU_DATA())
            {
                string hocsinhadw = "";
                foreach (var item in hocSinhid)
                {
                    hocsinhadw += "'" + item + "',";
                }
                string hocsinhIds = String.Join(",", hocSinhid.ToString());
                string query = $"SELECT s2.HocSinhID, s2.SchoolID, s2.Ho, s2.Ten, s2.GioiTinh, s2.NgaySinh, s1.LopID, s3.TenLop, s4.TenTruong FROM (SELECT HocSinhID, DotDiemID, LopID FROM [CSDL].[CSDL].[dbo].T_HocSinh_Lop AS s1 WHERE   (NOT EXISTS  (SELECT 1 AS Expr1 FROM  [115.74.212.98,2424].[CSDL].[dbo].T_HocSinh_Lop AS s2 WHERE   (s1.ID < s2.ID) AND (s1.HocSinhID = HocSinhID))) AND (HocSinhID IN ({hocsinhadw.Remove(hocsinhadw.Length - 1, 1)})) AND (LoaiBienDongID <= 200)) AS s1 INNER JOIN [115.74.212.98,2424].[CSDL].[dbo].T_DM_HocSinh AS s2 ON s1.HocSinhID = s2.HocSinhID INNER JOIN [115.74.212.98,2424].[CSDL].[dbo].T_DM_Lop AS s3 ON s1.LopID = s3.LopID INNER JOIN [115.74.212.98,2424].[CSDL].[dbo].T_DM_Truong AS s4 ON s3.SchoolID = s4.SchoolID INNER JOIN [115.74.212.98,2424].[CSDL].[dbo].T_DM_DotDiem AS s5 ON s1.DotDiemID = s5.DotDiemID";
                List<HocSinhLopTruongDTO> hocsinhloptruong = _db.Database.SqlQuery<HocSinhLopTruongDTO>(query).ToList();
                return hocsinhloptruong;
            }
        }
    }
}