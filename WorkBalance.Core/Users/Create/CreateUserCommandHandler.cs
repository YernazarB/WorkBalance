using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;
using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Users.Create
{
    public class CreateUserCommandHandler : BaseRequestHandler<CreateUserCommand, BaseHandlerResult<UserModel>>
    {
        public CreateUserCommandHandler(AppDbContext db, ILogger<CreateUserCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<UserModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User { Name = request.Name };
            await DbContext.Users.AddAsync(newUser, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(UserModel.Create(newUser));
        }
    }
}
