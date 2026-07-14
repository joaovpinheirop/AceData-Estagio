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

        public decimal salarioBruto;
        public decimal salarioFamilia;
        public decimal salarioLiquido;

        public string message = "";

        public SalaryCalculatorController Salary = new();

        public void OnGet()
        {

        }

        public void OnPost()
        {

            if (Salary.VerifyCalc().status == true)
            {
                Salary.hourPay = hourPay;
                Salary.hourWork = hourWork;
                Salary.numberChildren = numberChildren;

                salarioBruto = Salary.CalcSalary();
                salarioFamilia = Salary.CalcSalaryFamily();
                salarioLiquido = Salary.CalcSalaryFinal();
            }
            else
            {
                salarioBruto = 0;
                salarioFamilia = 0;
                salarioLiquido = 0;
            }

            message = Salary.VerifyCalc().message;
        }
    }
}