using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using m = Methods.ConsoleMethods;

namespace Hug_Quest_
{
    static class Events
    {
        //========================================EVENTS========================================//
        //Intro sequence (Call GetName() after)
        public static void Intro()
        {

            //First Seg
            m.ToConsole("Hello and welcome to the universe of Hugtopia!", false);
            m.ToConsole("This world is a precious place full of happiness and hugs!", false);
            m.ToConsole("\\(0u0)/", true);
            Console.Clear();

            //Second Seg
            m.ToConsole("Every day, everyone would gather at the town square of Hugopolis...",false);
            m.ToConsole("There, they would all give eachother hugs to help keep everyone happy!", false);
            m.ToConsole("(0>0)", true);
            Console.Clear();

            //Third Seg
            m.ToConsole("Oh silly me, I should really introduce myself!", false);
            m.ToConsole("My name is Snuffle!", false);
            m.ToConsole("\\(0u0)/", false);
            Console.WriteLine();

            //GET NAME SHOULD BE CALLED AFTER THIS FUNCTION
        }

        public static string GetName()
        {
            string name = null;
            bool nameConfirm = false;

            //Ask for name
            m.ToConsole("What is your name?", false);
            
            //Read name loop (While false)
            while (!nameConfirm){

                name = Console.ReadLine();

                //Accept only letters, clear and ask again if invalid
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    //Clear 2 lines
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    m.ClearCurrentConsoleLine();

                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    m.ClearCurrentConsoleLine();

                    //Request valid name
                    m.ToConsole("Please enter a real name, we are not that silly here!", false);
                }
                else //Else name is valid, ask to confirm
                {
                    //Confirm name
                    nameConfirm = m.ConfirmChoice("Are you happy with this name?");
                    if (!nameConfirm) //If false
                    {
                        m.ToConsole("Please enter your name again!");
                    }
                }
                
            }

            name = m.CapitalizeFirstLetter(name);
            //Name is valid
            return name;
        }

        //Intro sequence (Call GetName() after)
        public static void Transition(Saves.Savefile player)
        {

            //First Seg
            m.ToConsole($"So you are {player.name}!", false);
            m.ToConsole("Well I want to welcome you to this land of hugs and snuggles!", false);
            m.ToConsole("*hugs*");
            m.ToConsole("\\(UwU)/", true);
            Console.Clear();

            //Second Seg
            m.ToConsole("You must be really tired from learning all this though!", false);
            m.ToConsole("How about you take some time to rest?", false);
            m.ToConsole("(0>0)", true);
            Console.Clear();

            //Third Seg
            Console.ForegroundColor = ConsoleColor.Cyan;
            m.ToConsole("Snuffle takes you to a cozy little house...", false);
            m.ToConsole("He tucks you into bed and you steadily fall asleep", false);
            Console.Clear();
            Console.ResetColor();

            //Forth Seg (Sleep)
            m.ToConsole("Zzz", 1000, 1500);
            Console.Clear();

            m.ToConsole("Zzz", 1000, 1500);
            Console.Clear();

            m.ToConsole("Zzz", 1000, 1500);
            Console.Clear();

            m.ToConsole(". . . ", 500, 2000);
            Console.Clear();

            //Fifth seg (Awakening)
            Console.ForegroundColor = ConsoleColor.Red;
            m.ToConsole("BOOM!!!", 0, 2000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            m.ToConsole("You wake up to the sound of chaos...");
            m.ToConsole("Everyone is running all over the place, there is weird people dressed in black with AHL on their outfits");
            m.ToConsole("One of the citizens of Hugopolis runs up to you", true);
            Console.Clear();
            Console.ResetColor();

            //Sixth seg (Explanation)
            m.ToConsole("The Anti Hug Legion is here! And they have taken Snuffle!");
            m.ToConsole("You must do something!");
            m.ToConsole("Go to the castle quick!!!");
        }
    }
}
