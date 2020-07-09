using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saves;

namespace Hug_Quest_
{
    class Program
    {
        //Global Save file
        static Savefile player;

        static void Main(string[] args)
        {
            //Check for save file, if save exists load, else start new save
            if (SaveMethods.LoadSave() != null)
            {
                player = SaveMethods.LoadSave();
            }
            else
            {
                NewSave(args);
            }
        }

        static void NewSave(string [] arguments)
        {
            string name;
            bool skipIntro = false;
            bool skipTran = false;

            foreach(string arg in arguments)
            {
                if (string.Compare(arg, "-skipintro") == 0) { skipIntro = true; }
                if (string.Compare(arg, "-skiptran") == 0) { skipTran = true; }
            }

            //=====New game sequence=====

            //Trigger intro event
            if(!skipIntro) { Events.Intro(); }

            //Create new save
            name = Events.GetName();
            player = new Savefile(name, 0);

            //Begin transition
            if (!skipTran) { Events.Transition(player); }

            //=====Throw into game loop=====

            
        }
    }
}
