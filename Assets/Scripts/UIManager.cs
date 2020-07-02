using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager UIM;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    // load scene
    public void LoadingScene(int id)
    {
        GameHandler.gameHandler.sceneId = id;
        SceneManager.LoadScene(1);
    }

    public void LoadLogin()
    {

    }
}
