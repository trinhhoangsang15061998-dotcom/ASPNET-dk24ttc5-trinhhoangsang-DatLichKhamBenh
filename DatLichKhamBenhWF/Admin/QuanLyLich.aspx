<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLyLich.aspx.cs" Inherits="DatLichKhamBenhWF.Admin.QuanLyLich" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản Lý Lịch</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">⚙️ Quản Lý Lịch Làm Việc Bác Sĩ</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success w-100" Visible="false" />
    <h4>Thêm Lịch Làm Việc</h4>
    <div class="row">
        <div class="col-md-3">
            <label>Bác sĩ</label>
            <asp:DropDownList ID="ddlBacSi" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-2">
            <label>Ngày làm</label>
            <asp:TextBox ID="txtNgayLam" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-2">
            <label>Giờ bắt đầu</label>
            <asp:TextBox ID="txtGioBatDau" runat="server" CssClass="form-control" TextMode="Time" />
        </div>
        <div class="col-md-2">
            <label>Giờ kết thúc</label>
            <asp:TextBox ID="txtGioKetThuc" runat="server" CssClass="form-control" TextMode="Time" />
        </div>
        <div class="col-md-2 d-flex align-items-end">
            <asp:Button ID="btnThem" runat="server" Text="Thêm"
                CssClass="btn btn-success w-100" OnClick="btnThem_Click" />
        </div>
    </div>
    <hr />
    <h4>Danh Sách Lịch Làm Việc</h4>
    <asp:GridView ID="gvLich" runat="server" CssClass="table table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="MaLich"
        OnRowCommand="gvLich_RowCommand">
        <Columns>
            <asp:BoundField DataField="TenBS" HeaderText="Bác Sĩ" />
            <asp:BoundField DataField="TenCK" HeaderText="Chuyên Khoa" />
            <asp:BoundField DataField="NgayLam" HeaderText="Ngày Làm" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="GioBatDau" HeaderText="Giờ Bắt Đầu" />
            <asp:BoundField DataField="GioKetThuc" HeaderText="Giờ Kết Thúc" />
            <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái" />
            <asp:ButtonField CommandName="Xoa" Text="Xóa" ButtonType="Button"
                ControlStyle-CssClass="btn btn-danger btn-sm" HeaderText="Xóa" />
        </Columns>
    </asp:GridView>
</asp:Content>