﻿using AlgorithmsWebApp.Models;

namespace AlgorithmsWebApp.Data
{
    public class ResultsDisplayedToUser
    {
       public static List<ResultsModel> ResultsFromSession = new List<ResultsModel>();

        public static Dictionary<string, string> TextToUserDictionary = new Dictionary<string, string>(); 
    }
}
