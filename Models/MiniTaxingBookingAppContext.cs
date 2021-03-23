using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MiniTaxiBookingApplication.Models
{
    public partial class MiniTaxingBookingAppContext : DbContext
    {
        public MiniTaxingBookingAppContext()
        {
        }

        public MiniTaxingBookingAppContext(DbContextOptions<MiniTaxingBookingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDatum> BookingData { get; set; }
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server= LAPTOP-3D3F3ANG;Database=MiniTaxingBookingApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BookingType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmiratesId).HasColumnName("EmiratesID");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationDesc).IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BookingStatusNavigation)
                    .WithMany(p => p.BookingData)
                    .HasForeignKey(d => d.BookingStatus)
                    .HasConstraintName("FK__BookingDa__Booki__31EC6D26");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.ToTable("BookingStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK_Users_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
