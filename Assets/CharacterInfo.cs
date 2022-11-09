using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] Actor[] actors;

    // Update is called once per frame
    void Update()
    {
        actors = FindObjectsOfType<Actor>();

        foreach (Actor actor in actors)
        {
            if(actor._currentHealth <= 0) { actor._currentHealth = 0; }
            if(actor._currentHealth > actor._maxHealth) {actor._currentHealth = actor._maxHealth; }
            actor._nameSpot.text = actor._name;
            actor._healthSpot.text = "HP: " +actor._currentHealth.ToString() + " / " + actor._maxHealth.ToString();
            actor._imageSpot.sprite = actor._image;
           



        }
    }
}
