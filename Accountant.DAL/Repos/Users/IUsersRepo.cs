using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public interface IUsersRepo:IGenericRepo<User>
{
    User? getByUserName(string userName);

}
