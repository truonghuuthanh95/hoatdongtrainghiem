namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoatDongNgoaiKhoa")]
    public partial class HoatDongNgoaiKhoa
    {
        public int Id { get; set; }

        [StringLength(2000)]
        public string ActivityName { get; set; }

        public int? ProvinceId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateRegisted { get; set; }

        public int? StudentQuantity { get; set; }

        public string Summary { get; set; }

        [StringLength(200)]
        public string FileKeHoachToChuc { get; set; }

        [StringLength(200)]
        public string FilePhuongAnChiTietAnToan { get; set; }

        [StringLength(200)]
        public string FileQDThanhLapBanToChuc { get; set; }

        [StringLength(200)]
        public string FileHDKKPhoiHopToChuc { get; set; }

        [StringLength(200)]
        public string FileLichTrinhHoatDong { get; set; }

        [StringLength(200)]
        public string FileBaoHiemChuyenDi { get; set; }

        [StringLength(200)]
        public string FileThuBaoChoChaMe { get; set; }

        [StringLength(200)]
        public string FileNoiQuyChuyenDi { get; set; }

        [StringLength(200)]
        public string FileDanhSachPhanXeVaGV { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        [StringLength(200)]
        public string SchoolName { get; set; }

        [StringLength(200)]
        public string Creator { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? JobTitileId { get; set; }

        public int? ClassId { get; set; }

        public virtual Jobtitle Jobtitle { get; set; }

        public virtual Province Province { get; set; }
    }
}
