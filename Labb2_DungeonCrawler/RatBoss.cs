using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class RatBoss : Enemy
{
    public override char Character { get; set; }

    public override ConsoleColor MyColor { get { return ConsoleColor.DarkRed; } }

    public override Dice AttackDice { get; set; }
    public override Dice DefenceDice { get; set; }

    private Random random;
    public RatBoss()
    {
        this.random = new Random();
        this.AttackDice = new Dice(6, 3, 2);
        this.DefenceDice = new Dice(6, 1, 1);
        this.HP = 85;
        this.Name = "ratKing";
        this.Character = 'R';
    }
    public override void Update(Player player)
    {
        int move = random.Next(4);
        if (TurnsPlayed % 2 == 0)
        {
            switch (move)
            {
                case 0:
                    this.xCordinate -= 2;
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.xCordinate += 2;
                        break;
                    }
                case 1:
                    this.xCordinate += 2;
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.xCordinate -= 2;
                        break;
                    }
                case 2:
                    this.yCordinate -= 2;
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.yCordinate += 2;
                        break;
                    }
                case 3:
                    this.yCordinate += 2;
                    if (this.IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        this.yCordinate -= 2;
                        break;
                    }

            }
        }
        //TODO detta är råttkungens attack gör klart
        if (TurnsPlayed % 3 == 0)
        {
            Console.SetCursorPosition()
        }
    }
}
