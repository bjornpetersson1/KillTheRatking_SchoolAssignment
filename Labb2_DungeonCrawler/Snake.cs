using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;
public class Snake : Enemy
{
    public override char Character { get { return 's'; } }

    public override ConsoleColor MyColor { get { return ConsoleColor.Yellow; } }

    public override Dice AttackDice { get; set; }
    public override Dice DefenceDice { get; set; }
    public Snake()
    {
        this.AttackDice = new Dice(4, 3, 2);
        this.DefenceDice = new Dice(8, 1, 5);
        this.HP = 25;
        this.Name = "snake";
    }

    public override void Update(Player player)
    {
        //TODO fixa ormens updatemetod
        if (this.GetDistanceTo(player) < 2)
        {
            if (this.xCordinate == player.xCordinate && this.yCordinate > player.yCordinate)
            {
                this.yCordinate++;
                if (!this.IsSpaceAvailable()) this.yCordinate--;
            }
            else if (this.xCordinate == player.xCordinate && this.yCordinate < player.yCordinate)
            {
                this.yCordinate--;
                if (!this.IsSpaceAvailable()) this.yCordinate++;
            }
            else if (this.yCordinate == player.yCordinate && this.xCordinate > player.xCordinate)
            {
                this.xCordinate++;
                if (!this.IsSpaceAvailable()) this.xCordinate--;
            }
            else if (this.yCordinate == player.yCordinate && this.xCordinate < player.xCordinate)
            {
                this.xCordinate--;
                if (!this.IsSpaceAvailable()) this.xCordinate++;
            }
            else if (Math.Abs(this.xCordinate - player.xCordinate) > Math.Abs(this.yCordinate - player.yCordinate))
            {
                if (this.yCordinate > player.yCordinate)
                {
                    this.yCordinate++;
                    if (!this.IsSpaceAvailable()) this.yCordinate--;
                }
                else
                {
                    this.yCordinate--;
                    if (!this.IsSpaceAvailable()) this.yCordinate++;
                }
            }
            else
            {
                if (this.xCordinate > player.xCordinate)
                {
                    this.xCordinate++;
                    if (!this.IsSpaceAvailable()) this.xCordinate--;
                }
                else
                {
                    this.xCordinate--;
                    if (!this.IsSpaceAvailable()) this.xCordinate++;
                }
            }
        }
    }
}
