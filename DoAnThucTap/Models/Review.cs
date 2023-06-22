using System.ComponentModel.DataAnnotations;
using DoAnThucTap.Areas.Admin.Models;

namespace DoAnThucTap.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int CameraId { get; set; }

        public int CustomerId { get; set; }

        [Range(1, 5, ErrorMessage = "Đánh giá từ 1 đến 5 sao.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Nội dung nhận xét là bắt buộc.")]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public Camera Camera { get; set; }

        public User Users { get; set; }
    }

}
