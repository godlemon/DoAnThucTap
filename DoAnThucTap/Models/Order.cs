using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        public decimal TotalAmount { get; set; }

        public List<CartItem> CartItems { get; set; } // Tham chiếu đến danh sách giỏ hàng
    }

}
