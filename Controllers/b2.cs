using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThietBiPhongChay_.ModelFromDp;

namespace ThietBiPhongChay_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class b2 : ControllerBase
    {
        ThietBiPhongChay dbc;
        public b2(ThietBiPhongChay db)
        {
            dbc = db;
        }

        [HttpGet("thietbi")]
        public async Task<IActionResult> GetThietBi()
        {
            try
            {
                var result = await dbc.GetThietBiKiemTras
                    .FromSqlRaw("EXEC GetThietBiKiemTra")
                    .ToListAsync();

                return Ok(result);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, "Lỗi truy vấn cơ sở dữ liệu: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertthietbi")]

        public IActionResult InsertThietBi(string LoaiPhuongtien,string ViTri,int TanSuatKiemTra)
        {
            ThietBi tb = new ThietBi();
            tb.LoaiPhuongTien = LoaiPhuongtien;
            tb.ViTri = ViTri;
            tb.TanSuatKiemTra = TanSuatKiemTra;
            dbc.ThietBis.Add(tb);
            dbc.SaveChanges();
            return Ok(new {tb});
        }

        [HttpPost]
        [Route("capnhatketquakiemtra")]

        public async Task<IActionResult> CapNhatKetQuaKiemTra(Capnhatketquakiemtras dto)
        {
            try
            {
                // Thực thi stored procedure với 2 tham số
                var result = await dbc.Database.ExecuteSqlRawAsync(
                    "EXEC capnhatketquakiemtra @IDNoiDungKiem, @KetQua",
                    new SqlParameter("@IDNoiDungKiem", dto.IDNoiDungKiemTra),
                    new SqlParameter("@KetQua", dto.KetQua)
                );

                return Ok(new { message = "Cập nhật thành công", rowsAffected = result });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, "Lỗi truy vấn cơ sở dữ liệu: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("deletethietbi")]

        public IActionResult DeleteThietBi(int IdThietBi)
        {
            ThietBi tb = new ThietBi();
            tb.IdthietBi = IdThietBi;
            dbc.ThietBis.Remove(tb);
            dbc.SaveChanges();
            return Ok(new { tb });
        }
    }
}
