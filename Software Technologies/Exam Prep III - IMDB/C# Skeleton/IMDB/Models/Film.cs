using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IMDB.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public string Genre { get; set; }

        [Required]
        [AllowHtml]
        public string Director { get; set; }

        [Required]
        public int Year { get; set; }
    }
}