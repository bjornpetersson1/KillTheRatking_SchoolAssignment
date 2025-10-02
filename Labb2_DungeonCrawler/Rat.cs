using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public class Rat : Enemy
{
    public override string Name { get { return "rat"; } }

    public override char Character { get { return 'r'; } }

    public override ConsoleColor MyColor { get { return ConsoleColor.Red; } }

    public override void Update()
    {
        //TODO fixa råttans updatemetod
    }
}
