using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai01_Bai02.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source = DESKTOP-1HRGAPF; Database = QL_NhanSu; User Id = sa; Password = 123";
        SqlConnection con = new SqlConnection(strcon);
        public List<NhanVien> dsNV = new List<NhanVien>();
        public List<PhongBan> dsPB = new List<PhongBan>();

        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPB();
        }

        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var em = new NhanVien();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = (int)dr["DeptId"];

                dsNV.Add(em);
            }
        }

        public void ThietLap_DSPB()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Department", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var p = new PhongBan();
                p.MaPB = int.Parse(dr["DeptId"].ToString());
                p.TenPB = dr["Name"].ToString();

                dsPB.Add(p);
            }
        }

        public PhongBan ChiTietPhongBan(int maPhong)
        {
            PhongBan dept = new PhongBan();
            string sqlScript = string.Format("select * from Department where DeptId = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dept.MaPB = int.Parse(dt.Rows[0]["DeptId"].ToString());
            dept.TenPB = dt.Rows[0]["Name"].ToString();
            return dept;
        }

        public List<NhanVien> DanhSachNVTheoPB(int maPhong)
        {
            List<NhanVien> employees = new List<NhanVien>();
            string sqlScript = string.Format("select * from Employee where DeptId = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new NhanVien();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = (int)dr["DeptId"];

                employees.Add(em);
            }

            return employees;
        }

        public bool ThemPB(PhongBan dept)
        {
            bool result = false;
            string sqlScript = "insert into Department values(@MaPB, @TenPB)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@MaPB", dept.MaPB);
                cmd.Parameters.AddWithValue("@TenPB", dept.TenPB);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool CapNhatPB(PhongBan dept)
        {
            bool result = false;
            string sqlScript = "update Department set Name = @TenPB where DeptId = @MaPB";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@TenPB", dept.TenPB);
                cmd.Parameters.AddWithValue("@MaPB", dept.MaPB);
                try
                {
                    con.Open();
                    int rowAnhHuong = cmd.ExecuteNonQuery();
                    result = true;
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool XoaPB(int maPB)
        {
            bool result = false;
            string sqlScript = "DELETE FROM Department WHERE DeptId = @MaPB";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@MaPB", maPB);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}