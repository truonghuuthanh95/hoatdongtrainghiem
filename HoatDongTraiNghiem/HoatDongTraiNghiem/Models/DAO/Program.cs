namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Program")]
    public partial class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            ProgramPermissions = new HashSet<ProgramPermission>();
            RegistrationCreativeExps = new HashSet<RegistrationCreativeExp>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? MaxAudience { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Longitude { get; set; }

        [StringLength(50)]
        public string Latittude { get; set; }

        public int? DayTypeEnableSelectId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramPermission> ProgramPermissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationCreativeExp> RegistrationCreativeExps { get; set; }
    }
}
