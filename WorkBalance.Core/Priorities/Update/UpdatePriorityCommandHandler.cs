using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkBalance.Core.Models;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Priorities.Update
{
    public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand, BaseHandlerResult<PriorityModel>>
    {
        private readonly AppDbContext _db;

        public UpdatePriorityCommandHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BaseHandlerResult<PriorityModel>> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _db.Priorities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (priority == null)
            {
                return BaseHandlerResult<PriorityModel>
                    .ErrorResult(HandlerErrorCode.NotFound, "Priority not found.");
            }

            priority.Level = request.Level;
            await _db.SaveChangesAsync(cancellationToken);

            return BaseHandlerResult<PriorityModel>
                .SuccessResult(PriorityModel.Create(priority));
        }
    }
}
