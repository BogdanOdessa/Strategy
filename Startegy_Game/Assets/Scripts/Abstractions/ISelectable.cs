using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder, IIconHolder
    {
        GameObject GameObject { get; }
        Transform PivotPoint { get; }
        void ShowOutline(bool value);
    }
}