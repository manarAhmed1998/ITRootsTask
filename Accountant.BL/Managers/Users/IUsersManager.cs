using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public interface IUsersManager
{
    void Add(UserAddVM userToAdd);
    IEnumerable<UserReadVM> GetAll();
    UserReadVM map(UserAddVM user);


}
