using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.ToDoItems.AssignUser
{
    public class AssignUserCommandHandler : BaseRequestHandler<AssignUserCommand, BaseHandlerResult>
    {
        public AssignUserCommandHandler(AppDbContext db, ILogger<AssignUserCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult> Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await DbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.ToDoItemId, cancellationToken);
            if (toDoItem == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "ToDoItem not found.");
            }

            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "User not found.");
            }

            toDoItem.UserId = user.Id;
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult();
        }
    }
}
