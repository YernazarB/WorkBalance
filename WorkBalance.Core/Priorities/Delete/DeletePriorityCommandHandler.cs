using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Priorities.Delete
{
    public class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand, BaseHandlerResult>
    {
        private readonly AppDbContext _db;

        public DeletePriorityCommandHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BaseHandlerResult> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _db.Priorities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (priority == null)
            {
                return BaseHandlerResult<PriorityModel>
                    .ErrorResult(HandlerErrorCode.NotFound, "Priority not found.");
            }

            _db.Priorities.Remove(priority);
            await _db.SaveChangesAsync(cancellationToken);

            return BaseHandlerResult.SuccessResult();
        }
    }
}
