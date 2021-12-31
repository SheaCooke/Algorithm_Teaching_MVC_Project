

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AlgorithmsWebApp.Models
{
    public class AlgorithmModels

    {
        [Required(ErrorMessage = "Must select an algorithm.")]
        public AlgorithmSelection SelectedAlgorithm { get; set; }

        [Required(ErrorMessage = "Must select an algorithm.")]
        public List<SelectListItem> AlgorithmList = new List<SelectListItem>
        {
            new SelectListItem(AlgorithmSelection.BinarySearch.ToString(), ((int)AlgorithmSelection.BinarySearch).ToString()),
            new SelectListItem(AlgorithmSelection.InsertingSinglyLinkedList.ToString(), ((int)AlgorithmSelection.InsertingSinglyLinkedList).ToString())

        };

        
        public string? Collection { get; set; }

        public int TargetValue { get; set; }
    }
}
