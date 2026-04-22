using System;
using System.Data.SqlClient;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập bệnh nhân
            string query = "SELECT MaBN, HoTen FROM BenhNhan WHERE Email=@Email AND MatKhau=@MatKhau";
            SqlParameter[] params1 = {
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };
            var result = DBHelper.ExecuteQuery(query, params1);

            if (result.Rows.Count > 0)
            {
                Session["MaBN"] = result.Rows[0]["MaBN"].ToString();
                Session["HoTen"] = result.Rows[0]["HoTen"].ToString();
                Session["VaiTro"] = "BenhNhan";
                Response.Redirect("Default.aspx");
                return;
            }

            // Kiểm tra đăng nhập Admin (bác sĩ) - dùng mảng params MỚI
            string queryAdmin = "SELECT MaBS, HoTen FROM BacSi WHERE Email=@Email AND MatKhau=@MatKhau";
            SqlParameter[] params2 = {
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };
            var resultAdmin = DBHelper.ExecuteQuery(queryAdmin, params2);

            if (resultAdmin.Rows.Count > 0)
            {
                Session["MaBS"] = resultAdmin.Rows[0]["MaBS"].ToString();
                Session["HoTen"] = resultAdmin.Rows[0]["HoTen"].ToString();
                Session["VaiTro"] = "Admin";
                Response.Redirect("Default.aspx");
                return;
            }

            lblThongBao.Text = "Email hoặc mật khẩu không đúng!";
        }
    }
}