using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThietBiPhongChay_.ModelFromDp
{
    public class GetThietBiKiemTra
    {
        [Key]
        [Column("IDThietBi")]
        public int IdthietBi { get; set; }
        public string? MaThietBi { get; set; }
        public string? LoaiPhuongTien { get; set; }
        public string? ViTri { get; set; }
        public string? NoiDungKiemTra { get; set; }
        public int? IdNoiDungKiemTra { get; set; }
        public DateTime? ThoiGianKiemTra { get; set; }
        public string? KetQua { get; set; }
        public int? SoLanKiemTraDat { get; set; }
        public int? SoLanKiemTraKhongDat { get; set; }
    }
}