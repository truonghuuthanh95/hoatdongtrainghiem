namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramPermission")]
    public partial class ProgramPermission
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public int? ProgramId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Program Program { get; set; }
    }
}
