<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLyChuyenKhoa.aspx.cs" Inherits="DatLichKhamBenhWF.Admin.QuanLyChuyenKhoa" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản Lý Chuyên Khoa</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">🏥 Quản Lý Chuyên Khoa</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success w-100" Visible="false" />
    <h4>Thêm Chuyên Khoa Mới</h4>
    <div class="row">
        <div class="col-md-4">
            <label>Tên chuyên khoa</label>
            <asp:TextBox ID="txtTenCK" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-5">
            <label>Mô tả</label>
            <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2 d-flex align-items-end">
            <asp:Button ID="btnThem" runat="server" Text="Thêm"
                CssClass="btn btn-success w-100" OnClick="btnThem_Click" />
        </div>
    </div>
    <hr />
    <h4>Danh Sách Chuyên Khoa</h4>
    <asp:GridView ID="gvChuyenKhoa" runat="server" CssClass="table table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="MaCK"
        OnRowCommand="gvChuyenKhoa_RowCommand">
        <Columns>
            <asp:BoundField DataField="TenCK" HeaderText="Tên Chuyên Khoa" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô Tả" />
            <asp:BoundField DataField="SoBacSi" HeaderText="Số Bác Sĩ" />
            <asp:ButtonField CommandName="Xoa" Text="Xóa" ButtonType="Button"
                ControlStyle-CssClass="btn btn-danger btn-sm" HeaderText="Xóa" />
        </Columns>
    </asp:GridView>
</asp:Content>