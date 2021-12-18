using System;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;
using ISelectable = Assets.Scripts.Abstractions.ISelectable;


namespace Assets.Scripts.UserControlSystem.Presenter
{
    public class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;


        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }

            /*
        var mainBuilding = hits
            .Select(hit => hit.collider.GetComponentInParent<IUnitProducer>())
            .Where(c => c != null)
            .FirstOrDefault();
        if (mainBuilding == default)
        {
            return;
        }
        mainBuilding.ProduceUnit();
        */
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(c => c != null);
            _selectedObject.SetValue(selectable);
        }
    }
}
