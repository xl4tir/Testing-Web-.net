using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.User
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "Роль")]
        public string Role { get; set; }

        [Display(Name = "Логін")]
        public string Name { get; set; }

        [Display(Name = "Вік")]
        public short Age { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
