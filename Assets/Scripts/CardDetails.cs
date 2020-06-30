using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Guessframework;//arthi
using UnityEngine.SceneManagement;
public class CardDetails : MonoBehaviour
{
    public TextMeshProUGUI Buzztxt1, Buzztxt2, Buzztxt3,Showans;
    public TextMeshProUGUI[] ShowCluetxt,ShowFacts;
    //public Button[] _Cluebtn;
    public TMP_InputField _displaytxt;
    int _buzzval;
    public Sprite[] Logoimg;
    public Image bgimg;

    [SerializeField] GussInQues QuesUi;

    public List<Guess> listAvailable = new List<Guess>();
    int rand;
    public string _checkstr;
    private void Start()

    {
        listAvailable = new List<Guess>(QuesUi.guess);
        GameStart();
    }

    private void Update()
    {
        //_checkstr = _displaytxt.text;
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void GameStart()
    {
        rand = Random.Range(0,listAvailable.Count);
        print("1-----" + rand+ listAvailable[rand]._QuesAns);
       Buzztxt1.text = listAvailable[rand].buzz[0];
       Buzztxt2.text = listAvailable[rand].buzz[1];
       Buzztxt3.text = listAvailable[rand].buzz[2];
        Showans.text= listAvailable[rand]._QuesAns;
        ShowCluetxt[0].text = listAvailable[rand].Clue[0];
        ShowCluetxt[1].text = listAvailable[rand].Clue[1];
        ShowCluetxt[2].text = listAvailable[rand].Clue[2];
        ShowFacts[0].text = listAvailable[rand].Facts[0];
        ShowFacts[1].text = listAvailable[rand].Facts[1];
        ShowFacts[2].text = listAvailable[rand].Facts[2];
        ShowFacts[3].text = listAvailable[rand].Facts[3];
        bgimg.GetComponent<Image>().sprite = Logoimg[rand];
    }

    // load scene
    public void Loadscene()
    {
        SceneManager.LoadScene("Playpage");
    }
    // load scene
    public void Nextfun()
    {
        SceneManager.LoadScene("CardDesign");
    }
}
