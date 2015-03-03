namespace ChiFouMi
{
    public interface ISystemDependencies
    {
        void WriteLine(string line);

        string ReadLine();

        int GetNextRandomBetween1And3();
    }
}