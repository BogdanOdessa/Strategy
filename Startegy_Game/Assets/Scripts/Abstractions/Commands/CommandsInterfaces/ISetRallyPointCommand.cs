using System.Collections;
using System.Collections.Generic;
using Abstractions.Commands;
using UnityEngine;

public interface ISetRallyPointCommand : ICommand
{
    Vector3 RallyPoint { get; }
}