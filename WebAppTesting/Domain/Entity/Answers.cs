using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.Entity
{
    public class Answers
    {
        public int id { set; get; }
        public int testID { set; get; }
        public string answer { get; set; }
        public bool isTrue { get; set; }

        public Tests Test { get; set; }


    }
}
