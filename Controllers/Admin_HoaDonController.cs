using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QL_NhaHang_ADO.Models;

namespace QL_NhaHang_ADO.Controllers
{
    public class Admin_HoaDonController : Controller
    {
        // GET: Admin_HoaDon
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiHoaDon()
        {
            XuLyHoaDon objHD = new XuLyHoaDon();
            List<PhieuNhapKho> listHD = objHD.LayThongTinHoaDon();
            return View(listHD);
        }

        public ActionResult HienThiChiTietHoaDon(string MaNhapKho)
        {
            XuLyHoaDon objHD = new XuLyHoaDon();
            List<ChiTietNhapKho> listCTHD = objHD.LayThongTinChiTietHoaDon(MaNhapKho);
            return View(listCTHD);
        }

        public ActionResult ThemHoaDon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemHoaDonMoi(FormCollection f)
        {
            PhieuNhapKho hd = new PhieuNhapKho();
            hd.MaNhapKho = f["MaNhapKho"];
            hd.MaNV = f["MaNV"];
            hd.NgayNhapKho = DateTime.Parse(f["NgayNhapKho"]);
            hd.TongTien = 0;

            XuLyHoaDon objHD = new XuLyHoaDon();
            objHD.XuLyThemHoaDon(hd);

            // Lưu ID của hóa đơn vừa tạo vào ViewBag để hiển thị form nhập chi tiết
            ViewBag.HoaDonId = hd.MaNhapKho;

            // Trả về view lại với ViewBag chứa HoaDonId
            return View("ThemHoaDon");
        }


        [HttpPost]
        public ActionResult ThemChiTietHoaDon(FormCollection f)
        {
            string MaNhapKho = f["MaNhapKho"]; // Lấy MaNhapKho từ form
            if (string.IsNullOrEmpty(MaNhapKho))
            {
                // Kiểm tra nếu MaNhapKho là null hoặc rỗng, có thể thêm xử lý lỗi ở đây
                return RedirectToAction("Error"); // hoặc hiển thị thông báo lỗi
            }

            string[] MaNguyenLieu = f.GetValues("ChiTietHoaDon[][MaNguyenLieu]");
            string[] TenNguyenLieu = f.GetValues("ChiTietHoaDon[][TenNguyenLieu]");
            string[] SoLuong = f.GetValues("ChiTietHoaDon[][SoLuong]");
            string[] DVT = f.GetValues("ChiTietHoaDon[][DVT]");
            string[] DonGia = f.GetValues("ChiTietHoaDon[][DonGia]");
            string[] ThanhTien = f.GetValues("ChiTietHoaDon[][ThanhTien]");

            List<ChiTietNhapKho> listCTHD = new List<ChiTietNhapKho>();
            for (int i = 0; i < MaNguyenLieu.Length; i++)
            {
                ChiTietNhapKho cthd = new ChiTietNhapKho
                {
                    MaNhapKho = MaNhapKho,  // Đảm bảo MaNhapKho được gán đúng
                    MaNguyenLieu = MaNguyenLieu[i],
                    SoLuong = int.Parse(SoLuong[i]),
                    ThanhTien = int.Parse(ThanhTien[i])
                };
                listCTHD.Add(cthd);
            }

            XuLyHoaDon objHD = new XuLyHoaDon();
            objHD.XuLyThemChiTietHoaDon(listCTHD);

            return RedirectToAction("HienThiHoaDon");
        }
    }
}