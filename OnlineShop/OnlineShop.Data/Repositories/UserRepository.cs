using OnlineShop.Data.AppDbContext;
using OnlineShop.Domain.Entitties.User;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    #region ctor
    private readonly OnlineShopDBContext _dbContext;
    public UserRepository (OnlineShopDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    #region General Methods
    public bool IsExistUserByMobile(string mobile)
    {
        var result = _dbContext.Users.Any(x => x.Mobile == mobile);
        return result;
    }
    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        SaveChange();
    }

    public void SaveChange()
    {
        _dbContext.SaveChanges();
    }
    #endregion
}
