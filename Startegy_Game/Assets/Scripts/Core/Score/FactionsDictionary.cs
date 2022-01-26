using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactionsDictionary : MonoBehaviour
{
    private Dictionary<int, List<int>> _factionDictionary;
    public int Count => _factionDictionary.Count;
    public int Winner => _factionDictionary.Keys.First();
    private void Awake() => _factionDictionary = new Dictionary<int, List<int>>();
    public void Register(int factionId, int unitID) 
    { 
        if(!_factionDictionary.ContainsKey(factionId)) 
            _factionDictionary.Add(factionId, new List<int>());
        if(!_factionDictionary[factionId].Contains(GetInstanceID()))
            _factionDictionary[factionId].Add(unitID);
    }
    public void Unregister(int factionId, int unitID)
    {
        if (_factionDictionary[factionId].Contains(unitID))
            _factionDictionary[factionId].Remove(unitID);
        if (_factionDictionary[factionId].Count == 0)
            _factionDictionary.Remove(factionId);
    }
}
