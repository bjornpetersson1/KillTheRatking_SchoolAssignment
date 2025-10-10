using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Player : LevelElement
{
    public ConsoleKey LastMove { get; set; }
    public Player(string name = "player")
    {
        this.AttackDice = new Dice(6, 2, 2);
        this.DefenceDice = new Dice(6, 2, 0);
        this.HP = 100;
        this.XP = 0;
        this.Name = name;
        this.TurnsPlayed = 0;
        this.Character = '@';
        this.MyColor = ConsoleColor.White;
        this.LastMove = ConsoleKey.RightArrow;
    }
    public override void PrintUnitInfo()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"|{Character}: {Name} | HP: {HP} | XP: {XP}| Attack: {AttackDice} | Defence: {DefenceDice} | Turn: {TurnsPlayed} |");
    }
    public void Update()
    {
        this.PrintUnitInfo();
        this.TurnsPlayed++;
        ConsoleKeyInfo userMove = Console.ReadKey(true);
        this.Erase();
        var lazers = LevelData.Elements.OfType<Lazer>().ToList();
        LevelData.Elements.RemoveAll(l => l is Lazer);
        foreach (var lazer in lazers)
        {
            lazer.Erase();
        }
        switch (userMove.Key)
        {
            case ConsoleKey.UpArrow:
                this.yCordinate--;
                LastMove = ConsoleKey.UpArrow;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.yCordinate++;
                    break;
                }
            case ConsoleKey.LeftArrow:
                this.xCordinate--;
                LastMove = ConsoleKey.LeftArrow;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.xCordinate++;
                    break;
                }
            case ConsoleKey.RightArrow:
                this.xCordinate++;
                LastMove = ConsoleKey.RightArrow;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.xCordinate--;
                    break;
                }
            case ConsoleKey.DownArrow:
                this.yCordinate++;
                LastMove = ConsoleKey.DownArrow;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    CollideAndConcequences();
                    this.yCordinate--;
                    break;
                }
            case ConsoleKey.Z:
                switch(LastMove)
                {
                    case ConsoleKey.UpArrow:
                        for (global::System.Int32 i = 1; i <= 4; i++)
                        {
                            Lazer lazer = new Lazer() { yCordinate = this.yCordinate - i, xCordinate = this.xCordinate };
                            if (lazer.IsSpaceAvailable()) LevelData.Elements.Add(lazer);
                            else
                            {
                                lazer.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        for (global::System.Int32 i = 1; i <= 4; i++)
                        {
                            Lazer lazer = new Lazer() { yCordinate = this.yCordinate + i, xCordinate = this.xCordinate };
                            if (lazer.IsSpaceAvailable()) LevelData.Elements.Add(lazer);
                            else
                            {
                                lazer.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        for (global::System.Int32 i = 1; i <= 4; i++)
                        {
                            Lazer lazer = new Lazer() { yCordinate = this.yCordinate, xCordinate = this.xCordinate - i };
                            if (lazer.IsSpaceAvailable()) LevelData.Elements.Add(lazer);
                            else
                            {
                                lazer.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        for (global::System.Int32 i = 1; i <= 4; i++)
                        {
                            Lazer lazer = new Lazer() { yCordinate = this.yCordinate, xCordinate = this.xCordinate + i };
                            if (lazer.IsSpaceAvailable()) LevelData.Elements.Add(lazer);
                            else
                            {
                                lazer.CollideAndConcequences();
                                break;
                            }
                        }
                        break;
                }
                break;

            default:
                break;
        }
    }
}
