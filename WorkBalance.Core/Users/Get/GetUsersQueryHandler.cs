using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Users.Get
{
    public class GetUsersQueryHandler : BaseRequestHandler<GetUsersQuery, BaseHandlerResult<UserModel[]>>
    {
        public GetUsersQueryHandler(AppDbContext db, ILogger<GetUsersQueryHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<UserModel[]>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var entities = await DbContext.Users.AsNoTracking().ToArrayAsync(cancellationToken);
            var users = entities.Select(UserModel.Create).ToArray();

            return SuccessResult(users);
        }
    }
}
