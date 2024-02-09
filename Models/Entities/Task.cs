using testSibers.Models.EntityTypes;

namespace testSibers.Models.Entities;

//Сущность задача
public class Task
{
    //ID задачи
    public int Id { get; private set; }
    
    //Название задачи
    public string Name { get; private set; }
    
    //Создатель задачи
    public User Creator { get; private set; }
    
    //Исполнитель задачи
    public User? Assignee { get; private set; }
    
    //Статус задачи
    public StatusType Status { get; private set; }
    
    //Комментарий
    public string Comment { get; private set; }
    
    //Приоритет задачи
    public int Priority { get; private set; }
    
    //Проект, к которому привязана задача
    public Project TaskProject { get; private set; }

    public Task() { }

    public Task(string name, User creator, User? assignee, StatusType status, string comment, int priority, Project taskProject)
    {
        Name = name;
        Creator = creator;
        Assignee = assignee;
        Status = status;
        Comment = comment;
        Priority = priority;
        TaskProject = taskProject;
    }
    
    public void UpdateTask(string name, User creator, User? assignee, StatusType status, string comment, int priority, Project taskProject)
    {
        Name = name;
        Creator = creator;
        Assignee = assignee;
        Status = status;
        Comment = comment;
        Priority = priority;
        TaskProject = taskProject;
    }

    public void UpdateAssignee(User assignee)
    {
        Assignee = assignee;
    }
}