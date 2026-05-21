using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心贪吃蛇项目.NewDirectory2;

 class BeginScene:BeginOrEndBaseScene
{
    public BeginScene()
    {
        strTitle ="贪吃蛇";
        strOne ="开始游戏";
    }
    public override void EnterDoSomething()
    {
        //按Enter键做什么的逻辑
        if (nowSelIndexl == 0)
        {
            Game.ChangeScene(E_SceneType.Gaming);
        }
        else
        {
            Environment.Exit(0);
        }
    }
}