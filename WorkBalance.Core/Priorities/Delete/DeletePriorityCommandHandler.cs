using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Priorities.Delete
{
    public class DeletePriorityCommandHandler : BaseRequestHandler<DeletePriorityCommand, BaseHandlerResult>
    {
        public DeletePriorityCommandHandler(AppDbContext db, ILogger<DeletePriorityCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await DbContext.Priorities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (priority == null)
            {
                return ErrorResult(HandlerErrorCode.NotFound, "Priority not found.");
            }

            DbContext.Priorities.Remove(priority);
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult();
        }
    }
}
