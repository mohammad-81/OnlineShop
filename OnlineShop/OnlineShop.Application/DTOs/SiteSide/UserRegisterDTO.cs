using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTOs.SiteSide;

public class UserRegisterDTO
{
    public string Mobile{ get; set; }


    [DataType(DataType.Password)]
    public string Password { get; set; }


    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "رمز وارد شده یکسان نیست")]
    public string Re_Password { get; set; }


    [Required(ErrorMessage = "لطفا قوانین سایت رو تایید کنید")]
    public bool AcceptTerms { get; set; }
}
