using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Enum;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Забыл ввести")]
        [Display(Name = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Забыл ввести")]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Забыл ввести")]
        [EmailAddress]
        [Display(Name = "Введите почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Забыл ввести")]
        [Display(Name = "Введите номер")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Выберете вашу поль")]
        public UserRoles UserRole { get; set; }
        public bool IsEnabled { get; set; }
    }
}
