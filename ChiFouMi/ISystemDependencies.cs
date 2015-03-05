namespace ChiFouMi
{
    public interface ISystemDependencies
    {
        void WriteLine(string line);

        string ReadLine();

        int GetRandomInt(int upperLimit);
    }
}