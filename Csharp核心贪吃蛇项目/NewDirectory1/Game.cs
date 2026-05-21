using Csharp核心贪吃蛇项目.NewDirectory2;

namespace Csharp核心贪吃蛇项目;

public enum E_SceneType
{
    Begin,
    Gaming,
    End
}
public class Game
{
    public const int w = 80;
    public const int h = 20;
    
    //当前选中的场景
     static public ISceneUpdate nowScene;
    //当前场景怎么和游戏接口绑定，让游戏场景类实现游戏帧更新接口，
    //然后什么时候进行游戏场景的切换能让帧更新的调用出现不同呢

    public  Game()
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(w, h);
        ChangeScene(E_SceneType.Begin);
    }

    //游戏场景怎么切换啊！！！！
    //没完没了的套娃烦死了啊！！我知道了，把一件大事做成功的秘诀就是切分成无数件小事
    public static void ChangeScene(E_SceneType type)
    {
        //少了一步清空控制台
        Console.Clear();
        switch (type)
        {
            case E_SceneType.End:
                //调用结束场景类的print画法
                nowScene = new EndScene();
                break;
            case E_SceneType.Begin:
                //调用开始场景类的print画法
                nowScene = new BeginScene();
                break;
            case E_SceneType.Gaming:
                //调用游戏场景类的print画法
                nowScene = new GameScene();
                break;
        }
    }

    public void GameLoop()
    {
        //游戏主循环 主要负责 游戏场景逻辑的更新
        while (true)
        {
            if (nowScene != null)
            {
                nowScene.Update();
            }
            //调用游戏帧更新接口
        }
    }
    //现在要干什么事？
        //画地图
        //写完成场景切换
        //画蛇
        //画食物
        //完成自动行走机制，怎么样每帧刷新？
        //角色行走
        //接口看来要大做文章，接口必须先预测下一帧要干啥，然后才能画出具体的画面，
        //地图要判断是不是要切换，初始默认是游戏选择界面，然后是游戏界面，蛇最后是游戏结束界面，
        //我好像可以根据吃的食物来生成一个分数，游戏结束的时候生成这个分数，
        //蛇要判断是不是蛇头撞墙或者蛇头撞身体
        //蛇的身体要运动，怎么运动啊，这个运动规律不好整
        //食物必须随机刷新在地图范围内
        //场景不同，画面更新的规则也不同
        //怪不得这里的场景id用接口表示，场景用接口表示，更新下一帧的时候就可以调用当前场景的更新画图方法
        //现在我该干嘛？脑子好乱

    
}