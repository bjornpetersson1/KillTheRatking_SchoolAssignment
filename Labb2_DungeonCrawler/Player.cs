using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Player : LevelElement
{
    public override char Character { get { return '@'; } }

    public override ConsoleColor MyColor { get { return ConsoleColor.White; } }
    public override Dice AttackDice { get; set; }
    public override Dice DefenceDice { get; set; }
    public override string Name { get; set; }
    public Player(string name = "player")
    {
        this.AttackDice = new Dice(6, 2, 2);
        this.DefenceDice = new Dice(6, 2, 0);
        this.HP = 100;
        this.Name = name;
    }
    public override void PrintUnitInfo()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"|{Character}: {Name} | HP: {HP} | Attack: {AttackDice} | Defence: {DefenceDice} |");
    }
    public void Update()
    {
        ConsoleKeyInfo userMove = Console.ReadKey(true);
        this.Erase();
        switch (userMove.Key)
        {
            case ConsoleKey.UpArrow:
                this.yCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    var collider = this.GetCollider();
                    if (collider is Wall)
                    {
                        this.yCordinate++;
                        break;                      
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 1);
                        PrintFightresult(Fight(collider), collider);
                        collider.PrintFightresult(collider.Fight(this), this);
                        this.PrintUnitInfo();
                        collider.PrintUnitInfo();
                        this.yCordinate++;
                        break;
                    }
                }
            case ConsoleKey.LeftArrow:
                this.xCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    var collider = this.GetCollider();
                    if (collider is Wall)
                    {
                        this.xCordinate++;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 1);
                        PrintFightresult(Fight(collider), collider);
                        collider.PrintFightresult(collider.Fight(this), this);
                        this.PrintUnitInfo();
                        collider.PrintUnitInfo();
                        this.xCordinate++;
                        break;
                    }
                }
            case ConsoleKey.RightArrow:
                this.xCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    var collider = this.GetCollider();
                    if (collider is Wall)
                    {
                        this.xCordinate--;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 1);
                        PrintFightresult(Fight(collider), collider);
                        collider.PrintFightresult(collider.Fight(this), this);
                        this.PrintUnitInfo();
                        collider.PrintUnitInfo();
                        this.xCordinate--;
                        break;
                    }
                    ;
                }
            case ConsoleKey.DownArrow:
                this.yCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    var collider = this.GetCollider();
                    if (collider is Wall)
                    {
                        this.yCordinate--;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 1);
                        PrintFightresult(Fight(collider), collider);
                        collider.PrintFightresult(collider.Fight(this), this);
                        this.PrintUnitInfo();
                        collider.PrintUnitInfo();
                        this.yCordinate--;
                        break;
                    }
                }
            default:
                break;
        }
    }
}
