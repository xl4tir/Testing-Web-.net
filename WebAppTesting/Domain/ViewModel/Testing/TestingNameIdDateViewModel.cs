using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.ViewModel.Testing
{
    public class TestingNameIdDateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public long UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
