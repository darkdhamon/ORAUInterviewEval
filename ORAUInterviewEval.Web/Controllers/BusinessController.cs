using Microsoft.AspNetCore.Mvc;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Infrastructure.ViewModels;

namespace ORAUInterviewEval.Web.Controllers
{
    public class BusinessController : Controller
    {
        private readonly ITaskService _taskService;
        
        public BusinessController(ITaskService taskService)
        {
            _taskService = taskService;
        }





        public IActionResult Task1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Task1(Task1ViewModel model)
        {            
            return View();
        }




        public IActionResult Task2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Task2(Task2ViewModel model)
        {
            return View();
        }




        public IActionResult Task3()
        {
            return View();
        }




        public IActionResult Task4()
        {
            return View();
        }





        public IActionResult Task5()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task5(Task5ViewModel model)
        {
            if(ModelState.IsValid)
            {
                _taskService.SaveProfile(model.Profile);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Task5NewContactPartial()
        {
            return PartialView("Task5ContactPartial");
        }




        public IActionResult Task6()
        {
            var model = new Task6ViewModel();
            model.Users = _taskService.GetUsers();
            return View(model);
        }


    }
}
