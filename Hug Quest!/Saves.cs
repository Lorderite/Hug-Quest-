using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saves
{
    static class SaveMethods
    {
        private const string FILE_NAME = "save_0.dat";
        private static readonly BinaryFormatter formatter = new BinaryFormatter();

        //Method that involves loading an existing save file
        public static Savefile LoadSave()
        {
            Savefile save;

            try
            {
                FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
                save = (Savefile)formatter.Deserialize(fs);
                fs.Close();

                return save;
            }
            catch
            {
                return null;
            }
        }

        //Method to save game
        public static void SaveGame(Savefile save)
        {
            FileStream fs = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
            formatter.Serialize(fs, save);
            fs.Close();
        }
    }

    class Savefile
    {
        //Variables to be stored in save file
        public readonly string name;
        protected double progress;
        
        public Savefile(string name, double progress)
        {
            this.name = name;
            this.progress = progress;
        }

        public double Progress { get => progress; set => progress = value; }
    }
}
