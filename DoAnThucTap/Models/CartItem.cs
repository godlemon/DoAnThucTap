using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CameraId { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; } // Tổng thanh toán
        public Camera Camera { get; set; } // Tham chiếu đến domain camera
        public DateTime TransactionDate { get; set; } // Ngày giao dịch
        
        public User Users { get; set; }
    }

}
