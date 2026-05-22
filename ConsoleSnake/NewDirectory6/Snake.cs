using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSnake.NewDirectory3;
using ConsoleSnake.NewDirectory4;
using ConsoleSnake.NewDirectory5;

namespace ConsoleSnake.NewDirectory6;
public enum E_Diretion
{
    N,
    S,
    W,
    E
}
//Snake是整条蛇，包含蛇头、蛇身，整体用SnakeBody数组存，蛇的每个部分都有坐标值
class Snake:IDraw
{
    SnakeBody[] bodys;
   //记录蛇的当前总长度，因为bodys.Length是最大长度，不是当前长度
    int nowLength;

    E_Diretion dir;
    
    //传入的是蛇头的坐标
    public Snake(int x, int y)
    {
        //蛇的身子最大不过是整个地图格子的空间
        //w/2是横墙的个数，w/2-2是内部的横长度
        // 总高度是h个，少画头和尾就是h-2
        bodys = new SnakeBody[(Game.w/2-2)*(Game.h-2)];
        //先把蛇头信息存进bodys[0]里面，身体放在数组序列0后面
        bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
        nowLength = 1;
        dir = E_Diretion.E;
    } 
    
    //这里其实也可以不用继承IDraw，反正Draw也没有实现，重点是用SnakeBody里面的IDraw
    public void Draw()
    {
        for (int i = 0; i < nowLength; i++)
        {
            bodys[i].Draw();
        }
    }

    public bool CheckEnd()
    {
        //老师的算法是传入地图，遍历地图的所有格子，如果蛇头的位置和地图格子的x、y坐标重合则游戏结束
        //我觉得这种方法不好，如果地图格子多比较大的话不太方便，我直接判断蛇头的x和y是否超过一个特定的范围，如果超过游戏直接结束，这样不是更高效吗
        if (bodys[0].pos.x<2 //这里为啥不写x<=2是因为x=2时恰好是墙壁内的光标范围
            ||bodys[0].pos.x>=Game.w
            ||bodys[0].pos.y==0||bodys[0].pos.y==Game.h-2)
        {
            return true;
        }
        //撞身体的机制,只有蛇头的时候，nowlength=1，没法进入循环
        for (int i = 1; i < nowLength; i++)
        {
            if (bodys[0].pos==bodys[i].pos)
            {
                return true;
            }
        }

        return false;
    }
    #region 蛇的移动
    public void Move()
    {
        //移动前擦除前一次移动的最后一个蛇位置,-1是因为序列从0开始
        SnakeBody lastBody = bodys[nowLength - 1];
        Console.SetCursorPosition(lastBody.pos.x,lastBody.pos.y);
        Console.Write("  ");
        //在蛇头移动之前，从蛇尾开始不停的让后一个位置等于前一个位置
        //从尾往前遍历，蛇头不用
        for (int i = nowLength - 1; i > 0; i--)
        {
            //前一节身体的坐标对象赋给后一节引用对象
            bodys[i].pos = bodys[i - 1].pos;
            //前一个坐标往后传递，最后的坐标对象被抛弃
        }
        switch (dir)
        {
            //为啥贪吃蛇的移动里，只有蛇头是在动的，蛇身不是也跟着动了吗
            //当蛇头和墙壁重合时，游戏结束，因此不需要在这里进行边界判断
            case E_Diretion.N:
                --bodys[0].pos.y;
                break;
            case E_Diretion.S:
                ++bodys[0].pos.y;
                break;
            case E_Diretion.W:
                bodys[0].pos.x -= 2;
                break;
            case E_Diretion.E:
                bodys[0].pos.x += 2;
                break;
        }
    }
    #endregion

    #region 改变方向

    public void ChangeDir(E_Diretion dir)
    {
        //转向分为两种情况，有身体和无身体，没有身体只有一个头怎么转向都行
        //有身体的话，蛇头不能转向和自己当前方向相反的方向
        if (dir ==this.dir)//已经和当前方向一样的不用转,有身体的不方便转，没身体随便转
        {
            return;
        }
        if (nowLength>1)//有身体才不能随便转
        {
            if (this.dir == E_Diretion.E && dir == E_Diretion.W)
            {
                return;
            }
            else if (this.dir == E_Diretion.W && dir == E_Diretion.E)
            {
                return;
            }
            else if (this.dir == E_Diretion.N && dir == E_Diretion.S)
            {
                return;
            }
            else if (this.dir == E_Diretion.S && dir == E_Diretion.N)
            {
                return;
            }
        }

        //如果满足情况直接赋值
        this.dir = dir;
    }
    #endregion

    #region 吃食物相关
    //判断位置是不是和蛇位置重合
    public bool CheckSamePos(Position p)
    {
        for (int i = 0; i < nowLength; i++)
        {
            if (bodys[i].pos == p)
            {
                return true;
            }
        }
        return false; 
    }
    //p是食物的坐标,吃食物的逻辑也是每帧检测，因此命名Check
    public void CheckEatFood(Food food)
    {
        if (bodys[0].pos == food.pos)
        {
            food.RandomPos(this);
           //只有在吃食物的时候增长身体
           AddBody();
        }
        
    }
    #endregion

    #region 长身体
    private void AddBody()
    {
        //获得上一节身体的位置信息，第一次吃的时候，蛇头的坐标给了蛇身
        SnakeBody frontBody = bodys[nowLength - 1];
        //先长
        bodys[nowLength] = new SnakeBody(E_SnakeBody_Type.Body,frontBody.pos.x,frontBody.pos.y);
        //再加长度
        ++nowLength;
    }

    #endregion
}