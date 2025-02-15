using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThietBiPhongChay_.ModelFromDp;

[Table("NoiDungKiemTra")]
public partial class NoiDungKiemTra
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("IDThietBi")]
    public int? IdthietBi { get; set; }

    [Column("NoiDungKiemTra")]
    [StringLength(255)]
    public string? NoiDungKiemTra1 { get; set; }

    [ForeignKey("IdthietBi")]
    [InverseProperty("NoiDungKiemTras")]
    public virtual ThietBi? IdthietBiNavigation { get; set; }

    [InverseProperty("IdnoiDungKiemTraNavigation")]
    public virtual ICollection<KetQuaKiemTra> KetQuaKiemTras { get; set; } = new List<KetQuaKiemTra>();
}
