using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_DungeonCrawler;

public abstract class LevelData : LevelElement
{
	private static List<LevelElement> _elements;

	public static List<LevelElement> Elements
	{
		get { return _elements; }
	}
	public static void Load(string fileName)
	{
        int row = 4;
        _elements = new List<LevelElement>();
        foreach (var line in File.ReadAllLines(fileName))
        {
            for (global::System.Int32 i = 0; i < line.Length; i++)
            {
                switch(line[i])
                {
                    case '#':
                        _elements.Add(new Wall() { yCordinate = row, xCordinate = i });
                        break;
                    case '@':
                        _elements.Add(new Player() { yCordinate = row, xCordinate = i });
                        break;
                    case 'r':
                        _elements.Add(new Rat() { yCordinate = row, xCordinate = i });
                        break;
                    case 's':
                        _elements.Add(new Snake() { yCordinate = row, xCordinate = i });
                        break;
                    default:
                        break;
                }
            }
            row++;
        }
    }

}
