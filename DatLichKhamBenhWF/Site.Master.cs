using System;

namespace DatLichKhamBenhWF
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HoTen"] != null)
            {
                pnlDangNhap.Visible = false;
                pnlDaDangNhap.Visible = true;
                lblHoTen.Text = "👤 " + Session["HoTen"].ToString();
                pnlAdmin.Visible = Session["VaiTro"] != null &&
                                   Session["VaiTro"].ToString() == "Admin";
            }
            else
            {
                pnlDangNhap.Visible = true;
                pnlDaDangNhap.Visible = false;
                pnlAdmin.Visible = false;
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Default.aspx");
        }
    }
}