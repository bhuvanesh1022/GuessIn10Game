using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public int sceneId;

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
