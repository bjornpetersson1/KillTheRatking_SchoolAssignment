﻿using Labb2_DungeonCrawler.GameFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Player : LevelElement
{
    public ConsoleKey LastMove { get; set; }
    private Dictionary<ConsoleKey, int> playerDirection;
    public Player(string name = "player")
    {
        AttackDice = new Dice(6, 2, 2);
        DefenceDice = new Dice(6, 2, 0);
        HP = 100;
        XP = 0;
        Name = name;
        TurnsPlayed = 0;
        Symbol = '@';
        MyColor = ConsoleColor.White;
        LastMove = ConsoleKey.RightArrow;
        playerDirection = new Dictionary<ConsoleKey, int>();
        playerDirection.Add(ConsoleKey.UpArrow, -1);
        playerDirection.Add(ConsoleKey.LeftArrow, -1);
        playerDirection.Add(ConsoleKey.DownArrow, +1);
        playerDirection.Add(ConsoleKey.RightArrow, +1);
    }
    public override void PrintUnitInfo()
    {
        if (TurnsPlayed == 10 || TurnsPlayed == 100 || TurnsPlayed == 1000 || TurnsPlayed == 10000 || TurnsPlayed == 100000)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"|{Symbol}: {Name} | HP: {HP} | XP: {XP}| Attack: {AttackDice} | Defence: {DefenceDice} | Turn: {TurnsPlayed} |");
    }
    private void PlayerMoveMethod(ConsoleKeyInfo userMove)
    {
        int hold;
        LastMove = userMove.Key;
        if (userMove.Key == ConsoleKey.UpArrow || userMove.Key == ConsoleKey.DownArrow)
        {
            hold = this.yCordinate;
            this.yCordinate += playerDirection[userMove.Key];
        }
        else
        {
            hold = this.xCordinate;
            this.xCordinate += playerDirection[userMove.Key];
        }
        if (!this.IsSpaceAvailable())
        {
            CollideAndConcequences(this);
            if (userMove.Key == ConsoleKey.UpArrow || userMove.Key == ConsoleKey.DownArrow) this.yCordinate = hold;
            else this.xCordinate = hold;
        }
    }
    private void LazerShootMethod(ConsoleKey lastMove, int lazerLength)
    {
        if (lastMove == ConsoleKey.UpArrow || lastMove == ConsoleKey.DownArrow)
        {
            for (global::System.Int32 i = 1; i <= lazerLength; i++)
            {
                Lazer lazer = new Lazer() { yCordinate = this.yCordinate + playerDirection[lastMove]*i, xCordinate = this.xCordinate };
                if (lazer.IsSpaceAvailable()) LevelData.Elements?.Add(lazer);
                else
                {
                    lazer.CollideAndConcequences(this);
                    break;
                }
            }
        }
        else
        {
            for (global::System.Int32 i = 1; i <= lazerLength; i++)
            {
                Lazer lazer = new Lazer() { yCordinate = this.yCordinate, xCordinate = this.xCordinate + playerDirection[lastMove]*i };
                if (lazer.IsSpaceAvailable()) LevelData.Elements?.Add(lazer);
                else
                {
                    lazer.CollideAndConcequences(this);
                    break;
                }
            }
        }
    }
    public void Update(ConsoleKeyInfo userMove)
    {
        this.PrintUnitInfo();
        this.TurnsPlayed++;
        this.Erase();
        var lazers = (LevelData.Elements ?? Enumerable.Empty<LevelElement>()).OfType<Lazer>().ToList();
        if (LevelData.Elements != null) LevelData.Elements.RemoveAll(l => l is Lazer);
        foreach (var lazer in lazers)
        {
            lazer.Erase();
        }
        if (userMove.Key == ConsoleKey.Z)
        {
            LazerShootMethod(LastMove, 3);
        }
        else
        {
            PlayerMoveMethod(userMove);
        }
    }
}
