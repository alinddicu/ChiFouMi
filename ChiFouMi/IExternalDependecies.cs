namespace ChiFouMi
{
    public interface IExternalDependecies
    {
        void WriteLine(string line);

        string ReadLine();

        int GetNextRandomBetween1And3();
    }
}
