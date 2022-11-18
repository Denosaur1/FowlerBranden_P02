using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameState : State
{
    [SerializeField] protected SM_ScriptManager scriptManager;
    protected GameSM StateMachine { get; private set; }
    private void Awake()
    {
        StateMachine = GetComponent<GameSM>();
    }

}
