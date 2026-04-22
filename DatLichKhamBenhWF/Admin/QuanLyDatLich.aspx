<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLyDatLich.aspx.cs" Inherits="DatLichKhamBenhWF.Admin.QuanLyDatLich" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản Lý Lịch Hẹn</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">📋 Quản Lý Lịch Hẹn</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success w-100" Visible="false" />
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtTuKhoa" runat="server" CssClass="form-control"
                placeholder="Tìm theo tên bệnh nhân..." />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnTim" runat="server" Text="Tìm"
                CssClass="btn btn-primary w-100" OnClick="btnTim_Click" />
        </div>
    </div>
    <asp:GridView ID="gvDatLich" runat="server" CssClass="table table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="MaDL"
        OnRowCommand="gvDatLich_RowCommand">
        <Columns>
            <asp:BoundField DataField="TenBN" HeaderText="Bệnh Nhân" />
            <asp:BoundField DataField="TenBS" HeaderText="Bác Sĩ" />
            <asp:BoundField DataField="NgayLam" HeaderText="Ngày Khám" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="GioBatDau" HeaderText="Giờ" />
            <asp:BoundField DataField="TrieuChung" HeaderText="Triệu Chứng" />
            <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái" />
            <asp:ButtonField CommandName="XacNhan" Text="✓ Xác Nhận" ButtonType="Button"
                ControlStyle-CssClass="btn btn-success btn-sm" HeaderText="Xác Nhận" />
            <asp:ButtonField CommandName="Huy" Text="✗ Hủy" ButtonType="Button"
                ControlStyle-CssClass="btn btn-danger btn-sm" HeaderText="Hủy" />
        </Columns>
    </asp:GridView>
    <div class="row mt-4">
        <div class="col-md-4">
            <div class="card text-white bg-warning text-center p-3">
                <h5>Chờ Xác Nhận</h5>
                <h2><asp:Label ID="lblChoXacNhan" runat="server" Text="0" /></h2>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-success text-center p-3">
                <h5>Đã Xác Nhận</h5>
                <h2><asp:Label ID="lblDaXacNhan" runat="server" Text="0" /></h2>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-danger text-center p-3">
                <h5>Đã Hủy</h5>
                <h2><asp:Label ID="lblDaHuy" runat="server" Text="0" /></h2>
            </div>
        </div>
    </div>
</asp:Content>