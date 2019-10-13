using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMgr 
{
    // A->B-C->D   回退D->C->B->A
    public Stack<BaseCommand> backCommands;
    //撤销后退
    public Stack<BaseCommand> cancleCommands;

    //构造时初始化2个栈
    public CmdMgr()
    {
        backCommands = new Stack<BaseCommand>();
        cancleCommands = new Stack<BaseCommand>();
    }
    //打算留作最开始场景初始化时候使用  未使用
    public void AddStack(BaseCommand command)
    {
        backCommands.Push(command);
    }
    //入栈   把命令压进  后退栈
    public void Execute(BaseCommand command)
    {
        if(cancleCommands.Count!=0)
        cancleCommands.Clear();

        backCommands.Push(command);
        command.ExecuteCommand();
    }
    //后退栈取出  撤销后退栈压入
    public void BackCommand()
    {
        if (backCommands.Count!=0)
        {
            BaseCommand command = backCommands.Pop();
            command.RemoveCommand();
            cancleCommands.Push(command);
        }
    }
    //撤销后退栈取出   后退栈压入
    public void CancleCommand()
    {
        if (cancleCommands.Count != 0)
        {
            BaseCommand command = cancleCommands.Pop();
            command.CancleCommand();

            backCommands.Push(command);
        }
    }
}
