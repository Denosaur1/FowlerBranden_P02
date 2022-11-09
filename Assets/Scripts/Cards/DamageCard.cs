using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : Card
{
    [SerializeField] int damageMin, damageMax;
    [SerializeField] int damageAmount;
   
    public override void CardInit()
    {
       damageAmount = Random.Range(damageMin, damageMax);
        _target = _turnManager.evilActors[Random.Range(0, _turnManager.evilActors.Length)];
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
