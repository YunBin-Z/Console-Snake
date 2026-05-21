namespace Csharp核心贪吃蛇项目;


class Program
{
    static void Main(string[] args)
    {
        //实例化游戏场景类和开始和结束场景基类
        Game game = new Game();
        game.GameLoop();
    }
}