using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions;
using Assets.Scripts.ExternalTools;
using Core;
using UnityEngine;

public class TeleportUnit : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public GameObject GameObject => _go;
    public Transform PivotPoint { get; set; }
    public Sprite Icon => _icon; 
    
    [SerializeField] private GameObject _go;
    [SerializeField] protected OutlineTool _outlineTool;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;

    private float _health = 50f;

    private void Start()
    {
        ShowOutline(false);
    }

    public void ShowOutline(bool value)
    {
        _outlineTool.enabled = value;
    }
}
