namespace SearchNest.Utils.Reader
{
    public interface IReader
    {
        bool MoveNext();
        string Current();
    }
}