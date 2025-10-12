using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Rat : Enemy
{
    private Random random;
    public Rat()
    {
        random = new Random();
        AttackDice = new Dice(6, 1, 3);
        DefenceDice = new Dice(6, 1, 1);
        HP = 10;
        Name = "rat";
        Symbol = 'r';
        MyColor = ConsoleColor.Red;
    }

    public override void Update(Player player)
    {
        int move = random.Next(4);
        switch(move)
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
    }
}
