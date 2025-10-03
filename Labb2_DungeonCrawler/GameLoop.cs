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
        var player = LevelData.Elements.OfType<Player>().FirstOrDefault();
        var rats = LevelData.Elements.OfType<Rat>().ToList();
        do
        {
            Console.Clear();           
            foreach (var element in LevelData.Elements)
            {
                element.Draw();
            }
            player.Update();
            foreach (var rat in rats)
            {
                rat.Update();
            }



        }
        while (true);
    }
}
