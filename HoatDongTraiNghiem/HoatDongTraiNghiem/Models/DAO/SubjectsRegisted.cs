namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectsRegisted")]
    public partial class SubjectsRegisted
    {
        public int Id { get; set; }

        public int? RegistrationId { get; set; }

        public int? SubjectId { get; set; }

        public virtual Registration Registration { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
