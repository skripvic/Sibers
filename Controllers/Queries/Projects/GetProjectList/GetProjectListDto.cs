namespace testSibers.Controllers.Queries.Projects.GetProjectList;

public class GetProjectListDto
{
    public int Id { get; init; }
    
    public string Name  { get; init; }
    
    public string ClientCompany { get; init; }
    
    public string ContractorCompany { get; init; }
    
    public DateTime StartDate { get; init; }
    
    public DateTime EndDate { get; init; }
    
    public int Priority { get; init; }
}