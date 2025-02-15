using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThietBiPhongChay_.ModelFromDp;

[Table("ThietBi")]
public partial class ThietBi
{
    [Key]
    [Column("IDThietBi")]
    public int IdthietBi { get; set; }

    [StringLength(12)]
    public string? MaThietBi { get; set; }

    [StringLength(255)]
    public string? LoaiPhuongTien { get; set; }

    [StringLength(255)]
    public string? ViTri { get; set; }

    public int? TanSuatKiemTra { get; set; }

    [InverseProperty("IdthietBiNavigation")]
    public virtual ICollection<NoiDungKiemTra> NoiDungKiemTras { get; set; } = new List<NoiDungKiemTra>();
}
