using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Priorities.Get
{
    public class GetPrioritiesQueryHandler : BaseRequestHandler<GetPrioritiesQuery, BaseHandlerResult<PriorityModel[]>>
    {
        public GetPrioritiesQueryHandler(AppDbContext db, ILogger<GetPrioritiesQueryHandler> logger) : base(db, logger)
        {
        }

        public override async Task<BaseHandlerResult<PriorityModel[]>> Handle(GetPrioritiesQuery request, CancellationToken cancellationToken)
        {
            var entities = await DbContext.Priorities.AsNoTracking().ToArrayAsync(cancellationToken);
            var priorities = entities.Select(PriorityModel.Create).ToArray();

            return SuccessResult(priorities);
        }
    }
}
