using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Enum;

namespace WebAppTesting.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }


        public List<Testing> Testing { set; get; }
        public Profile Profile { get; set; }
    }
}
