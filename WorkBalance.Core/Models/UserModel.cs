using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Models
{
    public class UserModel
    {
        private UserModel()
        {
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }

        public static UserModel Create(User user)
        {
            return new UserModel 
            { 
                Id = user.Id, 
                Name = user.Name 
            };
        }
    }
}
