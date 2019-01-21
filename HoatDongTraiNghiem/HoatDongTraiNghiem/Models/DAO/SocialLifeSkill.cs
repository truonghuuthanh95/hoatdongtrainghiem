namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SocialLifeSkill")]
    public partial class SocialLifeSkill
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? SchoolDegreeId { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        public int? ClassId { get; set; }

        public bool? IsKyNangThucHanhXH { get; set; }

        [StringLength(4000)]
        public string SumaryContent { get; set; }

        [StringLength(300)]
        public string CompanyContact { get; set; }

        [StringLength(100)]
        public string License { get; set; }

        [StringLength(100)]
        public string FileKeHoach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [StringLength(50)]
        public string Creatot { get; set; }

        public int? JobtitleId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string ProgramName { get; set; }

        [StringLength(200)]
        public string SchoolName { get; set; }

        public virtual Jobtitle Jobtitle { get; set; }
    }
}
