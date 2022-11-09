using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }
    State _currentState;
    protected State _previousState;



    public void ChangeState<T>() where T : State {
        T targetState = GetComponent<T>();
        if (targetState == null) {
            Debug.LogWarning("No State is attached to the State Machine");
            return;



        }
        InitiateStateChange(targetState);
    
    
    }


    public void RevertState() {
        if (_previousState != null) { InitiateStateChange(_previousState); }
    
    }
    void InitiateStateChange(State targetState) {
        if (_currentState != targetState && !InTransition) {
            Transisition(targetState);
        
        }
    
    
    }

    void Transisition(State newState) {
        InTransition = true;
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        InTransition = false;
    
    
    }
    private void Update()
    {
        if (CurrentState && !InTransition) {
            CurrentState.Tick();
        
        }
    }

}
