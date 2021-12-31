using Microsoft.AspNetCore.Mvc;
using AlgorithmsWebApp.Models;
using AlgorithmsWebApp.Data;
using Newtonsoft.Json;
using System.IO;


namespace AlgorithmsWebApp.Controllers
{
    public class UserInputController : Controller
    {
        public UserInputController()
        {
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
        }
        public IActionResult Index()
        {
            var vm = new AlgorithmModels();

            return View(vm);
        }



        [HttpPost]
        public IActionResult AlgorithmSelected(AlgorithmModels vm)
        {
      
           return View(vm);
        }

        [HttpPost]
        public IActionResult GenerateResponse(AlgorithmModels am)
        {
           
            var AlgoOutput = am.SelectedAlgorithm switch
            {
                AlgorithmSelection.BinarySearch => Algorithms.BinarySearch(Algorithms.ParseToIntArray(am.Collection), am.TargetValue),
                _ => 0
            };

       
            ResultsModel results = new ResultsModel(AlgoOutput.ToString(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchDescription"].Trim(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchLink"].Trim(), am.Collection, am.TargetValue.ToString());


            ResultsDisplayedToUser.ResultsFromSession.Add(results);

            
            return View("index", am);
        }




    }
}
