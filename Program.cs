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



        static void MenuDisplay()
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
                MenuDisplay();
                int input = UserMenuInput();


                switch (input)
                {
                    case 1:
                        Console.Clear();
                        UserFeedMethod(); // input method for feed tasks
                        break;

                    case 2:
                        Console.Clear();
                        //ShowList();// input method for reviewing tasks
                        ListSelection();

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

            List<string> toDoList = File.ReadAllLines(txtPath).ToList();// setting all input to toDoList to the text path.

            string list = "";

            Console.WriteLine("Feed Me Tasks");  // initial request for input
            Console.WriteLine("press 'Enter' key with no input to continue");
            Console.WriteLine("______________________________________________________________________________________________");


            do
            {


                list = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(list))  // makes sure that there are no blank spaces in the list.
                {

                    toDoList.Add(list);
                }



            } while (!string.IsNullOrEmpty(list));



            Console.WriteLine();
            Console.WriteLine("All Done!");//!!!!!!!!having an issue with this (when printed to the console it appears all messed up)
            File.WriteAllLines(txtPath, toDoList);



            return toDoList;
        }




        //static void ShowList()// this will show the user what is currently on their list 
        //{
            
        //    Console.WriteLine("Press 'ESC' to return to main menu");
            
        //    Console.WriteLine("__________________________________________________");
            

        //    string txtPath = @"C:\Users\Geddy107\Desktop\csharpUserList.rtf";
            
        //    List<string> lines = File.ReadAllLines(txtPath).ToList();
        //    ConsoleKey escapeKey;
        //    ConsoleKey userPress;
        //    do
        //    {
                

        //        foreach (string line in lines)
        //        {
        //            Console.WriteLine(line);

        //            //if (line )
        //            //{

        //            //}
        //        }

        //        escapeKey = ConsoleKey.Escape;
        //        userPress = Console.ReadKey().Key;

        //    } while (escapeKey != userPress);
          

          

            

        //    MenuDisplay();

        //}





        static void ListSelection()//method highlights diffrent tasks in the list

        {
            int index = 0;

            string txtPath = @"C:\Users\Geddy107\Desktop\csharpUserList.rtf";
            
            List<string> lines = File.ReadAllLines(txtPath).ToList();
            List<string> actioned = new List<string>();

            ConsoleKeyInfo ckey;
         
            Console.CursorVisible = false;
            do
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(lines[i]);
                    }

                    else
                    {
                        Console.WriteLine(lines[i]);
                    }
                    Console.ResetColor();

                }

                ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)

                    if (index == lines.Count - 1)
                    { index = 0; }


                    else
                    { index++; }


                else if (ckey.Key == ConsoleKey.UpArrow)
                    if (index <= 0)
                    { index = lines.Count - 1; }


                    else
                    { index--; }
                else if (ckey.Key == ConsoleKey.Enter )
                {
                    
                    actioned.Add(lines[index] + "^");  //having an issue wher the first char of first selected string is cut off.
                }


                





                Console.Clear();
                



            } while (ckey.Key != ConsoleKey.Escape);

            actioned.ForEach(Console.WriteLine);
            Console.ReadLine();
        }


      
       






    }
}


