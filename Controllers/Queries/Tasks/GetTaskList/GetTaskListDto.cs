
namespace testSibers.Controllers.Queries.Tasks.GetTaskList;

public class GetTaskListDto
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public StatusType Status { get; init; }
    
    public int Priority { get; init; }
}