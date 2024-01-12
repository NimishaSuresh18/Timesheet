using System.ComponentModel.DataAnnotations;
namespace Tms.Models{
public class UserLogin {
[Required(ErrorMessage = "Please enter your username")]  
[DataType(DataType.EmailAddress)]  
[Display(Name = "Username")]  
[MaxLength(50)]  
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct username")] 
[EmailAddress]
public string? Username { get; set; }
[Required]
[DataType(DataType.Password)]
[RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",ErrorMessage = "Please enter correct password")] 
public string? Password { get; set; }
}
}