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
        random = new Random();
        AttackDice = new Dice(6, 3, 2);
        DefenceDice = new Dice(6, 1, 1);
        HP = 85;
        Name = "ratKing";
        Character = 'R';
        MyColor = ConsoleColor.DarkRed;
        
    }
    
    public override void Update(Player player)
    {
        int move = random.Next(4);
        this.TurnsPlayed++;
        if (TurnsPlayed % 2 == 0)
        {
            switch (move)
            {
                case 0:
                    xCordinate--;
                    if (IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        xCordinate++;
                        break;
                    }
                case 1:
                    xCordinate++;
                    if (IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        xCordinate--;
                        break;
                    }
                case 2:
                    yCordinate--;
                    if (IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        yCordinate++;
                        break;
                    }
                case 3:
                    yCordinate++;
                    if (IsSpaceAvailable()) break;
                    else
                    {
                        CollideAndConcequences();
                        yCordinate--;
                        break;
                    }

            }
            if (TurnsPlayed % 3 == 0 && HP > 0)
            {
               RatBossTail.AddRatTails(move, yCordinate, xCordinate);
            }
        }
    }
}
