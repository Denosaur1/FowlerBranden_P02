using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyDamageCard : Card
{
    [SerializeField] int damageMin, damageMax;
    [SerializeField] int damageAmount;
    
    
    public override void CardInit()
    {
        damageAmount = Random.Range(damageMin, damageMax);
        _target = _scriptManager._turnManager.allyActors[Random.Range(0, _scriptManager._turnManager.allyActors.Length)];
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
