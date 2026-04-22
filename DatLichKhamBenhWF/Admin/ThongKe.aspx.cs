using System;
using System.Data.SqlClient;
using DatLichKhamBenhWF.DAL;

namespace DatLichKhamBenhWF.Admin
{
    public partial class ThongKe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load dropdown tháng
                for (int i = 1; i <= 12; i++)
                    ddlThang.Items.Add(new System.Web.UI.WebControls.ListItem("Tháng " + i, i.ToString()));
                ddlThang.SelectedValue = DateTime.Now.Month.ToString();
                txtNam.Text = DateTime.Now.Year.ToString();
                LoadThongKe();
            }
        }

        private void LoadThongKe()
        {
            int thang = Convert.ToInt32(ddlThang.SelectedValue);
            int nam = Convert.ToInt32(txtNam.Text);

            // Tổng quan
            lblTong.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) FROM DatLich WHERE MONTH(NgayDat)=@T AND YEAR(NgayDat)=@N",
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) })
                .Rows[0][0].ToString();

            lblXacNhan.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) FROM DatLich WHERE TrangThai=N'Đã xác nhận' AND MONTH(NgayDat)=@T AND YEAR(NgayDat)=@N",
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) })
                .Rows[0][0].ToString();

            lblCho.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) FROM DatLich WHERE TrangThai=N'Chờ xác nhận' AND MONTH(NgayDat)=@T AND YEAR(NgayDat)=@N",
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) })
                .Rows[0][0].ToString();

            lblHuy.Text = DBHelper.ExecuteQuery(
                "SELECT COUNT(*) FROM DatLich WHERE TrangThai=N'Đã hủy' AND MONTH(NgayDat)=@T AND YEAR(NgayDat)=@N",
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) })
                .Rows[0][0].ToString();

            // Thống kê theo bác sĩ
            string queryBS = @"SELECT b.HoTen AS TenBS, c.TenCK,
                COUNT(*) AS TongSo,
                SUM(CASE WHEN d.TrangThai=N'Đã xác nhận' THEN 1 ELSE 0 END) AS DaXacNhan,
                SUM(CASE WHEN d.TrangThai=N'Đã hủy' THEN 1 ELSE 0 END) AS DaHuy
                FROM DatLich d
                JOIN LichLamViec l ON d.MaLich = l.MaLich
                JOIN BacSi b ON l.MaBS = b.MaBS
                JOIN ChuyenKhoa c ON b.MaCK = c.MaCK
                WHERE MONTH(d.NgayDat)=@T AND YEAR(d.NgayDat)=@N
                GROUP BY b.HoTen, c.TenCK";
            gvThongKeBS.DataSource = DBHelper.ExecuteQuery(queryBS,
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) });
            gvThongKeBS.DataBind();

            // Thống kê theo chuyên khoa
            string queryCK = @"SELECT c.TenCK, COUNT(*) AS TongSo
                FROM DatLich d
                JOIN LichLamViec l ON d.MaLich = l.MaLich
                JOIN BacSi b ON l.MaBS = b.MaBS
                JOIN ChuyenKhoa c ON b.MaCK = c.MaCK
                WHERE MONTH(d.NgayDat)=@T AND YEAR(d.NgayDat)=@N
                GROUP BY c.TenCK";
            gvThongKeCK.DataSource = DBHelper.ExecuteQuery(queryCK,
                new SqlParameter[] { new SqlParameter("@T", thang), new SqlParameter("@N", nam) });
            gvThongKeCK.DataBind();
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}