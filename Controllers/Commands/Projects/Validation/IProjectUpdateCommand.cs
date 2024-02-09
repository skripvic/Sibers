namespace testSibers.Controllers.Commands.Projects.Validation;

public interface IProjectUpdateCommand
{
    public string Name  { get; init; }
    
    public string ClientCompany { get; init; }
    
    public string ContractorCompany { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }

    public Guid ManagerId { get; init; }

    public int Priority { get; init; }
}