using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Models
{
    public class PriorityModel
    {
        private PriorityModel()
        {
        }

        public int Id { get; private set; }
        public int Level { get; private set; }

        public static PriorityModel Create(Priority priority)
        {
            return new PriorityModel
            {
                Id = priority.Id,
                Level = priority.Level
            };
        }
    }
}
