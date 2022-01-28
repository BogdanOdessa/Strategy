using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRallyPointCommand : ISetRallyPointCommand
{
    public Vector3 RallyPoint { get; }

    public SetRallyPointCommand(Vector3 rallyPoint)
    {
        RallyPoint = rallyPoint;
    }
}

