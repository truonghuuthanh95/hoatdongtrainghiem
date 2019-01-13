namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrationCreativeExp")]
    public partial class RegistrationCreativeExp
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        public int? StudentQuantity { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public int? JobTiteId { get; set; }

        public int? ProgramId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateRegisted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? SchoolDegreeId { get; set; }

        public int? ClassId { get; set; }

        public int? DaySessionId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string ActivitiTitle { get; set; }

        public virtual Jobtitle Jobtitle { get; set; }

        public virtual Program Program { get; set; }

        public virtual SessionADay SessionADay { get; set; }
    }
}
