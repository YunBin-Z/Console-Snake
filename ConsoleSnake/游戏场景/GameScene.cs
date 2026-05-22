//  
// namespace ConsoleSnake;
//
// public class GameScene:ISceneUpdate
// {
//     public void print()
//     {
//         
//     }
//
//     /// <summary>
//     /// 画不变的红墙
//     /// </summary>
//     /// <param name="x">墙的长度</param>
//     /// <param name="y">墙的高度</param>
//     public void RedWall(int x,int y)
//     {
//         //把光标放在起始点开始画
//         Console.SetCursorPosition(0,0);
//         //调整画笔的颜色为红色
//         Console.ForegroundColor =ConsoleColor.Red;
//         for (int i = 0; i < y; i++)
//         {
//             for (int j = 0; j < x ; j+=2)
//             {
//                 //中文字符横着占两个格子，竖着占一个格子
//                 //所以得横着间隔着打
//                 if (i!=0 || i !=y-1)
//                 {
//                     //画中间的墙
//                     Console.SetCursorPosition(0,j);
//                     Console.Write("◼︎");
//                     Console.SetCursorPosition(x-2,j);
//                     Console.Write("◼︎");
//                 }
//                 else//画开头和最后的横着的墙
//                 {
//                     Console.SetCursorPosition(i,j);
//                     Console.Write("◼︎");
//                 }
//             }
//         }
//     }
// //蛇头得调用多次，蛇头和蛇身是一个数组行不行，毕竟得位置交换,蛇头和蛇身用一个结构体表示吧，每个结构体都有自己的位置坐标，
// //这个数组得多次增加怎么办，同样面临string的困境啊，多次gc不好吧
//
//     public void Snake_head()
//     {
//         Snake snake_head = new Snake();
//     }
//
//     public void Snake_body()
//     {
//         
//     }
//    
//     //画蛇
//     //画食物
//     
//     
// }