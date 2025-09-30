using LTWeb05_Bai03.Models;
using LTWeb05_Bai03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb05_Bai03.Controllers
{
    public class HomeController : Controller
    {
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiLoaiSP()
        {
            List<Loai> ds = csdl.dsLoai;
            return View(ds);
        }
        public ActionResult HienThiSP()
        {
            List<SanPham> ds = csdl.dsSP;
            return View(ds);
        }

        [HttpGet]
        public ActionResult ThongTinLoaiSP(int id)
        {
            LoaiSPViewModel l = new LoaiSPViewModel();
            List<SanPham> dsnv = csdl.DSSP_TheoLoai(id);
            l.sp = dsnv;

            return View(l);
        }

        [HttpGet]
        public ActionResult TimKiemSP()
        {
            ViewBag.KetQuaTimKiem = "Chưa có sản phẩm nào được tìm kiếm.";
            return View(new List<SanPham>());
        }

        [HttpPost]
        public ActionResult TimKiemSP(string TimKiem) 
        {
            if (string.IsNullOrWhiteSpace(TimKiem))
            {
                ViewBag.KetQuaTimKiem = "Vui lòng nhập từ khóa tìm kiếm.";
                return View(new List<SanPham>());
            }

            List<SanPham> dsKetQua = csdl.TimKiemSP(TimKiem);

            if (dsKetQua.Count > 0)
            {
                ViewBag.KetQuaTimKiem = $"Tìm thấy {dsKetQua.Count} sản phẩm với từ khóa '{TimKiem}'";
            }
            else
            {
                ViewBag.KetQuaTimKiem = $"Không tìm thấy sản phẩm nào phù hợp với từ khóa '{TimKiem}'";
            }

            return View(dsKetQua);
        }

        [HttpGet]
        public ActionResult TimKiemTheoLoai()
        {
            ViewBag.MaLoai = new SelectList(csdl.dsLoai, "MaLoai", "TenLoai");
            return View(new List<SanPham>());
        }

        [HttpPost]
        public ActionResult TimKiemTheoLoai(int MaLoai) 
        {
            ViewBag.MaLoai = new SelectList(csdl.dsLoai, "MaLoai", "TenLoai", MaLoai);

            List<SanPham> dsKetQua = csdl.DSSP_TheoLoai(MaLoai);

            ViewBag.TongSoSP = dsKetQua.Count;

            return View(dsKetQua);
        }
    }
}