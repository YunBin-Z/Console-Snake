using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSnake.NewDirectory4;
using ConsoleSnake.NewDirectory5;
using ConsoleSnake.NewDirectory6;

namespace ConsoleSnake.NewDirectory2;

public class GameScene:ISceneUpdate
{
     Map map;
     private Snake snake;
      Food food;
     int updateIndex = 0;

     public GameScene()
     {
         map = new Map();
         snake = new Snake(40,10);
         food = new Food(snake);
     }
     
    public void Update()
    {
        //目前来说蛇动的太快了，没有学过多线程，只能用笨办法计数来等待
        //蛇头跑出地图外，蛇头会在第一道围墙上闪烁，其实就是报错了
        if (updateIndex %14454 ==0)
        {
            map.Draw();
            //食物不能每一次计数都画一遍，只有蛇移动的时候画一遍
            //吃的时候那次计数就把食物坐标给改变了
            food.Draw();
            //先动再画的目的是为了先得到坐标，再根据坐标画
            snake.Move();
            snake.Draw();
            
            //检测是否撞墙或者撞身体
            if (snake.CheckEnd())
             {
                //结束逻辑
                Game.ChangeScene(E_SceneType.End);
            }
                snake.CheckEatFood(food);//这里既生成食物，又增加身体
            //不用擦除食物的原因是，最后画蛇头，蛇头会把食物覆盖，蛇头走之后蛇会自己擦掉轨迹
            //蛇吃完食物之后食物会有新的位置，第二帧的时候就会重新
            updateIndex = 0;
        }
        updateIndex++;
        if (Console.KeyAvailable)
        {
            //检测输入输出 不希望在间隔帧中检测，应该每一帧都检测才准确
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    snake.ChangeDir(E_Diretion.N);
                    break;
                case ConsoleKey.A:
                    snake.ChangeDir(E_Diretion.W);
                    break;
                case ConsoleKey.S:
                    snake.ChangeDir(E_Diretion.S);
                    break;
                case ConsoleKey.D:
                    snake.ChangeDir(E_Diretion.E);
                    break;
            }
        }
      
    }
}