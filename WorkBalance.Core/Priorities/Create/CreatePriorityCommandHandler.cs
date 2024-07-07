using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;
using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Priorities.Create
{
    public class CreatePriorityCommandHandler : BaseRequestHandler<CreatePriorityCommand, BaseHandlerResult<PriorityModel>>
    {
        public CreatePriorityCommandHandler(AppDbContext db, ILogger<CreatePriorityCommandHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<PriorityModel>> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = new Priority { Level = request.Level };

            await DbContext.AddAsync(priority, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return SuccessResult(PriorityModel.Create(priority));
        }
    }
}
