﻿using System;

namespace TestApplication 
{
    class Program 
    {
        static void Main(string[] args) 
        {

            Console.WriteLine("+===========================================+");
            Console.WriteLine("|       Test Application (Database EF6)     |");
            Console.WriteLine("+-------------------------------------------+");
            Console.WriteLine("|                  Menu                     |");
            Console.WriteLine("|     1 - Create New user to Database       |");
            Console.WriteLine("|     2 - Output info from Table            |");
            Console.WriteLine("|     3 - Exit and close                    |");
            Console.WriteLine("|___________________________________________|");

            using (var context = new ApplicationContext()) 
            {

                try {

                    while (true)
                    {
                        Console.Write("|  Input your choice: ");
                        var input = Console.ReadLine();
                       
                        if (input == null)                   // if (input == null || int.TryParse(input) ????)
                        {
                            continue;
                        }
                        int choiceMenu = int.Parse(input);

                        switch (choiceMenu)
                        {
                            case 1:
                                Console.WriteLine("+             Creating new user.            +");
                                string messageLogin = "|             Enter login: ";
                                string login = Verification(messageLogin);
                                string passwordMessage = "|             Enter password:               |";
                                string password = Verification(passwordMessage);
                                var usr = new Users()
                                {
                                    UserLogin = login,
                                    Password = password
                                };

                                context.Users.Add(usr);
                                context.SaveChanges();
                                Console.WriteLine("|  User was successfully added to the table |");
                                break;

                            case 2:
                                Console.WriteLine("|          Output info from Table           |");
                                List<Users> users = context.Users.ToList();
                                foreach (Users u in users)
                                {
                                    Console.WriteLine(u);
                                }
                                break;

                            case 3:
                                Console.WriteLine(".___________________________________________.");
                                Console.WriteLine("|           Closing app. Goodbye!           |");
                                Console.WriteLine("+-------------------------------------------+------------+");
                                Console.WriteLine("| Github: https://github.com/tohamdhope/TomHunterTestApp |");
                                Console.WriteLine("+========================================================+");
                                return;

                            default:
                                Console.WriteLine("|             Choose a numer from 1 to 3                 |");
                                break;
                        }

                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"      ERORR: {ex}       ");
                }
                
            }
        }


        public static string Verification(string message)
        {
            Console.WriteLine(message);
            var inputString = Console.ReadLine();
            while (inputString == null) 
            {
                Console.WriteLine("You didn't enter anything. try again");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
    }
}
