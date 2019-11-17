using UnityEngine;

public class PlayerCommand : BaseCommand
{
    public Player commandTarget;
    public Vector3 newTrans;
    public Vector3 oldTrans;

    public PlayerCommand(Player commandTarget, Vector3 oldPos,Vector3 newPos)
    {
        this.commandTarget = commandTarget;
        this.newTrans = newPos;
        this.oldTrans = oldPos;
    }

    public override void ExecuteCommand()
    {
        base.ExecuteCommand();
        commandTarget.transform.position = newTrans;
    }
    public override void RemoveCommand()
    {
        base.RemoveCommand();
        commandTarget.transform.position = oldTrans;
    }

    public override void CancleCommand()
    {
        base.CancleCommand();
        commandTarget.transform.position = newTrans;
    }
}
