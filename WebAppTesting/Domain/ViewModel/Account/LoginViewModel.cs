using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть логін")]
        [MaxLength(20, ErrorMessage = "Логін повивен мати менше 20-ти символів")]
        [MinLength(3, ErrorMessage = "Логін повинен мати більше 3-х символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
