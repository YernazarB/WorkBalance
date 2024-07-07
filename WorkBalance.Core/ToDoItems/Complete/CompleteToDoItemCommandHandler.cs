using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.ToDoItems.Complete
{
    public class CompleteToDoItemCommandHandler : BaseRequestHandler<CompleteToDoItemCommand, BaseHandlerResult>
    {
        public CompleteToDoItemCommandHandler(AppDbContext db, ILogger<CompleteToDoItemCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult> Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await DbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (toDoItem == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "ToDoItem not found.");
            }

            toDoItem.IsCompleted = true;
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult();
        }
    }
}
