using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTesting.Domain.ViewModel.Profile;
using WebAppTesting.Service.Interfaces;
using WebAppTesting.ViewModels;

namespace WebAppTesting.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IProfileService _profileService;
        private readonly ITestingService _testingService;

        public ProfileController(IProfileService profileService, ITestingService testingService)
        {
            _profileService = profileService;

            _testingService = testingService;
        }

        public async Task<IActionResult> ProfileInfo()
        {

            ProfileInfoViewModel obj = new ProfileInfoViewModel();

            var userName = User.Identity.Name;

            var responseProfile = await _profileService.GetProfile(userName);
            var responseTestings = await _testingService.SelectAllTestingsByAuthor(responseProfile.Data.UserId);
            if (responseProfile.StatusCode == Domain.Enum.StatusCode.OK)
            {
                obj.Profile = responseProfile.Data;
                obj.Testings = responseTestings.Data;

                return View(obj);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProfileInfoViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var response = await _profileService.Save(obj.Profile);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }

                
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        public async Task<IActionResult> DeleteTesting(int testingId, int userId)
        {
            

            var response = await _testingService.DeleteTesting(userId, testingId);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("ProfileInfo");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
