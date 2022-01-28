using System.Collections;
using System.Collections.Generic;
using Abstractions.Commands;
using Core;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable
{
    public float Health { get; }
    public float MaxHealth { get; }
    public void RecieveDamage(int amount)
    {
       
    }
}
