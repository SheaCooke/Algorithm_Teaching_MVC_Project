namespace AlgorithmsWebApp.Models
{
    public class ResultsModel
    {
        public string ReturnedValue { get; set; }

        public string Explanation { get; set; }

        public string LinkToDocumentation { get; set; }

        public string InputCollection { get; set; }

        public string InputValue { get; set; }

        public ResultsModel(string returnedValue, string explanation, string linkToDocumentation, string inputCollection, string inputValue)
        {
            this.LinkToDocumentation = linkToDocumentation;
            this.ReturnedValue = returnedValue;
            this.Explanation = explanation;
            this.InputCollection = inputCollection;
            this.InputValue = inputValue;
        }
    }
}
