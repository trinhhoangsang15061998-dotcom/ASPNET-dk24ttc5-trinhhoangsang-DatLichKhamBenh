using System;
using System.Data.SqlClient;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF
{
    public partial class DatLich : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaBN"] == null)
                Response.Redirect("DangNhap.aspx");

            if (!IsPostBack)
            {
                LoadChuyenKhoa();
                LoadBacSi();
                LoadDatLich();
            }
        }

        private void LoadChuyenKhoa()
        {
            var dt = DBHelper.ExecuteQuery("SELECT MaCK, TenCK FROM ChuyenKhoa");
            ddlChuyenKhoa.DataSource = dt;
            ddlChuyenKhoa.DataTextField = "TenCK";
            ddlChuyenKhoa.DataValueField = "MaCK";
            ddlChuyenKhoa.DataBind();
            ddlChuyenKhoa.Items.Insert(0, "-- Chọn chuyên khoa --");
        }

        private void LoadBacSi()
        {
            string query = "SELECT MaBS, HoTen FROM BacSi";
            if (ddlChuyenKhoa.SelectedIndex > 0)
            {
                query += " WHERE MaCK = @MaCK";
                var dt = DBHelper.ExecuteQuery(query, new SqlParameter[] {
                    new SqlParameter("@MaCK", ddlChuyenKhoa.SelectedValue)
                });
                ddlBacSi.DataSource = dt;
            }
            else
            {
                ddlBacSi.DataSource = DBHelper.ExecuteQuery(query);
            }
            ddlBacSi.DataTextField = "HoTen";
            ddlBacSi.DataValueField = "MaBS";
            ddlBacSi.DataBind();
            ddlBacSi.Items.Insert(0, "-- Chọn bác sĩ --");
        }

        private void LoadDatLich()
        {
            string query = @"SELECT b.HoTen AS TenBS, l.NgayLam, l.GioBatDau, l.GioKetThuc,
                            d.TrieuChung, d.TrangThai
                            FROM DatLich d
                            JOIN LichLamViec l ON d.MaLich = l.MaLich
                            JOIN BacSi b ON l.MaBS = b.MaBS
                            WHERE d.MaBN = @MaBN";
            var dt = DBHelper.ExecuteQuery(query, new SqlParameter[] {
                new SqlParameter("@MaBN", Session["MaBN"].ToString())
            });
            gvDatLich.DataSource = dt;
            gvDatLich.DataBind();
        }

        protected void ddlChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBacSi();
        }

        protected void btnDatLich_Click(object sender, EventArgs e)
        {
            if (ddlBacSi.SelectedIndex == 0 || string.IsNullOrEmpty(txtNgayKham.Text))
            {
                lblThongBao.Text = "Vui lòng chọn đầy đủ thông tin!";
                lblThongBao.CssClass = "alert alert-danger w-100";
                lblThongBao.Visible = true;
                return;
            }

            // Tìm lịch làm việc phù hợp
            string queryLich = @"SELECT MaLich FROM LichLamViec 
                WHERE MaBS = @MaBS AND NgayLam = @NgayLam AND TrangThai = N'Còn trống'";
            var lichDt = DBHelper.ExecuteQuery(queryLich, new SqlParameter[] {
                new SqlParameter("@MaBS", ddlBacSi.SelectedValue),
                new SqlParameter("@NgayLam", DateTime.Parse(txtNgayKham.Text))
            });

            if (lichDt.Rows.Count == 0)
            {
                lblThongBao.Text = "Bác sĩ không có lịch vào ngày này!";
                lblThongBao.CssClass = "alert alert-danger w-100";
                lblThongBao.Visible = true;
                return;
            }

            int maLich = Convert.ToInt32(lichDt.Rows[0]["MaLich"]);

            // Thêm lịch hẹn
            string queryDat = @"INSERT INTO DatLich (MaBN, MaLich, NgayDat, TrieuChung, TrangThai)
                VALUES (@MaBN, @MaLich, @NgayDat, @TrieuChung, N'Chờ xác nhận')";
            DBHelper.ExecuteNonQuery(queryDat, new SqlParameter[] {
                new SqlParameter("@MaBN", Session["MaBN"].ToString()),
                new SqlParameter("@MaLich", maLich),
                new SqlParameter("@NgayDat", DateTime.Now),
                new SqlParameter("@TrieuChung", txtTrieuChung.Text)
            });

            // Cập nhật trạng thái lịch
            DBHelper.ExecuteNonQuery("UPDATE LichLamViec SET TrangThai=N'Đã đặt' WHERE MaLich=@MaLich",
                new SqlParameter[] { new SqlParameter("@MaLich", maLich) });

            lblThongBao.Text = "Đặt lịch thành công!";
            lblThongBao.CssClass = "alert alert-success w-100";
            lblThongBao.Visible = true;
            LoadDatLich();
        }
    }
}