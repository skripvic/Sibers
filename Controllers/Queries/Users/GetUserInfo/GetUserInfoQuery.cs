using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Controllers.Exceptions;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Users.GetUserInfo;

//Получение информации о сотруднике по ID
public class GetUserInfoQuery : IRequest<GetUserInfoResponse>
{
    public GetUserInfoQuery(Guid userId)
    {
        UserId = userId;
    }

    private Guid UserId { get; init; }
    
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResponse>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetUserInfoQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _systemDbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user is null)
            {
                throw new EntityNotFoundException("Сотрудник не найден");
            }
            
            return new GetUserInfoResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                Roles = user.Roles.Select(r => r.Type).ToList()
            };
        }
    }
}