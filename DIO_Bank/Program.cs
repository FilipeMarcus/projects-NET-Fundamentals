using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoMenu = "";
            do 
            {   
                opcaoMenu = ObterOpcaoUsuario();

                switch (opcaoMenu)
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
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();            
                }
            } while (opcaoMenu != "X");

            Console.WriteLine("Obrigado por utilizar nossos serviços\n");
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count <= 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            else
            {
                for ( int i = 0; i < listaContas.Count; i++)
                {
                    Conta contaVetor = listaContas[i];
                    Console.Write($"Conta #{i}:\n");
                    //  fazendo o metodo ToString SOZINHO
                    Console.WriteLine(contaVetor);
                    //  fazendo o metodo ToString SOZINHO
                }
            }
            //throw new NotImplementedException();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = 0;
            if ( int.TryParse(Console.ReadLine(), out int tempInt ) && (tempInt == 1 || tempInt == 2) )
            {
                entradaTipoConta = tempInt;
            }
            else
            {
                Console.Write("Tipo de Conta Inválido!");
            }

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = 0;
            if (Double.TryParse(Console.ReadLine(), out double tempDouble1))
            {
                entradaSaldo = tempDouble1;
            }
            else
            {
                Console.Write("Saldo inválido!");
            }
            
            Console.Write("Digite o crédito: ");
            double entradaCredito = 0;
            if (Double.TryParse(Console.ReadLine(), out double tempDouble2))
            {
                entradaCredito = tempDouble2;
            }
            else
            {
                Console.Write("Crédito inválido!");
            }
            Conta novaConta = new Conta(tipo_conta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo, credito: entradaCredito,
										nome: entradaNome);

            listaContas.Add(novaConta);
            //throw new NotImplementedException();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de Origem: ");
            int indiceContaOrigem = 0;
            if (int.TryParse(Console.ReadLine(), out int indiceOrigem))
            {
                indiceContaOrigem = indiceOrigem;
            }
            else
            {
                Console.Write("Número de conta inválido: ");
            }

            Console.Write("Digite o número da conta de Destino: ");
            int indiceContaDestino = 0;
            if (int.TryParse(Console.ReadLine(), out int indiceDestino))
            {
                indiceContaDestino = indiceDestino;
            }
            else
            {
                Console.Write("Número de conta inválido: ");
            }
            
            Console.Write("Digite o valor a ser Transferido: ");
            double valorTransferencia = 0;
            if (double.TryParse(Console.ReadLine(), out double valorDigitado))
            {
                valorTransferencia = valorDigitado;
            }
            else
            {
                Console.Write("Digitação errada: ");
            }

            listaContas[indiceContaOrigem].TransferirFundos(valorTransferencia, listaContas[indiceContaDestino]);
        }
        private static void Sacar()
        {
            Console.Write("Digite o Nº da conta: ");
            if (int.TryParse(Console.ReadLine(), out int tryaccountid))
            {
                int indiceConta = tryaccountid;
                Console.Write("Digite o valor a ser sacado: ");
                if (double.TryParse(Console.ReadLine(), out double trysaque))
                {
                    double valorSaque = trysaque;

                    listaContas[indiceConta].SacarFundos(valorSaque);
                }
            }
        }
        private static void Depositar()
        {
            Console.Write("Digite o Nº da conta: ");
            if (int.TryParse(Console.ReadLine(), out int tryaccountid))
            {
                int indiceConta = tryaccountid;
                Console.Write("Digite o valor a ser depositado: ");
                if (double.TryParse(Console.ReadLine(), out double trydeposit))
                {
                    double valorDeposito = trydeposit;

                    listaContas[indiceConta].DepositarFundos(valorDeposito);
                }
            }
        }
        private static string ObterOpcaoUsuario()
        {   
            Console.WriteLine("\nDIO Bank a seu dispor !");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Abrir nova conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoMenu;
        }
    }
}
