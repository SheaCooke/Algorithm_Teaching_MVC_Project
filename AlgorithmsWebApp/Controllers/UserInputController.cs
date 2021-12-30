using Microsoft.AspNetCore.Mvc;
using AlgorithmsWebApp.Models;
using AlgorithmsWebApp.Data;
using Newtonsoft.Json;
using System.IO;


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
           
            var AlgoOutput = am.SelectedAlgorithm switch
            {
                AlgorithmSelection.BinarySearch => Algorithms.BinarySearch(Algorithms.ParseCollectionToArray(am.Collection), am.TargetValue),
                _ => 0
            };

            

            using (var sr = new StreamReader("AlgoInfo.txt"))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!ResultsDisplayedToUser.TextToUserDictionary.ContainsKey(line))
                    {
                        ResultsDisplayedToUser.TextToUserDictionary.Add(line, sr.ReadLine());
                    }
                    
                }
            }

       

            ResultsModel results = new ResultsModel(AlgoOutput.ToString(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchDescription"].Trim(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchLink"].Trim());


            ResultsDisplayedToUser.ResultsFromSession.Add(results);

            return Redirect("Index");
        }




    }
}
