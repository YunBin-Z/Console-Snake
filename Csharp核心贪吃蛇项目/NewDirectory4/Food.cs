using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp核心贪吃蛇项目.NewDirectory3;
using Csharp核心贪吃蛇项目.NewDirectory6;
namespace Csharp核心贪吃蛇项目.NewDirectory4;

  class Food:GameObject
{ 
    public Food(Snake snake)
    {
        //食物的位置得随机生成，不能和墙壁和蛇重合
       RandomPos(snake);
    }
    public override void Draw()
    {
      Console.SetCursorPosition(pos.x,pos.y);
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("🐭");
    }
    //得到随机位置，给食物位置初始化，食物的位置得多次变化，也就是多次初始化感觉不用构造函数好点
    public void RandomPos(Snake snake)
    {
        Random r = new Random();
        int x = r.Next(2, Game.w/2 - 1)*2;
        int y = r.Next(1, Game.h - 4);
        //将食物坐标确定
        pos= new Position(x, y);
        
        // 如果食物的位置和蛇重合，就递归重新跑一遍生成逻辑，如果坐标位置不相同就不会发生任何问题
        if (snake.CheckSamePos(pos))
        {
            RandomPos(snake);
        }
    }
}