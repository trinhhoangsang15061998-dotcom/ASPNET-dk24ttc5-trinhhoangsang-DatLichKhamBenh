using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF.Admin
{
    public partial class QuanLyLich : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBacSi();
                LoadLich();
            }
        }

        private void LoadBacSi()
        {
            var dt = DBHelper.ExecuteQuery("SELECT MaBS, HoTen FROM BacSi");
            ddlBacSi.DataSource = dt;
            ddlBacSi.DataTextField = "HoTen";
            ddlBacSi.DataValueField = "MaBS";
            ddlBacSi.DataBind();
        }

        private void LoadLich()
        {
            string query = @"SELECT l.MaLich, b.HoTen AS TenBS, c.TenCK,
                            l.NgayLam, l.GioBatDau, l.GioKetThuc, l.TrangThai
                            FROM LichLamViec l
                            JOIN BacSi b ON l.MaBS = b.MaBS
                            JOIN ChuyenKhoa c ON b.MaCK = c.MaCK
                            ORDER BY l.NgayLam DESC";
            gvLich.DataSource = DBHelper.ExecuteQuery(query);
            gvLich.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO LichLamViec (MaBS, NgayLam, GioBatDau, GioKetThuc, TrangThai)
                VALUES (@MaBS, @NgayLam, @GioBatDau, @GioKetThuc, N'Còn trống')";
            DBHelper.ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@MaBS", ddlBacSi.SelectedValue),
                new SqlParameter("@NgayLam", DateTime.Parse(txtNgayLam.Text)),
                new SqlParameter("@GioBatDau", txtGioBatDau.Text),
                new SqlParameter("@GioKetThuc", txtGioKetThuc.Text)
            });
            lblThongBao.Text = "Thêm lịch thành công!";
            lblThongBao.Visible = true;
            LoadLich();
        }

        protected void gvLich_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int maLich = Convert.ToInt32(gvLich.DataKeys[index].Value);
                DBHelper.ExecuteNonQuery("DELETE FROM LichLamViec WHERE MaLich=@MaLich",
                    new SqlParameter[] { new SqlParameter("@MaLich", maLich) });
                lblThongBao.Text = "Xóa lịch thành công!";
                lblThongBao.Visible = true;
                LoadLich();
            }
        }
    }
}