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
    }
    //TODO lös så att lazern försvinner efter attacken

}
