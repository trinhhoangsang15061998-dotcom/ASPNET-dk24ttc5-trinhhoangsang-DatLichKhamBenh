<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="DatLichKhamBenhWF.DangNhap" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng Nhập</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">Đăng Nhập</h2>
    <hr />
    <div class="row justify-content-center">
        <div class="col-md-5">
            <div class="mb-3">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="mb-3">
                <label>Mật khẩu</label>
                <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button ID="btnDangNhap" runat="server" Text="Đăng Nhập"
                CssClass="btn btn-primary w-100" OnClick="btnDangNhap_Click" />
            <div class="mt-2 text-center">
                <a href="DangKy.aspx">Chưa có tài khoản? Đăng ký ngay</a>
            </div>
            <asp:Label ID="lblThongBao" runat="server" CssClass="text-danger mt-2" />
        </div>
    </div>
</asp:Content>