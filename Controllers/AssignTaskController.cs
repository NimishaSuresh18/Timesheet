using AssignTask.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class AssignTaskController : ControllerBase{
    private readonly TaskContext _context;
    public AssignTaskController(TaskContext context)
    {
      _context=context;   
    }
    //GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assign>>> GetTasks(){
        return await _context.Assigns.ToListAsync();
    }
    [HttpGet("{TaskId}")]
    public async Task<ActionResult<Assign>> GetTasks(Guid TaskId){
        var tasks = await _context.Assigns.FindAsync(TaskId);
        if(tasks==null){
            return NotFound();
        }
        return tasks;
    }
    //PUT
    [HttpPut("{TasId}")]
    public async Task<IActionResult> PutTasks(Guid TaskId,Assign tasks){
        if(TaskId!=tasks.TaskId){
            return BadRequest();
        }
        _context.Entry(tasks).State=EntityState.Modified;
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException){
            if(!PutTasksExists(TaskId)){
                return NotFound();
            }
            else{
                throw;
            }
        }
        return NoContent();
    }
    private bool PutTasksExists(Guid TaskId){
        return _context.Assigns.Any(e=> e.TaskId==TaskId);
    }
    [HttpPost]
    //[ServiceFilter(typeof(ValidateFilterAttribute))]
    public async Task<ActionResult<Assign>> PostTasks(Assign tasks){
        if(tasks==null){
            return BadRequest("Data is null");
        }
        _context.Assigns.Add(tasks);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTasks",new{TaskId=tasks.TaskId},tasks);
    }
    [HttpDelete("{TaskId}")]
    public async Task<IActionResult> DeleteTasks(Guid TaskId){
        var tasks =  await _context.Assigns.FindAsync(TaskId);
        if(tasks==null){
            return NotFound();
        }
        _context.Assigns.Remove(tasks);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}