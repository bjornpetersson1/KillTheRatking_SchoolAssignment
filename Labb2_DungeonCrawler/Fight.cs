using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class Combat:LevelElement
{
    public LevelElement Enemy { get; set; }
    protected Combat(LevelElement enemy)
    {
        this.Enemy = enemy;
    }
    public int Attack()
    {
        int attack = this.AttackDice.Throw();
        int defence = Enemy.DefenceDice.Throw();
        int result = attack - defence;
        if (result > 0)
        {
            Enemy.HP -= (result);
            return result;
        }
        else return -1;
    }
    public int Fight()
    {

        if (this.Enemy != this && (this.Enemy is Enemy || this.Enemy is Player))
        {
            return this.Attack();
        }
        else return -1;
    }
    public void PrintFightresult(int fightreturn)
    {
        if (fightreturn != -1)
        {
            Console.WriteLine($"{this.Name} attacked {Enemy.Name} with {this.AttackDice} and {Enemy.Name} defended with {Enemy.DefenceDice}. Attack was successfull and did {fightreturn} damage");
        }
        else Console.WriteLine($"{this.Name} attacked {Enemy.Name} with {this.AttackDice} and {Enemy.Name} defended with {Enemy.DefenceDice}. Attack failed and did no damage");
    }
}
