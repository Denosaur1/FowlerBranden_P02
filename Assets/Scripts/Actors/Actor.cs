
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    [System.Serializable]
    public struct Actions
    {
        public GameObject actionCard;
        public int weight;
    }
    [SerializeField] public GameObject _indicator;
    [SerializeField] public GameObject _target;
    [SerializeField] public Material _material;
    [SerializeField] public GameObject _currentCard;
    [SerializeField] public GameObject _spot;
    //info
    [SerializeField] public Sprite _image;
    [SerializeField] public Image _imageSpot;
    [SerializeField] public int _health;
    public int _currentHealth, _maxHealth;
    [SerializeField] public TextMeshProUGUI _healthSpot;
    [SerializeField] public string _name;
    [SerializeField] public TextMeshProUGUI _nameSpot, _namePlate;

    public int choice;
    public List<Actions> _possibleActions = new List<Actions>();
    public List<GameObject> _deck = new List<GameObject>();
    public bool _isDead;
    //move to setup state
    public void Init()
    {
        _maxHealth = _health;
        _currentHealth = _health;
        _isDead = false; 
        for (int i = 0; i < _possibleActions.Count; i++) {
            
            for (int j = 0; j < _possibleActions[i].weight+1; j++)
            {
                _deck.Add(_possibleActions[i].actionCard);

            }
        
        }
        if(_name == "") { _name = this.name; }
        _namePlate.text = _name;
        
    }

    


    public void DrawCard() {
        if (_spot && _deck.Count > 0)
        {
            choice = (int)Random.Range(1, _deck.Count) - 1;
            _currentCard = Instantiate(_deck[choice]);
            _currentCard.transform.SetParent(_spot.transform);
            _currentCard.transform.position = _spot.transform.position;
            _currentCard.GetComponent<Card>()._owner = this;

        }
    }
}
