namespace ChessMazeGame
{
    public interface IView
    {
        void Begin();
        void End();
        void Show<T>(T message);
        void Show<T>(string message, T value);
        void Show<T>(string message, T value1, T value2);
        string Read(string prompt);

    }
}
