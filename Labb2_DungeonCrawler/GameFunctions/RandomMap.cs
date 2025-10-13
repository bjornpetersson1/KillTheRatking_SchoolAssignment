using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler.GameFunctions;

public abstract class RandomMap : LevelElement
{
    //det här lär gå aatt göra om till en Enum
    private char player = '@';
    private char wall = '#';
    private char rat = 'r';
    private char ratKing = 'R';
    private char snake = 's';
    private Random random;

    public static void GenerateMap()
    {

    }
}
