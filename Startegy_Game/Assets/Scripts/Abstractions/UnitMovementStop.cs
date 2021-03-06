using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows.WebCam;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public class StopAwaiter: AwaiterBase<AsyncExtensions.Void,UnitMovementStop>
        {
            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                ParentClass = unitMovementStop;
                ParentClass.OnStop += ONStop;
            }
            public override AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
            private void ONStop()
            {
                ParentClass.OnStop -= ONStop;
                IsCompleted = true;
                Continuation?.Invoke();
            }
        }
        // public class StopAwaiter : IAwaiter<AsyncExtensions.Void>
        // {
        //     private readonly UnitMovementStop _unitMovementStop;
        //     private Action _continuation;
        //     private bool _isCompleted;
        //
        //     public StopAwaiter(UnitMovementStop unitMovementStop)
        //     {
        //         _unitMovementStop = unitMovementStop;
        //         _unitMovementStop.OnStop += ONStop;
        //     }
        //
        //     private void ONStop()
        //     {
        //         _unitMovementStop.OnStop -= ONStop;
        //         _isCompleted = true;
        //         _continuation?.Invoke();
        //     }
        //
        //     public void OnCompleted(Action continuation)
        //     {
        //         if (_isCompleted)
        //         {
        //             continuation?.Invoke();
        //         }
        //         else
        //         {
        //             _continuation = continuation;
        //         }
        //     }
        //     public bool IsCompleted => _isCompleted;
        //     public AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
        // }
        public event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}