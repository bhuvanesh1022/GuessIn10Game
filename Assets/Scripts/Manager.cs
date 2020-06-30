using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // load scene
    public void Loadscene()
    {
        SceneManager.LoadScene("CardDesign");
    }
}
