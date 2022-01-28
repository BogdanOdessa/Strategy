using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;
        [Inject] private IObservable<ISelectable> _selectedValues;
        [Inject] private IObservable<Vector3> _groundClicksRMB;
        [Inject] private CommandButtonsModel _model;
        [Inject] private SelectableValue _selectedObject;
        private ISelectable _currentSelectable;
        private GameObject _gameObject;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            _groundClicksRMB.Subscribe(OnRightClicked);
            _selectedValues.Subscribe(ONSelected);
        }
        private void OnRightClicked(Vector3 value)
        {
            var queue = _selectedObject.CurrentValue.GameObject.GetComponentInParent<ICommandsQueue>();
            queue?.EnqueueCommand(new MoveCommand(value));
        }
        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
                _view.MakeLayout(commandExecutors, queue);
            }
        }
    }
}