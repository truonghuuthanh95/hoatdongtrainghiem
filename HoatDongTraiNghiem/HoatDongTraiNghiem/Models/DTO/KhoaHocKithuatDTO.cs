using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class KhoaHocKithuatDTO
    {
        public int LinhVucId { get; set; }


        public string TenDeTai { get; set; }

        public bool IsCaNhan { get; set; }


        public string HocSinh1 { get; set; }


        public string HocSinh2 { get; set; }


        public string LopIdHocSinh1 { get; set; }


        public string LopIdhocSinh2 { get; set; }


        public string DongGopHs1 { get; set; }

        public string DongGopHs2 { get; set; }

        public string GVHD { get; set; }

        public string SchoolId { get; set; }
        public string Email { get; set; }

        public string SDT { get; set; }

        public string DVCongTac { get; set; }
    }
}