namespace ChiFouMi
{
    public interface IExternalDependencies
    {
        void WriteLine(string line);

        string ReadLine();

        int GetNextRandomBetween1And3();
    }
}