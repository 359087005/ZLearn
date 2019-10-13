
/// <summary>
/// 命令模式 把所有的操作封装成为对象
/// </summary>
public class BaseCommand 
{
    public virtual void ExecuteCommand()
    { }

    public virtual void RemoveCommand() { }

    public virtual void CancleCommand() { }
}
