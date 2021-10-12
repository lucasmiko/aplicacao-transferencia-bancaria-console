using System;

namespace DIO.Bank
{
    public class Account
    {
        private string Name {get;set;}
        private AccountType AccountType {get;set;}
        private double Balance {get;set;}
        private double Credit {get;set;}

        //Construtor principal da conta
        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            if (this.Balance - withdrawValue < (this.Credit* .1))
            {
                Console.WriteLine("Slado insuficiente");
                return false;
            }

            this.Balance -= withdrawValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double depositAmount)
        {
            this.Balance += depositAmount;
            Console.WriteLine("Saldo atual da conte de {0} é {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account destinationAccount)
        {
            if (this.Withdraw(transferValue)) 
            {
                destinationAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
		{
            string result = "";
            result += "Tipo de Conta: " + this.AccountType + " | ";
            result += "Nome: " + this.Name + " | ";
            result += "Saldo: " + this.Balance + " | ";
            result += "Crédito: " + this.Credit;
			return result;
		}
    }
}