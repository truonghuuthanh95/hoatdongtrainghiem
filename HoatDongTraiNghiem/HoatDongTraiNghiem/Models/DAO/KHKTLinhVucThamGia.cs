namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHKTLinhVucThamGia")]
    public partial class KHKTLinhVucThamGia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
}
