using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tms.Data;
using Tms.Domain;
namespace Tms.Models{
public class Join{
    public Assign? assigns{get;set;}
    public TaskEntries? taskEntries {get;set;}
    public UserActivity? userActivity{get;set;}
    public ApplicationUserRole? users {get;set;}
    
}
}