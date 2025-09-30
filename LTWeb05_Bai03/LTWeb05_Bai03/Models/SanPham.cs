using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai03.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DuongDan { get; set; }
        public float Gia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
    }
}