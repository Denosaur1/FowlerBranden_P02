using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    [SerializeField] public Actor _owner;
    [SerializeField] protected SM_ScriptManager _scriptManager;
    
    [SerializeField] public TextMeshProUGUI _moveText, _targetText, _ownerText;
    
    [SerializeField] public GameObject visuals;
    [SerializeField] GameObject _turnSpotPrefab, _particlePrefab;

    

  

    //Action Info
    [SerializeField] public string _moveName, _ownerName, _targetName;
    [SerializeField] public Sprite _targetImage, _ownerImage;
    GameObject _particles;
    public Actor _target;
    
    private MeshRenderer _renderer;
    public bool actionDone = false;
    public float actionTime = 1;
    bool hovering;
    public void Start()
    {
        _scriptManager = FindObjectOfType<SM_ScriptManager>();
        _renderer = visuals.GetComponent<MeshRenderer>();
       
        CardInit();
        _ownerImage = _owner._image;
        _targetImage = _target._image;
        _ownerName = _owner._name;
        _targetName = _target._name;
     



        _renderer.material = _owner._material;
        _moveText.text = _moveName;
        _targetText.text = "To: " + _targetName;
        _ownerText.text = _ownerName +"'s Turn";
       

    }
    public void Action() {

        if(_owner._isDead) { 
            StartCoroutine(Delayer(1));
            return;
        }
        else { StartCoroutine(DoAction(actionTime));}
        
    
    }
    public abstract void CardAction();
    public virtual void CardInit() { }
    public virtual void Hover() {

        
        _owner._indicator.SetActive(true);
        _target._target.SetActive(true);
        hovering = true;
    }
    

    private void OnMouseOver()
    {
        if (!hovering && !_scriptManager._turnManager.paused)
        {
            _scriptManager._audioManager.Play("HOVER");

        }
        if(visuals.activeSelf && !_scriptManager._turnManager.paused)
            Hover();
    }
    private void OnMouseExit()
    {

        if (visuals.activeSelf && !_scriptManager._turnManager.paused)
        {
            _owner._indicator.SetActive(false);
            _target._target.SetActive(false);
            hovering = false;
        }
    }
    private void OnMouseDown()
    {
        if (visuals.activeSelf && !_scriptManager._turnManager.paused)
        {
            _scriptManager._audioManager.Play("CLICK");
            _scriptManager._turnManager.TurnOrder.Add(this);
            _owner._indicator.SetActive(false);
            visuals.SetActive(false);
            GameObject _turnObj = Instantiate(_turnSpotPrefab);

            _scriptManager._turnManager._ActiveTurns.Add(_turnObj);
            _target._target.SetActive(false);
        }
    }
  protected IEnumerator Delayer(float duration)
    {
        yield return new WaitForSeconds(duration);
        actionDone = true;
        Destroy(this.gameObject);
    }
    protected IEnumerator DoAction(float duration)
    {

        yield return new WaitForSeconds(duration);
        CardAction();
        
        if (_particlePrefab != null)
        {
            _particles = Instantiate(_particlePrefab);
            _particles.transform.position = _target.gameObject.transform.position;
        }
        actionDone = true;
        Destroy(this.gameObject);

    }

}
