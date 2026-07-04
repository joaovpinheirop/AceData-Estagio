using Calculo_de_salario.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculo_de_salario.Pages
{
    public class SalaryCalculator : PageModel
    {
        [BindProperty] public decimal hourPay { get; set; }
        [BindProperty] public decimal hourWork { get; set; }
        [BindProperty] public int numberChildren { get; set; }

        public string message = "";

        public SalaryCalculatorController Salary = new();

        public void OnPost() // Chamado quando você clica em "Adicionar"
        {
            Salary.hourPay = hourPay;
            Salary.hourWork = hourWork;
            Salary.numberChildren = numberChildren;

            message = Salary.VerifyCalc().message;
        }
    }
}