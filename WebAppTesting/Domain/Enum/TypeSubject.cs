using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.Enum
{
    public enum TypeSubject
    {
        [Display(Name = "Алгебра")]
        Algebra = 0,
        [Display(Name = "Геометрія")]
        Geometry = 1,
        [Display(Name = "Географія")]
        Geography =2,
        [Display(Name = "Фізика")]
        Physics=3,
        [Display(Name = "Біологія")]
        Biology=4
    }
}
