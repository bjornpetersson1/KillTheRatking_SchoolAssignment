using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class RatBoss : Enemy
{

    private Random random;
    public RatBoss()
    {
        this.random = new Random();
        this.AttackDice = new Dice(6, 3, 2);
        this.DefenceDice = new Dice(6, 1, 1);
        this.HP = 85;
        this.Name = "ratKing";
        this.Character = 'R';
        this.MyColor = ConsoleColor.DarkRed;
    }
    public override void Update(Player player)
    {
        var tails = LevelData.Elements.OfType<RatBossTail>().ToList();
        int move = random.Next(4);
        if (TurnsPlayed % 2 == 0)
        {
            //switch (move)
            //{
            //    case 0:
            //        this.xCordinate --;
            //        foreach (var tail in tails)
            //        {
            //            tail.xCordinate--;
            //        }
            //        if (this.IsSpaceAvailable()) break;
            //        else
            //        {
            //            CollideAndConcequences();
            //            this.xCordinate ++;
            //            break;
            //        }
            //    case 1:
            //        this.xCordinate ++;
            //        foreach (var tail in tails)
            //        {
            //            tail.xCordinate++;
            //        }
            //        if (this.IsSpaceAvailable()) break;
            //        else
            //        {
            //            CollideAndConcequences();
            //            this.xCordinate --;
            //            break;
            //        }
            //    case 2:
            //        this.yCordinate --;
            //        foreach (var tail in tails)
            //        {
            //            tail.yCordinate--;
            //        }
            //        if (this.IsSpaceAvailable()) break;
            //        else
            //        {
            //            CollideAndConcequences();
            //            this.yCordinate ++;
            //            break;
            //        }
            //    case 3:
            //        this.yCordinate ++;
            //        foreach (var tail in tails)
            //        {
            //            tail.yCordinate++;
            //        }
            //        if (this.IsSpaceAvailable()) break;
            //        else
            //        {
            //            CollideAndConcequences();
            //            this.yCordinate --;
            //            break;
            //        }

            //}
        }
    }
}
