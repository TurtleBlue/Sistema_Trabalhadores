using System;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_Trabalhadores
{
    public class trabalhadorNormal
    {
        public string nome;
        protected decimal salarioL;

        public trabalhadorNormal(string nome, decimal salarioL)
        {
            this.nome = nome;
            this.salarioL = salarioL;
        }
        public virtual decimal calculoDeSalario()
        {
            return salarioL;
        }
    }
    public class trabalhadorVendas : trabalhadorNormal
    {
        protected decimal comissao;

        public trabalhadorVendas(string nome, decimal comissao, decimal salarioL) : base(nome, salarioL)
        {
            this.comissao = comissao;
        }
        public override decimal calculoDeSalario()
        {
            return salarioL + comissao;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                char op = 'x';
                string nome;
                decimal salario, comissaoV;

                Console.WriteLine("Qual o nome do trabalhador que deseja cadastrar?");
                nome = Console.ReadLine();
                Console.WriteLine("Qual o salário do trabalhador que deseja cadastrar?");
                salario = Convert.ToInt32(Console.ReadLine());

                    while (op != 'S' && op != 's' && op != 'N' && op != 'n')
                    {
                        Console.WriteLine("Esse trabalhador possui comissão? S/N");
                        op = Convert.ToChar(Console.ReadLine());
                        if (op != 'S' && op != 's' && op != 'N' && op != 'n')
                        {
                        Console.WriteLine("Opção inválida, tente novamente");
                        Console.ReadKey();
                        Console.Clear();
                        }
                    }

                    if (op == 'S' || op == 's')
                    {
                        Console.WriteLine("Qual a comissão desse trabalhador?");
                        comissaoV = Convert.ToInt32(Console.ReadLine());

                        var trabalhadorVendas = new trabalhadorVendas(nome, salario, comissaoV);
                        Console.WriteLine($"O trabalhador {trabalhadorVendas.nome} tem o salário de: {trabalhadorVendas.calculoDeSalario()} e comissão de: {comissaoV}");
                    }
                    if (op == 'N' || op == 'n')
                    {
                        var trabalhador = new trabalhadorNormal(nome, salario);
                        Console.WriteLine($"O trabalhador {trabalhador.nome} tem o salário de {trabalhador.calculoDeSalario()}");
                    }
                }
            }
        }
    }
