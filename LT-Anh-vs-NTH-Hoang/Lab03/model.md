# SinhVienModel.md

## Giới thiệu về SinhVien Model

`SinhVien` là một model class trong ASP.NET Core MVC, đại diện cho thực thể Sinh Viên trong hệ thống quản lý. Model này định nghĩa cấu trúc dữ liệu và các quy tắc validation cho thông tin sinh viên.

## Cấu trúc Class

```csharp
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models
{
    public class SinhVien
    {
        // Properties...
    }
}
```

## Các Properties

### 1. Id
```csharp
public int Id { get; set; }
```
- **Kiểu dữ liệu**: `int`
- **Mục đích**: Khóa chính (Primary Key) duy nhất cho mỗi sinh viên
- **Tự động tạo**: Trong controller, ID được tạo tự động khi thêm mới

### 2. MaSinhVien
```csharp
[Required(ErrorMessage = "Mã sinh viên là bắt buộc")]
[Display(Name = "Mã sinh viên")]
public string MaSinhVien { get; set; }
```
- **Kiểu dữ liệu**: `string`
- **Validation**: Bắt buộc nhập
- **Display**: Hiển thị tên thân thiện trong UI
- **Mục đích**: Mã số duy nhất của sinh viên (ví dụ: 1880001)

### 3. HoVaTen
```csharp
[Required(ErrorMessage = "Họ và tên là bắt buộc")]
[Display(Name = "Họ và tên")]
public string HoVaTen { get; set; }
```
- **Kiểu dữ liệu**: `string`
- **Validation**: Bắt buộc nhập
- **Mục đích**: Họ và tên đầy đủ của sinh viên

### 4. Email
```csharp
[Display(Name = "Email")]
public string? Email { get; set; }
```
- **Kiểu dữ liệu**: `string?` (nullable)
- **Validation**: Không bắt buộc
- **Mục đích**: Địa chỉ email của sinh viên

### 5. SoDienThoai
```csharp
[Display(Name = "Số điện thoại")]
public string? SoDienThoai { get; set; }
```
- **Kiểu dữ liệu**: `string?` (nullable)
- **Validation**: Không bắt buộc
- **Mục đích**: Số điện thoại liên hệ

### 6. NgaySinh
```csharp
[Display(Name = "Ngày sinh")]
[Required(ErrorMessage = "Ngày sinh là bắt buộc")]
public DateTime NgaySinh { get; set; }
```
- **Kiểu dữ liệu**: `DateTime`
- **Validation**: Bắt buộc nhập
- **Mục đích**: Ngày tháng năm sinh của sinh viên

## Data Annotations

### 1. [Required]
- **Mục đích**: Đánh dấu trường bắt buộc nhập
- **ErrorMessage**: Thông báo lỗi tùy chỉnh khi validation fail
- **Áp dụng cho**: MaSinhVien, HoVaTen, NgaySinh

### 2. [Display]
- **Mục đích**: Cung cấp tên hiển thị thân thiện cho UI
- **Name**: Chuỗi hiển thị thay vì tên property
- **Áp dụng cho**: Tất cả properties

## Kiến thức về Model Validation

### Client-side Validation
- ASP.NET Core tự động tạo JavaScript validation dựa trên data annotations
- Hiển thị lỗi ngay trên trình duyệt mà không cần postback

### Server-side Validation
- Controller kiểm tra `ModelState.IsValid` trước khi xử lý
- Bảo vệ chống lại invalid data từ client

### Validation Attributes phổ biến
- `[Required]`: Trường bắt buộc
- `[StringLength]`: Giới hạn độ dài chuỗi
- `[Range]`: Giới hạn giá trị số
- `[EmailAddress]`: Validation email
- `[Phone]`: Validation số điện thoại
- `[RegularExpression]`: Validation theo pattern

## Nullable Reference Types

### string?
- Sử dụng `string?` cho các trường không bắt buộc
- Cho phép giá trị null mà không gây warning compiler
- Phù hợp với nullable reference types trong C# 8+

## Best Practices cho Model Design

### 1. Validation Rules
- Đặt validation ở model level thay vì controller
- Sử dụng ErrorMessage để có thông báo rõ ràng

### 2. Display Names
- Luôn sử dụng `[Display(Name = "...")]` cho UX tốt
- Tên hiển thị nên bằng tiếng Việt thân thiện

### 3. Data Types
- Chọn kiểu dữ liệu phù hợp (DateTime cho ngày tháng)
- Sử dụng nullable types khi cần thiết

### 4. Property Naming
- Sử dụng PascalCase theo convention C#
- Tên property nên mô tả rõ nội dung

## Mở rộng Model

### Thêm Validation nâng cao
```csharp
[EmailAddress(ErrorMessage = "Email không hợp lệ")]
public string? Email { get; set; }

[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
public string? SoDienThoai { get; set; }

[StringLength(10, ErrorMessage = "Mã sinh viên không quá 10 ký tự")]
public string MaSinhVien { get; set; }
```