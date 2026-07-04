namespace Calculo_de_salario.Controller
{
    public class SequenceAnalyzerController
    {
        public int numberRepetition = 0;
        public List<float> sequence = new();

        public void AddNumber(float number) => sequence.Add(number);

        // Verificar qual o maior e qual o menor
        public (float menor, float maior) ExtractExtremes(List<float> sequence)
        {
            float maior = sequence[0];
            float menor = sequence[0];

            foreach (var number in sequence)
            {
                maior = maior >= number ? maior : number;
                menor = menor <= number ? menor : number;
            }

            return (menor, maior);
        }

        public List<float> ExtractionSequence(string sequence)
        {
            string[] textSequence = sequence.Split(",");
            List<float> newSequence = new();

            foreach (var text in textSequence)
            {
                if (float.TryParse(text, out float number))
                {
                    newSequence.Add(number);
                }
            }

            return newSequence;
        }

        // Valider Requisitos do sistema
        public (bool status, string error) ValidateSequence(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return (false, $"O{input} Campo não pode estar vazio");
            }

            var numbers = input.Split(',');
            if (numbers.Count() > numberRepetition)
            {
                return (false, $"A quantidade de numeros não corresponde a quantidade determindada {numbers.Count()}");
            }

            if (numbers.Any(n => n.Any(char.IsLetter)))
            {
                return (false, "Não pode conter letras");
            }

            if (numbers.Any(n => n.Any(char.IsWhiteSpace)))
            {
                return (false, "Não pode conter espaço");
            }

            return (true, "Sucesso");

        }

        public string JoinText(List<float> list)
        {
            string sequence = string.Join(",", list);
            return sequence;
        }
    }
}