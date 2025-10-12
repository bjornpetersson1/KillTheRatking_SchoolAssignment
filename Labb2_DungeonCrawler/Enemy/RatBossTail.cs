using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class RatBossTail : Enemy
{
    private int lifeTime = 1;
    public RatBossTail()
    {
        Symbol = '¤';
        MyColor = ConsoleColor.DarkYellow;
        Name = "theKingsTail";
        AttackDice = new Dice(0, 0, 20);
        DefenceDice = new Dice(20, 20, 20);
        HP = 200;
    }
    public override void Update(Player player)
    {
        this.lifeTime--;
        if (lifeTime <= 0)
        {
            this.Erase();
            LevelData.Elements.Remove(this);
        }
    }
    public static void AddRatTails(int random0To3, int y, int x)
    {
        switch (random0To3)
        {
            case 0:
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail = new RatBossTail() { yCordinate = y - i, xCordinate = x };
                    if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                    else
                    {
                        tail.CollideAndConcequences();
                        break;
                    }
                }
                for(int i = 1; i <=3; i++)
                { 
                    RatBossTail tail2 = new RatBossTail() { yCordinate = y + i, xCordinate = x };
                    if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                    else
                    {
                        tail2.CollideAndConcequences();
                        break;
                    }
                }
                break;
            case 1:
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail = new RatBossTail() { yCordinate = y + i, xCordinate = x };
                    if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                    else
                    {
                        tail.CollideAndConcequences();
                        break;
                    }
                }
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail2 = new RatBossTail() { yCordinate = y, xCordinate = x - i };
                    if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                    else
                    {
                        tail2.CollideAndConcequences();
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail = new RatBossTail() { yCordinate = y, xCordinate = x - i };
                    if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                    else
                    {
                        tail.CollideAndConcequences();
                        break;
                    }
                }
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail2 = new RatBossTail() { yCordinate = y, xCordinate = x + i };
                    if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                    else
                    {
                        tail2.CollideAndConcequences();
                        break;
                    }
                }
                break;
            case 3:
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail = new RatBossTail() { yCordinate = y, xCordinate = x + i };
                    if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                    else
                    {
                        tail.CollideAndConcequences();
                        break;
                    }
                }
                for (int i = 1; i <= 3; i++)
                {
                    RatBossTail tail2 = new RatBossTail() { yCordinate = y - i, xCordinate = x };
                    if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                    else
                    {
                        tail2.CollideAndConcequences();
                        break;
                    }
                }
                break;
        }
    }

}
