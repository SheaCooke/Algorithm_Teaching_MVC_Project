using Microsoft.AspNetCore.Mvc;
using AlgorithmsWebApp.Models;

namespace AlgorithmsWebApp.Controllers
{
    public class UserInputController : Controller
    {
        public IActionResult Index()
        {
            var vm = new AlgorithmModels();

            return View(vm);
        }



        [HttpPost]
        public IActionResult AlgorithmSelected(AlgorithmModels vm)
        {
            if (ModelState.IsValid)
            {
                /*if (vm.AlgorithmList.Equals(AlgorithmSelection.BinarySearch))
                {

                }*/
                return View(vm);
            }
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult GenerateResponse()
        {
            return Redirect("Index");
        }


    }
}
