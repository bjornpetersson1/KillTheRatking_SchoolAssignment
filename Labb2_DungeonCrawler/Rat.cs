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
        this.random = new Random();
        this.AttackDice = new Dice(6, 1, 3);
        this.DefenceDice = new Dice(6, 1, 1);
        this.HP = 10;
        this.Name = "rat";
        this.Character = 'r';
        this.MyColor = ConsoleColor.Red;
    }

    public override void Update(Player player)
    {
        int move = random.Next(4);
        switch(move)
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
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.xCordinate--;
                    break;
                }
            case 2:
                this.yCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.yCordinate++;
                    break;
                }
            case 3:
                this.yCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.yCordinate--;
                    break;
                }
        }    
    }
}
