using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public List<ButtonManager> buttons = new List<ButtonManager>();
    public int sceneId;
    public int pencils;

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
    
}
