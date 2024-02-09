using MediatR;
using Microsoft.EntityFrameworkCore;
using testSibers.Models;

namespace testSibers.Controllers.Queries.Users.GetUsersList;

//Получение списка всех сотрудников
public class GetUserListQuery : IRequest<ICollection<GetUserListDto>>
{
    public sealed class GetUsersListQueryHandler : IRequestHandler<GetUserListQuery, ICollection<GetUserListDto>>
    {
        private readonly ISystemDbContext _systemDbContext;

        public GetUsersListQueryHandler(ISystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<ICollection<GetUserListDto>> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {

            var users = await _systemDbContext
                .Users
                .Select(u => new GetUserListDto()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                })
                .ToListAsync(cancellationToken);

            return users;
        }

    }
}