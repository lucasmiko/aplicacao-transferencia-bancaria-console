using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Account> accounts = new List<Account>();
		static void Main(string[] args)
		{
			string userChoice = GetUserChoice();

			while (userChoice.ToUpper() != "X")
			{
				switch (userChoice)
				{
					case "1":
						ShowAccounts();
						break;
					case "2":
						InsertAccount();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
						Deposit();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userChoice = GetUserChoice();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void Deposit()
		{
			Console.Write("Digite o número da conta: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double depositValue = double.Parse(Console.ReadLine());

            accounts[accountIndex].Deposit(depositValue);
		}

		private static void Withdraw()
		{
			Console.Write("Digite o número da conta: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double withdrawValue = double.Parse(Console.ReadLine());

            accounts[accountIndex].Withdraw(withdrawValue);
		}

		private static void Transfer()
		{
			Console.Write("Digite o número da conta de origem: ");
			int sourceAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int destinationAccountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double transferValue = double.Parse(Console.ReadLine());

            accounts[sourceAccountIndex].Transfer(transferValue, accounts[destinationAccountIndex]);
		}

		private static void InsertAccount()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int accountTypeIn = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string nameIn = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double balanceIn = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double creditIn = double.Parse(Console.ReadLine());

			Account newAccount = new Account(accountType: (AccountType)accountTypeIn,
										balance: balanceIn,
										credit: creditIn,
										name: nameIn);

			accounts.Add(newAccount);
		}

		private static void ShowAccounts()
		{
			Console.WriteLine("Listar contas");

			if (accounts.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < accounts.Count; i++)
			{
				Account account = accounts[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}

		private static string GetUserChoice()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar contas");
			Console.WriteLine("2 - Inserir nova conta");
			Console.WriteLine("3 - Transferir");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
			return userOption;
		}
	}
}

