using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTesting.Domain.Enum;

namespace WebAppTesting.Domain.Entity
{
    public class Testing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int SubjectID { get; set; }
        public int GradeID { get; set; }
        public int NumberOfPasses { get; set; } = 0;



        public User User { get; set; }
        public Subjects Subject { get; set; }
        public Grades Grade { get; set; }
        public List<Tests> Tests { set; get; }
        
    }
}
