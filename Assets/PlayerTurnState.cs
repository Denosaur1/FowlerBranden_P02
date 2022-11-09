using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : CardGameState
{

    public bool turnComplete = false;

    public override void Enter()
    {
        
        Debug.Log("Player Turn: ..Entering");
        turnComplete = false;
    }

  
    public override void Exit()
    {

        turnComplete = false;
        Debug.Log("Player Turn: ..Exiting");


    }
    public override void Tick()
    {
        if (turnComplete)
        {

            StateMachine.ChangeState<ActionState>();
        }
    }
}

