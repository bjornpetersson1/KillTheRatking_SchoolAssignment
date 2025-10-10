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
        ConsoleKeyInfo menuChoice;
        Console.CursorVisible = false;
        string userName = Graphics.WriteStartScreen();
        do
        {
            menuChoice = Console.ReadKey(true);
            switch (menuChoice.Key)
            {
                case ConsoleKey.D1:
                    LevelData.Load("Level1.txt");
                    break;
                case ConsoleKey.D2:
                    LevelData.Load("Level2.txt");
                    break;
                case ConsoleKey.D3:
                    LevelData.Load("Level3.txt");
                    break;
            }   
        }
        while (menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.D2 && menuChoice.Key != ConsoleKey.D3);
        var player = LevelData.Elements.OfType<Player>().FirstOrDefault();
        var enemys = LevelData.Elements.OfType<Enemy>().ToList();
        var walls = LevelData.Elements.OfType<Wall>().ToList();
        player.Name = userName; 
        Console.Clear();
        player.PrintUnitInfo();
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
            enemys = LevelData.Elements.OfType<Enemy>().ToList();
            walls = LevelData.Elements.OfType<Wall>().ToList();
            player.Update();
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

            LevelData.Elements.RemoveAll(e => e is Enemy && e.HP <= 0);
            
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
        }
        while (player.HP > 0);
        Graphics.WriteEndScreen(player);
    }
}
