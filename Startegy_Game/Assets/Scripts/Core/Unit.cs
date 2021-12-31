using System;
using System.Runtime.CompilerServices;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.ExternalTools;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, ISelectable {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint { get; }
        public Sprite Icon => _icon;
        public GameObject GameObject => GO;

        [SerializeField] private GameObject GO;
        [SerializeField] protected OutlineTool _outlineTool;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        protected float _health = 100;
        
        private void Start()
        {
            ShowOutline(false);
           
        }
        public void ShowOutline(bool value)
        {
            _outlineTool.enabled = value;
        }
    }
}