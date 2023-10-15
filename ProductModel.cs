namespace WebApplication4.Models
{
    public class ProductModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int UserAge { get; set; }
        public string? UserAdress { get; set; }
        public int UserPhoneNumber { get; set; }
        public int UserQ { get; set; }
        public List<string>? SelectedPizzas { get; set; }

    }
}