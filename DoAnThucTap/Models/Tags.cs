using System.ComponentModel.DataAnnotations;

namespace DoAnThucTap.Models
{
    public class Tags
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
