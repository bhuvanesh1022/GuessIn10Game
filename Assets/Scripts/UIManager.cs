using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uim;

    public PopupManager popupManager;
    public TextMeshProUGUI userNameText;

    public TextMeshProUGUI pencilCountText;

    public List<ButtonManager> buttons = new List<ButtonManager>();

    private void Awake()
    {
        if (UIManager.uim == null)
        {
            UIManager.uim = this;
        }
        else
        {
            if (UIManager.uim != this)
            {
                Destroy(gameObject);
            }
        }
    }

    //private void Start()
    //{
    //    GameHandler.gameHandler.UpdatePencils();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { CloseNow(); }
    }

    public void CloseNow()
    {
        if (popupManager.currentPopup)
        {
            popupManager.currentPopup.SetActive(false);
            popupManager.currentPopup = null;
            buttons[0].transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Application.Quit();
            Debug.Log("GameClosed");
        }
    }

    public void LoadingPage(int id)
    {
        if (GameHandler.gameHandler.types[id])
        {
            GameHandler.gameHandler.sceneId = id;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Unlocking");
            popupManager.ToUnlockGuess(id);
        }
    }
}
