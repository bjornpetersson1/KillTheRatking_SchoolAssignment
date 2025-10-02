using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;
public class Snake : Enemy
{
    public override string Name { get { return "snake"; } }

    public override char Character { get { return 's'; } }

    public override ConsoleColor MyColor { get { return ConsoleColor.Yellow; } }

    public override void Update()
    {
        //TODO fixa ormens updatemetod
    }
}
