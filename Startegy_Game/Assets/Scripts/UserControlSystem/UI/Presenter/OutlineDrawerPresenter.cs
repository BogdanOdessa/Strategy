using System;
using Abstractions;
using Assets.Scripts.UserControlSystem;
using UniRx;
using UnityEngine;
using UserControlSystem;
using Zenject;

namespace Assets.Scripts.UserControlSystem.Presenter
{
    public class OutlineDrawerPresenter : MonoBehaviour
    {
        [Inject] private IObservable<ISelectable> _selectedObject;
        
        private ISelectable _currentSelectable;
    
        private void Start()
        {
            _selectedObject.Subscribe(OnSelected);
        }

        private void OnSelected(ISelectable selected)
        {
            if(_currentSelectable == selected)
                return;
            
            _currentSelectable?.ShowOutline(false);
            
            _currentSelectable = selected;
            _currentSelectable?.ShowOutline(true);
        }
    }
}
