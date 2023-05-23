using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class Camera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên camera là bắt buộc.")]
        [DisplayName("Tên camera")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nhãn hiệu là bắt buộc.")]
        [DisplayName("Nhãn hiệu")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Độ phân giải là bắt buộc.")]
        [DisplayName("Độ phân giải")]
        public string Resolution { get; set; }
        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Nhãn dán")]
        public Tags Tags { get; set; }
    }
}
