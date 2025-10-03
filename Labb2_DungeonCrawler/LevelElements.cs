using Labb2_DungeonCrawler;

public abstract class LevelElements
{
    public int xCordinate { get; set; }
    public int yCordinate { get; set; }
    public virtual char Character { get; }
    public virtual ConsoleColor MyColor { get; }

    public void Draw()
    {
        Console.SetCursorPosition(xCordinate, yCordinate);
        Console.ForegroundColor = MyColor;
        Console.Write(Character);
    }
    public bool IsSpaceAvailable()
    {
        return LevelData.Elements.
    }

}