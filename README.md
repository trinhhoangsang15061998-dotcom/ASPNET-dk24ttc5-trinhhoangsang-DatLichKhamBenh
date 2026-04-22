# 🏥 Hệ Thống Đặt Lịch Hẹn Khám Bệnh Ngoài Giờ

## Thông tin sinh viên
- **Họ tên:** Trịnh Hoàng Sang
- **MSSV:** 170124507
- **Lớp:** DK24TTC5
- **Môn học:** Chuyên đề ASP.NET
- **Giảng viên:** ThS. Đoàn Phước Miền

## Công nghệ sử dụng
- ASP.NET Web Forms (.NET Framework 4.8)
- C#
- SQL Server
- ADO.NET
- Bootstrap 5

## Hướng dẫn cài đặt

### Yêu cầu
- Visual Studio 2022+
- SQL Server
- SQL Server Management Studio (SSMS)

### Các bước chạy
1. Mở SSMS → New Query → mở file `database.sql` → bấm F5 để tạo database
2. Mở Visual Studio → mở file `DatLichKhamBenhWF.sln`
3. Mở file `Web.config` → kiểm tra connection string
4. Bấm F5 để chạy

## Tài khoản test
| Vai trò | Email | Mật khẩu |
|---------|-------|----------|
| Bệnh nhân | test@gmail.com | 123456 |

## Chức năng hệ thống
- ✅ Đăng ký / Đăng nhập bệnh nhân
- ✅ Đặt lịch khám theo bác sĩ và chuyên khoa
- ✅ Quản lý lịch làm việc bác sĩ
- ✅ Xác nhận / hủy lịch hẹn
- ✅ Tìm kiếm lịch hẹn theo tên bệnh nhân
- ✅ Thống kê báo cáo theo tháng
- ✅ Quản lý bác sĩ và chuyên khoa

## Cấu trúc database
- **BenhNhan**: Thông tin bệnh nhân
- **BacSi**: Thông tin bác sĩ
- **ChuyenKhoa**: Danh sách chuyên khoa
- **LichLamViec**: Lịch làm việc của bác sĩ
- **DatLich**: Lịch hẹn khám bệnh
