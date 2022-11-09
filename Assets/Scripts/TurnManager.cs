using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public List<Card> TurnOrder = new List<Card>();
    
    [SerializeField] public int turnMax;
    [SerializeField]PlayerTurnState State;
    public List<GameObject> _ActiveTurns =new List<GameObject>();
    public EvilActor[] evilActors;
    public AllyActor[] allyActors;
    [SerializeField] GameObject _spotParent;
   
 
    private void Update()
    {
      
        foreach (var turn in TurnOrder) {
            Card card = turn;
          
            

        }
        
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
        

       

    }



    public void ResetTurn() {
        
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
    public void CompleteTurn() {
        if (TurnOrder.Count == turnMax)
        {
            Debug.Log("Turn Complete");
            State.turnComplete = true;
          
        }
        else { Debug.Log("Not all actions queued"); }
    
    
    }

    

}
