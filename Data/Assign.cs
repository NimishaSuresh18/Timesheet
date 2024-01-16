using System.ComponentModel.DataAnnotations;

namespace AssignTask.Data{
public class Assign{
    [Key]
    public Guid TaskId{get;set;}
    public string? Task{get;set;}
    public string? description {get;set;}
    public string? Assignedto {get;set;}
    public DateTime Assigneddate {get;set;}
    public DateTime Duedate {get;set;}
   
}
}