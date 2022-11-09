
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : Card
{
    [SerializeField] int healMin, healMax;
    [SerializeField] int healAmount;
    

    public override void CardInit()
    {
        healAmount = Random.Range(healMin, healMax);
        _target = _turnManager.allyActors[Random.Range(0, _turnManager.allyActors.Length)];
        _moveName = "Heal: " + healAmount;
    }
    

    public override void CardAction()
    {
        _target._currentHealth += healAmount;
        
    }
    public override void Hover()
    {
        base.Hover();

        
    }
}
