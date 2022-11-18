using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : CardGameState
{
    [SerializeField] GameObject WinObject;
    public override void Enter()
    {
        Debug.Log("Game Won");
    }


    public override void Tick()
    {
        WinObject.SetActive(true);
    }
    public override void Exit()
    {
        WinObject.SetActive(false);
    }
}
