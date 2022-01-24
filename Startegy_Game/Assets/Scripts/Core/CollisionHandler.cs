using System;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Zenject.Asteroids;

namespace Core
{
    public class CollisionHandler : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private static readonly int Idle = Animator.StringToHash("Idle");
        
        private float _targetTime = 5.0f;
        private float _timerTime;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _timerTime = _targetTime;
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.GetComponent<MeshCollider>()) return;
            
            _timerTime -= Time.deltaTime;
            if (_timerTime <= 0.0f)
            {
                _animator.SetTrigger(Idle);
                _navMeshAgent.isStopped = true;
                _timerTime = _targetTime;
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.GetComponent<MeshCollider>()) return;
            _timerTime = _targetTime;
        }
    }
}
