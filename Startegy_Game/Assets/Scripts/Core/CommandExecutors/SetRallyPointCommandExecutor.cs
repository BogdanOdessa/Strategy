using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.Commands;
using UnityEngine;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>, ICommandExecutor
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
    {
       var rallyPoint = GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
        Debug.Log("Rally point = " + rallyPoint);
    }
}
