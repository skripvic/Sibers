namespace testSibers.Models.Entities;

//Сушность проекта
public class Project
{
    //ID проекта
    public int Id { get; private set; }
    
    //Название проекта
    public string Name  { get; private set; }
    
    //Название компании-заказчика
    public string ClientCompany { get; private set; }
    
    //Название компании-исполнителя
    public string ContractorCompany { get; private set; }
    
    //Дата начала проекта
    public DateTime StartDate { get; private set; }
    
    //Дата конца проекта
    public DateTime EndDate { get; private set; }

    //Менеджер проекта
    public User Manager { get; private set; }

    //Приоритет проекта
    public int Priority { get; private set; }

    //Список сотрутников на проекте
    public IList<User> Users { get; private set; } = new List<User>();

    //Конструктор для EF
    public Project () {} 
    
    public Project(string name, string clientCompany, string contractorCompany, DateTime startDate, DateTime endDate, User manager, int priority)
    {
        Name = name;
        ClientCompany = clientCompany;
        ContractorCompany = contractorCompany;
        StartDate = startDate;
        EndDate = endDate;
        Manager = manager;
        Priority = priority;
    }

    public void UpdateProject(
        string name, 
        string clientCompany, 
        string contractorCompany, 
        DateTime startDate,
        DateTime endDate, 
        User manager, 
        int priority)
    {
        Name = name;
        ClientCompany = clientCompany;
        ContractorCompany = contractorCompany;
        StartDate = startDate;
        EndDate = endDate;
        Manager = manager;
        Priority = priority;
    }
    
}