using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaTimeDemo.DataAccess.Models
{
    public class Category
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("類別名稱")]
        public string? Name { get; set; }
        [DisplayName("顯示順序")]
        [Range(1, 100, ErrorMessage = "顯示順序必須介於 1 到 100 之間。")]
        public int? DisplayOrder { get; set; }
    }
}