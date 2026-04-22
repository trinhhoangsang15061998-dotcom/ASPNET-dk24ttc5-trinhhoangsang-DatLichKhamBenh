<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatLich.aspx.cs" Inherits="DatLichKhamBenhWF.DatLich" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đặt Lịch Khám</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center text-primary">📅 Đặt Lịch Khám Bệnh</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success w-100" Visible="false" />
    <div class="row justify-content-center">
        <div class="col-md-7">
            <div class="mb-3">
                <label>Chuyên khoa</label>
                <asp:DropDownList ID="ddlChuyenKhoa" runat="server" CssClass="form-control"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlChuyenKhoa_SelectedIndexChanged" />
            </div>
            <div class="mb-3">
                <label>Bác sĩ</label>
                <asp:DropDownList ID="ddlBacSi" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Ngày khám</label>
                <asp:TextBox ID="txtNgayKham" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="mb-3">
                <label>Triệu chứng</label>
                <asp:TextBox ID="txtTrieuChung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>
            <asp:Button ID="btnDatLich" runat="server" Text="Đặt Lịch"
                CssClass="btn btn-primary w-100" OnClick="btnDatLich_Click" />
        </div>
    </div>
    <hr />
    <h4 class="text-center">Lịch Hẹn Của Tôi</h4>
    <asp:GridView ID="gvDatLich" runat="server" CssClass="table table-bordered table-hover"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="TenBS" HeaderText="Bác Sĩ" />
            <asp:BoundField DataField="NgayLam" HeaderText="Ngày Khám" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="GioBatDau" HeaderText="Giờ Bắt Đầu" />
            <asp:BoundField DataField="GioKetThuc" HeaderText="Giờ Kết Thúc" />
            <asp:BoundField DataField="TrieuChung" HeaderText="Triệu Chứng" />
            <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái" />
        </Columns>
    </asp:GridView>
</asp:Content>