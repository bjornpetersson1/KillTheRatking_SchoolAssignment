using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class Enemy : LevelElement
{
    public abstract string Name { get; }
    public abstract void Update(Player player);
}
