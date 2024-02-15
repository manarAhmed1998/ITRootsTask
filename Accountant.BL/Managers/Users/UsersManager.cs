using Accountant.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class UsersManager : IUsersManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepo _usersRepo;

    public UsersManager(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
    {
        _unitOfWork = unitOfWork;
        _usersRepo = usersRepo;

    }

    public void Add(UserAddVM userToAdd)
    {
        User user = new User()
        {
            Id=Guid.NewGuid(),
            FullName = userToAdd.FullName,
            UserName = userToAdd.UserName,
            Password = userToAdd.Password,
            Phone = userToAdd.Phone,
            Email = userToAdd.Email
        };
        // add admin if there is no users
        if (_usersRepo.GetAll()==null)
        {
            user.UserType = UserType.Admin;
        }
        else user.UserType = UserType.User;
        _usersRepo.Add(user);
        _unitOfWork.Save();
        
    }

    public void Delete(User userToDelete)
    {
        _unitOfWork.UsersRepo.Delete(userToDelete);
        _unitOfWork.Save();
    }

    public void Edit(UserEditVM user)
    {
        User? userToEdit=_usersRepo.GetById(user.Id);
        userToEdit.UserName = user.UserName;
        userToEdit.Password = user.Password;
        userToEdit.Phone = user.Phone;
        userToEdit.Email = user.Email;
        _unitOfWork.Save();
    }

    public IEnumerable<UserReadVM> GetAll()
    {
        var usersFromDB= _usersRepo.GetAll();
        IEnumerable<UserReadVM> userReadVMs = usersFromDB
            .Select(u => new UserReadVM
            {
                Id = u.Id,
                FullName = u.FullName,
                UserName = u.UserName,
                Phone = u.Phone,
                Email = u.Email,
            });
        return userReadVMs;
    }

    public User? getByUserName(string userName)
    {
        return _usersRepo.getByUserName(userName);
    }

    public User? getUserById(Guid id)
    {
        return _unitOfWork.UsersRepo.GetById(id);
    }

    public UserReadVM map(UserAddVM user)
    {
        UserReadVM userReadVM = new UserReadVM()
        {
            FullName=user.FullName,
            UserName=user.UserName,
            Phone = user.Phone,
            Email = user.Email
        };
        return userReadVM;
    }

    public UserEditVM mapToEdit(User userToUpdate)
    {
        UserEditVM userEditVM = new UserEditVM()
        {
            FullName = userToUpdate.FullName,
            UserName = userToUpdate.UserName,
            Phone = userToUpdate.Phone,
            Email = userToUpdate.Email,
            Password = userToUpdate.Password
        };
        return userEditVM;
        }
}
