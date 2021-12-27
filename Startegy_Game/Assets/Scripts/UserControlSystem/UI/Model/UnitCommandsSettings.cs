using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = nameof(UnitCommandsSettings), 
    menuName = "Strategy Game/" + nameof(UnitCommandsSettings), order = 0)]
public class UnitCommandsSettings : ScriptableObject
{
    [field: SerializeField] public Vector3 MoveDestination { get; private set; }
    [field: SerializeField] public Vector3 PatrolDestination { get;  private set;}
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed { get;  private set;}
}
