using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;

public class SetRallyPointCommandCreator : CancellableCommandCreatorBase<ISetRallyPointCommand,Vector3>
{
    protected override ISetRallyPointCommand CreateCommand(Vector3 argument) => new SetRallyPointCommand(argument);
}
