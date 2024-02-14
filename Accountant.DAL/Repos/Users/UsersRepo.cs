using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    private readonly AccountantContext _context;
    public UsersRepo(AccountantContext context) : base(context)
    {
        _context = context;
    }

    public User? getByUserName(string userName)
    {

        return _context.Users.FirstOrDefault(u => u.UserName == userName);
    }
   
}
