using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTOs.SiteSide.AuthDto
{
    public class AuthDTO
    {
    }
    public class AuthRegisterDto
    {

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "حداقل یک حرف انگلیسی داشته باشه|حداقل یک عدد هم داشته باشه|طولش حداقل 8 کاراکتر باشه")]
        [Required(ErrorMessage = "رمز عبورفراموش نشه ")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز وارد شده یکسان نیست")]
        public string Re_Password { get; set; }
    }
    public class AuthLoginDto
    {
        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]

        [DataType(DataType.Password)]
        public string password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class AuthResponseDto
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public AuthUserDto? User { get; set; }
    }

    public class AuthUserDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
