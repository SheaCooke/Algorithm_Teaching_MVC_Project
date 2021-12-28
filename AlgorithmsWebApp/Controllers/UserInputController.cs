using Microsoft.AspNetCore.Mvc;
using AlgorithmsWebApp.Models;
using AlgorithmsWebApp.Data;

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
            /*if (ModelState.IsValid) model state was not evaluating to valid after collection and target value were added
            {*/
                
                return View(vm);
          /*  }
            return View("Index", vm);*/
        }

        [HttpPost]
        public IActionResult GenerateResponse(AlgorithmModels am)
        {
            
            //call RunAlgoBasedOnName, store in AlgoOutput var
            var AlgoOutput = am.SelectedAlgorithm switch
            {
                AlgorithmSelection.BinarySearch => Algorithms.BinarySearch(am.Collection, am.TargetValue),
                _ => 0
            };

            //call GetDescriptionAndLink, returns tuple of strings, store in (string,string) text

            //new ResponseModel(AlgoOutput, text.1, text.2)

            ResultsModel results = new ResultsModel(AlgoOutput.ToString(), "description", "link");

            //Add new ResponseModel to ResultsFromSession

            ResultsDisplayedToUser.ResultsFromSession.Add(results);

            return Redirect("Index");
        }




    }
}
