using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PopupManager popupManager;
    public TextMeshProUGUI pencilCountText;

    private void Update()
    {
        pencilCountText.text = GameHandler.gameHandler.pencils.ToString();

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
        
    public void LoadingScene(int id)
    {
        GameHandler.gameHandler.sceneId = id;
        SceneManager.LoadScene(1);
}
