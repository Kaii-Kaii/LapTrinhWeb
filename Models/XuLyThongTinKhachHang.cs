using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace QL_NhaHang_ADO.Models
{
    public class XuLyThongTinKhachHang
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;

        public List<KhachHang> LayThongTinKhachHang()
        {
            List<KhachHang> listProduct = new List<KhachHang>();
            SqlConnection con = new SqlConnection(connectionString);

            // Truy vấn SQL để lấy và giải mã TenDangNhap bằng hàm decryptCaesarCipher
            string sql = @"
                         SELECT 
                             MAKH,
                             MATAIKHOAN,
                             HOTEN,
                             NGAYSINH,
                             SODT,
                             DIEMTHANHVIEN,
                             AVATAR
                         FROM KhachHang";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                KhachHang kh = new KhachHang();

                // Lấy kết quả giải mã từ cột TenDangNhapDecrypted
                kh.MaTaiKhoan = rdr.GetValue(1).ToString();

                kh.MaKH = rdr.GetValue(0).ToString();

                kh.HoTen = rdr.GetValue(2).ToString();

                // Giải mã mật khẩu trong C#
                kh.NgaySinh = rdr.GetValue(3).ToString();

                kh.SoDT = rdr.GetValue(4).ToString();

                kh.DiemThanhVien = Convert.ToInt32(rdr.GetValue(5).ToString());

                kh.Avatar = rdr.GetValue(6).ToString();

                listProduct.Add(kh);
            }
            con.Close();
            return listProduct;
        }
        
    }
}