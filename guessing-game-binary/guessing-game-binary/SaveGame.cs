using GraZaDuzoZaMalo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessing_game_binary
{
    public abstract class SaveGame
    {
        protected String saveFileName;
        public bool SaveExists { get => File.Exists(saveFileName); }
        protected abstract void ProcessSaving(Stream stream, Gra gra);
        protected abstract Gra ProcessLoading(Stream stream);
        public void DeleteSave()
        {
            if (SaveExists)
            {
                File.Delete(saveFileName);
            }
        }
        public void SerializeGame(Gra gra)
        {
            using (var stream = new FileStream(saveFileName, FileMode.Create, FileAccess.Write))
            {
                ProcessSaving(stream, gra);
            }
        }
        public Gra LoadGame()
        {
            using (var stream = new FileStream(saveFileName, FileMode.Open, FileAccess.Read))
            {
                return ProcessLoading(stream);
            }
        }
        
        
    }
}
