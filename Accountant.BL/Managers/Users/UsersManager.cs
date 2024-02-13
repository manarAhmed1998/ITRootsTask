using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class UsersManager:IUsersManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepo _usersRepo;

    public UsersManager(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
    {
        _unitOfWork = unitOfWork;
        _usersRepo = usersRepo;

    }
}
