using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCommand : BaseCommand
{

    private InputField commandTarget;
    string newValue;
    string oldValue;

    public InputCommand(InputField commandTarget, string value,string oldValue)
    {
        this.commandTarget = commandTarget;
        this.newValue = value;
        this.oldValue = oldValue;
    }

    public override void ExecuteCommand()
    {
        base.ExecuteCommand();
        commandTarget.text = newValue;
    }

    public override void RemoveCommand()
    {
        base.RemoveCommand();
        commandTarget.text = newValue;
    }

    public override void CancleCommand()
    {
        base.CancleCommand();
        commandTarget.text = oldValue;
    }
}
