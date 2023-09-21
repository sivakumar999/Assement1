using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomSupport.Models;

public partial class EndDbContext : DbContext
{
    public EndDbContext()
    {
    }

    public EndDbContext(DbContextOptions<EndDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustLogInfo> CustLogInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dbserverrr.database.windows.net,1433;Initial Catalog=EndDb;User Id=Admin123; Password=AdminMine99;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustLogInfo>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__CustLogI__5E5486482B28316E");

            entity.ToTable("CustLogInfo");

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.CustEmail).HasMaxLength(100);
            entity.Property(e => e.CustName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LogStatus).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.CustLogInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CustLogIn__UserI__5EBF139D");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C3C6A3929");

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
