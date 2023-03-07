using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;

namespace WebAppTesting.ViewModels
{
    public class GetTestingViewModel
    {
        public Testing Testing;

        public IEnumerable<Tests> Tests;

        public IEnumerable<Answers> Answers;
    }
}
