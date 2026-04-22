<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="DatLichKhamBenhWF.DangKy" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng Ký</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">Đăng Ký Tài Khoản Bệnh Nhân</h2>
    <hr />
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="mb-3">
                <label>Họ và tên</label>
                <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Ngày sinh</label>
                <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="mb-3">
                <label>Giới tính</label>
                <asp:DropDownList ID="ddlGioiTinh" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Nam">Nam</asp:ListItem>
                    <asp:ListItem Value="Nữ">Nữ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label>Số điện thoại</label>
                <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="mb-3">
                <label>Địa chỉ</label>
                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Mật khẩu</label>
                <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button ID="btnDangKy" runat="server" Text="Đăng Ký"
                CssClass="btn btn-primary w-100" OnClick="btnDangKy_Click" />
            <div class="mt-2 text-center">
                <a href="DangNhap.aspx">Đã có tài khoản? Đăng nhập</a>
            </div>
            <asp:Label ID="lblThongBao" runat="server" CssClass="text-danger mt-2" />
        </div>
    </div>
</asp:Content>