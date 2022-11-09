using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : CardGameState
{
    List<Card> _Turns;
    [SerializeField] TurnManager turnManager;
    [SerializeField] GameObject buttons;
    int _turnCount;
    
    public override void Enter()
    {
       buttons.SetActive(false);
        _Turns = turnManager.TurnOrder;
    }
    public override void Tick()
    {
        if (!_Turns[_turnCount].actionDone)
        {
            
            _Turns[_turnCount].Action();
            
            
            return;


        }
        else {
            Destroy(turnManager._ActiveTurns[_turnCount]);
            _turnCount++;
            
        
        }
        if(_turnCount >= _Turns.Count) { 
            StateMachine.ChangeState<DrawCardsState>();
            buttons.SetActive(true);
            _turnCount = 0;
            
        }
    }


}
