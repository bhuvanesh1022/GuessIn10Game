using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public bool available;
    public UIManager uim;

    public void OnClick(int id) { uim.LoadingPage(id); }
}
