using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tms.Domain;
namespace Tms.Models{
public class Profile{
    [Key]
    public Guid Id{get;set;}
    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile? ImageFile{get; set ;}
    //public string? ProfilePicture {get;set;}
    public string? Address{get;set;}
    public DateTime Dob{get;set;}

}}