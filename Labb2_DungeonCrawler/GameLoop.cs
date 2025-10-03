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
        ConsoleKeyInfo userMove; //TODO hitta en snyggare lösning på esc
        var player = FindFirst //TODO fortstätt här, du ska hitta referernsen till player helt enkelt, sen köra in den i player.Update()
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
