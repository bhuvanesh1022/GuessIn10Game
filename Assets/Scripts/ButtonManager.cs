using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public bool available;

    public void OnClick(int id) { UIManager.uim.LoadingPage(id); }

}
