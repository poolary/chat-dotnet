using Backender.AppDbContext;
using Backender.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace Backender.Services
{
    public class ServicesUsers
    {
        private readonly IUserRepo _userRepo;

        public ServicesUsers(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        /*public List<UserEntity> GetUserMessage(string MessageName)
        {
        var user = _userRepo.GetByName(MessageName);
        return user.Select(u => new UserEntity { Name = u.Name }).ToList();
        }*/

    }
}
