using System;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using Assets.Scripts.ExternalTools;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, ISelectable {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private OutlineTool _outlineTool;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        private float _health = 100;
        
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