namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaHocKiThuat")]
    public partial class KhoaHocKiThuat
    {
        public int Id { get; set; }

        public int? LinhVucId { get; set; }

        [StringLength(200)]
        public string TenDeTai { get; set; }

        public bool? IsCaNhan { get; set; }

        [StringLength(50)]
        public string HocSinh1 { get; set; }

        [StringLength(50)]
        public string HocSinh2 { get; set; }

        [StringLength(50)]
        public string LopIdHocSinh1 { get; set; }

        [StringLength(50)]
        public string LopIdhocSinh2 { get; set; }

        [StringLength(50)]
        public string DongGopHs1 { get; set; }

        [StringLength(50)]
        public string DongGopHs2 { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAr { get; set; }

        [StringLength(50)]
        public string GVHD { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string FileTaiLieu { get; set; }

        [StringLength(200)]
        public string DVCongTac { get; set; }
    }
}
