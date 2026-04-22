using System;
using System.Data.SqlClient;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra email đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM BenhNhan WHERE Email = @Email";
            SqlParameter[] checkParams = {
                new SqlParameter("@Email", txtEmail.Text)
            };
            var result = DBHelper.ExecuteQuery(checkQuery, checkParams);
            int count = Convert.ToInt32(result.Rows[0][0]);

            if (count > 0)
            {
                lblThongBao.Text = "Email này đã được đăng ký!";
                return;
            }

            string query = @"INSERT INTO BenhNhan 
                (HoTen, NgaySinh, GioiTinh, SDT, Email, DiaChi, MatKhau) 
                VALUES (@HoTen, @NgaySinh, @GioiTinh, @SDT, @Email, @DiaChi, @MatKhau)";

            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", txtHoTen.Text),
                new SqlParameter("@NgaySinh", DateTime.Parse(txtNgaySinh.Text)),
                new SqlParameter("@GioiTinh", ddlGioiTinh.SelectedValue),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text),
                new SqlParameter("@MatKhau", txtMatKhau.Text)
            };

            DBHelper.ExecuteNonQuery(query, parameters);
            Response.Redirect("DangNhap.aspx");
        }
    }
}