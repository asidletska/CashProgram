using System;

namespace Cash_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Autorization
            bool autorization;
            {
                autorization = false;
                string login, password;
                {
                    Console.WriteLine("To enter the program you need to log in!");
                    Console.Write("Enter login: ");
                    login = Console.ReadLine();
                    Console.Write("\nEnter password: ");
                    password = Console.ReadLine();
                }
                Console.WriteLine("You have successfully registered!");
                Console.WriteLine();

                int authorizationAttemptCounter = 0;
                const int ALLOWABLE_NUMBER_OF_AUTHORIZATION_ATTEMPTS = 3;
                bool authorizationAttemptAvailable = authorizationAttemptCounter < ALLOWABLE_NUMBER_OF_AUTHORIZATION_ATTEMPTS;

                // Login to the program
                while (authorizationAttemptAvailable)
                {
                    string loginEnter, passwordEnter;
                    {
                        Console.Write("Enter login: ");
                        loginEnter = Console.ReadLine();
                        Console.Write("\nEnter password: ");
                        passwordEnter = Console.ReadLine();
                    }

                    if (loginEnter == login && passwordEnter == password)
                    {
                        Console.WriteLine("Welcome! You can start working in the program.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Login or password entered incorrectly!");
                        authorizationAttemptAvailable = ++authorizationAttemptCounter < ALLOWABLE_NUMBER_OF_AUTHORIZATION_ATTEMPTS;

                        if (authorizationAttemptAvailable)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("You have exhausted the number of authorization attempts. " +
                                "Recover data using phone number or email.");
                            Exit();
                            break;
                        }
                    }
                    
                }
            }
            // Work Program 
            {
                // Menu 
                while (true)
                {
                    Console.WriteLine("1. Cash program\n" +
                        "2. Sales for the quarter\n"  +
                        "3. Exit ");

                    string input = Console.ReadLine();                    
                    switch (input)
                    {
                        case "1":
                            CashProgram();
                            break;
                            case "2":
                            Quarter();
                            break;
                        case "3":
                            Exit();
                            break;
                    }
                }
            }

        }

        private static void CashProgram()
        {
            ConsoleKey key;
            do
            {
                decimal quontiti, price;
                {
                    Console.Write("quantity: ");
                    string stringQuontiti = Console.ReadLine();
                    quontiti = Convert.ToDecimal(stringQuontiti);
                    Console.Write("Price: ");
                    string stringPrice = Console.ReadLine();
                    price = Convert.ToDecimal(stringPrice);
                }
                decimal cost = quontiti * price;
                Console.WriteLine(@"All price: {0}", cost);

                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        private static void Quarter()
        {
            ConsoleKey key;

            string[] months = { "January", "February", "March" };
            string[] goods = { "Goods1", "Goods2", "Goods3" };
            string[] distributors = { "1", "2" };
            decimal[,,] statistic = new decimal[distributors.Length, goods.Length, months.Length];

            for (int z = 0; z < statistic.GetLength(0); z++)
                for (int y = 0; y < statistic.GetLength(1); y++)
                    for (int x = 0; x < statistic.GetLength(2); x++)
                    {
                        Console.Write($"{distributors[z]} sold tile {goods[y]} for {months[x]}: ");
                        statistic[z, y, x] = Convert.ToDecimal(Console.ReadLine());
                    }

            do
            {
                Console.Write("Enter the name of the company: ");
                string distributorsName = Console.ReadLine();
                Console.Write("Enter the name of the type of goods: ");
                string GoodsName = Console.ReadLine();
                int distributorsIndex = Array.IndexOf(distributors, distributorsName);
                int GoodsIndex = Array.IndexOf(goods, GoodsName);
                decimal numberOfGoods = 0;

                for (int x = 0; x < statistic.GetLength(2); x++)
                    numberOfGoods += statistic[distributorsIndex, GoodsIndex, x];
                Console.Write($"{distributorsName} sold goods {GoodsName} per quarter. ");

                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        private static void Exit()
        {
            Exit();
        }
    }

}


