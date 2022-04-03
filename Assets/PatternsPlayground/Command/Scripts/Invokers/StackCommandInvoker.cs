using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCommandInvoker
{
    private Stack<ICommand> _commands = new Stack<ICommand>();

    public void AddAndExecuteCommand(ICommand command)
    {
        _commands.Push(command);
        command.Execute();
    }

    public void CancelLast()
    {
        _commands.Pop().Undo();
    }

    public void CancelManyLast(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (_commands.Count > 0)
            {
                _commands.Pop().Undo();
            }
        }
    }
}
