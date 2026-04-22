using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF.Admin
{
    public partial class QuanLyDatLich : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadData();
        }

        private void LoadData(string tuKhoa = "")
        {
            string query = @"SELECT d.MaDL, bn.HoTen AS TenBN, bs.HoTen AS TenBS,
                            l.NgayLam, l.GioBatDau, d.TrieuChung, d.TrangThai
                            FROM DatLich d
                            JOIN BenhNhan bn ON d.MaBN = bn.MaBN
                            JOIN LichLamViec l ON d.MaLich = l.MaLich
                            JOIN BacSi bs ON l.MaBS = bs.MaBS
                            WHERE bn.HoTen LIKE @TuKhoa
                            ORDER BY d.NgayDat DESC";
            gvDatLich.DataSource = DBHelper.ExecuteQuery(query, new SqlParameter[] {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            });
            gvDatLich.DataBind();

            lblChoXacNhan.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) AS N FROM DatLich WHERE TrangThai=N'Chờ xác nhận'")
                .Rows[0][0].ToString();
            lblDaXacNhan.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) AS N FROM DatLich WHERE TrangThai=N'Đã xác nhận'")
                .Rows[0][0].ToString();
            lblDaHuy.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) AS N FROM DatLich WHERE TrangThai=N'Đã hủy'")
                .Rows[0][0].ToString();
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            LoadData(txtTuKhoa.Text);
        }

        protected void gvDatLich_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int maDL = Convert.ToInt32(gvDatLich.DataKeys[index].Value);

            if (e.CommandName == "XacNhan")
            {
                DBHelper.ExecuteNonQuery(
                    "UPDATE DatLich SET TrangThai=N'Đã xác nhận' WHERE MaDL=@MaDL",
                    new SqlParameter[] { new SqlParameter("@MaDL", maDL) });
                lblThongBao.Text = "Xác nhận thành công!";
            }
            else if (e.CommandName == "Huy")
            {
                var dt = DBHelper.ExecuteQuery(
                    "SELECT MaLich FROM DatLich WHERE MaDL=@MaDL",
                    new SqlParameter[] { new SqlParameter("@MaDL", maDL) });
                int maLich = Convert.ToInt32(dt.Rows[0]["MaLich"]);

                DBHelper.ExecuteNonQuery(
                    "UPDATE DatLich SET TrangThai=N'Đã hủy' WHERE MaDL=@MaDL",
                    new SqlParameter[] { new SqlParameter("@MaDL", maDL) });
                DBHelper.ExecuteNonQuery(
                    "UPDATE LichLamViec SET TrangThai=N'Còn trống' WHERE MaLich=@MaLich",
                    new SqlParameter[] { new SqlParameter("@MaLich", maLich) });
                lblThongBao.Text = "Đã hủy lịch hẹn!";
            }

            lblThongBao.Visible = true;
            LoadData();
        }
    }
}