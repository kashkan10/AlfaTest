using System.Threading.Tasks;

namespace AlfaTest
{
    public class Manager
    {
        private string text;
        private string inputFilePath;

        public Manager(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
        }

        public async Task<string> ParseAsync(IParser parser)
        {
            text = await Task.Run(() => parser.Parse(inputFilePath));

            return text;
        }

        public async Task WriteAsync(IWriter writer)
        {
            await writer.WriteAsync(text);
        }

        public void ClearText()
        {
            text = "";
        }
    }
}
