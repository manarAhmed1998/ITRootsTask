﻿using Accountant.DAL;
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
    User? getByUserName(string userName);
    User? getUserById(Guid id);
    void Delete(User userToDelete);
    UserEditVM mapToEdit(User userToUpdate);
    void Edit(UserEditVM user);


}
