using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = Methods.ConsoleMethods;
using s = Saves.SaveMethods;

namespace Hug_Quest_
{
    //Interface for all encounter types
    interface IEncounter
    {
        void StartEncounter(Saves.Savefile playerSave);

        void EncounterOpening();

        void EncounterInteract();

        void EncounterClosing();
    }

    //Exploration encounter
    class ExploreEncounter : IEncounter
    {
        //Variables
        readonly string[] openText;
        readonly string[] interactText;
        readonly string[] closeText;

        //Methods

        public void StartEncounter(Saves.Savefile playerSave)
        {
            s.SaveGame(playerSave);
            EncounterOpening();
            EncounterInteract();
            EncounterClosing();
        }

        public void EncounterOpening()
        {
            foreach (string text in openText)
            {
                m.ToConsole(text);
            }
        }
        
        public void EncounterInteract()
        {
            throw new NotImplementedException();
        }

        public void EncounterClosing()
        {
            throw new NotImplementedException();
        }
    }
}
