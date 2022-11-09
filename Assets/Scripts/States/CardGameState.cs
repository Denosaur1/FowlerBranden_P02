using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameState : State
{
    protected GameSM StateMachine { get; private set; }
    private void Awake()
    {
        StateMachine = GetComponent<GameSM>();
    }

}
