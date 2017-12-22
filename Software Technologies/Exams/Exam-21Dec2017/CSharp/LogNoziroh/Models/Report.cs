using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LogNoziroh.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Message { get; set; }

        [Required]
        [AllowHtml]
        public string Status { get; set; }

        [Required]
        [AllowHtml]
        public string Origin { get; set; }
    }
}