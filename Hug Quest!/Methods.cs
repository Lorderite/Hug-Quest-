using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public static class ConsoleMethods
    {
        //=====Variables=====
        static readonly string[] affirmative = {"y", "yes", "sure", "ok", "okay","ye", "yeh", "alright", "yep", "mhm", "yuh", "yee", "yeah"};
        static readonly string[] negative = { "n", "no", "nope", "nuh", "nou", "nah", "nu", "nuh uh", "nu uh"};

        static readonly int textPrintWaitTime = 50;
        static readonly int lineWaitTime = 300;


        //=====Methods=====

        //Print to consoles and hold until enter is pressed
        public static void ToConsole(string text, bool hold)
        {
            //Push text to console
            ToConsole(text);

            //If clear is TRUE, clear console
            if (hold)
            {
                HoldConsole();
            }
        }

        //Print line to console
        public static void ToConsole(string text)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(textPrintWaitTime);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(lineWaitTime);
        }

        //Print line to console (With time overrides)
        public static void ToConsole(string text, int textPrintWaitTime, int lineWaitTime)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(textPrintWaitTime);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(lineWaitTime);
        }

        //Use to get valid yes/no
        public static bool ConfirmChoice()
        {
            //Print basic confirmation request
            ToConsole("Are you sure? y/n");
         
            //Input handle
            bool isResponseValid = false;
            while (!isResponseValid)//Always loops, exit is handled via return
            {
                //Get Response
                string response = Console.ReadLine();
                //Change to lower case for comparison
                response = response.ToLower();

                //Examine response
                //Check for affirmative match against all strings
                foreach(string affirmativeString in affirmative)
                {
                    if(string.Compare(affirmativeString, response) == 0)
                    {
                        return true;
                    }
                }

                //Check for negative match
                foreach (string negativeString in negative)
                {
                    if (string.Compare(negativeString, response) == 0)
                    {
                        return false;
                    }
                }

                //No match was found, request answer again
                ToConsole("I'm not sure what you said, please answer properly!");
            }

            //Default to false
            return false;
        }

        //Use to get yes/no (Custom message)
        public static bool ConfirmChoice(string message)
        {
            //Print basic confirmation request
            ToConsole(message);

            //Input handle
            bool isResponseValid = false;
            while (!isResponseValid)//Always loops, exit is handled via return
            {
                //Get Response
                string response = Console.ReadLine();
                //Change to lower case for comparison
                response = response.ToLower();

                //Examine response
                //Check for affirmative match against all strings
                foreach (string affirmativeString in affirmative)
                {
                    if (string.Compare(affirmativeString, response) == 0)
                    {
                        return true;
                    }
                }

                //Check for negative match
                foreach (string negativeString in negative)
                {
                    if (string.Compare(negativeString, response) == 0)
                    {
                        return false;
                    }
                }

                //No match was found, request answer again
                ToConsole("I'm not sure what you said, please answer properly!");
            }

            //Default to false
            return false;
        }

        public static void HoldConsole()
        {
            //Prepare key + wait variables
            ConsoleKeyInfo cki;
            bool wait = true;

            Console.WriteLine("Press enter to continue...", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.ResetColor();

            while (wait)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    wait = false;
                }
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        //Captilize first letter
        public static string CapitalizeFirstLetter(string word)
        {
            char[] letters = word.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            word = new string(letters);
            return word;
        }
    }
}
