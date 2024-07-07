using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.ToDoItems.Update
{
    public class UpdateToDoItemCommandHandler : BaseRequestHandler<UpdateToDoItemCommand, BaseHandlerResult<ToDoItemModel>>
    {
        public UpdateToDoItemCommandHandler(AppDbContext db, ILogger<UpdateToDoItemCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<ToDoItemModel>> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await DbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (toDoItem == null)
            {
                return ErrorResult<ToDoItemModel>(HandlerErrorCode.NotFound, "ToDoItem not found.");
            }

            toDoItem.DueDate = request.DueDate;
            toDoItem.Description = request.Description;
            toDoItem.Title = request.Title;
            toDoItem.PriorityId = request.PriorityId;

            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(ToDoItemModel.Create(toDoItem));
        }
    }
}
