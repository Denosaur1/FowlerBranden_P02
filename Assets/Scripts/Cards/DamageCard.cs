using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : Card
{
    [SerializeField] int damageMin, damageMax;
    [SerializeField] int damageAmount;
    int targetAttempts;
    public override void CardInit()
    {
        damageAmount = Random.Range(damageMin, damageMax);
        _target = _scriptManager._turnManager.evilActors[Random.Range(0, _scriptManager._turnManager.evilActors.Length)];
        while (_target._currentHealth == 0 && targetAttempts < _scriptManager._turnManager.evilActors.Length) { 
            _target = _scriptManager._turnManager.evilActors[Random.Range(0, _scriptManager._turnManager.evilActors.Length)]; 
            targetAttempts++;
        }
        _moveName = "Damage: " + damageAmount;
    }
   

    public override void CardAction()
    {
        _target._currentHealth -= damageAmount;
    }

    public override void Hover()
    {
        base.Hover();
        
        
    }
    
}
