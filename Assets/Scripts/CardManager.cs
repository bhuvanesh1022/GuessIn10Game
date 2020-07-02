using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Guessframework;//arthi
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    #region PRIVATE VARIABLES

    [SerializeField] GuessAns[] Quesses;
    [SerializeField] string[] Title;
    [SerializeField] Color[] ThemeColor;

    private GameHandler _gameHandler;

    #endregion

    #region PUBLIC VARIABLES

    public TextMeshProUGUI _title;
    public Image[] themed;

    public TextMeshProUGUI[] BuzzTxt;
    public TextMeshProUGUI ShowAns;
    public TextMeshProUGUI[] ShowClueTxt,ShowFactsTxt;
    public Image _imgHolder;

    public List<Guess> listAvailable = new List<Guess>();
    public List<Guess> listUsed = new List<Guess>();

    public Button next;

    public delegate void AnsGuessed();
    public static AnsGuessed OnAnsGuessed;

    #endregion

    #region DEFAULT METHODS

    private void Awake()
    {
        next.onClick.AddListener(NextCard);
        _gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    private void Start()
    {
        listAvailable = new List<Guess>(Quesses[_gameHandler.sceneId].guess);
        _title.text = Title[_gameHandler.sceneId];

        for (int i = 0; i < themed.Length; i++) themed[i].color = ThemeColor[_gameHandler.sceneId];

        NextCard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    #endregion

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
        SceneManager.LoadScene(0);
    }
}
