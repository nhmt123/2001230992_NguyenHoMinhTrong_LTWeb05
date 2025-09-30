using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb05_Bai01_Bai02.Models;
using LTWeb05_Bai01_Bai02.ViewModels;

namespace LTWeb05_Bai01_Bai02.Controllers
{
    public class HomeController : Controller
    {
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiNhanVien()
        {
            List<NhanVien> ds = csdl.dsNV;
            return View(ds);
        }
        public ActionResult HienThiPhongBan()
        {
            List<PhongBan> ds = csdl.dsPB;
            return View(ds);
        }

        [HttpGet]
        public ActionResult ThongTinPB(int id)
        {
            PhongBanViewModel dept = new PhongBanViewModel();
            PhongBan ds = csdl.ChiTietPhongBan(id);
            List<NhanVien> dsnv = csdl.DanhSachNVTheoPB(id);
            dept.phongBan = ds;
            dept.nhanVien = dsnv;

            return View(dept);
        }

        [HttpGet]
        public ActionResult ThemPB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemPB(string Id, string Name)
        {
            PhongBan dept = new PhongBan();
            dept.MaPB = int.Parse(Id);
            dept.TenPB = Name;
            bool result = csdl.ThemPB(dept);
            ViewBag.Message = result == true ? "SUCCESS" : "FAILURE";
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSuaPB(int id)
        {
            PhongBan ds = csdl.ChiTietPhongBan(id);
            return View(ds);
        }
        [HttpPost]
        public ActionResult ChinhSuaPB(PhongBan dept)
        {
            bool result = csdl.CapNhatPB(dept);
            ViewBag.Message = result == true ? "SUCCESS" : "FAILURE";
            return View(dept);
        }

        [HttpGet] 
        public ActionResult XoaPB(int id) 
        {
            bool result = csdl.XoaPB(id);
            return RedirectToAction("HienThiPhongBan");
        }
    }
}