using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void ReloadGame()
    {
        Debug.Log("Reload Game!!!");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("QUUUIT!!!");
        Application.Quit();
    }
    
    
}
