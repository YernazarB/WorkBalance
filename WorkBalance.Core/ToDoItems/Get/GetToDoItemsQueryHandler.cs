using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.ToDoItems.Get
{
    public class GetToDoItemsQueryHandler : BaseRequestHandler<GetToDoItemsQuery, BaseHandlerResult<ToDoItemModel[]>>
    {
        public GetToDoItemsQueryHandler(AppDbContext db, ILogger<GetToDoItemsQueryHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<ToDoItemModel[]>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItemsQueryable = DbContext.ToDoItems.AsQueryable();

            if (request.IsCompleted.HasValue)
            {
                todoItemsQueryable = todoItemsQueryable.Where(x => x.IsCompleted == request.IsCompleted.Value);
            }

            if (request.PriorityId.HasValue)
            {
                todoItemsQueryable = todoItemsQueryable.Where(x => x.PriorityId == request.PriorityId.Value);
            }

            if (request.UserId.HasValue)
            {
                todoItemsQueryable = todoItemsQueryable.Where(x => x.UserId == request.UserId.Value);
            }

            var entities = await todoItemsQueryable.ToArrayAsync();
            var todoItems = entities.Select(ToDoItemModel.Create).ToArray();

            return SuccessResult(todoItems);
        }
    }
}
