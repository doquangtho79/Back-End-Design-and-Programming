## Giới thiệu về Views trong ASP.NET Core MVC

Views trong folder `SinhVien` chứa các file Razor (.cshtml) chịu trách nhiệm hiển thị giao diện người dùng cho các thao tác CRUD của sinh viên. Đây là phần presentation layer trong kiến trúc MVC.

## Cấu trúc Views

### Layout và Shared Views
- Sử dụng `_Layout.cshtml` chung cho toàn bộ ứng dụng
- Views được đặt trong `Views/SinhVien/` theo convention
- Mỗi action trong controller tương ứng với một view

## Các View Files

### 1. Index.cshtml - Danh sách sinh viên

#### Model Directive
```cshtml
@model List<SinhVien>
```
- Nhận model là danh sách sinh viên từ controller

#### ViewData
```cshtml
@{
    ViewData["Title"] = "Danh sách sinh viên";
}
```
- Thiết lập tiêu đề trang

#### Hiển thị dữ liệu với Razor Syntax
```cshtml
@foreach (var student in Model)
{
    <tr>
        <td>@student.Id</td>
        <td>@student.MaSinhVien</td>
        <td>@student.HoVaTen</td>
        <!-- ... -->
    </tr>
}
```
- Sử dụng `@foreach` để lặp qua danh sách
- Truy cập properties với `@student.PropertyName`

#### Tag Helpers
```cshtml
<a asp-action="Create" class="btn btn-primary">
<a asp-controller="SinhVien" asp-action="Details" asp-route-id="@student.Id">
```
- `asp-action`: Tạo URL đến action
- `asp-route-id`: Truyền parameter

### 2. Details.cshtml - Chi tiết sinh viên

#### Model
```cshtml
@model SinhVien
```
- Nhận model là một đối tượng SinhVien

#### Bootstrap Components
```cshtml
<div class="card mt-3">
    <div class="card-header bg-primary text-white">
        <h4>Thông tin sinh viên</h4>
    </div>
```
- Sử dụng Bootstrap để tạo giao diện đẹp

#### Hiển thị dữ liệu
```cshtml
<div class="row mb-3">
    <div class="col-md-3">
        <strong>Mã sinh viên:</strong>
    </div>
    <div class="col-md-9">
        @Model.MaSinhVien
    </div>
</div>
```
- Sử dụng `@Model.PropertyName` để hiển thị dữ liệu

#### Formatting
```cshtml
@Model.NgaySinh.ToString("dd/MM/yyyy")
```
- Format ngày tháng theo định dạng Việt Nam

### 3. Create.cshtml - Form tạo mới

#### Form Handling
```cshtml
<form asp-action="Create" id="createClassForm">
```
- `asp-action`: Form sẽ submit đến action "Create"

#### Validation Summary
```cshtml
<div asp-validation-summary="ModelOnly" class="alert alert-danger" role="alert"></div>
```
- Hiển thị tổng hợp lỗi validation

#### Input Fields với Tag Helpers
```cshtml
<input asp-for="MaSinhVien" class="form-control" placeholder="Nhập mã sinh viên" required />
<span asp-validation-for="MaSinhVien" class="text-danger small"></span>
```
- `asp-for`: Bind với property của model
- `asp-validation-for`: Hiển thị lỗi validation cho field

#### Label với Display Name
```cshtml
<label asp-for="MaSinhVien" class="form-label fw-bold">
    @Html.DisplayNameFor(model => model.MaSinhVien)
</label>
```
- `Html.DisplayNameFor`: Lấy tên hiển thị từ `[Display]` attribute

#### Input Types
```cshtml
<input type="email" asp-for="Email" ... />
<input type="tel" asp-for="SoDienThoai" ... />
<input type="date" asp-for="NgaySinh" ... />
```
- Sử dụng HTML5 input types cho validation client-side

### 4. Edit.cshtml - Form chỉnh sửa

#### Tương tự Create.cshtml nhưng:
- Model đã có dữ liệu nên form sẽ được populate
- Action là "Edit" thay vì "Create"
- Có thể thêm hidden field cho ID nếu cần

#### Form Method
```cshtml
<form asp-action="Edit" id="createClassForm">
```
- Submit đến action "Edit" với method POST

### 5. Delete.cshtml - Xác nhận xóa

#### Simple Form
```cshtml
<form asp-action="Delete" method="post">
    <input type="hidden" asp-for="Id" />
    <input type="submit" value="Xóa" onclick="return confirm('Bạn có chắc chắn muốn xóa?');" />
</form>
```
- Hidden field chứa ID
- JavaScript confirm trước khi xóa

## Kiến thức Razor Syntax

### 1. Directives
- `@model`: Khai báo kiểu model
- `@using`: Import namespace
- `@{ ... }`: Code block

### 2. Expressions
- `@Model.Property`: Hiển thị giá trị
- `@Html.DisplayNameFor()`: Tên hiển thị
- `@Url.Action()`: Tạo URL

### 3. Tag Helpers
- `asp-for`: Model binding
- `asp-action`: URL generation
- `asp-validation-for`: Validation messages
- `asp-validation-summary`: Tổng hợp validation errors

### 4. HTML Helpers (ít dùng hơn Tag Helpers)
- `@Html.TextBoxFor()`
- `@Html.LabelFor()`
- `@Html.ValidationMessageFor()`
