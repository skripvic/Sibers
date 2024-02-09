namespace testSibers.Controllers.Queries.Projects.GetProjectInfo;

public class GetProjectInfoResponse
{
    public int Id { get; init; }
    
    public string Name  { get; init; }
    
    public string ClientCompany { get; init; }
    
    public string ContractorCompany { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }

    public string ManagerFirstName { get; init; }
    
    public string ManagerLastName { get; init; }

    public int Priority { get; init; }
}