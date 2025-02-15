using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThietBiPhongChay_.ModelFromDp;

[Table("KetQuaKiemTra")]
public partial class KetQuaKiemTra
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("IDNoiDungKiemTra")]
    public int? IdnoiDungKiemTra { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ThoiGianKiemTra { get; set; }

    [StringLength(50)]
    public string? KetQua { get; set; }

    [ForeignKey("IdnoiDungKiemTra")]
    [InverseProperty("KetQuaKiemTras")]
    public virtual NoiDungKiemTra? IdnoiDungKiemTraNavigation { get; set; }
}
