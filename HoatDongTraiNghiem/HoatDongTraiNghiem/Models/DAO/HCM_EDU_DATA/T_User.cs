namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_User
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string FullName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string PasswordSalt { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public Guid? CreatedByUser { get; set; }

        [StringLength(3)]
        public string AccountType { get; set; }

        [StringLength(50)]
        public string DonViID { get; set; }

        public bool? Disabled { get; set; }

        public bool? ForceChangePass { get; set; }

        [StringLength(50)]
        public string InitialPassword { get; set; }
    }
}
