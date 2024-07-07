using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.ToDoItems.Delete
{
    public class DeleteToDoItemCommandHandler : BaseRequestHandler<DeleteToDoItemCommand, BaseHandlerResult>
    {
        public DeleteToDoItemCommandHandler(AppDbContext db, ILogger<DeleteToDoItemCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await DbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (toDoItem == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "ToDoItem not found.");
            }

            DbContext.ToDoItems.Remove(toDoItem);
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult();
        }
    }
}
