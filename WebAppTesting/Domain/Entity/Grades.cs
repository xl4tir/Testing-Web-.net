using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.Entity
{
    public class Grades
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public List<Testing> Testings { set; get; }
    }
}
