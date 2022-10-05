using System;

namespace Individual_project
{
    internal class Program
    {
       public static void MainMenu(string user, int[,] account, int i)
       {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Välkommen {0} Vänligen välj ett menyval", user);
                Console.Write("\n\t1: Ta ut pengar\n\t2: Överförning\n\t4:Logga ut ");
                Int32.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Console.WriteLine($"Vilket konto vill ta ut ifrån?\n\t1: Bankkonto {account[i, 0]}\n\t2: Sparkonto {account[i, 1]}");


                        break;




                    case 4:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
       }
        
        public static void Login(string[,] user, int[,] account)
        {
            int counter = 0;
            while (counter < 3)
            {
                Console.Clear();
                Console.Write("Skriv in användarnamn: ");
                string name = Console.ReadLine().ToLower();
                Console.Write("Skriv in pinkod: ");
                string pin = Console.ReadLine().ToLower();
                for (int i = 0; i < user.Length; i++)
                {
                   if (user[i,0] == name && user[i,1] == pin)
                   {
                        MainMenu(name, account, i);
                        counter = 3;
                        break;
                   }

                }
                Console.Write("xd");
                Console.ReadKey();
                counter++;
            }
        }
        static void Main(string[] args)
        {
            int[,] account = new int[5, 2] { { 5000, 21423 }, { 1000, 7245 }, { 500, 754 }, { 487, 15000 }, { 123, 52079 } };
            string[,] user = new string[5, 2] { { "andreas", "3695" }, { "sebastian", "1569" }, { "casper", "5170" }, { "johan", "5784" }, { "kalle", "3459" } };
            
            

            bool loop = true;

            while (loop)
            {
                Login(user, account);
            }

        }
    }
}
