using System.ComponentModel.DataAnnotations;

namespace WpfAppTemplate.Models
{
    public class DaiLy
    {
        [Key]
        public int MaDaiLy { get; set; } = 0;

        [Required(ErrorMessage = "Tên đại lý không được để trống")]
        [StringLength(100, ErrorMessage = "Tên đại lý không được vượt quá 100 ký tự")]
        public string TenDaiLy { get; set; } = "";

        public int MaLoaiDaiLy { get; set; } = 0;
        public int MaQuan { get; set; } = 0;

        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự")]
        public string DiaChi { get; set; } = "";

        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string DienThoai { get; set; } = "";

        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = "";

        public DateTime NgayTiepNhan { get; set; } = DateTime.Now;
        public long TienNo { get; set; } = 0;

        // Navigation properties
        public LoaiDaiLy LoaiDaiLy { get; set; } = null!;
        public Quan Quan { get; set; } = null!;
    }
}
