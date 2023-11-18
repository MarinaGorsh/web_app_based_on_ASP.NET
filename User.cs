using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User
    {
        [Required(ErrorMessage = "Не вказано ім'я")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Не вказана електронна адреса")]
        public string UserEmail { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Product { get; set; }
    }
}
