using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class UserEditVM
{
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$",
    ErrorMessage = "Password must contain at least one uppercase letter and one lowercase letter")]
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }
}
