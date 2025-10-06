using Labb2_DungeonCrawler;

public abstract class LevelElement
{
    public int xCordinate { get; set; }
    public int yCordinate { get; set; }
    public int XP { get; set; }
    public virtual char Character { get; }
    public virtual ConsoleColor MyColor { get; }
    public virtual Dice AttackDice { get; set; }
    public virtual Dice DefenceDice { get; set; }
    public virtual int HP { get; set; }
    public virtual string Name { get; set; }


    public virtual void PrintUnitInfo() { }
    public void Draw()
    {
        Console.SetCursorPosition(xCordinate, yCordinate);
        Console.ForegroundColor = MyColor;
        Console.Write(Character);
    }
    public void Erase()
    {
        Console.SetCursorPosition(this.xCordinate, this.yCordinate);
        Console.Write(' ');
    }
    public double GetDistanceTo(Player player)
    {
        return Math.Sqrt(Math.Abs(Math.Pow(this.yCordinate - player.yCordinate, 2) + Math.Abs(Math.Pow(this.xCordinate - player.xCordinate, 2))));
    }
    public bool IsSpaceAvailable()
    {
        CoOrdinate targetSpace = new CoOrdinate(this);

        return !LevelData.Elements.Any(k => k != this && k.yCordinate == targetSpace.YCord && k.xCordinate == targetSpace.XCord);
    }
    public void CollideAndConcequences()
    {
        var collider = this.GetCollider();
        if (collider is not Wall && !(collider is Enemy && this is Enemy))
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 1);
            PrintFightresult(Fight(collider), collider);
            collider.PrintFightresult(collider.Fight(this), this);
            this.PrintUnitInfo();
            collider.PrintUnitInfo();
        }
    }
    public LevelElement GetCollider()
    {
        CoOrdinate targetSpace = new CoOrdinate(this);
        return LevelData.Elements.FirstOrDefault(k => k != this && k.xCordinate == targetSpace.XCord && k.yCordinate == targetSpace.YCord);
    }
    public int Attack(LevelElement enemy)
    {
        int attack = this.AttackDice.Throw();
        int defence = enemy.DefenceDice.Throw();
        int result = attack - defence;

        if (result > 0)
        {
            enemy.HP -= (result);
            return result;
        }
        else return -1;
    }
    public int Fight(LevelElement enemy)
    {

        if (enemy != this && (enemy is Enemy || enemy is Player))
        {
            return this.Attack(enemy);
        }
        else return -1;
    }
    public void PrintFightresult(int fightreturn, LevelElement enemy)
    { 
        if (fightreturn != -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack was successfull and did {fightreturn} damage");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack failed and did no damage");
        }
    }

}