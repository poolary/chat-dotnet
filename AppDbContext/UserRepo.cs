using Backender.AppDbContext;
using Backender.Model;
using System.Linq;

namespace Backender.AppDbContext
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContexts _context;

        public UserRepo(AppDbContexts context)
        {
            _context = context;
        }

        public UserEntity GetByID(int id)
        {
            return _context.MessagesOfUsersChat
                .FirstOrDefault(u => u.IdSender == id);
        }

        public UserEntity GetByName(string name)
        {
            return _context.MessagesOfUsersChat
                .FirstOrDefault(u => u.Name_Message.Contains(name));
        }
    }
}