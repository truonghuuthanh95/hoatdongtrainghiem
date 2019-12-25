namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DM_Lop
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string LopID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SchoolID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NamHocID { get; set; }

        [StringLength(50)]
        public string ClientLopID { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Khoi { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string TenLop { get; set; }

        public int? PGDID { get; set; }

        public bool? LopHoc2Buoi { get; set; }

        public byte? CreateBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreateTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifyTime { get; set; }

        public byte? STT { get; set; }

        public int? LogID { get; set; }

        public byte? SiSoHS { get; set; }
    }
}
