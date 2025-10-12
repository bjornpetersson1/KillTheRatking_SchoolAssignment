using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler.GameFunctions;

//public abstract class Character : LevelElement
//{
//    public int XP { get; set; }
//    public Dice AttackDice { get; set; }
//    public Dice DefenceDice { get; set; }
//    public int HP { get; set; }

//    public void CollideAndConcequences()
//    {
//        Character collider = this.GetCollider();
//        if ((collider is Character || collider is Weapon) && !(collider is Enemy && this is Enemy))//det här är fel logik
//        {
//            Console.SetCursorPosition(0, 1);
//            Console.Write(new string(' ', Console.WindowWidth));
//            Console.Write(new string(' ', Console.WindowWidth));
//            Console.SetCursorPosition(0, 1);
//            PrintFightresult(Fight(collider), collider);
//            if (collider.HP > 0) collider.PrintFightresult(collider.Fight(this), this);
//            this.PrintUnitInfo();
//            collider.PrintUnitInfo();
//        }
//    }
//    public Character GetCollider()
//    {
//        CoOrdinate targetSpace = new CoOrdinate(this);
//        return LevelData.Elements.OfType<Character>().FirstOrDefault(k => k != this && k.xCordinate == targetSpace.XCord && k.yCordinate == targetSpace.YCord);
//    }
//    public int Attack(Character enemy)
//    {
//        int attack = this.AttackDice.Throw();
//        int defence = enemy.DefenceDice.Throw();
//        int result = attack - defence;

//        if (result > 0)
//        {
//            enemy.HP -= (result);
//            return result;
//        }
//        else return -1;
//    }
//    public int Fight(Character enemy)
//    {

//        if (enemy != this && (enemy is Enemy || enemy is Player))
//        {
//            return this.Attack(enemy);
//        }
//        else return -1;
//    }
//    public void PrintFightresult(int fightreturn, Character enemy)
//    {
//        if (fightreturn != -1)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine($"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack was successfull and did {fightreturn} damage");
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack failed and did no damage");
//        }
//    }
//}
