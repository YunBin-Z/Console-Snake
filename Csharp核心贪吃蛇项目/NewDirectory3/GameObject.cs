using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心贪吃蛇项目.NewDirectory3;

abstract class GameObject:IDraw
{
    public Position pos;
    //可以继承接口后 把接口中的行为 设定为抽象行为，转嫁给子类去实现
    public abstract void Draw();
}
