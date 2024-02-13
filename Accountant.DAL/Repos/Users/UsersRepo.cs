using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    public UsersRepo(AccountantContext context) : base(context)
    {
    }
}
