using System.Collections;
using System.Collections.Generic;
using Abstractions;
using Assets.Scripts.ExternalTools;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public GameObject GameObject => _go;
    public Transform PivotPoint => _pivotPoint;
    
    [SerializeField] private GameObject _go;
    [SerializeField] private float _maxHealth = 500;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private OutlineTool _outlineTool;
    private float _health = 500;
    private void Start()
    {
        _outlineTool.enabled = false;
    }
    public void ShowOutline(bool value)
    {
        if(this)
            _outlineTool.enabled = value;
    }
   
}
