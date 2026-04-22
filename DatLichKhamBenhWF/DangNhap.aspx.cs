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
            string query = "SELECT MaBN, HoTen FROM BenhNhan WHERE Email=@Email AND MatKhau=@MatKhau";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };

            var result = DBHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                Session["MaBN"] = result.Rows[0]["MaBN"].ToString();
                Session["HoTen"] = result.Rows[0]["HoTen"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblThongBao.Text = "Email hoặc mật khẩu không đúng!";
            }
        }
    }
}