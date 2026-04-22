<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DatLichKhamBenhWF._Default" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang Chủ</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mb-5">
        <h1 class="text-primary">🏥 Hệ Thống Đặt Lịch Khám Bệnh</h1>
        <p class="lead">Đặt lịch hẹn khám bệnh ngoài giờ nhanh chóng, tiện lợi</p>
        <a href="DangKy.aspx" class="btn btn-primary btn-lg me-2">Đăng Ký Ngay</a>
        <a href="DatLich.aspx" class="btn btn-outline-primary btn-lg">📅 Đặt Lịch Khám</a>
    </div>
    <div class="row text-center">
        <div class="col-md-4">
            <div class="card shadow p-4 mb-4">
                <h1>🩺</h1>
                <h4>Đội Ngũ Bác Sĩ</h4>
                <p>Bác sĩ chuyên khoa giàu kinh nghiệm</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow p-4 mb-4">
                <h1>📅</h1>
                <h4>Đặt Lịch Dễ Dàng</h4>
                <p>Đặt lịch online 24/7, không cần chờ đợi</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow p-4 mb-4">
                <h1>⚡</h1>
                <h4>Nhanh Chóng</h4>
                <p>Xác nhận lịch hẹn trong vài phút</p>
            </div>
        </div>
    </div>
</asp:Content>