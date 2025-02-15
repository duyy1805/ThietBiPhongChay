using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThietBiPhongChay_.ModelFromDp
{
    public class Capnhatketquakiemtras
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public int IDNoiDungKiemTra { get; set; }
        public string? KetQua { get; set; }
    }
}