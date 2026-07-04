namespace Calculo_de_salario.Controller
{
    public class SequenceFibonacciController

    {
        public int limitFibonaci { get; set; }
        public List<int> sequence = new();

        // Verificar se o numero é ou não parte da sequencia Fibonaci
        public (bool status, string message) VerifyFibonacci(int number)
        {
            var eq1 = 5 * (Math.Pow(number, 2)) - 4;
            var eq2 = 5 * Math.Pow(number, 2) + 4;

            if (Math.Sqrt(eq1) % 1 == 0 || Math.Sqrt(eq2) % 1 == 0)
            {
                return (true, $" O numero {number} faz parte da sequencia Fibonaci");
            }
            return (false, $"O numero {number} não faz parte da sequencia Fibonaci");
        }

        // Criar sequencia Fibonaci
        public string SequenceFibonacci()
        {
            int previus = 0;
            int current = 1;

            for (int i = 0; i < limitFibonaci; i++)
            {
                int proximo = previus + current;
                AddNumberInSequence(proximo);
                previus = current;
                current = proximo;
            }

            string sequence = string.Join(", ", this.sequence);
            return sequence;
        }

        //Modificar valor do limite da lista
        public void SetLimiteFibonaci(int limit) => limitFibonaci = limit;
        //Obter valor de limite da lista
        public int GetLimiteFibonaci() => limitFibonaci;

        //Adicionar numero na sequencia
        public void AddNumberInSequence(int number) => sequence.Add(number);
    }
}