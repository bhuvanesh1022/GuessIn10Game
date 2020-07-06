using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public int sceneId;
    public int pencils;

    public List<bool> types;

    private void Awake()
    {
        if (GameHandler.gameHandler == null)
        {
            GameHandler.gameHandler = this;
        }
        else
        {
            if (GameHandler.gameHandler != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        GameHandler.gameHandler.UpdatePencils();
    }

    public void UpdatePencils() { UIManager.uim.pencilCountText.text = pencils.ToString(); }

}
