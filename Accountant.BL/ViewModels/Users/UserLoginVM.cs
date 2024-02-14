using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class UserLoginVM
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserType UserType { get; set; }
}
