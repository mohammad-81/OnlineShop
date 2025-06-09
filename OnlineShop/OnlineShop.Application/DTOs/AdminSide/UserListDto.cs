using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTOs.AdminSide;

public class UserListDto
{

    public long Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FullName { get; set; }
    public DateTime CreatedDate { get; set; } 
    public bool IsDelete { get; set; }
    public string? UserAvatar { get; set; }

    public IEnumerable<string> Roles { get; set; } = new List<string>();
}
