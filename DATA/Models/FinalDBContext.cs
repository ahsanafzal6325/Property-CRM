using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DATA.Models
{
    public partial class FinalDBContext : DbContext
    {
        public FinalDBContext()
        {
        }

        public FinalDBContext(DbContextOptions<FinalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<FileTab> FileTab { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Site> Site { get; set; }

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

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName).HasMaxLength(100);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EnterDate).HasColumnType("datetime");

                entity.Property(e => e.SiteName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
