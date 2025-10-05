using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class Enemy : LevelElement
{
    public abstract void Update(Player player);
    public override void PrintUnitInfo()
    {
        Console.SetCursorPosition(0, 3);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"|{Character}: {Name} | HP: {HP} | Attack: {AttackDice} | Defence: {DefenceDice} |");
    }
}
