using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SetupGameState : CardGameState
{
    [SerializeField]Actor[] actors;
    [SerializeField]TurnManager turnManager;
    bool _activated = false;
    public override void Enter()
    {
        Debug.Log("Setting Up Actors");
        actors =FindObjectsOfType<Actor>();
        foreach (Actor actor in actors) {
           actor.Init();
            actor.DrawCard();
        }
        Debug.Log("Actors Set Up!");
        Debug.Log("Setting Up Turn Manager");
        turnManager.evilActors = FindObjectsOfType<EvilActor>();
        turnManager.allyActors = FindObjectsOfType<AllyActor>();
        turnManager.turnMax = actors.Length;
        _activated = false;
        Debug.Log("Turn Manager Set Up!");
        
    }

    public override void Tick()
    {
        if (!_activated) {

            _activated = true;
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }


    public override void Exit()
    {
        _activated = false;
        Debug.Log("Set Up Done");
    }
}
