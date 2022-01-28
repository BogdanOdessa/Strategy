using System;
using System.Runtime.CompilerServices;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.ExternalTools;
using Core.UpgradeCommand;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, ISelectable , IDamageDealer, IAttackable, IAutomaticAttacker, IUpgradable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public GameObject GameObject => _go;
        public Transform PivotPoint { get; set; }
        public Sprite Icon => _icon; 
        public int Damage => _damage;
        public float VisionRadius => _visionRadius;

        [SerializeField] private GameObject _go;
        [SerializeField] private float _visionRadius = 8f;
        [SerializeField] private int _damage = 25;
        [SerializeField] protected OutlineTool _outlineTool;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        
        protected float _health = 100;
        private static readonly int PlayDead = Animator.StringToHash("PlayDead");

        private void Start() => ShowOutline(false);
        public void ShowOutline(bool value)
        {
            if(this)
                _outlineTool.enabled = value;
        }
        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger(PlayDead);
                Invoke(nameof(DestroyGO), 1f);
            }
        }
        private async void DestroyGO()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }
        public void IncreaseAttack()
        {
            _damage++;
        }
    }
}