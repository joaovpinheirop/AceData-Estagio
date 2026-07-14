using Calculo_de_salario.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculo_de_salario.Pages
{
    public class NumberSequenci : PageModel
    {

        [BindProperty] public int numberRepetition { get; set; }
        [BindProperty] public string number { get; set; }
        [BindProperty] public bool suceess { get; set; }


        public List<float> n = new();
        public SequenceAnalyzerController sequenceAnalyzer = new();

        public float maior = 0;
        public float menor = 0;
        public float segundoMaior = 0;
        public string sequence;
        public string errorMensagem = "";

        public void OnGet() { }

        public void OnPostTestar()
        {
            sequenceAnalyzer.numberRepetition = numberRepetition;

            var status = sequenceAnalyzer.ValidateSequence(number).status;
            var error = sequenceAnalyzer.ValidateSequence(number).error;

            if (status)
            {
                List<float> numbers = sequenceAnalyzer.ExtractionSequence(number);

                sequence = sequenceAnalyzer.JoinText(numbers);

                menor = sequenceAnalyzer.ExtractExtremes(numbers).menor;
                maior = sequenceAnalyzer.ExtractExtremes(numbers).maior;
                segundoMaior = sequenceAnalyzer.ExtractExtremes(numbers).segundoMaior;
            }
            else if (!status)
            {
                errorMensagem = error;
            }

        }
    }
}