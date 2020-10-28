using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class KhoaHocKiThuatDetailDTO
    {
        public KhoaHocKiThuat KhoaHocKiThuat { get; set; }
        public KHKTLinhVucThamGia KHKTLinhVucThamGia { get; set; }
        public T_DM_Lop T_DM_Lop1 { get; set; }
        public T_DM_Lop T_DM_Lop2 { get; set; }
        public T_DM_Truong T_DM_Truong1 { get; set; }
        public T_DM_Truong T_DM_Truong2 { get; set; }
        public T_DM_HocSinh T_DM_HocSinh1 { get; set; }
        public T_DM_HocSinh T_DM_HocSinh2 { get; set; }
        public T_DM_PGD T_DM_PGDTruong { get; set; }
        public HocSinhLopTruongDTO HocSinhLopTruong1 { get; set; }
        public HocSinhLopTruongDTO HocSinhLopTruong2 { get; set; }
    }
}