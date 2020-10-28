namespace HoatDongTraiNghiem.Models.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HoatDongTraiNghiemDB : DbContext
    {
        public HoatDongTraiNghiemDB()
            : base("name=HoatDongTraiNghiemDB4")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<HoatDongNgoaiKhoa> HoatDongNgoaiKhoas { get; set; }
        public virtual DbSet<Jobtitle> Jobtitles { get; set; }
        public virtual DbSet<KHKTLinhVucThamGia> KHKTLinhVucThamGias { get; set; }
        public virtual DbSet<KhoaHocKiThuat> KhoaHocKiThuats { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ProgramPermission> ProgramPermissions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<RegistrationCreativeExp> RegistrationCreativeExps { get; set; }
        public virtual DbSet<SessionADay> SessionADays { get; set; }
        public virtual DbSet<SocialLifeSkill> SocialLifeSkills { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectsRegisted> SubjectsRegisteds { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Wards)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jobtitle>()
                .HasMany(e => e.HoatDongNgoaiKhoas)
                .WithOptional(e => e.Jobtitle)
                .HasForeignKey(e => e.JobTitileId);

            modelBuilder.Entity<Jobtitle>()
                .HasMany(e => e.RegistrationCreativeExps)
                .WithOptional(e => e.Jobtitle)
                .HasForeignKey(e => e.JobTiteId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SessionADay>()
                .HasMany(e => e.RegistrationCreativeExps)
                .WithOptional(e => e.SessionADay)
                .HasForeignKey(e => e.DaySessionId);
        }
    }
}
