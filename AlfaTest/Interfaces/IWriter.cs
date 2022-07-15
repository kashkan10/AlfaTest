using System.Threading.Tasks;

namespace AlfaTest
{
    public interface IWriter
    {
        public Task WriteAsync(string text);
    }
}
