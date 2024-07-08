using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;
using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.ToDoItems.Create
{
    public class CreateToDoItemCommandHandler : BaseRequestHandler<CreateToDoItemCommand, BaseHandlerResult<ToDoItemModel>>
    {
        public CreateToDoItemCommandHandler(AppDbContext db, ILogger<CreateToDoItemCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<ToDoItemModel>> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var priority = await DbContext.Priorities.FirstOrDefaultAsync(x => x.Id == request.PriorityId, cancellationToken);
            if (priority == null) 
            {
                return ErrorResult<ToDoItemModel>(HandlerErrorCode.NotFound, "Priority not found");
            }

            var newToDoItem = new ToDoItem
            {
                Description = request.Description,
                DueDate = request.DueDate,
                PriorityId = request.PriorityId,
                Title = request.Title
            };

            await DbContext.ToDoItems.AddAsync(newToDoItem, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(ToDoItemModel.Create(newToDoItem));
        }
    }
}
