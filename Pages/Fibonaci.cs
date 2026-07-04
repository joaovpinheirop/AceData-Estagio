using Calculo_de_salario.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculo_de_salario.Pages
{
    public class Fibonaci : PageModel
    {
        [BindProperty] public int numberCompareFibonaci { get; set; }
        [BindProperty] public int limitFibonaci { get; set; }

        public string message;
        public string sequence;

        public SequenceFibonacciController fibonacciController = new();

        public void OnGet() { }

        public void OnPost()
        {
            fibonacciController.SetLimiteFibonaci(limitFibonaci);
            message = fibonacciController.VerifyFibonacci(numberCompareFibonaci).message;
            sequence = fibonacciController.SequenceFibonacci();
        }
    }
}