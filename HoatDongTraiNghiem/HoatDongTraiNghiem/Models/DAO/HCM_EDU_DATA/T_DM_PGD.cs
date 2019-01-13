namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DM_PGD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PGDID { get; set; }

        [StringLength(10)]
        public string TenTat { get; set; }

        [StringLength(50)]
        public string TenPGD { get; set; }
    }
}
