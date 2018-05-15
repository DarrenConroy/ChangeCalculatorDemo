using System;
using ChangeCalculatorDemo;

namespace ChangeCalculatorDemoConsole
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Q) Please enter the TOTAL PRODUCT PRICE");

                string productPrice = Console.ReadLine();

                ChangeCalculator changeCalculator = new ChangeCalculator();

                int actualProductPrice = changeCalculator.ConvertMoney(productPrice);

                if (actualProductPrice > 0)
                {
                    Console.WriteLine("Q) How much are you giving to the cashier?");

                    string cashierGiven = Console.ReadLine();
                    int actualCashierGiven = changeCalculator.ConvertMoney(cashierGiven);

                    if (actualCashierGiven > 0)
                    {
                        if (actualCashierGiven == actualProductPrice)
                        {
                            Console.WriteLine("_______________");
                            Console.WriteLine();
                            Console.WriteLine("Thanks. That's spot on!");
                            Console.WriteLine();
                        }
                        else if (actualCashierGiven > actualProductPrice)
                        {
                            var change = changeCalculator.DisplayChange(actualCashierGiven - actualProductPrice);

                            Console.WriteLine("_______________");
                            Console.WriteLine();
                            Console.WriteLine("Your change is:");
                            Console.WriteLine("_______________");
                            Console.WriteLine();

                            foreach (string denomination in change)
                            {
                                Console.WriteLine(denomination);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that's not enough!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount given to cashier!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product price!");
                }

                Console.WriteLine("___________________________________");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
