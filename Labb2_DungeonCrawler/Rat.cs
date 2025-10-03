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
    private Random random;
    public Rat()
    {
        random = new Random();
    }

    public override void Update()
    {
        //TODO fixa råttans updatemetod
        int move = random.Next(4);
        switch(move)
        {
            case 0:
                this.xCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.xCordinate++;
                    break;
                }
                break;
            case 1:
                this.xCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.xCordinate--;
                    break;
                }
                break;
            case 2:
                this.yCordinate--;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.yCordinate++;
                    break;
                }
                break;
            case 3:
                this.yCordinate++;
                if (this.IsSpaceAvailable()) break;
                else
                {
                    this.yCordinate--;
                    break;
                }
                break;
        }    
    }
}
