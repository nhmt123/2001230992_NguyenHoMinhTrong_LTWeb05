using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb05_Bai03.Models;
using LTWeb05_Bai03.ViewModels;

namespace LTWeb05_Bai03.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source = DESKTOP-1HRGAPF; Database = QL_DTDD1; User Id = sa; Password = 123";
        SqlConnection con = new SqlConnection(strcon);
        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();

        public DuLieu()
        {
            ThietLap_DSLoai();
            ThietLap_DSSP();
        }

        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var l = new Loai();
                l.MaLoai = int.Parse(dr["MaLoai"].ToString());
                l.TenLoai = dr["TenLoai"].ToString();

                dsLoai.Add(l);
            }
        }
        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = int.Parse(dr["MaSP"].ToString());
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = float.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.MaLoai = int.Parse(dr["MaLoai"].ToString());

                dsSP.Add(sp);
            }
        }

        public List<SanPham> DSSP_TheoLoai(int maLoai)
        {
            List<SanPham> dsLoc = new List<SanPham>();
            string sqlScript = string.Format("SELECT * FROM SanPham WHERE MaLoai = {0}", maLoai);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = int.Parse(dr["MaSP"].ToString());
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = float.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.MaLoai = int.Parse(dr["MaLoai"].ToString());

                dsLoc.Add(sp);
            }
            return dsLoc;            
        }
        
        public List<SanPham> TimKiemSP(string tuKhoa)
        {
            List<SanPham> dsKetQua = new List<SanPham>();
            string sqlScript = "SELECT * FROM SanPham WHERE TenSP LIKE @tuKhoa";
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            da.SelectCommand.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
            DataTable dt = new DataTable();

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = int.Parse(dr["MaSP"].ToString());
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = float.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.MaLoai = int.Parse(dr["MaLoai"].ToString());

                dsKetQua.Add(sp);
            }

            return dsKetQua;
        }
    }
}