using System.ComponentModel.DataAnnotations;
using DoAnThucTap.Models;

namespace DoAnThucTap.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
    }

}
