using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;




//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Linq;
//using System.Web;

//namespace QL_NhaHang_ADO.Models
//{
//    public class HoaDon
//    {
//        [Display(Name = "Mã Hóa Đơn")]
//        public string Ma { get; set; }

//        [Display(Name = "Mã Bàn")]
//        public string MaBan { get; set; }

//        [Display(Name = "Mã Khách Hàng")]
//        [Required(ErrorMessage = "Mã khách hàng không được để trống.")]
//        public string MaKH { get; set; }

//        [Display(Name = "Nhân Viên")]
//        public string MaNV { get; set; }

//        [Display(Name = "Giảm Giá")]
//        public string MaGiamGia { get; set; }

//        [Required(ErrorMessage = "Ngày lập không được để trống")]
//        [DataType(DataType.Date)]
//        public DateTime? NgayLap { get; set; }


//        [Display(Name = "Hình Thức")]
//        public string HinhThuc { get; set; }

//        public string TenKhachHang { get; set; }

//        public HoaDon() { }

//        public HoaDon(string ma, string maBan, string maKH, string maNV, string maGiamGia, DateTime ngayLap, string hinhThuc)
//        {
//            Ma = ma;
//            MaBan = maBan;
//            MaKH = maKH;
//            MaNV = maNV;
//            MaGiamGia = maGiamGia;
//            NgayLap = ngayLap;  // Không nullable
//            HinhThuc = hinhThuc;
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace QL_NhaHang_ADO.Models
//{
//    public class ChiTietHoaDon
//    {
//        public string MaHD { get; set; }
//        public string MaMA { get; set; }
//        public int SoLuong { get; set; }
//        public int ThanhTien { get; set; }
//        public DateTime? TGHoanThanh { get; set; }
//        public string TenMon { get; set; }
//        public int GiaMon { get; set; }
//    }
//}

namespace QL_NhaHang_ADO.Models
{
    public class XuLyThanhToan
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;


        public void XuLyHoaDon(List<ChiTietHoaDon> chiTietHoaDonList, HoaDon hd)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sql = "insert into HoaDon values(@Ma, @MaBan, @MaKH, @MaNV, @MaGiamGia, @NgayLap,@TongTien, @HinhThuc, @GiaGiam)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("Ma", hd.Ma);
            cmd.Parameters.AddWithValue("MaBan", hd.MaBan ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("MaKH", hd.MaKH ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("MaNV", hd.MaNV ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("MaGiamGia", hd.MaGiamGia);
            cmd.Parameters.AddWithValue("NgayLap", hd.NgayLap);
            cmd.Parameters.AddWithValue("TongTien", hd.TongTien);
            cmd.Parameters.AddWithValue("HinhThuc", hd.HinhThuc);
            cmd.Parameters.AddWithValue("GiaGiam", hd.GiaGiam);
            cmd.ExecuteNonQuery();
            con.Close();

            // Thêm chi tiết hóa đơn
            foreach (ChiTietHoaDon cthd in chiTietHoaDonList)
            {
                con.Open();
                sql = "insert into ChiTietHoaDon values(@MaHD, @MaMA, @SoLuong, @ThanhTien)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("MaHD", cthd.MaHD);
                cmd.Parameters.AddWithValue("MaMA", cthd.MaMA);
                cmd.Parameters.AddWithValue("SoLuong", cthd.SoLuong);
                cmd.Parameters.AddWithValue("ThanhTien", cthd.ThanhTien);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}