using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace bigBadInClass
{
    class UserList
    {
        static void Main(string[] args)
        {

            MenuLoop();

            


        }

     

        static int UserMenuInput()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }



        static void InitialMenuLoop()
        {
            Console.Clear();
            Console.WriteLine("Welcom to the Task App! What would you like to preform?");
            Console.WriteLine("1. Feed Tasks");
            Console.WriteLine("2. Review Tasks Pages");
            Console.WriteLine("3. Exit Program");
            Console.WriteLine("______________________________________________________________________________________________");
        }




        static void MenuLoop()
        {

            bool adqInput = false;

            do
            {
                InitialMenuLoop();
                int input = UserMenuInput();


                switch (input)
                {
                    case 1:
                        Console.Clear();
                        UserFeedMethod(); // input method for feed tasks
                        break;

                    case 2:
                        Console.Clear();
                        ShowList();// input method for reviewing tasks
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;
                }
            } while (!adqInput);

        }




        static List<string> UserFeedMethod()
        {
            string txtPath = @"C:\Users\Geddy107\Desktop\csharpUserList.rtf";// setting the path for the txt document that the list will write to.

            List<string> toDoList = File.ReadAllLines(txtPath).ToList();// setting all input to toDoList to the text path 

            string list = "";

            Console.WriteLine("Feed Me Tasks");  // initial request for input
            Console.WriteLine("press 'Enter' key with no input to continue");
            Console.WriteLine("______________________________________________________________________________________________");
           

            do
            {
                
                
                list = Console.ReadLine();
                toDoList.Add(list);


            } while (!string.IsNullOrEmpty(list));

            

            Console.WriteLine();
            Console.WriteLine("All Done!");//!!!!!!!!having an issue with this (when printed to the console it appears all messed up)
            File.WriteAllLines(txtPath, toDoList);



            return toDoList;
        }




        static void ShowList()// this will show the user what is currently on their list 
        {

            Console.WriteLine("Press 'ESC' to return to main menu");
            Console.WriteLine("__________________________________________________");

            string txtPath = @"C:\Users\Geddy107\Desktop\csharpUserList.rtf";

            List<string> lines = File.ReadAllLines(txtPath).ToList();
            ConsoleKey escapeKey;
            ConsoleKey userPress;
            do
            {
                

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }

                escapeKey = ConsoleKey.Escape;
                userPress = Console.ReadKey().Key;

            } while (escapeKey != userPress);
          

          

            

            InitialMenuLoop();

        }








            //static void Highlight()
            //{

            //    ConsoleColor newForeColor = ConsoleColor.White;
            //    ConsoleColor newBackColor = ConsoleColor.Black;

            //}







        
    }
}


