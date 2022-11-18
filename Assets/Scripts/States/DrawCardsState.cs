using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsState : CardGameState
{
    
    
    bool _completed = false;
    public override void Enter()
    {
        Debug.Log("Begin Drawing Cards");
        

        foreach (Actor actor in scriptManager._turnManager.actors)
        {

            actor.DrawCard();
        }
        scriptManager._turnManager.TurnOrder.Clear();
        scriptManager._turnManager._ActiveTurns.Clear();
        _completed = false;
    }
    public override void Tick()
    {
        if (!_completed) {
            StateMachine.ChangeState<PlayerTurnState>();
            _completed=true;
        } 
    }
    public override void Exit()
    {
        _completed = false;
        Debug.Log("Done Drawing Cards");
    }

}
