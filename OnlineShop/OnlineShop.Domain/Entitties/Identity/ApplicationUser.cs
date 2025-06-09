using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entitties;

public class ApplicationUser:IdentityUser<long>
{
    public string? FullName{ get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDelete { get; set; }
    public bool IsSuperAdmin { get; set; }
    public string? UserAvatar { get; set; }

}
