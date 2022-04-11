using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Name must be a maximum of 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [MinLength(10, ErrorMessage = "E-mail must be at least 10 characters.")]
        [MaxLength(180, ErrorMessage = "E-mail must be a maximum of 180 characters.")]
        [EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [MaxLength(100, ErrorMessage = "Password must be a maximum of 40 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
