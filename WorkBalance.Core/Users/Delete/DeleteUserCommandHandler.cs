using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Users.Delete
{
    public class DeleteUserCommandHandler : BaseRequestHandler<DeleteUserCommand, BaseHandlerResult>
    {
        public DeleteUserCommandHandler(AppDbContext db, ILogger<DeleteUserCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "User not found");
            }

            DbContext.Users.Remove(user);
            await DbContext.SaveChangesAsync();

            return SuccessResult();
        }
    }
}
