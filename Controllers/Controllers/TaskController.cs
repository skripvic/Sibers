using MediatR;
using Microsoft.AspNetCore.Mvc;
using testSibers.Controllers.Commands.Tasks.AddAssignee;
using testSibers.Controllers.Commands.Tasks.ChangeAssignee;
using testSibers.Controllers.Commands.Tasks.CreateTask;
using testSibers.Controllers.Commands.Tasks.DeleteTask;
using testSibers.Controllers.Commands.Tasks.UpdateTask;
using testSibers.Controllers.Queries.Tasks.GetTaskInfo;
using testSibers.Controllers.Queries.Tasks.GetTaskList;

namespace testSibers.Controllers.Controllers;

//Контроллер для работы с задачами
[ApiController]
[Route("api/[controller]")]
public class TaskController: ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //Получение информации о задаче по ID
    [HttpGet("getTaskInfo/{taskId:int}")]
    public Task<GetTaskInfoResponse> GetTaskInfo(int taskId)
    {
        return _mediator.Send(new GetTaskInfoQuery(taskId), HttpContext.RequestAborted);
    }
        
    //Получение списка всех задач
    [HttpPost("getTaskList")]
    public Task<ICollection<GetTaskListDto>> GetTaskList(GetTaskListQuery query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
      
    //Команда для создания задачи
    [HttpPost("createTask")]
    public Task<CreateTaskResponse> CreateTask(CreateTaskCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для добавления исполнителя задания
    [HttpPost("addAssignee")]
    public Task AddAssignee(AddAssigneeCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для изменения исполнителя проекта
    [HttpPost("changeAssignee")]
    public Task ChangeAssignee(ChangeAssigneeCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для изменения информации задачи
    [HttpPut("updateTask")]
    public Task UpdateTask(UpdateTaskCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для удаления задачи
    [HttpDelete("deleteTask/{taskId:int}")]
    public Task DeleteTask(int taskId)
    {
        return _mediator.Send(new DeleteTaskCommand(taskId), HttpContext.RequestAborted);
    }
    
}