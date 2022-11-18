using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class TurnManager : MonoBehaviour
{
    public List<Card> TurnOrder = new List<Card>();
    
    [SerializeField] public int turnMax;
    [SerializeField]  SM_ScriptManager scriptManager;
    
    public List<GameObject> _ActiveTurns =new List<GameObject>();

    public Actor[] actors;
    public EvilActor[] evilActors;
    //[SerializeField] public List<bool> _deadEvil = new List<bool>();
    public AllyActor[] allyActors;
    //[SerializeField] public List<bool> _deadGood = new List<bool>();

    [SerializeField] GameObject _spotParent;
    public bool gameWon = false;
    public bool gameLost = false;
    public bool paused = false;
    [SerializeField] GameObject pausedMenu;
     
    
    void Update()
    {

        CharacterInfo();
       pausedMenu.SetActive(paused);
    
        
        
        
            for (int i = 0; i < _ActiveTurns.Count; i++)
            {
                if (_ActiveTurns[i] != null)
                {
                    _ActiveTurns[i].transform.SetParent(_spotParent.transform);
                    _ActiveTurns[i].transform.localScale = new Vector3(1,1,1);
                    _ActiveTurns[i].transform.localPosition = new Vector3(0, (-70 * i));
                    TurnSpot _curSpot = _ActiveTurns[i].GetComponent<TurnSpot>();
                    if (_curSpot != null)
                    {
                    _curSpot._ownerImage.sprite = TurnOrder[i]._ownerImage;
                    _curSpot._targetImage.sprite = TurnOrder[i]._targetImage;
                    _curSpot._actionName.text = TurnOrder[i]._moveName;
                    _curSpot._targetName.text = TurnOrder[i]._targetName;
                    _curSpot._ownerName.text = TurnOrder[i]._ownerName;
                    //Debug.Log("Image Added");

                    }
                }
            }
        /*
        foreach (EvilActor actor in scriptManager._turnManager.evilActors)
        {
            _deadEvil.Add(actor._isDead);
           

        }
        if (_deadEvil.Contains(false))
        {
            
            _deadEvil.Clear();
        }
        else
        {
           
            gameWon = true;
            _deadEvil.Clear();
        }
        foreach (AllyActor actor in scriptManager._turnManager.allyActors)
        {
            _deadGood.Add(actor._isDead);
            
      

        }
        if (_deadGood.Contains(false))
        {
           
            _deadGood.Clear();
        }
        else { 
            gameLost = true;
           
            _deadGood.Clear();
        }
        */


    }



    public void ResetTurn() {
        if (!paused)
        {
            if (TurnOrder.Count > 0)
            {
                int _turnCount = TurnOrder.Count - 1;
                Card gameObject = TurnOrder[_turnCount];
                gameObject.visuals.SetActive(true);
                TurnOrder.Remove(TurnOrder[_turnCount]);
                GameObject _turnObj = _ActiveTurns[_turnCount];
                Destroy(_turnObj);
                _ActiveTurns.Remove(_ActiveTurns[_turnCount]);

            }
        }
    }
    public void CompleteTurn() {
        if (!paused)
        {
            if (TurnOrder.Count == turnMax)
            {
                Debug.Log("Turn Complete");
                scriptManager._playerTurnState.turnComplete = true;

            }
            else { Debug.Log("Not all actions queued"); }
        }
    
    }

    public void CharacterInfo() {

        foreach (Actor actor in actors)
        {
            if (actor._currentHealth <= 0)
            {
                actor._currentHealth = 0;
                actor._isDead = true;
            }
            else
            {
                actor._isDead = false;
            }
            if (actor._currentHealth > actor._maxHealth) { actor._currentHealth = actor._maxHealth; }
            actor._nameSpot.text = actor._name;
            actor._healthSpot.text = "HP: " + actor._currentHealth.ToString() + " / " + actor._maxHealth.ToString();
            actor._imageSpot.sprite = actor._image;




        }


    }
    public void PauseGame() {
        paused = !paused;
    
    }
    public void RestartGame() {
    
        scriptManager._gameSM.ChangeState<SetupGameState>();
    }
}
