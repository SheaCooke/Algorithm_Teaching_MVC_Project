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
            //call parseCollection with am.collection, pass that new value into the algos 

            


            //call RunAlgoBasedOnName, store in AlgoOutput var
            var AlgoOutput = am.SelectedAlgorithm switch
            {
                AlgorithmSelection.BinarySearch => Algorithms.BinarySearch(Algorithms.ParseCollectionToArray(am.Collection), am.TargetValue),
                _ => 0
            };

            //call GetDescriptionAndLink, returns tuple of strings, store in (string,string) text



            /*var text = File.ReadLines("C:\\Users\\Shea Cooke\\Desktop\\AlgorithmWebApp\\AlgorithmsWebApp\\AlgorithmsWebApp\\AlgoInfo.txt")
               .Select((v, i) => new {Index = i, Value = v})
               .GroupBy(p => p.Index / 2)
               .ToDictionary(g => g.First().Value, g => g.Last().Value);*/

            

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

           




            //new ResponseModel(AlgoOutput, text.1, text.2)

            ResultsModel results = new ResultsModel(AlgoOutput.ToString(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchDescription"].Trim(), ResultsDisplayedToUser.TextToUserDictionary["BinarySearchLink"].Trim());

            //Add new ResponseModel to ResultsFromSession

            ResultsDisplayedToUser.ResultsFromSession.Add(results);

            return Redirect("Index");
        }




    }
}
