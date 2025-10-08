using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo menuChoice;
        do
        {
            Console.SetBufferSize(Console.WindowWidth, 60);
            StartAndEndScreen.WriteTitleScreen();
            LevelData.Elements?.Clear();
            GameLoop.GameStart();
            menuChoice = Console.ReadKey(true);
        }
        while (menuChoice.Key != ConsoleKey.Escape);

    }
}
