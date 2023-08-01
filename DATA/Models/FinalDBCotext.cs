using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DATA.Models
{
    public partial class FinalDBCotext : DbContext
    {
        public FinalDBCotext()
        {
        }

        public FinalDBCotext(DbContextOptions<FinalDBCotext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<FileTab> FileTab { get; set; }
        public virtual DbSet<Filter> Filter { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Platter> Platter { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<TypeTab> TypeTab { get; set; }
        public virtual DbSet<UserRights> UserRights { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;User Id=ahsan;Password=1234;Database=Zameen;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agreement>(entity =>
            {
                entity.HasKey(e => e.AgrId)
                    .HasName("PK__Agreemen__81EE94743589A907");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaName).HasMaxLength(50);
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.BlockName).HasMaxLength(50);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.Property(e => e.DealerCnic).HasMaxLength(50);

                entity.Property(e => e.DealerContact).HasMaxLength(50);

                entity.Property(e => e.DealerName).HasMaxLength(100);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FileTab>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__FileTab__6F0F98BFD3227C41");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Area).HasMaxLength(1);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.EdiDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.MenuName).HasMaxLength(50);

                entity.Property(e => e.URL).HasMaxLength(100);
            });

            modelBuilder.Entity<Platter>(entity =>
            {
                entity.HasKey(e => e.RecNo)
                    .HasName("PK__Platter__36047C744CD01C77");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName).HasMaxLength(100);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK__Record__36047C74C598CD38");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.PlatterName).HasMaxLength(50);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.SiteName).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeTab>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__Type__516F03B5417A3F38");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRights>(entity =>
            {
                entity.HasKey(e => e.UserRightId)
                    .HasName("PK__UserRigh__956097A2B429531D");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C4D5C8E37");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
