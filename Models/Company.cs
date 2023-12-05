using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
    }
}