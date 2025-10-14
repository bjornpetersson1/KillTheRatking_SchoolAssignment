using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Labb2_DungeonCrawler;

public abstract class GameLoop:LevelElement
{
    public static void GameStart()
    {
        while (true)
        {
            bool isAlive = true;
            int savedXP = 0;
            int savedHP = 100; //TODO det måste du lösa, INTE SNYGGT
            ConsoleKeyInfo menuChoice;
            Console.CursorVisible = false;
            string userName = Graphics.WriteStartScreen();
            while(true)
            {
                LevelData.Elements?.Clear();
                Graphics.WriteLevelSelect(userName);
                menuChoice = Console.ReadKey(true);
                LevelChoice(menuChoice);
                var player = LevelData.Elements.OfType<Player>().FirstOrDefault();
                var enemys = LevelData.Elements.OfType<Enemy>().ToList();
                var walls = LevelData.Elements.OfType<Wall>().ToList();
                player.XP = savedXP;
                player.HP = savedHP;
                player.Name = userName; 
                Console.Clear();
                player.PrintUnitInfo();
                Graphics.WriteInfo();
                foreach (var wall in walls)
                {
                    wall.Update(player);
                    if (wall.IsToBeDrawn()) wall.Draw();
                }
                foreach (var element in LevelData.Elements)
                {
                    if (element is Player)
                    {
                        element.Draw();
                    }
                    else if (element.GetDistanceTo(player) < 5)
                    {
                        element.Draw();
                    }
                }
                do
                {
                    Graphics.WriteInfo();
                    enemys = LevelData.Elements.OfType<Enemy>().ToList();
                    walls = LevelData.Elements.OfType<Wall>().ToList();
                    menuChoice = Console.ReadKey(true);
                    if (menuChoice.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        savedXP = player.XP;
                        savedHP = player.HP;
                        break;
                    }
                    player.Update(menuChoice);
                    foreach (var wall in walls)
                    {
                        wall.Update(player);
                        if (wall.IsToBeDrawn()) wall.Draw();
                    }
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
                    var deadKings = LevelData.Elements.OfType<RatBoss>().Where(e => e.HP <= 0).ToList();
                    foreach (var king in deadKings)
                    {
                        player.XP += 132;
                    }

                    LevelData.Elements.RemoveAll(e => e is Enemy enemy && enemy.HP <= 0);

                    foreach (var element in LevelData.Elements)
                    {
                        if (element is Player)
                        {
                            element.Draw();
                        }
                        else if (element.GetDistanceTo(player) < 5)
                        {
                            element.Draw();
                        }
                    }
                } while (player.HP > 0);

                if (player.HP <= 0)
                {
                    isAlive = false;
                    savedXP = 0;
                    savedHP = 100;
                    Graphics.WriteEndScreen(player);

                    do
                    {
                        menuChoice = Console.ReadKey(true); 
                    }
                    while (menuChoice.Key != ConsoleKey.Escape && menuChoice.Key != ConsoleKey.Enter);
                    if (menuChoice.Key == ConsoleKey.Enter) Console.Clear();
                    else if (menuChoice.Key == ConsoleKey.Escape) break;
                }
            }
            if (isAlive == false) break;
        }
    }
}
