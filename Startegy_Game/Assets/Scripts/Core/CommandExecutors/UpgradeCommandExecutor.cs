using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.Commands;
using Core;
using Core.UpgradeCommand;
using UnityEngine;

public class UpgradeCommandExecutor : CommandExecutorBase<IUpgradeCommand>, ICommandExecutor
{
    public bool ChomperIsUpgraded { get; private set; }
    public override async Task ExecuteSpecificCommand(IUpgradeCommand command)
    {
        if (!ChomperIsUpgraded)
        {
            ChomperIsUpgraded = true;
            var chompers = FindObjectsOfType<Unit>();
            foreach (var chomper in chompers)
            {
                chomper.GameObject.GetComponent<IUpgradable>().IncreaseAttack();
            }
        }
        else
        {
            Debug.Log("Upgrade is already completed!");
        }
    }
    public void UpgradeUnit(IUpgradable unit)
    {
        unit.IncreaseAttack();
    }
}
