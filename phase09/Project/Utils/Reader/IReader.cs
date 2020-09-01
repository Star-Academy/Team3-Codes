namespace SearchNest.Utils.Reader
{
    public interface IReader
    {
        bool MoveNext();
        string CurrentText();
        string CurrentName();
    }
}