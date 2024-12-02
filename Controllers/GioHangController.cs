using QL_NhaHang_ADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_NhaHang_ADO.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult HienThiGioHang()
        {
            var cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();
            return View(cart);
        }


        [HttpPost]
        public JsonResult AddToCart(string maMonAn, string tenMonAn, double donGia, string anhMon, int soLuong = 1)
        {
            // Lấy giỏ hàng từ Session hoặc khởi tạo mới nếu chưa có
            List<GioHang> cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();

            // Kiểm tra món ăn đã tồn tại trong giỏ hàng bằng cách duyệt danh sách
            GioHang existingItem = null;
            foreach (var item in cart)
            {
                if (item.MaMonAn == maMonAn)
                {
                    existingItem = item;
                    break; // Thoát khỏi vòng lặp khi tìm thấy phần tử
                }
            }

            if (existingItem != null)
            {
                // Nếu món ăn đã tồn tại, tăng số lượng
                existingItem.SoLuong += soLuong;
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới vào giỏ hàng
                GioHang newItem = new GioHang
                {
                    MaMonAn = maMonAn,
                    TenMonAn = tenMonAn,
                    DonGia = donGia,
                    AnhMon = anhMon,
                    SoLuong = soLuong
                   
                };
                cart.Add(newItem);
            }

            // Cập nhật lại giỏ hàng vào Session
            Session["Cart"] = cart;

            // Chuyển hướng đến trang Index
            return Json(new { success = true, cartCount = cart.Count });
        }

        public ActionResult GetCartItems()
        {
            var cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();
            return PartialView("CartItemsPartial", cart);
        }

        [HttpPost]
        public JsonResult TangSoLuong(string maMonAn)
        {
            // Lấy giỏ hàng từ Session
            List<GioHang> cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();

            // Kiểm tra món ăn có trong giỏ hàng không
            var item = cart.FirstOrDefault(x => x.MaMonAn == maMonAn);
            if (item != null)
            {
                // Tăng số lượng trong danh sách
                item.SoLuong++;

            }

            // Lưu lại giỏ hàng trong Session
            Session["Cart"] = cart;

            // Tính toán tổng số lượng và tổng tiền
            var totalQuantity = cart.Sum(x => x.SoLuong);
            var totalPrice = cart.Sum(x => x.SoLuong * x.DonGia);

            return Json(new { totalQuantity, totalPrice });

        }

        [HttpPost]
        public JsonResult GiamSoLuong(string maMonAn)
        {

            // Lấy giỏ hàng từ Session
            List<GioHang> cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();

            // Kiểm tra món ăn trong giỏ hàng
            var item = cart.FirstOrDefault(x => x.MaMonAn == maMonAn);
            if (item != null)
            {
                item.SoLuong--;

                if (item.SoLuong <= 1)
                {
                    // Xóa sản phẩm nếu số lượng <= 0
                    item.SoLuong = 1;
                }
            }

            // Lưu lại giỏ hàng trong Session
            Session["Cart"] = cart;

            // Tính toán tổng số lượng và tổng tiền
            var totalQuantity = cart.Sum(x => x.SoLuong);
            var totalPrice = cart.Sum(x => x.SoLuong * x.DonGia);

            return Json(new { totalQuantity, totalPrice });
        }
        [HttpPost]
        public JsonResult RemoveItem(string maMonAn)
        {
            // Lấy giỏ hàng từ Session
            List<GioHang> cart = Session["Cart"] as List<GioHang> ?? new List<GioHang>();

            // Xóa sản phẩm khỏi danh sách trong Session
            var item = cart.FirstOrDefault(x => x.MaMonAn == maMonAn);
            if (item != null)
            {
                cart.Remove(item);

            }
            // Lưu lại danh sách vào Session
            Session["Cart"] = cart;

            // Tính toán lại tổng số lượng và tổng tiền
            var totalQuantity = cart.Sum(x => x.SoLuong);
            var totalPrice = cart.Sum(x => x.SoLuong * x.DonGia);

            return Json(new { totalQuantity, totalPrice });
        }
    }



    }
