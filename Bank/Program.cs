using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "x")
            {

                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado pr utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void InserirConta()
            {
                Console.WriteLine("Inserir nova conta");

                Console.Write("Digita 1 para conta Física o 2 para Jurídica:");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.Write("Digita o Nome do Cliente:");
                string entradaNome = Console.ReadLine();

                Console.Write("Digite o saldo inicial:");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.Write("Digita o crédito:");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

                listContas.Add(novaConta);
            }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {

                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[1];
                Console.Write("#{0} -", i);
                Console.WriteLine(conta);
            }

        }


        private static string ObterOpcaoUsuario()
            {

                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada:");


                Console.WriteLine("1- Listar Contas.");
                Console.WriteLine("2- Inserir nova conta.");
                Console.WriteLine("3- Transferir");
                Console.WriteLine("4- Sacar");
                Console.WriteLine("5- Depositar");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");

                string OpcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return OpcaoUsuario;

            }
        }



    }

