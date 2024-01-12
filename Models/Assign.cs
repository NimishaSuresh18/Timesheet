using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tms.Models{
public class Assign{
   
    [Key]
    public Guid TaskId{get;set;}
    [Required]
    [DisplayName("task")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$",ErrorMessage="Inavalid Task name")]
    public string? Task{get;set;}
    [Required]
    [DisplayName("description")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^[a-zA-Z0-9-_ ]+$",ErrorMessage="Inavalid Task name")]
    public string? description {get;set;}
    [Required(ErrorMessage = "Please fill the field")]  
    [DataType(DataType.EmailAddress)]  
    [Display(Name = "Assignedto")]  
    [MaxLength(50)]  
    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct username")] 
    [EmailAddress]
    public string? Assignedto {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Assigneddate {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Duedate {get;set;}
}
}