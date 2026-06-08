using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginBanco
{

    public class Banco
    {
        public int senha = 1234;
        public double saldo = 100;
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Banco banco = new Banco();

            int opcoes = 3;
            double deposito = 0, saque = 0;
            double limite = 10000;

            string senhaDigitada;

            Console.WriteLine("Digite sua senha: ");
            senhaDigitada = Console.ReadLine();

            while (true)
            {
                if (senhaDigitada == banco.senha.ToString())
                {
                    Console.WriteLine("Senha correta. Bem-vindo ao banco!");
                    break;
                }
                else
                {
                    Console.WriteLine("Senha incorreta. Tente novamente: ");
                    senhaDigitada = Console.ReadLine();
                }
            }

        inicioSwitch:
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");

            opcoes = int.Parse(Console.ReadLine());

            switch (opcoes)
            {
                case 1:
                    Console.WriteLine("Você tem R$" + banco.saldo + " na conta. " + "Digite o valor a ser depositado: ");
                    deposito = double.Parse(Console.ReadLine());

                    while (true)
                    {
                        if (deposito > 0 && deposito < limite)
                        {
                            banco.saldo += deposito;
                            Console.WriteLine("Depósito realizado com sucesso. Seu novo saldo é: R$" + banco.saldo);
                            break;
                        }
                        else if (deposito < 0)
                        {
                            Console.WriteLine("Valor inválido");
                            deposito = double.Parse(Console.ReadLine());
                        }
                        else if (deposito > limite)
                        {
                            Console.WriteLine("Valor excede o limite de depósito. Tente novamente");
                            deposito = double.Parse(Console.ReadLine());
                        }
                    }
                    break;

                    case 2:
                    Console.WriteLine("Você tem R$" + banco.saldo + " na conta. " + "Digite o valor a ser sacado: ");
                    saque = double.Parse(Console.ReadLine());

                    while (true)
                    {
                        if (saque <= banco.saldo)
                        {
                            banco.saldo -= saque;
                            Console.WriteLine("Saque realizado com sucesso. Seu novo saldo é: R$" + banco.saldo);
                            break;
                        }
                        else if (saque > banco.saldo)
                        {
                            Console.WriteLine("Valor inválido ou saldo insuficiente. Tente novamente");
                            saque = double.Parse(Console.ReadLine());
                        }
                    }break;

                default:
                    {
                        while (true)
                        {
                            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            goto inicioSwitch;
                        }
                    }
            }

            Console.WriteLine("Deseja realizar outra operação? (sim/não)");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "sim")
            {
                goto inicioSwitch;
            }
            else if (resposta == "não")
            {
                Console.WriteLine("Obrigado por usar o banco. Tenha um ótimo dia!");
            }

                Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}