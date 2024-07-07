using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Priorities.Update
{
    public class UpdatePriorityCommandHandler : BaseRequestHandler<UpdatePriorityCommand, BaseHandlerResult<PriorityModel>>
    {
        public UpdatePriorityCommandHandler(AppDbContext db, ILogger<UpdatePriorityCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<PriorityModel>> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await DbContext.Priorities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (priority == null)
            {
                return BaseHandlerResult<PriorityModel>
                    .ErrorResult(HandlerErrorCode.NotFound, "Priority not found.");
            }

            priority.Level = request.Level;
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(PriorityModel.Create(priority));
        }
    }
}
