using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTesting.DAL.Interfaces;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.ViewModel.Testing;
using WebAppTesting.Service.Interfaces;
using WebAppTesting.ViewModels;

namespace WebAppTesting.Controllers
{
    public class TestingController : Controller
    {


        private readonly ITestingService _testingService;
        private readonly ITestsService _testsService;
        private readonly IAnswersService _answersService;

        public TestingController(ITestingService testingService, ITestsService testsService, IAnswersService answersService)
        {
            _testingService = testingService;
            _testsService = testsService;
            _answersService = answersService;
        }


        [HttpGet]
        public async Task<IActionResult> GetTestings()
        {

            var response = await _testingService.GetTestingWithIncludeUser();

            

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }


        [HttpGet] 
        public async Task<IActionResult> GetTesting(int id)
        {

            GetTestingViewModel obj = new GetTestingViewModel();
            var response = await _testingService.GetTesting(id);
            var response2 = _testsService.GetTestsByTestingId(id);
            var response3 = _answersService.GetAnswersByIdTestings(id);


            if (response.StatusCode == Domain.Enum.StatusCode.OK && response2.StatusCode == Domain.Enum.StatusCode.OK && response3.StatusCode == Domain.Enum.StatusCode.OK)
            {
                obj.Testing = response.Data;
                obj.Tests = response2.Data;
                obj.Answers = response3.Data;
                return View(obj);
            }
            return RedirectToAction("Error");

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _testingService.DeleteTesting(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }


        [HttpGet]
        public async Task<IActionResult> CreateTesting(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _testingService.GetTesting(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTesting(TestingViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    await _testingService.CreateTesting(model);
                }
                else
                {
                    await _testingService.Edit(model.Id, model);
                }
            }

            return RedirectToAction("GetTestings");
        }


    }
}
