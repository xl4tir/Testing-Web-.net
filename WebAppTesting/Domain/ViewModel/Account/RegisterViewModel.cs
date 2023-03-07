using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть логін")]
        [MaxLength(20, ErrorMessage = "Логін повинен мати менше 20 символів")]
        [MinLength(3, ErrorMessage = "Логін повинен мати більше 3 символів")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введіть пароль")]
        [MinLength(6, ErrorMessage = "Пароль повинен мати більше 6 символів")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string PasswordConfirm { get; set; }
    }
}
