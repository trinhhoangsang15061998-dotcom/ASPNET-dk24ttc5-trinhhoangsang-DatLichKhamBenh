<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThongKe.aspx.cs" Inherits="DatLichKhamBenhWF.Admin.ThongKe" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Thống Kê</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center text-primary">📊 Thống Kê Báo Cáo</h2>
            <hr />
            <!-- Bộ lọc -->
            <div class="row mb-4">
                <div class="col-md-2">
                    <label>Tháng</label>
                    <asp:DropDownList ID="ddlThang" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-2">
                    <label>Năm</label>
                    <asp:TextBox ID="txtNam" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-2 d-flex align-items-end">
                    <asp:Button ID="btnXem" runat="server" Text="Xem"
                        CssClass="btn btn-primary w-100" OnClick="btnXem_Click" />
                </div>
            </div>
            <!-- Tổng quan -->
            <div class="row mb-4">
                <div class="col-md-3">
                    <div class="card text-white bg-primary text-center p-3">
                        <h5>Tổng Lịch Hẹn</h5>
                        <h2><asp:Label ID="lblTong" runat="server" Text="0" /></h2>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card text-white bg-success text-center p-3">
                        <h5>Đã Xác Nhận</h5>
                        <h2><asp:Label ID="lblXacNhan" runat="server" Text="0" /></h2>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card text-white bg-warning text-center p-3">
                        <h5>Chờ Xác Nhận</h5>
                        <h2><asp:Label ID="lblCho" runat="server" Text="0" /></h2>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card text-white bg-danger text-center p-3">
                        <h5>Đã Hủy</h5>
                        <h2><asp:Label ID="lblHuy" runat="server" Text="0" /></h2>
                    </div>
                </div>
            </div>
            <!-- Thống kê theo bác sĩ -->
            <h4>📋 Thống Kê Theo Bác Sĩ</h4>
            <asp:GridView ID="gvThongKeBS" runat="server" CssClass="table table-bordered table-hover mb-4"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TenBS" HeaderText="Bác Sĩ" />
                    <asp:BoundField DataField="TenCK" HeaderText="Chuyên Khoa" />
                    <asp:BoundField DataField="TongSo" HeaderText="Tổng Lịch Hẹn" />
                    <asp:BoundField DataField="DaXacNhan" HeaderText="Đã Xác Nhận" />
                    <asp:BoundField DataField="DaHuy" HeaderText="Đã Hủy" />
                </Columns>
            </asp:GridView>
            <!-- Thống kê theo chuyên khoa -->
            <h4>🏥 Thống Kê Theo Chuyên Khoa</h4>
            <asp:GridView ID="gvThongKeCK" runat="server" CssClass="table table-bordered table-hover"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TenCK" HeaderText="Chuyên Khoa" />
                    <asp:BoundField DataField="TongSo" HeaderText="Số Lịch Hẹn" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>