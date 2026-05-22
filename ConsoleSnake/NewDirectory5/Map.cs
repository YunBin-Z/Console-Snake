using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSnake.NewDirectory3;
using ConsoleSnake.NewDirectory4;

namespace ConsoleSnake.NewDirectory5;

 class Map :IDraw
{
    private Wall[] walls;

    //如果类的成员是类类型的数组或者结构体类型数组，如何在构造函数中初始化它们
    public Map()
    {
        walls = new Wall[Game.w + (Game.h - 3) * 2];
        int index = 0;
        for (int i = 0; i < Game.w; i+=2)
        {
            walls[index] = new Wall(i, 0);
            index++;
            //y的坐标是从零开始的，长度最大是h-1，不能订满所以h-2
            walls[index] = new Wall(i,Game.h-2);
            index++;
        }
        
        //Game-2是因为画这么多次，上面减2是因为坐标
        for (int i = 1; i < Game.h-2; i++)
        {
            walls[index] = new Wall(0,i);
            index++;
            //y坐标是1到h-3
            walls[index] = new Wall(Game.w-2,i);
            index++;
        }
    }
    public void Draw()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].Draw();
        }
    }
}