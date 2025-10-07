using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labb2_DungeonCrawler;

public static class StartAndEndScreen
{
    public static void WriteEndScreen(Player player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string gameOver = "game over.";
        string roundInfo = $"{player.Name} died a heroic death fighting rats and\nsnakes in {player.TurnsPlayed} turns and recieved {player.XP} xp\npress [enter] to play again or [escape] to quit";
        Console.SetCursorPosition(15, 10);
        foreach (var item in gameOver)
        {
            Console.Write(item);
            Thread.Sleep(300);
        }
        Console.SetCursorPosition(0, 12);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        foreach (var item in roundInfo)
        {
            Console.Write(item);
            Thread.Sleep(80);
        }
    }
    public static string WriteStartScreen()
    {
        Console.Clear();
        string hello = "Hello there, whats your name?";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(15, 10);
        foreach (var item in hello)
        {
            Console.Write(item);
            Thread.Sleep(100);
        }
        Console.SetCursorPosition(15, 12);
        Console.CursorVisible = true;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Name: ");
        string result = Console.ReadLine();
        Console.CursorVisible = false;
        Console.SetCursorPosition(15, 14);
        Console.ForegroundColor = ConsoleColor.Green;
        string gameStart1 = $"Alright {result}...";
        string gameStart2 = "press any key when you are ready to fight";
        foreach (var item in gameStart1)
        {
            Console.Write(item);
            Thread.Sleep(120);
        }
        Console.WriteLine();
        Console.SetCursorPosition(15, 15);
        foreach (var item in gameStart2)
        {
            Console.Write(item);
            Thread.Sleep(120);
        }
        return result;
    }
    public static void WriteLevelSelect()
    {
        Console.Clear();
        string levelSelect1 = "press [1] to play level 1";
        string levelSelect2 = "press [2] to play level 2";
        string levelSelect3 = "press [2] to play level 3";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(15, 10);
        foreach (var item in levelSelect1)
        {
            Console.Write(item);
            Thread.Sleep(80);
        }
        Console.SetCursorPosition(15, 11);
        foreach (var item in levelSelect2)
        {
            Console.Write(item);
            Thread.Sleep(80);
        }
    }
}

