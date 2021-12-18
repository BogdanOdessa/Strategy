using Assets.Scripts.Abstractions;
using Assets.Scripts.UserControlSystem;
using UnityEngine;

namespace Assets.Scripts.UserControlSystem.Presenter
{
    public class OutlineDrawerPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedObject;
        private ISelectable _currentSelectable;
    
        private void Start()
        {
            _selectedObject.OnSelected += OnSelected;
            OnSelected(_selectedObject.CurrentValue);
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