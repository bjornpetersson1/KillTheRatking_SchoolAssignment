using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Weapon:LevelElement
{
    public bool IsEquipped { get; set; }
    public Weapon()
    {
        IsEquipped = false;
    }
}
