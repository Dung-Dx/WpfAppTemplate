using System.ComponentModel.DataAnnotations;

namespace WpfAppTemplate.Models
{
    public class LoaiDaiLy
    {
        [Key]
        public int MaLoaiDaiLy { get; set; } = 0;

        [Required(ErrorMessage = "Tên loại đại lý không được để trống")]
        [StringLength(100, ErrorMessage = "Tên loại đại lý không được vượt quá 100 ký tự")]
        public string TenLoaiDaiLy { get; set; } = "";
        public long NoToiDa { get; set; } = 0;

        // Navigation property
        public ICollection<DaiLy> DsDaiLy { get; set; } = [];
    }
}
