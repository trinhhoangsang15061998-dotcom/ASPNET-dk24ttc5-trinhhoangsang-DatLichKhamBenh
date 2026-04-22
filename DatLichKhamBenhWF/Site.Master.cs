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
            }
            else
            {
                pnlDangNhap.Visible = true;
                pnlDaDangNhap.Visible = false;
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Default.aspx");
        }
    }
}