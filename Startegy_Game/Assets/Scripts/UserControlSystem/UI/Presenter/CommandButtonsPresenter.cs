using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;
        [SerializeField] private UnitCommandsSettings _unitCommandsSettings;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var unitMoveExecutor = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (unitMoveExecutor != null)
            {
                unitMoveExecutor.ExecuteSpecificCommand(new MoveCommand(_unitCommandsSettings.MoveDestination));
                return;
            }
            
            var unitAttackExecutor = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (unitAttackExecutor != null)
            {
                unitAttackExecutor.ExecuteSpecificCommand(new AttackCommand(_unitCommandsSettings.Damage));
                return;
            }
            
            var unitStopExecutor = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (unitStopExecutor != null)
            {
                unitStopExecutor.ExecuteSpecificCommand(new StopCommand(_unitCommandsSettings.Speed));
                return;
            }
            
            var unitPatrolExecutor = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (unitPatrolExecutor != null)
            {
                unitPatrolExecutor.ExecuteSpecificCommand(new PatrolCommand(_unitCommandsSettings.PatrolDestination));
                return;
            }
            
            
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}