namespace Calculo_de_salario.Controller
{
    public class SalaryCalculatorController
    {
        public decimal hourPay { private get; set; }
        public decimal hourWork { private get; set; }
        public int numberChildren { private get; set; }

        public decimal CalcSalary() => hourPay * hourWork;

        public decimal CalcSalaryFamily()
        {
            decimal salary = CalcSalary();
            decimal salaryFamily = 0;

            if (salary <= 788) salaryFamily = 30.50m * numberChildren;
            if (salary > 788 && salary <= 1100) salaryFamily = 18.50m * numberChildren;
            if (salary > 1100) salaryFamily = 11.90m * numberChildren;

            return salaryFamily;
        }

        public decimal CalcSalaryFinal()
        {
            decimal salaryFinal = CalcSalary() + CalcSalaryFamily();
            return salaryFinal;
        }

        public (bool status, string message) VerifyCalc()
        {
            if (hourPay == null)
            {
                return (false, "Preencha o campo de salario hora");
            }

            if (hourWork == null)
            {
                return (false, "Preencha o campo de horas trabalhadas");
            }

            if (hourPay.ToString().Any(n => n.ToString().Any(char.IsLetter)))
            {
                return (false, "Não coloque letras nos campos");
            }

            if (hourWork.ToString().Any(n => n.ToString().Any(char.IsLetter)))
            {
                return (false, "Não coloque letras nos campos");
            }

            if (hourPay < 0)
            {
                return (false, "Salario Hora não pode ser negativo");
            }
            return (true, "");

        }

    }
}