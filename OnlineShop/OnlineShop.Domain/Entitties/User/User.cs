using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entitties.User;

public class User
{
    #region Properties
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDelete { get; set; }
    #endregion

    #region Navigation properties

    #endregion

}