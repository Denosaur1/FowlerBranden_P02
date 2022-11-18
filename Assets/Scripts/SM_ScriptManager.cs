using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SM_ScriptManager : MonoBehaviour
{
    [SerializeField] public GameSM _gameSM;
    [SerializeField] public TurnManager _turnManager;
   
    //[SerializeField] public CharacterInfo _characterInfo;
    [SerializeField] public SetupGameState _setupState;
    [SerializeField] public PlayerTurnState _playerTurnState;
    [SerializeField] public ActionState _actionState;
    [SerializeField] public DrawCardsState _drawCardsState;
    [SerializeField] public WinState _winState;
    [SerializeField] public LossState _lossState;
    [SerializeField] public State currentState; 
    private void Update()
    {
        currentState = _gameSM.CurrentState;
    }

}
