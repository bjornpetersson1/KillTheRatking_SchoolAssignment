using Labb2_DungeonCrawler;

public abstract class LevelElement
{
    public int xCordinate { get; set; }
    public int yCordinate { get; set; }
    public virtual char Character { get; }
    public virtual ConsoleColor MyColor { get; }
    public virtual Dice AttackDice { get; set; }
    public virtual Dice DefenceDice { get; set; }
    public virtual int HP { get; set; }
    public virtual string Name { get; }

    public void Draw()
    {
        Console.SetCursorPosition(xCordinate, yCordinate);
        Console.ForegroundColor = MyColor;
        Console.Write(Character);
    }
    public LevelElement UnitCollide()
    {
        CoOrdinate targetSpace = new CoOrdinate(this);
        return LevelData.Elements.Where(e => e is Player || e is Enemy).FirstOrDefault(e => e.xCordinate == targetSpace.XCord && e.yCordinate == targetSpace.YCord);
    }
    public bool IsSpaceAvailable()
    {
        CoOrdinate targetSpace = new CoOrdinate(this);

        return !LevelData.Elements.Any(k => k != this && k.yCordinate == targetSpace.YCord && k.xCordinate == targetSpace.XCord);
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
    public string Attack(LevelElement enemy)
    {
        int attack = this.AttackDice.Throw();
        int defence = enemy.DefenceDice.Throw();
        if (attack > defence)
        {
            enemy.HP -= (attack - defence);
            return $"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack was successfull and did {attack-defence} damage";
        }
        else return $"{this.Name} attacked {enemy.Name} with {this.AttackDice} and {enemy.Name} defended with {enemy.DefenceDice}. Attack failed and did no damage"; ;
    }

}