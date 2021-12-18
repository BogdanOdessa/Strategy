using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Abstractions;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.ExternalTools;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Core
{
    public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private OutlineTool _outlineTool;

        public float Health
        {
            get { return _health; }
        }

        private void Start()
        {
            _outlineTool.enabled = false;
        }

        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        
        public void ShowOutline(bool value)
        {
            _outlineTool.enabled = value;
        }

        private float _health = 1000;

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity,
                _unitsParent);
        }
        
    }
}

