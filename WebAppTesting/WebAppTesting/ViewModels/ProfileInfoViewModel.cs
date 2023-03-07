using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.ViewModel.Profile;
using WebAppTesting.Domain.ViewModel.Testing;

namespace WebAppTesting.ViewModels
{
    public class ProfileInfoViewModel
    {

        public ProfileViewModel Profile;
        public IEnumerable<TestingNameIdDateViewModel> Testings;

    }
}
