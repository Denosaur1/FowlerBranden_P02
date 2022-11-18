using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField]SM_ScriptManager scriptManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(scriptManager != null)
                scriptManager._turnManager.PauseGame();

        }
    }
    public void GoToNextStage() { SceneManager.LoadScene(1); }
    public void GoToPreviousStage() { SceneManager.LoadScene(0); }
    public void QuitGame()
    {
        Application.Quit();


    }
    
}
