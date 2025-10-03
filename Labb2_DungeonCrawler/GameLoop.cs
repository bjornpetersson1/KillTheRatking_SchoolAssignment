using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class GameLoop:LevelElements
{
    public static void GameStart()
    {
        ConsoleKeyInfo userMove;
        do
        {
            foreach (var element in LevelData.Elements)
            {
                element.Draw();
            }
            userMove = Console.ReadKey(true);
            
            Console.Clear();           
        }
        while (userMove.Key != ConsoleKey.Escape);
    }
}
