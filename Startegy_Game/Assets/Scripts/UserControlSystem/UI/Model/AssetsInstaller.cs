using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = nameof(AssetsInstaller),
    menuName = "Strategy Game/" + nameof(AssetsInstaller), order = 0)]
public class AssetsInstaller : ScriptableObjectInstaller
{
    [field:SerializeField] public SelectableValue _selectableValue { get; private set; }
    [field:SerializeField] public AttackableValue _attackableValue{ get; private set; }
    [field:SerializeField] public Vector3Value _groundClickValue{ get; private set; }
    [field:SerializeField] public AssetsContext _assetsContext{ get; private set; }
    [field:SerializeField] public UnitCommandsSettings _unitCommandsSettings{ get; private set; }

    public override void InstallBindings()
    {
        
    }
}
