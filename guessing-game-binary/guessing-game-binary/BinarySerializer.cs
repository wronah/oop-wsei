using GraZaDuzoZaMalo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace guessing_game_binary
{
    public class BinarySerializer : SaveGame
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        public BinarySerializer()
        {
            saveFileName = "save.bin";
        }

        protected override Gra ProcessLoading(Stream stream)
        {
            return (Gra)formatter.Deserialize(stream);
        }

        protected override void ProcessSaving(Stream stream, Gra gra)
        {
            formatter.Serialize(stream, gra);
        }
    }
}
