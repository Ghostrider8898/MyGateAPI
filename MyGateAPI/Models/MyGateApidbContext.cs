using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyGateAPI.Models;

public partial class MyGateApidbContext : DbContext
{
    public MyGateApidbContext()
    {
    }

    public MyGateApidbContext(DbContextOptions<MyGateApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FlatOwner> FlatOwners { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SecurityGuard> SecurityGuards { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    public virtual DbSet<VisitorPass> VisitorPasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-08L6HPA;Database=MyGateAPIDB;Trusted_Connection=true;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlatOwner>(entity =>
        {
            entity.HasKey(e => e.FlatOwnerId).HasName("PK__FlatOwne__BD780EA4EAB11613");

            entity.ToTable("FlatOwner");

            entity.Property(e => e.FlatOwnerId).HasColumnName("FlatOwnerID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.FlatOwners)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__FlatOwner__UserI__29572725");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A02D31A78");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<SecurityGuard>(entity =>
        {
            entity.HasKey(e => e.SecurityGuardId).HasName("PK__Security__9E7B76C0735214A8");

            entity.ToTable("SecurityGuard");

            entity.Property(e => e.SecurityGuardId).HasColumnName("SecurityGuardID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Shift).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.SecurityGuards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__SecurityG__UserI__38996AB5");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF784C19358");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Shift).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.FlatNoNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FlatNo)
                .HasConstraintName("FK__Staff__FlatNo__4BAC3F29");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Staff__UserID__4CA06362");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserProf__1788CCAC4C6285E7");

            entity.ToTable("UserProfile");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AadharCardNo).HasMaxLength(20);
            entity.Property(e => e.Contact).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserProfi__RoleI__267ABA7A");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__476B54B29A1816AF");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.Model).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Type).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VehicleNo).HasMaxLength(10);

            entity.HasOne(d => d.FlatNoNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.FlatNo)
                .HasConstraintName("FK__Vehicle__FlatNo__5535A963");

            entity.HasOne(d => d.Role).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Vehicle__RoleID__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Vehicle__UserID__571DF1D5");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.VisitorId).HasName("PK__Visitor__B121AFA855EDCFA8");

            entity.ToTable("Visitor");

            entity.Property(e => e.VisitorId).HasColumnName("VisitorID");
            entity.Property(e => e.PurposeOfVisit).HasMaxLength(500);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VehicleNo).HasMaxLength(10);

            entity.HasOne(d => d.FlatNoNavigation).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.FlatNo)
                .HasConstraintName("FK__Visitor__FlatNo__2C3393D0");

            entity.HasOne(d => d.User).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Visitor__UserID__2D27B809");
        });

        modelBuilder.Entity<VisitorPass>(entity =>
        {
            entity.HasKey(e => e.PassId).HasName("PK__VisitorP__C67409488D23DA06");

            entity.ToTable("VisitorPass");

            entity.Property(e => e.PassId).HasColumnName("PassID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.VehicleNo).HasMaxLength(10);
            entity.Property(e => e.VisitorId).HasColumnName("VisitorID");

            entity.HasOne(d => d.FlatNoNavigation).WithMany(p => p.VisitorPasses)
                .HasForeignKey(d => d.FlatNo)
                .HasConstraintName("FK__VisitorPa__FlatN__6383C8BA");

            entity.HasOne(d => d.Staff).WithMany(p => p.VisitorPasses)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__VisitorPa__Staff__6477ECF3");

            entity.HasOne(d => d.Visitor).WithMany(p => p.VisitorPasses)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__VisitorPa__Visit__656C112C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
