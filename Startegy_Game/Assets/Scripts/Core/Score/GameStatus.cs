using System;
using System.Collections.Generic;
using System.Threading;
using Abstractions;
using UniRx;
using UnityEngine;

public class GameStatus :MonoBehaviour, IGameStatus
{
    public IObservable<int> Status => _status;
    private Subject<int> _status = new Subject<int>();
    private FactionsDictionary _factionsDictionary;
    private void Start()
    {
        _factionsDictionary = FindObjectOfType<FactionsDictionary>();
    }
    private void CheckStatus(object state)
    {
        lock (_factionsDictionary)
        {
            if (_factionsDictionary.Count == 0)
            {
                _status.OnNext(0);
            }
            else if (_factionsDictionary.Count == 1)
            {
                _status.OnNext(_factionsDictionary.Winner);
            }
        }
    }
    private void Update()
    {
        ThreadPool.QueueUserWorkItem(CheckStatus);
    }
}