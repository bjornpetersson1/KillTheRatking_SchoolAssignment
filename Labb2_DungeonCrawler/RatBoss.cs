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
        var tails = LevelData.Elements.OfType<RatBossTail>()?.ToList();
        if (!(tails is null))
        {
            foreach (var tail in tails)
            {
                tail.Erase();
            }
        }
        LevelData.Elements.RemoveAll(t => t is RatBossTail);
        int move = random.Next(4);
        this.TurnsPlayed++;
        if (this.TurnsPlayed % 2 == 0)
        {
            switch (move)
            {
                case 0:
                    this.xCordinate--;
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.xCordinate++;
                        break;
                    }
                case 1:
                    this.xCordinate++;
                    foreach (var tail in tails)
                    {
                        tail.xCordinate++;
                    }
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.xCordinate--;
                        break;
                    }
                case 2:
                    this.yCordinate--;
                    foreach (var tail in tails)
                    {
                        tail.yCordinate--;
                    }
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.yCordinate++;
                        break;
                    }
                case 3:
                    this.yCordinate++;
                    foreach (var tail in tails)
                    {
                        tail.yCordinate++;
                    }
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.yCordinate--;
                        break;
                    }

            }
            if (this.TurnsPlayed % 3 == 0)
            {
                switch(move)
                {
                    case 0:
                        for (global::System.Int32 i = 1; i <= 3; i++)
                        {
                            RatBossTail tail = new RatBossTail() { yCordinate = this.yCordinate - i, xCordinate = this.xCordinate };
                            if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                            else
                            {
                                tail.CollideAndConcequences();
                                break;
                            }
                            RatBossTail tail2 = new RatBossTail() { yCordinate = this.yCordinate + i, xCordinate = this.xCordinate };
                            if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                            else
                            {
                                tail2.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case 1:
                        for (global::System.Int32 i = 1; i <= 3; i++)
                        {
                            RatBossTail tail = new RatBossTail() { yCordinate = this.yCordinate + i, xCordinate = this.xCordinate };
                            if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                            else
                            {
                                tail.CollideAndConcequences();
                                break;
                            }
                            RatBossTail tail2 = new RatBossTail() { yCordinate = this.yCordinate, xCordinate = this.xCordinate - i };
                            if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                            else
                            {
                                tail2.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case 2:
                        for (global::System.Int32 i = 1; i <= 3; i++)
                        {
                            RatBossTail tail = new RatBossTail() { yCordinate = this.yCordinate, xCordinate = this.xCordinate - i };
                            if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                            else
                            {
                                tail.CollideAndConcequences();
                                break;
                            }
                            RatBossTail tail2 = new RatBossTail() { yCordinate = this.yCordinate, xCordinate = this.xCordinate + i };
                            if (tail2.IsSpaceAvailable()) LevelData.Elements.Add(tail2);
                            else
                            {
                                tail2.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case 3:
                        for (global::System.Int32 i = 1; i <= 3; i++)
                        {
                            RatBossTail tail = new RatBossTail() { yCordinate = this.yCordinate, xCordinate = this.xCordinate + i };
                            if (tail.IsSpaceAvailable()) LevelData.Elements.Add(tail);
                            else
                            {
                                tail.CollideAndConcequences();
                                break;
                            }
                            RatBossTail tail2 = new RatBossTail() { yCordinate = this.yCordinate - i, xCordinate = this.xCordinate };
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
    }
}
