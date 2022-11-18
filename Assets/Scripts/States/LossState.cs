using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossState : CardGameState
{
    [SerializeField] GameObject LossObject;
    public override void Enter()
    {
        Debug.Log("Game Lost");
    }
    public override void Tick()
    {
        LossObject.SetActive(true);
    }
    public override void Exit()
    {
        LossObject.SetActive(false);
    }
}
