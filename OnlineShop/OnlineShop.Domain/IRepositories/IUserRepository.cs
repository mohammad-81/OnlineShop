using OnlineShop.Domain.Entitties.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories;

public interface IUserRepository
{

    bool IsExistUserByMobile(string mobile);
    void AddUser(User user);
    void SaveChange();

}
