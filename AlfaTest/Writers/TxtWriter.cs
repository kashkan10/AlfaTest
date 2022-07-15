using System.IO;
using System.Threading.Tasks;

namespace AlfaTest
{
    public class TxtWriter : IWriter
    {
        private readonly string path;

        public TxtWriter(string path)
        {
            this.path = path;
        }

        public async Task WriteAsync(string text)
        {
            using (StreamWriter writer = new StreamWriter(path + "output.txt", false))
            {
                await writer.WriteLineAsync(text);
            }
        }
    }
}