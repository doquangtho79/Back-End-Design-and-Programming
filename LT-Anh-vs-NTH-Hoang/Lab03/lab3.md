# Giới thiệu về bài toán quản lý sinh viên cơ bản theo mô hình MVC

## Tổng quan về bài toán

Bài toán quản lý sinh viên cơ bản là một ứng dụng web đơn giản được xây dựng bằng ASP.NET Core MVC, nhằm mục đích quản lý thông tin của các sinh viên trong một trường học hoặc tổ chức giáo dục. Ứng dụng cho phép thực hiện các thao tác cơ bản như:

- **Xem danh sách sinh viên**: Hiển thị tất cả sinh viên hiện có với thông tin chi tiết.
- **Thêm sinh viên mới**: Cho phép nhập thông tin của sinh viên mới và lưu vào cơ sở dữ liệu.
- **Chỉnh sửa thông tin sinh viên**: Cập nhật thông tin của một sinh viên đã tồn tại.
- **Xóa sinh viên**: Loại bỏ thông tin của một sinh viên khỏi hệ thống.
- **Xem chi tiết sinh viên**: Hiển thị thông tin đầy đủ của một sinh viên cụ thể.

## Mô hình MVC (Model-View-Controller)

Mô hình MVC là một kiến trúc phần mềm phổ biến được sử dụng trong phát triển ứng dụng web. Nó tách biệt logic nghiệp vụ, giao diện người dùng và điều khiển luồng dữ liệu thành ba thành phần riêng biệt:

- **Model**: Đại diện cho dữ liệu và logic nghiệp vụ của ứng dụng. Trong project này, Model là lớp `SinhVien` chứa các thuộc tính như Mã sinh viên, Họ tên, Ngày sinh, Giới tính, Lớp, v.v.
- **View**: Chịu trách nhiệm hiển thị dữ liệu cho người dùng. Các file Razor (.cshtml) trong thư mục Views/SinhVien như Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, Delete.cshtml là các View tương ứng với các thao tác CRUD.
- **Controller**: Xử lý các yêu cầu từ người dùng, tương tác với Model để lấy hoặc cập nhật dữ liệu, và chọn View phù hợp để trả về. `SinhVienController` là Controller chính trong project này, chứa các action methods như Index, Create, Edit, Delete, Details.

## Cấu trúc project

Project QuanLySinhVien được tổ chức theo cấu trúc chuẩn của ASP.NET Core MVC:

- **Controllers/**: Chứa các Controller, bao gồm `HomeController.cs` và `SinhVienController.cs`.
- **Models/**: Chứa các Model, bao gồm `SinhVien.cs` và `ErrorViewModel.cs`.
- **Views/**: Chứa các View, được chia thành các thư mục con như Home/, Shared/, SinhVien/.
- **wwwroot/**: Chứa các tài nguyên tĩnh như CSS, JavaScript, hình ảnh.
- **appsettings.json**: Cấu hình ứng dụng, bao gồm chuỗi kết nối cơ sở dữ liệu.
- **Program.cs**: Điểm vào của ứng dụng, cấu hình dịch vụ và pipeline xử lý yêu cầu.

## Cách hoạt động

1. Người dùng gửi yêu cầu HTTP đến ứng dụng thông qua trình duyệt.
2. Routing middleware định tuyến yêu cầu đến Controller phù hợp (ví dụ: SinhVienController).
3. Controller xử lý yêu cầu, tương tác với Model để truy vấn hoặc cập nhật dữ liệu.
4. Controller chọn View phù hợp và truyền dữ liệu (ViewModel) để render.
5. View được render thành HTML và trả về cho người dùng.