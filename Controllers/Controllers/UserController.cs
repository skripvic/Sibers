using MediatR;
using Microsoft.AspNetCore.Mvc;
using testSibers.Controllers.Commands.Users.CreateUser;
using testSibers.Controllers.Commands.Users.DeleteUser;
using testSibers.Controllers.Commands.Users.UpdateUser;
using testSibers.Controllers.Queries.Users.GetUserInfo;
using testSibers.Controllers.Queries.Users.GetUsersList;

namespace testSibers.Controllers.Controllers;

//Контроллер для работы с сотрудниками
[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //Получение информации о сотруднике по ID
    [HttpGet("getUserInfo/{userId:guid}")]
    public Task<GetUserInfoResponse> GetUserInfo(Guid userId)
    {
        return _mediator.Send(new GetUserInfoQuery(userId), HttpContext.RequestAborted);
    } 
    
    //Получение списка всех сотрудников
    [HttpGet("getUserList")]
    public Task<ICollection<GetUserListDto>> GetUserList()
    {
        return _mediator.Send(new GetUserListQuery(), HttpContext.RequestAborted);
    }  
    
    //Команда для создания сотрудника
    [HttpPost("createUser")]
    public Task<CreateUserResponse> CreateUser(CreateUserCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }   
    
    //Команда для изменения данных сотрудника
    [HttpPut("updateUser")]
    public Task UpdateUser(UpdateUserCommand query)
    {
        return _mediator.Send(query, HttpContext.RequestAborted);
    }
    
    //Команда для удаления сотрудника
    [HttpDelete("deleteUser/{userId:guid}")]
    public Task DeleteUser(Guid userId)
    {
        return _mediator.Send(new DeleteUserCommand(userId), HttpContext.RequestAborted);
    }  
    
}