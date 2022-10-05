using System;

namespace Individual_project
{
    internal class Program
    {

        public static void Withdrawal(decimal[,] account, int i, string pin)
        {
            Console.Clear();
            Console.WriteLine($"Vilket konto vill göra ett uttag ifrån?\n1: Lönkonto: {account[i, 0]}Kr\n2: Sparkonto: {account[i, 1]}Kr");
            Int32.TryParse(Console.ReadLine(), out int accountChoise);
            accountChoise--;
            if (accountChoise == 0 || accountChoise == 1)
            {
                bool amountCheck = true;
                while (amountCheck)
                {
                    Console.Write("Summa för uttag: ");
                    Decimal.TryParse(Console.ReadLine(), out decimal amount);
                    if (amount > account[i, accountChoise])
                    {
                        Console.WriteLine("Vänligen välj en summa mindre än {0}Kr!", account[i, accountChoise]);
                    }
                    else
                    {
                        Console.WriteLine("Vänligen skriv in din pin");
                        string pinCheck = Console.ReadLine();
                        if (pinCheck == pin)
                        {
                            account[i, accountChoise] -= amount;
                            Console.WriteLine("Ditt nya saldo: {0}Kr", account[i, accountChoise]);
                            amountCheck = false;
                            ReturnToMainMenu();
                        }
                        else
                        {
                            Console.WriteLine("Fel pin!");
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Felaktigt konto val!");
            }
        }
        public static void MainMenu(string user, decimal[,] account, int i, string pin)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Välkommen {0} Vänligen välj ett menyval", user);
                Console.Write("\n\t1: Dina konton\n\t2: Överförning\n\t3: Uttag\n\t4:Logga ut ");
                Int32.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {









                    case 3:
                        Withdrawal(account, i, pin);
                        break;

                    case 4:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Login(string[,] user, decimal[,] account)
        {
            int counter = 0;
            while (counter < 3)
            {
                bool loginSucces = false;
                Console.Clear();
                Console.Write("Skriv in användarnamn: ");
                string name = Console.ReadLine().ToLower();
                Console.Write("Skriv in pinkod: ");
                string pin = Console.ReadLine().ToLower();
                for (int i = 0; i < user.Length/2; i++)
                {
                    /*if (i == 5)
                        break;*/
                     if (user[i, 0].ToLower() == name && user[i, 1] == pin)
                    {
                        loginSucces = true;
                        counter = 0;
                        MainMenu(name, account, i, pin);

                    }

                }
                if (!loginSucces)
                {
                    Console.Write("Felaktigt Användarnamn Eller Pin!");
                    Console.ReadKey();
                }

                counter++;
            }
        }
        static void Main(string[] args)
        {
            decimal[,] account = new decimal[5, 2] { { 5000, 21423 }, { 1000, 7245 }, { 500, 754 }, { 487, 15000 }, { 123, 52079 } };
            string[,] user = new string[5, 2] { { "Andreas", "3695" }, { "Sebastian", "1569" }, { "Casper", "5170" }, { "Johan", "5784" }, { "Kalle", "3459" } };

            Login(user, account);


        }
        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Tryck på enter för att återgå till Menyn!");
            Console.ReadKey();
        }
    }
}
