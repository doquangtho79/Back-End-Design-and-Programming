using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models
{
    public class SinhVien
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên là bắt buộc")]
        [Display(Name = "Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string HoVaTen { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
        
        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime NgaySinh { get; set; }

    }
}
