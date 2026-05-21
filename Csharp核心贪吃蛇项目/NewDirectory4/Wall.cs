using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp核心贪吃蛇项目.NewDirectory3;

namespace Csharp核心贪吃蛇项目.NewDirectory4;
    class Wall:GameObject
{
    public Wall(int x, int y)
    {
        pos = new Position(x, y);
    }
    public override void Draw()
    {
        Console.SetCursorPosition(pos.x,pos.y);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("◼︎");
    }
}