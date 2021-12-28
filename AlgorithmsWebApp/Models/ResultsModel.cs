namespace AlgorithmsWebApp.Models
{
    public class ResultsModel
    {
        public string ReturnedValue { get; set; }

        public string Explanation { get; set; }

        public string LinkToDocumentation { get; set; }

        public ResultsModel(string returnedValue, string explanation, string linkToDocumentation)
        {
            this.LinkToDocumentation = linkToDocumentation;
            this.ReturnedValue = returnedValue;
            this.Explanation = explanation;
        }
    }
}
