using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tms.Data;
using Tms.Models;

public class TaskEntriesController : Controller{
 
private readonly TaskContext _dbcontext;
 public TaskEntriesController(TaskContext dbcontext)
 {
    _dbcontext=dbcontext;
 }
 public ActionResult Status(string? search,string? search1){
             
      var  assigns =  _dbcontext.Assign.ToList();  
            using(TaskContext db = new TaskContext()){
            List<TaskEntries> entries = _dbcontext.TaskEntry.ToList() ;        
            List<Assign> assign = _dbcontext.Assign.ToList();
            var  joins = from e in entries
            join d in assign on e.description equals d.description into table1 from d in table1.ToList()
                select new Join{
                taskEntries = e,
                assigns=d
            };
             return View(joins);
             }

            }
        

 [HttpGet]
        public ActionResult TaskEntries(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TaskEntries(TaskEntries create)
        {
            var task = new TaskEntries(){
                ProjectId = create.ProjectId,
                Projectname=create.Projectname,
                task=create.task,
                description=create.description,
                Date=create.Date,
                Status=create.Status="Pending"
            };
                 await _dbcontext.TaskEntry.AddAsync(task);
                    await _dbcontext.SaveChangesAsync();
                    return RedirectToAction(nameof(TaskEntries));           
              }
 
         public IActionResult TaskReport(Guid ProjectId)
        {
            var request = _dbcontext.TaskEntry.ToList();           
            IEnumerable<TaskEntries> task = from e in request where e.Status=="Pending" select e;
            return View(request);
        }
        public IActionResult Approve( Guid ProjectId){
            var request = _dbcontext.TaskEntry.Find(ProjectId);
            if(request!=null){
            request.Status="Approved";
            _dbcontext.TaskEntry.Update(request);
            _dbcontext.SaveChanges();
          return RedirectToAction("TaskReport","TaskEntries");

            }       
      return RedirectToAction("TaskReport","TaskEntries");
        }
        public ActionResult Reject(Guid ProjectId){
        var reject = _dbcontext.TaskEntry.Find(ProjectId);
        if (reject != null){
          reject.Status="Rejected";
          _dbcontext.TaskEntry.Update(reject);
          _dbcontext.SaveChanges();
          return RedirectToAction("TaskReport","TaskEntries");
        }
        return RedirectToAction("TaskReport","TaskEntries");
        }
 
    public ActionResult Delete(Guid? id)
        {
            if(id==null){
                return NotFound();
            }
            var employee = _dbcontext.TaskEntry.SingleOrDefault(u=>u.ProjectId==id);
            if(employee!=null){
                _dbcontext.TaskEntry.Remove(employee);
                _dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>AssignTask(){
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =(sender,cert,chain,sslPolicyErrors)=>{
                return true;
                };
                using (var client = new HttpClient(clientHandler)){
                    var response = await client.GetAsync("https://localhost:7189/api/AssignTask");
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Assign>>(json);
                    return View(data);
                }
        }
        public ActionResult OverallTask(){
            using(TaskContext db = new TaskContext()){
                 List<TaskEntries> entries = _dbcontext.TaskEntry.ToList() ;        
             List<Assign> assign = _dbcontext.Assign.ToList();
            var  joins = from e in entries
            join d in assign on e.description equals d.description into table1 from d in table1.ToList()
                select new Join{
                taskEntries = e,
                assigns=d
            };
            return View(joins);
            }                
        } 
         

        } 
     