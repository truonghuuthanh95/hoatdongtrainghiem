namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DM_HocSinh
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string HocSinhID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SchoolID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ClientHocSinhID { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Ten { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool GioiTinh { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime NgaySinh { get; set; }

        [StringLength(100)]
        public string NoiSinh { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short DanTocID { get; set; }

        public byte? TonGiaoID { get; set; }

        public byte? KhuyetTatID { get; set; }

        public byte? DoiTuongChinhSachID { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(500)]
        public string HoKhau_DiaChi { get; set; }

        public int? HoKhau_XaID { get; set; }

        [StringLength(500)]
        public string DCTT_DiaChi { get; set; }

        public int? DCTT_XaID { get; set; }

        [StringLength(50)]
        public string TenCha { get; set; }

        [StringLength(50)]
        public string SDTCha { get; set; }

        [StringLength(50)]
        public string TenMe { get; set; }

        [StringLength(50)]
        public string SDTMe { get; set; }

        [StringLength(50)]
        public string TenNguoiGiamHo { get; set; }

        [StringLength(50)]
        public string SDTNguoiGiamHo { get; set; }

        public byte? CreateBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreateTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifyTime { get; set; }

        [StringLength(50)]
        public string SoQuyetDinh { get; set; }

        public bool? IsPending { get; set; }

        [StringLength(50)]
        public string NguoiDuyetCD { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDuyetCD { get; set; }

        [StringLength(50)]
        public string LopID { get; set; }

        public int? LogID { get; set; }
    }
}
