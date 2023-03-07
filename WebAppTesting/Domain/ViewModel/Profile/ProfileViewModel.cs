using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.Profile
{
    public class ProfileViewModel
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Вкажіть свій вік")]
        [Range(0, 150, ErrorMessage = "Діапазов віку повинен бути 0-100")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Вкажіть свою адресу")]
        [MinLength(5, ErrorMessage = "Мінімальна довжина адреси 5 символів")]
        [MaxLength(200, ErrorMessage = "Максимальна довжина адреси повинна бути не більше 200 символів")]
        public string Address { get; set; }

        

        

       
    }
}
