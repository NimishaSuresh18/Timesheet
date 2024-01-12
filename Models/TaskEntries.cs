using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tms.Domain;

namespace Tms.Models{
public class TaskEntries{
    [Key]    
    public Guid ProjectId{get;set;}
    [Required]
    [DisplayName("Projectname")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^[a-zA-Z]{1,20}$",ErrorMessage="Kindly Enter only Alphabet")]
    public string? Projectname {get;set;}
    [Required]
    [DisplayName("task")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$",ErrorMessage="Inavalid Task name")]
    public string? task{get;set;}
    [Required]
    [DisplayName("description")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^[a-zA-Z0-9-_ ]+$",ErrorMessage="Inavalid Task name")]
    public string? description{get;set;}
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Date{get;set;}=DateTime.Now;
    [Required]
    [DisplayName("Status")] 
    [StringLength(100, MinimumLength = 2)]
    [RegularExpression("^[a-zA-Z]{1,20}$",ErrorMessage="Kindly Enter only Alphabet")]
    public string? Status{get;set;}
 
}
  
}
