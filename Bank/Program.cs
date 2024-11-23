using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Principal;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----WELCOME-----");
                Console.WriteLine("Please enter your username");
                string username = Console.ReadLine().ToLower();
                Console.WriteLine("Please enter your password");
                int password = Convert.ToInt32(Console.ReadLine());
                if (username == "erkan" && password == 123)
                {
                    Console.WriteLine("Login successful.");
                    Thread.Sleep(3000);
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1-Deposit\n2-Withdraw\n3-Money\n4-Press q to exit.\nPlease write down the action you want to take.");
                        string input = Console.ReadLine().ToLower();
                        if (input == "1" || input == "d" || input == "deposit")
                        {
                            Console.WriteLine("Please enter the amount you want to deposit");
                            double dmoney = Convert.ToDouble(Console.ReadLine());
                            bank.Deposit(dmoney);
                        }
                        else if (input == "2" || input == "w" || input == "withdraw")
                        {
                            Console.WriteLine("Please enter the amount you want to deposit");
                            double wmoney = Convert.ToDouble(Console.ReadLine());
                            bank.Withdraw(wmoney);
                        }
                        else if (input == "3" || input == "m" || input == "money")
                        {
                            Console.WriteLine("Money in your account: " + bank.Money);
                            Thread.Sleep(2000);
                        }
                        else if (input == "q" || input == "exit" || input == "4")
                        {
                            bank.Party();
                        }
                        else
                        {
                            Console.WriteLine("You entered an incorrect value, try again.");
                            Thread.Sleep(2000);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Username or password is incorrect, try again.");
                    Thread.Sleep(2000);
                    continue;
                }
            }
        }
    }
    class Bank
    {
        private double money = 1000;
        public double Money
        {
            get { return money; }
            set
            {
                money += value;
                if (value > 0)
                {
                    Console.WriteLine("Money in your account: " + this.money);
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("There is no money in the account");
                    Thread.Sleep(2000);
                }
            }
        }
        public void Deposit(double deposit)
        {
            if (deposit > 0)
            {
                money += deposit;
                Console.WriteLine("Money has been added to your account {0}", deposit);
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("The entered value must be greater than zero.");
                Thread.Sleep(2000);
            }
        }
        public void Withdraw(double withdraw)
        {
            if (withdraw <= 0)
            {
                Console.WriteLine("The entered value must be greater than zero.");
                Thread.Sleep(2000);
            }
            else if (withdraw > money)
            {
                Console.WriteLine("Insufficient funds. The amount you want to withdraw is more than your current balance");
                Thread.Sleep(2000);
            }
            else
            {
                money -= withdraw;
                Console.WriteLine("Money has been debited from your account " + withdraw);
                Thread.Sleep(2000);
            }
        }
        public void Party()
        {
            Console.Clear();
            Console.WriteLine("Exiting the program\nGet ready for fun!!!");
            Thread.Sleep(3000);
            Console.Clear();
            for (; ; )
            {
                for (var i = 0; i < 15; i++)
                {
                    string backColor = i.ToString();
                    string foreColor = i.ToString();
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), backColor);
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), foreColor);
                    Console.Clear();
                    Thread.Sleep(1);
                }
            }
        }
    }
}
