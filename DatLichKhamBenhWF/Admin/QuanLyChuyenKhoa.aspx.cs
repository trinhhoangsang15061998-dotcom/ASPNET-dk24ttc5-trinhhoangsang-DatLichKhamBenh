using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF.Admin
{
    public partial class QuanLyChuyenKhoa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadData();
        }

        private void LoadData()
        {
            string query = @"SELECT c.MaCK, c.TenCK, c.MoTa,
                COUNT(b.MaBS) AS SoBacSi
                FROM ChuyenKhoa c
                LEFT JOIN BacSi b ON c.MaCK = b.MaCK
                GROUP BY c.MaCK, c.TenCK, c.MoTa";
            gvChuyenKhoa.DataSource = DBHelper.ExecuteQuery(query);
            gvChuyenKhoa.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO ChuyenKhoa (TenCK, MoTa) VALUES (@TenCK, @MoTa)";
            DBHelper.ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@TenCK", txtTenCK.Text),
                new SqlParameter("@MoTa", txtMoTa.Text)
            });
            lblThongBao.Text = "Thêm chuyên khoa thành công!";
            lblThongBao.Visible = true;
            LoadData();
        }

        protected void gvChuyenKhoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int maCK = Convert.ToInt32(gvChuyenKhoa.DataKeys[index].Value);
                DBHelper.ExecuteNonQuery("DELETE FROM ChuyenKhoa WHERE MaCK=@MaCK",
                    new SqlParameter[] { new SqlParameter("@MaCK", maCK) });
                lblThongBao.Text = "Xóa chuyên khoa thành công!";
                lblThongBao.Visible = true;
                LoadData();
            }
        }
    }
}