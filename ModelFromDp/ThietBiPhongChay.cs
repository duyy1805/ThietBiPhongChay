using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThietBiPhongChay_.ModelFromDp;

public partial class ThietBiPhongChay : DbContext
{
    public ThietBiPhongChay()
    {
    }

    public ThietBiPhongChay(DbContextOptions<ThietBiPhongChay> options)
        : base(options)
    {
    }

    public virtual DbSet<KetQuaKiemTra> KetQuaKiemTras { get; set; }

    public virtual DbSet<NoiDungKiemTra> NoiDungKiemTras { get; set; }

    public virtual DbSet<ThietBi> ThietBis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<GetThietBiKiemTra> GetThietBiKiemTras { get; set; }

    public virtual DbSet<Capnhatketquakiemtras> Capnhatketquakiemtras { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=125.212.207.52,3400;Initial Catalog=ThietBiPhongChay;Persist Security Info=True;User ID=hethong;Password=Z176LoginHethong;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KetQuaKiemTra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KetQuaKi__3214EC2701D6DE2E");

            entity.Property(e => e.ThoiGianKiemTra).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdnoiDungKiemTraNavigation).WithMany(p => p.KetQuaKiemTras).HasConstraintName("FK__KetQuaKie__IDNoi__2C3393D0");
        });

        modelBuilder.Entity<NoiDungKiemTra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NoiDungK__3214EC2768BB3008");

            entity.HasOne(d => d.IdthietBiNavigation).WithMany(p => p.NoiDungKiemTras).HasConstraintName("FK__NoiDungKi__IDThi__2D27B809");
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.HasKey(e => e.IdthietBi).HasName("PK__ThietBi__1376CB7B9C5BE64B");

            entity.ToTable("ThietBi", tb =>
                {
                    tb.HasTrigger("ThemNoiDungKiemTraTuDong");
                    tb.HasTrigger("XoaNoiDungKiemTraKetQua");
                });

            entity.Property(e => e.MaThietBi).HasComputedColumnSql("('TB'+CONVERT([nvarchar](10),[IDThietBi]))", true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FE5631258");

            entity.Property(e => e.Role).HasDefaultValue("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
