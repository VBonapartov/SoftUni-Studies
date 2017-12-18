using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingList.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [AllowHtml]
        public string Status { get; set; }
    }
}