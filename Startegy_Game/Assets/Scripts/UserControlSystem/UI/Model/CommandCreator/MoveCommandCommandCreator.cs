using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

public class MoveCommandCommandCreator :  CommandCreatorBase<IMoveCommand>
{

    [Inject] private AssetsContext _context;
    private Action<IMoveCommand> _creationCallback;

    [Inject]
    private void Init(Vector3Value groundClicks) => groundClicks.OnNewValue += ONNewValue;

    private void ONNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
        _creationCallback = null;
    }

    protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationCallback = null;
    }
}
