using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SetupGameState : CardGameState
{
   
  
    bool _activated = false;
    public override void Enter()
    {
        
        Debug.Log("Setting Up Turn Manager");
        scriptManager._turnManager.actors = FindObjectsOfType<Actor>();
        scriptManager._turnManager.evilActors = FindObjectsOfType<EvilActor>();
        scriptManager._turnManager.allyActors = FindObjectsOfType<AllyActor>();
       
        scriptManager._turnManager.paused = false;
        scriptManager._actionState.buttons.SetActive(true);
        scriptManager._turnManager.turnMax = scriptManager._turnManager.actors.Length;
        Debug.Log("Turn Manager Set Up!");
        Debug.Log("Setting Up Actors");
        foreach (Actor actor in scriptManager._turnManager.actors) {
           actor.Init();
            //actor.DrawCard();
        }
        
        Debug.Log("Actors Set Up!");
        
        
        
        _activated = false;
       
        
    }

    public override void Tick()
    {
        if (!_activated) {

            _activated = true;
            StateMachine.ChangeState<DrawCardsState>();
        }
    }


    public override void Exit()
    {
        _activated = false;
        Debug.Log("Set Up Done");
    }
}
