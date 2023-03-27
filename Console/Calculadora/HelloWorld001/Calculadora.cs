using System;

namespace HelloWorld001
{
    internal class Calculadora
    {
        public static float OperacaoBasica(float num1, float num2, char operador)
        {
            float resultado = 0;

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Erro: divisão por zero.");
                    }
                    break;
                default:
                    Console.WriteLine("Operador inválido.");
                    break;
            }

            return resultado;
        }

        static void Main(string[] args)
        {
            float num1 = 0, num2 = 0;
            char operador;

            while (true)
            {
                try
                {
                    Console.Write("Escreva o primeiro número: ");
                    num1 = float.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Número inválido.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Escreva o operador (+ - / *): ");
                    operador = Console.ReadKey().KeyChar;
                    if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Operador inválido.");
                    }
                }
                catch
                {
                    Console.WriteLine("Operador inválido.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("\nEscreva o segundo número: ");
                    num2 = float.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Número inválido.");
                }
            }

            float resultado = OperacaoBasica(num1, num2, operador);
            Console.WriteLine($"O resultado de {num1} {operador} {num2} é: {resultado}");
            Console.Read();
        }
    }
}
