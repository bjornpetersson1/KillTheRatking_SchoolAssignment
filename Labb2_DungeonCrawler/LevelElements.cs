public abstract class LevelElements
{
    public int xCordinate { get; set; }
    public int yCordinate { get; set; }
    public abstract char Character { get; }
    public abstract ConsoleColor MyColor { get; }

    public void Draw()
    {
        Console.SetCursorPosition(xCordinate, yCordinate);
        Console.ForegroundColor = MyColor;
        Console.Write(Character);
    }

}