using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Lazer : LevelElement
{
    public Lazer()
    {
        this.Name = "lazer";
        this.Character = '~';
        this.MyColor = ConsoleColor.Magenta;
        this.AttackDice = new Dice(0, 0, 20);
        this.DefenceDice = new Dice(20, 20, 20);
    }

}
