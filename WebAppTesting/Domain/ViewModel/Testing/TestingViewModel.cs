using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.Testing
{
    public class TestingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string SubjectID { get; set; }
        public int GradeID { get; set; }
    }
}
