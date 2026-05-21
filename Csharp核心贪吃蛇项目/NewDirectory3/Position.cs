using System;

namespace Csharp核心贪吃蛇项目.NewDirectory3;

struct Position
{
      public int x;
      public int y;

      public Position(int a, int b)
      {
            x = a;
            y = b;
      }
      //贪吃蛇中肯定涉及到位置的比较，那这个就涉及到两个结构体之间的行为，结构体在定义的时候不能声明结构体
      //原来运算符重载是可以
      public static bool operator ==(Position p1, Position p2)
      {
            if (p1.x ==p2.x && p1.y ==p2.y)
            {
                  return true;
            }
            return false;
      }

      public static bool operator !=(Position p1, Position p2)
      {
            if (p1.x ==p2.x && p1.y ==p2.y)
            {
                  return false;
            }
            return true;
      }
}