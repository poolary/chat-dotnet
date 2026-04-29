using Backender.Model;

namespace Backender.AppDbContext
{
    public interface IUserRepo
    {
        UserEntity GetByID(int id);
        UserEntity GetByName(string name);

    }
}
