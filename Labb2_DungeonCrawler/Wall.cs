using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Wall : LevelElement
{
    public Wall()
    {
        this.Character = '#';
        this.MyColor = ConsoleColor.Gray;
    }

}


