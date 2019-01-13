namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            SubjectsRegisteds = new HashSet<SubjectsRegisted>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        public int? StudentQuantity { get; set; }

        [StringLength(100)]
        public string Creator { get; set; }

        public int? JobTitleId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateRegisted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? SchoolDegreeId { get; set; }

        public int? ClassId { get; set; }

        [StringLength(200)]
        public string ProgramName { get; set; }

        public int? ProvinceId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string FileKeHoach { get; set; }

        [StringLength(100)]
        public string FileTaiLieuChoHS { get; set; }

        [StringLength(100)]
        public string FileBaiKiemTra { get; set; }

        [StringLength(100)]
        public string Fee { get; set; }

        [StringLength(500)]
        public string PhuongAnChoHsThamGia { get; set; }

        public string ViTriKienThuc { get; set; }

        public string TomTatNoiDungCT { get; set; }

        public virtual Jobtitle Jobtitle { get; set; }

        public virtual Province Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectsRegisted> SubjectsRegisteds { get; set; }
    }
}
