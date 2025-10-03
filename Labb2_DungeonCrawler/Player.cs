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
    //TODO fixa players update-metod
    public void Update()
    {
        ConsoleKeyInfo userMove;
        Player player;
        userMove = Console.ReadKey(true);
        switch (userMove.Key) //TODO fixa till det här stöket, gör en struct av koordinaterna
        {
            case ConsoleKey.UpArrow:
                player = LevelData.Elements.OfType<Player>().First(e => e is Player);
                player.yCordinate--;
                if (player.IsSpaceAvailable()) break;
                else
                {
                    player.yCordinate++;
                    break;
                }
            case ConsoleKey.LeftArrow:
                player = LevelData.Elements.OfType<Player>().First(e => e is Player);
                player.xCordinate--;
                if (player.IsSpaceAvailable()) break;
                else
                {
                    player.xCordinate++;
                    break;
                }
            case ConsoleKey.RightArrow:
                player = LevelData.Elements.OfType<Player>().First(e => e is Player);
                player.xCordinate++;
                if (player.IsSpaceAvailable()) break;
                else
                {
                    player.xCordinate--;
                    break;
                }
            case ConsoleKey.DownArrow:
                player = LevelData.Elements.OfType<Player>().First(e => e is Player);
                player.yCordinate++;
                if (player.IsSpaceAvailable()) break;
                else
                {
                    player.yCordinate--;
                    break;
                }
            default:
                break;
        }
    }
}
