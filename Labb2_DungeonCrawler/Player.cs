using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Player : LevelElements
{
    public override char Character { get { return '@'; } }

    public override ConsoleColor MyColor { get { return ConsoleColor.White; } }
    public Player()
    {
        
    }
    public void Update()
    {
        ConsoleKeyInfo userMove = Console.ReadKey(true);
        switch (userMove.Key)
        {
            case ConsoleKey.UpArrow:
                this.yCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.yCordinate++;
                    break;
                }
            case ConsoleKey.LeftArrow:
                this.xCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.xCordinate++;
                    break;
                }
            case ConsoleKey.RightArrow:
                this.xCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.xCordinate--;
                    break;
                }
            case ConsoleKey.DownArrow:
                this.yCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.yCordinate--;
                    break;
                }
            default:
                break;
        }
    }
}
