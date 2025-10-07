using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class RatBossTail : Enemy
{
    public RatBossTail()
    {
        this.Character = '¤';
        this.MyColor = ConsoleColor.DarkYellow;
        this.Name = "theKingsTail";
        this.HP = 254;
        this.AttackDice = new Dice(0, 0, 20);

    }

    public override void Update(Player player)
    {

        //if (TurnsPlayed % 3 == 0)
        //{

        //}
    }
}
