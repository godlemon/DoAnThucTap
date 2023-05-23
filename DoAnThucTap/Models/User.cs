using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên là bắt buộc.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
    }

}
