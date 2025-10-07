using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;
public class Snake : Enemy
{
    public Snake()
    {
        this.AttackDice = new Dice(4, 3, 2);
        this.DefenceDice = new Dice(8, 1, 5);
        this.HP = 25;
        this.Name = "snake";
        this.Character = 's';
        this.MyColor = ConsoleColor.Yellow;
    }

    public void SnakeNextMove(Player player)
    {
        //TODO det här kommer gå att göra om till delegate
        var directions = new Dictionary<string, double>();
        this.yCordinate++;
        if (this.IsSpaceAvailable()) directions["south"] = this.GetDistanceTo(player);
        this.yCordinate--;

        this.yCordinate--;
        if (this.IsSpaceAvailable()) directions["north"] = this.GetDistanceTo(player);
        this.yCordinate++;

        this.xCordinate++;
        if (this.IsSpaceAvailable()) directions["west"] = this.GetDistanceTo(player);
        this.xCordinate--;

        this.xCordinate--;
        if (this.IsSpaceAvailable()) directions["east"] = this.GetDistanceTo(player);
        this.xCordinate++;
        if (directions.Any())
        {
            var bestMove = directions.OrderByDescending(d => d.Value).First().Key;
            switch(bestMove)
            {
                case "south":
                    this.yCordinate++;
                    break;
                case "north":
                    this.yCordinate--;
                    break;
                case "west":
                    this.xCordinate++;
                    break;
                case "east":
                    this.xCordinate--;
                    break;
            }
        }

    }

    public override void Update(Player player)
    {
        if (this.GetDistanceTo(player) < 2)
        {
            this.SnakeNextMove(player);
        }
    }
}
