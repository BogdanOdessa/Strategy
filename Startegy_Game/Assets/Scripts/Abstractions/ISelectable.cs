using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder
    {
        void ShowOutline(bool value);
        Transform PivotPoint { get; }
        Sprite Icon { get; }
    }
}