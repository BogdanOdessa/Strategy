using System;
using Abstractions;
using Assets.Scripts.ExternalTools;
using UnityEngine;

public sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;

    public Vector3 RallyPoint;
    
    public void ShowOutline(bool value)
    {
        if(this)
            _outlineTool.enabled = value;
    }
    private void Start()
    {
        _outlineTool.enabled = false;
    }
    public Sprite Icon => _icon;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private OutlineTool _outlineTool;

    private float _health = 1000;
    
    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}