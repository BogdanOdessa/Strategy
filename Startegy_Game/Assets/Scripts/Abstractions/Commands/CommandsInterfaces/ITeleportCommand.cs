using System.Collections;
using System.Collections.Generic;
using Abstractions.Commands;
using UnityEngine;

public interface ITeleportCommand : ICommand
{
    public Vector3 Target { get; }
}
