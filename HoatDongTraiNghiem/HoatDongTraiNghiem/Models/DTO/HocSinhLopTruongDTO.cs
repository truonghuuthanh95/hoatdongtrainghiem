using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class HocSinhLopTruongDTO
    {
        public string HocSinhID { get; set; }
        public string SchoolID { get; set; }
        public string TenTruong { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string LopID { get; set; }
        public string TenLop { get; set; }
    }
}