using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp核心贪吃蛇项目.NewDirectory3;

namespace Csharp核心贪吃蛇项目.NewDirectory4;

enum E_SnakeBody_Type
{
   Head,
   Body
}
 class SnakeBody :GameObject
 {
     private E_SnakeBody_Type type;

     public SnakeBody(E_SnakeBody_Type type, int a, int b)
     {
         this.type = type;
         pos = new Position(a, b);
     }
      
     public override void Draw()
      {
         Console.SetCursorPosition(pos.x,pos.y);
         Console.ForegroundColor = type == E_SnakeBody_Type.Body ? ConsoleColor.Yellow : ConsoleColor.White;
         Console.Write(type==E_SnakeBody_Type.Body?"●":"🦄");
      }
}