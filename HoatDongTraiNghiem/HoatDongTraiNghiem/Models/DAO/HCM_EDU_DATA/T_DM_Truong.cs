namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DM_Truong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SchoolID { get; set; }

        [StringLength(100)]
        public string TenTruong { get; set; }      

        [StringLength(50)]
        public string HieuTruong { get; set; }

        [StringLength(20)]
        public string DT_HieuTruong { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        public int? XaID { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public byte? KhuVucID { get; set; }

        [StringLength(10)]
        public string ChinhSachVungID { get; set; }

        public bool? ThuocVungKinhTeKK { get; set; }

        public bool? DatChuanQG { get; set; }

        public bool? CoChiBoDang { get; set; }

        public bool? CoLopHoc2Buoi { get; set; }

        public bool? CoHSBanTru { get; set; }

        public bool? CoHSNoiTru { get; set; }

        public bool? TruongQuocTe { get; set; }

        public bool? CoHSKhuyetTat { get; set; }

        public bool? CoDayNghePT { get; set; }

        public bool? CoPhoBien_HIV_SKSS { get; set; }

        public byte? PhanMemID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short upDotDiemID { get; set; }

        public int? PGDID { get; set; }

        [StringLength(50)]
        public string PGDID_C12 { get; set; }

        public byte? Cap1 { get; set; }

        public byte? Cap2 { get; set; }

        public byte? Cap3 { get; set; }

        public bool? IsTestOnly { get; set; }

        public int? HuyenID { get; set; }
    }
}
