
namespace Search.Utils
{
    public interface IReader
    {
         bool MoveNext();
         string Current();
    }
}