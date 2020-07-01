using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Guessframework;//arthi
using UnityEngine.SceneManagement;

public class CardDetails : MonoBehaviour
{
    [SerializeField] GuessAns CityQues;
    [SerializeField] GuessAns AnimalQues;
    [SerializeField] GuessAns BirdQues;

    public TextMeshProUGUI[] BuzzTxt;
    public TextMeshProUGUI ShowAns;
    public TextMeshProUGUI[] ShowClueTxt,ShowFactsTxt;
    public Image _imgHolder;

    public List<Guess> listAvailable = new List<Guess>();
    public List<Guess> listUsed = new List<Guess>();

    public Button next;

    public delegate void AnsGuessed();
    public static AnsGuessed OnAnsGuessed;

    private void Awake()
    {
        next.onClick.AddListener(NextCard);
    }

    private void Start()
    {
        listAvailable = new List<Guess>(CityQues.guess);
        NextCard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void NextCard()
    {
        if (listAvailable.Count != 0)
        {
            RefreshCard();
        }
    }

    void RefreshCard()
    {
        int rand;
        rand = Random.Range(0, listAvailable.Count);

        ShowAns.text = listAvailable[rand]._QuesAns;
        _imgHolder.GetComponent<Image>().sprite = listAvailable[rand].img;

        for (int i = 0; i < BuzzTxt.Length; i++)
            BuzzTxt[i].text = listAvailable[rand].buzz[i];

        for (int i = 0; i < ShowClueTxt.Length; i++)
            ShowClueTxt[i].text = listAvailable[rand].Clue[i];

        for (int i = 0; i < ShowFactsTxt.Length; i++)
            ShowFactsTxt[i].text = listAvailable[rand].Facts[i];

        listUsed.Add(listAvailable[rand]);
        listAvailable.RemoveAt(rand);
    }

    // Reset Game
    public void Loadscene()
    {
        SceneManager.LoadScene("Playpage");
    }
}
