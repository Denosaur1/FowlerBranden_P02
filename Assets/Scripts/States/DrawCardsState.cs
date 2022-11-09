using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsState : CardGameState
{
    [SerializeField] Actor[] actors;
    [SerializeField] TurnManager turnManager;
    bool _completed = false;
    public override void Enter()
    {
        Debug.Log("Begin Drawing Cards");
        actors = FindObjectsOfType<Actor>();

        foreach (Actor actor in actors)
        {

            actor.DrawCard();
        }
        turnManager.TurnOrder.Clear(); 
        turnManager._ActiveTurns.Clear();
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
