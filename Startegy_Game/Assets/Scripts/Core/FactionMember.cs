using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class FactionMember : MonoBehaviour, IFactionMember
{
    public int FactionId => _factionId;
    [SerializeField] private int _factionId;
    private int _unitID;
    private FactionsDictionary _factionsDictionary;
    private void Start()
    {
        _unitID = GetInstanceID();
        _factionsDictionary = FindObjectOfType<FactionsDictionary>();
        _factionsDictionary.Register(_factionId, _unitID);
    }
    public void SetFaction(int factionId)
    {
        _factionId = factionId;
    }
    private void OnDestroy()
    {
        _factionsDictionary.Unregister(_factionId, _unitID);
    }
    
}