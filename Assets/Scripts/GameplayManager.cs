using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Guessframework;//arthi
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
   /*
     public TextMeshProUGUI Buzztxt1, Buzztxt2;
    public List<string> _buzzkeyword; 
    public Button[] _Cluebtn;
    public TMP_InputField _displaytxt;
    int _buzzval;
    public List<string> _emptyclue;

  [SerializeField] GuessCity QuesUi;
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
        _checkstr = _displaytxt.text;

    }
    void GameStart()
    {
        rand = Random.Range(0,listAvailable.Count);
        print("1-----" + rand+ listAvailable[rand]._QuesAns);
       Buzztxt1.text = listAvailable[rand].buzz[0];
       Buzztxt2.text = listAvailable[rand].buzz[1];
    }

    // check text SUBMIT
    public void CheckString()
    {
        if(_checkstr.ToUpper().Contains(listAvailable[rand]._QuesAns.ToUpper()))
        {
            print("correct");
            Invoke("systemAnsYes",1f);
        }
        else
        {
            print("Wrong");
            Invoke("systemAnsNo", 1f);

        }
    }
    void systemAnsYes()
    {
        _displaytxt.text = "Yes";
        Invoke("Loadscene", 1f);

    }
    void systemAnsNo()
    {
        _displaytxt.text = "No";
    }
    //show clue card
    public void _showClue_card(int n)
    {
        _displaytxt.text = listAvailable[rand].Clue[n];
    }
    // load scene
    public void Loadscene()
    {
        SceneManager.LoadScene("GussInGame");
    }
    */
}
