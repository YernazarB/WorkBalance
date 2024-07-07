using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Users.Update
{
    public class UpdateUserCommandHandler : BaseRequestHandler<UpdateUserCommand, BaseHandlerResult<UserModel>>
    {
        public UpdateUserCommandHandler(AppDbContext db, ILogger<UpdateUserCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<UserModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                return ErrorResult<UserModel>(HandlerErrorCode.NotFound, "User not found");
            }

            user.Name = request.Name;
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(UserModel.Create(user));
        }
    }
}
