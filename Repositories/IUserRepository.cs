using Models;

namespace Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
