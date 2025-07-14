using System;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.Arm;

namespace Cadastro
{
    public class Sistema
    {
        public static List<string> pessoas = new List<string>();

        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();

            double resposta = 0;
            Console.WriteLine("====== Sistema de cadastro de Cliente ======\n");

            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 - Cadastrar Cliente\n2 - Listar Clientes\n3 - Remover Clientes\n4 - Sair\n");

            resposta = double.Parse(Console.ReadLine());

            switch (resposta)
            {
                case 1: Cadastro(); break;
                case 2: Listar(); break;
                case 3: Remover(); break;
                case 4: Sair(); break;
                default: break;
            }

            Menu();
        }

        public static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("====== Cadastro de Cliente ======");

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Digite o nome do Cliente: ");
                var cliente = Console.ReadLine();

                if (cliente == null || cliente == "")
                {
                    Console.Clear();
                    Console.WriteLine("Resposta inválida, tente novamente!");
                    Thread.Sleep(3000);
                    continue;
                }
                
                Console.Clear();

                if (PegarRespostaPositivaNegativa("Deseja adicionar outro cliente?"))
                    continue;
                else
                    break;
            }

            Console.WriteLine("Cliente cadastrado com sucesso!");

            Menu();
        }

        public static void Listar()
        {
            Console.Clear();

            int cont = 1;

            Thread.Sleep(1000);
            Console.WriteLine("Clientes Cadastrados: ");

            if (pessoas.Count == 0)
            {
                Console.Clear();

                Thread.Sleep(500);
                Console.WriteLine("Nenhum cliente cadastrado ainda.");
                Thread.Sleep(3000);

                return;
            }

            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"{cont}. {pessoa}");
                cont++;
            }

            Thread.Sleep(4000);

            Menu();
        }

        public static void Remover()
        {
            Console.Clear();

            Console.WriteLine("====== Remover Cliente ======");
            pessoas.Remove(Console.ReadLine());

            Console.WriteLine("Cliente removido com sucesso!");

            Menu();
        }

        public static void Sair()
        {
            Console.Clear();
            Console.WriteLine("Encerrando o sistema... Obrigado!");
            Thread.Sleep(2000);

            Environment.Exit(0);
        }

        private static bool PegarRespostaPositivaNegativa(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                var input = Console.ReadLine();

                if (input.ToUpper() == "SIM" || input.ToUpper() == "NÃO")
                {
                    return input.ToUpper() == "SIM";
                }

                Console.WriteLine("Você digitou errado, tente novamente.");
                Thread.Sleep(1000);
                continue;
            }
        }
    }
}