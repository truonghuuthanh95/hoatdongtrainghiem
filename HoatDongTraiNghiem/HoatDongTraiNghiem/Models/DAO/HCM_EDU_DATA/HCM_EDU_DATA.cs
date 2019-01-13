namespace HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HCM_EDU_DATA : DbContext
    {
        public HCM_EDU_DATA()
            : base("name=HCM_EDU_DATA")
        {
        }

        public virtual DbSet<T_DM_PGD> T_DM_PGD { get; set; }
        public virtual DbSet<T_DM_Truong> T_DM_Truong { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_DM_PGD>()
                .Property(e => e.TenTat)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.SchoolID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.DT_HieuTruong)
                .IsFixedLength();

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.ChinhSachVungID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DM_Truong>()
                .Property(e => e.PGDID_C12)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.DonViID)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.InitialPassword)
                .IsUnicode(false);
        }
    }
}
