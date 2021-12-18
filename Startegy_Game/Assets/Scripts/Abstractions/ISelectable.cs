using UnityEngine;

namespace Assets.Scripts.Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }

        void ShowOutline(bool value);

    }
}
