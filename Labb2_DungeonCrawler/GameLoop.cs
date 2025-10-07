using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class GameLoop:LevelElement
{
    public static void GameStart()
    {
        Console.CursorVisible = false;
        ConsoleKeyInfo userMove; //TODO hitta en snyggare lösning på esc
        var player = LevelData.Elements.OfType<Player>().FirstOrDefault();
        var enemys = LevelData.Elements.OfType<Enemy>().ToList();
        player.PrintUnitInfo();
        foreach (var element in LevelData.Elements)
        {
            if (element is Player)
            {
                element.Draw();
            }
            else if (element.GetDistanceTo(player) < 50)
            {
                element.Draw();
            }
        }
        do
        {
            player.Update();
            foreach (var enemy in enemys)
            {
                enemy.Erase();
                enemy.Update(player);
            }
            //TODO det här lär att gå att göra till geemensam lista
            var deadRats = LevelData.Elements.OfType<Rat>().Where(e => e.HP <= 0).ToList();
            foreach (var rat in deadRats)
            {
                player.XP += 23;
            }
            var deadSneaks = LevelData.Elements.OfType<Snake>().Where(e => e.HP <= 0).ToList();
            foreach (var snake in deadSneaks)
            {
                player.XP += 57;
            }

            LevelData.Elements.RemoveAll(e => e is Enemy && e.HP <= 0);
            
            foreach (var element in LevelData.Elements)
            {
                if (element is Player)
                {
                    element.Draw();
                }
                else if (element.GetDistanceTo(player) < 50)
                {
                    element.Draw();
                }
            }
        }
        while (true);
    }
}
