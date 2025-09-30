using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTWeb05_Bai01_Bai02.Models;

namespace LTWeb05_Bai01_Bai02.ViewModels
{
    public class PhongBanViewModel
    {
        public PhongBan phongBan { get; set; }
        public List<NhanVien> nhanVien { get; set; }
    }
}