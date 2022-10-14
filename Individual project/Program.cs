using System;

namespace Individual_project
{
    internal class Program
    {

        public static void Withdrawal(decimal[][] account, int index, string pin)
        {
            bool withdrawLoop = true;
            while (withdrawLoop)
            {
                Console.Clear();
                Console.WriteLine($"Vilket konto vill göra ett uttag ifrån?");
                int count = 0;
                for (int i = 0; i < account.Length; i++)
                {
                    try
                    {
                        count++;
                        Console.WriteLine($"Konto Nr{count}: {account[index][i]}Kr");
                    }
                    catch
                    {
                        count = i;
                        break;
                    }
                }
                Int32.TryParse(Console.ReadLine(), out int accountChoise);
                accountChoise--;
                if (accountChoise < count && accountChoise >= 0)
                {
                    bool amountCheck = true;
                    while (amountCheck)
                    {
                        Console.Write("Summa för uttag: ");
                        Decimal.TryParse(Console.ReadLine(), out decimal amount);
                        if (amount > account[index][accountChoise])
                        {
                            Console.WriteLine("Vänligen välj en summa mindre än {0}Kr!", account[index][accountChoise]);
                        }
                        else
                        {
                            Console.WriteLine("Vänligen skriv in din PIN");
                            string pinCheck = Console.ReadLine();
                            if (pinCheck == pin)
                            {
                                account[index][accountChoise] -= amount;
                                account[index][accountChoise] = Math.Round(account[index][accountChoise], 2, MidpointRounding.ToEven);
                                Console.WriteLine("Ditt nya saldo: {0}Kr", account[index][accountChoise]);
                                amountCheck = false;
                                withdrawLoop = false;
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
                    Console.WriteLine("Felaktigt konto val!\nTryck på enter för att fortsätta");
                    Console.ReadLine();
                }
            }
        }
        public static void MainMenu(string user, decimal[][] account, int i, string pin)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Välkommen {0} Vänligen välj ett menyval", user);
                Console.Write("\n\t1: Dina konton\n\t2: Överförning\n\t3: Uttag\n\t4: Logga ut\n");
                Int32.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {









                    case 3:
                        Withdrawal(account, i, pin);
                        break;
                    case 4:
                        loop = false;
                        Login(account);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Login(decimal[][] account)
        {
            string[,] user = new string[5, 2] { { "Andreas", "3695" }, { "Sebastian", "1569" }, { "Casper", "5170" }, { "Johan", "5784" }, { "Kalle", "3459" } };
            int counter = 0;
            while (counter < 3)
            {
                bool loginSucces = false;
                Console.Clear();
                Console.Write("Skriv in användarnamn: ");
                string name = Console.ReadLine().ToLower();
                Console.Write("Skriv in pinkod: ");
                string pin = Console.ReadLine().ToLower();
                for (int i = 0; i < user.Length / 2; i++)
                {
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
            decimal[][] account = new decimal[][]
            {
                new decimal []{ 5000, 21423, 500000 },
                new decimal []{ 1000, 7245 },
                new decimal []{ 500, 754 },
                new decimal []{ 487, 15000, 5000, 21375},
                new decimal []{ 123, 52079 }
            };
            Login(account);
        }
        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Tryck på enter för att återgå till Menyn!");
            Console.ReadKey();
        }
    }
}
