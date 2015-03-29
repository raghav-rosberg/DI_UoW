using System.ComponentModel.DataAnnotations;

namespace DI_UoW.ViewModel
{
    public class AccountViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool Activated { get; set; }
        [Required]
        public string UserName { get; set; }

        public int RoleId { get; set; }

        public string EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockOutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        
    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}