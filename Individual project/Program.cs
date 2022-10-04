using System;

namespace Individual_project
{
    internal class Program
    {
       
        
        public static void Login(string[,] user)
        {
            int counter = 0;
            while (counter < 3)
            {
                Console.Clear();
                Console.Write("Skriv in användarnamn: ");
                string name = Console.ReadLine();
                Console.Write("Skriv in pinkod: ");
                string pin = Console.ReadLine();
                foreach(string s in user)
                {
                    Console.WriteLine(s);
                    Console.ReadLine();

                }
                
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
                Login(user);
            }

        }
    }
}
