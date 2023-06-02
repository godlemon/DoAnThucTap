using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class Warehouses
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Camera Camera { get; set; }
        [Required(ErrorMessage = "Giá nhập là bắt buộc.")]
        [DisplayName("Giá Nhập")]
        public decimal PriceBuy { get; set; }
        [Required(ErrorMessage = "Giá bán là bắt buộc.")]
        [DisplayName("Giá bán")]
        public decimal PriceSell { get; set; }
        [Required]
        [DisplayName("Số lượng nhập")]
        public  int Amount { get; set; }
        [Required]
        [DisplayName("Số lượng đã bán")]
        public  int Sold { get; set; }
        public  int Active { get; set; }
        
    }
}
