using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using HoatDongTraiNghiem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                List<T_DM_HocSinh> t_DM_HocSinhs = _db.T_DM_HocSinh.SqlQuery($"SELECT s1.[HocSinhID], s1.[SchoolID], s2.[Ho], s2.[Ten], s2.[GioiTinh], s2.[NgaySinh], s2.[ClientHocSinhID] ,s2.[NoiSinh], s2.[CMND], s2.[DanTocID], s2.[TonGiaoID], s2.[KhuyetTatID], s2.[DoiTuongChinhSachID], s2.[SDT], s2.[HoKhau_DiaChi], s2.[HoKhau_XaID], s2.[DCTT_DiaChi], s2.[DCTT_XaID], s2.[TenCha], s2.[SDTCha], s2.[TenMe], s2.[SDTMe], s2.[TenNguoiGiamHo], s2.[SDTNguoiGiamHo], s2.[CreateBy] , s2.[CreateTime], s2.[ModifyTime] , s2.[SoQuyetDinh] , s2.[IsPending], s2.[NguoiDuyetCD], s2.[NgayDuyetCD] , s2.[LopID], s2.[LogID], s2.[CheckKey] FROM[Server_VS].[CSDL].[dbo].[T_BienDong_Cache] as s1, [Server_VS].[CSDL].[dbo].[T_DM_Hocsinh] as s2 WHERE s1.[HocSinhID] = s2.[HocSinhID] AND s1.[LopID] = '{classId}' AND DOTDIEMID = 12").ToList();
                return t_DM_HocSinhs;
            }
            
        }
        public T_DM_HocSinh GetT_DM_HocSinhHocSinhId(string hocSinhId)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                T_DM_HocSinh t_DM_HocSinhs = _db.T_DM_HocSinh.SqlQuery($"SELECT * FROM [Server_VS].[CSDL].[dbo].[T_DM_Hocsinh] WHERE [HocSinhID] = '{hocSinhId}'").SingleOrDefault();
                return t_DM_HocSinhs;
            }

        }
        public HocSinhLopTruongDTO GetHocSinhById(string hocSinhid)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                var hocsinhloptruong = _db.Database.SqlQuery<HocSinhLopTruongDTO>($"SELECT TOP 1 s1.[HocSinhID], s1.[SchoolID], s4.[TenTruong], s2.[Ho], s2.[Ten], s2.[GioiTinh], s2.[NgaySinh], s3.[LopID], s3.[TenLop] FROM[Server_VS].[CSDL].[dbo].[T_BienDong_Cache] as s1, [Server_VS].[CSDL].[dbo].[T_DM_HocSinh] as s2, [Server_VS].[CSDL].[dbo].[T_DM_Lop] as s3, [Server_VS].[CSDL].[dbo].[T_DM_Truong] as s4 WHERE s1.[HocSinhID] = s2.[HocSinhID] AND s1.[HocSinhID] = '{hocSinhid}' AND DOTDIEMID = 12 AND s1.[LopID] = s3.[LopID] AND s1.[SchoolID] = s4.[SchoolID] ORDER BY s1.[BienDongID]").SingleOrDefault();
                return hocsinhloptruong;
            }
        }
    }
}