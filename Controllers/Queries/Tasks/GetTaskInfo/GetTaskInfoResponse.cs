using testSibers.Models.EntityTypes;

namespace testSibers.Controllers.Queries.Tasks.GetTaskInfo;

public class GetTaskInfoResponse
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public string CreatorLastName { get; init; }
    
    public string CreatorFirstName { get; init; }
    
    public string? AssigneeLastName { get; init; }
    
    public string? AssigneeFirstName { get; init; }
    
    public StatusType Status { get; init; }
    
    public string Comment { get; init; }
    
    public int Priority { get; init; }
    
    public string TaskProjectName { get; init; }
}