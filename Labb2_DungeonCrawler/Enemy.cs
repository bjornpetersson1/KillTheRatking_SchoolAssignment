using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class Enemy : LevelElements
{
    public abstract string Name { get; }
    public int HP { get; set; }
    //TODO: lägg till tärningar
    public abstract void Update();
}
