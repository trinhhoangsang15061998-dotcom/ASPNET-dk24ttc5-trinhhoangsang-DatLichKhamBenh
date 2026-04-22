using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF.Admin
{
    public partial class QuanLyBacSi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChuyenKhoa();
                LoadBacSi();
            }
        }

        private void LoadChuyenKhoa()
        {
            var dt = DBHelper.ExecuteQuery("SELECT MaCK, TenCK FROM ChuyenKhoa");
            ddlChuyenKhoa.DataSource = dt;
            ddlChuyenKhoa.DataTextField = "TenCK";
            ddlChuyenKhoa.DataValueField = "MaCK";
            ddlChuyenKhoa.DataBind();
        }

        private void LoadBacSi(string tuKhoa = "")
        {
            string query = @"SELECT b.MaBS, b.HoTen, c.TenCK, b.SDT, b.Email
                            FROM BacSi b JOIN ChuyenKhoa c ON b.MaCK = c.MaCK
                            WHERE b.HoTen LIKE @TuKhoa";
            gvBacSi.DataSource = DBHelper.ExecuteQuery(query, new SqlParameter[] {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            });
            gvBacSi.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO BacSi (HoTen, MaCK, SDT, Email, MatKhau)
                VALUES (@HoTen, @MaCK, @SDT, @Email, '123456')";
            DBHelper.ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@HoTen", txtHoTen.Text),
                new SqlParameter("@MaCK", ddlChuyenKhoa.SelectedValue),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@Email", txtEmail.Text)
            });
            lblThongBao.Text = "Thêm bác sĩ thành công!";
            lblThongBao.Visible = true;
            LoadBacSi();
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            LoadBacSi(txtTuKhoa.Text);
        }

        protected void gvBacSi_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int maBS = Convert.ToInt32(gvBacSi.DataKeys[index].Value);
                DBHelper.ExecuteNonQuery("DELETE FROM BacSi WHERE MaBS=@MaBS",
                    new SqlParameter[] { new SqlParameter("@MaBS", maBS) });
                lblThongBao.Text = "Xóa bác sĩ thành công!";
                lblThongBao.Visible = true;
                LoadBacSi();
            }
        }
    }
}