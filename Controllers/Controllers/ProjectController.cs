using MediatR;
using Microsoft.AspNetCore.Mvc;
using testSibers.Controllers.Commands.Projects.AddUserToProject;
using testSibers.Controllers.Commands.Projects.CreateProject;
using testSibers.Controllers.Commands.Projects.DeleteProject;
using testSibers.Controllers.Commands.Projects.DeleteUserFromProject;
using testSibers.Controllers.Commands.Projects.UpdateProject;
using testSibers.Controllers.Queries.Projects.GetProjectInfo;
using testSibers.Controllers.Queries.Projects.GetProjectList;
using testSibers.Controllers.Queries.Projects.GetProjectUsers;
using testSibers.Controllers.Queries.Projects.GetProjectUsersList;

namespace testSibers.Controllers.Controllers;

//Контроллер для работы с проектами
[ApiController]
[Route("api/[controller]")]
public class ProjectController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //Получение информации о проекте по ID
    [HttpGet("getProjectInfo/{projectId:int}")]
    public Task<GetProjectInfoResponse> GetProjectInfo(int projectId)
    {
        return _mediator.Send(new GetProjectInfoQuery(projectId), HttpContext.RequestAborted);
    }
    
    //Получение списка сотрудников проекта
    [HttpGet("getProjectUsers/{projectId:int}")]
    public Task GetProjectUsers(int projectId)
    {
        return _mediator.Send(new GetProjectUsersQuery(projectId), HttpContext.RequestAborted);
    }
    
    //Получение списка всех проектов
    [HttpPost("getProjectList")]
    public Task<ICollection<GetProjectListDto>> GetProjectList(GetProjectListQuery query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для создания проекта
    [HttpPost("createProject")]
    public Task<CreateProjectResponse> CreateProject(CreateProjectCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для добавления сотрудника в проект
    [HttpPost("addUserToProject")]
    public Task AddUserToProject(AddUserToProjectCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    } 
    
    //Команда для изменения данных проекта
    [HttpPut("updateProject")]
    public Task UpdateProject(UpdateProjectCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }   
    
    //Команда для удаления проекта
    [HttpDelete("deleteProject/{projectId:int}")]
    public Task DeleteProject(int projectId)
    {
        return _mediator.Send(new DeleteProjectCommand(projectId), HttpContext.RequestAborted);
    }
    
    //Команда для удаления сотрудника из проекта
    [HttpDelete("deleteUserFromProject/projectId={projectId}&userId={userId}")]
    public Task DeleteUserFromProject(int projectId, Guid userId)
    {
        return _mediator.Send(new DeleteUserFromProjectCommand(projectId, userId), HttpContext.RequestAborted);
    } 
    

}