﻿using System;
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
            return String.Format("Venus bank server: balance = {0,6:C}", balance);
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
        }
    }
}
