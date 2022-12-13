using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : CardGameState
{
    List<Card> _Turns;
     List<bool> _deadEvil = new List<bool>();
     List<bool> _deadGood = new List<bool>();

    [SerializeField] public GameObject buttons;
    int _turnCount;
    
    public override void Enter()
    {
       buttons.SetActive(false);
        _Turns = scriptManager._turnManager.TurnOrder;
    }
    public override void Tick()
    {
        if (!_Turns[_turnCount].actionDone)
        {
            
            _Turns[_turnCount].Action();
            
            
            return;


        }
        else {
            Destroy(scriptManager._turnManager._ActiveTurns[_turnCount]);
            _turnCount++;
            
        
        }
        if(_turnCount >= _Turns.Count) {


            foreach (EvilActor actor in scriptManager._turnManager.evilActors)
            {
                _deadEvil.Add(actor._isDead);

            }
            foreach (AllyActor actor in scriptManager._turnManager.allyActors)
            {
                _deadGood.Add(actor._isDead);

            }
            if (_deadEvil.Contains(false) && _deadGood.Contains(false)) {
                Debug.Log("Game Continues");
                StateMachine.ChangeState<DrawCardsState>();
                buttons.SetActive(true);
                _turnCount = 0;
                _deadGood.Clear();
                _deadEvil.Clear();
            }
            else if (_deadEvil.Contains(false))
                {
                    Debug.Log("Game Lost");
                    StateMachine.ChangeState<LossState>();
                }
            else {
                    Debug.Log("Game Won");
                    StateMachine.ChangeState<WinState>();
                }

            


           




        }
    }


}
