namespace testSibers.Controllers.Commands.Tasks.Validation;

public interface ITaskUpdateCommand
{
    public string Name { get; init; }
    
    public Guid CreatorId { get; init; }
    
    public Guid? AssigneeId { get; init; }
    
    public StatusType Status { get; init; }
    
    public string Comment { get; init; }
    
    public int Priority { get; init; }
    
    public int TaskProjectId { get; init; }
}