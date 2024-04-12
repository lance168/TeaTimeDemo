using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaTimeDemo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("類別名稱")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("顯示順序")]
        [Range(1, 100,ErrorMessage ="輸入的資料範圍須在1~100")]
        public int DisplayOrder { get; set; }

    }
}
