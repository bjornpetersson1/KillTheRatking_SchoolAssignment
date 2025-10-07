using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Wall : LevelElement
{
    public override char Character { get; set; }
    public Wall()
    {
        this.Character = '#';
    }
    public override ConsoleColor MyColor { get { return ConsoleColor.Gray; } }
}


