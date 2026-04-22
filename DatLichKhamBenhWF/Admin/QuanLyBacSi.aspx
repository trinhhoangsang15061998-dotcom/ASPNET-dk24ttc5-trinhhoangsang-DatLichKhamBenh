<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLyBacSi.aspx.cs" Inherits="DatLichKhamBenhWF.Admin.QuanLyBacSi" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản Lý Bác Sĩ</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">👨‍⚕️ Quản Lý Bác Sĩ</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success w-100" Visible="false" />
    <h4>Thêm Bác Sĩ Mới</h4>
    <div class="row">
        <div class="col-md-3">
            <label>Họ tên</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2">
            <label>Chuyên khoa</label>
            <asp:DropDownList ID="ddlChuyenKhoa" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2">
            <label>Số điện thoại</label>
            <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2 d-flex align-items-end">
            <asp:Button ID="btnThem" runat="server" Text="Thêm"
                CssClass="btn btn-success w-100" OnClick="btnThem_Click" />
        </div>
    </div>
    <hr />
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtTuKhoa" runat="server" CssClass="form-control"
                placeholder="Tìm theo tên bác sĩ..." />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnTim" runat="server" Text="Tìm"
                CssClass="btn btn-primary w-100" OnClick="btnTim_Click" />
        </div>
    </div>
    <asp:GridView ID="gvBacSi" runat="server" CssClass="table table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="MaBS"
        OnRowCommand="gvBacSi_RowCommand">
        <Columns>
            <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" />
            <asp:BoundField DataField="TenCK" HeaderText="Chuyên Khoa" />
            <asp:BoundField DataField="SDT" HeaderText="Số Điện Thoại" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:ButtonField CommandName="Xoa" Text="Xóa" ButtonType="Button"
                ControlStyle-CssClass="btn btn-danger btn-sm" HeaderText="Xóa" />
        </Columns>
    </asp:GridView>
</asp:Content>