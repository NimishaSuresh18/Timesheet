
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tms.Models{
public class RegistrationModel {
[Required(ErrorMessage = "Please enter your email address")]  
[DataType(DataType.EmailAddress)]  
[Display(Name = "Email")]  
[MaxLength(50)]  
[RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$", ErrorMessage = "Please enter correct email")] 
[EmailAddress]
public string? Email { get; set; }
[Required]
[DisplayName("Name")] 
[StringLength(100, MinimumLength = 3)]
[RegularExpression("^[A-Z]+[a-z]*$",ErrorMessage="Kindly Enter only Alphabet")]
public string? Name{get;set;}
[Required(ErrorMessage = "Please enter your username")]  
[DataType(DataType.EmailAddress)]  
[Display(Name = "Username")]  
[MaxLength(50)]  
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct username")] 
[EmailAddress]
public string? Username{get;set;}
[Required]
[DataType(DataType.Password)]
[RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",ErrorMessage = "Please enter correct password")] 
public string? Password { get; set; }
[Required]
[DataType(DataType.Password)]
[Display(Name ="Confirm Password")]
[Compare("Password",ErrorMessage ="Password and confirmation password not match.")]
public string? ConfirmPassword { get; set; }
[Required]
[DisplayName("Role")] 
[StringLength(100, MinimumLength = 2)]
[RegularExpression("^[a-zA-Z]{1,20}$",ErrorMessage="Kindly Enter only Alphabet")]
public string? Role{get;set;}
[Display(Name = "Phone:")]
[Required(ErrorMessage = "Phone Number is required.")]
[RegularExpression(@"^(0|91)?[6-9][0-9]{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
public string? Phone{get;set;}
[Required]
[DisplayName("Name")] 
[StringLength(100, MinimumLength = 2)]
[RegularExpression("^[a-zA-Z]{1,20}$",ErrorMessage="Kindly Enter only Alphabet")]
public string? hr{get;set;}
}
}