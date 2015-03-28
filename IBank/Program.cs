using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBank
{
    //bank interface
    public interface IBankAccount
    {
        void payIn(decimal amount);
        bool withDraw(decimal amount);
        decimal Balance
        {
            get;
        }
    }

    //another interface
    //to show inherit between interfaces
    public interface ITransferBankAccount : IBankAccount
    {
        bool transferTo(IBankAccount destination,decimal amount);
    }


    //first bank: Royal Bank of Venus
    public class SaverAccount : IBankAccount
    {
        private decimal balance;
        public void payIn(decimal amount)
        {
            balance += amount;
        }
        public bool withDraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("withdraw faild,not enough money");
            return false;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public override string ToString()
        {
            return String.Format("Venus bank server: balance = {0,6:C}",balance);
        }
    }

    //second bank: Planetary Bank of Jupiter
    public class GoldAccount : IBankAccount
    {
        private decimal balance;
        public void payIn(decimal amount)
        {
            balance += amount;
        }
        public bool withDraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("withdraw faild,not enough money");
            return false;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public override string ToString()
        {
            return String.Format("jupiter bank server: balance = {0,6:C}", balance);
        }
    }

    //the third bank: Plentary Bank of Jupiter
    public class CurretAccount : ITransferBankAccount
    {
        private decimal balance;
        public void payIn(decimal amount)
        {
            balance += amount;
        }
        public bool withDraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("withdraw faild,not enough money");
            return false;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public bool transferTo(IBankAccount destination,decimal amount)
        {
            if (this.balance >= amount)
            {
                destination.payIn(amount);
                this.balance -= amount;
                return true;
            }
            return false;
            Console.WriteLine("no enough money");
        }

        public override string ToString()
        {
            return String.Format("lucifer bank server: balance = {0,6:C}", balance);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //impletation of interface
            //instantiation two banks
            IBankAccount venusAccount = new SaverAccount();
            IBankAccount jupiterAccount = new GoldAccount();

            venusAccount.payIn(200);
            venusAccount.withDraw(100);
            Console.WriteLine(venusAccount.ToString());

            jupiterAccount.payIn(500);
            jupiterAccount.withDraw(600);
            jupiterAccount.payIn(200);
            Console.WriteLine(jupiterAccount.ToString());

            //we can even use array to save classes implements from the same interface
            //IBankAccount[] banks = new IBankAccount[2];
            //banks[1] = new SaverAccount();
            //banks[2] = new GoldAccount();
            //test outcoming

            ITransferBankAccount luciferAccount = new CurretAccount();
            luciferAccount.payIn(1000);
            luciferAccount.transferTo(jupiterAccount,200);
            Console.WriteLine(jupiterAccount.ToString());
            Console.WriteLine(luciferAccount.ToString());
        }
    }
}
